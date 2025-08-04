import os
import re
import argparse
import textwrap # Thư viện để xử lý thụt lề văn bản

# --- HÀM TRỢ GIÚP (Đã được tinh chỉnh) ---

def find_entity_configs(code):
    """
    Tìm các khối cấu hình, trích xuất và chuẩn hóa thụt lề tương đối bên trong.
    """
    configs = []
    start_pattern = re.compile(r'modelBuilder\.Entity<([a-zA-Z_0-9]+)>\s*\(')

    for match in start_pattern.finditer(code):
        entity_name = match.group(1)
        content_start_index = match.end()

        paren_level = 1
        current_pos = content_start_index
        end_pos = -1

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
        brace_level = 1
        inner_body_end = -1
        
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
            
            lines = inner_body.split('\n')
            
            while lines and not lines[0].strip(): lines.pop(0)
            while lines and not lines[-1].strip(): lines.pop()
            if not lines: continue

            lines = [line.expandtabs(4) for line in lines]

            min_indent = -1
            for line in lines:
                if line.strip():
                    indent = len(line) - len(line.lstrip(' '))
                    if min_indent == -1 or indent < min_indent:
                        min_indent = indent
            
            # Chuẩn hóa khối code: Xóa thụt lề chung bên ngoài
            final_lines = []
            if min_indent > 0:
                for line in lines:
                    final_lines.append(line[min_indent:] if line.strip() else "")
            else:
                final_lines = lines
            
            final_body = '\n'.join(final_lines)
            
            configs.append({
                'name': entity_name,
                'body': final_body
            })

    return configs

def create_individual_config_file(entity_name, config_body, namespace, partial_class_name):
    """Tạo file cấu hình, áp dụng thụt lề cuối cùng cho khối code."""
    method_name = f'Configure{entity_name}'
    
    # Áp dụng thụt lề cuối cùng (16 dấu cách) cho toàn bộ khối code
    # namespace(4) -> class(4) -> method(4) -> entity lambda(4) = 16
    final_indented_body = textwrap.indent(config_body, ' ' * 16)

    file_content = f"""
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace {namespace}
{{
    public static partial class {partial_class_name}
    {{
        public static void {method_name}(this ModelBuilder modelBuilder)
        {{
            modelBuilder.Entity<{entity_name}>(entity =>
            {{
{final_indented_body}
            }});
        }}
    }}
}}
"""
    return file_content.strip()

def create_main_caller_file(method_names, namespace, partial_class_name):
    """Tạo file tổng hợp gọi tất cả các hàm cấu hình."""
    method_names.sort()
    
    calls = "\n".join([f'            modelBuilder.{name}();' for name in method_names])
    
    file_content = f"""
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
"""
    return file_content.strip()

# --- CHƯƠNG TRÌNH CHÍNH (Không thay đổi) ---
def main():
    parser = argparse.ArgumentParser(
        description="Tách file cấu hình Fluent API C# lớn thành các file nhỏ hơn.",
        formatter_class=argparse.RawTextHelpFormatter
    )
    parser.add_argument("input_file", help="Đường dẫn đến file C# Fluent API gốc cần xử lý.")
    parser.add_argument("-o", "--output", default="Configurations", help="Thư mục để lưu các file đã tách.\n(Mặc định: Configurations)")
    parser.add_argument("-n", "--namespace", default="Bamboo.Core.EntityFrameworkCore", help="Namespace cho các file được tạo ra.\n(Mặc định: YourProject.Data.Configurations)")
    parser.add_argument("-c", "--classname", default="ModelBuilderExtensions", help="Tên của lớp partial tĩnh chứa các phương thức.\n(Mặc định: ModelBuilderExtensions)")
    
    args = parser.parse_args()

    print(f"Bắt đầu quá trình với các tùy chọn:")
    print(f"  - File input: {args.input_file}")
    print(f"  - Thư mục output: {args.output}")
    print(f"  - Namespace: {args.namespace}")
    print(f"  - Tên lớp: {args.classname}")
    print("-" * 20)

    if not os.path.exists(args.output):
        os.makedirs(args.output)
        print(f"Đã tạo thư mục: '{args.output}'")

    try:
        with open(args.input_file, 'r', encoding='utf-8') as f:
            csharp_code = f.read()
    except FileNotFoundError:
        print(f"LỖI: Không tìm thấy file '{args.input_file}'. Vui lòng kiểm tra lại đường dẫn.")
        return

    entity_configs = find_entity_configs(csharp_code)
    
    if not entity_configs:
        print("Không tìm thấy cấu hình entity nào. Vui lòng kiểm tra lại logic và nội dung file.")
        return
        
    print(f"Tìm thấy {len(entity_configs)} cấu hình entity.")

    method_names = []

    for config in entity_configs:
        entity_name = config['name']
        method_names.append(f'Configure{entity_name}')
        
        print(f"  - Đang xử lý: {entity_name}")
        
        file_content = create_individual_config_file(entity_name, config['body'], args.namespace, args.classname)
        file_path = os.path.join(args.output, f'{entity_name}Configuration.cs')
        
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(file_content)

    main_caller_content = create_main_caller_file(method_names, args.namespace, args.classname)
    main_caller_path = os.path.join(args.output, f'_{args.classname}.cs')
    
    with open(main_caller_path, 'w', encoding='utf-8') as f:
        f.write(main_caller_content)
        
    print(f"Đã tạo file tổng hợp: '{main_caller_path}'")
    print("\nHoàn tất! ✅")

if __name__ == '__main__':
    main()