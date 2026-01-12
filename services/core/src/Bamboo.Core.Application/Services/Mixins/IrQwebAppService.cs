using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base", Category = "Base")]
    public class IrQwebAppService : ApplicationService, IIrQwebAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AdaptStyleBackgroundImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object atts, object url_adapter) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb.py) ---
            // def _adapt_style_background_image(self, atts, url_adapter):
            // if isinstance(atts.get('style'), str) and 'background-image' in atts['style']:
            //     atts['style'] = re_background_image.sub(lambda m: '%s%s' % (m[1], url_adapter(m[2])), atts['style'])
            // return atts
            */
            return default;
        }

        public async Task<TEntity> AppendTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object text, object compile_context) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _append_text(self, text, compile_context):
            // """ Add an item (converts to a string) to the list.
            //     This will be concatenated and added during a call to the
            //     `_flush_text` method. This makes it possible to return only one
            //     yield containing all the parts."""
            // compile_context['_text_concat'].append(self._compile_to_str(text))
            */
            return default;
        }

        public async Task<TEntity> CompileBoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attr, object @default) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_bool(self, attr, default=False):
            // """Convert the statements as a boolean."""
            // if attr:
            //     if attr is True:
            //         return True
            //     attr = attr.lower()
            //     if attr in ('false', '0'):
            //         return False
            //     elif attr in ('true', '1'):
            //         return True
            // return bool(default)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveAsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_as(self, el, compile_context, level):
            // """Compile `t-as` expressions into a python code as a list of strings.
            // 
            // This method only check if this attributes is on the same node of a
            //  `t-foreach` attribute.
            // """
            // if 't-foreach' not in el.attrib:
            //     raise SyntaxError("t-as must be on the same node of t-foreach")
            // return []
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveAttInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py) ---
            // def _compile_directive_att(self, el, compile_context, level):
            // if "raise_on_forbidden_code_for_model" in compile_context:
            //     if set(el.attrib) - {"t-out", "t-tag-open", "t-tag-close", "t-inner-content"}:
            //         raise PermissionError("This directive is not allowed for this rendering mode.")
            // return super()._compile_directive_att(el, compile_context, level)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_att(self, el, compile_context, level):
            // """ Compile the attributes of the given elements.
            // 
            // The compiled function will create the ``values['__qweb_attrs__']``
            // dictionary. Then the dictionary will be output.
            // 
            // 
            // The new namespaces of the current element.
            // 
            // The static attributes (not prefixed by ``t-``) are add to the
            // dictionary in first.
            // 
            // The dynamic attributes values will be add after. The dynamic
            // attributes has different origins.
            // 
            // - value from key equal to ``t-att``: python dictionary expression;
            // - value from keys that start with ``t-att-``: python expression;
            // - value from keys that start with ``t-attf-``: format string
            //     expression.
            // """
            // code = [indent_code("attrs = values['__qweb_attrs__'] = {}", level)]
            // 
            // # Compile the introduced new namespaces of the given element.
            // #
            // # Add the found new attributes into the `attrs` dictionary like
            // # the static attributes.
            // if el.nsmap:
            //     for ns_prefix, ns_definition in set(el.nsmap.items()) - set(compile_context['nsmap'].items()):
            //         key = 'xmlns'
            //         if ns_prefix is not None:
            //             key = f'xmlns:{ns_prefix}'
            //         code.append(indent_code(f'attrs[{key!r}] = {ns_definition!r}', level))
            // 
            // # Compile the static attributes of the given element.
            // #
            // # Etree will also remove the ns prefixes indirection in the
            // # attributes. As we only have the namespace definition, we'll use
            // # an nsmap where the keys are the definitions and the values the
            // # prefixes in order to get back the right prefix and restore it.
            // if any(not key.startswith('t-') for key in el.attrib):
            //     nsprefixmap = {v: k for k, v in chain(compile_context['nsmap'].items(), el.nsmap.items())}
            //     for key in list(el.attrib):
            //         if not key.startswith('t-'):
            //             value = el.attrib.pop(key)
            //             name = key.removesuffix(".translate")
            //             attrib_qname = etree.QName(name)
            //             if attrib_qname.namespace:
            //                 name = f'{nsprefixmap[attrib_qname.namespace]}:{attrib_qname.localname}'
            //             code.append(indent_code(f'attrs[{name!r}] = {value!r}', level))
            // 
            // # Compile the dynamic attributes of the given element. All
            // # attributes will be add to the ``attrs`` dictionary in the
            // # compiled function.
            // for key in list(el.attrib):
            //     if key.startswith('t-attf-'):
            //         value = el.attrib.pop(key)
            //         name = key[7:].removesuffix(".translate")
            //         code.append(indent_code(f"attrs[{name!r}] = {self._compile_format(value)}", level))
            //     elif key.startswith('t-att-'):
            //         value = el.attrib.pop(key)
            //         code.append(indent_code(f"attrs[{key[6:]!r}] = {self._compile_expr(value)}", level))
            //     elif key == 't-att':
            //         value = el.attrib.pop(key)
            //         code.append(indent_code(f"""
            //             atts_value = {self._compile_expr(value)}
            //             if isinstance(atts_value, dict):
            //                 attrs.update(atts_value)
            //             elif isinstance(atts_value, (list, tuple)) and not isinstance(atts_value[0], (list, tuple)):
            //                 attrs.update([atts_value])
            //             elif isinstance(atts_value, (list, tuple)):
            //                 attrs.update(dict(atts_value))
            //             """, level))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveCallAssetsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_call_assets(self, el, compile_context, level):
            // """ This special 't-call-assets' tag can be used in order to aggregate/minify javascript and css assets"""
            // if len(el) > 0:
            //     raise SyntaxError("t-call-assets cannot contain children nodes")
            // 
            // code = self._flush_text(compile_context, level)
            // xmlid = el.attrib.pop('t-call-assets')
            // css = self._compile_bool(el.attrib.pop('t-css', True))
            // js = self._compile_bool(el.attrib.pop('t-js', True))
            // # async_load support was removed
            // defer_load = self._compile_bool(el.attrib.pop('defer_load', False))
            // lazy_load = self._compile_bool(el.attrib.pop('lazy_load', False))
            // media = el.attrib.pop('media', False)
            // autoprefix = self._compile_bool(el.attrib.pop('t-autoprefix', False))
            // code.append(indent_code(f"""
            //     t_call_assets_nodes = self._get_asset_nodes(
            //         {xmlid!r},
            //         css={css},
            //         js={js},
            //         debug=values.get("debug"),
            //         defer_load={defer_load},
            //         lazy_load={lazy_load},
            //         media={media!r},
            //         autoprefix={autoprefix}
            //     )
            // """.strip(), level))
            // 
            // code.append(indent_code("""
            //     for index, (tagName, asset_attrs) in enumerate(t_call_assets_nodes):
            //         if index:
            //             yield '\\n        '
            //         yield '<'
            //         yield tagName
            // 
            //         attrs = self._post_processing_att(tagName, asset_attrs)
            //         for name, value in attrs.items():
            //             if value or isinstance(value, str):
            //                 yield f' {escape(str(name))}="{escape(str(value))}"'
            // 
            //         if tagName in VOID_ELEMENTS:
            //             yield '/>'
            //         else:
            //             yield '>'
            //             yield '</'
            //             yield tagName
            //             yield '>'
            //         """, level))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveCallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_call(self, el, compile_context, level):
            // """Compile `t-call` expressions into a python code as a list of
            // strings.
            // 
            // `t-call` allow formating string dynamic at rendering time.
            // Can use `t-options` used to call and render the sub-template at
            // rendering time.
            // The sub-template is called with a copy of the rendering values
            // dictionary. The dictionary contains the key 0 coming from the
            // compilation of the contents of this element
            // 
            // The code will contain the call of the template and a function from the
            // compilation of the content of this element.
            // """
            // expr = el.attrib.pop('t-call')
            // 
            // el_tag = etree.QName(el.tag).localname if el.nsmap else el.tag
            // if el_tag != 't':
            //     raise SyntaxError(f"t-call must be on a <t> element (actually on <{el_tag}>).")
            // 
            // if el.attrib.get('t-call-options'): # retro-compatibility
            //     el.attrib.set('t-options', el.attrib.pop('t-call-options'))
            // 
            // nsmap = compile_context.get('nsmap')
            // 
            // code = self._flush_text(compile_context, level, rstrip=el.tag.lower() == 't')
            // _ref, path, xml = compile_context['_qweb_error_path_xml']
            // 
            // # options
            // el.attrib.pop('t-consumed-options', None)
            // code.append(indent_code("t_call_options = values.pop('__qweb_options__', {})", level))
            // if nsmap:
            //     # update this dict with the current nsmap so that the callee know
            //     # if he outputting the xmlns attributes is relevenat or not
            //     nsmap = []
            //     for key, value in compile_context['nsmap'].items():
            //         if isinstance(key, str):
            //             nsmap.append(f'{key!r}:{value!r}')
            //         else:
            //             nsmap.append(f'None:{value!r}')
            //     code.append(indent_code(f"t_call_options.update(nsmap={{{', '.join(nsmap)}}})", level))
            // 
            // # values from content (t-out="0")
            // if bool(list(el) or el.text):
            //     is_deprecated_version = not any(not key.startswith('t-') for key in el.attrib) and any(n.attrib.get('t-set') for n in el)
            // 
            //     def_name = compile_context['make_name']('t_call')
            //     code_content = [f"def {def_name}(self, values):"]
            //     code_content.append(indent_code(f'# element: {path!r} , {xml!r}', 1))
            //     code_content.extend(self._compile_directive(el, compile_context, 'inner-content', 1))
            //     self._append_text('', compile_context)  # To ensure the template function is a generator and doesn't become a regular function
            //     code_content.extend(self._flush_text(compile_context, 1, rstrip=True))
            // 
            //     compile_context['template_functions'][def_name] = code_content
            // 
            //     code.append(indent_code(f"""
            //         t_call_content_values = values.copy()
            //         qwebContent = QwebContent(self, QwebCallParameters(self.env.context, {compile_context['ref']!r}, {def_name!r}, t_call_content_values, 'root', 'inner-content', (template_options['ref'], {path!r}, {xml!r})))
            //         t_call_values = {{ {T_CALL_SLOT}: qwebContent}}
            //     """, level))
            // 
            //     if is_deprecated_version:
            //         # force the loading of the content to get values from t-set
            //         code.append(indent_code(f"""
            //             str(qwebContent)
            //             new_values = {{k: v for k, v in t_call_content_values.items() if k != {T_CALL_SLOT} and k != '__qweb_attrs__' and values.get(k) is not v}}
            //             t_call_values.update(new_values)
            //         """, level))
            // else:
            //     code.append(indent_code(f"t_call_values = {{ {T_CALL_SLOT}: '' }}", level))
            // 
            // # args to values
            // for key in list(el.attrib):
            //     if key.endswith(('.f', '.translate')):
            //         name = key.removesuffix(".f").removesuffix(".translate")
            //         value = el.attrib.pop(key)
            //         code.append(indent_code(f"t_call_values[{name!r}] = {self._compile_format(value)}", level))
            //     elif not key.startswith('t-'):
            //         value = el.attrib.pop(key)
            //         code.append(indent_code(f"t_call_values[{key!r}] = {self._compile_expr(value)}", level))
            //     elif key == 't-args':
            //         value = el.attrib.pop(key)
            //         code.append(indent_code(f"""
            //             atts_value = {self._compile_expr(value)}
            //             if isinstance(atts_value, dict):
            //                 t_call_values.update(atts_value)
            //             elif isinstance(atts_value, (list, tuple)) and not isinstance(atts_value[0], (list, tuple)):
            //                 t_call_values.update([atts_value])
            //             elif isinstance(atts_value, (list, tuple)):
            //                 t_call_values.update(dict(atts_value))
            //             """, level))
            // 
            // template = expr if expr.isnumeric() else self._compile_format(expr)
            // 
            // # call
            // code.append(indent_code(f"""
            //     template = {template}
            //     """, level))
            // if '%' in template:
            //     code.append(indent_code("""
            //         if template.isnumeric():
            //             template = int(template)
            //         """, level))
            // 
            // code.append(indent_code(f"yield QwebCallParameters(t_call_options, template, None, t_call_values, True, 't-call', (template_options['ref'], {path!r}, {xml!r}))", level))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveConsumedOptionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_consumed_options(self, el, compile_context, level):
            // raise SyntaxError('the t-options must be on the same tag as a directive that consumes it (for example: t-out, t-field, t-call)')
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveDebugInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_debug(self, el, compile_context, level):
            // """Compile `t-debug` expressions into a python code as a list of
            // strings.
            // 
            // The code will contains the call to the debugger chosen from the valid
            // list.
            // """
            // debugger = el.attrib.pop('t-debug')
            // code = []
            // if compile_context.get('dev_mode'):
            //     code.append(indent_code(f"self._debug_trace({debugger!r}, values)", level))
            // else:
            //     _logger.warning("@t-debug in template is only available in qweb dev mode")
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveElifInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_elif(self, el, compile_context, level):
            // """Compile `t-elif` expressions into a python code as a list of
            // strings. This method is linked with the `t-if` directive.
            // 
            // Check if this directive is valide, the t-qweb-skip flag and call
            // `t-if` directive
            // """
            // if not el.attrib.pop('t-else-valid', None):
            //     raise SyntaxError("t-elif directive must be preceded by t-if or t-elif directive")
            // 
            // return self._compile_directive_if(el, compile_context, level)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveElseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_else(self, el, compile_context, level):
            // """Compile `t-else` expressions into a python code as a list of strings.
            // This method is linked with the `t-if` directive.
            // 
            // Check if this directive is valide and add the t-qweb-skip flag.
            // """
            // if not el.attrib.pop('t-else-valid', None):
            //     raise SyntaxError("t-elif directive must be preceded by t-if or t-elif directive")
            // el.attrib.pop('t-else')
            // return []
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveEscInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_esc(self, el, compile_context, level):
            // # deprecated use.
            // if compile_context.get('dev_mode'):
            //     _logger.warning(
            //         "Found deprecated directive @t-esc=%r in template %r. Replace by @t-out",
            //         el.get('t-esc'),
            //         compile_context.get('ref', '<unknown>'),
            //     )
            // return self._compile_directive_out(el, compile_context, level)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_field(self, el, compile_context, level):
            // """Compile ``t-field`` expressions into a python code as a list of
            // strings.
            // 
            // The compiled code will call ``_get_field`` method at rendering time
            // using the type of value supplied by the field. This behavior can be
            // changed with ``t-options-widget`` or ``t-options={'widget': ...}``.
            // 
            // The code will contain evalution and rendering of the compiled value
            // value from the record field. If the compiled value is None or False,
            // the tag is not added to the render
            // (Except if the widget forces rendering or there is default content.).
            // """
            // tagName = el.tag
            // assert tagName not in ("table", "tbody", "thead", "tfoot", "tr", "td",
            //                          "li", "ul", "ol", "dl", "dt", "dd"),\
            //     "QWeb widgets do not work correctly on %r elements" % tagName
            // assert tagName != 't',\
            //     "t-field can not be used on a t element, provide an actual HTML node"
            // assert "." in el.get('t-field'),\
            //     "t-field must have at least a dot like 'record.field_name'"
            // 
            // return self._compile_directive_out(el, compile_context, level)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveForeachInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_foreach(self, el, compile_context, level):
            // """Compile ``t-foreach`` expressions into a python code as a list of
            // strings.
            // 
            // * ``t-as`` is used to define the key name.
            // * ``t-foreach`` compiled value can be an iterable, an dictionary or a
            //   number.
            // 
            // The code will contain loop ``for`` that wrap the rest of the compiled
            // code of this element.
            // 
            // Some key into values dictionary are create automatically::
            // 
            //     *_size, *_index, *_value, *_first, *_last, *_odd, *_even, *_parity
            // """
            // expr_foreach = el.attrib.pop('t-foreach')
            // expr_as = el.attrib.pop('t-as')
            // 
            // if not expr_as:
            //     raise KeyError('t-as')
            // 
            // if not VARNAME_REGEXP.match(expr_as):
            //     raise ValueError(f'The varname {expr_as!r} can only contain alphanumeric characters and underscores.')
            // 
            // if el.tag.lower() == 't':
            //     self._rstrip_text(compile_context)
            // 
            // code = self._flush_text(compile_context, level)
            // 
            // content_foreach = (
            //     self._compile_directives(el, compile_context, level + 1) +
            //     self._flush_text(compile_context, level + 1, rstrip=True))
            // 
            // t_foreach = compile_context['make_name']('t_foreach')
            // size = compile_context['make_name']('size')
            // has_value = compile_context['make_name']('has_value')
            // 
            // if expr_foreach.isdigit():
            //     code.append(indent_code(f"""
            //         values[{expr_as + '_size'!r}] = {size} = {int(expr_foreach)}
            //         {t_foreach} = range({size})
            //         {has_value} = False
            //     """, level))
            // else:
            //     code.append(indent_code(f"""
            //         {t_foreach} = {self._compile_expr(expr_foreach)} or []
            //         if isinstance({t_foreach}, Sized):
            //             values[{expr_as + '_size'!r}] = {size} = len({t_foreach})
            //         elif ({t_foreach}).__class__ == int:
            //             values[{expr_as + '_size'!r}] = {size} = {t_foreach}
            //             {t_foreach} = range({size})
            //         else:
            //             {size} = None
            //         {has_value} = False
            //         if isinstance({t_foreach}, Mapping):
            //             {t_foreach} = {t_foreach}.items()
            //             {has_value} = True
            //     """, level))
            // 
            // code.append(indent_code(f"""
            //         for index, item in enumerate({t_foreach}):
            //             values[{expr_as + '_index'!r}] = index
            //             if {has_value}:
            //                 values[{expr_as!r}], values[{expr_as + '_value'!r}] = item
            //             else:
            //                 values[{expr_as!r}] = values[{expr_as + '_value'!r}] = item
            //             values[{expr_as + '_first'!r}] = values[{expr_as + '_index'!r}] == 0
            //             if {size} is not None:
            //                 values[{expr_as + '_last'!r}] = index + 1 == {size}
            //             values[{expr_as + '_odd'!r}] = index % 2
            //             values[{expr_as + '_even'!r}] = not values[{expr_as + '_odd'!r}]
            //             values[{expr_as + '_parity'!r}] = 'odd' if values[{expr_as + '_odd'!r}] else 'even'
            //     """, level))
            // 
            // code.extend(content_foreach or indent_code('continue', level + 1))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_groups(self, el, compile_context, level):
            // """Compile `t-groups` expressions into a python code as a list of
            // strings.
            // 
            // The code will contain the condition `if self.env.user.has_groups(groups)`
            // part that wrap the rest of the compiled code of this element.
            // """
            // groups = el.attrib.pop('t-groups', el.attrib.pop('groups', None))
            // 
            // strip = self._rstrip_text(compile_context)
            // code = self._flush_text(compile_context, level)
            // code.append(indent_code(f"if self.env.user.has_groups({groups!r}):", level))
            // if strip and el.tag.lower() != 't':
            //     self._append_text(strip, compile_context)
            // code.extend([
            //     *self._compile_directives(el, compile_context, level + 1),
            //     *self._flush_text(compile_context, level + 1, rstrip=True),
            // ] or [indent_code('pass', level + 1)])
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveIfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_if(self, el, compile_context, level):
            // """Compile `t-if` expressions into a python code as a list of strings.
            // 
            // The code will contain the condition `if`, `else` and `elif` part that
            // wrap the rest of the compiled code of this element.
            // """
            // expr = el.attrib.pop('t-if', el.attrib.pop('t-elif', None))
            // 
            // assert not expr.isspace(), 't-if or t-elif expression should not be empty.'
            // 
            // strip = self._rstrip_text(compile_context)  # the withspaces is visible only when display a content
            // if el.tag.lower() == 't' and el.text and LSTRIP_REGEXP.search(el.text):
            //     strip = ''  # remove technical spaces
            // code = self._flush_text(compile_context, level)
            // 
            // code.append(indent_code(f"if {self._compile_expr(expr)}:", level))
            // body = []
            // if strip:
            //     self._append_text(strip, compile_context)
            // body.extend(
            //     self._compile_directives(el, compile_context, level + 1) +
            //     self._flush_text(compile_context, level + 1, rstrip=True))
            // code.extend(body or [indent_code('pass', level + 1)])
            // 
            // # Look for the else or elif conditions
            // next_el = el.getnext()
            // comments_to_remove = []
            // while isinstance(next_el, etree._Comment):
            //     comments_to_remove.append(next_el)
            //     next_el = next_el.getnext()
            // 
            // # If there is a t-else directive, the comment nodes are deleted
            // # and the t-else or t-elif is validated.
            // if next_el is not None and {'t-else', 't-elif'} & set(next_el.attrib):
            //     # Insert a flag to allow t-else or t-elif rendering.
            //     next_el.attrib['t-else-valid'] = 'True'
            // 
            //     # remove comment node
            //     parent = el.getparent()
            //     for comment in comments_to_remove:
            //         parent.remove(comment)
            //     if el.tail and not el.tail.isspace():
            //         raise SyntaxError("Unexpected non-whitespace characters between t-if and t-else directives")
            //     el.tail = None
            // 
            //     # You have to render the `t-else` and `t-elif` here in order
            //     # to be able to put the log. Otherwise, the parent's
            //     # `t-inner-content`` directive will render the different
            //     # nodes without taking indentation into account such as:
            //     #    if (if_expression):
            //     #         content_if
            //     #    log ['last_path_node'] = path
            //     #    else:
            //     #       content_else
            // 
            //     code.append(indent_code("else:", level))
            //     body = []
            //     if strip:
            //         self._append_text(strip, compile_context)
            //     body.extend(
            //         self._compile_node(next_el, compile_context, level + 1)+
            //         self._flush_text(compile_context, level + 1, rstrip=True))
            //     code.extend(body or [indent_code('pass', level + 1)])
            // 
            //     # Insert a flag to avoid the t-else or t-elif rendering when
            //     # the parent t-inner-content dirrective compile his
            //     # children.
            //     next_el.attrib['t-qweb-skip'] = 'True'
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveInnerContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_inner_content(self, el, compile_context, level):
            // """Compiles the content of the element (is the technical `t-inner-content`
            // directive created by QWeb) into a python code as a list of
            // strings.
            // 
            // The code will contains the text content of the node or the compliled
            // code from the recursive call of ``_compile_node``.
            // """
            // el.attrib.pop('t-inner-content', None)
            // 
            // if el.nsmap:
            //     # Update the dict of inherited namespaces before continuing the recursion. Note:
            //     # since `compile_context['nsmap']` is a dict (and therefore mutable) and we do **not**
            //     # want changes done in deeper recursion to bevisible in earlier ones, we'll pass
            //     # a copy before continuing the recursion and restore the original afterwards.
            //     compile_context = dict(compile_context, nsmap=el.nsmap)
            // 
            // if el.text is not None:
            //     self._append_text(el.text, compile_context)
            // body = []
            // for item in list(el):
            //     if isinstance(item, etree._Comment):
            //         if compile_context.get('preserve_comments'):
            //             self._append_text(f"<!--{item.text}-->", compile_context)
            //     elif isinstance(item, etree._ProcessingInstruction):
            //         if compile_context.get('preserve_comments'):
            //             self._append_text(f"<?{item.target} {item.text}?>", compile_context)
            //     else:
            //         body.extend(self._compile_node(item, compile_context, level))
            //     # comments can also contains tail text
            //     if item.tail is not None:
            //         self._append_text(item.tail, compile_context)
            // return body
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _compile_directive_install(self, el, compile_context, indent):
            // key = el.attrib.pop('t-install')
            // thumbnail = el.attrib.pop('t-thumbnail', 'oe-thumbnail')
            // image_preview = el.attrib.pop('t-image-preview', None)
            // group = el.attrib.pop('group', None)
            // label = el.attrib.pop('label', None)
            // if self.env.user.has_group('base.group_system'):
            //     module = self.env['ir.module.module'].search([('name', '=', key)])
            //     if not module or module.state == 'installed':
            //         return []
            //     name = el.attrib.get('string') or 'Snippet'
            //     div = Markup('<div name="%s" data-oe-type="snippet" data-module-id="%s" data-module-display-name="%s" data-o-image-preview="%s" data-oe-thumbnail="%s" %s %s><section/></div>') % (
            //         name,
            //         module.id,
            //         module.display_name,
            //         escape_silent(image_preview),
            //         thumbnail,
            //         Markup('data-o-group="%s"') % group if group else '',
            //         Markup('data-o-label="%s"') % label if label else '',
            //     )
            //     self._append_text(div, compile_context)
            // return []
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object directive, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py) ---
            // def _compile_directive(self, el, compile_context, directive, level):
            // if (
            //     "raise_on_forbidden_code_for_model" in compile_context
            //     and directive not in self.allowed_directives
            // ):
            //     raise PermissionError("This directive is not allowed for this rendering mode.")
            // return super()._compile_directive(el, compile_context, directive, level)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive(self, el, compile_context, directive, level):
            // compile_handler = getattr(self, f"_compile_directive_{directive.replace('-', '_')}", None)
            // if compile_context.get('profile') and directive not in ('inner-content', 'tag-open', 'tag-close'):
            //     enter = f"{' ' * 4 * level}self.env.context['qweb_tracker'].enter_directive({directive!r}, {el.attrib!r}, {compile_context['_qweb_error_path_xml'][1]!r})"
            //     leave = f"{' ' * 4 * level}self.env.context['qweb_tracker'].leave_directive({directive!r}, {el.attrib!r}, {compile_context['_qweb_error_path_xml'][1]!r})"
            //     code_directive = compile_handler(el, compile_context, level)
            //     if code_directive:
            //         code_directive = [enter, *code_directive, leave]
            // else:
            //     code_directive = compile_handler(el, compile_context, level)
            // return code_directive
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_lang(self, el, compile_context, level):
            // if 't-call' not in el.attrib:
            //     raise SyntaxError("t-lang is an alias of t-options-lang but only available on the same node of t-call")
            // el.attrib['t-options-lang'] = el.attrib.pop('t-lang')
            // return self._compile_node(el, compile_context, level)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveOptionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_options(self, el, compile_context, level):
            // """
            // compile t-options and add to the dict the t-options-xxx. Will create
            // the dictionary ``values['__qweb_options__']`` in compiled code.
            // """
            // code = []
            // dict_options = []
            // for key in list(el.attrib):
            //     if key.startswith('t-options-'):
            //         value = el.attrib.pop(key)
            //         option_name = key[10:]
            //         dict_options.append(f'{option_name!r}:{self._compile_expr(value)}')
            // 
            // t_options = el.attrib.pop('t-options', None)
            // if t_options and dict_options:
            //     code.append(indent_code(f"values['__qweb_options__'] = {{**{self._compile_expr(t_options)}, {', '.join(dict_options)}}}", level))
            // elif dict_options:
            //     code.append(indent_code(f"values['__qweb_options__'] = {{{', '.join(dict_options)}}}", level))
            // elif t_options:
            //     code.append(indent_code(f"values['__qweb_options__'] = {self._compile_expr(t_options)}", level))
            // else:
            //     code.append(indent_code("values['__qweb_options__'] = {}", level))
            // 
            // el.set('t-consumed-options', str(bool(code)))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveOutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py) ---
            // def _compile_directive_out(self, el, compile_context, level):
            // if "raise_on_forbidden_code_for_model" in compile_context:
            //     if len(el) != 0:
            //         raise PermissionError("No child allowed for t-out.")
            //     if set(el.attrib) - {'t-out', 't-tag-open', 't-tag-close'}:
            //         raise PermissionError("No other attribute allowed for t-out.")
            // return super()._compile_directive_out(el, compile_context, level)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_out(self, el, compile_context, level):
            // """Compile `t-out` expressions into a python code as a list of
            // strings.
            // 
            // The code will contain evalution and rendering of the compiled value. If
            // the compiled value is None or False, the tag is not added to the render
            // (Except if the widget forces rendering or there is default content).
            // (eg: `<t t-out="my_value">Default content if falsy</t>`)
            // 
            // The output can have some rendering option with `t-options-widget` or
            // `t-options={'widget': ...}. At rendering time, The compiled code will
            // call ``_get_widget`` method or ``_get_field`` method for `t-field`.
            // 
            // A `t-field` will necessarily be linked to the value of a record field
            // (eg: `<span t-field="record.field_name"/>`), a t-out` can be applied
            // to any value (eg: `<span t-out="10" t-options-widget="'float'"/>`).
            // """
            // ttype = 't-out'
            // expr = el.attrib.pop('t-out', None)
            // if expr is None:
            //     ttype = 't-field'
            //     expr = el.attrib.pop('t-field', None)
            //     if expr is None:
            //         # deprecated use.
            //         ttype = 't-esc'
            //         expr = el.attrib.pop('t-esc', None)
            //         if expr is None:
            //             ttype = 't-raw'
            //             expr = el.attrib.pop('t-raw')
            // 
            // code = self._flush_text(compile_context, level)
            // 
            // _ref, path, xml = compile_context['_qweb_error_path_xml']
            // 
            // code_options = el.attrib.pop('t-consumed-options', 'None')
            // tag_open = (
            //     self._compile_directive(el, compile_context, 'tag-open', level + 1) +
            //     self._flush_text(compile_context, level + 1))
            // tag_close = (
            //     self._compile_directive(el, compile_context, 'tag-close', level + 1) +
            //     self._flush_text(compile_context, level + 1))
            // default_body = (
            //     self._compile_directive(el, compile_context, 'inner-content', level + 1) +
            //     self._flush_text(compile_context, level + 1))
            // 
            // # The generated code will set the values of the content, attrs (used to
            // # output attributes) and the force_display (if the widget or field
            // # mark force_display as True, the tag will be inserted in the output
            // # even the value of content is None and without default value)
            // 
            // if expr == T_CALL_SLOT and code_options != 'True':
            //     code.append(indent_code("if True:", level))
            //     code.extend(tag_open)
            //     code.append(indent_code(f"yield values.get({T_CALL_SLOT}, '')", level + 1))
            //     code.extend(tag_close)
            //     return code
            // elif ttype == 't-field':
            //     record, field_name = expr.rsplit('.', 1)
            //     code.append(indent_code(f"""
            //         field_attrs, content, force_display = self._get_field({self._compile_expr(record, raise_on_missing=True)}, {field_name!r}, {expr!r}, {el.tag!r}, values.pop('__qweb_options__', {{}}), values)
            //         if values.get('__qweb_attrs__') is None:
            //             values['__qweb_attrs__'] = field_attrs
            //         else:
            //             values['__qweb_attrs__'].update(field_attrs)
            //         if content is not None and content is not False:
            //             content = self._compile_to_str(content)
            //         """, level))
            //     force_display_dependent = True
            // else:
            //     if expr == T_CALL_SLOT:
            //         code.append(indent_code(f"content = values.get({T_CALL_SLOT}, '')", level))
            //     else:
            //         code.append(indent_code(f"content = {self._compile_expr(expr)}", level))
            // 
            //     if code_options == 'True':
            //         code.append(indent_code(f"""
            //             widget_attrs, content, force_display = self._get_widget(content, {expr!r}, {el.tag!r}, values.pop('__qweb_options__', {{}}), values)
            //             if values.get('__qweb_attrs__') is None:
            //                 values['__qweb_attrs__'] = widget_attrs
            //             else:
            //                 values['__qweb_attrs__'].update(widget_attrs)
            //             content = self._compile_to_str(content)
            //             """, level))
            //         force_display_dependent = True
            //     else:
            //         force_display_dependent = False
            // 
            //     if ttype == 't-raw':
            //         # deprecated use.
            //         code.append(indent_code("""
            //             if content is not None and content is not False:
            //                 content = Markup(content)
            //         """, level))
            // 
            // # The generated code will create the output tag with all attribute.
            // # If the value is not falsy or if there is default content or if it's
            // # in force_display mode, the tag is add into the output.
            // 
            // el.attrib.pop('t-tag', None) # code generating the output is done here
            // 
            // # generate code to display the tag if the value is not Falsy
            // 
            // code.append(indent_code("if content is not None and content is not False:", level))
            // code.extend(tag_open)
            // # Use str to avoid the escaping of the other html content because the
            // # yield generator MarkupSafe values will be join into an string in
            // # `_render`.
            // code.append(indent_code(f"""
            //     if isinstance(content, QwebContent):
            //         self.env.context['_qweb_error_path_xml'][0] = template_options['ref']
            //         self.env.context['_qweb_error_path_xml'][1] = {path!r}
            //         self.env.context['_qweb_error_path_xml'][2] = {xml!r}
            //         yield content
            //     else:
            //         yield str(escape(content))
            // """, level + 1))
            // code.extend(tag_close)
            // 
            // # generate code to display the tag with default content if the value is
            // # Falsy
            // 
            // if default_body or compile_context['_text_concat']:
            //     _text_concat = list(compile_context['_text_concat'])
            //     compile_context['_text_concat'].clear()
            //     code.append(indent_code("else:", level))
            //     code.extend(tag_open)
            //     code.extend(default_body)
            //     compile_context['_text_concat'].extend(_text_concat)
            //     code.extend(tag_close)
            // elif force_display_dependent:
            // 
            //     # generate code to display the tag if it's the force_diplay mode.
            // 
            //     if tag_open + tag_close:
            //         code.append(indent_code("elif force_display:", level))
            //         code.extend(tag_open + tag_close)
            // 
            //     code.append(indent_code("""else: values.pop('__qweb_attrs__', None)""", level))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectivePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _compile_directive_placeholder(self, el, compile_context, indent):
            // el.set('t-att-placeholder', el.attrib.pop('t-placeholder'))
            // return []
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_raw(self, el, compile_context, level):
            // # deprecated use.
            // _logger.warning(
            //     "Found deprecated directive @t-raw=%r in template %r. Replace by "
            //     "@t-out, and explicitely wrap content in `Markup` if "
            //     "necessary (which likely is not the case)",
            //     el.get('t-raw'),
            //     compile_context.get('ref', '<unknown>'),
            // )
            // return self._compile_directive_out(el, compile_context, level)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveSetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_set(self, el, compile_context, level):
            // """Compile `t-set` expressions into a python code as a list of
            // strings.
            // 
            // There are 3 kinds of `t-set`:
            // * `t-value` containing python code;
            // * `t-valuef` containing strings to format;
            // * `t-valuef.translate` containing translated strings to format;
            // * whose value is the content of the tag (being Markup safe).
            // 
            // The code will contain the assignment of the dynamically generated value.
            // """
            // 
            // code = self._flush_text(compile_context, level, rstrip=el.tag.lower() == 't')
            // 
            // if 't-set' in el.attrib:
            //     varname = el.attrib.pop('t-set')
            //     if varname == "":
            //         raise KeyError('t-set')
            //     if varname != T_CALL_SLOT and varname[0] != '{' and not VARNAME_REGEXP.match(varname):
            //         raise SyntaxError('The varname can only contain alphanumeric characters and underscores.')
            //     if '__' in varname:
            //         raise SyntaxError(f"Using variable names with '__' is not allowed: {varname!r}")
            // 
            //     if 't-value' in el.attrib or 't-valuef' in el.attrib or 't-valuef.translate' in el.attrib or varname[0] == '{':
            //         el.attrib.pop('t-inner-content') # The content is considered empty.
            //         if varname == T_CALL_SLOT:
            //             raise SyntaxError('t-set="0" should not be set from t-value or t-valuef')
            // 
            //     if 't-value' in el.attrib:
            //         expr = el.attrib.pop('t-value') or 'None'
            //         code.append(indent_code(f"values[{varname!r}] = {self._compile_expr(expr)}", level))
            //     elif 't-valuef' in el.attrib:
            //         exprf = el.attrib.pop('t-valuef')
            //         code.append(indent_code(f"values[{varname!r}] = {self._compile_format(exprf)}", level))
            //     elif 't-valuef.translate' in el.attrib:
            //         exprf = el.attrib.pop('t-valuef.translate')
            //         code.append(indent_code(f"values[{varname!r}] = {self._compile_format(exprf)}", level))
            //     elif varname[0] == '{':
            //         code.append(indent_code(f"values.update({self._compile_expr(varname)})", level))
            //     else:
            //         # set the content as value
            //         _ref, path, xml = compile_context['_qweb_error_path_xml']
            //         content = (
            //             self._compile_directive(el, compile_context, 'inner-content', 1) +
            //             self._flush_text(compile_context, 1))
            //         if content:
            //             def_name = compile_context['make_name']('t_set')
            //             def_code = [f"def {def_name}(self, values):"]
            //             def_code.append(indent_code(f'# element: {path!r} , {xml!r}', 1))
            //             def_code.extend(content)
            //             compile_context['template_functions'][def_name] = def_code
            // 
            //             code.append(indent_code(f"""
            //                 values[{varname!r}] = QwebContent(self, QwebCallParameters(self.env.context, {compile_context['ref']!r}, {def_name!r}, values.copy(), 'root', 't-set', (template_options['ref'], {path!r}, {xml!r})))
            //             """, level))
            //         else:
            //             code.append(indent_code(f"values[{varname!r}] = ''", level))
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveSnippetCallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _compile_directive_snippet_call(self, el, compile_context, indent):
            // key = el.attrib.pop('t-snippet-call')
            // snippet_name = el.attrib.pop('string', None)
            // el.set('t-call', key)
            // el.set('t-options', f"{{'snippet-key': {key!r}, 'snippet-name': {snippet_name!r}}}")
            // return self._compile_node(el, compile_context, indent)
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveSnippetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object indent) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _compile_directive_snippet(self, el, compile_context, indent):
            // key = el.attrib.pop('t-snippet')
            // el.set('t-call', key)
            // snippet_lang = self.env.context.get('snippet_lang')
            // if snippet_lang:
            //     el.set('t-lang', f"'{snippet_lang}'")
            // 
            // el.set('t-options', f"{{'snippet-key': {key!r}}}")
            // view = self.env['ir.ui.view']._get_template_view(key)
            // name = el.attrib.pop('string', view.name)
            // thumbnail = el.attrib.pop('t-thumbnail', "oe-thumbnail")
            // image_preview = el.attrib.pop('t-image-preview', None)
            // # Forbid sanitize contains the specific reason:
            // # - "true": always forbid
            // # - "form": forbid if forms are sanitized
            // forbid_sanitize = el.attrib.pop('t-forbid-sanitize', None)
            // grid_column_span = el.attrib.pop('t-grid-column-span', None)
            // snippet_group = el.attrib.pop('snippet-group', None)
            // group = el.attrib.pop('group', None)
            // label = el.attrib.pop('label', None)
            // div = Markup('<div name="%s" data-oe-type="snippet" data-o-image-preview="%s" data-oe-thumbnail="%s" data-oe-snippet-id="%s" data-oe-snippet-key="%s" data-oe-keywords="%s" %s %s %s %s %s>') % (
            //     name,
            //     escape_silent(image_preview),
            //     thumbnail,
            //     view.id,
            //     key.split('.')[-1],
            //     escape_silent(el.findtext('keywords')),
            //     Markup('data-oe-forbid-sanitize="%s"') % forbid_sanitize if forbid_sanitize else '',
            //     Markup('data-o-grid-column-span="%s"') % grid_column_span if grid_column_span else '',
            //     Markup('data-o-snippet-group="%s"') % snippet_group if snippet_group else '',
            //     Markup('data-o-group="%s"') % group if group else '',
            //     Markup('data-o-label="%s"') % label if label else '',
            // )
            // self._append_text(div, compile_context)
            // code = self._compile_node(el, compile_context, indent)
            // self._append_text('</div>', compile_context)
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveTagCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_tag_close(self, el, compile_context, level):
            // """ Compile the closing tag of the given element into string.
            // Returns an empty list because it's use only `_append_text`.
            // """
            // el_tag = el.attrib.pop("t-tag-close", None)
            // if el_tag:
            //     self._append_text(f'</{el_tag}>', compile_context)
            // return []
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveTagOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_tag_open(self, el, compile_context, level):
            // """ Compile the opening tag with attributes of the given element into
            // a list of python code line.
            // 
            // The compiled function will fill the ``attrs`` dictionary. Then the
            // ``attrs`` dictionary will be output and reset the value of ``attrs``.
            // 
            // The static attributes (not prefixed by ``t-``) are add to the
            // ``attrs`` dictionary in first.
            // 
            // The dynamic attributes values will be add after. The dynamic
            // attributes has different origins.
            // 
            // - value from key equal to ``t-att``: python dictionary expression;
            // - value from keys that start with ``t-att-``: python expression;
            // - value from keys that start with ``t-attf-``: format string
            //     expression.
            // """
            // 
            // el_tag = el.attrib.pop('t-tag-open', None)
            // if not el_tag:
            //     return []
            // 
            // # open the open tag
            // self._append_text(f"<{el_tag}", compile_context)
            // 
            // code = self._flush_text(compile_context, level)
            // 
            // # Generates the part of the code that prost process and output the
            // # attributes from ``attrs`` dictionary. Consumes `attrs` dictionary
            // # and reset it.
            // #
            // # Use str(value) to change Markup into str and escape it, then use str
            // # to avoid the escaping of the other html content.
            // code.append(indent_code(f"""
            //     attrs = values.pop('__qweb_attrs__', None)
            //     if attrs:
            //         tagName = {el.tag!r}
            //         attrs = self._post_processing_att(tagName, attrs)
            //         for name, value in attrs.items():
            //             if value or isinstance(value, str):
            //                 yield f' {{escape(str(name))}}="{{escape(str(value))}}"'
            // """, level))
            // 
            // # close the open tag
            // if 't-tag-close' in el.attrib:
            //     self._append_text('>', compile_context)
            // else:
            //     self._append_text('/>', compile_context)
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_value(self, el, compile_context, level):
            // """Compile `t-value` expressions into a python code as a list of strings.
            // 
            // This method only check if this attributes is on the same node of a
            //  `t-set` attribute.
            // """
            // raise SyntaxError("t-value must be on the same node of t-set")
            */
            return default;
        }

        public async Task<TEntity> CompileDirectiveValuefInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directive_valuef(self, el, compile_context, level):
            // """Compile `t-valuef` expressions into a python code as a list of strings.
            // 
            // This method only check if this attributes is on the same node of a
            //  `t-set` attribute.
            // """
            // raise SyntaxError("t-valuef must be on the same node of t-set")
            */
            return default;
        }

        public async Task<TEntity> CompileDirectivesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_directives(self, el, compile_context, level):
            // """ Compile the given element, following the directives given in the
            // iterator ``compile_context['iter_directives']`` create by
            // `_compile_node`` method.
            // 
            // :return: list of code lines
            // """
            // if self._is_static_node(el, compile_context):
            //     el.attrib.pop('t-tag-open', None)
            //     el.attrib.pop('t-inner-content', None)
            //     el.attrib.pop('t-tag-close', None)
            //     return self._compile_static_node(el, compile_context, level)
            // 
            // code = []
            // 
            // # compile the directives still present on the element
            // for directive in compile_context['iter_directives']:
            //     if ('t-' + directive) in el.attrib:
            //         code.extend(self._compile_directive(el, compile_context, directive, level))
            //     elif directive == 'groups':
            //         if directive in el.attrib:
            //             code.extend(self._compile_directive(el, compile_context, directive, level))
            //     elif directive == 'att':
            //         code.extend(self._compile_directive(el, compile_context, directive, level))
            //     elif directive == 'options':
            //         if any(name.startswith('t-options-') for name in el.attrib):
            //             code.extend(self._compile_directive(el, compile_context, directive, level))
            // 
            // # compile unordered directives still present on the element
            // for att in el.attrib:
            //     if att not in SPECIAL_DIRECTIVES and att.startswith('t-') and getattr(self, f"_compile_directive_{att[2:].replace('-', '_')}", None):
            //         code.extend(self._compile_directive(el, compile_context, directive, level))
            // 
            // remaining = set(el.attrib) - SPECIAL_DIRECTIVES
            // if remaining:
            //     _logger.warning('Unknown directives or unused attributes: %s in %s', remaining, compile_context['template'])
            // 
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileExprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expr, object raise_on_missing) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py) ---
            // def _compile_expr(self, expr, raise_on_missing=False):
            // model = self.env.context.get("raise_on_forbidden_code_for_model")
            // if model is not None and not self._is_expression_allowed(expr, model):
            //     raise PermissionError("This directive is not allowed for this rendering mode.")
            // return super()._compile_expr(expr, raise_on_missing)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_expr(self, expr, raise_on_missing=False):
            // """Transform string coming into a python instruction in textual form by
            // adding the namepaces for the dynamic values.
            // This method tokenize the string and call ``_compile_expr_tokens``
            // method.
            // 
            // :param expr: string: python expression
            // :param bool raise_on_missing:
            //     Compile has `values['product'].price` instead of
            //     `values.get('product').price` to raise an error when get the
            //     'product' value and not an 'NoneType' object has no attribute
            //     'price' error.
            // """
            // # Parentheses are useful for compiling multi-line expressions such as
            // # conditions existing in some templates. (see test_compile_expr tests)
            // readable = io.BytesIO(f"({expr or ''})".encode('utf-8'))
            // try:
            //     tokens = list(tokenize.tokenize(readable.readline))
            // except tokenize.TokenError:
            //     raise ValueError(f"Can not compile expression: {expr}")
            // 
            // expression = self._compile_expr_tokens(tokens, ALLOWED_KEYWORD, raise_on_missing=raise_on_missing)
            // 
            // assert_valid_codeobj(_SAFE_QWEB_OPCODES, compile(expression, '<>', 'eval'), expr)
            // 
            // return f"({expression})"
            */
            return default;
        }

        public async Task<TEntity> CompileExprTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tokens, object allowed_keys, object argument_names, object raise_on_missing) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_expr_tokens(self, tokens, allowed_keys, argument_names=None, raise_on_missing=False):
            // """ Transform the list of token coming into a python instruction in
            //     textual form by adding the namepaces for the dynamic values.
            // 
            //     Example: `5 + a + b.c` to be `5 + values.get('a') + values['b'].c`
            //     Unknown values are considered to be None, but using `values['b']`
            //     gives a clear error message in cases where there is an attribute for
            //     example (have a `KeyError: 'b'`, instead of `AttributeError: 'NoneType'
            //     object has no attribute 'c'`).
            // 
            //     @returns str
            // """
            // # Finds and extracts the current "scope"'s "allowed values": values
            // # which should not be accessed through the environment's namespace:
            // # * the local variables of a lambda should be accessed directly e.g.
            // #     lambda a: a + b should be compiled to lambda a: a + values['b'],
            // #     since a is local to the lambda it has to be accessed directly
            // #     but b needs to be accessed through the rendering environment
            // # * similarly for a comprehensions [a + b for a in c] should be
            // #     compiledto [a + values.get('b') for a in values.get('c')]
            // # to avoid the risk of confusion between nested lambdas / comprehensions,
            // # this is currently performed independently at each level of brackets
            // # nesting (hence the function being recursive).
            // open_bracket_index = -1
            // bracket_depth = 0
            // 
            // argument_name = '_arg_%s__'
            // argument_names = argument_names or []
            // 
            // for index, t in enumerate(tokens):
            //     if t.exact_type in [token.LPAR, token.LSQB, token.LBRACE]:
            //         bracket_depth += 1
            //     elif t.exact_type in [token.RPAR, token.RSQB, token.RBRACE]:
            //         bracket_depth -= 1
            //     elif bracket_depth == 0 and t.exact_type == token.NAME:
            //         string = t.string
            //         if string == 'lambda': # lambda => allowed values for the current bracket depth
            //             for i in range(index + 1, len(tokens)):
            //                 t = tokens[i]
            //                 if t.exact_type == token.NAME:
            //                     argument_names.append(t.string)
            //                 elif t.exact_type == token.COMMA:
            //                     pass
            //                 elif t.exact_type == token.COLON:
            //                     break
            //                 elif t.exact_type == token.EQUAL:
            //                     raise NotImplementedError('Lambda default values are not supported')
            //                 else:
            //                     raise NotImplementedError('This lambda code style is not implemented.')
            //         elif string == 'for': # list comprehensions => allowed values for the current bracket depth
            //             for i in range(index + 1, len(tokens)):
            //                 t = tokens[i]
            //                 if t.exact_type == token.NAME:
            //                     if t.string == 'in':
            //                         break
            //                     argument_names.append(t.string)
            //                 elif t.exact_type in [token.COMMA, token.LPAR, token.RPAR]:
            //                     pass
            //                 else:
            //                     raise NotImplementedError('This loop code style is not implemented.')
            // 
            // # Use bracket to nest structures.
            // # Recursively processes the "sub-scopes", and replace their content with
            // # a compiled node. During this recursive call we add to the allowed
            // # values the values provided by the list comprehension, lambda, etc.,
            // # previously extracted.
            // index = 0
            // open_bracket_index = -1
            // bracket_depth = 0
            // 
            // while index < len(tokens):
            //     t = tokens[index]
            //     string = t.string
            // 
            //     if t.exact_type in [token.LPAR, token.LSQB, token.LBRACE]:
            //         if bracket_depth == 0:
            //             open_bracket_index = index
            //         bracket_depth += 1
            //     elif t.exact_type in [token.RPAR, token.RSQB, token.RBRACE]:
            //         bracket_depth -= 1
            //         if bracket_depth == 0:
            //             code = self._compile_expr_tokens(
            //                 tokens[open_bracket_index + 1:index],
            //                 list(allowed_keys),
            //                 list(argument_names),
            //                 raise_on_missing,
            //             )
            //             code = tokens[open_bracket_index].string + code + t.string
            //             tokens[open_bracket_index:index + 1] = [tokenize.TokenInfo(token.QWEB, code, tokens[open_bracket_index].start, t.end, '')]
            //             index = open_bracket_index
            // 
            //     index += 1
            // 
            // # The keys will be namespaced by values if they are not allowed. In
            // # order to have a clear keyError message, this will be replaced by
            // # values['key'] for certain cases (for example if an attribute is called
            // # key.attrib, or an index key[0] ...)
            // code = []
            // index = 0
            // pos = tokens and tokens[0].start # to keep level when use expr on multi line
            // while index < len(tokens):
            //     t = tokens[index]
            //     string = t.string
            // 
            //     if t.start[0] != pos[0]:
            //         pos = (t.start[0], 0)
            //     space = t.start[1] - pos[1]
            //     if space:
            //         code.append(' ' * space)
            //     pos = t.start
            // 
            //     if t.exact_type == token.NAME:
            //         if '__' in string:
            //             raise SyntaxError(f"Using variable names with '__' is not allowed: {string!r}")
            //         if string == 'lambda': # lambda => allowed values
            //             code.append('lambda ')
            //             index += 1
            //             while index < len(tokens):
            //                 t = tokens[index]
            //                 if t.exact_type == token.NAME and t.string in argument_names:
            //                     code.append(argument_name % t.string)
            //                 if t.exact_type in [token.COMMA, token.COLON]:
            //                     code.append(t.string)
            //                 if t.exact_type == token.COLON:
            //                     break
            //                 index += 1
            //             if t.end[0] != pos[0]:
            //                 pos = (t.end[0], 0)
            //             else:
            //                 pos = t.end
            //         elif string in argument_names:
            //             code.append(argument_name % t.string)
            //         elif string in allowed_keys:
            //             code.append(string)
            //         elif index + 1 < len(tokens) and tokens[index + 1].exact_type == token.EQUAL: # function kw
            //             code.append(string)
            //         elif index > 0 and tokens[index - 1] and tokens[index - 1].exact_type == token.DOT:
            //             code.append(string)
            //         elif raise_on_missing or index + 1 < len(tokens) and tokens[index + 1].exact_type in [token.DOT, token.LPAR, token.LSQB, token.QWEB]:
            //             # Should have values['product'].price to raise an error when get
            //             # the 'product' value and not an 'NoneType' object has no
            //             # attribute 'price' error.
            //             code.append(f'values[{string!r}]')
            //         else:
            //             # not assignation allowed, only getter
            //             code.append(f'values.get({string!r})')
            //     elif t.type not in [tokenize.ENCODING, token.ENDMARKER, token.DEDENT]:
            //         code.append(string)
            // 
            //     if t.end[0] != pos[0]:
            //         pos = (t.end[0], 0)
            //     else:
            //         pos = t.end
            // 
            //     index += 1
            // 
            // return ''.join(code)
            */
            return default;
        }

        public async Task<TEntity> CompileFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expr) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_format(self, expr):
            // """ Parses the provided format string and compiles it to a single
            // expression python, uses string with format method.
            // Use format is faster to concat string and values.
            // """
            // # <t t-setf-name="Hello #{world} %s !"/>
            // # =>
            // # values['name'] = 'Hello %s %%s !' % (values['world'],)
            // values = [
            //     f'self._compile_to_str({self._compile_expr(m.group(1) or m.group(2))})'
            //     for m in FORMAT_REGEX.finditer(expr)
            // ]
            // code = repr(FORMAT_REGEX.sub('%s', expr.replace('%', '%%')))
            // if values:
            //     code += f' % ({", ".join(values)},)'
            // return code
            */
            return default;
        }

        public async Task<TEntity> CompileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile(self, template):
            // ref = None
            // if isinstance(template, str) and template.endswith('.xml'):
            //     module_path = Manifest.for_addon(Path(template).parts[0]).path
            //     if 'templates' not in Path(file_path(template)).relative_to(module_path).parts:
            //         raise ValueError("The templates file %s must be under a subfolder 'templates' of a module", template)
            //     else:
            //         with file_open(template, 'rb', filter_ext=('.xml',)) as file:
            //             template = etree.fromstring(file.read())
            // elif not isinstance(template, etree._Element):
            //     ref = self._get_template_info(template)['id']
            // 
            // if ref:
            //     template_functions, def_name, options = self._generate_code_cached(ref)
            // else:
            //     template_functions, def_name, options = self._generate_code_uncached(template)
            // 
            // render_template = template_functions[def_name]
            // if options.get('profile') and render_template.__name__ != 'profiled_method_compile':
            //     ref = options.get('ref')
            //     ref_xml = str(val) if (val := options.get('ref_xml')) else None
            // 
            //     def wrap(function):
            //         def profiled_method_compile(self, values):
            //             qweb_tracker = QwebTracker(ref, ref_xml, self.env.cr)
            //             self = self.with_context(qweb_tracker=qweb_tracker)
            //             if qweb_tracker.execution_context_enabled:
            //                 with ExecutionContext(template=ref):
            //                     return function(self, values)
            //             return function(self, values)
            // 
            //         return profiled_method_compile
            // 
            //     for key, function in template_functions.items():
            //         if isinstance(function, FunctionType):
            //             template_functions[key] = wrap(function)
            // 
            // return (template_functions, def_name, options)
            */
            return default;
        }

        public async Task<TEntity> CompileNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _compile_node(self, el, compile_context, level):
            // snippet_key = compile_context.get('snippet-key')
            // 
            // template = compile_context['ref_name']
            // sub_call_key = compile_context.get('snippet-sub-call-key')
            // 
            // # We only add the 'data-snippet' & 'data-name' attrib once when
            // # compiling the root node of the template.
            // if not template or template not in {snippet_key, sub_call_key} or el.getparent() is not None:
            //     return super()._compile_node(el, compile_context, level)
            // 
            // snippet_base_node = el
            // if el.tag == 't':
            //     el_children = [child for child in list(el) if isinstance(child.tag, str) and child.tag != 't']
            //     if len(el_children) == 1:
            //         snippet_base_node = el_children[0]
            //     elif not el_children:
            //         # If there's not a valid base node we check if the base node is
            //         # a t-call to another template. If so the called template's base
            //         # node must take the current snippet key.
            //         el_children = [child for child in list(el) if isinstance(child.tag, str)]
            //         if len(el_children) == 1:
            //             sub_call = el_children[0].get('t-call')
            //             if sub_call:
            //                 el_children[0].set('t-options', f"{{'snippet-key': '{snippet_key}', 'snippet-sub-call-key': '{sub_call}'}}")
            // # If it already has a data-snippet it is a saved or an
            // # inherited snippet. Do not override it.
            // if 'data-snippet' not in snippet_base_node.attrib:
            //     snippet_base_node.attrib['data-snippet'] = \
            //         snippet_key.split('.', 1)[-1]
            // # If it already has a data-name it is a saved or an
            // # inherited snippet. Do not override it.
            // snippet_name = compile_context.get('snippet-name')
            // if snippet_name and 'data-name' not in snippet_base_node.attrib:
            //     snippet_base_node.attrib['data-name'] = snippet_name
            // return super()._compile_node(el, compile_context, level)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_node(self, el, compile_context, level):
            // """ Compile the given element into python code.
            // 
            //     The t-* attributes (directives) will be converted to a python instruction. If there
            //     are no t-* attributes, the element will be considered static.
            // 
            //     Directives are compiled using the order provided by the
            //     ``_directives_eval_order`` method (an create the
            //     ``compile_context['iter_directives']`` iterator).
            //     For compilation, the directives supported are those with a
            //     compilation method ``_compile_directive_*``
            // 
            // :return: list of string
            // """
            // # Internal directive used to skip a rendering.
            // if 't-qweb-skip' in el.attrib:
            //     return []
            // 
            // # if tag don't have qweb attributes don't use directives
            // if self._is_static_node(el, compile_context):
            //     return self._compile_static_node(el, compile_context, level)
            // 
            // path = compile_context['root'].getpath(el)
            // xml = etree.tostring(etree.Element(el.tag, el.attrib), encoding='unicode')
            // compile_context['_qweb_error_path_xml'][0] = compile_context['ref']
            // compile_context['_qweb_error_path_xml'][1] = path
            // compile_context['_qweb_error_path_xml'][2] = xml
            // body = [indent_code(f'# element: {path!r} , {xml!r}', level)]
            // 
            // # create an iterator on directives to compile in order
            // compile_context['iter_directives'] = iter(self._directives_eval_order())
            // 
            // # add technical directive tag-open, tag-close, inner-content and take
            // # care of the namspace
            // if not el.nsmap:
            //     unqualified_el_tag = el_tag = el.tag
            // else:
            //     # Etree will remove the ns prefixes indirection by inlining the corresponding
            //     # nsmap definition into the tag attribute. Restore the tag and prefix here.
            //     # Note: we do not support namespace dynamic attributes, we need a default URI
            //     # on the root and use attribute directive t-att="{'xmlns:example': value}".
            //     unqualified_el_tag = etree.QName(el.tag).localname
            //     el_tag = unqualified_el_tag
            //     if el.prefix:
            //         el_tag = f'{el.prefix}:{el_tag}'
            // 
            // if unqualified_el_tag != 't':
            //     el.set('t-tag-open', el_tag)
            //     if el_tag not in VOID_ELEMENTS:
            //         el.set('t-tag-close', el_tag)
            // 
            // if not ({'t-out', 't-esc', 't-raw', 't-field'} & set(el.attrib)):
            //     el.set('t-inner-content', 'True')
            // 
            // return body + self._compile_directives(el, compile_context, level)
            */
            return default;
        }

        public async Task<TEntity> CompileStaticNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context, object level) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_static_node(self, el, compile_context, level):
            // """ Compile a purely static element into a list of string. """
            // if not el.nsmap:
            //     unqualified_el_tag = el_tag = el.tag
            //     attrib = self._post_processing_att(el.tag, {**el.attrib, '__is_static_node': True})
            // else:
            //     # Etree will remove the ns prefixes indirection by inlining the corresponding
            //     # nsmap definition into the tag attribute. Restore the tag and prefix here.
            //     unqualified_el_tag = etree.QName(el.tag).localname
            //     el_tag = unqualified_el_tag
            //     if el.prefix:
            //         el_tag = f'{el.prefix}:{el_tag}'
            // 
            //     attrib = {}
            //     # If `el` introduced new namespaces, write them as attribute by using the
            //     # `attrib` dict.
            //     for ns_prefix, ns_definition in set(el.nsmap.items()) - set(compile_context['nsmap'].items()):
            //         if ns_prefix is None:
            //             attrib['xmlns'] = ns_definition
            //         else:
            //             attrib[f'xmlns:{ns_prefix}'] = ns_definition
            // 
            //     # Etree will also remove the ns prefixes indirection in the attributes. As we only have
            //     # the namespace definition, we'll use an nsmap where the keys are the definitions and
            //     # the values the prefixes in order to get back the right prefix and restore it.
            //     ns = chain(compile_context['nsmap'].items(), el.nsmap.items())
            //     nsprefixmap = {v: k for k, v in ns}
            //     for key, value in el.attrib.items():
            //         name = key.removesuffix(".translate")
            //         attrib_qname = etree.QName(name)
            //         if attrib_qname.namespace:
            //             attrib[f'{nsprefixmap[attrib_qname.namespace]}:{attrib_qname.localname}'] = value
            //         else:
            //             attrib[name] = value
            // 
            //     attrib = self._post_processing_att(el.tag, {**attrib, '__is_static_node': True})
            // 
            //     # Update the dict of inherited namespaces before continuing the recursion. Note:
            //     # since `compile_context['nsmap']` is a dict (and therefore mutable) and we do **not**
            //     # want changes done in deeper recursion to bevisible in earlier ones, we'll pass
            //     # a copy before continuing the recursion and restore the original afterwards.
            //     original_nsmap = dict(compile_context['nsmap'])
            // 
            // if unqualified_el_tag != 't':
            //     attributes = ''.join(f' {name.removesuffix(".translate")}="{escape(str(value))}"'
            //                         for name, value in attrib.items() if value or isinstance(value, str))
            //     self._append_text(f'<{el_tag}{"".join(attributes)}', compile_context)
            //     if el_tag in VOID_ELEMENTS:
            //         self._append_text('/>', compile_context)
            //     else:
            //         self._append_text('>', compile_context)
            // 
            // el.attrib.clear()
            // 
            // if el.nsmap:
            //     compile_context['nsmap'].update(el.nsmap)
            //     body = self._compile_directive(el, compile_context, 'inner-content', level)
            //     compile_context['nsmap'] = original_nsmap
            // else:
            //     body = self._compile_directive(el, compile_context, 'inner-content', level)
            // 
            // if unqualified_el_tag != 't':
            //     if el_tag not in VOID_ELEMENTS:
            //         self._append_text(f'</{el_tag}>', compile_context)
            // 
            // return body
            */
            return default;
        }

        public async Task<TEntity> CompileToStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expr) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _compile_to_str(self, expr):
            // """ Generates a text value (an instance of text_type) from an arbitrary
            //     source.
            // """
            // if expr is None or expr is False:
            //     return ''
            // 
            // if isinstance(expr, str):
            //     return expr
            // elif isinstance(expr, bytes):
            //     return expr.decode()
            // else:
            //     return str(expr)
            */
            return default;
        }

        public async Task<TEntity> DebugTraceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debugger, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _debug_trace(self, debugger, values):
            // """Method called at running time to load debugger."""
            // if not debugger:
            //     breakpoint()
            // elif debugger in SUPPORTED_DEBUGGER:
            //     warnings.warn(
            //         "Using t-debug with an explicit debugger is deprecated "
            //         "since Odoo 17.0, keep the value empty and configure the "
            //         "``breakpoint`` builtin instead.",
            //         category=DeprecationWarning,
            //         stacklevel=2,
            //     )
            //     __import__(debugger).set_trace()
            // else:
            //     raise ValueError(f"unsupported t-debug value: {debugger}")
            */
            return default;
        }

        public async Task<TEntity> DirectivesEvalOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _directives_eval_order(self):
            // directives = super()._directives_eval_order()
            // # Insert before "att" as those may rely on static attributes like
            // # "string" and "att" clears all of those
            // index = directives.index('att') - 1
            // directives.insert(index, 'placeholder')
            // directives.insert(index, 'snippet')
            // directives.insert(index, 'snippet-call')
            // directives.insert(index, 'install')
            // return directives
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _directives_eval_order(self):
            // """ List all supported directives in the order in which they should be
            // evaluated on a given element. For instance, a node bearing both
            // ``foreach`` and ``if`` should see ``foreach`` executed before ``if``
            // aka
            // 
            // .. code-block:: xml
            // 
            //     <el t-foreach="foo" t-as="bar" t-if="bar">
            // 
            // should be equivalent to
            // 
            // .. code-block:: xml
            // 
            //     <t t-foreach="foo" t-as="bar">
            //         <t t-if="bar">
            //             <el>
            // 
            // then this method should return ``['foreach', 'if']``.
            // """
            // return [
            //     'elif', # Must be the first because compiled by the previous if.
            //     'else', # Must be the first because compiled by the previous if.
            //     'debug',
            //     'groups',
            //     'as', 'foreach',
            //     'if',
            //     'call-assets',
            //     'lang',
            //     'options',
            //     'call',
            //     'att',
            //     'field', 'esc', 'raw', 'out',
            //     'tag-open',
            //     'set',
            //     'inner-content',
            //     'tag-close',
            // ]
            */
            return default;
        }

        public async Task<TEntity> FlushTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object compile_context, object level, object rstrip) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _flush_text(self, compile_context, level, rstrip=False):
            // """Concatenate all the textual chunks added by the `_append_text`
            //     method into a single yield.
            //     If no text to flush, return an empty list
            // 
            //     If rstrip the text is right stripped.
            // 
            //     @returns list(str)
            // """
            // text_concat = compile_context['_text_concat']
            // if not text_concat:
            //     return []
            // if rstrip:
            //     self._rstrip_text(compile_context)
            // text = ''.join(text_concat)
            // text_concat.clear()
            // return [f"{'    ' * level}yield {text!r}"]
            */
            return default;
        }

        public async Task<TEntity> GenerateAssetLinksCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object assets_params, object rtl, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _generate_asset_links_cache(self, bundle, css=True, js=True, assets_params=None, rtl=False, autoprefix=False):
            // return self._generate_asset_links(bundle, css, js, False, assets_params, rtl, autoprefix=autoprefix)
            */
            return default;
        }

        public async Task<TEntity> GenerateAssetLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object debug_assets, object assets_params, object rtl, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _generate_asset_links(self, bundle, css=True, js=True, debug_assets=False, assets_params=None, rtl=False, autoprefix=False):
            // asset_bundle = self._get_asset_bundle(bundle, css=css, js=js, debug_assets=debug_assets, rtl=rtl, assets_params=assets_params, autoprefix=autoprefix)
            // return asset_bundle.get_links()
            */
            return default;
        }

        public async Task<TEntity> GenerateCodeCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, int @ref) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _generate_code_cached(self, ref: int):
            // return self._generate_code_uncached(ref)
            */
            return default;
        }

        public async Task<TEntity> GenerateCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _generate_code(self, template: int | str | etree._Element):
            // """ Compile the given template into a rendering function (generator)::
            // 
            //     render_template(qweb, values)
            // 
            // This method can be called only by :meth:`_render` method or by
            // the compiled code of t-call from an other template.
            // 
            // An ``options`` dictionary is created and attached to the function.
            // It contains rendering options that are part of the cache key in
            // addition to template references.
            // 
            // where ``qweb`` is a QWeb instance and ``values`` are the values to
            // render.
            // 
            // :returns: tuple containing code, options and main method name
            // """
            // if not isinstance(template, (int, str, etree._Element)):
            //     template = str(template)
            // # The `compile_context`` dictionary includes the elements used for the
            // # cache key to which are added the template references as well as
            // # technical information useful for generating the function. This
            // # dictionary is only used when compiling the template.
            // compile_context = self.env.context.copy()
            // 
            // try:
            //     element, document, ref = self._get_template(template)
            // except (ValueError, UserError) as e:
            //     # return the error information if the template is not found or fail
            //     options = {k: compile_context.get(k, False) for k in self._get_template_cache_keys()}
            //     message = str(e)
            //     if hasattr(e, 'context') and e.context.get('view'):
            //         message = f"{message} (view: {e.context['view'].key})"
            //     options['error'] = (e.__class__, message, traceback.format_exc())
            //     return (None, options, 'not_found_template')
            // 
            // compile_context.pop('raise_if_not_found', None)
            // 
            // ref_name = element.attrib.pop('t-name', None)
            // if isinstance(ref, int) or (isinstance(template, str) and '<' not in template):
            //     ref_name = self._get_template_info(ref)['key'] or ref_name
            // 
            // # reference to get xml and etree (usually the template ID)
            // compile_context['ref'] = ref
            // # reference name or key to get xml and etree (usually the template XML ID)
            // compile_context['ref_name'] = ref_name
            // # str xml of the reference template used for compilation. Useful for debugging, dev mode and profiling.
            // compile_context['ref_xml'] = str(document) if document else None
            // # Identifier used to call `_compile`
            // compile_context['template'] = template
            // # Root of the etree which will be processed during compilation.
            // compile_context['root'] = element.getroottree()
            // # Reference to the last node being compiled. It is mainly used for debugging and displaying error messages.
            // compile_context['_qweb_error_path_xml'] = compile_context.get('_qweb_error_path_xml', [None, None, None])
            // 
            // compile_context['nsmap'] = {
            //     ns_prefix: str(ns_definition)
            //     for ns_prefix, ns_definition in compile_context.get('nsmap', {}).items()
            // }
            // 
            // # The options dictionary includes cache key elements and template
            // # references. It will be attached to the generated function. This
            // # dictionary is only there for logs, performance or test information.
            // # The values of these `options` cannot be changed and must always be
            // # identical in `context` and `self.env.context`.
            // options = {
            //     key: compile_context.get(key, False)
            //     for key in self._get_template_cache_keys() + ['ref', 'ref_name']
            // }
            // 
            // # generate code
            // ref_name = compile_context['ref_name'] or ''
            // if isinstance(template, etree._Element):
            //     def_name = TO_VARNAME_REGEXP.sub(r'_', f'template_etree_{next(ETREE_TEMPLATE_REF)}')
            // else:
            //     def_name = TO_VARNAME_REGEXP.sub(r'_', f'template_{ref_name if "<" not in ref_name else ""}_{ref}')
            // 
            // name_gen = count()
            // compile_context['make_name'] = lambda prefix: f"{def_name}_{prefix}_{next(name_gen)}"
            // 
            // if element.text:
            //     element.text = FIRST_RSTRIP_REGEXP.sub(r'\2', element.text)
            // 
            // compile_context['template_functions'] = {}
            // 
            // compile_context['_text_concat'] = []
            // self._append_text("", compile_context)  # To ensure the template function is a generator and doesn't become a regular function
            // compile_context['template_functions'][f'{def_name}_content'] = (
            //     [f"def {def_name}_content(self, values):"]
            //     + self._compile_node(element, compile_context, 2)
            //     + self._flush_text(compile_context, 2, rstrip=True))
            // 
            // compile_context['template_functions'][def_name] = [indent_code(f"""
            //     def {def_name}(self, values):
            //         if 'xmlid' not in values:
            //             values['xmlid'] = {options['ref_name']!r}
            //             values['viewid'] = {options['ref']!r}
            //         self.env.context['__qweb_loaded_functions'].update(template_functions)
            //         self.env.context['__qweb_loaded_options'][{options['ref']!r}] = self.env.context['__qweb_loaded_options'][{options['ref_name']!r}] = template_options
            //         self.env.context['__qweb_loaded_codes'][{options['ref']!r}] = self.env.context['__qweb_loaded_codes'][{options['ref_name']!r}] = code
            //         yield from {def_name}_content(self, values)
            //         """, 0)]
            // 
            // code_lines = []
            // code_lines.append(f'template_options = {pprint.pformat(options, indent=4)}')
            // code_lines.append('code = None')
            // code_lines.append('template_functions = {}')
            // 
            // for lines in compile_context['template_functions'].values():
            //     code_lines.extend(lines)
            // 
            // for name in compile_context['template_functions']:
            //     code_lines.append(f'template_functions[{name!r}] = {name}')
            // 
            // code = '\n'.join(code_lines)
            // 
            // if options.get('profile'):
            //     options['ref_xml'] = compile_context['ref_xml']
            // 
            // return (code, options, def_name)
            */
            return default;
        }

        public async Task<TEntity> GenerateCodeUncachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _generate_code_uncached(self, template: int | str | etree._Element):
            // ref = self._get_template_info(template)['id'] if isinstance(template, (int, str)) else None
            // 
            // code, options, def_name = self._generate_code(template)
            // 
            // if code is None:
            //     Error, message, stack = options['error']
            // 
            //     def not_found_template(self, values):
            //         if tools.config['dev_mode']:
            //             _logger.info(stack)
            //         if self.env.context.get('raise_if_not_found', True):
            //             raise Error(message)
            //         _logger.warning('Cannot load template %s: %s', template, message)
            //         return ''
            // 
            //     return {'not_found_template': not_found_template}, 'not_found_template', frozendict(options)
            // 
            // wrap_code = '\n'.join([
            //     "def generate_functions():",
            //     indent_code(code, 1),
            //     f"    code = {code!r}",
            //     "    return template_functions",
            // ])
            // compiled = compile(wrap_code, f"<{ref}>", 'exec')
            // globals_dict = self.__prepare_globals()
            // globals_dict['__builtins__'] = globals_dict  # So that unknown/unsafe builtins are never added.
            // unsafe_eval(compiled, globals_dict)
            // return globals_dict['generate_functions'](), def_name, frozendict(options)
            */
            return default;
        }

        public async Task<TEntity> GetAssetBundleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle_name, object css, object js, object debug_assets, object rtl, object assets_params, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_asset_bundle(self, bundle_name, css=True, js=True, debug_assets=False, rtl=False, assets_params=None, autoprefix=False):
            // if assets_params is None:
            //     assets_params = self.env['ir.asset']._get_asset_params()
            // files, external_assets = self._get_asset_content(bundle_name, assets_params)
            // return AssetsBundle(bundle_name, files, external_assets, env=self.env, css=css, js=js, debug_assets=debug_assets, rtl=rtl, assets_params=assets_params, autoprefix=autoprefix)
            */
            return default;
        }

        public async Task<TEntity> GetAssetContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object assets_params) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_asset_content(self, bundle, assets_params=None):
            // if assets_params is None:
            //     assets_params = self.env['ir.asset']._get_asset_params()  # website_id
            // asset_paths = self.env['ir.asset']._get_asset_paths(bundle=bundle, assets_params=assets_params)
            // files = []
            // external_asset = []
            // for path, full_path, _bundle, last_modified in asset_paths:
            //     if full_path is not EXTERNAL_ASSET:
            //         files.append({
            //             'url': path,
            //             'filename': full_path,
            //             'content': '',
            //             'last_modified': last_modified,
            //         })
            //     else:
            //         external_asset.append(path)
            // return (files, external_asset)
            */
            return default;
        }

        public async Task<TEntity> GetAssetLinkUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object debug) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_asset_link_urls(self, bundle, debug=False):
            // asset_nodes = self._get_asset_nodes(bundle, js=False, debug=debug)
            // return [node[1]['href'] for node in asset_nodes if node[0] == 'link']
            */
            return default;
        }

        public async Task<TEntity> GetAssetLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object debug, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_asset_links(self, bundle, css=True, js=True, debug=None, autoprefix=False):
            // """Generates asset nodes.
            // If debug=assets, the assets will be regenerated when a file which composes them has been modified.
            // Else, the assets will be generated only once and then stored in cache.
            // """
            // rtl = self.env['res.lang'].sudo()._get_data(code=(self.env.lang or self.env.user.lang)).direction == 'rtl'
            // assets_params = self.env['ir.asset']._get_asset_params() # website_id
            // debug_assets = debug and 'assets' in debug
            // 
            // if debug_assets:
            //     return self._generate_asset_links(bundle, css=css, js=js, debug_assets=True, assets_params=assets_params, rtl=rtl, autoprefix=autoprefix)
            // else:
            //     return self._generate_asset_links_cache(bundle, css=css, js=js, assets_params=assets_params, rtl=rtl, autoprefix=autoprefix)
            */
            return default;
        }

        public async Task<TEntity> GetAssetNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bundle, object css, object js, object debug, object defer_load, object lazy_load, object media, object autoprefix) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_asset_nodes(self, bundle, css=True, js=True, debug=False, defer_load=False, lazy_load=False, media=None, autoprefix=False):
            // """Generates asset nodes.
            // If debug=assets, the assets will be regenerated when a file which composes them has been modified.
            // Else, the assets will be generated only once and then stored in cache.
            // """
            // media = css and media or None
            // links = self._get_asset_links(bundle, css=css, js=js, debug=debug, autoprefix=autoprefix)
            // return self._links_to_nodes(links, defer_load=defer_load, lazy_load=lazy_load, media=media)
            */
            return default;
        }

        public async Task<TEntity> GetBundlesToPregenarateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb.py) ---
            // def _get_bundles_to_pregenarate(self):
            // js_assets, css_assets = super()._get_bundles_to_pregenarate()
            // assets = {
            //     'website.assets_all_wysiwyg',
            // }
            // return (js_assets | assets, css_assets | assets)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_bundles_to_pregenarate(self):
            // """
            // Returns the list of bundles to pregenerate.
            // """
            // 
            // views = self.env['ir.ui.view'].search([('type', '=', 'qweb'), ('arch_db', 'like', 't-call-assets')])
            // js_bundles = set()
            // css_bundles = set()
            // for view in views:
            //     for call_asset in etree.fromstring(view.arch_db).xpath("//*[@t-call-assets]"):
            //         asset = call_asset.get('t-call-assets')
            //         js = str2bool(call_asset.get('t-js', 'True'))
            //         css = str2bool(call_asset.get('t-css', 'True'))
            //         if js:
            //             js_bundles.add(asset)
            //         if css:
            //             css_bundles.add(asset)
            // return (js_bundles, css_bundles)
            #endif
            return default;
        }

        public async Task<TEntity> GetConvertedImageDataUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base64_source) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_converted_image_data_uri(self, base64_source):
            // if self.env.context.get('webp_as_jpg'):
            //     mimetype = FILETYPE_BASE64_MAGICWORD.get(base64_source[:1], 'png')
            //     if 'webp' in mimetype:
            //         # Use converted image so that is recognized by wkhtmltopdf.
            //         bin_source = base64.b64decode(base64_source)
            //         Attachment = self.env['ir.attachment']
            //         checksum = Attachment._compute_checksum(bin_source)
            //         origins = Attachment.sudo().search([
            //             ['id', '!=', False],  # No implicit condition on res_field.
            //             ['checksum', '=', checksum],
            //         ])
            //         if origins:
            //             converted_domain = [
            //                 ['id', '!=', False],  # No implicit condition on res_field.
            //                 ['res_model', '=', 'ir.attachment'],
            //                 ['res_id', 'in', origins.ids],
            //                 ['mimetype', '=', 'image/jpeg'],
            //             ]
            //             converted = Attachment.sudo().search(converted_domain, limit=1)
            //             if converted:
            //                 base64_source = converted.datas
            // return image_data_uri(base64_source)
            */
            return default;
        }

        public async Task<object> GetErrorInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error, List<object> stack, object frame) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_error_info(self, error, stack: list[QwebStackFrame], frame: QwebStackFrame) -> QWebErrorInfo:
            // no_id_ref = 'etree._Element'
            // 
            // path = None
            // html = None
            // loaded_codes = self.env.context['__qweb_loaded_codes']
            // if (frame.params.view_ref in loaded_codes and not isinstance(error, RecursionError)) or len(stack) <= 1:
            //     options = frame.options or {}  # The compilation may have failed before the compilation options were loaded.
            //     if 'ref' not in options:
            //         options = self.env.context['__qweb_loaded_options'].get(frame.params.view_ref) or {}
            //     ref = options.get('ref') or frame.params.view_ref  # The template can have a null reference, for example for a provided etree.
            //     ref_name = options.get('ref_name') or None
            //     code = loaded_codes.get(frame.params.view_ref) or loaded_codes.get(no_id_ref)
            //     if ref == self.env.context['_qweb_error_path_xml'][0]:
            //         path = self.env.context['_qweb_error_path_xml'][1]
            //         html = self.env.context['_qweb_error_path_xml'][2]
            // else:
            //     # get the previous caller (like t-call) to display erroneous xml node.
            //     options = stack[-2].options or {}  # The compilation may have failed before the compilation options were loaded.
            //     ref = options.get('ref')
            //     ref_name = options.get('ref_name')
            //     code = loaded_codes.get(ref) or loaded_codes.get(no_id_ref)
            //     if frame.params.path_xml:
            //         path = frame.params.path_xml[1]
            //         html = frame.params.path_xml[2]
            // 
            // source_file_ref = None if ref == no_id_ref else ref
            // line_nb = 0
            // trace = traceback.format_exc()
            // for error_line in reversed(trace.split('\n')):
            //     if f'File "<{source_file_ref}>"' in error_line or (ref is None and 'File "<' in error_line):
            //         line_function = error_line.split(', line ')[1]
            //         line_nb = int(line_function.split(',')[0])
            //         break
            // 
            // source = [info.params.path_xml for info in stack if info.params.path_xml]
            // code_lines = (code or '').split('\n')
            // 
            // found = False
            // for code_line in reversed(code_lines[:line_nb]):
            //     if code_line.startswith('def '):
            //         break
            //     match = re.match(r'\s*# element: (.*) , (.*)', code_line)
            //     if not match:
            //         if found:
            //             break
            //         continue
            //     if found:
            //         info = (ref, match[1][1:-1], match[2][1:-1])
            //         if info not in source:
            //             source.append(info)
            //     else:
            //         found = True
            //         path = match[1][1:-1]
            //         html = match[2][1:-1]
            // 
            // if path:
            //     source.append((ref, path, html))
            // 
            // surrounding = None
            // if self.env.context.get('dev_mode') and line_nb:
            //     if html and ' t-if=' in html and ' if ' in '\n'.join(code_lines[line_nb - 2:line_nb - 1]):
            //         line_nb -= 1
            //     previous_lines = '\n'.join(code_lines[max(line_nb - 25, 0):line_nb - 1])
            //     line = code_lines[line_nb - 1]
            //     next_lines = '\n'.join(code_lines[line_nb:line_nb + 5])
            //     indent = re.search(r"^(\s*)", line).group(0)
            //     surrounding = textwrap.indent(
            //         textwrap.dedent(
            //             f"{previous_lines}\n"
            //             f"{indent}########### Line triggering the error ############\n{line}\n"
            //             f"{indent}##################################################\n{next_lines}"
            //         ),
            //         ' ' * 8
            //     )
            // 
            // return QWebErrorInfo(f'{error.__class__.__name__}: {error}', ref if ref_name is None else ref_name, ref, path, html, source, surrounding)
            */
            return default;
        }

        public async Task<TEntity> GetFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object expression, object tagName, object field_options, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_field(self, record, field_name, expression, tagName, field_options, values):
            // """Method called at compile time to return the field value.
            // 
            // :returns: tuple:
            //     * dict: attributes
            //     * string or None: content
            //     * boolean: force_display display the tag if the content and default_content are None
            // """
            // field = record._fields[field_name]
            // 
            // # adds generic field options
            // field_options['tagName'] = tagName
            // field_options['expression'] = expression
            // field_options['type'] = field_options.get('widget', field.type)
            // inherit_branding = (
            //         self.env.context['inherit_branding']
            //         if 'inherit_branding' in self.env.context
            //         else self.env.context.get('inherit_branding_auto') and record.has_access('write'))
            // field_options['inherit_branding'] = inherit_branding
            // translate = self.env.context.get('edit_translations') and values.get('translatable') and field.translate
            // field_options['translate'] = translate
            // 
            // # field converter
            // model = 'ir.qweb.field.' + field_options['type']
            // converter = self.env[model] if model in self.env else self.env['ir.qweb.field']
            // 
            // # get content (the return values from fields are considered to be markup safe)
            // content = converter.record_to_html(record, field_name, field_options)
            // attributes = converter.attributes(record, field_name, field_options, values)
            // 
            // return (attributes, content, inherit_branding or translate)
            */
            return default;
        }

        public async Task<TEntity> GetPreloadAttributeXmlidsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _get_preload_attribute_xmlids(self):
            // return super()._get_preload_attribute_xmlids() + ['t-snippet', 't-snippet-call']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_preload_attribute_xmlids(self):
            // return ['t-call']
            */
            return default;
        }

        public async Task<TEntity> GetTemplateCacheKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_qweb_fields.py) ---
            // def _get_template_cache_keys(self):
            // return super()._get_template_cache_keys() + ['snippet_lang']
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py) ---
            // def _get_template_cache_keys(self):
            // return super()._get_template_cache_keys() + ["raise_on_forbidden_code_for_model"]
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb.py) ---
            // def _get_template_cache_keys(self):
            // """ Return the list of context keys to use for caching ``_compile``. """
            // return super()._get_template_cache_keys() + ['website_id', 'cookies_allowed']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_template_cache_keys(self):
            // """ Return the list of context keys to use for caching ``_compile``. """
            // return ['lang', 'inherit_branding', 'inherit_branding_auto', 'edit_translations', 'profile']
            */
            return default;
        }

        public async Task<TEntity> GetTemplateInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_template_info(self, template):
            // return self.env['ir.ui.view']._get_cached_template_info(template)
            */
            return default;
        }

        public async Task<TEntity> GetTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb.py) ---
            // def _get_template(self, template):
            // element, document, ref = super()._get_template(template)
            // if self.env.context.get('website_id'):
            //     add_form_signature(element, self.sudo().env)
            // return element, document, ref
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_template(self, template):
            // """ Retrieve the given template, and return it as a tuple ``(etree,
            // xml, ref)``, where ``element`` is an etree, ``document`` is the
            // string document that contains ``element``, and ``ref`` if the uniq
            // reference of the template (id, t-name or template).
            // 
            // :param template: template identifier or etree
            // """
            // assert template not in (False, None, ""), "template is required"
            // 
            // # template is an xml etree already
            // if isinstance(template, etree._Element):
            //     element = template
            //     document = etree.tostring(template, encoding='unicode')
            // 
            //     # <templates>
            //     #   <template t-name=... /> <!-- return ONLY this element -->
            //     #   <template t-name=... />
            //     # </templates>
            //     for node in element.iter():
            //         ref = node.get('t-name')
            //         if ref:
            //             return (node, document, _id_or_xmlid(ref))
            // 
            //     return (element, document, 'etree._Element')
            // 
            // # template is xml as string
            // if isinstance(template, str) and '<' in template:
            //     raise ValueError('Inline templates must be passed as `etree` documents')
            // 
            // # template is (id or ref) to a database stored template
            // id_or_xmlid = _id_or_xmlid(template)  # e.g. <t t-call="33"/> or <t t-call="web.layout"/>
            // value = self._preload_trees([id_or_xmlid]).get(id_or_xmlid)
            // if value.get('error'):
            //     raise value['error']
            // 
            // # In dev mode `_generate_code_cached` is not cached and the tree can be processed several times
            // value_tree = deepcopy(value['tree']) if 'xml' in tools.config['dev_mode'] else value['tree']
            // # return etree, document and ref
            // return (value_tree, value['template'], value['ref'])
            */
            return default;
        }

        public async Task<TEntity> GetWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object expression, object tagName, object field_options, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _get_widget(self, value, expression, tagName, field_options, values):
            // """Method called at compile time to return the widget value.
            // 
            // :returns: tuple:
            //     * dict: attributes
            //     * string or None: content
            //     * boolean: force_display display the tag if the content and default_content are None
            // """
            // field_options['type'] = field_options['widget']
            // field_options['tagName'] = tagName
            // field_options['expression'] = expression
            // inherit_branding = self.env.context.get('inherit_branding')
            // field_options['inherit_branding'] = inherit_branding
            // 
            // # field converter
            // model = 'ir.qweb.field.' + field_options['type']
            // converter = self.env[model] if model in self.env else self.env['ir.qweb.field']
            // 
            // # get content (the return values from widget are considered to be markup safe)
            // content = converter.value_to_html(value, field_options)
            // attributes = {}
            // attributes['data-oe-type'] = field_options['type']
            // attributes['data-oe-expression'] = field_options['expression']
            // 
            // return (attributes, content, inherit_branding)
            */
            return default;
        }

        public async Task<TEntity> IsExpressionAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expression, object model) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_qweb.py) ---
            // def _is_expression_allowed(self, expression, model):
            // return model and expression.strip() in self.env[model].mail_allowed_qweb_expressions()
            */
            return default;
        }

        public async Task<TEntity> IsStaticNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object el, object compile_context) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _is_static_node(self, el, compile_context):
            // """ Test whether the given element is purely static, i.e. (there
            // are no t-* attributes), does not require dynamic rendering for its
            // attributes.
            // """
            // return el.tag != 't' and 'groups' not in el.attrib and not any(
            //     att.startswith('t-') and att not in ('t-tag-open', 't-inner-content')
            //     for att in el.attrib
            // )
            */
            return default;
        }

        public async Task<TEntity> LinkToNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object path, object defer_load, object lazy_load, object media) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _link_to_node(self, path, defer_load=False, lazy_load=False, media=None):
            // ext = path.rsplit('.', maxsplit=1)[-1] if path else 'js'
            // is_js = ext in SCRIPT_EXTENSIONS
            // is_xml = ext in TEMPLATE_EXTENSIONS
            // is_css = ext in STYLE_EXTENSIONS
            // 
            // if is_js:
            //     is_asset_bundle = path and path.startswith('/web/assets/')
            //     attributes = {
            //         'type': 'text/javascript',
            //     }
            // 
            //     if defer_load:
            //         # Note that "lazy_load" will lead to "defer" being added in JS,
            //         # not here, otherwise this is not W3C valid (defer is probably
            //         # not even needed there anyways). See LAZY_LOAD_DEFER.
            //         attributes['defer'] = 'defer'
            //     if path:
            //         if lazy_load:
            //             attributes['data-src'] = path
            //         else:
            //             attributes['src'] = path
            // 
            //     if is_asset_bundle:
            //         attributes['onerror'] = "__odooAssetError=1"
            // 
            //     return ('script', attributes)
            // 
            // if is_css:
            //     attributes = {
            //         'type': f'text/{ext}',  # we don't really expect to have anything else than pure css here
            //         'rel': 'stylesheet',
            //         'href': path,
            //         'media': media,
            //     }
            //     return ('link', attributes)
            // 
            // if is_xml:
            //     attributes = {
            //         'type': 'text/xml',
            //         'async': 'async',
            //         'rel': 'prefetch',
            //         'data-src': path,
            //         }
            //     return ('script', attributes)
            // 
            // return None
            */
            return default;
        }

        public async Task<TEntity> LinksToNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object paths, object defer_load, object lazy_load, object media) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _links_to_nodes(self, paths, defer_load=False, lazy_load=False, media=None):
            // return [self._link_to_node(path, defer_load=defer_load, lazy_load=lazy_load, media=media) for path in paths]
            */
            return default;
        }

        public async Task<TEntity> PostProcessingAttInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tagName, object atts) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb.py) ---
            // def _post_processing_att(self, tagName, atts):
            // if atts.get('data-no-post-process'):
            //     return atts
            // 
            // atts = super()._post_processing_att(tagName, atts)
            // 
            // website = ir_http.get_request_website()
            // if not website and self.env.context.get('website_id'):
            //     website = self.env['website'].browse(self.env.context['website_id'])
            // if website and tagName == 'img' and 'loading' not in atts:
            //     atts['loading'] = 'lazy'  # default is auto
            // 
            // if self.env.context.get('inherit_branding') or self.env.context.get('rendering_bundle') or \
            //    self.env.context.get('edit_translations') or self.env.context.get('debug') or (request and request.session.debug):
            //     return atts
            // 
            // if not website:
            //     return atts
            // 
            // if (
            //     website.cookies_bar
            //     and website.block_third_party_domains
            //     and not self.env.context.get('cookies_allowed')
            //     and not request.env.user.has_group('website.group_website_restricted_editor')
            // ):
            //     # If the cookie banner is activated, 3rd-party embedded iframes and
            //     # scripts should be controlled. As such:
            //     # - 'domains' is a watchlist on the iframe/script's src itself,
            //     # - 'classes' is a watchlist on container elements in which iframes
            //     # are/could be built on the fly client-side for some reason.
            //     cookies_watchlist = {
            //         'domains': website.blocked_third_party_domains.split('\n'),
            //         'classes': website._get_blocked_iframe_containers_classes(),
            //     }
            //     remove_src = False
            //     if tagName in ('iframe', 'script'):
            //         src_host = urlsplit((atts.get('src') or '').lower()).hostname
            //         if src_host:
            //             remove_src = any(
            //                 # "www.example.com" and "example.com" should block both.
            //                 src_host == domain.removeprefix('www.')
            //                 # "domain.com" should block "subdomain.domain.com", but
            //                 # not "(subdomain.)mydomain.com".
            //                 or src_host.endswith('.' + domain.removeprefix('www.'))
            //                 for domain in cookies_watchlist['domains']
            //             )
            //     if (
            //         remove_src
            //         or cookies_watchlist['classes'].intersection((atts.get('class') or '').split(' '))
            //     ):
            //         atts['data-need-cookies-approval'] = 'true'
            //         # Case class in watchlist: we stop here. The element could
            //         # contain an iframe created on the fly client-side. It is marked
            //         # now so that the iframe can be marked later when created.
            //         # Case iframe/script's src in watchlist: we adapt the src.
            //         if 'src' in atts:
            //             atts['data-nocookie-src'] = atts['src']
            //             atts['src'] = 'about:blank'
            // 
            // name = self.URL_ATTRS.get(tagName)
            // if request:
            //     value = atts.get(name) if name else None
            //     if value not in (None, False, ()):
            //         atts[name] = self.env['ir.http']._url_for(str(value))
            // 
            //     # Adapt background-image URL in the same way as image src.
            //     atts = self._adapt_style_background_image(atts, self.env['ir.http']._url_for)
            // 
            // if not website.cdn_activated:
            //     return atts
            // 
            // data_name = f'data-{name}'
            // if name and (name in atts or data_name in atts):
            //     atts = OrderedDict(atts)
            //     if name in atts and atts[name] not in (False, None, ()):
            //         atts[name] = website.get_cdn_url(atts[name])
            //     if data_name in atts and atts[data_name] not in (False, None, ()):
            //         atts[data_name] = website.get_cdn_url(atts[data_name])
            // atts = self._adapt_style_background_image(atts, website.get_cdn_url)
            // 
            // return atts
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _post_processing_att(self, tagName, atts):
            // """ Method called at compile time for the static node and called at
            //     runing time for the dynamic attributes.
            // 
            //     This method may be overwrited to filter or modify the attributes
            //     (during compilation for static node or after they compilation in
            //     the case of dynamic elements).
            // 
            //     @returns dict
            // """
            // if not atts.pop('__is_static_node', False) and (href := atts.get('href')) and MALICIOUS_SCHEMES(str(href)):
            //     atts['href'] = ""
            // return atts
            */
            return default;
        }

        public async Task<TEntity> PregenerateAssetsBundlesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _pregenerate_assets_bundles(self):
            // """
            // Pregenerates all assets that may be used in web pages to speedup first loading.
            // This may is mainly usefull for tests.
            // 
            // The current version is looking for all t-call-assets in view to generate the minimal
            // set of bundles to generate.
            // 
            // Current version only generate assets without extra, not taking care of rtl.
            // """
            // _logger.runbot('Pregenerating assets bundles')
            // 
            // js_bundles, css_bundles = self._get_bundles_to_pregenarate()
            // 
            // links = []
            // start = time.time()
            // for bundle in sorted(js_bundles):
            //     links += self._get_asset_bundle(bundle, css=False, js=True).js()
            // _logger.info('JS Assets bundles generated in %s seconds', time.time()-start)
            // start = time.time()
            // for bundle in sorted(css_bundles):
            //     links += self._get_asset_bundle(bundle, css=True, js=False).css()
            // _logger.info('CSS Assets bundles generated in %s seconds', time.time()-start)
            // return links
            */
            return default;
        }

        public async Task<TEntity> PreloadTreesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refs) where TEntity : IEntity<Guid>, IIrQwebable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _preload_trees(self, refs: Sequence[int | str]):
            // """ Preload all tree and subtree (from t-call and other '_get_preload_attribute_xmlids' values).
            // 
            //     Returns::
            // 
            //         {
            //             id or xmlId/key: {
            //                 'xmlid': str | None,
            //                 'ref': int | None,
            //                 'tree': etree | None,
            //                 'template': str | None,
            //                 'error': None | MissingError
            //             }
            //         }
            // """
            // compile_batch = self.env['ir.ui.view']._preload_views(refs)
            // 
            // refs = list(map(_id_or_xmlid, refs))
            // missing_refs = {ref: compile_batch[ref] for ref in refs if 'template' not in compile_batch[ref] and not compile_batch[ref]['error']}
            // if not missing_refs:
            //     return compile_batch
            // 
            // xmlids = list(missing_refs)
            // missing_refs_values = list(missing_refs.values())
            // views = self.env['ir.ui.view'].sudo().union(*[data['view'] for data in missing_refs_values])
            // 
            // trees = views._get_view_etrees()
            // 
            // # add in cache
            // for xmlid, view, tree in zip(xmlids, views, trees):
            //     data = {
            //         'tree': tree,
            //         'template': etree.tostring(tree, encoding='unicode'),
            //     }
            //     compile_batch[view.id].update(data)
            //     compile_batch[xmlid].update(data)
            // 
            // # preload sub template
            // ref_names = self._get_preload_attribute_xmlids()
            // sub_refs = OrderedSet()
            // for tree in trees:
            //     sub_refs.update(
            //         el.get(ref_name)
            //         for ref_name in ref_names
            //         for el in tree.xpath(f'//*[@{ref_name}]')
            //         if not any(att.startswith('t-options-') or att == 't-options' or att == 't-lang' for att in el.attrib)
            //         if '{' not in el.get(ref_name) and '<' not in el.get(ref_name) and '/' not in el.get(ref_name)
            //     )
            // assert not any(not f for f in sub_refs), "template is required"
            // self._preload_trees(list(sub_refs))
            // 
            // # not found template
            // for ref in missing_refs:
            //     if ref not in compile_batch:
            //         compile_batch[ref] = {
            //             'xmlid': ref,
            //             'ref': ref,
            //             'error': MissingError(self.env._("External ID can not be loaded: %s", ref)),
            //         }
            // 
            // return compile_batch
            #endif
            return default;
        }

        public async Task<TEntity> PrepareEnvironmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_qweb.py) ---
            // def _prepare_environment(self, values):
            // irQweb = super()._prepare_environment(values)
            // values['slug'] = self.env['ir.http']._slug
            // values['unslug_url'] = self.env['ir.http']._unslug_url
            // 
            // if not irQweb.env.context.get('minimal_qcontext') and request:
            //     if not hasattr(request, 'is_frontend'):
            //         _logger.warning(BAD_REQUEST, stack_info=True)
            //     elif request.is_frontend:
            //         return irQweb._prepare_frontend_environment(values)
            // 
            // return irQweb
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _prepare_environment(self, values):
            // """ Prepare the values and context that will sent to the
            // compiled and evaluated function.
            // 
            // :param values: template values to be used for rendering
            // 
            // :returns self (with new context)
            // """
            // debug = request and request.session.debug or ''
            // values.update(
            //     true=True,
            //     false=False,
            // )
            // if not self.env.context.get('minimal_qcontext'):
            //     values.setdefault('debug', debug)
            //     values.setdefault('user_id', self.env.user.with_env(self.env))
            //     values.setdefault('res_company', self.env.company.sudo())
            //     values.update(
            //         request=request,  # might be unbound if we're not in an httprequest context
            //         test_mode_enabled=config['test_enable'],
            //         json=qwebJSON,
            //         quote_plus=werkzeug.urls.url_quote_plus,
            //         time=safe_eval.time,
            //         datetime=safe_eval.datetime,
            //         relativedelta=relativedelta,
            //         image_data_uri=self._get_converted_image_data_uri,
            //         # specific 'math' functions to ease rounding in templates and lessen controller marshmalling
            //         floor=math.floor,
            //         ceil=math.ceil,
            //         env=self.env,
            //         lang=self.env.context.get('lang'),
            //         keep_query=keep_query,
            //     )
            // 
            // context = {'dev_mode': 'qweb' in tools.config['dev_mode']}
            // return self.with_context(**context)
            */
            return default;
        }

        public async Task<TEntity> PrepareFrontendEnvironmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_qweb.py) ---
            // def _prepare_frontend_environment(self, values):
            // values['url_for'] = self.env['ir.http']._url_for
            // values['url_localized'] = self.env['ir.http']._url_localized
            // return self
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: ir_qweb.py) ---
            // def _prepare_frontend_environment(self, values):
            // """ Returns ir.qweb with context and update values with portal specific
            //     value (required to render portal layout template)
            // """
            // irQweb = super()._prepare_frontend_environment(values)
            // values.update(
            //     is_html_empty=is_html_empty,
            //     frontend_languages=lazy(lambda: irQweb.env['res.lang']._get_frontend())
            // )
            // for key in irQweb.env.context:
            //     if key not in values:
            //         values[key] = irQweb.env.context[key]
            // 
            // return irQweb
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_qweb.py) ---
            // def _prepare_frontend_environment(self, values):
            // """ Update the values and context with website specific value
            //     (required to render website layout template)
            // """
            // irQweb = super()._prepare_frontend_environment(values)
            // 
            // current_website = request.website
            // editable = irQweb.env.user.has_group('website.group_website_designer')
            // has_group_restricted_editor = irQweb.env.user.has_group('website.group_website_restricted_editor')
            // if not editable and has_group_restricted_editor and 'main_object' in values:
            //     try:
            //         main_object = values['main_object'].with_user(irQweb.env.user.id)
            //         current_website._check_user_can_modify(main_object)
            //         editable = True
            //     except AccessError:
            //         pass
            // translatable = has_group_restricted_editor and irQweb.env.context.get('lang') != irQweb.env['ir.http']._get_default_lang().code
            // editable = editable and not translatable
            // 
            // if has_group_restricted_editor and irQweb.env.user.has_group('website.group_multi_website'):
            //     values['multi_website_websites_current'] = lazy(lambda: current_website.name)
            //     values['multi_website_websites'] = lazy(lambda: [
            //         {'website_id': website.id, 'name': website.name, 'domain': website.domain}
            //         for website in current_website.search([('id', '!=', current_website.id)])
            //     ])
            // 
            //     cur_company = irQweb.env.company
            //     values['multi_website_companies_current'] = lazy(lambda: {'company_id': cur_company.id, 'name': cur_company.name})
            //     values['multi_website_companies'] = lazy(lambda: [
            //         {'company_id': comp.id, 'name': comp.name}
            //         for comp in irQweb.env.user.company_ids if comp != cur_company
            //     ])
            // 
            // # update values
            // 
            // values.update(dict(
            //     website=current_website,
            //     is_view_active=lazy(lambda: current_website.is_view_active),
            //     res_company=lazy(request.env['res.company'].browse(current_website._get_cached('company_id')).sudo),
            //     translatable=translatable,
            //     editable=editable,
            // ))
            // 
            // if editable:
            //     # form editable object, add the backend configuration link
            //     if 'main_object' in values and has_group_restricted_editor:
            //         func = getattr(values['main_object'], 'get_backend_menu_id', False)
            //         values['backend_menu_id'] = lazy(lambda: func and func() or irQweb.env['ir.model.data']._xmlid_to_res_id('website.menu_website_configuration'))
            // 
            // # update options
            // 
            // irQweb = irQweb.with_context(website_id=current_website.id)
            // if 'inherit_branding' not in irQweb.env.context and not self.env.context.get('rendering_bundle'):
            //     if editable:
            //         # in edit mode add branding on ir.ui.view tag nodes
            //         irQweb = irQweb.with_context(inherit_branding=True)
            //     elif has_group_restricted_editor:
            //         # will add the branding on fields (into values)
            //         irQweb = irQweb.with_context(inherit_branding_auto=True)
            // 
            // # Avoid cache inconsistencies: if the cookies have been accepted, the
            // # DOM structure should reflect it after a reload and not be stuck in its
            // # previous state (see the part related to cookies in
            // # `_post_processing_att`).
            // is_allowed_optional_cookies = request.env['ir.http']._is_allowed_cookie('optional')
            // irQweb = irQweb.with_context(cookies_allowed=is_allowed_optional_cookies)
            // 
            // return irQweb
            */
            return default;
        }

        public async Task<object> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _render(self, template: int | str | etree._Element, values: dict | None = None, **options) -> Markup:
            // """ Render the template specified by the given name.
            // 
            // :param template: etree, xml_id, template name (see _get_template)
            //     * Call the method ``load`` is not an etree.
            // :param dict values: template values to be used for rendering
            // :param options: used to compile the template
            //     Options will be add into the IrQweb.env.context for the rendering.
            // 
            //     * ``lang`` (str) used language to render the template
            //     * ``inherit_branding`` (bool) add the tag node branding
            //     * ``inherit_branding_auto`` (bool) add the branding on fields
            //     * ``minimal_qcontext``(bool) To use the minimum context and options
            //       from ``_prepare_environment``
            // 
            // :returns: bytes marked as markup-safe (decode to :class:`markupsafe.Markup`
            //           instead of `str`)
            // :rtype: MarkupSafe
            // """
            // # profiling code
            // current_thread = threading.current_thread()
            // execution_context_enabled = getattr(current_thread, 'profiler_params', {}).get('execution_context_qweb')
            // qweb_hooks = getattr(current_thread, 'qweb_hooks', ())
            // if execution_context_enabled or qweb_hooks:
            //     # To have the new compilation cached because the generated code will change.
            //     # Therefore 'profile' is a key to the cache.
            //     options['profile'] = True
            // 
            // values = values.copy() if values else {}
            // if T_CALL_SLOT in values:
            //     _logger.warning('values[0] should be unset when call the _render method and only set into the template.')
            //     values.pop(T_CALL_SLOT)
            // 
            // irQweb = self.with_context(**options)._prepare_environment(values)
            // irQweb = irQweb.with_context(
            //     # List of generated and/or used functions, used for optimal performance
            //     __qweb_loaded_functions={},
            //     # List of codes generated during compilation. It is mainly used for debugging and displaying error messages.
            //     __qweb_loaded_codes={},
            //     __qweb_loaded_options={},
            //     # Reference to the last node being compiled. It is mainly used for debugging and displaying error messages.
            //     _qweb_error_path_xml=[None, None, None],
            // )
            // 
            // safe_eval.check_values(values)
            // 
            // root_values = values.copy()
            // values['__qweb_root_values'] = root_values['__qweb_root_values'] = root_values
            // 
            // iterator = irQweb._render_iterall(template, None, values)
            // return Markup(''.join(iterator))
            */
            return default;
        }

        public async Task<TEntity> RenderIterallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_ref, object method, object values, object directive) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _render_iterall(self, view_ref, method, values, directive='render') -> Iterator[str]:
            // """ Iterate over the generator method.
            //     Generator elements are a str
            // """
            // root_values = values['__qweb_root_values']
            // loaded_functions = self.env.context['__qweb_loaded_functions']
            // 
            // params = QwebCallParameters(
            //     context={},
            //     view_ref=view_ref,
            //     method=method,
            //     values=None,
            //     scope=False,
            //     directive=directive,
            //     path_xml=None,
            // )
            // stack = [QwebStackFrame(params, self, iter([params]), values, None)]
            // 
            // try:
            //     while stack:
            //         if len(stack) > 50:
            //             raise RecursionError('Qweb template infinite recursion')  # noqa: TRY301
            // 
            //         frame = stack[-1]
            // 
            //         # traverse the iterator
            //         for item in frame.iterator:
            //             # To debug the rendering step by step you can log the (len(stack) * '  ', repr(item))
            //             if isinstance(item, str):
            //                 yield item
            //                 continue
            // 
            //             # use QwebContent params or return already evaluated QwebContent
            //             if is_content := isinstance(item, QwebContent):
            //                 if item.html is not None:
            //                     yield item.html
            //                     continue
            //                 params = item.params__
            // 
            //             else:  # isinstance(item, QwebCallParameters)
            //                 params = item
            // 
            //             # add new QwebStackFrame from QwebCallParameters
            //             values = frame.values
            //             irQweb = frame.irQweb
            // 
            //             # Use the current directive context
            //             if params.context:
            //                 irQweb = irQweb.with_context(**params.context)
            // 
            //             render_template = loaded_functions.get(params.method)
            // 
            //             # Fetch the compiled function and template options
            //             if not render_template:
            //                 template_functions, def_name, options = irQweb._compile(params.view_ref)
            //                 loaded_functions.update(template_functions)
            //                 render_template = template_functions[params.method or def_name]
            //             else:
            //                 options = irQweb._compile(params.view_ref)[2]
            // 
            //             # Apply a new scope if needed
            //             if params.scope:
            //                 if params.scope == 'root':
            //                     values = root_values
            //                 values = values.copy()
            // 
            //             # Update values with default values
            //             if params.values:
            //                 values.update(params.values)
            // 
            //             iterator = iter([])
            //             try:
            //                 # Create the iterator from the template
            //                 iterator = render_template(irQweb, values)
            //             finally:
            //                 if is_content and self.env.context['_qweb_error_path_xml'][1]:
            //                     # add a stack frame to log a complete error with the path when compile the template
            //                     logParams = QwebCallParameters(*(params[0:-1] + (tuple(self.env.context['_qweb_error_path_xml']),)))
            //                     stack.append(QwebStackFrame(logParams, irQweb, [], values, options))
            //                 stack.append(QwebStackFrame(params, irQweb, iterator, values, options))
            //             break
            // 
            //         else:
            //             stack.pop()
            // 
            // except (TransactionRollbackError, ReadOnlySqlTransaction):
            //     raise
            // 
            // except Exception as error:
            //     qweb_error_info = self._get_error_info(error, stack, stack[-1])
            //     if qweb_error_info.template is None and qweb_error_info.ref is None:
            //         qweb_error_info.ref = view_ref
            // 
            //     if hasattr(error, 'qweb'):
            //         if qweb_error_info.source:
            //             error.qweb.source = qweb_error_info.source + error.qweb.source
            //         if not error.qweb.ref and frame.params.view_ref:
            //             error.qweb.ref = frame.params.view_ref
            //         qweb_error_info = error.qweb
            //     elif not isinstance(error, UserError):
            //         # If is not an odoo Exception check if the current error is raise from
            //         # IrQweb (models or computed code). In this case, convert it into an QWebError.
            //         isQweb = False
            // 
            //         trace = error.__traceback__
            //         tb_frames = [trace.tb_frame]
            //         while trace.tb_next is not None:
            //             trace = trace.tb_next
            //             tb_frames.append(trace.tb_frame)
            //         for tb_frame in tb_frames[::-1]:
            //             if tb_frame.f_globals.get('__name__') == __name__ or (
            //                 isinstance(tb_frame.f_locals.get('self'), models.AbstractModel)
            //                 and tb_frame.f_locals['self']._name == self._name
            //             ):
            //                 isQweb = True
            //                 break
            //             if any(path in tb_frame.f_code.co_filename for path in tools.config['addons_path']):
            //                 break
            // 
            //         if isQweb:
            //             raise QWebError(qweb_error_info) from error
            // 
            //     error.qweb = qweb_error_info
            //     raise
            */
            return default;
        }

        public async Task<TEntity> RstripTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object compile_context) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def _rstrip_text(self, compile_context):
            // """ The text to flush is right stripped, and the stripped content are
            // returned.
            // """
            // text_concat = compile_context['_text_concat']
            // if not text_concat:
            //     return ''
            // 
            // result = RSTRIP_REGEXP.search(text_concat[-1])
            // strip = result.group(0) if result else ''
            // text_concat[-1] = RSTRIP_REGEXP.sub('', text_concat[-1])
            // 
            // return strip
            */
            return default;
        }

        public async Task<TEntity> _PrepareGlobalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb.py) ---
            // def __prepare_globals(self):
            // """ Prepare the global context that will sent to eval the qweb
            // generated code.
            // """
            // return {
            //     '__name__': __name__,
            //     'Sized': Sized,
            //     'Mapping': Mapping,
            //     'Markup': Markup,
            //     'escape': escape,
            //     'VOID_ELEMENTS': VOID_ELEMENTS,
            //     'QwebCallParameters': QwebCallParameters,
            //     'QwebContent': QwebContent,
            //     'ValueError': ValueError,
            //     **_BUILTINS,
            // }
            */
            return default;
        }
    }
}