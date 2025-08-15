import os
import re
import argparse
import textwrap

# ==============================================================================
# DANH SÁCH TÙY CHỈNH
# ==============================================================================
# THÊM TÊN CÁC LỚP (CLASS) BẠN MUỐN COI LÀ "BẢNG HỆ THỐNG" VÀO ĐÂY
# Ví dụ: ["MyCustomSystemTable", "AnotherSpecialOne"]
MANUAL_SYSTEM_ENTITIES = [
    # "TenLop1", 
    # "TenLop2"
]

# DANH SÁCH CÁC VIEW - Script sẽ tự động thêm .ToView()
# Thêm tên lớp (class) của các View vào đây
# Ví dụ: ["AccountInvoiceReport"]
VIEW_ENTITIES = [
    # "TenView1",
    # "TenView2"
]


# CÁC BẢNG CẦN COMMENT OUT QUAN HỆ MANY-TO-MANY
# Có nhiều bảng tham chiếu đến nó, vậy thì để các bảng đó quyết định quan hệ.
# Thêm tên các lớp (class) vào đây.
COMMENT_OUT_M2M_RELATIONSHIPS = [
    #"ResCompany" # 166
]

# CÁC BẢNG CẦN COMMENT OUT QUAN HỆ ONE-TO-MANY
# Thêm tên các lớp (class) vào đây.
COMMENT_OUT_O2M_RELATIONSHIPS = [
    "AccountAccount", # 14
    #"AccountAnalyticAccount", # 6
    #"AccountFiscalPosition",
    #"AccountJournal", # 20
    #"AccountMove", # 11
    #"AccountPayment", # 15
    #"AccountTax", # 15
    #"CrmLead", # 8
    #"CrmTeam", # 8
    #"EventEvent",
    #"HrDepartment", # 8
    #"HrEmployee", # 8   
    "IrAttachment", # 13
    #"IrModel",
    #"IrModelFields",
    #"IrModuleModule",
    #"IrUiView",
    #"MailActivityType",
    #"MailMessage",
    #"MailTemplate",
    #"MrpProduction", # 7
    #"ProductProduct", # 8
    #"ProductTemplate", # 15
    #"ProjectProject",
    "ResCompany",
    "ResCountry", # 7
    "ResCurrency", # 
    #"ResGroups", # 17
    "ResPartner", # 25
    #"ResPartnerCategory", # 5
    "ResUsers", # 23
    #"SaleOrder",
    #"SaleOrderLine",
    #"StockLocation",
    #"StockPicking", # 9
    #"StockPickingType",
    #"StockWarehouse", # 7
    "UomUom", # 7
    "Website"
]

PROPERTIES_TO_CLEAN_WITHMANY = [
    "Company", "CreateU", "WriteU", "User", "Currency",
    "Country", "Partner", "PartnerCategory", "MessageMainAttachment",
    "Account", "Journal", "Product", "ProductUom", "ProductCateg"
]

# ==============================================================================
# CÁC HÀM TRỢ GIÚP
# ==============================================================================

def find_statement_end_index(lines, start_index):
    """Tìm dòng kết thúc của một câu lệnh C# bằng cách đếm ngoặc."""
    paren_count = 0
    in_string = False
    for i in range(start_index, len(lines)):
        line = lines[i]
        # Bắt đầu đếm ngoặc từ dòng đầu tiên
        if i == start_index:
            for char in line:
                if char == '"': in_string = not in_string
                if not in_string and char == '(': paren_count += 1
        
        for char in line:
            if char == '"': in_string = not in_string
            if not in_string:
                if i > start_index and char == '(': paren_count += 1
                elif char == ')': paren_count -= 1
        
        if paren_count == 0 and line.strip().endswith(';'):
            return i
    return start_index

def find_fluent_entity_configs(code):
    """Sử dụng phương pháp đếm ngoặc để tìm khối entity một cách chính xác."""
    configs = []
    start_pattern = re.compile(r'modelBuilder\.Entity<([a-zA-Z_0-9]+)>\s*\(')
    for match in start_pattern.finditer(code):
        entity_name = match.group(1)
        content_start_index = match.end()
        paren_level, current_pos, end_pos = 1, content_start_index, -1
        while current_pos < len(code):
            char = code[current_pos]
            if char == '(': paren_level += 1
            elif char == ')': paren_level -= 1
            if paren_level == 0:
                end_pos = current_pos + 2 if code[current_pos+1:current_pos+2] == ';' else current_pos + 1
                break
            current_pos += 1
        if end_pos == -1: continue
        full_block_text = code[match.start():end_pos]
        body_match = re.search(r'entity\s*=>\s*{', full_block_text, re.DOTALL)
        if not body_match: continue
        inner_body_start_in_block = body_match.end()
        brace_level, inner_body_end_in_block = 1, -1
        current_pos_in_block = inner_body_start_in_block
        while current_pos_in_block < len(full_block_text):
            char = full_block_text[current_pos_in_block]
            if char == '{': brace_level += 1
            elif char == '}': brace_level -= 1
            if brace_level == 0:
                inner_body_end_in_block = current_pos_in_block
                break
            current_pos_in_block += 1
        if inner_body_end_in_block != -1:
            body_content = full_block_text[inner_body_start_in_block:inner_body_end_in_block]
            configs.append({'name': entity_name, 'body': body_content})
    return configs

# ==============================================================================
# GIAI ĐOẠN 1: XÂY DỰNG BẢN ĐỒ QUAN HỆ
# ==============================================================================



# ==============================================================================
# GIAI ĐOẠN 2: TÁI CẤU TRÚC VÀ TÁCH FILE FLUENT
# ==============================================================================

def analyze_and_transform_fluent_block(entity_name, body_content, schema_map):
    """Phân tích và biến đổi một khối cấu hình Fluent, sử dụng schema_map."""
    key_match = re.search(r'HasKey\(e\s*=>\s*new\s*{\s*([^}]*)}\)', body_content)
    if key_match:
        key_content = key_match.group(1)
        key_count = key_content.count('e.')
        property_count = body_content.count('entity.Property(e => e.')
        if key_count == 2 and property_count == 2:
            print(f"    -> Phát hiện bảng nối M2M, sẽ bỏ qua.")
            return ("SKIP", None)

    if entity_name in VIEW_ENTITIES:
        print(f"    -> Phát hiện View.")
        view_db_name = re.sub(r'(?<!^)(?=[A-Z])', '_', entity_name).lower()
        transformed_content = f'entity.ToView("{view_db_name}", "public");\n\n{body_content}'
        return ("PROCESS", transformed_content)

    current_content = body_content
    has_composite_key = 'HasKey(e => new { e.' in current_content
    
    # Dùng schema_map để kiểm tra company_id
    has_company_id_fk = False
    if entity_name in schema_map:
        for prop in schema_map[entity_name]['properties'].values():
            if prop.get('foreign_key') == 'CompanyId':
                has_company_id_fk = True
                break

    is_system_entity = entity_name.startswith(('Ir', 'Res', 'Bas')) or entity_name in MANUAL_SYSTEM_ENTITIES
    should_add_multitenancy = (not is_system_entity or (is_system_entity and has_company_id_fk)) and not has_composite_key

    if should_add_multitenancy:
        print("    -> Đánh dấu là MultiTenant.")
        current_content = re.sub(r'(Property\(e\s*=>\s*e\.)CompanyId', r'\1TenantId', current_content)
        current_content = re.sub(r'(\.HasIndex\((.|\n)*?e\.)CompanyId', r'\1TenantId', current_content)
        tenant_id_property_code = 'entity.Property(e => e.TenantId).HasColumnName("company_id");'
        id_block_pattern = re.compile(r'(Property\(e\s*=>\s*e\.Id\).*?;)', re.DOTALL)
        if id_block_pattern.search(current_content):
            current_content = id_block_pattern.sub(r'\1\n\n            ' + tenant_id_property_code, current_content, count=1)
        else:
             current_content = tenant_id_property_code + '\n\n' + current_content
        tenant_id_index_code = r'entity.HasIndex(e => e.TenantId);'
        to_table_pattern = re.compile(r'(entity\.ToTable\(.*?\);)')
        if to_table_pattern.search(current_content):
            current_content = to_table_pattern.sub(r'\1\n\n            ' + tenant_id_index_code, current_content, count=1)
        else:
            current_content = current_content + '\n\n' + tenant_id_index_code

    replacements = {'CreateUid': 'CreatorId', 'WriteUid': 'LastModifierId', 'CreateDate': 'CreationTime', 'WriteDate': 'LastModificationTime'}
    for old, new in replacements.items():
        current_content = re.sub(rf'([de]\.\s*){old}', rf'\1{new}', current_content)
        current_content = re.sub(rf'_{old.lower()}_', f'_{new.lower()}_', current_content)
        current_content = re.sub(rf'_{old.lower()}$', f'_{new.lower()}', current_content)

    for prop_name in PROPERTIES_TO_CLEAN_WITHMANY:
        pattern = re.compile(r'(\s*entity\.HasOne\(\s*d\s*=>\s*d\.' + prop_name + r'\s*\)\s*\.WithMany\()([^\)]*)(\))')
        current_content = pattern.sub(r'\1\3', current_content)
    
    return ("PROCESS", current_content)

def split_and_refactor_fluent(fluent_content, schema_map, args):
    """Hàm điều khiển việc tái cấu trúc và tách file Fluent API."""
    print("\nGiai đoạn 2: Bắt đầu tái cấu trúc và tách file Fluent API...")
    output_dir = args.output_fluent
    views_dir = os.path.join(output_dir, "Views")
    os.makedirs(output_dir, exist_ok=True)
    os.makedirs(views_dir, exist_ok=True)
    
    entity_blocks = find_fluent_entity_configs(fluent_content)
    processed_methods = []

    for config in entity_blocks:
        entity_name = config['name']
        original_body = config['body']
        print(f"  - Đang xử lý Fluent cho: {entity_name}")
        
        status, transformed_body = analyze_and_transform_fluent_block(entity_name, original_body, schema_map)
        
        if status == "SKIP":
            continue

        method_name = f'Configure{entity_name}'
        processed_methods.append(method_name)
        
        lines = transformed_body.split('\n')
        while lines and not lines[0].strip(): lines.pop(0)
        while lines and not lines[-1].strip(): lines.pop()
        
        final_body = ""
        if lines:
            normalized_body = textwrap.dedent('\n'.join(lines))
            final_body = textwrap.indent(normalized_body, ' ' * 12)
        
        full_block_for_file = f"modelBuilder.Entity<{entity_name}>(entity =>\n            {{\n{final_body}\n            }});"
        file_content = create_individual_config_file(entity_name, full_block_for_file, args.namespace, args.classname)
        
        target_dir = views_dir if status == "VIEW" else output_dir
        file_path = os.path.join(target_dir, f'{entity_name}Configuration.cs')
        
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(file_content)

    main_caller_content = create_main_caller_file(processed_methods, args.namespace, args.classname)
    main_caller_path = os.path.join(output_dir, f'_{args.classname}.cs')
    with open(main_caller_path, 'w', encoding='utf-8') as f:
        f.write(main_caller_content)
        
    print("Tách file Fluent API hoàn tất.")

def create_individual_config_file(entity_name, config_body, namespace, partial_class_name):
    return f"""using Microsoft.EntityFrameworkCore;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace {namespace}
{{
    public static partial class {partial_class_name}
    {{
        public static void Configure{entity_name}(this ModelBuilder modelBuilder)
        {{
{config_body}
        }}
    }}
}}
""".strip()

def create_main_caller_file(method_names, namespace, partial_class_name):
    method_names.sort()
    calls = "\n".join([f'            modelBuilder.{name}();' for name in method_names])
    return f"""using Microsoft.EntityFrameworkCore;

namespace {namespace}
{{
    public static partial class {partial_class_name}
    {{
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {{
{calls}
        }}
    }}
}}
""".strip()

def handle_split_fluent_new(args):
    """Hàm xử lý cho chức năng 'split-fluent' với logic mới."""
    print("--- Chức năng: Tách và tái cấu trúc file Fluent API ---")
    
    output_dir = args.output
    os.makedirs(output_dir, exist_ok=True)

    try:
        with open(args.input_file, 'r', encoding='utf-8') as f: csharp_code = f.read()
    except FileNotFoundError:
        print(f"LỖI: Không tìm thấy file '{args.input_file}'.")
        return
        
    entity_blocks = find_fluent_entity_configs(csharp_code)

    if not entity_blocks:
        print("Không tìm thấy cấu hình entity nào hợp lệ.")
        return
        
    print(f"Tìm thấy {len(entity_blocks)} khối entity. Bắt đầu phân tích và xử lý...")
    
    processed_methods = []

    for config in entity_blocks:
        entity_name = config['name']
        original_body = config['body']
        print(f"  - Đang phân tích: {entity_name}")
        
        full_block_content = f"            modelBuilder.Entity<{entity_name}>(entity =>\n            {{\n{original_body}\n            }});"
        status, new_content, target_subdir = analyze_and_transform_fluent_block(entity_name, full_block_content)
        
        if status == "SKIP":
            continue

        method_name = f'Configure{entity_name}'
        processed_methods.append(method_name)
        
        # Tạo nội dung file hoàn chỉnh
        file_content = create_individual_config_file(entity_name, new_content, args.namespace, args.classname)
        
        target_path = os.path.join(output_dir, target_subdir)
        os.makedirs(target_path, exist_ok=True)
        
        file_path = os.path.join(target_path, f'{entity_name}Configuration.cs')
        
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(file_content)

    main_caller_content = create_main_caller_file(processed_methods, args.namespace, args.classname)
    main_caller_path = os.path.join(output_dir, f'_{args.classname}.cs')
    with open(main_caller_path, 'w', encoding='utf-8') as f:
        f.write(main_caller_content)
        
    print(f"Đã tạo file tổng hợp: '{main_caller_path}'")
    print(f"Hoàn tất! {len(entity_blocks)} entities ✅")

def build_schema_map(entities_dir, fluent_content):
    """Thực hiện quy trình 2 giai đoạn để xây dựng bản đồ quan hệ hoàn chỉnh."""
    print("Giai đoạn 1: Bắt đầu xây dựng bản đồ quan hệ...")
    
    # --- 1.1: Quét Entities để xây dựng bản đồ thô ---
    schema_map = {}
    prop_pattern = re.compile(
        r'((?:\s*\[[^\]]+\]\s*\r?\n|\s*\r?\n)*)'
        r'(\s*public\s+virtual\s+(.*?)\s+(\w+)\s*.*?{.*?get;.*?set;.*?})',
        re.MULTILINE
    )
    files_to_scan = [f for f in os.listdir(entities_dir) if f.lower().endswith('.cs')]
    for filename in files_to_scan:
        class_name = os.path.splitext(filename)[0]
        schema_map[class_name] = {'properties': {}}
        filepath = os.path.join(entities_dir, filename)
        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                content = f.read()
                for match in prop_pattern.finditer(content):
                    attributes_str = match.group(1)
                    prop_type = match.group(3)
                    prop_name = match.group(4)
                    rel_info = {}
                    if prop_type.startswith("ICollection<"):
                        rel_info['relationship'] = 'Collection'
                    else:
                        rel_info['relationship'] = 'ManyToOne'
                    fk_match = re.search(r'\[ForeignKey\("([^"]+)"\)\]', attributes_str)
                    inv_prop_match = re.search(r'\[InverseProperty\("([^"]+)"\)\]', attributes_str)
                    if fk_match: rel_info['foreign_key'] = fk_match.group(1)
                    if inv_prop_match: rel_info['inverse_property'] = inv_prop_match.group(1)
                    clean_type = re.sub(r'ICollection<(\w+)>', r'\1', prop_type).replace('?', '')
                    rel_info['type'] = clean_type
                    schema_map[class_name]['properties'][prop_name] = rel_info
        except Exception as e:
            print(f"    Cảnh báo: Không thể quét file {filename}: {e}")
    
    # --- 1.2: Dùng Fluent API để hoàn thiện bản đồ ---
    entity_blocks = find_fluent_entity_configs(fluent_content)
    for config in entity_blocks:
        entity_name = config['name']
        body_content = config['body']
        if entity_name not in schema_map: continue

        lines = body_content.splitlines()
        i = 0
        while i < len(lines):
            line = lines[i]
            if line.strip().startswith("entity.HasOne") or line.strip().startswith("entity.HasMany"):
                end_index = find_statement_end_index(lines, i)
                statement_content = "\n".join(lines[i : end_index + 1])
                prop_match = re.search(r'Has(?:One|Many)\(d\s*=>\s*d\.(\w+)\)', statement_content)
                if not prop_match:
                    i = end_index + 1
                    continue
                
                prop_name = prop_match.group(1)
                with_one_match = re.search(r'\.WithOne\(\s*(?:p\s*=>\s*p\.(\w+))?\s*\)', statement_content)
                with_many_match = re.search(r'\.WithMany\(\s*(?:p\s*=>\s*p\.(\w+))?\s*\)', statement_content)
                
                if line.strip().startswith("entity.HasOne") and with_many_match:
                    o2m_prop_name = with_many_match.group(1)
                    other_class_name = schema_map.get(entity_name, {}).get('properties', {}).get(prop_name, {}).get('type')
                    if other_class_name and o2m_prop_name and other_class_name in schema_map and o2m_prop_name in schema_map[other_class_name]['properties']:
                        schema_map[other_class_name]['properties'][o2m_prop_name]['relationship'] = 'OneToMany'
                        fk_match = re.search(r'\.HasForeignKey\((?:d|e)\s*=>\s*(?:d|e)\.(\w+)\)', statement_content)
                        if fk_match:
                            schema_map[other_class_name]['properties'][o2m_prop_name]['foreign_key'] = fk_match.group(1)
                
                elif line.strip().startswith("entity.HasMany") and with_many_match:
                    if prop_name in schema_map.get(entity_name, {}).get('properties', {}):
                        schema_map[entity_name]['properties'][prop_name]['is_fluent_m2m'] = True
                        schema_map[entity_name]['properties'][prop_name]['relationship'] = 'ManyToMany'

                i = end_index + 1
            else:
                i += 1
                
    for entity_name, data in schema_map.items():
        for prop_name, rel_info in data['properties'].items():
            if rel_info.get('relationship') == 'Collection':
                rel_info['relationship'] = 'ManyToManyHidden'
                rel_info['is_fluent_m2m'] = False # Đây là M2M ẩn

    print("Xây dựng bản đồ quan hệ hoàn tất.")
    return schema_map


# ==============================================================================
# GIAI ĐOẠN 3: TÁI CẤU TRÚC ENTITIES
# ==============================================================================

def refactor_entity_file(content, schema_map):
    """Áp dụng các quy tắc chuyển đổi cho một file entity, sử dụng schema_map."""
    class_name_match = re.search(r'public\s+partial\s+class\s+(\w+)', content)
    if not class_name_match: return content
    class_name = class_name_match.group(1)
    
    one2many_found_in_file = [False]

    def transform_relationship(match):
        attributes_block_str = match.group(1)
        property_line_str = match.group(2)
        prop_name = match.group(4)
        
        full_original_block = (attributes_block_str + property_line_str)
        indent = ' ' * (len(property_line_str) - len(property_line_str.lstrip(' ')))
        rel_info = schema_map.get(class_name, {}).get('properties', {}).get(prop_name, {})
        rel_type = rel_info.get('relationship', 'unknown')
        
        result = []

        if rel_type == 'OneToMany':
            one2many_found_in_file[0] = True
            #result.append(f"\n\n{indent}// [One2many]")
            has_fk_attr = "ForeignKey" in attributes_block_str
            if class_name in COMMENT_OUT_O2M_RELATIONSHIPS:
                result.append(f"\n\n{indent}// [One2many] - RELATIONSHIP COMMENTED OUT FOR '{class_name}'")
                if not has_fk_attr and 'foreign_key' in rel_info:
                    result.append(f"{indent}// [ForeignKey(\"{rel_info['foreign_key']}\")]")                
                for line in full_original_block.splitlines():
                    if line.strip(): result.append(f"{indent}// {line.strip()}")
            else: # Xử lý bình thường
                result.append(f"\n\n{indent}// [One2many]")
                if not has_fk_attr and 'foreign_key' in rel_info:
                    result.append(f"{indent}[ForeignKey(\"{rel_info['foreign_key']}\")]")
                #result.append(full_original_block.strip())
                for line in full_original_block.splitlines():
                    if line.strip(): result.append(line)

            # if not has_fk_attr and 'foreign_key' in rel_info:
            #     result.append(f"{indent}[ForeignKey(\"{rel_info['foreign_key']}\")]")
            # for line in (attributes_block_str + property_line_str).splitlines():
            #     if line.strip(): result.append(line)
        
        elif rel_type == 'ManyToMany':
            is_fluent_m2m = rel_info.get('is_fluent_m2m', False)            
            if is_fluent_m2m: # M2M tường minh -> giữ lại
                result.append(f"\n\n{indent}// [Many2many] // Normal")
                for line in full_original_block.splitlines():
                    if line.strip():
                        line_indent = ' ' * (len(line) - len(line.lstrip(' ')))
                        if line.strip().startswith(("[ForeignKey", "[InverseProperty")):
                            result.append(f"{line_indent}// {line.strip()} //Many2many")
                        else:
                            result.append(line)
                        #result.append(f"{line_indent} {line.strip()}")
            else: # M2M ẩn -> comment out
                result.append(f"\n\n{indent}// [Many2many] // Hidden")
                for line in full_original_block.splitlines():
                    if line.strip():
                        line_indent = ' ' * (len(line) - len(line.lstrip(' ')))
                        result.append(f"{line_indent}// {line.strip()}")
        
        elif rel_type == 'ManyToManyHidden':
            result.append(f"\n\n{indent}// [Many2many] // ManyToMany Hidden")
            for line in (attributes_block_str + property_line_str).splitlines():
                if line.strip():
                    line_indent = ' ' * (len(line) - len(line.lstrip(' ')))
                    result.append(f"{line_indent}// {line.strip()}")

        elif rel_type == 'ManyToOne':
            result.append(f"\n\n{indent}// [Many2one]")
            for line in (attributes_block_str + property_line_str).splitlines():
                if line.strip():
                    if line.strip().startswith(("[InverseProperty")):
                        result.append(f"{indent}// {line.strip()} //Many2many")
                    else:
                        result.append(line)
        else:
            return (attributes_block_str + property_line_str)

        return "\n".join(result)

    relationship_pattern = re.compile(
        r'((?:\s*\[[^\]]+\]\s*\r?\n|\s*\r?\n)*)' 
        r'(\s*public\s+virtual\s+(.*?)\s+(\w+)\s*.*?{.*?get;.*?set;.*?})',
        re.MULTILINE
    )
    content = relationship_pattern.sub(transform_relationship, content)

    #content = re.sub(r'(^\s*)(\[InverseProperty\([^)]+\)\])', r'\1// \2', content, flags=re.MULTILINE)

    # === Tiếp tục các xử lý đơn giản khác sau khi quan hệ đã được xử lý ===
    
    # Xác định lại kế thừa dựa trên kết quả xử lý quan hệ
    if one2many_found_in_file[0]:
        content = re.sub(r'(public\s+partial\s+class\s+\w+)(:.*)?', r'\1: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject', content, count=1)
    else:
        content = re.sub(r'(public\s+partial\s+class\s+\w+)(:.*)?', r'\1: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject', content, count=1)

    # Thay thế usings
    abp_usings = """using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;"""
    content = re.sub(r'^\s*using Microsoft\.EntityFrameworkCore;.*$', abp_usings, content, flags=re.MULTILINE)
    
    # Comment out các Index còn lại
    content = re.sub(r'(^\s*\[Index.*\]\s*$)', r'//\1', content, flags=re.MULTILINE)
    
    # Thay thế Id và thêm TenantId
    id_replacement = r"""public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }"""
    content = re.sub(r'public\s+Guid\s+Id\s*{\s*get;\s*set;\s*}', id_replacement, content)
    
    # Thay thế các trường Auditing và các trường khác
    content = content.replace("public Guid? CreateUid { get; set; }", "public Guid? CreatorId { get; set; }")
    content = content.replace("public Guid? WriteUid { get; set; }", "public Guid? LastModifierId { get; set; }")
    content = content.replace("public DateTime? CreateDate { get; set; }", "public DateTime CreationTime { get; set; }")
    content = content.replace("public DateTime? WriteDate { get; set; }", "public DateTime? LastModificationTime { get; set; }")
    content = content.replace("public DateOnly? ", "public DateTime? ")
    content = content.replace("public DateOnly ", "public DateTime ")
    
    # Xóa thuộc tính CompanyId gốc
    company_id_pattern = re.compile(r'^\s*\[Column\("company_id"\)\].*(\r?\n)\s*public\s+Guid\?\s+CompanyId\s*{\s*get;\s*set;\s*}.*(\r?\n)?', re.MULTILINE)
    content = company_id_pattern.sub('', content)

    # Xóa phần khởi tạo ICollection
    content = re.sub(r'(public\s+virtual\s+ICollection<[^>]*>\s*.*?{\s*get;\s*set;\s*})(\s*=\s*new.*;)', r'\1', content)

    return content



def refactor_all_entities(entities_dir, schema_map, args):
    """Hàm điều khiển việc tái cấu trúc tất cả các file entity."""
    print(f"\nGiai đoạn 3: Bắt đầu tái cấu trúc các file trong '{entities_dir}'...")
    output_dir = args.output_entities
    os.makedirs(output_dir, exist_ok=True)
    
    files_to_process = [f for f in os.listdir(entities_dir) if f.lower().endswith('.cs')]
    for filename in files_to_process:
        input_path = os.path.join(entities_dir, filename)
        output_path = os.path.join(output_dir, filename)
        print(f"  - Đang xử lý: {filename}")
        with open(input_path, 'r', encoding='utf-8') as f:
            original_content = f.read()
            
        modified_content = refactor_entity_file(original_content, schema_map)
        
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(modified_content)
    print("Tái cấu trúc entities hoàn tất.")


# ==============================================================================
# HÀM ĐIỀU KHIỂN CHÍNH VÀ CLI
# ==============================================================================

def handle_combined_tool(args):
    """Hàm điều khiển cho công cụ kết hợp mới."""
    print("--- Bắt đầu quy trình tái cấu trúc kết hợp ---")
    
    # GIAI ĐOẠN 1
    with open(args.fluent_file, 'r', encoding='utf-8') as f:
        fluent_content = f.read()
    schema_map = build_schema_map_from_fluent(fluent_content)
    
    # GIAI ĐOẠN 2 (Tách fluent trước)
    # Tạm thời gọi lại hàm cũ để tách file, sau này có thể tích hợp refactor vào đây
    temp_args = argparse.Namespace(
        input_file=args.fluent_file, 
        output=args.output_fluent, 
        namespace=args.namespace, 
        classname=args.classname
    )
    handle_split_fluent_new(temp_args) # Giả định hàm này đã tồn tại và đúng

    # GIAI ĐOẠN 3
    refactor_all_entities(args.entities_directory, schema_map, args)

    print("\nQuy trình hoàn tất! ✅")

# ==============================================================================
# THIẾT LẬP GIAO DIỆN DÒNG LỆNH (CLI)
# ==============================================================================

def main():
    parser = argparse.ArgumentParser(
        prog="DotnetRefactorTool",
        description="Công cụ tái cấu trúc code C# cho Entities và Fluent API.",
    )
    parser.add_argument("fluent", help="Đường dẫn đến file C# chứa DbContext với Fluent API.")
    parser.add_argument("entities", help="Thư mục chứa các file entity C# gốc.")
    parser.add_argument("-of", "--output_fluent", default="Configurations", help="Thư mục output cho các file Fluent API đã tách.")
    parser.add_argument("-oe", "--output_entities", default="AbpEntities", help="Thư mục output cho các file entity đã chuyển đổi.")
    parser.add_argument("-n", "--namespace", default="Bamboo.Core.EntityFrameworkCore", help="Namespace cho các file fluent được tạo ra.")
    parser.add_argument("-c", "--classname", default="ModelBuilderExtensions", help="Tên lớp partial cho các file fluent.")

    args = parser.parse_args()
    
    print("--- Bắt đầu quy trình tái cấu trúc kết hợp ---")
    
    # GIAI ĐOẠN 1
    #type_map = build_type_map_from_entities(args.entities)

    # GIAI ĐOẠN 2
    with open(args.fluent, 'r', encoding='utf-8') as f:
        fluent_content = f.read()
    schema_map = build_schema_map(args.entities, fluent_content)
        
    # GIAI ĐOẠN 2
    split_and_refactor_fluent(fluent_content, schema_map, args)

    # GIAI ĐOẠN 3
    refactor_all_entities(args.entities, schema_map, args)

    print("\nQuy trình hoàn tất! ✅")

if __name__ == '__main__':
    main()
