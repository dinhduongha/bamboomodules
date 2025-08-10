import os
import re
import argparse
import textwrap

# ==============================================================================
# CHỨC NĂNG 1: TÁCH FILE FLUENT API (LOGIC TỪ CÁC PHIÊN BẢN TRƯỚC)
# ==============================================================================

def find_fluent_entity_configs(code):
    """Tìm các khối cấu hình entity bằng cách đếm dấu ngoặc."""
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
        full_block = code[match.start():end_pos]
        body_match = re.search(r'entity\s*=>\s*{', full_block, re.DOTALL)
        if not body_match: continue
        inner_body_start = body_match.end()
        brace_level, inner_body_end = 1, -1
        current_pos = inner_body_start
        while current_pos < len(full_block):
            char = full_block[current_pos]
            if char == '{': brace_level += 1
            elif char == '}': brace_level -= 1
            if brace_level == 0:
                inner_body_end = current_pos
                break
            current_pos += 1
        if inner_body_end != -1:
            inner_body = full_block[inner_body_start:inner_body_end]
            lines = [line.expandtabs(4) for line in inner_body.split('\n')]
            while lines and not lines[0].strip(): lines.pop(0)
            while lines and not lines[-1].strip(): lines.pop()
            if not lines: continue
            min_indent = -1
            for line in lines:
                if line.strip():
                    indent = len(line) - len(line.lstrip(' '))
                    if min_indent == -1 or indent < min_indent: min_indent = indent
            final_lines = [line[min_indent:] if line.strip() else "" for line in lines] if min_indent > 0 else lines
            configs.append({'name': entity_name, 'body': '\n'.join(final_lines)})
    return configs

def create_individual_config_file(entity_name, config_body, namespace, partial_class_name):
    final_indented_body = textwrap.indent(config_body, ' ' * 16)
    return f"""
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;

namespace {namespace}
{{
    public static partial class {partial_class_name}
    {{
        public static void Configure{entity_name}(this ModelBuilder modelBuilder)
        {{
            modelBuilder.Entity<{entity_name}>(entity =>
            {{
{final_indented_body}
            }});
        }}
    }}
}}
""".strip()

def create_main_caller_file(method_names, namespace, partial_class_name):
    method_names.sort()
    calls = "\n".join([f'            modelBuilder.{name}();' for name in method_names])
    return f"""
using Microsoft.EntityFrameworkCore;

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

    # Kiểm tra xem có phải là bảng nối M2M không
    join_table_pk_pattern = r'\[PrimaryKey\(".*",\s*".*"\)\]'
    is_many_to_many_join_table = bool(re.search(join_table_pk_pattern, content))

    # Nếu là bảng nối, chỉ xử lý đơn giản rồi trả về
    if is_many_to_many_join_table:
        # Comment out các thuộc tính [Index]
        content = re.sub(r'^(\s*\[Index.*\]\s*)$', r'//\1', content, flags=re.MULTILINE)
        # Comment out thuộc tính [PrimaryKey]
        content = re.sub(f'^(\\s*{join_table_pk_pattern}\\s*)$', r'//\1', content, flags=re.MULTILINE)
        return content

    # a) Thay thế using
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

    # Comment out [Index]
    content = re.sub(r'^(\s*\[Index.*\]\s*)$', r'//\1', content, flags=re.MULTILINE)

    # c) Thay thế Id và thêm TenantId
    id_replacement = r"""public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }"""
    content = re.sub(r'public\s+Guid\s+Id\s*{\s*get;\s*set;\s*}', id_replacement, content)

    # d, e, f, g) Thay thế các trường Auditing
    content = content.replace("public Guid? CreateUid { get; set; }", "public Guid? CreatorId { get; set; }")
    content = content.replace("public Guid? WriteUid { get; set; }", "public Guid? LastModifierId { get; set; }")
    content = content.replace("public DateTime? CreateDate { get; set; }", "public DateTime CreationTime { get; set; }")
    content = content.replace("public DateTime? WriteDate { get; set; }", "public DateTime? LastModificationTime { get; set; }")

    # h, i, j) Thay thế các ForeignKey
    content = content.replace('[ForeignKey("CreateUid")]', '[ForeignKey("CreatorId")]')
    content = content.replace('[ForeignKey("WriteUid")]', '[ForeignKey("LastModifierId")]')
    content = content.replace('[ForeignKey("CompanyId")]', '[ForeignKey("TenantId")]')

    # k) Cắt phần khởi tạo của ICollection
    content = re.sub(r'(public\s+virtual\s+ICollection<[^>]*>\s*.*?{\s*get;\s*set;\s*})(\s*=\s*new.*;)', r'\1', content)
    
    company_id_pattern = re.compile(
        r'^\s*\[Column\("company_id"\)\].*(\r?\n)\s*public\s+Guid\?\s+CompanyId\s*{\s*get;\s*set;\s*}.*(\r?\n)?',
        re.MULTILINE
    )
    content = company_id_pattern.sub('', content)

    # l & m) Xử lý JsonField và các mối quan hệ
    lines = content.split('\n')
    new_lines = []
    i = 0
    while i < len(lines):
        line = lines[i].expandtabs(4)
        
        # YÊU CẦU MỚI 2: Sửa vị trí [JsonField]
        if 'TypeName = "jsonb"' in line:
            j = i + 1
            while j < len(lines) and not lines[j].strip().startswith("public"): j += 1
            if j < len(lines):
                public_line_indent = ' ' * (len(lines[j]) - len(lines[j].lstrip(' ')))
                # Thêm [JsonField] VÀO TRƯỚC
                new_lines.append(f"{public_line_indent}[JsonField]")
                # Thêm các dòng gốc (bao gồm [Column])
                for k in range(i, j + 1):
                    new_lines.append(lines[k])
                i = j + 1
                continue

        if line.strip().startswith("[InverseProperty"):
            prev_line = lines[i-1].strip() if i > 0 else ""
            next_line = lines[i+1].strip() if i < len(lines) - 1 else ""
            is_m2m = (prev_line == "" and next_line.startswith("public virtual ICollection"))
            is_o2m = (prev_line.startswith("[ForeignKey") and next_line.startswith("public virtual ICollection"))
            is_m2o = (prev_line.startswith("[ForeignKey") and not next_line.startswith("public virtual ICollection"))
            indent = ' ' * (len(line) - len(line.lstrip(' ')))

            if is_m2m:
                if new_lines and not new_lines[-1].strip(): new_lines.pop()
                new_lines.append("") # Thêm dòng trống để tách biệt
                new_lines.append(f"{indent}// [Many2many]")
                new_lines.append(f"{indent}// [NotMapped] // Many2many")
                new_lines.append(f"{indent}// {lines[i].strip()}")
                new_lines.append(f"{indent}// {lines[i+1].strip()}")
                i += 2
                continue
            
            elif is_o2m:
                one2many_found = True
                if new_lines and new_lines[-1].strip() == prev_line: new_lines.pop()
                new_lines.append(f"{indent}// [One2many]")
                new_lines.append(lines[i-1])
                new_lines.append(f"{indent}[NotMapped] // One2many")
                new_lines.append(f"{indent}// {lines[i].strip()}")
                new_lines.append(lines[i+1])
                i += 2
                continue

            elif is_m2o:
                if new_lines and new_lines[-1].strip() == prev_line: new_lines.pop()
                new_lines.append(f"{indent}// [Many2one]")
                new_lines.append(lines[i-1])
                new_lines.append(f"{indent}// {lines[i].strip()}")
                new_lines.append(lines[i+1])
                i += 2
                continue
        
        new_lines.append(lines[i])
        i += 1

    content = "\n".join(new_lines)
    
    if one2many_found:
        replacement_inheritance = r': FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject'
    else:
        replacement_inheritance = r': FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject'
    
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
    parser_split.set_defaults(func=handle_split_fluent)

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