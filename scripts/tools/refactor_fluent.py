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
    "AccountAccount", # 51
    #"AccountAccountTemplate", # 29
    #"AccountJournal", # (???) 28 
    #"AccountMove", # (???) 21 
    #"AccountAnalyticAccount", # 11
    #"AccountFiscalPosition", #9
    #"AccountMoveLine", # (???) 7 
    #"AccountPayment", # 7
    #"AccountTax", # 8
    #"CrmLead", # 6
    #"CrmTeam", # 19
    #"EventEvent", # 16
    #"EventType", # 7
    #"GamificationBadge", # 6    
    #"HrDepartment", # 14
    #"HrEmployee", # 37
    "IrAttachment", # 81
    #"IrMailServer", # 6    
    "IrModel", # 34
    "IrModelFields", # 15
    "IrModuleModule", # 11
    #"IrUiView", # 19
    #"LoyaltyProgram", # 6
    #"MailActivityType", # 10
    #"MailAlias", # 6    
    #"MailingMailing", # 10
    #"MailMessage", # 17
    #"MailTemplate", # 28
    #"MrpBom", # 6
    #"MrpProduction", # 13
    #"ProcurementGroup", # 8
    #"ProductCategory", # 9
    #"ProductPricelist", # 8
    "ProductProduct", # 70
    #"ProductTemplate", # 12
    #"ProjectProject", # 13
    #"ProjectTask", # 8
    "ResCountry", # 25
    #"ResCountryState", # 6
    "ResCurrency", # 44
    #"ResourceCalendar", # 10    
    "ResPartner", # 120
    "ResUsers", # 1457
    #"SaleOrder", # 22
    #"SaleOrderLine", # 16
    #"SlideSlide", # 7
    #"SmsTemplate", # 8
    #"StockLocation", # 44
    #"StockLot", # 7
    #"StockMove", # 11
    #"StockPicking", # 11
    #"StockPickingType", # 22
    #"StockRoute", # 10
    #"StockRule", # 9
    #"StockWarehouse", # 14
    #"SurveyQuestion", # 7
    #"SurveySurvey", # 8
    "UomUom", # 28
    #"UtmCampaign", # 11
    #"UtmMedium", # 8
    #"UtmSource", # 9
    "Website", # 33
    "ResCompany" # 166

]

# CÁC BẢNG CẦN COMMENT OUT QUAN HỆ ONE-TO-MANY
# Thêm tên các lớp (class) vào đây.
COMMENT_OUT_O2M_RELATIONSHIPS = [
    "AccountAccount", # 14
    #"AccountAccountTag", # 6
    #"AccountJournal", # 20
    #"AccountMove", # 11
    #"AccountTax", # 15
    #"CrmLead", # 8
    #"HrEmployee", # 8   
    "IrAttachment", # 13
    #"MrpProduction", # 7
    #"PosConfig", # 16
    #"ProductProduct", # 8
    #"ProductTemplate", # 15
    #"ProductTemplateAttributeValue", # 10
    "ResCountry", # 7
    #"ResCurrency", # 
    #"ResGroups", # 17
    "ResPartner", # 25
    #"ResPartnerCategory", # 5
    "ResUsers", # 23
    #"StockMove", # 7
    #"StockPicking", # 9
    #"StockQuant", # 7
    #"StockRoute", # 7
    "ResCompany"
]

PROPERTIES_TO_CLEAN_WITHMANY = [
    "Company", "CreateU", "WriteU", "User", "Currency",
    "Country", "Partner", "PartnerCategory", "MessageMainAttachment",
    "Account", "Journal", "Product", "ProductUom", "ProductCateg"
]

# ==============================================================================
# CHỨC NĂNG 1: TÁCH FILE FLUENT API (LOGIC TỪ CÁC PHIÊN BẢN TRƯỚC)
# ==============================================================================
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

def find_statement_end_index(lines, start_index):
    """Tìm dòng kết thúc của một câu lệnh C# bắt đầu từ start_index bằng cách đếm ngoặc."""
    paren_count = 0
    in_string = False
    for i in range(start_index, len(lines)):
        line = lines[i]
        for char in line:
            if char == '"': in_string = not in_string
            if not in_string:
                if char == '(': paren_count += 1
                elif char == ')': paren_count -= 1
        # Câu lệnh kết thúc khi dấu ; nằm ngoài tất cả các cặp ngoặc
        if paren_count == 0 and line.strip().endswith(';'):
            return i
    return start_index # Fallback

def transform_using_entity_block(match):
    """Hàm trợ giúp được gọi bởi re.sub để thực hiện việc biến đổi phức tạp cho UsingEntity."""
    indent = match.group(1)
    has_many_part = match.group(2)
    using_entity_block = match.group(3)
    target_entity = match.group(4)
    
    commented_line = f"{indent}// {has_many_part.strip()}"
    new_line = f"{indent}entity.HasMany<{target_entity}>().WithMany()"
    
    return f"{commented_line}\n{new_line}{using_entity_block}"

def analyze_and_transform_fluent_block(entity_name, body_content):
    """Phân tích và biến đổi nội dung BÊN TRONG của một khối cấu hình."""
    key_match = re.search(r'HasKey\(e\s*=>\s*new\s*{\s*([^}]*)}\)', body_content)
    if key_match:
        key_content = key_match.group(1)
        key_count = key_content.count('e.')
        property_count = body_content.count('entity.Property(e => e.')
        if key_count == 2 and property_count == 2:
            print(f"    -> Phát hiện bảng nối M2M, sẽ bỏ qua.")
            return ("SKIP", None, None)

    if entity_name in VIEW_ENTITIES:
        print(f"    -> Phát hiện View.")
        view_db_name = re.sub(r'(?<!^)(?=[A-Z])', '_', entity_name).lower()
        transformed_content = f'entity.ToView("{view_db_name}", "public");\n\n{body_content}'
        return ("VIEW", transformed_content, "Views")

    print(f"    -> Xử lý như bảng thường.")
    current_content = body_content
    has_composite_key = 'HasKey(e => new { e.' in current_content
    is_system_entity = entity_name.startswith(('Ir', 'Res', 'Bas')) or entity_name in MANUAL_SYSTEM_ENTITIES
    has_company_id = 'company_id' in current_content or 'CompanyId' in current_content
    should_add_multitenancy = (not is_system_entity or (is_system_entity and has_company_id)) and not has_composite_key

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

    # for prop_name in PROPERTIES_TO_CLEAN_WITHMANY:
    #     pattern = re.compile(
    #         # Bắt đầu từ đầu dòng, chụp lại phần thụt lề (group 1)
    #         r'^(\s*)'
    #         # Chụp lại phần HasOne(...) (group 2)
    #         r'(entity\.HasOne\(\s*d\s*=>\s*d\.' + prop_name + r'\s*\))'
    #         # Chụp lại phần WithMany(...) có tham số (group 3)
    #         r'(\s*\.WithMany\([^)]+\))',
    #         re.MULTILINE
    #     )
        
    #     def replace_with_comment_and_new_line(match):
    #         indent = match.group(1)
    #         has_one_part = match.group(2)
    #         with_many_part = match.group(3)
            
    #         original_full_line = f"{has_one_part}{with_many_part}".strip()
    #         commented_line = f"{indent}// {original_full_line}"
    #         new_line = f"{indent}{has_one_part}.WithMany()"
            
    #         return f"{commented_line}\n{new_line}"

    #     current_content = pattern.sub(replace_with_comment_and_new_line, current_content)

    # lines = current_content.splitlines()
    # new_lines = []
    # for line in lines:
    #     transformed = False
    #     for prop_name in PROPERTIES_TO_CLEAN_WITHMANY:
    #         pattern = re.compile(
    #             r'^(\s*)' # Group 1: Thụt lề
    #             r'(entity\.HasOne\(\s*d\s*=>\s*d\.' + prop_name + r'\s*\))' # Group 2: Phần HasOne
    #             r'(\s*\.WithMany\([^)]+\))' # Group 3: Phần WithMany
    #         )
    #         match = pattern.match(line.strip())
    #         if match:
    #             indent = ' ' * (len(line) - len(line.lstrip(' ')))
    #             has_one_part = match.group(2)
    #             with_many_part = match.group(3)
                
    #             original_full_line = f"{has_one_part}{with_many_part}".strip()
    #             commented_line = f"{indent}// {original_full_line}"
    #             new_line = f"{indent}{has_one_part}.WithMany()"
                
    #             new_lines.append(commented_line)
    #             new_lines.append(new_line)
    #             transformed = True
    #             break # Đã xử lý dòng này, chuyển sang dòng tiếp theo
        
    #     if not transformed:
    #         new_lines.append(line)
    
    # current_content = "\n".join(new_lines)


    # ** SỬA LỖI: Chuyển sang xử lý UsingEntity theo từng câu lệnh hoàn chỉnh **
    # lines = current_content.splitlines()
    # new_lines = []
    # i = 0
    # while i < len(lines):
    #     line = lines[i]
    #     # Tìm điểm bắt đầu của một câu lệnh HasMany có khả năng là UsingEntity
    #     if line.strip().startswith("entity.HasMany"):
    #         end_index = find_statement_end_index(lines, i)
    #         statement_lines = lines[i : end_index + 1]
    #         statement_content = "\n".join(statement_lines)

    #         # Chỉ xử lý nếu đây thực sự là khối UsingEntity M2M
    #         if ".UsingEntity<Dictionary<string, object>>" in statement_content:
    #             print(f"    -> Xử lý khối M2M UsingEntity đặc biệt.")
    #             first_line = statement_lines[0]
    #             commented_line = "//" + first_line
    #             target_entity = "Unknown"
    #             target_match = re.search(r'\.HasOne<([a-zA-Z_0-9]+)>', statement_content)
    #             if target_match: target_entity = target_match.group(1)
                
    #             indent = ' ' * (len(first_line) - len(first_line.lstrip(' ')))
    #             new_line = f"{indent}entity.HasMany<{target_entity}>().WithMany()"
                
    #             new_lines.append(commented_line)
    #             new_lines.append(new_line)
    #             new_lines.extend(statement_lines[1:])
    #             i = end_index + 1
    #             continue
        
    #     new_lines.append(line)
    #     i += 1
    
    # current_content = "\n".join(new_lines)
    # using_entity_pattern = re.compile(
    #     # Group 1: Thụt lề
    #     r'^(\s*)'
    #     # Group 2: Dòng HasMany(...).WithMany(...)
    #     r'(entity\.HasMany\([^\)]+\)\.WithMany\([^\)]+\))'
    #     # Group 3: Toàn bộ khối .UsingEntity theo sau
    #     r'(\s*\.UsingEntity<Dictionary<string, object>>\s*\('
    #     # Tìm HasOne đầu tiên bên trong để lấy tên entity
    #     r'[^,]+,\s*[^=]*=>\s*\w+\.HasOne<([a-zA-Z_0-9]+)>' # Group 4: Tên Entity
    #     # Bắt phần còn lại của khối cho đến khi kết thúc
    #     r'.*?\);)',
    #     re.DOTALL | re.MULTILINE
    # )
    # current_content = using_entity_pattern.sub(transform_using_entity_block, current_content)

    lines = current_content.splitlines()
    new_lines = []
    i = 0
    while i < len(lines):
        line = lines[i]
        
        is_processed = False

        # --- QUY TẮC 1: Xử lý HasMany(...).UsingEntity(...) (phức tạp, nhiều dòng) ---
        if line.strip().startswith("entity.HasMany"):
            end_index = find_statement_end_index(lines, i)
            statement_lines = lines[i : end_index + 1]
            statement_content = "\n".join(statement_lines)
            if ".UsingEntity<Dictionary<string, object>>" in statement_content:
                print(f"    -> Xử lý khối M2M UsingEntity đặc biệt.")
                first_line = statement_lines[0]
                
                # ** SỬA LỖI: Xử lý thụt lề cho dòng comment **
                indent = ' ' * (len(first_line) - len(first_line.lstrip(' ')))
                stripped_first_line = first_line.lstrip()
                commented_line = f"{indent}// {stripped_first_line}"
                
                target_entity = "Unknown"
                target_match = re.search(r'\.HasOne<([a-zA-Z_0-9]+)>', statement_content)
                if target_match: target_entity = target_match.group(1)
                
                new_line = f"{indent}entity.HasMany<{target_entity}>().WithMany()"
                
                new_lines.append(commented_line)
                new_lines.append(new_line)
                new_lines.extend(statement_lines[1:])
                i = end_index + 1
                is_processed = True
        
        if is_processed: continue

        # --- QUY TẮC 2: Xử lý HasOne() (đơn giản, một dòng) ---
        # Sử dụng logic chính xác bạn đã cung cấp
        transformed_has_one = False
        for prop_name in PROPERTIES_TO_CLEAN_WITHMANY:
            pattern = re.compile(
                r'^(\s*)' # Group 1: Thụt lề
                r'(entity\.HasOne\(\s*d\s*=>\s*d\.' + prop_name + r'\s*\))' # Group 2: Phần HasOne
                r'(\s*\.WithMany\([^)]+\))' # Group 3: Phần WithMany
            )
            # Chú ý: chạy match trên line đã strip() để pattern đơn giản hơn
            match = pattern.match(line.strip())
            if match:
                indent = ' ' * (len(line) - len(line.lstrip(' ')))
                has_one_part = match.group(2)
                with_many_part = match.group(3)
                
                original_full_line = f"{has_one_part}{with_many_part}".strip()
                commented_line = f"{indent}// {original_full_line}"
                new_line = f"{indent}{has_one_part}.WithMany()"
                
                new_lines.append(commented_line)
                new_lines.append(new_line)
                transformed_has_one = True
                break
        
        if transformed_has_one:
            i += 1
            continue

        # --- QUY TẮC 3: Xử lý CreationTime ---
        if line.strip().startswith("entity.Property(e => e.CreationTime)"):
            end_index = find_statement_end_index(lines, i)
            statement_lines = lines[i : end_index + 1]
            statement_content = "\n".join(statement_lines)
            
            if ".HasDefaultValueSql(" not in statement_content:
                print("    -> Thêm HasDefaultValueSql(\"now()\") cho CreationTime.")
                first_line = statement_lines[0]
                indent = ' ' * (len(first_line) - len(first_line.lstrip(' ')) + 4)
                new_default_sql_line = f'{indent}.HasDefaultValueSql("now()")'
                
                new_lines.append(first_line)
                new_lines.append(new_default_sql_line)
                new_lines.extend(statement_lines[1:])
            else:
                # Thuộc tính đã có, giữ nguyên
                new_lines.extend(statement_lines)
            
            i = end_index + 1
            is_processed = True

        if is_processed:
            continue
        # Nếu không có quy tắc nào khớp, giữ lại dòng gốc
        new_lines.append(line)
        i += 1
    
    current_content = "\n".join(new_lines)

    lines = current_content.splitlines()
    final_lines = []
    for line in lines:
        if line.strip().startswith('//'):
            final_lines.append(line)
            continue
        
        modified_line = line
        for class_to_clean in COMMENT_OUT_M2M_RELATIONSHIPS:
            pattern = re.compile(r'(\.WithMany\(\s*p\s*=>\s*p\.' + class_to_clean + r'\s*\))')
            modified_line = pattern.sub('.WithMany()', modified_line)
        
        final_lines.append(modified_line)
    
    current_content = "\n".join(final_lines)

    return ("PROCESS", current_content, "")

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

def handle_split_fluent(args):
    """Hàm xử lý cho chức năng 'split-fluent'."""
    print("--- Chức năng: Tách file Fluent API ---")
    if not os.path.exists(args.output):
        os.makedirs(args.output)
        print(f"Đã tạo thư mục output: '{args.output}'")
    try:
        with open(args.input_file, 'r', encoding='utf-8') as f: csharp_code = f.read()
    except FileNotFoundError:
        print(f"LỖI: Không tìm thấy file '{args.input_file}'.")
        return
    entity_configs = find_fluent_entity_configs(csharp_code)
    if not entity_configs:
        print("Không tìm thấy cấu hình entity nào.")
        return
    print(f"Tìm thấy {len(entity_configs)} cấu hình entity.")
    method_names = []
    for config in entity_configs:
        entity_name = config['name']
        print(f"  - Đang xử lý: {entity_name}")
        method_names.append(f'Configure{entity_name}')
        file_content = create_individual_config_file(entity_name, config['body'], args.namespace, args.classname)
        file_path = os.path.join(args.output, f'{entity_name}Configuration.cs')
        with open(file_path, 'w', encoding='utf-8') as f: f.write(file_content)
    main_caller_content = create_main_caller_file(method_names, args.namespace, args.classname)
    main_caller_path = os.path.join(args.output, f'_{args.classname}.cs')
    with open(main_caller_path, 'w', encoding='utf-8') as f: f.write(main_caller_content)
    print(f"Đã tạo file tổng hợp: '{main_caller_path}'")
    print("Hoàn tất! ✅")

# ==============================================================================
# CHỨC NĂNG 2: CONVERT ENTITIES SANG ABP FRAMEWORK
# ==============================================================================


def process_entity_file(content):
    """Áp dụng tất cả các quy tắc chuyển đổi cho một file entity."""
    one2many_found = False
    
    join_table_pk_pattern = r'\[PrimaryKey\(".*",\s*".*"\)\]'
    is_many_to_many_join_table = bool(re.search(join_table_pk_pattern, content))

    if is_many_to_many_join_table:
        content = re.sub(r'^(\s*\[Index.*\]\s*)$', r'//\1', content, flags=re.MULTILINE)
        content = re.sub(r'(^\[PrimaryKey\(".*",\s*".*"\)\]\s*$)', r'//\1', content, flags=re.MULTILINE)
        return content

    class_name_match = re.search(r'public\s+partial\s+class\s+(\w+)', content)
    if not class_name_match:
        return content 
    
    class_name = class_name_match.group(1)

    table_attr_pattern = r'\[Table\("(ir|res|bas)_[^"]*"\)\]'
    is_system_by_attribute = bool(re.search(table_attr_pattern, content))
    is_system_by_manual_list = class_name in MANUAL_SYSTEM_ENTITIES
    is_system_entity = is_system_by_attribute or is_system_by_manual_list
    has_company_id = '[Column("company_id")]' in content or 'public Guid? CompanyId' in content
    
    should_add_multitenancy = False
    if is_system_entity:
        if has_company_id:
            should_add_multitenancy = True
    else:
        should_add_multitenancy = True

    abp_usings = """using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;"""
    if should_add_multitenancy:
        abp_usings += "\nusing Volo.Abp.MultiTenancy;"
    content = re.sub(r'^\s*using Microsoft\.EntityFrameworkCore;.*$', abp_usings, content, flags=re.MULTILINE)

    content = re.sub(r'^(\s*\[Index.*\]\s*)$', r'//\1', content, flags=re.MULTILINE)
    
    if should_add_multitenancy:
        id_replacement = r"""public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    """
    else:
        id_replacement = r"public Guid Id { get => base.Id; set => base.Id = value; }"
    content = re.sub(r'public\s+Guid\s+Id\s*{\s*get;\s*set;\s*}', id_replacement, content)

    content = content.replace("public Guid? CreateUid { get; set; }", "public Guid? CreatorId { get; set; }")
    content = content.replace("public Guid? WriteUid { get; set; }", "public Guid? LastModifierId { get; set; }")
    content = content.replace("public DateTime? CreateDate { get; set; }", "public DateTime CreationTime { get; set; }")
    content = content.replace("public DateTime CreateDate { get; set; }", "public DateTime CreationTime { get; set; }")
    content = content.replace("public DateTime? WriteDate { get; set; }", "public DateTime? LastModificationTime { get; set; }")
    content = content.replace("public DateOnly? ", "public DateTime? ")
    content = content.replace("public DateOnly ", "public DateTime ")
    content = content.replace("public TimeOnly? ", "public TimeSpan? ")
    content = content.replace("public TimeOnly ", "public TimeSpan ")

    content = content.replace('[ForeignKey("CreateUid")]', '[ForeignKey("CreatorId")]')
    content = content.replace('[ForeignKey("WriteUid")]', '[ForeignKey("LastModifierId")]')
    if should_add_multitenancy:
        content = content.replace('[ForeignKey("CompanyId")]', '[ForeignKey("TenantId")]')
        company_id_pattern = re.compile(
            r'^\s*\[Column\("company_id"\)\].*(\r?\n)\s*public\s+Guid\?\s+CompanyId\s*{\s*get;\s*set;\s*}.*(\r?\n)?',
            re.MULTILINE
        )
        content = company_id_pattern.sub('', content)

    content = re.sub(r'(public\s+virtual\s+ICollection<[^>]*>\s*.*?{\s*get;\s*set;\s*})(\s*=\s*new.*;)', r'\1', content)

    lines = content.split('\n')
    new_lines = []
    i = 0
    while i < len(lines):
        line = lines[i].expandtabs(4)
        if 'TypeName = "jsonb"' in line:
            j = i + 1
            while j < len(lines) and not lines[j].strip().startswith("public"): j += 1
            if j < len(lines):
                public_line_indent = ' ' * (len(lines[j]) - len(lines[j].lstrip(' ')))
                new_lines.append(f"{public_line_indent}[JsonField]")
                for k in range(i, j + 1): new_lines.append(lines[k])
                i = j + 1
                continue
        if line.strip().startswith("[InverseProperty"):
            prev_line = lines[i-1].strip() if i > 0 else ""
            next_line = lines[i+1].strip() if i < len(lines) - 1 else ""
            indent = ' ' * (len(line) - len(line.lstrip(' ')))

            is_m2m = (prev_line == "" and next_line.startswith("public virtual ICollection"))
            is_o2m = (prev_line.startswith("[ForeignKey") and next_line.startswith("public virtual ICollection"))
            is_m2o = (prev_line.startswith("[ForeignKey") and not next_line.startswith("public virtual ICollection"))

            if is_m2m:
                if class_name in COMMENT_OUT_M2M_RELATIONSHIPS:
                    if new_lines and not new_lines[-1].strip(): new_lines.pop()
                    new_lines.append("")                    
                    new_lines.append(f"{indent}// [Many2many] // RELATIONSHIP COMMENTED OUT FOR '{class_name}'")
                    new_lines.append(f"{indent}// [NotMapped] // Many2many")
                    new_lines.append(f"{indent}// {lines[i].strip()} // Many2many")
                    new_lines.append(f"{indent}// {lines[i+1].strip()}")
                else: # Giữ lại quan hệ nhưng disable nó cho EF Core
                    new_lines.append("")
                    new_lines.append(f"{indent}// [Many2many]")
                    new_lines.append(f"{indent}[NotMapped] // Many2many")
                    new_lines.append(f"{indent}// {lines[i].strip()} // Many2many")
                    new_lines.append(lines[i+1])
                i += 2
                continue
            
            elif is_o2m:
                if class_name in COMMENT_OUT_O2M_RELATIONSHIPS:
                    if new_lines and new_lines[-1].strip() == lines[i-1].strip(): new_lines.pop()
                    new_lines.append(f"{indent}// [One2many] // RELATIONSHIP COMMENTED OUT FOR '{class_name}'")
                    new_lines.append(f"{indent}// [NotMapped] // One2many")
                    new_lines.append(f"{indent}// {lines[i-1].strip()}")
                    new_lines.append(f"{indent}// {lines[i].strip()}  //[One2many]")
                    new_lines.append(f"{indent}// {lines[i+1].strip()}")
                else: # Giữ lại quan hệ nhưng disable nó cho EF Core
                    one2many_found = True
                    if new_lines and new_lines[-1].strip() == prev_line: new_lines.pop()
                    new_lines.append(f"{indent}// [One2many]")
                    new_lines.append(lines[i-1])
                    new_lines.append(f"{indent}// [NotMapped] // One2many")
                    new_lines.append(f"{indent}// {lines[i].strip()}  //[One2many]")
                    new_lines.append(lines[i+1])
                i += 2
                continue

            elif is_m2o:
                if new_lines and new_lines[-1].strip() == prev_line: new_lines.pop()
                new_lines.append(f"{indent}// [Many2one]")
                new_lines.append(lines[i-1])
                new_lines.append(f"{indent}// {lines[i].strip()} // [Many2one]")
                new_lines.append(lines[i+1])
                i += 2
                continue
        
        new_lines.append(lines[i])
        i += 1
    content = "\n".join(new_lines)
    
    inheritance_parts = []
    if one2many_found:
        inheritance_parts.append("FullAuditedAggregateRoot<Guid>")
    else:
        inheritance_parts.append("FullAuditedEntity<Guid>")
    inheritance_parts.append("IEntityDto<Guid>")
    if should_add_multitenancy:
        inheritance_parts.append("IMultiTenant")
    inheritance_parts.append("IAuditedObject")
    replacement_inheritance = ': ' + ', '.join(inheritance_parts)
    
    content = re.sub(
        r'(public\s+partial\s+class\s+\w+)(\s*:.*)?',
        r'\1 ' + replacement_inheritance,
        content,
        count=1
    )

    return content

def handle_convert_entities(args):
    """Hàm xử lý cho chức năng 'convert-entities'."""
    print("--- Chức năng: Convert Entities sang ABP Framework ---")
    input_dir = args.input_directory
    output_dir = args.output_directory
    process_join_tables = args.include_join_tables

    if not os.path.isdir(input_dir):
        print(f"LỖI: Thư mục input '{input_dir}' không tồn tại.")
        return

    if not os.path.exists(output_dir):
        os.makedirs(output_dir)
        print(f"Đã tạo thư mục output: '{output_dir}'")

    many2many_dir = os.path.join(output_dir, "many2many")
    if process_join_tables:
        os.makedirs(many2many_dir, exist_ok=True)
        print(f"Đã chuẩn bị thư mục con cho bảng nối: '{many2many_dir}'")

    files_to_process = [f for f in os.listdir(input_dir) if f.endswith('.cs')]
    print(f"Tìm thấy {len(files_to_process)} file .cs để xử lý.")

    for filename in files_to_process:
        input_path = os.path.join(input_dir, filename)
        output_path = os.path.join(output_dir, filename)
        print(f"  - Đang xử lý: {filename}")
        try:
            with open(input_path, 'r', encoding='utf-8') as f:
                original_content = f.read()
            is_join_table = bool(re.search(r'\[PrimaryKey\(".*",\s*".*"\)\]', original_content))

            # Nếu là bảng nối VÀ logic mặc định là bỏ qua
            if is_join_table and not process_join_tables:
                print(f"  - Bỏ qua bảng nối (mặc định): {filename}")
                continue
            
            if is_join_table:
                output_path = os.path.join(many2many_dir, filename)
            else:
                output_path = os.path.join(output_dir, filename)

            modified_content = process_entity_file(original_content)

            with open(output_path, 'w', encoding='utf-8') as f:
                f.write(modified_content)
        except Exception as e:
            print(f"    LỖI khi xử lý file {filename}: {e}")

    print("Hoàn tất! ✅")

# ==============================================================================
# THIẾT LẬP GIAO DIỆN DÒNG LỆNH (CLI)
# ==============================================================================

def main():
    parser = argparse.ArgumentParser(
        prog="DotnetRefactorTool",
        description="Công cụ hỗ trợ tái cấu trúc (refactor) code C# cho Fluent API và ABP Framework.",
        epilog="Chọn một trong các chức năng (commands) ở trên và thêm --help để xem chi tiết."
    )

    subparsers = parser.add_subparsers(dest='command', required=True, help='Các chức năng có sẵn')

    # Parser cho chức năng 'fluent'
    parser_split = subparsers.add_parser('fluent', help='Tách một file Fluent API lớn thành nhiều file nhỏ.')
    parser_split.add_argument("input_file", help="Đường dẫn đến file C# Fluent API gốc.")
    parser_split.add_argument("-o", "--output", default="Configurations", help="Thư mục để lưu các file đã tách (mặc định: Configurations).")
    parser_split.add_argument("-n", "--namespace", default="Bamboo.Core.Data.Configurations", help="Namespace cho các file được tạo ra.")
    parser_split.add_argument("-c", "--classname", default="ModelBuilderExtensions", help="Tên của lớp partial tĩnh.")
    #parser_split.set_defaults(func=handle_split_fluent)
    parser_split.set_defaults(func=handle_split_fluent_new)

    # Parser cho chức năng 'entities'
    parser_convert = subparsers.add_parser('entities', help='Chuyển đổi các file C# Entity sang định dạng của ABP Framework.')
    parser_convert.add_argument("input_directory", help="Thư mục chứa các file entity gốc.")
    parser_convert.add_argument("-o", "--output_directory", default="AbpEntities", help="Thư mục để lưu các file entity đã chuyển đổi (mặc định: AbpEntities).")
    parser_convert.add_argument(
        "--include-join-tables",
        action="store_true", # Khi có flag này, giá trị sẽ là True
        help="Thêm cờ này để xử lý các bảng nối (mặc định: bỏ qua)."
    )
    parser_convert.set_defaults(func=handle_convert_entities)

    args = parser.parse_args()
    args.func(args)

if __name__ == '__main__':
    main()