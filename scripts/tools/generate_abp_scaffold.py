import os
import ast
import inspect
import argparse
import logging
from pathlib import Path
import re
import json

# --- Configuration and Helper Functions ---
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')
CSHARP_KEYWORDS = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "async", "await", "by", "descending", "dynamic", "equals", "from", "get", "global", "group", "into", "join", "let", "nameof", "on", "orderby", "partial", "remove", "select", "set", "value", "var", "when", "where", "yield" }
ODOO_COMMON_API_METHODS = {'create', 'write', 'read', 'unlink', 'search', 'search_read', 'name_get', 'name_search', 'copy', 'default_get', 'fields_get', 'onchange', 'name_create', 'read_group', 'check_access_rights', 'check_access_rule', 'check_field_access_rights'}
PYTHON_TO_CSHARP_TYPE_MAP = { 'str': 'string', 'int': 'int', 'float': 'float', 'bool': 'bool', 'dict': 'Dictionary<string, object>', 'list': 'List<object>', 'tuple': 'object', 'datetime': 'DateTime', 'date': 'DateTime', 'any': 'object', 'object': 'object' }
ODOO_TO_CSHARP_TYPE = { 'char': 'string', 'text': 'string', 'html': 'string', 'integer': 'int', 'float': 'double', 'monetary': 'decimal', 'boolean': 'bool', 'date': 'DateTime', 'datetime': 'DateTime', 'binary': 'byte[]' }
COMMON_ODOO_FIELDS = {
    'id': {'type': 'integer'},
    'create_date': {'type': 'datetime'},
    'create_uid': {'type': 'many2one', 'related_model': 'res.users'},
    'write_date': {'type': 'datetime'},
    'write_uid': {'type': 'many2one', 'related_model': 'res.users'}
}

def sanitize_csharp_identifier(name):
    sanitized = re.sub(r'[^a-zA-Z0-9_]', '_', str(name))
    if sanitized and sanitized[0].isdigit(): sanitized = 'Value_' + sanitized
    if not sanitized: return "Unnamed"
    return sanitized

def to_pascal_case(snake_str):
    if not isinstance(snake_str, (str, int, float)):
        logging.warning(f"to_pascal_case received non-string/numeric input: {snake_str}. Skipping.")
        return "InvalidValue"
    
    original_str = str(snake_str)
    starts_with_ = original_str.startswith('_')
    ends_with_ = original_str.endswith('_')
    
    clean_str = sanitize_csharp_identifier(original_str.replace('.', '_').strip('_'))
    if not clean_str: return "_" if starts_with_ or ends_with_ else ""
        
    components = clean_str.split('_')
    pascal_body = "".join(c[0].upper() + c[1:] for c in components if c)
    
    result = pascal_body
    if starts_with_: result = '_' + result
    if ends_with_: result = result + '_'
    
    return result

def format_csharp_code(code):
    formatted_code, indent_level = [], 0
    lines = code.strip().split('\n')
    for line in lines:
        line = line.strip()
        if '}' in line and '{' not in line and not line.startswith('//'): indent_level = max(0, indent_level - 1)
        formatted_code.append("    " * indent_level + line)
        if '{' in line and '}' not in line and not line.startswith('//'): indent_level += 1
    return "\n".join(formatted_code)

def cleanup_empty_dirs(path):
    for dirpath, _, _ in os.walk(path, topdown=False):
        if not os.listdir(dirpath):
            try:
                #logging.info(f"  Cleaning up empty directory: {dirpath}")
                os.rmdir(dirpath)
            except OSError as e:
                logging.error(f"Error removing directory {dirpath}: {e}")

def map_python_type_to_csharp(py_type_str, all_csharp_entity_names, param_name=""):
    if not py_type_str: return "object"
    if py_type_str == "TEntity": return "TEntity"
    if py_type_str == "IEnumerable<TEntity>": return "IEnumerable<TEntity>"
    if param_name.endswith("_ids"): return "List<Guid>"
    if param_name.endswith("_id"): return "Guid"
    py_type_str = py_type_str.strip("'\"")
    py_type_lower = py_type_str.lower()
    if py_type_lower in PYTHON_TO_CSHARP_TYPE_MAP:
        return PYTHON_TO_CSHARP_TYPE_MAP[py_type_lower]
    match = re.match(r"list\[(.+)\]", py_type_lower)
    if match:
        inner_type_str = match.group(1).strip("'\"")
        inner_csharp_type = map_python_type_to_csharp(inner_type_str, all_csharp_entity_names)
        return f"List<{inner_csharp_type}>"
    potential_entity_name = to_pascal_case(py_type_str)
    if potential_entity_name in all_csharp_entity_names:
        return potential_entity_name
    #logging.warning(f"Unrecognized type hint '{py_type_str}' for parameter '{param_name}'. Falling back to 'object'.")
    return "object"

# --- C# Content Generation Functions ---
def create_model_entity_content(project_name, module_name, model_name, model_data, dependencies, flat_model_dir, implemented_interfaces, property_order, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))
    is_auto = model_data.get('is_auto', True)
    
    if is_auto:
        base_class = f"FullAuditedEntity<Guid>"
        if any(f.get('type', '').lower() == 'one2many' for f in model_data.get('fields', {}).values()):
            base_class = f"FullAuditedAggregateRoot<Guid>"
    else:
        base_class = f"Entity<Guid>"

    final_interfaces = []
    has_company_id = 'company_id' in model_data.get('fields', {})
    if has_company_id:
        final_interfaces.append("IMultiTenant")
    final_interfaces.extend(sorted(implemented_interfaces))

    inverse_field_nav_map = {'create_uid': 'Creator', 'write_uid': 'LastModifier', 'company_id': 'Company'}
    
    using_statements = {
        "using System;", "using System.Collections.Generic;", "using System.ComponentModel.DataAnnotations;",
        "using System.ComponentModel.DataAnnotations.Schema;", "using Volo.Abp.Domain.Entities;",
        f"using {project_name}.Domain.Shared.Attributes;", f"using {project_name}.Domain.Shared.Interfaces;"
    }
    if "Audited" in base_class:
        using_statements.add("using Volo.Abp.Domain.Entities.Auditing;")
    if has_company_id:
        using_statements.add("using Volo.Abp.MultiTenancy;")
    if final_interfaces:
        using_statements.add(f"using {project_name}.MixinData;")
    
    for field_info in model_data.get('fields', {}).values():
        if 'related_model' in field_info and field_info['related_model'] in master_models:
            related_model_base_module = master_models[field_info['related_model']].get('base_module')
            if related_model_base_module:
                pascal_related_module = module_namespace_map.get(related_model_base_module, to_pascal_case(related_model_base_module))
                entity_namespace = f"{project_name}.Models" if flat_model_dir else f"{project_name}.Domain.Entities.{pascal_related_module}"
                using_statements.add(f"using {entity_namespace};")

    table_name = model_data.get('table_name') or model_name.replace('.', '_')
    depends_str = f"Depends = new[] {{ {', '.join(f'\"{dep}\"' for dep in dependencies)} }}" if dependencies else ""
    is_transient = model_data.get('is_transient', False)
    
    model_attribute_props = [f'IsTransient = {str(is_transient).lower()}']
    if not is_auto: model_attribute_props.append('IsAuto = false')
    if model_data.get('attributes', {}).get('Description'):
        model_attribute_props.append(f'Description = "{model_data["attributes"]["Description"]}"')

    attributes = [f'[Module("{module_name}"{(", " + depends_str) if depends_str else ""})]', f'[Model("{model_name}", {", ".join(model_attribute_props)})]', f'[Table("{table_name}")]']
    namespace = f"{project_name}.Models" if flat_model_dir else f"{project_name}.Domain.Entities.{pascal_module}"
    inheritance = f": {base_class}{', ' + ', '.join(final_interfaces) if final_interfaces else ''}"
    
    content = f"""
    {'\n'.join(list(using_statements))}
    namespace {namespace}
    {{
        {'\n        '.join(attributes)}
        public partial class {pascal_model} {inheritance}
        {{
    """
    
    properties_to_generate = {}

    def get_property_sort_group(field_info):
        field_type = field_info['type'].lower()
        if field_type in ODOO_TO_CSHARP_TYPE: return 10
        if field_type == 'many2one': return 20
        if field_type == 'one2many': return 30
        if field_type == 'many2many': return 40
        return 99

    def generate_property_string(field_name, field_info, pascal_field_name):
        prop_content = ""
        field_type = field_info['type'].lower()

        if field_name.endswith('country_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.country'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'res.country'.")

        if field_name.endswith('currency_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.currency'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'res.currency'.")

        if field_name.endswith('company_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.company'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'res.company'.")

        if field_name.endswith('user_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.users'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'res.users'.")

        if field_name.endswith('bank_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.bank'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'res.bank'.")

        if field_name.endswith('partner_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.partner'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'res.partner'.")

        if field_name.endswith('uom_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'uom.uom'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'uom.uom'.")

        if field_name.endswith('website_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'website'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' assuming related model is 'website'.")

        if field_type in ['many2one', 'one2many', 'many2many'] and 'related_model' not in field_info:
            nav_prop_name = to_pascal_case(field_name.removesuffix('_id'))
            if field_type == 'many2one':
                return f"""
                // TODO: Odoo C# Code Generator could not resolve the related model for '{field_name}' ({field_type}).
                // Please complete the following navigation property manually.
                [Column("{field_name}")]
                public Guid? {pascal_field_name} {{ get; set; }}
                /*
                [Many2one(RelatedModel = "your.model.name")]
                [ForeignKey(nameof({pascal_field_name}))]
                public virtual YourRelatedModel? {nav_prop_name} {{ get; set; }}
                */
                """
            else: # one2many, many2many
                attribute_name = "One2many" if field_type == 'one2many' else "Many2many"
                inverse_field_guess = to_pascal_case(model_name.replace('.', '_') if attribute_name == 'Many2many' else field_name.removesuffix('_ids') + "_id")
                return f"""
                // TODO: Odoo C# Code Generator could not resolve the related model for '{field_name}' ({field_type}).
                // Please uncomment and complete the following collection navigation property manually.
                /*
                [{attribute_name}(RelatedModel = "your.model.name", InverseField = "{inverse_field_guess}")]
                //[ForeignKey("{inverse_field_guess}")]
                public virtual ICollection<YourRelatedModel>? {pascal_field_name} {{ get; set; }}
                */
                """

        if field_type in ODOO_TO_CSHARP_TYPE:
            csharp_type = ODOO_TO_CSHARP_TYPE[field_type]
            is_required = field_info.get('is_required', False)
            is_translatable = field_info.get('is_translatable', False)
            is_sparse = field_info.get('is_sparse', False)

            if not is_required and '?' not in csharp_type: csharp_type += '?'
            attr_lines = ['[Required]' if is_required else '']

            if is_translatable or is_sparse:
                attr_lines.append(f'[JsonField(IsSparse = {str(is_sparse).lower()})]')
                attr_lines.append(f'[Column("{field_name}", TypeName = "jsonb")]')
            else:
                attr_lines.append(f'[Column("{field_name}")]')

            prop_content = f'{"\n            ".join(filter(None, attr_lines))}\n            public {csharp_type} {pascal_field_name} {{ get; set; }}\n'
        elif field_type == 'many2one':
            nav_property_name = to_pascal_case(field_name.removesuffix('_id'))
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_content = f"""
            [Column("{field_name}")] public Guid? {pascal_field_name} {{ get; set; }}
            [Many2one(RelatedModel = "{field_info['related_model']}")]
            [ForeignKey(nameof({pascal_field_name}))]
            public virtual {related_model_pascal}? {nav_property_name} {{ get; set; }}
            """
        elif field_type == 'one2many':
            inverse_field = field_info.get('inverse_field', '')
            csharp_inverse_field = inverse_field_nav_map.get(inverse_field, to_pascal_case(inverse_field))
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_content = f"""
            [One2many(RelatedModel = "{field_info['related_model']}", InverseField = "{csharp_inverse_field}")]
            //[ForeignKey("{csharp_inverse_field}")]
            public virtual ICollection<{related_model_pascal}>? {pascal_field_name} {{ get; set; }}
            """
        elif field_type == 'many2many':
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_content = f"""
            [Many2many(RelatedModel = "{field_info['related_model']}")]
            public virtual ICollection<{related_model_pascal}>? {pascal_field_name} {{ get; set; }}
            """
        return prop_content.strip()

    for field_name, field_info in model_data.get('fields', {}).items():
        if field_info.get('type') == 'Computed': continue
        
        prop_code, prop_name = "", ""
        sort_group = get_property_sort_group(field_info)
        
        if field_name == 'id': continue
        elif field_name == 'create_date':
            properties_to_generate['CreationTime'] = ('\n            [Column("create_date")]\n            public override DateTime CreationTime { get => base.CreationTime; protected set => base.CreationTime = value; }\n', 2)
        elif field_name == 'create_uid':
            res_users_pascal = to_pascal_case("res.users")
            properties_to_generate['CreatorId'] = ('\n            [Column("create_uid")]\n            public override Guid? CreatorId { get => base.CreatorId; protected set => base.CreatorId = value; }\n', 2)
            properties_to_generate['Creator'] = (f'\n            [ForeignKey(nameof(CreatorId))]\n            public virtual {res_users_pascal}? Creator {{ get; protected set; }}\n', 21)
        elif field_name == 'write_date':
            properties_to_generate['LastModificationTime'] = ('\n            [Column("write_date")]\n            public override DateTime? LastModificationTime { get => base.LastModificationTime; protected set => base.LastModificationTime = value; }\n', 2)
        elif field_name == 'write_uid':
            res_users_pascal = to_pascal_case("res.users")
            properties_to_generate['LastModifierId'] = ('\n            [Column("write_uid")]\n            public override Guid? LastModifierId { get => base.LastModifierId; protected set => base.LastModifierId = value; }\n', 2)
            properties_to_generate['LastModifier'] = (f'\n            [ForeignKey(nameof(LastModifierId))]\n            public virtual {res_users_pascal}? LastModifier {{ get; protected set; }}\n', 21)
        elif field_name == 'company_id':
            if 'related_model' in field_info:
                nav_prop_name = to_pascal_case('company')
                related_model_pascal = to_pascal_case(field_info['related_model'])
                prop_code = f'[ForeignKey(nameof(TenantId))]\n            public virtual {related_model_pascal}? {nav_prop_name} {{ get; set; }}'
                properties_to_generate[nav_prop_name] = (f'\n            {prop_code}\n', 21)
        else:
            prop_name = to_pascal_case(field_name)
            if field_info['type'].lower() in ['one2many', 'many2many'] and field_name.endswith('_ids'):
                prop_name = to_pascal_case(field_name[:-4]) + 's'
            
            prop_code = generate_property_string(field_name, field_info, prop_name)
            if prop_code:
                properties_to_generate[prop_name] = (f'\n            {prop_code}\n', sort_group)

    # =================================================================
    # THÊM ĐOẠN CODE GỠ LỖI NÀY VÀO ĐÂY
    # =================================================================
    logging.info(f"--- Debugging property keys for model: {model_name}, table_name: {model_data.get('table_name') } ---")
    # Lấy tất cả các key, chuyển thành list, sắp xếp và in ra
    property_keys = sorted(list(properties_to_generate.keys()))
    print(f"Generated property keys for '{model_name}': {property_keys}")
    logging.info(f"Generated property keys for '{model_name}': {property_keys}")
    logging.info(f"--- End debugging for model: {model_name} ---")
    # =================================================================

    content += "\n            //<editor-fold desc=\"ABP ENTITY PROPERTIES\">\n"
    content += "            [Key]\n            public override Guid Id { get => base.Id; protected set => base.Id = value; }\n"
    if has_company_id:
        content += '\n            [Column("company_id")]\n            public virtual Guid? TenantId { get; protected set; }\n'
    
    audit_overrides = ['CreationTime', 'CreatorId', 'LastModificationTime', 'LastModifierId', 'Creator', 'LastModifier', 'Company']
    for prop_name in audit_overrides:
        if prop_name in properties_to_generate:
            content += properties_to_generate.pop(prop_name)[0]
    content += "            //</editor-fold>\n"

    if property_order == 'abc':
        for prop_name, (prop_code, _) in sorted(properties_to_generate.items()):
            content += prop_code
    else: # type
        sorted_props = sorted(properties_to_generate.items(), key=lambda item: (item[1][1], item[0]))
        for _, (prop_code, _) in sorted_props:
            content += prop_code
    
    content += "        }\n    }"
    return format_csharp_code(content)

def create_enum_content(project_base_name, module_name, model_name, field_name, selection_list, flat_model_ns, module_namespace_map):
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))

    model_alias = to_pascal_case(model_name.split('.')[-1]); pascal_field = to_pascal_case(field_name)
    enum_name = f"{model_alias}{pascal_field}Enum"
    namespace = f"{project_base_name}.Models.Enums" if flat_model_ns else f"{project_base_name}.Domain.Enums.{pascal_module}"
    content = f"namespace {namespace}\n{{\n    public enum {enum_name}\n    {{\n"
    for value, _ in selection_list:
        clean_value = str(value)
        member_name = sanitize_csharp_identifier(to_pascal_case(clean_value))
        if clean_value.isdigit(): content += f"        {member_name} = {clean_value},\n"
        else: content += f"        {member_name},\n"
    content += "    }\n}"
    return format_csharp_code(content)

def create_partial_model_content(project_base_name, module_name, model_name, computed_fields, all_methods, flat_model_ns, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))
    
    namespace = f"{project_base_name}.Models" if flat_model_ns else f"{project_base_name}.Domain.Entities.{pascal_module}"
    content = f"""
    // Auto-generated by Odoo C# Code Generator
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using {project_base_name}.Domain.Shared.Attributes;

    namespace {namespace}
    {{
        public partial class {pascal_model}
        {{
    """
    
    for field_name, compute_method_name in sorted(computed_fields.items()):
        pascal_field = to_pascal_case(field_name)
        
        # Lấy thông tin chi tiết của phương thức compute
        compute_implementations = all_methods.get(compute_method_name, [])
        if compute_implementations:
            last_impl = compute_implementations[-1]
            compute_source = last_impl.get('source', f"# Source for '{compute_method_name}' not found.")
            source_module = last_impl.get('module', 'N/A')
            full_path = last_impl.get('source_file')
            source_file_info = Path(full_path).name if full_path else 'N/A'
            comment_header = f"--- ODOO COMPUTE METHOD SOURCE (MODULE: {source_module}, FILE: {source_file_info}) ---"
        else:
            compute_source = f"# Source for '{compute_method_name}' not found."
            comment_header = "--- ODOO COMPUTE METHOD SOURCE ---"

        content += f"""
            [NotMapped]
            public object {pascal_field} 
            {{ 
                get
                {{
                    /*
                    {comment_header}
{compute_source}
                    */
                    return default;
                }}
            }}
        """
    content += "    }\n}"
    return format_csharp_code(content)

def create_service_interface_content(project_base_name, module_name, model_name, model_data, methods, flat_model_dir, flat_service_ns, all_csharp_entity_names, module_namespace_map, is_mixin=False):
    pascal_model = to_pascal_case(model_name)
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))
    is_auto = model_data.get('is_auto', True)

    interface_name = f"I{pascal_model}AppService"
    contracts_namespace = f"{project_base_name}.Application.Contracts.Interfaces"
    interface_namespace = contracts_namespace + (".Mixins" if is_mixin else (f".{pascal_module}" if not flat_service_ns else ""))
    dto_namespace = f"{project_base_name}.Application.Contracts.DTOs" + (f".{pascal_module}" if not flat_service_ns else "")
    entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
    
    using_statements = ["using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Threading.Tasks;", "using Volo.Abp.Application.Services;"]
    
    if is_mixin:
        base_interface = "IMixinAppService"
        using_statements.extend([f"using {project_base_name}.Domain.Shared.Interfaces;", "using Volo.Abp.Domain.Entities;"])
        using_statements.append(f"using {contracts_namespace}.Mixins;")
    elif not is_auto:
        base_interface = "IApplicationService"
        using_statements.append(f"using {entity_namespace};")
        using_statements.append(f"using {dto_namespace};")
    else:
        base_interface = f"IGenericApplicationService<{pascal_model}>"
        using_statements.extend([f"using {entity_namespace};", f"using {project_base_name}.Application.Contracts;", f"using {dto_namespace};"])
    
    content = f"""
    {'\n'.join(list(set(using_statements)))}
    namespace {interface_namespace}
    {{
        public interface {interface_name} : {base_interface}
        {{
    """
    
    methods_to_generate = {}
    if is_mixin:
        for method_name, implementations in methods.items():
            is_instance_method = implementations[-1].get('is_instance_method', True)
            if is_instance_method or not method_name.startswith('_'):
                methods_to_generate[method_name] = implementations
    else:
        methods_to_generate = {k: v for k, v in methods.items() if not k.startswith('_') and k.lower() not in ODOO_COMMON_API_METHODS}
    
    sorted_method_info = []
    for method_name, implementations in methods_to_generate.items():
        csharp_name = ""
        if method_name.startswith('__'):
            csharp_name = "_" + to_pascal_case(method_name.strip('_')) + "InternalAsync"
        elif method_name.startswith('_'):
            csharp_name = to_pascal_case(method_name.strip('_')) + "InternalAsync"
        else:
            if is_mixin:
                csharp_name = to_pascal_case(method_name) + "Async"
            else:
                csharp_name = to_pascal_case(method_name.replace("action_", "")) + "Async"

        if csharp_name:
            sorted_method_info.append({'csharp_name': csharp_name, 'method_name': method_name, 'implementations': implementations})

        # csharp_name = to_pascal_case(method_name)
        # if not method_name.startswith('_') and not csharp_name.endswith("Async"): csharp_name += "Async"
        # sorted_method_info.append({'csharp_name': csharp_name, 'method_name': method_name, 'implementations': implementations})
    
    sorted_method_info.sort(key=lambda x: x['csharp_name']) 

    for item in sorted_method_info:
        service_method_name, implementations = item['csharp_name'], item['implementations']
        last_impl = implementations[-1]; params = last_impl.get('params', []); 
        is_instance_method = last_impl.get('is_instance_method', True)
        
        return_type_py = last_impl.get('return_type')
        if is_mixin and is_instance_method:
            #return_type_str = "TEntity" if return_type_py == 'self' else (return_type_py or "TEntity")
            if return_type_py == 'self':
                return_type_str = "IEnumerable<TEntity>"
            else:
                return_type_str = return_type_py or "TEntity"            
        else:
            return_type_str = return_type_py or (pascal_model if not is_mixin else "object")

        param_parts = [f"{map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)} @{p_name}" if p_name in CSHARP_KEYWORDS else f"{map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)} {p_name}" for p_name, p_type in params]
        
        generic_part, generic_constraint, param_str = "", "", ""
        if is_mixin and is_instance_method:
            generic_part = "<TEntity>"
            param_str = ", ".join([f"IEnumerable<TEntity> entities"] + param_parts)
            generic_constraint = f" where TEntity : IEntity<Guid>, I{pascal_model}able"
        elif not is_mixin:
            if params:
                dto_name = f"{pascal_model}{service_method_name.replace('Async', '')}RequestDto"
                param_str = f"Guid id, {dto_name} input"
            else:
                param_str = "Guid id"
        else:
            param_str = ", ".join(param_parts)
        
        return_type = f"Task<{map_python_type_to_csharp(return_type_str, all_csharp_entity_names)}>" if return_type_str != "void" else "Task"

        content += f"        {return_type} {service_method_name}{generic_part}({param_str}){generic_constraint};\n"
        
    content += "    }\n}"
    return format_csharp_code(content)

def create_service_implementation_content(project_base_name, module_name, model_name, model_data, methods, dependencies, flat_model_dir, flat_service_ns, include_private, all_csharp_entity_names, is_mixin, inherited_mixins, final_exclude_set, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))
    is_auto = model_data.get('is_auto', True)

    service_name, interface_name = f"{pascal_model}AppService", f"I{pascal_model}AppService"
    depends_list_str = ', '.join(f'\"{dep}\"' for dep in dependencies)
    depends_str = f"Depends = new[] {{ {depends_list_str} }}" if dependencies else ""
    contracts_namespace = f"{project_base_name}.Application.Contracts.Interfaces"
    dto_namespace = f"{project_base_name}.Application.Contracts.DTOs" + (f".{pascal_module}" if not flat_service_ns else "")
    interface_namespace = contracts_namespace + (".Mixins" if is_mixin else (f".{pascal_module}" if not flat_service_ns else ""))
    service_namespace = f"{project_base_name}.Application.Services" + (".Mixins" if is_mixin else (f".{pascal_module}" if not flat_service_ns else ""))
    
    using_statements = ["using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Threading.Tasks;", f"using {project_base_name}.Domain.Shared.Attributes;", f"using {interface_namespace};", f"using {dto_namespace};"]
    
    private_fields, constructor_assignments, constructor_params = [], [], []
    entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"

    if is_mixin:
        base_class, constructor_params, base_call = "ApplicationService", ["IServiceProvider serviceProvider"], ""
        using_statements.extend(["using Volo.Abp.Application.Services;", "using Volo.Abp.Domain.Entities;", f"using {entity_namespace};", f"using {project_base_name}.Domain.Shared.Interfaces;"])
        private_fields.append(f"private readonly IServiceProvider _serviceProvider;")
        constructor_assignments.append(f"_serviceProvider = serviceProvider;")

    # elif not is_auto:
    #     base_class, base_call = "ApplicationService", ""
    #     repo_interface_name = f"I{pascal_model}Repository"
    #     repo_var_name = f"_{repo_interface_name[1].lower()}{repo_interface_name[2:]}"
    #     repo_namespace = f"using {project_base_name}.Domain.Repositories;"
    #     using_statements.extend(["using Volo.Abp.Application.Services;", f"using {entity_namespace};", repo_namespace])
    #     private_fields.append(f"private readonly {repo_interface_name} {repo_var_name};")
    #     constructor_params.append(f"{repo_interface_name} {repo_var_name[1:]}")
    #     constructor_assignments.append(f"{repo_var_name} = {repo_var_name[1:]};")
    else:
        base_class = f"GenericApplicationService<{pascal_model}>"
        base_constructor_params_str = "repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache"
        constructor_params = [f"IRepository<{pascal_model}, Guid> repository", "IServiceProvider serviceProvider", "AuthorizationService authorizationService", "DomainParser domainParser", "IModelTypeRegistry modelTypeRegistry", "IDataFilter dataFilter", "IObjectMapper objectMapper", "IMemoryCache memoryCache"]
        base_call = f": base({base_constructor_params_str})"
        using_statements.extend([
            f"using Microsoft.Extensions.Caching.Memory;", f"using Volo.Abp.Domain.Repositories;", f"using Volo.Abp.ObjectMapping;", f"using Volo.Abp.Data;",
            f"using {project_base_name}.Application.Services.Commons;", f"using {entity_namespace};"
        ])
    
    if not is_mixin and inherited_mixins:
        mixin_interface_namespace = f"{contracts_namespace}.Mixins"
        using_statements.append(f"using {mixin_interface_namespace};")
        for mixin_name in sorted(inherited_mixins):
            if mixin_name in (final_exclude_set or set()):
                pascal_mixin = to_pascal_case(mixin_name)
                mixin_interface = f"I{pascal_mixin}AppService"
                mixin_var_name_camel = to_pascal_case(mixin_name.replace('.', '_'))
                mixin_var_name_camel = mixin_var_name_camel[0].lower() + mixin_var_name_camel[1:] + "AppService"
                private_fields.append(f"private readonly {mixin_interface} _{mixin_var_name_camel};")
                constructor_params.append(f"{mixin_interface} {mixin_var_name_camel}")
                constructor_assignments.append(f"_{mixin_var_name_camel} = {mixin_var_name_camel};")
    
    content_parts = [
        f"{'\n'.join(sorted(list(set(using_statements))))}",
        f"\nnamespace {service_namespace}", f"{{",
        f"    [Module(\"{module_name}\"{(', ' + depends_str) if depends_str else ''})]",
        f"    public class {service_name} : {base_class}, {interface_name}", f"    {{",
        '\n'.join([f"        {field}" for field in private_fields]),
        f"        public {service_name}({', '.join(constructor_params)}) {base_call}",
        f"        {{",
        '\n'.join([f"            {assign}" for assign in constructor_assignments]),
        f"        }}",
    ]
    
    sorted_methods_info = []
    for method_name, implementations in methods.items():
        if not include_private and method_name.startswith('_'): continue
        
        csharp_name, visibility = "", ""
        is_public = not method_name.startswith('_')
        is_common_method = method_name.lower() in ODOO_COMMON_API_METHODS
        is_instance_method = implementations[-1].get('is_instance_method', True)

        if is_mixin:
            if is_instance_method or is_public:
                visibility = "public"
            elif method_name.startswith('__'):
                visibility = "private"
            else: #_
                visibility = "protected"
        else: # Regular Service
            if method_name.startswith('__'):
                visibility = "private"
            elif method_name.startswith('_'):
                visibility = "protected"
            else:
                visibility = "public"
                if is_common_method:
                    is_override = len(implementations) > 1 or (implementations and implementations[0]['module'] != master_models.get(model_name, {}).get('base_module'))
                    if not is_override: continue
                    visibility += " override"
        
        if method_name.startswith('__'):
            csharp_name = "_" + to_pascal_case(method_name.strip('_')) + "InternalAsync"
        elif method_name.startswith('_'):
            csharp_name = to_pascal_case(method_name.strip('_')) + "InternalAsync"
        elif is_common_method:
            csharp_name = to_pascal_case(method_name.replace("action_", "")) + "Async"
            #csharp_name = to_pascal_case(method_name) + "Async"
        else:
            if is_mixin:
                csharp_name = to_pascal_case(method_name) + "Async"
            else:
                csharp_name = to_pascal_case(method_name.replace("action_", "")) + "Async"
        
        if csharp_name:
            sorted_methods_info.append({'csharp_name': csharp_name, 'visibility': visibility, 'python_name': method_name, 'implementations': implementations})
    
    sorted_methods_info.sort(key=lambda x: x['csharp_name'])

    for item in sorted_methods_info:
        service_method_name, visibility, method_name, implementations = item['csharp_name'], item['visibility'], item['python_name'], item['implementations']
        last_impl = implementations[-1]
        params, return_type_str_py = last_impl.get('params', []), last_impl.get('return_type', None)
        is_common_method = method_name.lower() in ODOO_COMMON_API_METHODS
        is_instance_method = last_impl.get('is_instance_method', True)
        base_call_params = ""
        
        param_parts = [f"{map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)} @{p_name}" if p_name in CSHARP_KEYWORDS else f"{map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)} {p_name}" for p_name, p_type in params]
        
        generic_part, generic_constraint, param_str = "", "", ""
        if is_mixin and 'public' in visibility and is_instance_method:
            generic_part = "<TEntity>"
            param_str = ", ".join([f"IEnumerable<TEntity> entities"] + param_parts)
            generic_constraint = f" where TEntity : IEntity<Guid>, I{pascal_model}able"

        elif 'public' in visibility and not is_common_method and not is_mixin:
            if params:
                #dto_name = f"{pascal_model}{action_name}RequestDto"
                dto_name = f"{pascal_model}{service_method_name.replace('Async', '')}RequestDto"
                #dto_name = f"{pascal_model}{method_name.replace('action_', '')}RequestDto"
                param_str = f"Guid id, {dto_name} input"
            else:
                param_str = "Guid id"
        elif is_common_method and 'override' in visibility:
            if method_name.lower() in ['write', 'unlink']:
                param_str = ", ".join([f"List<Guid> ids"] + param_parts)
            elif method_name.lower() == 'create':
                param_str = ", ".join(param_parts)
            else: # copy and others
                 param_str = ", ".join([f"Guid id"] + param_parts)
        else: # private/protected
            param_str = ", ".join(param_parts)
        
        if is_common_method and 'override' in visibility:
            if method_name.lower() == 'write': param_str, return_type, base_call_params = f"List<Guid> ids, {pascal_model} entity, List<string> fields", "Task<List<object>>", "ids, entity, fields"
            elif method_name.lower() == 'create': param_str, return_type, base_call_params = f"{pascal_model} entity, List<string> fields", f"Task<{pascal_model}>", "entity, fields"
            elif method_name.lower() == 'copy': param_str, return_type, base_call_params = f"Guid id, List<string> fields, {pascal_model} defaultValues = null", f"Task<{pascal_model}>", "id, fields, defaultValues"
            elif method_name.lower() == 'unlink': param_str, return_type, base_call_params = f"List<Guid> ids", "Task<object>", "ids"
            elif method_name.lower() == 'default_get': param_str, return_type, base_call_params = f"List<string> fields", f"Task<{pascal_model}>", "fields"
            elif method_name.lower() == 'fields_get': param_str, return_type, base_call_params = f"List<string> fields = null, Dictionary<string, List<string>> attributes = null", f"Task<Dictionary<string, Dictionary<string, object>>>", "fields, attributes"
            elif method_name.lower() == 'name_create': param_str, return_type, base_call_params = f"string name", f"Task<object>", "name"
            elif method_name.lower() == 'name_get': param_str, return_type, base_call_params = f"List<Guid> ids", f"Task<List<(Guid Id, string Name)>>", "ids"
            elif method_name.lower() == 'name_search': param_str, return_type, base_call_params = f"string name, string domain = null, string @operator = \"ilike\", int limit = 100", f"Task<List<(Guid Id, string Name)>>", "name, domain, @operator, limit"
            elif method_name.lower() == 'on_change': param_str, return_type, base_call_params = f"List<string> changedFields, {pascal_model} values, Dictionary<string, object> fieldInfo", f"Task<object>", "changedFields, values, fieldInfo"
            else:
                final_return_type = return_type_str_py or "object"
                return_type = f"Task<{map_python_type_to_csharp(final_return_type, all_csharp_entity_names)}>"
        else:
            if is_mixin and is_instance_method:
                final_return_type = "TEntity" if return_type_str_py == 'self' else (return_type_str_py or "TEntity")
            else:
                final_return_type = return_type_str_py or (pascal_model if not is_mixin else "object")
            return_type = f"Task<{map_python_type_to_csharp(final_return_type, all_csharp_entity_names)}>" if final_return_type != "void" else "Task"

        if not service_method_name: continue
        
        comment_wrapper = ("/*", "*/")
        source_code_combined = "\n".join(impl['source'] for impl in implementations)
        if "/*" in source_code_combined or "*/" in source_code_combined:
            comment_wrapper = ("#if PYTHON_CODE", "#endif")
        
        method_body = [f"\n        {visibility} async {return_type} {service_method_name}{generic_part}({param_str}){generic_constraint}", "        {", f"            {comment_wrapper[0]}"]
        for impl in implementations:
            source_code, tag = impl['source'], "BASE" if len(implementations) > 1 and impl == implementations[0] else "INHERITS"
            method_body.append(f"            --- ODOO METHOD SOURCE (MODULE: {impl['module']}, FILE: {Path(impl['source_file']).name}) ---")
            for line in source_code.split('\n'): method_body.append(f"            // {line}")
        method_body.append(f"            {comment_wrapper[1]}")
        
        if is_common_method and 'override' in visibility and not is_mixin and base_call_params:
            method_body.append(f"            return await base.{service_method_name}({base_call_params});")
        elif "Task<" in return_type and 'public' in visibility and not is_mixin:
            method_body.append(f"            var entity = await Repository.GetAsync(id); return entity;")
        elif "Task<" in return_type:
            method_body.append(f"            return default;")
        else:
            method_body.append(f"            await Task.CompletedTask;")
        method_body.append("        }")
        content_parts.extend(method_body)
    content_parts.extend(["    }", "}"])
    return "\n".join(content_parts)

def create_dtos_content(project_base_name, module_name, model_name, methods, flat_model_ns, flat_service_ns, all_csharp_entity_names, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))
    
    # Namespace cho DTOs sẽ tuân theo cờ của service
    namespace = f"{project_base_name}.Application.Contracts.DTOs" + (f".{pascal_module}" if not flat_service_ns else "")
    
    using_statements = {"using System;","using System.Collections.Generic;", "using System.Collections.Generic;"}
    
    dto_classes = []
    specific_actions = {name: impl for name, impl in methods.items() if not name.startswith('_') and name.lower() not in ODOO_COMMON_API_METHODS}

    sorted_actions = []
    for method_name, implementations in specific_actions.items():
        action_name = to_pascal_case(method_name.replace("action_", ""))
        sorted_actions.append({'csharp_name': action_name, 'implementations': implementations})
    sorted_actions.sort(key=lambda x: x['csharp_name'])

    for item in sorted_actions:
        action_name, implementations = item['csharp_name'], item['implementations']
        last_impl = implementations[-1]
        params = last_impl.get('params', [])
        
        if not params:
            continue
            
        dto_name = f"{pascal_model}{action_name}RequestDto"
        class_content = [f"    public class {dto_name}\n    {{"]
        for p_name, p_type in params:
            csharp_type = map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)
            prop_name = to_pascal_case(p_name)
            class_content.append(f"        public {csharp_type} {prop_name} {{ get; set; }}")
        class_content.append("    }")
        dto_classes.append("\n".join(class_content))

    if not dto_classes:
        return None

    content = f"""
    // Auto-generated by Odoo C# Code Generator
    {'\n'.join(list(using_statements))}

    namespace {namespace}
    {{
    {'\n\n'.join(dto_classes)}
    }}
    """
    return format_csharp_code(content)

def create_controller_content(project_base_name, module_name, module_category, model_name, model_data, methods, flat_model_ns, flat_service_ns, flat_controller_ns, add_common_actions, all_csharp_entity_names, group_by_category, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module = module_namespace_map.get(module_name, to_pascal_case(module_name))
    is_auto = model_data.get('is_auto', True)

    controller_name = f"{pascal_model}Controller"
    interface_name = f"I{pascal_model}AppService"
    
    entity_namespace = f"{project_base_name}.Models" if flat_model_ns else f"{project_base_name}.Domain.Entities.{pascal_module}"
    interface_namespace = f"{project_base_name}.Application.Contracts.Interfaces" + (f".{pascal_module}" if not flat_service_ns else "")
    controller_namespace = f"{project_base_name}.HttpApi.Controllers" + (f".{pascal_module}" if not flat_controller_ns else "")
    dto_namespace = f"{project_base_name}.Application.Contracts.DTOs" + (f".{pascal_module}" if not flat_service_ns else "")

    route_parts = ["api", "v1"]
    if group_by_category and module_category:
        clean_category = module_category.split('/')[0].strip().lower().replace(' ', '-')
        if clean_category == 'hidden':
            clean_category = module_name.replace('_','-')
        if clean_category: route_parts.append(clean_category)
    #route_parts.append(module_name.replace('_','-'))
    #route_parts.append(model_name.replace('_','-'))
    route_parts.append(pascal_model)
    route = f'[Route("{'/'.join(route_parts)}")]'
    
    if add_common_actions and is_auto:
        base_class = f"GenericController<{pascal_model}, {interface_name}>"
        using_statements = {f"using {project_base_name}.HttpApi.Controllers.Commons;"}
        constructor_body = f"public {controller_name}({interface_name} service) : base(service) {{ }}"
    else:
        base_class = "AbpControllerBase"
        using_statements = set()
        constructor_body = f"private readonly {interface_name} _appService;\n        public {controller_name}({interface_name} appService) {{ _appService = appService; }}"
    
    using_statements.update(["using System;", "using System.Collections.Generic;", "using System.Threading.Tasks;", "using Microsoft.AspNetCore.Mvc;", "using Volo.Abp.AspNetCore.Mvc;", f"using {interface_namespace};", f"using {entity_namespace};"])
    
    #{'\n'.join(sorted(list(using_statements)))}
    main_content = f"""
    {'\n'.join(list(using_statements))}
    namespace {controller_namespace}
    {{
        {route}
        public partial class {controller_name} : {base_class}
        {{
            {constructor_body}
        }}
    }}
    """
    
    partial_content = ""
    specific_actions = {name: impl for name, impl in methods.items() if not name.startswith('_') and name.lower() not in ODOO_COMMON_API_METHODS}
    
    if specific_actions:
        partial_using = { "using System;", "using System.Collections.Generic;", "using System.Threading.Tasks;", "using Microsoft.AspNetCore.Mvc;", f"using {entity_namespace};", f"using {dto_namespace};" }
        partial_content_action_result = f"""
        {'\n'.join(list(partial_using))}
        namespace {controller_namespace}
        {{
            public partial class {controller_name}
            {{
        """
        partial_content_entity_result = f"""
        {'\n'.join(list(partial_using))}
        namespace {controller_namespace}
        {{
            public partial class {controller_name}
            {{
        """
        service_accessor = "AppService" if add_common_actions else "_appService"
        
        sorted_actions = []
        for method_name, implementations in specific_actions.items():
            #action_name = to_pascal_case(method_name.replace("action_", ""))
            action_name = to_pascal_case(method_name)
            #sorted_actions.append({'csharp_name': action_name, 'implementations': implementations})
            sorted_actions.append({'csharp_name': action_name, 'python_name': to_pascal_case(method_name.replace("action_", "")), 'implementations': implementations})
        
        sorted_actions.sort(key=lambda x: x['csharp_name'])

        for item in sorted_actions:
            action_name, method_name, implementations = item['csharp_name'], item['python_name'], item['implementations']
            last_impl = implementations[-1]
            params = last_impl.get('params', [])

            # Xác định kiểu trả về
            return_type_py = last_impl.get('return_type', pascal_model)
            csharp_return_type = map_python_type_to_csharp(return_type_py, all_csharp_entity_names)
            final_return_type = f"Task<{csharp_return_type}>"

            route_action = ''.join(['-' + c.lower() if c.isupper() else c for c in action_name]).strip('-')
            #dto_name, action_params, service_call_params = f"{action_name}RequestDto", "Guid id", "id"
            action_params, service_call_params = "Guid id", "id"
            if params:
                dto_name = f"{pascal_model}{method_name}RequestDto"
                action_params += f", [FromBody] {dto_name} input"
                service_call_params = f"id, input" # Thay đổi ở đây
                #service_call_params += ", " + ", ".join(f"input.{to_pascal_case(p_name)}" for p_name, _ in params)
            service_method_name = f"{method_name}Async"
            #service_method_name = f"{action_name}Async"
            partial_content_entity_result += f"""
                [HttpPost]
                [Route(\"{{id}}/{route_action}\")]
                public async {final_return_type} {action_name}Async({action_params})
                {{
                    var result = await {service_accessor}.{service_method_name}({service_call_params});
                    return result;
                }}
            """            
            partial_content_entity_result += "            }\n}"

            partial_content_action_result += f"""
                [HttpPost]
                [Route(\"{{id}}/{route_action}\")]
                public async Task<IActionResult> {action_name}Async({action_params})
                {{
                    var result = await {service_accessor}.{service_method_name}({service_call_params});
                    return Ok(result);
                }}
            """
        partial_content_action_result += "            }\n}"
        partial_content = partial_content_action_result
        #partial_content = partial_content_entity_result
    return format_csharp_code(main_content), format_csharp_code(partial_content) if partial_content else None

def create_marker_interface_content(project_name, mixin_name):
    """
    Tạo nội dung cho một interface đánh dấu (marker interface) rỗng.
    Ví dụ: 'mail.thread' -> 'IMailThreadable'
    """
    pascal_mixin = to_pascal_case(mixin_name)
    interface_name = f"I{pascal_mixin}able"
    namespace = f"{project_name}.Domain.Shared.Interfaces"
    
    content = f"""
    // Auto-generated Marker Interface from Odoo Mixin {mixin_name}
    namespace {namespace}
    {{
        public interface {interface_name}
        {{
            // This interface is used to mark entities that inherit from the '{mixin_name}' Odoo mixin.
            // It can be used for generic constraints in services.
        }}
    }}
    """
    return format_csharp_code(content)

def create_mixin_data_interface_content(project_name, mixin_name, model_data, all_csharp_entity_names, flat_model_dir, module_namespace_map):
    pascal_mixin = to_pascal_case(mixin_name)
    interface_name = f"I{pascal_mixin}Data"
    namespace = f"{project_name}.MixinData"
    
    using_statements = {"using System;", "using System.Collections.Generic;", "using Volo.Abp.Domain.Entities;"}
    for field_name, field_info in model_data['fields'].items():
        # SỬA LỖI: Áp dụng quy tắc cho country_id
        if field_name.endswith('_country_id') and 'related_model' not in field_info:
            field_info['related_model'] = 'res.country'
            logging.info(f"  -> Heuristic applied: Field '{field_name}' in mixin assuming related model is 'res.country'.")
        
        if 'related_model' in field_info:
            related_model_name = field_info['related_model']
            if related_model_name in master_models:
                related_model_base_module = master_models[related_model_name].get('base_module')
                if related_model_base_module:
                    pascal_related_module = module_namespace_map.get(related_model_base_module, to_pascal_case(related_model_base_module))
                    entity_namespace = f"{project_name}.Models" if flat_model_dir else f"{project_name}.Domain.Entities.{pascal_related_module}"
                    using_statements.add(f"using {entity_namespace};")

    content = f"""
    // Auto-generated Data Interface from Odoo Mixin {mixin_name}
    {'\n'.join(sorted(list(using_statements)))}

    namespace {namespace}
    {{
        public interface {interface_name}
        {{
    """
    
    # Logic tạo thuộc tính tương tự như trong entity generation, nhưng chỉ là chữ ký
    for field_name, field_info in sorted(model_data['fields'].items()):
        if 'related_model' not in field_info and field_info['type'].lower() in ['many2one', 'one2many', 'many2many']:
            continue # Bỏ qua nếu không phân giải được trong interface

        field_type = field_info['type'].lower()
        prop_signature = ""
        
        if field_type in ODOO_TO_CSHARP_TYPE:
            pascal_field = to_pascal_case(field_name)
            csharp_type = ODOO_TO_CSHARP_TYPE[field_type]
            is_required = field_info.get('is_required', False)
            if not is_required and '?' not in csharp_type:
                csharp_type += '?'
            prop_signature = f"{csharp_type} {pascal_field} {{ get; set; }}"
            
        elif field_type == 'many2one':
            nav_property_name = to_pascal_case(field_name.removesuffix('_id'))
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_signature = f"{related_model_pascal}? {nav_property_name} {{ get; set; }}"

        elif field_type in ['one2many', 'many2many']:
            pascal_field = to_pascal_case(field_name)
            if field_name.endswith('_ids'):
                pascal_field = to_pascal_case(field_name[:-4]) + 's'
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_signature = f"ICollection<{related_model_pascal}>? {pascal_field} {{ get; set; }}"

        if prop_signature:
            content += f"        {prop_signature}\n\n"

    content += "    }\n}"
    return format_csharp_code(content)

def create_readonly_repository_interface_content(project_base_name, model_name, flat_model_dir, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    interface_name = f"I{pascal_model}Repository"
    
    # Namespace cho entity (view)
    base_module = master_models[model_name].get('base_module', 'base')
    pascal_module = module_namespace_map.get(base_module, to_pascal_case(base_module))
    entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"

    namespace = f"{project_base_name}.Domain.Repositories" # Namespace cố định cho repo interface

    content = f"""
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using {entity_namespace};
    using Volo.Abp.Domain.Services;

    namespace {namespace}
    {{
        public interface {interface_name} : IDomainService
        {{
            // TODO: Add your custom read-only methods here. For example:
            // Task<List<{pascal_model}>> GetReportAsync(DateTime startDate, DateTime endDate);
        }}
    }}
    """
    return format_csharp_code(content)

def create_readonly_repository_implementation_content(project_base_name, model_name, flat_model_dir, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    interface_name = f"I{pascal_model}Repository"
    implementation_name = f"EfCore{pascal_model}Repository"
    
    base_module = master_models[model_name].get('base_module', 'base')
    pascal_module = module_namespace_map.get(base_module, to_pascal_case(base_module))
    entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
    
    interface_namespace = f"{project_base_name}.Domain.Repositories"
    implementation_namespace = f"{project_base_name}.EntityFrameworkCore.Repositories"
    
    content = f"""
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using {project_base_name}.EntityFrameworkCore;
    using {entity_namespace};
    using {interface_namespace};
    using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
    using Volo.Abp.EntityFrameworkCore;

    namespace {implementation_namespace}
    {{
        public class {implementation_name}
            : EfCoreRepository<{project_base_name}DbContext, {pascal_model}>,
              {interface_name}
        {{
            public {implementation_name}(
                IDbContextProvider<{project_base_name}DbContext> dbContextProvider)
                : base(dbContextProvider)
            {{
            }}

            // TODO: Implement your custom read-only methods here. For example:
            /*
            public async Task<List<{pascal_model}>> GetReportAsync(DateTime startDate, DateTime endDate)
            {{
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .Where(report => report.OrderDate >= startDate && report.OrderDate <= endDate)
                    .ToListAsync();
            }}
            */
        }}
    }}
    """
    return format_csharp_code(content)

def create_fluent_api_configuration_content(project_base_name, model_name, model_data, flat_model_dir, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    base_module = model_data.get('base_module', 'unknown')
    pascal_module = module_namespace_map.get(base_module, to_pascal_case(base_module))
    
    table_name = model_data.get('table_name') or model_name.replace('.', '_')
    entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
    
    is_auto = model_data.get('is_auto', True)
    if not is_auto:
        logging.info(f"  -> Generating custom fluent_api for '{model_name}'.")
    
    using_statements = {
        "using System;"
        "using System.Collections.Generic;"
        "using Microsoft.EntityFrameworkCore;",
        f"using {entity_namespace};"
    }

    content = f"""
    {'\n'.join(sorted(list(using_statements)))}

    namespace {project_base_name}.EntityFrameworkCore
    {{
        public static partial class ModelBuilderExtensions
        {{
            public static void Configure{pascal_model}(this ModelBuilder modelBuilder)
            {{
                modelBuilder.Entity<{pascal_model}>(b =>
                {{
    """
    
    # --- Bước 1: Cấu hình Bảng/View và Khóa ---
    if not is_auto:
        content += f"""
                    b.ToView("{table_name}");
                    b.HasNoKey();
        """
    else:
        content += f"""
                    b.ToTable("{table_name}");
                    b.HasKey(e => e.Id).HasName("{table_name}_pkey");

                    // Indexes
        """
        
        # Tạo Index
        for field_name, field_info in model_data.get('fields', {}).items():
            if field_info.get('type') == 'many2one' or field_info.get('has_index'):
                csharp_prop_name = to_pascal_case(field_name)
                # Ánh xạ tới các thuộc tính ABP đúng
                if field_name == 'create_uid': csharp_prop_name = 'CreatorId'
                elif field_name == 'write_uid': csharp_prop_name = 'LastModifierId'
                elif field_name == 'company_id': csharp_prop_name = 'TenantId'

                index_name = f"{table_name}_{field_name}_index"
                content += f'                    b.HasIndex(e => e.{csharp_prop_name}, "{index_name}");\n'
    
    # --- Bước 2: Cấu hình các Thuộc tính ---
    content += "\n                    // Properties\n"
    
    # Các trường đã được xử lý bởi ABP hoặc là quan hệ, không cần định nghĩa property cơ bản
    abp_handled_fields = {'id', 'create_date', 'create_uid', 'write_date', 'write_uid', 'company_id'}
    
    for field_name, field_info in model_data.get('fields', {}).items():
        if field_name in abp_handled_fields:
            continue
        if field_name not in abp_handled_fields or field_info.get('type') != 'many2one' and field_info.get('type') in ODOO_TO_CSHARP_TYPE:
            prop_config = ""
            csharp_prop_name = to_pascal_case(field_name)
            
            # Đổi tên cho các thuộc tính collection
            if field_info.get('type') in ['one2many', 'many2many'] and field_name.endswith('_ids'):
                csharp_prop_name = to_pascal_case(field_name[:-4]) + 's'

            prop_config = f'b.Property(e => e.{csharp_prop_name}).HasColumnName("{field_name}");'
            if field_info.get('is_required'):
                prop_config = prop_config.replace(";", ".IsRequired();")
            
            if prop_config:
                content += f"                    {prop_config}\n"

    # --- Bước 3: Ánh xạ các thuộc tính kế thừa của ABP (chỉ cho model _auto=True) ---
    if is_auto:
        content += "\n                    // ABP-Framework Audit/Tenant Properties\n"
        if 'id' in model_data['fields']: content += f'                    b.Property(e => e.Id).HasColumnName("id");\n'
        if 'create_date' in model_data['fields']: content += f'                    b.Property(e => e.CreationTime).HasColumnName("create_date");\n'
        if 'create_uid' in model_data['fields']: content += f'                    b.Property(e => e.CreatorId).HasColumnName("create_uid");\n'
        if 'write_date' in model_data['fields']: content += f'                    b.Property(e => e.LastModificationTime).HasColumnName("write_date");\n'
        if 'write_uid' in model_data['fields']: content += f'                    b.Property(e => e.LastModifierId).HasColumnName("write_uid");\n'
        if 'company_id' in model_data['fields']: content += f'                    b.Property(e => e.TenantId).HasColumnName("company_id");\n'
    
    content += """
                });
            }
        }
    }
    """
    return format_csharp_code(content)
#</editor-fold>

#<editor-fold desc="Odoo AST Visitor">
class OdooModelVisitor(ast.NodeVisitor):
    def __init__(self, source_code, source_filename):
        self.found_models = []
        self.full_source_text = source_code
        self.source_filename = source_filename

    def _get_type_hint_str(self, annotation_node):
        if not annotation_node: return None
        if isinstance(annotation_node, ast.Constant): return annotation_node.value
        if isinstance(annotation_node, ast.Name): return annotation_node.id
        if isinstance(annotation_node, ast.Subscript):
            if isinstance(annotation_node.value, ast.Name) and annotation_node.value.id in ['list', 'List']:
                slice_type = self._get_type_hint_str(annotation_node.slice)
                return f"list[{slice_type}]" if slice_type else "list"
        return None

    def visit_ClassDef(self, node):
        current_class_info = {
            'name': None, 'inherits': [], 'fields': {}, 'methods': {}, 
            'is_transient': False, 'is_abstract': False, 'base_classes': [], 
            'delegated_inherits': [], 'table_name': None, 'is_auto': True,
            'attributes': {}
        }

        for base in node.bases:
            if isinstance(base, ast.Attribute) and hasattr(base, "value") and hasattr(base.value, "id"):
                base_name = f"{base.value.id}.{base.attr}"
                current_class_info['base_classes'].append(base_name)
                if base_name == 'models.AbstractModel': current_class_info['is_abstract'] = True
                if base_name == 'models.TransientModel': current_class_info['is_transient'] = True
        
        for item in node.body:
            if isinstance(item, ast.Assign):
                for target in item.targets:
                    if isinstance(target, ast.Name) and target.id.startswith('_'):
                        if target.id == '_name' and isinstance(item.value, ast.Constant):
                            current_class_info['name'] = item.value.value
                        elif target.id == '_auto' and isinstance(item.value, ast.Constant) and item.value.value is False:
                            current_class_info['is_auto'] = False
                        elif target.id == '_table' and isinstance(item.value, ast.Constant):
                            current_class_info['table_name'] = item.value.value
                        elif target.id == '_description' and isinstance(item.value, ast.Constant):
                            current_class_info['attributes']['Description'] = item.value.value
                        elif target.id == '_inherit':
                            if isinstance(item.value, ast.Constant):
                                current_class_info['inherits'].append(item.value.value)
                            elif isinstance(item.value, (ast.List, ast.Tuple)):
                                for elt in item.value.elts:
                                    if isinstance(elt, ast.Constant):
                                        current_class_info['inherits'].append(elt.value)
                        elif target.id == '_inherits' and isinstance(item.value, ast.Dict):
                            for key_node, val_node in zip(item.value.keys, item.value.values):
                                if isinstance(key_node, ast.Constant) and isinstance(val_node, ast.Constant):
                                    current_class_info['delegated_inherits'].append((key_node.value, val_node.value))
        
        if current_class_info['name'] or current_class_info['inherits']:
            for item in node.body:
                if isinstance(item, ast.Assign):
                    self._parse_field(item, current_class_info)
                elif isinstance(item, ast.FunctionDef):
                    self._parse_method(item, current_class_info)
            
            self.found_models.append(current_class_info)

    def _parse_field(self, node, context):
        if not (len(node.targets) == 1 and isinstance(node.targets[0], ast.Name) and isinstance(node.value, ast.Call)): return
        field_name = node.targets[0].id
        if field_name.startswith('_'): return # Bỏ qua các trường private của class
        
        call = node.value
        if not (isinstance(call.func, ast.Attribute) and hasattr(call.func.value, 'id') and call.func.value.id == 'fields'): return
        
        field_type = call.func.attr
        field_data = {'type': field_type, 'attributes': {}}
        
        for kw in call.keywords:
            if isinstance(kw.value, ast.Constant):
                field_data['attributes'][to_pascal_case(kw.arg)] = kw.value.value

        field_data['is_required'] = field_data['attributes'].get('Required', False)
        field_data['is_translatable'] = field_data['attributes'].get('Translate', False)
        field_data['is_sparse'] = field_data['attributes'].get('Sparse', False)
        field_data['has_index'] = field_data['attributes'].get('Index', False)

        if 'Compute' in field_data['attributes']:
            field_data['type'] = 'Computed'
            field_data['compute'] = field_data['attributes']['Compute']

        if field_type.lower() in ['many2one', 'one2many', 'many2many']:
            related_model = None
            if call.args and isinstance(call.args[0], ast.Constant):
                related_model = call.args[0].value
            elif 'ComodelName' in field_data['attributes']:
                related_model = field_data['attributes']['ComodelName']
            
            if related_model:
                field_data['related_model'] = related_model
            
            if field_type.lower() == 'one2many':
                inverse_field = None
                if len(call.args) > 1 and isinstance(call.args[1], ast.Constant):
                    inverse_field = call.args[1].value
                elif 'InverseName' in field_data['attributes']:
                    inverse_field = field_data['attributes']['InverseName']
                if inverse_field:
                    field_data['inverse_field'] = inverse_field
        
        if field_type.lower() == 'selection':
            selection_list = []
            if 'Selection' in field_data['attributes'] and isinstance(field_data['attributes']['Selection'], list):
                selection_list = field_data['attributes']['Selection']
            field_data['selection'] = selection_list
        if field_type.lower() == 'serialized':
            field_data['is_sparse'] = True

        context['fields'][field_name] = field_data

    def _parse_method(self, node, context):
        method_name = node.name
        is_instance_method = len(node.args.args) > 0 and node.args.args[0].arg == 'self'
        params = [(arg.arg, self._get_type_hint_str(arg.annotation) or "object") for arg in node.args.args[1:]]
        return_type_str = self._get_type_hint_str(node.returns)
        source_code = ""
        try:
            source_code = ast.get_source_segment(self.full_source_text, node)
        except:
            try: source_code = inspect.getsource(node)
            except: source_code = f"# Could not retrieve source code for {method_name}"
        method_data = {'params': params, 'source': inspect.cleandoc(source_code or ""), 'is_instance_method': is_instance_method, 'source_file': self.source_filename}
        if return_type_str: method_data['return_type'] = return_type_str
        context['methods'][method_name] = method_data
#</editor-fold>

def _resolve_base_modules(master_models, module_infos, all_parsed_files, all_module_names):
    logging.info("Resolving base modules for all models...")
    
    # Bước 1: Thu thập các module ứng viên cho mỗi model
    base_module_candidates = {}
    for parsed_file in all_parsed_files:
        module_name = parsed_file['module_name']
        for info in parsed_file['models']:
            defined_model_name = info.get('name')
            if defined_model_name:
                base_module_candidates.setdefault(defined_model_name, []).append(module_name)

    # Bước 2: Xây dựng cây phụ thuộc bắc cầu
    transitive_deps = {}
    def get_transitive_dependencies(module, seen=None):
        # `seen` dùng để chống lặp vô hạn trong trường hợp có dependency vòng tròn
        if seen is None: seen = set()
        if module in seen: return set()
        seen.add(module)
        
        # Dùng cache để tăng tốc
        if module in transitive_deps:
            return transitive_deps[module]

        # Lấy các phụ thuộc trực tiếp
        direct_deps = set(module_infos.get(module, {}).get('depends', []))
        all_deps = set(direct_deps)

        # Đệ quy để lấy phụ thuộc của các phụ thuộc
        for dep in direct_deps:
            next_deps = get_transitive_dependencies(dep, seen.copy())
            all_deps.update(next_deps)
        
        transitive_deps[module] = sorted(all_deps)
        return all_deps

    for module in sorted(all_module_names):
        get_transitive_dependencies(module)
        print(f"Module {module} depends: {transitive_deps[module]}")

    # Bước 3: Quyết định module gốc dựa trên cây phụ thuộc
    base_module_map = {}
    for model_name, candidates in base_module_candidates.items():
        # THÊM MỚI: Bật cờ logging nếu model là 'res.partner'
        is_logging = model_name == 'res.partner'
        
        if is_logging:
            logging.info(f"\n--- Start Debugging for model: {model_name} ---")
            logging.info(f"Candidates: {sorted(candidates)}")
            print(f"\n--- Start Debugging for model: {model_name} ---")
            print(f"Candidates: {sorted(candidates)}")

        if len(candidates) == 1:
            base_module_map[model_name] = candidates[0]
            continue
        
        root_module = None
        for cand_a in sorted(candidates): # Sắp xếp để đảm bảo thứ tự nhất quán
            is_root = True
            for cand_b in sorted(candidates):
                if cand_a == cand_b: continue
                
                # THÊM MỚI: Log thông tin chi tiết nếu cờ được bật
                if is_logging:
                    deps_of_b = transitive_deps.get(cand_b, set())
                    # logging.info(f"  Checking if '{cand_a}' is root against '{cand_b}':")
                    # logging.info(f"    cand_a = '{cand_a}'")
                    # logging.info(f"    cand_b = '{cand_b}'")
                    # logging.info(f"    transitive_deps của cand_b: {deps_of_b}")
                    # print(f"  Checking if '{cand_a}' is root against '{cand_b}':")
                    # print(f"    cand_a = '{cand_a}'")
                    # print(f"    cand_b = '{cand_b}'")
                    # print(f"    transitive_deps của cand_b: {deps_of_b}")
                
                if cand_a not in transitive_deps.get(cand_b, set()):
                    is_root = False
                    if is_logging:
                        logging.info(f"    -> RESULT: '{cand_a}' is NOT in deps of '{cand_b}'. '{cand_a}' cannot be the root. Breaking inner loop.")
                        print(f"    -> RESULT: '{cand_a}' is NOT in deps of '{cand_b}'. '{cand_a}' cannot be the root. Breaking inner loop.")
                    break
                else:
                    if is_logging:
                        logging.info(f"    -> RESULT: '{cand_a}' IS in deps of '{cand_b}'. Check continues.")
                        print(f"    -> RESULT: '{cand_a}' IS in deps of '{cand_b}'. Check continues.")

            if is_root:
                if is_logging:
                    logging.info(f"  -> SUCCESS: '{cand_a}' is the root module for '{model_name}'. Breaking outer loop.")
                    print(f"  -> SUCCESS: '{cand_a}' is the root module for '{model_name}'. Breaking outer loop.")                    
                root_module = cand_a
                break
        
        base_module_map[model_name] = root_module if root_module else sorted(candidates)[0]

    # Bước 4: Áp dụng vào master_models
    for model_name, data in master_models.items():
        if model_name in base_module_map:
            data['base_module'] = base_module_map[model_name]

    return master_models

def analyze_odoo_sources(args):
    global master_models
    master_models = {}
    
    logging.info("Phase 1: Analyzing Odoo source directories...")
    module_infos = {}
    all_module_names = set()
    all_parsed_files = []

    # BƯỚC 1: Quét và thu thập tất cả dữ liệu thô
    for path_str in args.source_dirs:
        current_path = Path(path_str)
        if not current_path.is_dir():
            logging.warning(f"Skipping invalid source: {current_path}")
            continue
        
        logging.info(f"--- Recursively scanning directory: {current_path} ---")
        for manifest_path in sorted(current_path.glob('**/__manifest__.py')):
            module_dir, module_name = manifest_path.parent, manifest_path.parent.name
            if module_name.endswith(('_test', '_tests')) or 'overwrite_' in str(manifest_path):
                continue
            if module_name.startswith(('test_', 'tests_mail', 'l10n_')) or 'overwrite_' in str(manifest_path):
                continue
            
            all_module_names.add(module_name)
            try:
                manifest_data = ast.literal_eval(manifest_path.read_text(encoding='utf-8'))
                module_infos[module_name] = {
                    'depends': manifest_data.get('depends', []),
                    'category': manifest_data.get('category', ''),
                    'models': set()
                }
            except Exception as e:
                logging.warning(f"Could not read manifest for {module_name}: {e}")
                module_infos[module_name] = {'depends': [], 'category': '', 'models': set()}

            logging.info(f"  Processing module: {module_name}")
            models_path = module_dir / 'models'
            if models_path.is_dir():
                for model_file in sorted(models_path.glob('**/*.py')):
                    if model_file.name == '__init__.py':
                        continue
                    try:
                        source_code = model_file.read_text(encoding='utf-8')
                        visitor = OdooModelVisitor(source_code, str(model_file))
                        visitor.visit(ast.parse(source_code))
                        if visitor.found_models:
                            all_parsed_files.append({'module_name': module_name, 'models': visitor.found_models})
                            for info in visitor.found_models:
                                if info.get('name'):
                                    module_infos[module_name]['models'].add(info['name'])
                    except Exception as e:
                        logging.error(f"Error parsing file {model_file.name}: {e}")

    for module_data in module_infos.values():
        module_data['models'] = sorted(list(module_data['models']))

    # BƯỚC 2: Tổng hợp dữ liệu ban đầu
    all_model_names_from_parsing = set()
    for parsed_file in all_parsed_files:
        for info in parsed_file['models']:
            if info.get('name'): all_model_names_from_parsing.add(info['name'])
            for inherited in info.get('inherits', []): all_model_names_from_parsing.add(inherited)
    
    for model_name in all_model_names_from_parsing:
        master_models[model_name] = {'fields': {}, 'methods': {}, 'source_modules': set(), 'base_classes': set(), 'delegated_inherits': [], 'inherited_mixins': set(), 'table_name': None, 'is_auto': True}

    for parsed_file in all_parsed_files:
        module_name = parsed_file['module_name']
        for info in parsed_file['models']:
            target_model_names = set(info.get('inherits', []))
            if info.get('name'): target_model_names.add(info.get('name'))
            for target_model_name in target_model_names:
                if target_model_name in master_models:
                    # Luôn cập nhật các thuộc tính này, không phụ thuộc vào _name
                    master_models[target_model_name]['is_transient'] = info['is_transient']
                    master_models[target_model_name]['is_auto'] = info['is_auto']
                    if info.get('table_name'):
                         master_models[target_model_name]['table_name'] = info['table_name']

                    master_models[target_model_name]['fields'].update(info['fields'])
                    master_models[target_model_name]['delegated_inherits'].extend(info.get('delegated_inherits', []))
                    master_models[target_model_name]['source_modules'].add(module_name)
                    master_models[target_model_name]['base_classes'].update(info.get('base_classes', []))
                    master_models[target_model_name]['inherited_mixins'].update(info.get('inherits', []))
                    for method_name, method_data in info['methods'].items():
                        method_data['module'] = module_name
                        master_models[target_model_name].setdefault('all_methods', {}).setdefault(method_name, []).append(method_data)

    # BƯỚC 3: Xác định Mixin TRƯỚC KHI KẾ THỪA
    auto_detected_mixins = set()
    for parsed_file in all_parsed_files:
        for info in parsed_file['models']:
            model_odoo_name = info.get('name')
            if model_odoo_name and (info.get('is_abstract') or model_odoo_name.endswith('.mixin')):
                auto_detected_mixins.add(model_odoo_name)
    manual_excluded_models = set(args.exclude_models or [])
    final_exclude_set = auto_detected_mixins.union(manual_excluded_models)

    # Thêm model gốc ảo
    master_models['models.Model'] = {'fields': COMMON_ODOO_FIELDS.copy(), 'methods': {}, 'base_classes': set(), 'inherited_mixins': set()}

    # BƯỚC 4: Phân giải kế thừa đệ quy
    resolved_models = set()
    def resolve_inheritance(model_name):
        if model_name in resolved_models or model_name not in master_models: return
        resolved_models.add(model_name)
        
        data = master_models[model_name]
        parents_to_resolve = data.get('base_classes', set()).union(data.get('inherited_mixins', set()))
        
        for parent_name in parents_to_resolve:
            resolve_inheritance(parent_name)
            
            parent_data = master_models.get(parent_name, {})
            # Chỉ trộn fields nếu cha không phải là mixin (và không phải models.Model)
            if parent_name not in final_exclude_set or parent_name == 'models.Model':
                merged_fields = parent_data.get('fields', {}).copy()
                merged_fields.update(data.get('fields', {}))
                data['fields'] = merged_fields
            
            # Chỉ trộn methods nếu cha không phải là mixin (và không phải models.Model)
            if parent_name not in final_exclude_set or parent_name == 'models.Model':
                merged_methods = parent_data.get('all_methods', {}).copy()
                merged_methods.update(data.get('all_methods', {}))
                data['all_methods'] = merged_methods

    for model_name in list(master_models.keys()):
        if model_name not in final_exclude_set:
            resolve_inheritance(model_name)
        
    # BƯỚC 5: Xác định module gốc
    master_models = _resolve_base_modules(master_models, module_infos, all_parsed_files, all_module_names)

    return {
        "master_models": master_models,
        "module_infos": module_infos,
        "all_module_names": all_module_names,
        "final_exclude_set": final_exclude_set
    }

def generate_csharp_files(args, master_models, module_infos, all_module_names, final_exclude_set):
    output_path, project_base_name = Path(args.output_dir), args.project_name
    
    flat_structure_args = args.flat_structure if args.flat_structure is not None else []
    if 'all' in flat_structure_args:
        flat_model_dir, flat_service_dir, flat_controller_dir = True, True, True
    elif 'none' in flat_structure_args:
        flat_model_dir, flat_service_dir, flat_controller_dir = False, False, False
    else:
        flat_model_dir = 'model' in flat_structure_args
        flat_service_dir = 'service' in flat_structure_args
        flat_controller_dir = 'controller' in flat_structure_args
        
    flat_namespace_args = args.flat_namespace if args.flat_namespace is not None else []
    if 'all' in flat_namespace_args:
        flat_model_ns, flat_service_ns, flat_controller_ns = True, True, True
    elif 'none' in flat_namespace_args:
        flat_model_ns, flat_service_ns, flat_controller_ns = False, False, False
    else:
        flat_model_ns = 'model' in flat_namespace_args
        flat_service_ns = 'service' in flat_namespace_args
        flat_controller_ns = 'controller' in flat_namespace_args
        
    logging.info(f"Final mixin/exclusion list: {final_exclude_set}")
    
    all_csharp_model_names = {to_pascal_case(model_name) for model_name in master_models.keys()}
    all_csharp_module_names = {to_pascal_case(module_name) for module_name in all_module_names}
    conflicting_names = all_csharp_model_names.intersection(all_csharp_module_names)
    module_namespace_map = {}
    for module_name in all_module_names:
        pascal_module = to_pascal_case(module_name)
        if pascal_module in conflicting_names:
            module_namespace_map[module_name] = f"{pascal_module}Module"
            logging.warning(f"Global name collision for '{module_name}'. Its namespace will be '{pascal_module}Module'.")
        else:
            module_namespace_map[module_name] = pascal_module
    
    all_csharp_entity_names = {to_pascal_case(model_name) for model_name in master_models.keys() if model_name not in final_exclude_set}
    
    logging.info("\nPhase 2: Generating C# source code for ABP Framework...")
    
    attr_dir = output_path / f"src/{project_base_name}.Domain.Shared/Attributes"
    attr_dir.mkdir(parents=True, exist_ok=True)
    attribute_definitions = {
        "ModuleAttribute.cs": """
            [AttributeUsage(AttributeTargets.Class)]
            public class ModuleAttribute : Attribute
            {
                public string Name { get; }
                public string[] Depends { get; }
                public ModuleAttribute(string name, params string[] depends)
                {
                    Name = name;
                    Depends = depends;
                }
            }
        """,
        "ModelAttribute.cs": """
            [AttributeUsage(AttributeTargets.Class)]
            public class ModelAttribute : Attribute
            {
                public string Name { get; set; }
                public string Description { get; set; }
                public bool IsTransient { get; set; }
                public bool IsAuto { get; set; } = true;
                public ModelAttribute(string name)
                {
                    Name = name;
                }
            }
        """,
        "OdooFieldAttribute.cs": """
            [AttributeUsage(AttributeTargets.Property)]
            public class OdooFieldAttribute : Attribute 
            { 
                public string? String { get; set; }
                public string? Help { get; set; }
                public bool? Required { get; set; }
                public bool? Readonly { get; set; }
                public bool? Index { get; set; }
                public bool? Store { get; set; }
                public bool? Copy { get; set; }
                public bool? Translate { get; set; }
                public bool? Sparse { get; set; }
                public bool? CompanyDependent { get; set; }
                public int? Digits { get; set; }
                public bool? Attatchment { get; set; }
                public string? ComodelName { get; set; }
                public string[] Groups { get; set; }
            }
        """,
        "JsonFieldAttribute.cs": """
            [AttributeUsage(AttributeTargets.Property)]
            public class JsonFieldAttribute : Attribute 
            { 
                public bool IsSparse { get; set; } = false;
            }
        """,
        "Many2oneAttribute.cs": """
        [AttributeUsage(AttributeTargets.Property)]
        public class Many2oneAttribute : Attribute 
        { 
            public string RelatedModel { get; set; } 
        }""",
        "One2manyAttribute.cs": """
        [AttributeUsage(AttributeTargets.Property)]
        public class One2manyAttribute : Attribute
        { 
            public string RelatedModel { get; set; }
            public string InverseField { get; set; } 
        }""",
        "Many2manyAttribute.cs": """
        [AttributeUsage(AttributeTargets.Property)]
        public class Many2manyAttribute : Attribute
        { 
            public string RelatedModel { get; set; }
        }""",
    }
    for file_name, class_def in attribute_definitions.items():
        (attr_dir / file_name).write_text(format_csharp_code(f"using System;\nnamespace {project_base_name}.Domain.Shared.Attributes; {class_def}"), encoding='utf-8')
    
    marker_interface_dir = output_path / f"src/{project_base_name}.Domain.Shared/Interfaces/Markers"
    data_interface_dir = output_path / f"src/{project_base_name}.Domain/MixinData"
    mixin_contracts_dir = output_path / f"src/{project_base_name}.Application.Contracts/Interfaces/Mixins"
    mixin_service_dir = output_path / f"src/{project_base_name}.Application/Services/Mixins"
    for d in [marker_interface_dir, data_interface_dir, mixin_contracts_dir, mixin_service_dir]:
        d.mkdir(parents=True, exist_ok=True)
    
    (mixin_contracts_dir / "IMixinAppService.cs").write_text(format_csharp_code(f"using Volo.Abp.Application.Services;\nnamespace {project_base_name}.Application.Contracts.Interfaces.Mixins; public interface IMixinAppService : IApplicationService {{ }}"), encoding='utf-8')
    
    ef_core_path = output_path / f"src/{project_base_name}.EntityFrameworkCore"
    fluent_api_dir = ef_core_path / "Configurations"
    fluent_api_dir.mkdir(parents=True, exist_ok=True)
    
    all_model_configs = []
    
    for model_name, data in master_models.items():
        if model_name == 'models.Model' or 'base_module' not in data: continue

        is_auto = data.get('is_auto', True)
        if not is_auto:
             logging.info(f"DEBUG GENERATOR: Processing model '{model_name}' with is_auto = {is_auto}")

        base_module = data.get('base_module', "unknown")
        dependencies = module_infos.get(base_module, {}).get('depends', [])
        module_category = module_infos.get(base_module, {}).get('category', '')
        pascal_model = to_pascal_case(model_name)
        
        if model_name in final_exclude_set:
            logging.info(f"Generating dedicated service and interfaces for mixin model: '{model_name}'")
            all_methods = data.get('all_methods', {})
            (marker_interface_dir / f"I{pascal_model}able.cs").write_text(create_marker_interface_content(project_base_name, model_name), encoding='utf-8')
            if data.get('fields'):
                (data_interface_dir / f"I{pascal_model}Data.cs").write_text(create_mixin_data_interface_content(project_base_name, model_name, data, all_csharp_entity_names, flat_model_dir, module_namespace_map), encoding='utf-8')
            (mixin_contracts_dir / f"I{pascal_model}AppService.cs").write_text(create_service_interface_content(project_base_name, base_module, model_name, data, all_methods, flat_model_dir, True, all_csharp_entity_names, module_namespace_map, is_mixin=True), encoding='utf-8')
            (mixin_service_dir / f"{pascal_model}AppService.cs").write_text(create_service_implementation_content(project_base_name, base_module, model_name, data, all_methods, dependencies, flat_model_dir, True, args.include_private_methods, all_csharp_entity_names, is_mixin=True, inherited_mixins=None, final_exclude_set=final_exclude_set, module_namespace_map=module_namespace_map), encoding='utf-8')
            continue

        logging.info(f"Generating ABP structure for model '{model_name}' (base module: {base_module})")
        
        pascal_module_for_ns = module_namespace_map.get(base_module, to_pascal_case(base_module))

        domain_path = output_path / f"src/{project_base_name}.Domain"
        app_contracts_path = output_path / f"src/{project_base_name}.Application.Contracts"
        app_path = output_path / f"src/{project_base_name}.Application"
        http_api_path = output_path / f"src/{project_base_name}.HttpApi"
        
        entity_dir = (domain_path / 'Models') if flat_model_dir else (domain_path / 'Entities' / pascal_module_for_ns)
        enum_dir = (domain_path / 'Models' / 'Enums') if flat_model_dir else (domain_path / 'Enums' / pascal_module_for_ns)
        interface_dir = (app_contracts_path / 'Interfaces') if flat_service_dir else (app_contracts_path / 'Interfaces' / pascal_module_for_ns)
        service_dir = (app_path / 'Services') if flat_service_dir else (app_path / 'Services' / pascal_module_for_ns)
        controller_dir = (http_api_path / 'Controllers') if flat_controller_dir else (http_api_path / 'Controllers' / pascal_module_for_ns)
        
        for d in [enum_dir, entity_dir, interface_dir, service_dir, controller_dir]:
            d.mkdir(parents=True, exist_ok=True)
        
        implemented_interfaces = [f"I{to_pascal_case(mixin)}able" for mixin in data.get('inherited_mixins', set()) if mixin in final_exclude_set]
        (entity_dir / f"{pascal_model}.cs").write_text(create_model_entity_content(project_base_name, base_module, model_name, data, dependencies, flat_model_ns, implemented_interfaces, args.entity_property_order, module_namespace_map), encoding='utf-8')
        
        computed_fields = {}
        for field_name, field_data in data['fields'].items():
            if field_data.get('type', '').lower() == 'selection' and 'selection' in field_data:
                enum_filename = f"{to_pascal_case(model_name.split('.')[-1])}{to_pascal_case(field_name)}Enum.cs"
                (enum_dir / enum_filename).write_text(create_enum_content(project_base_name, base_module, model_name, field_name, field_data['selection'], flat_model_ns, module_namespace_map), encoding='utf-8')
            elif field_data.get('type') == 'Computed':
                computed_fields[field_name] = field_data.get('compute')
        
        if computed_fields:
            (entity_dir / f"{pascal_model}.Partials.cs").write_text(create_partial_model_content(project_base_name, base_module, model_name, computed_fields, data.get('all_methods', {}), flat_model_ns, module_namespace_map), encoding='utf-8')        
        
        all_methods = data.get('all_methods', {})
        public_methods = {k: v for k, v in all_methods.items() if not k.startswith('_')}
        
        has_specific_logic = False
        if public_methods:
            for method_name, implementations in public_methods.items():
                is_common = method_name.lower() in ODOO_COMMON_API_METHODS
                is_override = len(implementations) > 1 or (len(implementations) == 1 and implementations[0]['module'] != data.get('base_module'))
                if not is_common or is_override:
                    has_specific_logic = True
                    break
        
        should_generate_service = (args.generate_services == 'all') or (args.generate_services == 'specific' and has_specific_logic)
        should_generate_controller = False
        if args.generate_controllers == 'all':
            should_generate_controller = True
        elif args.generate_controllers == 'specific' and has_specific_logic:
            should_generate_controller = True
        
        if should_generate_service:
            logging.info(f"  -> Generating AppService for '{model_name}'.")
            (interface_dir / f"I{pascal_model}AppService.cs").write_text(create_service_interface_content(project_base_name, pascal_module_for_ns, model_name, data, public_methods, flat_model_ns, flat_service_ns, all_csharp_entity_names, module_namespace_map), encoding='utf-8')
            (service_dir / f"{pascal_model}AppService.cs").write_text(create_service_implementation_content(project_base_name, pascal_module_for_ns, model_name, data, all_methods, dependencies, flat_model_ns, flat_service_ns, args.include_private_methods, all_csharp_entity_names, is_mixin=False, inherited_mixins=data.get('inherited_mixins', set()), final_exclude_set=final_exclude_set, module_namespace_map=module_namespace_map), encoding='utf-8')
        
        if should_generate_controller:
            logging.info(f"  -> Generating Controller for '{model_name}'.")

            # TẠO THƯ MỤC DTO
            dtos_dir = app_contracts_path / 'DTOs' / ('' if flat_service_dir else pascal_module_for_ns)
            dtos_dir.mkdir(parents=True, exist_ok=True)

            # TẠO FILE DTO
            dtos_content = create_dtos_content(project_base_name, base_module, model_name, public_methods, flat_model_ns, flat_service_ns, all_csharp_entity_names, module_namespace_map)
            if dtos_content:
                (dtos_dir / f"{pascal_model}Dtos.cs").write_text(dtos_content, encoding='utf-8')

            # TẠO FILE CONTROLLER
            main_controller, partial_controller = create_controller_content(project_base_name, base_module, module_category, model_name, data, public_methods, flat_model_ns, flat_service_ns, flat_controller_ns, args.add_common_actions, all_csharp_entity_names, args.group_by_category, module_namespace_map)
            (controller_dir / f"{pascal_model}Controller.cs").write_text(main_controller, encoding='utf-8')
            if partial_controller:
                (controller_dir / f"{pascal_model}Controller.Partials.cs").write_text(partial_controller, encoding='utf-8')
        
        fluent_content = create_fluent_api_configuration_content(project_base_name, model_name, data, flat_model_ns, module_namespace_map)
        (fluent_api_dir / f"{pascal_model}Configuration.cs").write_text(fluent_content, encoding='utf-8')
        all_model_configs.append(pascal_model)

        # Sinh mã cho Repository tùy chỉnh nếu _auto = False
        if not is_auto:
            logging.info(f"  -> Generating custom Read-Only Repository for '{model_name}'.")
            print(f"DEBUG GENERATOR:  -> Generating custom Read-Only Repository for '{model_name}'.")
            
            repo_interface_dir = domain_path / "Repositories"
            repo_impl_dir = ef_core_path / "Repositories"
            repo_interface_dir.mkdir(parents=True, exist_ok=True)
            repo_impl_dir.mkdir(parents=True, exist_ok=True)

            (repo_interface_dir / f"I{pascal_model}Repository.cs").write_text(
                create_readonly_repository_interface_content(project_base_name, model_name, flat_model_ns, module_namespace_map),
                encoding='utf-8'
            )
            (repo_impl_dir / f"EfCore{pascal_model}Repository.cs").write_text(
                create_readonly_repository_implementation_content(project_base_name, model_name, flat_model_ns, module_namespace_map),
                encoding='utf-8'
            )

    model_builder_ext_content = f"""
    using Microsoft.EntityFrameworkCore;

    namespace {project_base_name}.EntityFrameworkCore
    {{
        public static partial class ModelBuilderExtensions
        {{
            public static void Configure{project_base_name.replace(".", "")}(this ModelBuilder builder)
            {{
    """
    for pascal_model in sorted(all_model_configs):
        model_builder_ext_content += f"                builder.Configure{pascal_model}();\n"
    model_builder_ext_content += "            }\n        }\n    }"
    
    (ef_core_path / f"{project_base_name}DbContextModelCreatingExtensions.cs").write_text(format_csharp_code(model_builder_ext_content), encoding='utf-8')

    logging.info("\nPhase 3: Cleaning up empty directories...")
    cleanup_empty_dirs(output_path)
    logging.info("\nGeneration complete!")

# --- HÀM CHÍNH ĐIỀU PHỐI ---
def main(args):
    manual_excluded_models = set(args.exclude_models or [])
    
    # Phần 1: Đọc file, tổng hợp và phân tích dữ liệu
    analysis_result = analyze_odoo_sources(args)
    
    # Phần 2: Tạo các content
    generate_csharp_files(args, **analysis_result)
    
if __name__ == '__main__':
    parser = argparse.ArgumentParser(
        description="Odoo to C# ABP Framework Scaffolding Code Generator.",
        formatter_class=argparse.RawTextHelpFormatter
    )
    
    # --- Input/Output Arguments ---
    parser.add_argument('-s', '--source-dirs', nargs='+', required=True,
                        help="A list of source directories to scan.\n"
                             "Example: -s \"C:/odoo/addons\" \"C:/odoo/custom_addons\"")
    parser.add_argument('-o', '--output-dir', type=str, required=True,
                        help="The root output directory for the generated C# solution.\n"
                             "Example: -o \"./BambooProject\"")
    parser.add_argument('-p', '--project-name', type=str, default="Bamboo.Core",
                        help="The C# base project name, used for generating namespaces.\n"
                             "Default: \"Bamboo.Core\"")

    # --- Generation Control Arguments ---
    parser.add_argument('--generate-services', type=str, choices=['all', 'specific'], default='specific',
                        help="Control service generation.\n"
                             "- 'specific': (Default) Generate services only for models with specific actions/overrides.\n"
                             "- 'all': Generate services for all models.")
    
    parser.add_argument('--generate-controllers', type=str, choices=['all', 'specific', 'none'], default='specific',
                        help="Control controller generation.\n"
                             "- 'specific': (Default) Generate controllers only for models with specific actions/overrides.\n"
                             "- 'all': Generate controllers for all models.\n"
                             "- 'none': Do not generate any specific controllers.")

    parser.add_argument('--add-common-actions', action='store_true',
                        help="If generating controllers, this makes them inherit from GenericController to include common CRUD actions.\n"
                             "If not set, they inherit from AbpControllerBase.")

    parser.add_argument('--group-by-category', action='store_true',
                        help="Group controller routes by the module's category (from __manifest__.py).")

    parser.add_argument('--include-private-methods', action='store_true',
                        help="Generate skeletons for private/protected helper methods inside AppServices.")

    # --- Structure & Filtering Arguments ---
    parser.add_argument('--flat-structure', nargs='+', default=['model'], choices=['all', 'none', 'model', 'service', 'controller'],
                        help="Flatten directory/namespace for specified layers.\n"
                             "- 'model': (Default) Flat for Domain layer.\n"
                             "- 'service': Flat for Application layer.\n"
                             "- 'controller': Flat for HttpApi layer.\n"
                             "- 'all': Flat for all layers.\n"
                             "- 'none': No flattening, use module subdirectories for all.")
    
    parser.add_argument('--flat-namespace', nargs='+', default=['model'], choices=['all', 'none', 'model', 'service', 'controller'],
                        help="Flatten C# namespace for specified layers (e.g., ...Interfaces, ...Services).\n"
                             "- 'model': (Default) Flat namespaces for Domain layer.\n"
                             "- 'service': Flat namespaces for Application layer.\n"
                             "- 'controller': Flat namespaces for HttpApi layer.\n"
                             "- 'all': Flat namespaces for all layers.\n"
                             "- 'none': No flattening, use module namespaces for all.")
    
    parser.add_argument('--entity-property-order', type=str, choices=['type', 'abc'], default='abc',
                        help="Control property order in generated Entities.\n"
                             "- 'type': (Default) Group by type (Primitives, M2O, O2M, etc.).\n"
                             "- 'abc': Sort all properties alphabetically.")
    
    #parser.add_argument('--exclude-models', nargs='*', default=['mail.activity.mixin', 'portal.mixin', 'format.address.mixin', 'utm.source.mixin', 'utm.test.source.mixin', 'website.cover_properties.mixin', 'website.multi.mixin', 'website.published.mixin', 'website.published.multi.mixin','website.searchable.mixin', 'purchase.bill.line.match'],
    #                    help="Manually specify a list of models to exclude.\n"
    #                         "Note: AbstractModels are already detected automatically.")
    
    parser.add_argument('--exclude-models', nargs='*', default=['format.address.mixin', 'mail.activity.mixin', 'portal.mixin', 'utm.source.mixin', 'utm.test.source.mixin', 'website.cover_properties.mixin', 'website.multi.mixin', 'website.published.mixin', 'website.published.multi.mixin','website.searchable.mixin', 'transifex.code.translation', 'test.translation.import.model1', 'ir.actions.actions', 'ir.actions.report', 'l10n_ar_partner_tax'],
                        help="Manually specify a list of models to exclude.\n"
                             "Note: AbstractModels are already detected automatically.")
    
    parser.add_argument('--generate-fluent-api', action='store_true',
                        help="Generate fluent api for models.")    
    args = parser.parse_args()
    main(args)