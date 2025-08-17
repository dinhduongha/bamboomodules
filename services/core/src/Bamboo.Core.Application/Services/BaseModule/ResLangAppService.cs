using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class ResLangAppService : GenericApplicationService<ResLang>, IResLangAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResLangAppService(IRepository<ResLang, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ResLang> ActivateLangInternalAsync(object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _activate_lang(self, code):
            // """ Activate languages
            // :param code: code of the language to activate
            // :return: the language matching 'code' activated
            // """
            // lang = self.with_context(active_test=False).search([('code', '=', code)])
            // if lang and not lang.active:
            //     lang.active = True
            // return lang
            */
            return default;
        }

        public async Task<ResLang> ActivateLangsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_lang.py) ---
            // def action_activate_langs(self):
            // """
            // Open wizard to install language(s), so user can select the website(s)
            // to translate in that language.
            // """
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Add languages'),
            //     'view_mode': 'form',
            //     'res_model': 'base.language.install',
            //     'views': [[False, 'form']],
            //     'target': 'new',
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def action_activate_langs(self):
            // """ Activate the selected languages """
            // for lang in self.filtered(lambda l: not l.active):
            //     lang.toggle_active()
            // message = _("The languages that you selected have been successfully installed. Users can choose their favorite language in their preferences.")
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'target': 'new',
            //     'params': {
            //         'message': message,
            //         'type': 'success',
            //         'sticky': False,
            //         'next': {'type': 'ir.actions.act_window_close'},
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<object> CACHEDFIELDSAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def CACHED_FIELDS(self) -> OrderedSet:
            // """ Return fields to cache for the active languages
            // Please promise all these fields don't depend on other models and context
            // and are not translated.
            // Warning: Don't add method names of ``dict`` to CACHED_FIELDS for sake of the
            // implementation of LangData
            // """
            // return OrderedSet(['id', 'name', 'code', 'iso_code', 'url_code', 'active', 'direction', 'date_format',
            //                    'time_format', 'short_time_format', 'week_start', 'grouping', 'decimal_point', 'thousands_sep', 'flag_image_url'])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResLang> CheckActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _check_active(self):
            // # do not check during installation
            // if self.env.registry.ready and not self.search_count([]):
            //     raise ValidationError(_('At least one language must be active.'))
            */
            return default;
        }

        protected async Task<ResLang> CheckFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _check_format(self):
            // for lang in self:
            //     for pattern in lang._disallowed_datetime_patterns:
            //         if (lang.time_format and pattern in lang.time_format) or \
            //                 (lang.date_format and pattern in lang.date_format):
            //             raise ValidationError(_('Invalid date/time format directive specified. '
            //                                     'Please refer to the list of allowed directives, '
            //                                     'displayed when you edit a language.'))
            */
            return default;
        }

        protected async Task<ResLang> CheckGroupingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _check_grouping(self):
            // warning = _('The Separator Format should be like [,n] where 0 < n :starting from Unit digit. '
            //             '-1 will end the separation. e.g. [3,2,-1] will represent 106500 to be 1,06,500;'
            //             '[1,2,-1] will represent it to be 106,50,0;[3] will represent it as 106,500. '
            //             'Provided as the thousand separator in each case.')
            // for lang in self:
            //     try:
            //         if any(not isinstance(x, int) for x in json.loads(lang.grouping)):
            //             raise ValidationError(warning)
            //     except Exception:
            //         raise ValidationError(warning)
            */
            return default;
        }

        protected async Task<ResLang> ComputeFieldFlagImageUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _compute_field_flag_image_url(self):
            // for lang in self:
            //     if lang.flag_image:
            //         lang.flag_image_url = f"/web/image/res.lang/{lang.id}/flag_image"
            //     else:
            //         lang.flag_image_url = f"/base/static/img/country_flags/{lang.code.lower().rsplit('_')[-1]}.png"
            */
            return default;
        }

        public async Task<ResLang> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for record, vals in zip(self, vals_list):
            //     if "name" not in default:
            //         vals["name"] = _("%s (copy)", record.name)
            //     if "code" not in default:
            //         vals["code"] = _("%s (copy)", record.code)
            //     if "url_code" not in default:
            //         vals["url_code"] = _("%s (copy)", record.url_code)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResLang> CreateLangInternalAsync(object lang, object lang_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _create_lang(self, lang, lang_name=None):
            // """ Create the given language and make it active. """
            // # create the language with locale information
            // fail = True
            // iso_lang = tools.get_iso_codes(lang)
            // for ln in tools.translate.get_locales(lang):
            //     try:
            //         locale.setlocale(locale.LC_ALL, str(ln))
            //         fail = False
            //         break
            //     except locale.Error:
            //         continue
            // if fail:
            //     lc = locale.getlocale()[0]
            //     msg = 'Unable to get information for locale %s. Information from the default locale (%s) have been used.'
            //     _logger.warning(msg, lang, lc)
            // 
            // if not lang_name:
            //     lang_name = lang
            // 
            // def fix_xa0(s):
            //     """Fix badly-encoded non-breaking space Unicode character from locale.localeconv(),
            //        coercing to utf-8, as some platform seem to output localeconv() in their system
            //        encoding, e.g. Windows-1252"""
            //     if s == '\xa0':
            //         return '\xc2\xa0'
            //     return s
            // 
            // def fix_datetime_format(format):
            //     """Python's strftime supports only the format directives
            //        that are available on the platform's libc, so in order to
            //        be 100% cross-platform we map to the directives required by
            //        the C standard (1989 version), always available on platforms
            //        with a C standard implementation."""
            //     # For some locales, nl_langinfo returns a D_FMT/T_FMT that contains
            //     # unsupported '%-' patterns, e.g. for cs_CZ
            //     format = format.replace('%-', '%')
            //     for pattern, replacement in tools.misc.DATETIME_FORMATS_MAP.items():
            //         format = format.replace(pattern, replacement)
            //     return str(format)
            // 
            // conv = locale.localeconv()
            // lang_info = {
            //     'code': lang,
            //     'iso_code': iso_lang,
            //     'name': lang_name,
            //     'active': True,
            //     'date_format' : fix_datetime_format(locale.nl_langinfo(locale.D_FMT)),
            //     'time_format' : fix_datetime_format(locale.nl_langinfo(locale.T_FMT)),
            //     'decimal_point' : fix_xa0(str(conv['decimal_point'])),
            //     'thousands_sep' : fix_xa0(str(conv['thousands_sep'])),
            //     'grouping' : str(conv.get('grouping', [])),
            // }
            // try:
            //     return self.create(lang_info)
            // finally:
            //     tools.translate.resetlocale()
            */
            return default;
        }

        public async Task<string> FormatAsync(Guid id, string percent, object @value, bool grouping)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def format(self, percent: str, value, grouping: bool = False) -> str:
            // """ Format() will return the language-specific output for float values"""
            // self.ensure_one()
            // if percent[0] != '%':
            //     raise ValueError(_("format() must be given exactly one %char format specifier"))
            // 
            // formatted = percent % value
            // 
            // # floats and decimal ints need special action!
            // if grouping:
            //     data = self._get_data(id=self.id)
            //     if not data:
            //         raise UserError(_("The language %s is not installed.", self.name))
            //     lang_grouping, thousands_sep, decimal_point = data.grouping, data.thousands_sep or '', data.decimal_point
            //     eval_lang_grouping = ast.literal_eval(lang_grouping)
            // 
            //     if percent[-1] in 'eEfFgG':
            //         parts = formatted.split('.')
            //         parts[0] = intersperse(parts[0], eval_lang_grouping, thousands_sep)[0]
            // 
            //         formatted = decimal_point.join(parts)
            // 
            //     elif percent[-1] in 'diu':
            //         formatted = intersperse(formatted, eval_lang_grouping, thousands_sep)[0]
            // 
            // return formatted
            */
            var entity = await Repository.GetAsync(id);
            return default;
        }

        protected async Task<object> GetActiveByInternalAsync(string field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _get_active_by(self, field: str) -> LangDataDict:
            // """ Return a LangDataDict mapping active languages' **unique**
            // **required** ``self.CACHED_FIELDS`` values to their LangData.
            // Its items are ordered by languages' names
            // Try to reuse the used ``field``s: 'id', 'code', 'url_code'
            // """
            // if field not in self.CACHED_FIELDS:
            //     raise UserError(_('Field "%s" is not cached', field))
            // if field == 'code':
            //     langs = self.sudo().with_context(active_test=True).search_fetch([], self.CACHED_FIELDS, order='name')
            //     return LangDataDict({
            //         lang.code: LangData({f: lang[f] for f in self.CACHED_FIELDS})
            //         for lang in langs
            //     })
            // return LangDataDict({data[field]: data for data in self._get_active_by('code').values()})
            */
            return default;
        }

        protected async Task<ResLang> GetCodeInternalAsync(string code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _get_code(self, code: str) -> str | Literal[False]:
            // """ Return the given language code if active, else return ``False`` """
            // return self._get_data(code=code).code
            */
            return default;
        }

        protected async Task<object> GetDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _get_data(self, **kwargs: Any) -> LangData:
            // """ Get the language data for the given field value in kwargs
            // For example, get_data(code='en_US') will return the LangData
            // for the res.lang record whose 'code' field value is 'en_US'
            // 
            // :param dict kwargs: {field_name: field_value}
            //         field_name is the only key in kwargs and in ``self.CACHED_FIELDS``
            //         Try to reuse the used ``field_name``s: 'id', 'code', 'url_code'
            // :return: Valid LangData if (field_name, field_value) pair is for an
            //         **active** language. Otherwise, Dummy LangData which will return
            //         ``False`` for all ``self.CACHED_FIELDS``
            // :rtype: LangData
            // :raise: UserError if field_name is not in ``self.CACHED_FIELDS``
            // """
            // [[field_name, field_value]] = kwargs.items()
            // return self._get_active_by(field_name)[field_value]
            */
            return default;
        }

        protected async Task<object> GetFrontendInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: res_lang.py) ---
            // def _get_frontend(self) -> LangDataDict:
            // """ Return the available languages for current request
            // :return: LangDataDict({code: LangData})
            // """
            // return self._get_active_by('code')
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_lang.py) ---
            // def _get_frontend(self) -> LangDataDict:
            // """ Return the available languages for current request
            // :return: LangDataDict({code: LangData})
            // """
            // if request and getattr(request, 'is_frontend', True):
            //     # get languages while ignoring current language as the one in the context may be invalid
            //     lang_ids = self.env['website'].get_current_website().with_context(lang=False).language_ids.sorted('name').ids
            //     langs = [dict(self.env['res.lang']._get_data(id=id_)) for id_ in lang_ids]
            //     es_419_exists = any(lang['code'] == 'es_419' for lang in langs)
            //     already_shortened = []
            //     for lang in langs:
            //         code = lang['code']
            //         short_code = code.split('_')[0]
            //         # Always shorten one language for each group of languages.
            //         # Special case for spanish, as es_419 is not a valid hreflang
            //         # and es_419 is actually the new "generic" spanish, when it is
            //         # in the available languages, it should be the one shortened.
            //         if (
            //             short_code not in already_shortened
            //             and not (
            //                 short_code == 'es'
            //                 and code != 'es_419'
            //                 and es_419_exists
            //             )
            //         ):
            //             lang['hreflang'] = short_code
            //             already_shortened.append(short_code)
            //         else:
            //             lang['hreflang'] = code.lower().replace('_', '-')
            //     return LangDataDict({lang['code']: LangData(lang) for lang in langs})
            // 
            // return super()._get_frontend()
            */
            return default;
        }

        public async Task<List<object>> GetInstalledAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def get_installed(self) -> list[tuple[str, str]]:
            // """ Return installed languages' (code, name) pairs sorted by name. """
            // return [(code, data.name) for code, data in self._get_active_by('code').items()]
            */
            var entity = await Repository.GetAsync(id);
            //return entity;
            return default;
        }

        public async Task<ResLang> GetLocalesForSpreadsheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: res_lang.py) ---
            // def get_locales_for_spreadsheet(self):
            // """Return the list of locales available for a spreadsheet."""
            // langs = self.with_context(active_test=False).search([])
            // 
            // spreadsheet_locales = [lang._odoo_lang_to_spreadsheet_locale() for lang in langs]
            // return spreadsheet_locales
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResLang> GetUserSpreadsheetLocaleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: res_lang.py) ---
            // def _get_user_spreadsheet_locale(self):
            // """Convert the odoo lang to a spreadsheet locale."""
            // lang = self._lang_get(self.env.user.lang or 'en_US')
            // return lang._odoo_lang_to_spreadsheet_locale()
            */
            return default;
        }

        public async Task<ResLang> InstallLangAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def install_lang(self):
            // """
            // 
            // This method is called from odoo/addons/base/data/res_lang_data.xml to load
            // some language and set it as the default for every partners. The
            // language is set via tools.config by the '_initialize_db' method on the
            // 'db' object. This is a fragile solution and something else should be
            // found.
            // 
            // """
            // # config['load_language'] is a comma-separated list or None
            // lang_code = (tools.config.get('load_language') or 'en_US').split(',')[0]
            // lang = self._activate_lang(lang_code) or self._create_lang(lang_code)
            // IrDefault = self.env['ir.default']
            // default_value = IrDefault._get('res.partner', 'lang')
            // if default_value is None:
            //     IrDefault.set('res.partner', 'lang', lang_code)
            //     # set language of main company, created directly by db bootstrap SQL
            //     partner = self.env.company.partner_id
            //     if not partner.lang:
            //         partner.write({'lang': lang_code})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResLang> LangGetInternalAsync(string code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _lang_get(self, code: str):
            // """ Return the language using this code if it is active """
            // return self.browse(self._get_data(code=code).id)
            */
            return default;
        }

        protected async Task<ResLang> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_lang.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'code', 'flag_image_url', 'display_name']
            */
            return default;
        }

        protected async Task<ResLang> OdooLangToSpreadsheetLocaleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: res_lang.py) ---
            // def _odoo_lang_to_spreadsheet_locale(self):
            // """Convert an odoo lang to a spreadsheet locale."""
            // return {
            //     "name": self.name,
            //     "code": self.code,
            //     "thousandsSeparator": self.thousands_sep,
            //     "decimalSeparator": self.decimal_point,
            //     "dateFormat": strftime_format_to_spreadsheet_date_format(self.date_format),
            //     "timeFormat": strftime_format_to_spreadsheet_time_format(self.time_format),
            //     "formulaArgSeparator": ";" if self.decimal_point == "," else ",",
            //     "weekStart": int(self.week_start),
            // }
            */
            return default;
        }

        protected async Task<ResLang> OnchangeFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _onchange_format(self):
            // warning = {
            //     'warning': {
            //         'title': _("Using 24-hour clock format with AM/PM can cause issues."),
            //         'message': _("Changing to 12-hour clock format instead."),
            //         'type': 'notification'
            //     }
            // }
            // for lang in self:
            //     if lang.date_format and "%H" in lang.date_format and "%p" in lang.date_format:
            //         lang.date_format = lang.date_format.replace("%H", "%I")
            //         return warning
            //     if lang.time_format and "%H" in lang.time_format and "%p" in lang.time_format:
            //         lang.time_format = lang.time_format.replace("%H", "%I")
            //         return warning
            */
            return default;
        }

        protected async Task<ResLang> RegisterHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _register_hook(self):
            // # check that there is at least one active language
            // if not self.search_count([]):
            //     _logger.error("No language is active.")
            */
            return default;
        }

        public async Task<ResLang> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def toggle_active(self):
            // super().toggle_active()
            // # Automatically load translation
            // active_lang = [lang.code for lang in self.filtered(lambda l: l.active)]
            // if active_lang:
            //     mods = self.env['ir.module.module'].search([('state', '=', 'installed')])
            //     mods._update_translations(active_lang)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResLang> UnlinkExceptDefaultLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def _unlink_except_default_lang(self):
            // for language in self:
            //     if language.code == 'en_US':
            //         raise UserError(_("Base Language 'en_US' can not be deleted."))
            //     ctx_lang = self._context.get('lang')
            //     if ctx_lang and (language.code == ctx_lang):
            //         raise UserError(_("You cannot delete the language which is the user's preferred language."))
            //     if language.active:
            //         raise UserError(_("You cannot delete the language which is Active!\nPlease de-activate the language first."))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResLang entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_lang.py) ---
            // def write(self, vals):
            // if 'active' in vals and not vals['active']:
            //     if self.env['website'].search_count([('language_ids', 'in', self._ids)], limit=1):
            //         raise UserError(_("Cannot deactivate a language that is currently used on a website."))
            // return super(Lang, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_lang.py) ---
            // def write(self, vals):
            // lang_codes = self.mapped('code')
            // if 'code' in vals and any(code != vals['code'] for code in lang_codes):
            //     raise UserError(_("Language code cannot be modified."))
            // if vals.get('active') == False:
            //     if self.env['res.users'].with_context(active_test=True).search_count([('lang', 'in', lang_codes)], limit=1):
            //         raise UserError(_("Cannot deactivate a language that is currently used by users."))
            //     if self.env['res.partner'].with_context(active_test=True).search_count([('lang', 'in', lang_codes)], limit=1):
            //         raise UserError(_("Cannot deactivate a language that is currently used by contacts."))
            //     if self.env['res.users'].with_context(active_test=False).search_count([('lang', 'in', lang_codes)], limit=1):
            //         raise UserError(_("You cannot archive the language in which Odoo was setup as it is used by automated processes."))
            //     # delete linked ir.default specifying default partner's language
            //     self.env['ir.default'].discard_values('res.partner', 'lang', lang_codes)
            // 
            // res = super(Lang, self).write(vals)
            // 
            // if vals.get('active'):
            //     # If we activate a lang, set it's url_code to the shortest version
            //     # if possible
            //     for long_lang in self.filtered(lambda lang: '_' in lang.url_code):
            //         short_code = long_lang.code.split('_')[0]
            //         short_lang = self.with_context(active_test=False).search([
            //             ('url_code', '=', short_code),
            //         ], limit=1)  # url_code is unique
            //         if (
            //             short_lang
            //             and not short_lang.active
            //             # `code` should always be the long format containing `_` but
            //             # there is a plan to change this in the future for `es_419`.
            //             # This `and` is about not failing if it's the case one day.
            //             and short_lang.code != short_code
            //         ):
            //             short_lang.url_code = short_lang.code
            //             long_lang.url_code = short_code
            // 
            // self.env.flush_all()
            // self.env.registry.clear_cache()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}