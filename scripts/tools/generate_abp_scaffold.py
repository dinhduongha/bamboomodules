import os
import ast
import inspect
import argparse
import logging
from pathlib import Path
import re

# --- Configuration and Helper Functions ---
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')
CSHARP_KEYWORDS = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "async", "await", "by", "descending", "dynamic", "equals", "from", "get", "global", "group", "into", "join", "let", "nameof", "on", "orderby", "partial", "remove", "select", "set", "value", "var", "when", "where", "yield" }
ODOO_COMMON_API_METHODS = {'create', 'write', 'read', 'unlink', 'search', 'search_read', 'name_get', 'name_search', 'copy', 'default_get', 'fields_get', 'onchange', 'name_create', 'read_group', 'check_access_rights', 'check_access_rule', 'check_field_access_rights'}
PYTHON_TO_CSHARP_TYPE_MAP = { 'str': 'string', 'int': 'int', 'float': 'float', 'bool': 'bool', 'dict': 'Dictionary<string, object>', 'list': 'List<object>', 'tuple': 'object', 'datetime': 'DateTime', 'date': 'DateTime', 'any': 'object', 'object': 'object' }
ODOO_TO_CSHARP_TYPE = { 'char': 'string', 'text': 'string', 'html': 'string', 'integer': 'int', 'float': 'double', 'monetary': 'decimal', 'boolean': 'bool', 'date': 'DateTime', 'datetime': 'DateTime', 'binary': 'byte[]' }

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
                logging.info(f"  Cleaning up empty directory: {dirpath}")
                os.rmdir(dirpath)
            except OSError as e:
                logging.error(f"Error removing directory {dirpath}: {e}")

def map_python_type_to_csharp(py_type_str, all_csharp_entity_names, param_name=""):
    if not py_type_str: return "object"
    if py_type_str == "TEntity": return "TEntity"
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
    logging.warning(f"Unrecognized type hint '{py_type_str}' for parameter '{param_name}'. Falling back to 'object'.")
    return "object"

# --- C# Content Generation Functions ---
def create_model_entity_content(project_name, module_name, model_name, model_data, dependencies, flat_model_dir, implemented_interfaces, property_order, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module_original = to_pascal_case(module_name)
    pascal_module = module_namespace_map.get(module_name, pascal_module_original)
    
    table_name = model_name.replace('.', '_')
    depends_str = f"Depends = new[] {{ {', '.join(f'\"{dep}\"' for dep in dependencies)} }}" if dependencies else ""
    is_transient = model_data.get('is_transient', False)
    attributes = [f'[Module("{module_name}"{(", " + depends_str) if depends_str else ""})]', f'[Model("{model_name}", IsTransient = {str(is_transient).lower()})]', f'[Table("{table_name}")]']
    namespace = f"{project_name}.Models" if flat_model_dir else f"{project_name}.Domain.Entities.{pascal_module}"
    inheritance = f": IEntity<Guid>{', ' + ', '.join(sorted(implemented_interfaces)) if implemented_interfaces else ''}"
    content = f"""
    // Auto-generated by Odoo C# Code Generator
    using System; using System.Collections.Generic; using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema; using Volo.Abp.Domain.Entities;
    using {project_name}.Domain.Shared.Attributes; using {project_name}.Domain.Shared.Interfaces;
    namespace {namespace}
    {{
        {'\n        '.join(attributes)}
        public partial class {pascal_model} {inheritance}
        {{
            [Key] public Guid Id {{ get; set; }}
    """

    def generate_property(field_name, field_info):
        prop_content = ""
        field_type = field_info['type'].lower()
        if field_type in ODOO_TO_CSHARP_TYPE:
            pascal_field = to_pascal_case(field_name)
            csharp_type = ODOO_TO_CSHARP_TYPE[field_type]
            is_required = field_info.get('is_required', False)
            if not is_required and '?' not in csharp_type: csharp_type += '?'
            attr_lines = ['[Required]' if is_required else '']
            if field_info.get('is_translatable'):
                attr_lines.append(f'[JsonField]')
                attr_lines.append(f'[Column("{field_name}", TypeName = "jsonb")]')
            else:
                attr_lines.append(f'[Column("{field_name}")]')
            prop_content += '\n            ' + '\n            '.join(filter(None, attr_lines))
            prop_content += f'\n            public {csharp_type} {pascal_field} {{ get; set; }}\n'
        elif field_type == 'many2one' and 'related_model' in field_info:
            fk_property_name, nav_property_name = to_pascal_case(field_name), to_pascal_case(field_name.removesuffix('_id'))
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_content += f"""
            [Column("{field_name}")] public Guid? {fk_property_name} {{ get; set; }}
            [Many2one(RelatedModel = "{field_info['related_model']}")]
            [ForeignKey(nameof({fk_property_name}))]
            public virtual {related_model_pascal}? {nav_property_name} {{ get; set; }}
            """
        elif field_type == 'one2many' and 'related_model' in field_info and 'inverse_field' in field_info:
            pascal_field, related_model_pascal = to_pascal_case(field_name), to_pascal_case(field_info['related_model'])
            prop_content += f"""
            [One2many(RelatedModel = "{field_info['related_model']}", InverseField = "{field_info['inverse_field']}")]
            public virtual ICollection<{related_model_pascal}>? {pascal_field} {{ get; set; }}
            """
        elif field_type == 'many2many' and 'related_model' in field_info:
            pascal_field, related_model_pascal = to_pascal_case(field_name), to_pascal_case(field_info['related_model'])
            prop_content += f"""
            [Many2many(RelatedModel = "{field_info['related_model']}")]
            public virtual ICollection<{related_model_pascal}>? {pascal_field} {{ get; set; }}
            """
        return prop_content

    if property_order == 'abc':
        content += "\n            //<editor-fold desc=\"PROPERTIES (Sorted alphabetically)\">\n"
        all_fields_sorted = sorted(model_data['fields'].items())
        all_delegates_sorted = sorted(model_data.get('delegated_inherits', []))
        for field_name, field_info in all_fields_sorted:
            if field_info.get('type') == 'Computed': continue
            content += generate_property(field_name, field_info)
        if all_delegates_sorted:
            for delegated_model, fk_field in all_delegates_sorted:
                fk_property_name, nav_property_name = to_pascal_case(fk_field), to_pascal_case(delegated_model)
                content += f"""
                [Column("{fk_field}")]
                public Guid? {fk_property_name} {{ get; set; }}
                [ForeignKey(nameof({fk_property_name}))]
                public virtual {nav_property_name}? {nav_property_name}_Proxy {{ get; set; }}
                """
        content += "            //</editor-fold>\n"
    else:
        content += "\n            //<editor-fold desc=\"PRIMITIVE PROPERTIES\">\n"
        for field_name, field_info in sorted(model_data['fields'].items()):
            if field_info.get('type').lower() in ODOO_TO_CSHARP_TYPE:
                content += generate_property(field_name, field_info)
        content += "            //</editor-fold>\n"
        if 'delegated_inherits' in model_data and model_data['delegated_inherits']:
            content += "\n            //<editor-fold desc=\"DELEGATION INHERITANCE (ONE-TO-ONE)\">\n"
            for delegated_model, fk_field in sorted(model_data['delegated_inherits']):
                fk_property_name, nav_property_name = to_pascal_case(fk_field), to_pascal_case(delegated_model)
                content += f"""
                [Column("{fk_field}")]
                public Guid? {fk_property_name} {{ get; set; }}
                [ForeignKey(nameof({fk_property_name}))]
                public virtual {nav_property_name}? {nav_property_name}_Proxy {{ get; set; }}
                """
            content += "            //</editor-fold>\n"
        content += "\n            //<editor-fold desc=\"NAVIGATION PROPERTIES (MANY-TO-ONE)\">\n"
        for field_name, field_info in sorted(model_data['fields'].items()):
            if field_info.get('type').lower() == 'many2one':
                content += generate_property(field_name, field_info)
        content += "            //</editor-fold>\n"
        content += "\n            //<editor-fold desc=\"NAVIGATION PROPERTIES (ONE-TO-MANY)\">\n"
        for field_name, field_info in sorted(model_data['fields'].items()):
            if field_info.get('type').lower() == 'one2many':
                content += generate_property(field_name, field_info)
        content += "            //</editor-fold>\n"
        content += "\n            //<editor-fold desc=\"NAVIGATION PROPERTIES (MANY-TO-MANY)\">\n"
        for field_name, field_info in sorted(model_data['fields'].items()):
            if field_info.get('type').lower() == 'many2many':
                content += generate_property(field_name, field_info)
        content += "            //</editor-fold>\n"
    
    content += "        }\n    }"
    return format_csharp_code(content)

def create_enum_content(project_base_name, module_name, model_name, field_name, selection_list, flat_model_dir, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module_original = to_pascal_case(module_name)
    pascal_module = module_namespace_map.get(module_name, pascal_module_original)

    model_alias = to_pascal_case(model_name.split('.')[-1]); pascal_field = to_pascal_case(field_name)
    enum_name = f"{model_alias}{pascal_field}Enum"
    namespace = f"{project_base_name}.Models.Enums" if flat_model_dir else f"{project_base_name}.Domain.Enums.{pascal_module}"
    content = f"namespace {namespace}\n{{\n    public enum {enum_name}\n    {{\n"
    for value, _ in selection_list:
        clean_value = str(value)
        member_name = sanitize_csharp_identifier(to_pascal_case(clean_value))
        if clean_value.isdigit(): content += f"        {member_name} = {clean_value},\n"
        else: content += f"        {member_name},\n"
    content += "    }\n}"
    return format_csharp_code(content)

def create_partial_model_content(project_base_name, module_name, model_name, computed_fields, all_methods_source, flat_model_dir, module_namespace_map):
    pascal_model_original = to_pascal_case(model_name)
    pascal_module_original = to_pascal_case(module_name)
    
    pascal_model = f"{pascal_model_original}Model" if pascal_model_original == module_namespace_map.get(module_name) and not flat_model_dir else pascal_model_original
    pascal_module = module_namespace_map.get(module_name, pascal_module_original)
    
    namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
    content = f"""
    using System; using System.ComponentModel.DataAnnotations.Schema; using {project_base_name}.Domain.Shared.Attributes;
    namespace {namespace}
    {{
        public partial class {pascal_model}
        {{
    """
    for field_name, compute_method_name in sorted(computed_fields.items()):
        pascal_field = to_pascal_case(field_name)
        compute_source = all_methods_source.get(compute_method_name, f"# Source for '{compute_method_name}' not found.")
        content += f"""
            [NotMapped]
            public object {pascal_field} 
            {{ 
                get
                {{
                    /*
                    --- ODOO COMPUTE METHOD SOURCE ---
{compute_source}
                    */
                    return default;
                }}
            }}
        """
    content += "    }\n}"
    return format_csharp_code(content)

def create_service_interface_content(project_base_name, module_name, model_name, methods, flat_model_dir, flat_namespace, all_csharp_entity_names, module_namespace_map, is_mixin=False):
    pascal_model = to_pascal_case(model_name)
    pascal_module_original = to_pascal_case(module_name)
    pascal_module = module_namespace_map.get(module_name, pascal_module_original)

    interface_name = f"I{pascal_model}AppService"
    contracts_namespace = f"{project_base_name}.Application.Contracts.Interfaces"
    interface_namespace = contracts_namespace + (".Mixins" if is_mixin else (f".{pascal_module}" if not flat_namespace else ""))
    
    using_statements = ["using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Threading.Tasks;", "using Volo.Abp.Application.Services;"]
    
    if is_mixin:
        base_interface = "IMixinAppService"
        using_statements.extend([f"using {project_base_name}.Domain.Shared.Interfaces;", "using Volo.Abp.Domain.Entities;"])
        using_statements.append(f"using {contracts_namespace}.Mixins;")
    else:
        entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
        base_interface = f"IGenericApplicationService<{pascal_model}>"
        using_statements.extend([f"using {entity_namespace};", f"using {project_base_name}.Application.Contracts;"])
    
    content = f"""
    // Auto-generated by Odoo C# Code Generator
    {'\n'.join(sorted(list(set(using_statements))))}
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
            csharp_name = to_pascal_case(method_name.replace("action_", "")) + "Async"
        
        if csharp_name:
            sorted_method_info.append({'csharp_name': csharp_name, 'method_name': method_name, 'implementations': implementations})
    
    sorted_method_info.sort(key=lambda x: x['csharp_name'])

    for item in sorted_method_info:
        service_method_name, implementations = item['csharp_name'], item['implementations']
        last_impl = implementations[-1]; params = last_impl.get('params', []); 
        is_instance_method = last_impl.get('is_instance_method', True)
        
        return_type_py = last_impl.get('return_type')
        if is_mixin and is_instance_method:
            if return_type_py == 'self':
                return_type_str = "TEntity"
            else:
                return_type_str = return_type_py or "TEntity" # Mặc định trả về TEntity
        else:
            return_type_str = return_type_py or (pascal_model if not is_mixin else "object")

        param_parts = [f"{map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)} @{p_name}" if p_name in CSHARP_KEYWORDS else f"{map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)} {p_name}" for p_name, p_type in params]
        
        generic_part, generic_constraint, param_str = "", "", ""
        if is_mixin and is_instance_method:
            generic_part = "<TEntity>"
            param_str = ", ".join([f"IEnumerable<TEntity> entities"] + param_parts)
            generic_constraint = f" where TEntity : IEntity<Guid>, I{pascal_model}able"
        elif not is_mixin:
            param_str = ", ".join([f"Guid id"] + param_parts)
        else: # Mixin static method
            param_str = ", ".join(param_parts)
        
        return_type = f"Task<{map_python_type_to_csharp(return_type_str, all_csharp_entity_names)}>" if return_type_str != "void" else "Task"

        content += f"        {return_type} {service_method_name}{generic_part}({param_str}){generic_constraint};\n"
        
    content += "    }\n}"
    return format_csharp_code(content)

def create_service_implementation_content(project_base_name, module_name, model_name, methods, dependencies, flat_model_dir, flat_namespace, include_private, all_csharp_entity_names, is_mixin, inherited_mixins, final_exclude_set, module_namespace_map):
    pascal_model = to_pascal_case(model_name)
    pascal_module_original = to_pascal_case(module_name)
    pascal_module = module_namespace_map.get(module_name, pascal_module_original)
    
    service_name, interface_name = f"{pascal_model}AppService", f"I{pascal_model}AppService"
    depends_list_str = ', '.join(f'\"{dep}\"' for dep in dependencies)
    depends_str = f"Depends = new[] {{ {depends_list_str} }}" if dependencies else ""
    contracts_namespace = f"{project_base_name}.Application.Contracts.Interfaces"
    interface_namespace = contracts_namespace + (".Mixins" if is_mixin else (f".{pascal_module}" if not flat_namespace else ""))
    service_namespace = f"{project_base_name}.Application.Services" + (".Mixins" if is_mixin else (f".{pascal_module}" if not flat_namespace else ""))
    
    using_statements = ["using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Threading.Tasks;", f"using {project_base_name}.Domain.Shared.Attributes;", f"using {interface_namespace};"]
    
    private_fields, constructor_assignments = [], []

    if is_mixin:
        base_class, constructor_params, base_call = "ApplicationService", [], ""
        using_statements.extend(["using Volo.Abp.Application.Services;", f"using {project_base_name}.Domain.Shared.Interfaces;", "using Volo.Abp.Domain.Entities;"])
    else:
        base_class = f"GenericApplicationService<{pascal_model}>"
        base_constructor_params_str = "repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache"
        constructor_params = [f"IRepository<{pascal_model}, Guid> repository", "IServiceProvider serviceProvider", "AuthorizationService authorizationService", "DomainParser domainParser", "IModelTypeRegistry modelTypeRegistry", "IDataFilter dataFilter", "IObjectMapper objectMapper", "IMemoryCache memoryCache"]
        base_call = f": base({base_constructor_params_str})"
        entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
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
        is_instance_method = implementations[-1].get('is_instance_method', True)
        is_public = not method_name.startswith('_')
        is_common_method = method_name.lower() in ODOO_COMMON_API_METHODS

        if is_mixin:
            if is_instance_method:
                visibility = "public"
            elif is_public:
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
            param_str = ", ".join([f"Guid id"] + param_parts)
        else:
            param_str = ", ".join(param_parts)

        if is_common_method and 'override' in visibility:
            if method_name.lower() == 'write': param_str, return_type, base_call_params = f"List<Guid> ids, {pascal_model} entity, List<string> fields", "Task<List<object>>", "ids, entity, fields"
            elif method_name.lower() == 'create': param_str, return_type, base_call_params = f"{pascal_model} entity, List<string> fields", "Task<object>", "entity, fields"
            elif method_name.lower() == 'copy': param_str, return_type, base_call_params = f"Guid id, List<string> fields, {pascal_model} defaultValues = null", "Task<object>", "id, fields, defaultValues"
            else:
                final_return_type = return_type_str_py or (pascal_model if not is_mixin else "object")
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
            method_body.append(f"            --- ODOO METHOD SOURCE FROM MODULE: {impl['module']} ({tag}) ---")
            for line in source_code.split('\n'): method_body.append(f"            // {line}")
        method_body.append(f"            {comment_wrapper[1]}")
        
        if is_common_method and 'override' in visibility and not is_mixin: method_body.append(f"            return await base.{service_method_name}({base_call_params});")
        elif "Task<" in return_type and 'public' in visibility and not is_mixin: method_body.append(f"            var entity = await Repository.GetAsync(id); return entity;")
        elif "Task<" in return_type: method_body.append(f"            return default;")
        else: method_body.append(f"            await Task.CompletedTask;")
        method_body.append("        }")
        content_parts.extend(method_body)
    content_parts.extend(["    }", "}"])
    return "\n".join(content_parts)

def create_controller_content(project_base_name, module_name, module_category, model_name, methods, flat_model_dir, flat_service_dir, flat_controller_dir, add_common_actions, all_csharp_entity_names, group_by_category, module_namespace_map):
    pascal_model_original = to_pascal_case(model_name)
    pascal_module_original = to_pascal_case(module_name)
    pascal_module = module_namespace_map.get(module_name, pascal_module_original)

    pascal_model = f"{pascal_model_original}Model" if pascal_model_original == pascal_module and not flat_model_dir else pascal_model_original

    controller_name, interface_name = f"{pascal_model}Controller", f"I{pascal_model}AppService"
    entity_namespace = f"{project_base_name}.Models" if flat_model_dir else f"{project_base_name}.Domain.Entities.{pascal_module}"
    interface_namespace = f"{project_base_name}.Application.Contracts.Interfaces" + (f".{pascal_module}" if not flat_service_dir else "")
    controller_namespace = f"{project_base_name}.HttpApi.Controllers" + (f".{pascal_module}" if not flat_controller_dir else "")
    
    route_parts = ["api", "app"]
    if group_by_category and module_category:
        clean_category = module_category.split('/')[0].strip().lower().replace(' ', '-')
        if clean_category:
            route_parts.append(clean_category)
    route_parts.append(model_name.replace('_','-'))
    route = f'[Route("{'/'.join(route_parts)}")]'
    
    if add_common_actions:
        base_class = f"GenericController<{pascal_model}, {interface_name}>"
        using_statements = {f"using {project_base_name}.HttpApi.Controllers.Commons;"}
        constructor_body = f"public {controller_name}({interface_name} service) : base(service) {{ }}"
    else:
        base_class = "AbpControllerBase"
        using_statements = set()
        constructor_body = f"private readonly {interface_name} _appService;\n        public {controller_name}({interface_name} appService) {{ _appService = appService; }}"
    
    using_statements.update(["using System;", "using System.Threading.Tasks;", "using Microsoft.AspNetCore.Mvc;", "using Volo.Abp.AspNetCore.Mvc;", f"using {interface_namespace};"])
    
    main_content = f"""
    // Auto-generated by Odoo C# Code Generator
    {'\n'.join(sorted(list(using_statements)))}
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
        partial_using = { "using System;", "using System.Threading.Tasks;", "using Microsoft.AspNetCore.Mvc;", "using System.Text.Json;", f"using {interface_namespace};", f"using {entity_namespace};" }
        partial_content = f"""
        // Auto-generated by Odoo C# Code Generator
        {'\n'.join(sorted(list(partial_using)))}
        namespace {controller_namespace}
        {{
            public partial class {controller_name}
            {{
        """
        service_accessor = "AppService" if add_common_actions else "_appService"
        
        sorted_actions = []
        for method_name, implementations in specific_actions.items():
            action_name = to_pascal_case(method_name.replace("action_", ""))
            sorted_actions.append({'csharp_name': action_name, 'python_name': method_name, 'implementations': implementations})
        sorted_actions.sort(key=lambda x: x['csharp_name'])

        for item in sorted_actions:
            action_name, method_name, implementations = item['csharp_name'], item['python_name'], item['implementations']
            last_impl = implementations[-1]
            params = last_impl.get('params', [])
            route_action = ''.join(['-' + c.lower() if c.isupper() else c for c in action_name]).strip('-')
            dto_name, action_params, service_call_params = f"{action_name}RequestDto", "Guid id", "id"
            if params:
                partial_content += f"        public class {dto_name}\n        {{\n"
                for p_name, p_type in params:
                    csharp_type = map_python_type_to_csharp(p_type, all_csharp_entity_names, p_name)
                    prop_name = to_pascal_case(p_name)
                    partial_content += f"            public {csharp_type} {prop_name} {{ get; set; }}\n"
                partial_content += "        }\n"
                action_params += f", [FromBody] {dto_name} input"
                service_call_params += ", " + ", ".join(f"input.{to_pascal_case(p_name)}" for p_name, _ in params)
            service_method_name = f"{action_name}Async"
            partial_content += f"""
                [HttpPost]
                [Route(\"{{id}}/{route_action}\")]
                public async Task<IActionResult> {action_name}Async({action_params})
                {{
                    var result = await {service_accessor}.{service_method_name}({service_call_params});
                    return Ok(result);
                }}
            """
        partial_content += "            }\n}"
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
    namespace = f"{project_name}.MixinData" # Namespace cố định

    # Tự động thêm các using statement cần thiết
    using_statements = {"using System;", "using System.Collections.Generic;", "using Volo.Abp.Domain.Entities;"}
    for field_info in model_data['fields'].values():
        if 'related_model' in field_info:
            related_model_name = field_info['related_model']
            related_model_base_module = master_models.get(related_model_name, {}).get('base_module')
            if related_model_base_module:
                pascal_related_module = module_namespace_map.get(related_model_base_module, to_pascal_case(related_model_base_module))
                entity_namespace = f"{project_name}.Models" if flat_model_dir else f"{project_name}.Domain.Entities.{pascal_related_module}"
                using_statements.add(f"using {entity_namespace};")

    content = f"""
    // Auto-generated Data Interface from Odoo Mixin {mixin_name}
    {'\n'.join(sorted(list(using_statements)))}

    namespace {namespace}
    {{
        public interface {interface_name} : IEntity<Guid>
        {{
    """
    
    # Logic tạo thuộc tính tương tự như trong create_model_entity_content
    for field_name, field_info in sorted(model_data['fields'].items()):
        field_type = field_info['type'].lower()
        prop_signature = ""
        
        if field_type in ODOO_TO_CSHARP_TYPE:
            pascal_field = to_pascal_case(field_name)
            csharp_type = ODOO_TO_CSHARP_TYPE[field_type]
            is_required = field_info.get('is_required', False)
            if not is_required and '?' not in csharp_type:
                csharp_type += '?'
            prop_signature = f"{csharp_type} {pascal_field} {{ get; set; }}"
            
        elif field_type == 'many2one' and 'related_model' in field_info:
            nav_property_name = to_pascal_case(field_name.removesuffix('_id'))
            related_model_pascal = to_pascal_case(field_info['related_model'])
            prop_signature = f"// Note: Foreign Key {to_pascal_case(field_name)} is defined in the implementing class\n        {related_model_pascal}? {nav_property_name} {{ get; set; }}"

        elif field_type in ['one2many', 'many2many'] and 'related_model' in field_info:
            pascal_field, related_model_pascal = to_pascal_case(field_name), to_pascal_case(field_info['related_model'])
            prop_signature = f"ICollection<{related_model_pascal}>? {pascal_field} {{ get; set; }}"

        if prop_signature:
            content += f"        {prop_signature}\n\n"

    content += "    }\n}"
    return format_csharp_code(content)
#</editor-fold>

#<editor-fold desc="Odoo AST Visitor">
class OdooModelVisitor(ast.NodeVisitor):
    def __init__(self, source_code):
        self.model_info = {'name': None, 'inherits': [], 'fields': {}, 'methods': {}, 'is_transient': False, 'is_abstract': False, 'base_classes': [], 'delegated_inherits': []}
        self.full_source_text = source_code

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
        if self.model_info['name'] or self.model_info['inherits']: return
        for base in node.bases:
            if isinstance(base, ast.Attribute) and hasattr(base, "value") and hasattr(base.value, "id"):
                base_name = f"{base.value.id}.{base.attr}"
                self.model_info['base_classes'].append(base_name)
                if base_name == 'models.AbstractModel': self.model_info['is_abstract'] = True
                if base_name == 'models.TransientModel': self.model_info['is_transient'] = True
        for item in node.body:
            if isinstance(item, ast.Assign):
                for target in item.targets:
                    if isinstance(target, ast.Name):
                        if target.id == '_name' and isinstance(item.value, ast.Constant): self.model_info['name'] = item.value.value
                        elif target.id == '_inherit':
                            if isinstance(item.value, ast.Constant): self.model_info['inherits'].append(item.value.value)
                            elif isinstance(item.value, (ast.List, ast.Tuple)):
                                for elt in item.value.elts:
                                    if isinstance(elt, ast.Constant): self.model_info['inherits'].append(elt.value)
                        elif target.id == '_inherits' and isinstance(item.value, ast.Dict):
                            for key_node, val_node in zip(item.value.keys, item.value.values):
                                if isinstance(key_node, ast.Constant) and isinstance(val_node, ast.Constant):
                                    self.model_info['delegated_inherits'].append((key_node.value, val_node.value))
        if self.model_info['name'] or self.model_info['inherits']: self.generic_visit(node)

    def visit_Assign(self, node):
        if not (len(node.targets) == 1 and isinstance(node.targets[0], ast.Name) and isinstance(node.value, ast.Call)): return
        field_name = node.targets[0].id; call = node.value
        if not (isinstance(call.func, ast.Attribute) and hasattr(call.func.value, 'id') and call.func.value.id == 'fields'): return
        field_type = call.func.attr; field_data = {'type': field_type}
        
        is_required = False
        for kw in call.keywords:
            if kw.arg == 'required' and isinstance(kw.value, ast.Constant) and kw.value.value is True: is_required = True; break
        field_data['is_required'] = is_required
        
        for kw in call.keywords:
            if kw.arg == 'translate' and isinstance(kw.value, ast.Constant) and kw.value.value is True: field_data['is_translatable'] = True; break
        
        for kw in call.keywords:
            if kw.arg == 'compute' and isinstance(kw.value, ast.Constant): field_data['type'] = 'Computed'; field_data['compute'] = kw.value.value
        
        if field_type.lower() in ['many2one', 'one2many', 'many2many']:
            related_model = None
            if call.args and isinstance(call.args[0], ast.Constant): related_model = call.args[0].value
            else:
                for kw in call.keywords:
                    if kw.arg == 'comodel_name' and isinstance(kw.value, ast.Constant): related_model = kw.value.value; break
            
            if related_model: field_data['related_model'] = related_model
            else: 
                logging.warning(f"Could not determine related model for field '{field_name}'. Skipping relation attributes.")
                self.model_info['fields'][field_name] = field_data
                return
            
            if field_type.lower() == 'one2many':
                inverse_field = None
                if len(call.args) > 1 and isinstance(call.args[1], ast.Constant): inverse_field = call.args[1].value
                else:
                    for kw in call.keywords:
                        if kw.arg == 'inverse_name' and isinstance(kw.value, ast.Constant): inverse_field = kw.value.value; break
                if inverse_field: field_data['inverse_field'] = inverse_field
        
        if field_type.lower() == 'selection':
            selection_list = []
            for kw in call.keywords:
                if kw.arg == 'selection' and isinstance(kw.value, ast.List):
                    for elt in kw.value.elts:
                        if isinstance(elt, (ast.Tuple, ast.List)) and len(elt.elts) == 2 and all(isinstance(e, ast.Constant) for e in elt.elts):
                            selection_list.append((elt.elts[0].value, elt.elts[1].value))
            if selection_list: field_data['selection'] = selection_list
            
        self.model_info['fields'][field_name] = field_data

    def visit_FunctionDef(self, node):
        method_name = node.name
        
        is_instance_method = len(node.args.args) > 0 and node.args.args[0].arg == 'self'
        params = [(arg.arg, self._get_type_hint_str(arg.annotation) or "object") for arg in node.args.args[1:]]
        return_type_str = self._get_type_hint_str(node.returns)
        
        source_code = ""
        try: source_code = ast.get_source_segment(self.full_source_text, node)
        except:
            try: source_code = inspect.getsource(node)
            except: source_code = f"# Could not retrieve source code for {method_name}"
        
        method_data = {'params': params, 'source': inspect.cleandoc(source_code or ""), 'is_instance_method': is_instance_method}
        if return_type_str: method_data['return_type'] = return_type_str
        
        self.model_info['methods'][method_name] = method_data
#</editor-fold>

# --- HÀM CHÍNH ĐIỀU PHỐI ---
def main(args):
    global master_models
    master_models = {}
    auto_detected_mixins = set()
    manual_excluded_models = set(args.exclude_models or [])
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
        
    flat_namespace = args.flat_namespace

    logging.info("Phase 1: Analyzing Odoo source directories...")
    module_infos = {}
    all_module_names = set()
    for path_str in args.source_dirs:
        current_path = Path(path_str)
        if not current_path.is_dir():
            logging.warning(f"Skipping invalid source: {current_path}")
            continue
        
        logging.info(f"--- Recursively scanning directory: {current_path} ---")
        for manifest_path in sorted(current_path.glob('**/__manifest__.py')):
            module_dir, module_name = manifest_path.parent, manifest_path.parent.name
            if module_name.endswith(('_test', '_tests')):
                continue
            
            all_module_names.add(module_name)
            try:
                manifest_data = ast.literal_eval(manifest_path.read_text(encoding='utf-8'))
                module_infos[module_name] = {
                    'depends': manifest_data.get('depends', []),
                    'category': manifest_data.get('category', '')
                }
            except Exception as e:
                logging.warning(f"Could not read manifest for {module_name}: {e}")
                module_infos[module_name] = {'depends': [], 'category': ''}

            logging.info(f"  Processing module: {module_name}")
            models_path = module_dir / 'models'
            if models_path.is_dir():
                for model_file in sorted(models_path.glob('**/*.py')):
                    if model_file.name == '__init__.py':
                        continue
                    try:
                        source_code = model_file.read_text(encoding='utf-8')
                        visitor = OdooModelVisitor(source_code)
                        visitor.visit(ast.parse(source_code))
                        info = visitor.model_info
                        
                        if info.get('is_abstract') and info.get('name'):
                            auto_detected_mixins.add(info['name'])

                        target_model_names = [m for m in info.get('inherits', [])]
                        base_module_info = {}
                        if info.get('name'):
                            target_model_names.append(info['name'])
                            base_module_info[info['name']] = (module_name, info['is_transient'])

                        for model_name in set(target_model_names):
                            if model_name not in master_models:
                                master_models[model_name] = {'fields': {}, 'methods': {}, 'all_methods_source': {}, 'source_modules': set(), 'inherited_mixins': set(), 'delegated_inherits': []}
                            
                            if model_name in base_module_info:
                                master_models[model_name]['base_module'] = base_module_info[model_name][0]
                                master_models[model_name]['is_transient'] = base_module_info[model_name][1]

                            master_models[model_name]['fields'].update(info['fields'])
                            master_models[model_name]['delegated_inherits'].extend(info.get('delegated_inherits', []))
                            all_inherits = set(info.get('inherits', []) + [b.replace('models.', '') for b in info.get('base_classes', []) if b != 'models.Model'])
                            master_models[model_name]['inherited_mixins'].update(all_inherits)
                            
                            for method_name, method_data in info['methods'].items():
                                master_models[model_name]['all_methods_source'][method_name] = method_data['source']
                                method_data['module'] = module_name
                                master_models[model_name].setdefault('all_methods', {}).setdefault(method_name, []).append(method_data)
                            master_models[model_name]['source_modules'].add(module_name)
                    except Exception as e:
                        logging.error(f"Error processing file {model_file.name}: {e}")
    
    final_exclude_set = auto_detected_mixins.union(manual_excluded_models)
    logging.info(f"Final mixin/exclusion list (auto + manual): {final_exclude_set}")
    
    all_csharp_model_names = {to_pascal_case(model_name) for model_name in master_models.keys()}
    all_csharp_module_names = {to_pascal_case(module_name) for module_name in all_module_names}
    
    conflicting_names = all_csharp_model_names.intersection(all_csharp_module_names)
    module_namespace_map = {}
    for module_name in all_module_names:
        pascal_module = to_pascal_case(module_name)
        if pascal_module in conflicting_names:
            module_namespace_map[module_name] = f"{pascal_module}s"
            logging.warning(f"Global name collision for '{module_name}'. Its namespace will be '{pascal_module}s'.")
        else:
            module_namespace_map[module_name] = pascal_module
            
    all_csharp_entity_names = {to_pascal_case(model_name) for model_name in master_models.keys() if model_name not in final_exclude_set}
    
    logging.info("\nPhase 2: Generating C# source code for ABP Framework...")
    
    attr_dir = output_path / f"src/{project_base_name}.Domain.Shared/Attributes"
    attr_dir.mkdir(parents=True, exist_ok=True)
    attribute_definitions = {
        "ModuleAttribute.cs": "[AttributeUsage(AttributeTargets.Class)] public class ModuleAttribute : Attribute { public string Name { get; } public string[] Depends { get; } public ModuleAttribute(string name, params string[] depends) { Name = name; Depends = depends; } }",
        "ModelAttribute.cs": "[AttributeUsage(AttributeTargets.Class)] public class ModelAttribute : Attribute { public string Name { get; set; } public bool IsTransient { get; set; } public ModelAttribute(string name) { Name = name; } }",
        "JsonFieldAttribute.cs": "[AttributeUsage(AttributeTargets.Property)] public class JsonFieldAttribute : Attribute {}",
        "Many2oneAttribute.cs": "[AttributeUsage(AttributeTargets.Property)] public class Many2oneAttribute : Attribute { public string RelatedModel { get; set; } }",
        "One2manyAttribute.cs": "[AttributeUsage(AttributeTargets.Property)] public class One2manyAttribute : Attribute { public string RelatedModel { get; set; } public string InverseField { get; set; } }",
        "Many2manyAttribute.cs": "[AttributeUsage(AttributeTargets.Property)] public class Many2manyAttribute : Attribute { public string RelatedModel { get; set; } }",
    }
    for file_name, class_def in attribute_definitions.items():
        (attr_dir / file_name).write_text(format_csharp_code(f"namespace {project_base_name}.Domain.Shared.Attributes; {class_def}"), encoding='utf-8')
    
    marker_interface_dir = output_path / f"src/{project_base_name}.Domain.Shared/Interfaces/Markers"
    data_interface_dir = output_path / f"src/{project_base_name}.Domain/MixinData"
    mixin_contracts_dir = output_path / f"src/{project_base_name}.Application.Contracts/Interfaces/Mixins"
    mixin_service_dir = output_path / f"src/{project_base_name}.Application/Services/Mixins"
    for d in [marker_interface_dir, data_interface_dir, mixin_contracts_dir, mixin_service_dir]:
        d.mkdir(parents=True, exist_ok=True)
    
    (mixin_contracts_dir / "IMixinAppService.cs").write_text(format_csharp_code(f"using Volo.Abp.Application.Services;\nnamespace {project_base_name}.Application.Contracts.Interfaces.Mixins; public interface IMixinAppService : IApplicationService {{ }}"), encoding='utf-8')
    
    for model_name, data in master_models.items():
        base_module = data.get('base_module', sorted(list(data['source_modules']))[0] if data['source_modules'] else "unknown")
        dependencies = module_infos.get(base_module, {}).get('depends', [])
        module_category = module_infos.get(base_module, {}).get('category', '')
        pascal_model = to_pascal_case(model_name)
        
        if model_name in final_exclude_set:
            logging.info(f"Generating dedicated service and interfaces for mixin model: '{model_name}'")
            all_methods = data.get('all_methods', {})
            (marker_interface_dir / f"I{pascal_model}able.cs").write_text(create_marker_interface_content(project_base_name, model_name), encoding='utf-8')
            if data.get('fields'):
                (data_interface_dir / f"I{pascal_model}Data.cs").write_text(create_mixin_data_interface_content(project_base_name, model_name, data, all_csharp_entity_names, flat_model_dir, module_namespace_map), encoding='utf-8')
            (mixin_contracts_dir / f"I{pascal_model}AppService.cs").write_text(create_service_interface_content(project_base_name, base_module, model_name, all_methods, flat_model_dir, True, all_csharp_entity_names, module_namespace_map, is_mixin=True), encoding='utf-8')
            (mixin_service_dir / f"{pascal_model}AppService.cs").write_text(create_service_implementation_content(project_base_name, base_module, model_name, all_methods, dependencies, flat_model_dir, True, args.include_private_methods, all_csharp_entity_names, is_mixin=True, inherited_mixins=None, final_exclude_set=final_exclude_set, module_namespace_map=module_namespace_map), encoding='utf-8')
            continue

        logging.info(f"Generating ABP structure for model '{model_name}' (base module: {base_module})")
        
        pascal_module = module_namespace_map.get(base_module, to_pascal_case(base_module))

        domain_path = output_path / f"src/{project_base_name}.Domain"
        app_contracts_path = output_path / f"src/{project_base_name}.Application.Contracts"
        app_path = output_path / f"src/{project_base_name}.Application"
        http_api_path = output_path / f"src/{project_base_name}.HttpApi"
        
        entity_dir = (domain_path / 'Models') if flat_model_dir else (domain_path / 'Entities' / pascal_module)
        enum_dir = (domain_path / 'Models' / 'Enums') if flat_model_dir else (domain_path / 'Enums' / pascal_module)
        interface_dir = (app_contracts_path / 'Interfaces') if flat_service_dir else (app_contracts_path / 'Interfaces' / pascal_module)
        service_dir = (app_path / 'Services') if flat_service_dir else (app_path / 'Services' / pascal_module)
        controller_dir = (http_api_path / 'Controllers') if flat_controller_dir else (http_api_path / 'Controllers' / pascal_module)
        
        for d in [enum_dir, entity_dir, interface_dir, service_dir, controller_dir]:
            d.mkdir(parents=True, exist_ok=True)
        
        implemented_interfaces = [f"I{to_pascal_case(mixin)}able" for mixin in data.get('inherited_mixins', set()) if mixin in final_exclude_set]
        (entity_dir / f"{pascal_model}.cs").write_text(create_model_entity_content(project_base_name, base_module, model_name, data, dependencies, flat_model_dir, implemented_interfaces, args.entity_property_order, module_namespace_map), encoding='utf-8')
        
        computed_fields = {}
        for field_name, field_data in data['fields'].items():
            if field_data.get('type', '').lower() == 'selection' and 'selection' in field_data:
                enum_filename = f"{to_pascal_case(model_name.split('.')[-1])}{to_pascal_case(field_name)}Enum.cs"
                (enum_dir / enum_filename).write_text(create_enum_content(project_base_name, pascal_module, model_name, field_name, field_data['selection'], flat_model_dir, module_namespace_map), encoding='utf-8')
            elif field_data.get('type') == 'Computed':
                computed_fields[field_name] = field_data.get('compute')
        
        if computed_fields:
            (entity_dir / f"{pascal_model}.Partials.cs").write_text(create_partial_model_content(project_base_name, pascal_module, model_name, computed_fields, data.get('all_methods_source', {}), flat_model_dir, module_namespace_map), encoding='utf-8')
        
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
            (interface_dir / f"I{pascal_model}AppService.cs").write_text(create_service_interface_content(project_base_name, pascal_module, model_name, public_methods, flat_model_dir, flat_namespace, all_csharp_entity_names, module_namespace_map), encoding='utf-8')
            (service_dir / f"{pascal_model}AppService.cs").write_text(create_service_implementation_content(project_base_name, pascal_module, model_name, all_methods, dependencies, flat_model_dir, flat_namespace, args.include_private_methods, all_csharp_entity_names, is_mixin=False, inherited_mixins=data.get('inherited_mixins', set()), final_exclude_set=final_exclude_set, module_namespace_map=module_namespace_map), encoding='utf-8')
        
        if should_generate_controller:
            logging.info(f"  -> Generating Controller for '{model_name}'.")
            main_controller, partial_controller = create_controller_content(project_base_name, pascal_module, module_category, model_name, public_methods, flat_model_dir, flat_service_dir, flat_controller_dir, args.add_common_actions, all_csharp_entity_names, args.group_by_category, module_namespace_map)
            (controller_dir / f"{pascal_model}Controller.cs").write_text(main_controller, encoding='utf-8')
            if partial_controller:
                (controller_dir / f"{pascal_model}Controller.Partials.cs").write_text(partial_controller, encoding='utf-8')
            
    logging.info("\nPhase 3: Cleaning up empty directories...")
    cleanup_empty_dirs(output_path)
    
    logging.info("\nGeneration complete!")
    
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

    parser.add_argument('--flat-namespace', action='store_true',
                        help="Generate Interfaces/Services/Controllers in flat namespaces (e.g., ...Interfaces, ...Services).")
    
    parser.add_argument('--entity-property-order', type=str, choices=['type', 'abc'], default='abc',
                        help="Control property order in generated Entities.\n"
                             "- 'type': (Default) Group by type (Primitives, M2O, O2M, etc.).\n"
                             "- 'abc': Sort all properties alphabetically.")
    
    #parser.add_argument('--exclude-models', nargs='*', default=['mail.activity.mixin', 'portal.mixin', 'format.address.mixin', 'utm.source.mixin', 'utm.test.source.mixin', 'website.cover_properties.mixin', 'website.multi.mixin', 'website.published.mixin', 'website.published.multi.mixin','website.searchable.mixin'],
    #                    help="Manually specify a list of models to exclude.\n"
    #                         "Note: AbstractModels are already detected automatically.")
    
    parser.add_argument('--exclude-models', nargs='*', default=['format.address.mixin', 'mail.activity.mixin', 'portal.mixin', 'utm.source.mixin', 'utm.test.source.mixin', 'website.cover_properties.mixin', 'website.multi.mixin', 'website.published.mixin', 'website.published.multi.mixin','website.searchable.mixin', 'transifex.code.translation', 'test.translation.import.model1', 'ir.qweb.field.contact', 'publisher_warranty.contract', 'ir.actions.report'],
                        help="Manually specify a list of models to exclude.\n"
                             "Note: AbstractModels are already detected automatically.")
    
    args = parser.parse_args()
    main(args)