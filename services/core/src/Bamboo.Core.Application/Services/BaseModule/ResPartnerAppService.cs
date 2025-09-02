using Bamboo.Core.Application.Contracts.DTOs;
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
    public class ResPartnerAppService : GenericApplicationService<ResPartner>, IResPartnerAppService
    {
        private readonly IAvatarMixinAppService _avatarMixinAppService;
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        private readonly IFormatAddressMixinAppService _formatAddressMixinAppService;
        private readonly IFormatVatLabelMixinAppService _formatVatLabelMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        private readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ResPartnerAppService(IRepository<ResPartner, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAvatarMixinAppService avatarMixinAppService, IBusListenerMixinAppService busListenerMixinAppService, IFormatAddressMixinAppService formatAddressMixinAppService, IFormatVatLabelMixinAppService formatVatLabelMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IPosLoadMixinAppService posLoadMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _busListenerMixinAppService = busListenerMixinAppService;
            _formatAddressMixinAppService = formatAddressMixinAppService;
            _formatVatLabelMixinAppService = formatVatLabelMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        protected async Task<ResPartner> AddressFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _address_fields(self):
            // return super()._address_fields() + ['city_id']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<ResPartner> AddressGetAsync(Guid id, ResPartnerAddressGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def address_get(self, adr_pref=None):
            // """ Find contacts/addresses of the right type(s) by doing a depth-first-search
            // through descendants within company boundaries (stop at entities flagged ``is_company``)
            // then continuing the search at the ancestors that are within the same company boundaries.
            // Defaults to partners of type ``'default'`` when the exact type is not found, or to the
            // provided partner itself if no type ``'default'`` is found either. """
            // adr_pref = set(adr_pref or [])
            // if 'contact' not in adr_pref:
            //     adr_pref.add('contact')
            // result = {}
            // visited = set()
            // for partner in self:
            //     current_partner = partner
            //     while current_partner:
            //         to_scan = [current_partner]
            //         # Scan descendants, DFS
            //         while to_scan:
            //             record = to_scan.pop(0)
            //             visited.add(record)
            //             if record.type in adr_pref and not result.get(record.type):
            //                 result[record.type] = record.id
            //             if len(result) == len(adr_pref):
            //                 return result
            //             to_scan = [c for c in record.child_ids
            //                          if c not in visited
            //                          if not c.is_company] + to_scan
            // 
            //         # Continue scanning at ancestor if current_partner is not a commercial entity
            //         if current_partner.is_company or not current_partner.parent_id:
            //             break
            //         current_partner = current_partner.parent_id
            // 
            // # default to type 'contact' or the partner itself
            // default = result.get('contact', self.id or False)
            // for adr_type in adr_pref:
            //     result[adr_type] = result.get(adr_type) or default
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> AssetDifferenceSearchInternalAsync(object account_type, object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _asset_difference_search(self, account_type, operator, operand):
            // if operator not in ('<', '=', '>', '>=', '<='):
            //     return []
            // if not isinstance(operand, (float, int)):
            //     return []
            // sign = 1
            // if account_type == 'liability_payable':
            //     sign = -1
            // res = self._cr.execute(f'''
            //     SELECT aml.partner_id
            //       FROM res_partner partner
            //  LEFT JOIN account_move_line aml ON aml.partner_id = partner.id
            //       JOIN account_move move ON move.id = aml.move_id
            //       JOIN res_company line_company ON line_company.id = aml.company_id
            // RIGHT JOIN account_account acc ON aml.account_id = acc.id
            //      WHERE acc.account_type = %s
            //        AND NOT acc.deprecated
            //        AND SPLIT_PART(line_company.parent_path, '/', 1)::int = %s
            //        AND move.state = 'posted'
            //   GROUP BY aml.partner_id
            //     HAVING %s * COALESCE(SUM(aml.amount_residual), 0) {operator} %s''',
            //     (account_type, self.env.company.root_id.id, sign, operand)
            // )
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [r[0] for r in res])]
            */
            return default;
        }

        public async Task<ResPartner> AutocompleteAsync(Guid id, ResPartnerAutocompleteRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete(self, query, timeout=15):
            // return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> AutocompleteByNameAsync(Guid id, ResPartnerAutocompleteByNameRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete_by_name(self, query, query_country_id, timeout=15):
            // if query_country_id is False:  # If it's 0, we purposely do not want to filter on the country
            //     query_country_id = self.env.company.country_id.id
            // query_country_code = self.env['res.country'].browse(query_country_id).code
            // response, _ = self.env['iap.autocomplete.api']._request_partner_autocomplete('search_by_name', {
            //     'query': query,
            //     'query_country_code': query_country_code,
            // }, timeout=timeout)
            // if response and not response.get("error"):
            //     results = []
            //     for suggestion in response.get("data"):
            //         results.append(self._format_data_company(suggestion))
            //     return results
            // else:
            //     return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> AutocompleteByVatAsync(Guid id, ResPartnerAutocompleteByVatRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete_by_vat(self, vat, query_country_id, timeout=15):
            // query_country_id = query_country_id or self.env.company.country_id.id
            // query_country_code = self.env['res.country'].browse(query_country_id).code
            // response, _ = self.env['iap.autocomplete.api']._request_partner_autocomplete('search_by_vat', {
            //     'query': vat,
            //     'query_country_code': query_country_code,
            // }, timeout=timeout)
            // if response and not response.get("error"):
            //     results = []
            //     for suggestion in response.get("data"):
            //         results.append(self._format_data_company(suggestion))
            //     return results
            // else:
            //     vies_result = None
            //     try:
            //         _logger.info('Calling VIES service to check VAT for autocomplete: %s', vat)
            //         vies_result = check_vies(vat, timeout=timeout)
            //     except Exception:
            //         _logger.warning("Failed VIES VAT check.", exc_info=True)
            //     if vies_result:
            //         name = vies_result['name']
            //         if vies_result['valid'] and name != '---':
            //             address = list(filter(bool, vies_result['address'].split('\n')))
            //             street = address[0]
            //             zip_city_record = next(filter(lambda addr: re.match(r'^\d.*', addr), address[1:]), None)
            //             zip_city = zip_city_record.split(' ', 1) if zip_city_record else [None, None]
            //             street2 = next((addr for addr in filter(lambda addr: addr != zip_city_record, address[1:])), None)
            //             return [self._iap_replace_location_codes({
            //                 'name': name,
            //                 'vat': vat,
            //                 'street': street,
            //                 'street2': street2,
            //                 'city': zip_city[1],
            //                 'zip': zip_city[0],
            //                 'country_code': vies_result['countryCode'],
            //             })]
            //     return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> AvatarGetPlaceholderPathInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_mondialrelay:
            //     return "delivery_mondialrelay/static/src/img/truck_mr.png"
            // return super()._avatar_get_placeholder_path()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_company:
            //     return "base/static/img/company_image.png"
            // if self.type == 'delivery':
            //     return "base/static/img/truck.png"
            // if self.type == 'invoice':
            //     return "base/static/img/money.png"
            // return super()._avatar_get_placeholder_path()
            */
            return default;
        }

        protected async Task<ResPartner> BuildErrorPeppolEndpointInternalAsync(object eas, object endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _build_error_peppol_endpoint(self, eas, endpoint):
            // """ This function contains all the rules regarding the peppol_endpoint."""
            // if eas == '0208' and not re.match(r"^\d{10}$", endpoint):
            //     return _("The Peppol endpoint is not valid. The expected format is: 0239843188")
            // if eas == '0009' and not siret.is_valid(endpoint):
            //     return _("The Peppol endpoint is not valid. The expected format is: 73282932000074")
            // if eas == '0007' and not re.match(r"^\d{10}$", endpoint):
            //     return _("The Peppol endpoint is not valid. "
            //              "It should contain exactly 10 digits (Company Registry number)."
            //              "The expected format is: 1234567890")
            */
            return default;
        }

        protected async Task<ResPartner> BuildVatErrorMessageInternalAsync(object country_code, object wrong_vat, object record_label)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _build_vat_error_message(self, country_code, wrong_vat, record_label):
            // """ Prepare an error message for the VAT number that failed validation
            // 
            // :param country_code: string of lowercase country code
            // :param wrong_vat: the vat number that was validated
            // :param record_label: a string to desribe the record that failed a VAT validation check
            // 
            // :return: The error message string
            // """
            // return ""
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _build_vat_error_message(self, country_code, wrong_vat, record_label):
            // # OVERRIDE account
            // if self.env.context.get('company_id'):
            //     company = self.env['res.company'].browse(self.env.context['company_id'])
            // else:
            //     company = self.env.company
            // 
            // vat_label = _("VAT")
            // if country_code and company.country_id and country_code == company.country_id.code.lower() and company.country_id.vat_label:
            //     vat_label = company.country_id.vat_label
            // 
            // expected_format = _ref_vat.get(country_code, "'CC##' (CC=Country Code, ##=VAT Number)")
            // 
            // # Catch use case where the record label is about the public user (name: False)
            // if 'False' not in record_label:
            //     return '\n' + _(
            //         'The %(vat_label)s number [%(wrong_vat)s] for %(record_label)s does not seem to be valid. \nNote: the expected format is %(expected_format)s',
            //         vat_label=vat_label,
            //         wrong_vat=wrong_vat,
            //         record_label=record_label,
            //         expected_format=expected_format,
            //     )
            // else:
            //     return '\n' + _(
            //         'The %(vat_label)s number [%(wrong_vat)s] does not seem to be valid. \nNote: the expected format is %(expected_format)s',
            //         vat_label=vat_label,
            //         wrong_vat=wrong_vat,
            //         expected_format=expected_format,
            //     )
            */
            return default;
        }

        protected async Task<ResPartner> BuildVcardInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_partner.py) ---
            // def _build_vcard(self):
            // """ Build the partner's vCard.
            //     :returns a vobject.vCard object
            // """
            // if not vobject:
            //     return False
            // vcard = vobject.vCard()
            // # Name
            // n = vcard.add('n')
            // n.value = vobject.vcard.Name(family=self.name or self.complete_name or '')
            // if self.title:
            //     n.value.prefix = self.title.name
            // # Formatted Name
            // fn = vcard.add('fn')
            // fn.value = self.name or self.complete_name or ''
            // # Address
            // adr = vcard.add('adr')
            // adr.value = vobject.vcard.Address(street=self.street or '', city=self.city or '', code=self.zip or '')
            // if self.state_id:
            //     adr.value.region = self.state_id.name
            // if self.country_id:
            //     adr.value.country = self.country_id.name
            // # Email
            // if self.email:
            //     email = vcard.add('email')
            //     email.value = self.email
            //     email.type_param = 'INTERNET'
            // # Telephone numbers
            // if self.phone:
            //     tel = vcard.add('tel')
            //     tel.type_param = 'work'
            //     tel.value = self.phone
            // if self.mobile:
            //     tel = vcard.add('tel')
            //     tel.type_param = 'cell'
            //     tel.value = self.mobile
            // # URL
            // if self.website:
            //     url = vcard.add('url')
            //     url.value = self.website
            // # Organisation
            // if self.commercial_company_name:
            //     org = vcard.add('org')
            //     org.value = [self.commercial_company_name]
            // if self.function:
            //     function = vcard.add('title')
            //     function.value = self.function
            // # Photo
            // photo = vcard.add('photo')
            // photo.value = b64decode(self.avatar_512)
            // photo.encoding_param = 'B'
            // photo.type_param = 'JPG'
            // return VComponentProxy(vcard)
            */
            return default;
        }

        protected async Task<ResPartner> BusSendHistoryMessageInternalAsync(object channel, object page_history)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _bus_send_history_message(self, channel, page_history):
            // message_body = _("No history found")
            // if page_history:
            //     message_body = Markup("<ul>%s</ul>") % (
            //         Markup("").join(
            //             Markup('<li><a href="%(page)s" target="_blank">%(page)s</a></li>')
            //             % {"page": page}
            //             for page in page_history
            //         )
            //     )
            // self._bus_send_transient_message(channel, message_body)
            */
            return default;
        }

        public async Task<ResPartner> ButtonAccountPeppolCheckPartnerEndpointAsync(Guid id, ResPartnerButtonAccountPeppolCheckPartnerEndpointRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def button_account_peppol_check_partner_endpoint(self, company=None):
            // """ A basic check for whether a participant is reachable at the given
            // Peppol participant ID - peppol_eas:peppol_endpoint (ex: '9999:test')
            // The SML (Service Metadata Locator) assigns a DNS name to each peppol participant.
            // This DNS name resolves into the SMP (Service Metadata Publisher) of the participant.
            // The DNS address is of the following form:
            // - "http://B-" + hexstring(md5(lowercase(ID-VALUE))) + "." + ID-SCHEME + "." + SML-ZONE-NAME + "/" + url_encoded(ID-SCHEME + "::" + ID-VALUE)
            // (ref:https://peppol.helger.com/public/locale-en_US/menuitem-docs-doc-exchange)
            // """
            // self.ensure_one()
            // if not company:
            //     company = self.env.company
            // 
            // self_partner = self.with_company(company)
            // old_value = self_partner.peppol_verification_state
            // self_partner.peppol_verification_state = self._get_peppol_verification_state(
            //     self.peppol_endpoint,
            //     self.peppol_eas,
            //     self_partner._get_peppol_edi_format(),
            // )
            // if self_partner.peppol_verification_state == 'valid' and not self_partner.invoice_sending_method:
            //     self_partner.invoice_sending_method = 'peppol'
            // 
            // self._log_verification_state_update(company, old_value, self_partner.peppol_verification_state)
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> CanBeEditedByCurrentCustomerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def _can_be_edited_by_current_customer(self, sale_order, address_type):
            // self.ensure_one()
            // children_partner_ids = self.env['res.partner']._search([
            //     ('id', 'child_of', sale_order.partner_id.commercial_partner_id.id),
            //     ('type', 'in', ('invoice', 'delivery', 'other')),
            // ])
            // return self == sale_order.partner_id or self.id in children_partner_ids
            --- ODOO METHOD SOURCE (MODULE: website_sale_mondialrelay, FILE: res_partner.py) ---
            // def _can_be_edited_by_current_customer(self, *args, **kwargs):
            // return super()._can_be_edited_by_current_customer(*args, **kwargs) and not self.is_mondialrelay
            */
            return default;
        }

        protected async Task<ResPartner> CanEditNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _can_edit_name(self):
            // """ Can't edit `name` if there is (non draft) issued invoices. """
            // return super()._can_edit_name() and not self._has_invoice(
            //     [('partner_id', '=', self.id)]
            // )
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: res_partner.py) ---
            // def _can_edit_name(self):
            // """ Name can be changed more often than the VAT """
            // self.ensure_one()
            // return True
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _can_edit_name(self):
            // """ Can't edit `name` if there is (non draft) issued SO. """
            // return super()._can_edit_name() and not self._has_order(
            //     [
            //         ('partner_invoice_id', '=', self.id),
            //         ('partner_id', '=', self.id),
            //     ]
            // )
            */
            return default;
        }

        public async Task<ResPartner> CanEditVatAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def can_edit_vat(self):
            // """ Can't edit `vat` if there is (non draft) issued invoices. """
            // return super().can_edit_vat() and not self._has_invoice(
            //     [('partner_id', 'child_of', self.commercial_partner_id.id)]
            // )
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: res_partner.py) ---
            // def can_edit_vat(self):
            // """ `vat` is a commercial field, synced between the parent (commercial
            // entity) and the children. Only the commercial entity should be able to
            // edit it (as in backend)."""
            // self.ensure_one()
            // return not self.parent_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def can_edit_vat(self):
            // """ Can't edit `vat` if there is (non draft) issued SO. """
            // return super().can_edit_vat() and not self._has_order(
            //     [('partner_id', 'child_of', self.commercial_partner_id.id)]
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> CheckBarcodeUnicityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_barcode_unicity(self):
            // for partner in self:
            //     if partner.barcode and self.env['res.partner'].search_count([('barcode', '=', partner.barcode)]) > 1:
            //         raise ValidationError(_('Another partner already has this barcode'))
            */
            return default;
        }

        protected async Task<ResPartner> CheckDocumentTypeSupportInternalAsync(object participant_info, object ubl_cii_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _check_document_type_support(self, participant_info, ubl_cii_format):
            // service_references = participant_info.findall(
            //     '{*}ServiceMetadataReferenceCollection/{*}ServiceMetadataReference'
            // )
            // document_type = self.env['account.edi.xml.ubl_21']._get_customization_ids()[ubl_cii_format]
            // for service in service_references:
            //     if document_type in parse.unquote_plus(service.attrib.get('href', '')):
            //         return True
            // return False
            */
            return default;
        }

        public async Task<ResPartner> CheckGstInAsync(Guid id, ResPartnerCheckGstInRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def check_gst_in(self, vat):
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> CheckImportConsistencyInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_import_consistency(self, vals_list):
            // """
            // The values created by an import are generated by a name search, field by field.
            // As a result there is no check that the field values are consistent with each others.
            // We check that if the state is given a value, it does belong to the given country, or we remove it.
            // """
            // States = self.env['res.country.state']
            // states_ids = {vals['state_id'] for vals in vals_list if vals.get('state_id')}
            // state_to_country = States.search_read([('id', 'in', list(states_ids))], ['country_id'])
            // for vals in vals_list:
            //     if vals.get('state_id'):
            //         country_id = next(c['country_id'][0] for c in state_to_country if c['id'] == vals.get('state_id'))
            //         state = States.browse(vals['state_id'])
            //         if state.country_id.id != country_id:
            //             state_domain = [('code', '=', state.code),
            //                             ('country_id', '=', country_id)]
            //             state = States.search(state_domain, limit=1)
            //             vals['state_id'] = state.id
            */
            return default;
        }

        protected async Task<ResPartner> CheckParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        protected async Task<ResPartner> CheckPartnerCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_partner_company(self):
            // """
            // Check that for every partner which has a company,
            // if there exists a company linked to that partner,
            // the company_id set on the partner is that company
            // """
            // partners = self.filtered(lambda p: p.is_company and p.company_id)
            // companies = self.env['res.company'].search_fetch([('partner_id', 'in', partners.ids)], ['partner_id'])
            // for company in companies:
            //     if company != company.partner_id.company_id:
            //         raise ValidationError(_('The company assigned to this partner does not match the company this partner represents.'))
            */
            return default;
        }

        protected async Task<ResPartner> CheckPeppolFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _check_peppol_fields(self):
            // for partner in self:
            //     if partner.peppol_endpoint and partner.peppol_eas:
            //         error = self._build_error_peppol_endpoint(partner.peppol_eas, partner.peppol_endpoint)
            //         if error:
            //             raise ValidationError(error)
            */
            return default;
        }

        protected async Task<ResPartner> CheckPeppolParticipantExistsInternalAsync(object participant_info, object edi_identification, object check_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _check_peppol_participant_exists(self, participant_info, edi_identification, check_company=False):
            // participant_identifier = participant_info.findtext('{*}ParticipantIdentifier')
            // service_metadata = participant_info.find('.//{*}ServiceMetadataReference')
            // service_href = ''
            // if service_metadata is not None:
            //     service_href = service_metadata.attrib.get('href', '')
            // 
            // if edi_identification != participant_identifier or 'hermes-belgium' in service_href:
            //     # all Belgian companies are pre-registered on hermes-belgium, so they will
            //     # technically have an existing SMP url but they are not real Peppol participants
            //     return False
            // 
            // if check_company:
            //     # if we are only checking company's existence on the network, we don't care about what documents they can receive
            //     if not service_href:
            //         return True
            // 
            //     access_point_contact = True
            //     with contextlib.suppress(requests.exceptions.RequestException, etree.XMLSyntaxError):
            //         response = requests.get(service_href, timeout=TIMEOUT)
            //         if response.status_code == 200:
            //             access_point_info = etree.fromstring(response.content)
            //             access_point_contact = access_point_info.findtext('.//{*}TechnicalContactUrl') or access_point_info.findtext('.//{*}TechnicalInformationUrl')
            //     return access_point_contact
            // 
            // return True
            */
            return default;
        }

        protected async Task<ResPartner> CheckRecursionAssociateMemberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _check_recursion_associate_member(self):
            // if self._has_cycle('associate_member'):
            //     raise ValidationError(_('You cannot create recursive associated members.'))
            */
            return default;
        }

        public async Task<ResPartner> CheckVatAlAsync(Guid id, ResPartnerCheckVatAlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_al(self, vat):
            // """Check Albania VAT number"""
            // number = stdnum.util.get_cc_module('al', 'vat').compact(vat)
            // 
            // if len(number) == 10 and self.__check_vat_al_re.match(number):
            //     return True
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat(self):
            // # The context key 'no_vat_validation' allows you to store/set a VAT number without doing validations.
            // # This is for API pushes from external platforms where you have no control over VAT numbers.
            // if self.env.context.get('no_vat_validation'):
            //     return
            // 
            // for partner in self:
            //     # Skip checks when only one character is used. Some users like to put '/' or other as VAT to differentiate between
            //     # A partner for which they didn't input VAT, and the one not subject to VAT
            //     if not partner.vat or len(partner.vat) == 1:
            //         continue
            //     country = partner.commercial_partner_id.country_id
            //     if self._run_vat_test(partner.vat, country, partner.is_company) is False:
            //         partner_label = _("partner [%s]", partner.name)
            //         msg = partner._build_vat_error_message(country and country.code.lower() or None, partner.vat, partner_label)
            //         raise ValidationError(msg)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatBrAsync(Guid id, ResPartnerCheckVatBrRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_br(self, vat):
            // is_cpf_valid = stdnum.get_cc_module('br', 'cpf').is_valid
            // is_cnpj_valid = stdnum.get_cc_module('br', 'cnpj').is_valid
            // return is_cpf_valid(vat) or is_cnpj_valid(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatChAsync(Guid id, ResPartnerCheckVatChRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ch(self, vat):
            // '''
            // Check Switzerland VAT number.
            // '''
            // # A new VAT number format in Switzerland has been introduced between 2011 and 2013
            // # https://www.estv.admin.ch/estv/fr/home/mehrwertsteuer/fachinformationen/steuerpflicht/unternehmens-identifikationsnummer--uid-.html
            // # The old format "TVA 123456" is not valid since 2014
            // # Accepted format are: (spaces are ignored)
            // #     CHE#########MWST
            // #     CHE#########TVA
            // #     CHE#########IVA
            // #     CHE-###.###.### MWST
            // #     CHE-###.###.### TVA
            // #     CHE-###.###.### IVA
            // #
            // # /!\ The english abbreviation VAT is not valid /!\
            // 
            // match = self.__check_vat_ch_re.match(vat)
            // 
            // if match:
            //     # For new TVA numbers, the last digit is a MOD11 checksum digit build with weighting pattern: 5,4,3,2,7,6,5,4
            //     num = [s for s in match.group(1) if s.isdigit()]        # get the digits only
            //     factor = (5, 4, 3, 2, 7, 6, 5, 4)
            //     csum = sum([int(num[i]) * factor[i] for i in range(8)])
            //     check = (11 - (csum % 11)) % 11
            //     return check == int(num[8])
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatCrAsync(Guid id, ResPartnerCheckVatCrRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_cr(self, vat):
            // # CÉDULA FÍSICA: 9 digits
            // # CÉDULA JURÍDICA: 10 digits
            // # CÉDULA DIMEX: 11 or 12 digits
            // # CÉDULA NITE: 10 digits
            // 
            // return self.__check_vat_cr_re.match(vat) or False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatDeAsync(Guid id, ResPartnerCheckVatDeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_de(self, vat):
            // is_valid_vat = stdnum.util.get_cc_module("de", "vat").is_valid
            // is_valid_stnr = stdnum.util.get_cc_module("de", "stnr").is_valid
            // return is_valid_vat(vat) or is_valid_stnr(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatEcAsync(Guid id, ResPartnerCheckVatEcRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ec(self, vat):
            // vat = clean(vat, ' -.').upper().strip()
            // return self.is_valid_ruc_ec(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatGrAsync(Guid id, ResPartnerCheckVatGrRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_gr(self, vat):
            // """ Allows some custom test VAT number to be valid to allow testing Greece EDI. """
            // greece_test_vats = ('047747270', '047747210', '047747220', '117747270', '127747270')
            // if vat in greece_test_vats:
            //     return True
            // return stdnum.util.get_cc_module('gr', 'vat').is_valid(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatHuAsync(Guid id, ResPartnerCheckVatHuRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_hu(self, vat):
            // """
            //     Check Hungary VAT number that can be for example 'HU12345676 or 'xxxxxxxx-y-zz' or '8xxxxxxxxy'
            //     - For xxxxxxxx-y-zz, 'x' can be any number, 'y' is a number between 1 and 5 depending on the person and the 'zz'
            //       is used for region code.
            //     - 8xxxxxxxxy, Tin number for individual, it has to start with an 8 and finish with the check digit
            //     - In case of EU format it will be the first 8 digits of the full VAT
            // """
            // companies = self.__check_tin_hu_companies_re.match(vat)
            // if companies:
            //     return True
            // individual = self.__check_tin_hu_individual_re.match(vat)
            // if individual:
            //     return True
            // european = self.__check_tin_hu_european_re.match(vat)
            // if european:
            //     return True
            // # Check the vat number
            // return stdnum.util.get_cc_module('hu', 'vat').is_valid(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatIdAsync(Guid id, ResPartnerCheckVatIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_id(self, vat):
            // """ Temporary Indonesian VAT validation to support the new format
            // introduced in January 2024."""
            // vat = clean(vat, ' -.').strip()
            // 
            // if len(vat) not in (15, 16) or not vat.isdecimal():
            //     return False
            // 
            // # VAT could be 15 (old numbers) or 16 digits. If there are 15 digits long, the 10th digit is a luhn checksum
            // # In some cases, the 15 digits can be transformed in a 16-digit by adding a 0 in front. In such case, we
            // # we can verify the luhn checksum like for the 15 digits by removing the 0. 
            // # However, for newly created VAT 16-digits VAT number, there is no checksum.
            // if (len(vat) == 16 and vat[0] != '0'):
            //     return True
            // 
            // try:
            //     luhn.validate(vat[0:9] if len(vat) == 15 else vat[1:10])
            // except (InvalidFormat, InvalidChecksum):
            //     return False
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatIeAsync(Guid id, ResPartnerCheckVatIeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ie(self, vat):
            // return stdnum.util.get_cc_module('ie', 'vat').is_valid(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatIlAsync(Guid id, ResPartnerCheckVatIlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_il(self, vat):
            // check_func = stdnum.util.get_cc_module('il', 'idnr').is_valid
            // return check_func(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatInAsync(Guid id, ResPartnerCheckVatInRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_in(self, vat):
            // #reference from https://www.gstzen.in/a/format-of-a-gst-number-gstin.html
            // if vat and len(vat) == 15:
            //     all_gstin_re = [
            //         r'[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Zz1-9A-Ja-j]{1}[0-9a-zA-Z]{1}', # Normal, Composite, Casual GSTIN
            //         r'[0-9]{4}[A-Z]{3}[0-9]{5}[UO]{1}[N][A-Z0-9]{1}', #UN/ON Body GSTIN
            //         r'[0-9]{4}[a-zA-Z]{3}[0-9]{5}[N][R][0-9a-zA-Z]{1}', #NRI GSTIN
            //         r'[0-9]{2}[a-zA-Z]{4}[a-zA-Z0-9]{1}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[DK]{1}[0-9a-zA-Z]{1}', #TDS GSTIN
            //         r'[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[C]{1}[0-9a-zA-Z]{1}' #TCS GSTIN
            //     ]
            //     return any(re.compile(rx).match(vat) for rx in all_gstin_re)
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatMaAsync(Guid id, ResPartnerCheckVatMaRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ma(self, vat):
            // return vat.isdigit() and len(vat) == 8
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatMxAsync(Guid id, ResPartnerCheckVatMxRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_mx(self, vat):
            // ''' Mexican VAT verification
            // 
            // Verificar RFC México
            // '''
            // m = self.__check_vat_mx_re.fullmatch(vat)
            // if not m:
            //     #No valid format
            //     return False
            // ano = int(m['ano'])
            // if ano > 30:
            //     ano = 1900 + ano
            // else:
            //     ano = 2000 + ano
            // try:
            //     datetime.date(ano, int(m['mes']), int(m['dia']))
            // except ValueError:
            //     return False
            // 
            // # Valid format and valid date
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatNoAsync(Guid id, ResPartnerCheckVatNoRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_no(self, vat):
            // """
            // Check Norway VAT number.See http://www.brreg.no/english/coordination/number.html
            // """
            // if len(vat) == 12 and vat.upper().endswith('MVA'):
            //     vat = vat[:-3] # Strictly speaking we should enforce the suffix MVA but...
            // 
            // if len(vat) != 9:
            //     return False
            // try:
            //     int(vat)
            // except ValueError:
            //     return False
            // 
            // sum = (3 * int(vat[0])) + (2 * int(vat[1])) + \
            //     (7 * int(vat[2])) + (6 * int(vat[3])) + \
            //     (5 * int(vat[4])) + (4 * int(vat[5])) + \
            //     (3 * int(vat[6])) + (2 * int(vat[7]))
            // 
            // check = 11 - (sum % 11)
            // if check == 11:
            //     check = 0
            // if check == 10:
            //     # 10 is not a valid check digit for an organization number
            //     return False
            // return check == int(vat[8])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatPeAsync(Guid id, ResPartnerCheckVatPeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_pe(self, vat):
            // if len(vat) != 11 or not vat.isdigit():
            //     return False
            // dig_check = 11 - (sum([int('5432765432'[f]) * int(vat[f]) for f in range(0, 10)]) % 11)
            // if dig_check == 10:
            //     dig_check = 0
            // elif dig_check == 11:
            //     dig_check = 1
            // return int(vat[10]) == dig_check
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatPhAsync(Guid id, ResPartnerCheckVatPhRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ph(self, vat):
            // return len(vat) >= 11 and len(vat) <= 17 and self.__check_vat_ph_re.match(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatRoAsync(Guid id, ResPartnerCheckVatRoRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ro(self, vat):
            // """
            //     Check Romanian VAT number that can be for example 'RO1234567897 or 'xyyzzaabbxxxx' or '9000xxxxxxxx'.
            //     - For xyyzzaabbxxxx, 'x' can be any number, 'y' is the two last digit of a year (in the range 00…99),
            //       'a' is a month, b is a day of the month, the number 8 and 9 are Country or district code
            //       (For those twos digits, we decided to let some flexibility  to avoid complexifying the regex and also
            //       for maintainability)
            //     - 9000xxxxxxxx, start with 9000 and then is filled by number In the range 0...9
            // 
            //     Also stdum also checks the CUI or CIF (Romanian company identifier). So a number like '123456897' will pass.
            // """
            // tin1 = self.__check_tin1_ro_natural_persons.match(vat)
            // if tin1:
            //     return True
            // tin2 = self.__check_tin2_ro_natural_persons.match(vat)
            // if tin2:
            //     return True
            // # Check the vat number
            // return stdnum.util.get_cc_module('ro', 'vat').is_valid(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatRuAsync(Guid id, ResPartnerCheckVatRuRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ru(self, vat):
            // '''
            // Check Russia VAT number.
            // Method copied from vatnumber 1.2 lib https://code.google.com/archive/p/vatnumber/
            // '''
            // if len(vat) != 10 and len(vat) != 12:
            //     return False
            // try:
            //     int(vat)
            // except ValueError:
            //     return False
            // 
            // if len(vat) == 10:
            //     check_sum = 2 * int(vat[0]) + 4 * int(vat[1]) + 10 * int(vat[2]) + \
            //         3 * int(vat[3]) + 5 * int(vat[4]) + 9 * int(vat[5]) + \
            //         4 * int(vat[6]) + 6 * int(vat[7]) + 8 * int(vat[8])
            //     check = check_sum % 11
            //     if check % 10 != int(vat[9]):
            //         return False
            // else:
            //     check_sum1 = 7 * int(vat[0]) + 2 * int(vat[1]) + 4 * int(vat[2]) + \
            //         10 * int(vat[3]) + 3 * int(vat[4]) + 5 * int(vat[5]) + \
            //         9 * int(vat[6]) + 4 * int(vat[7]) + 6 * int(vat[8]) + \
            //         8 * int(vat[9])
            //     check = check_sum1 % 11
            // 
            //     if check != int(vat[10]):
            //         return False
            //     check_sum2 = 3 * int(vat[0]) + 7 * int(vat[1]) + 2 * int(vat[2]) + \
            //         4 * int(vat[3]) + 10 * int(vat[4]) + 3 * int(vat[5]) + \
            //         5 * int(vat[6]) + 9 * int(vat[7]) + 4 * int(vat[8]) + \
            //         6 * int(vat[9]) + 8 * int(vat[10])
            //     check = check_sum2 % 11
            //     if check != int(vat[11]):
            //         return False
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatSaAsync(Guid id, ResPartnerCheckVatSaRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_sa(self, vat):
            // """
            //     Check company VAT TIN according to ZATCA specifications: The VAT number should start and begin with a '3'
            //     and be 15 digits long
            // """
            // return self.__check_vat_sa_re.match(vat) or False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatTAsync(Guid id, ResPartnerCheckVatTRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_t(self, vat):
            // if self.country_id.code == 'JP':
            //     return self.simple_vat_check('jp', vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatTrAsync(Guid id, ResPartnerCheckVatTrRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_tr(self, vat):
            // return stdnum.util.get_cc_module('tr', 'tckimlik').is_valid(vat) or stdnum.util.get_cc_module('tr', 'vkn').is_valid(vat)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatUaAsync(Guid id, ResPartnerCheckVatUaRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ua(self, vat):
            // res = []
            // for partner in self:
            //     if partner.commercial_partner_id.country_id.code == 'MX':
            //         if len(vat) == 10:
            //             res.append(True)
            //         else:
            //             res.append(False)
            //     elif partner.commercial_partner_id.is_company:
            //         if len(vat) == 12:
            //             res.append(True)
            //         else:
            //             res.append(False)
            //     else:
            //         if len(vat) == 10 or len(vat) == 9:
            //             res.append(True)
            //         else:
            //             res.append(False)
            // return all(res)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatUyAsync(Guid id, ResPartnerCheckVatUyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_uy(self, vat):
            // """ Taken from python-stdnum's master branch, as the release doesn't handle RUT numbers starting with 22.
            // origin https://github.com/arthurdejong/python-stdnum/blob/master/stdnum/uy/rut.py
            // FIXME Can be removed when python-stdnum does a new release. """
            // 
            // def compact(number):
            //     """Convert the number to its minimal representation."""
            //     number = clean(number, ' -').upper().strip()
            //     if number.startswith('UY'):
            //         return number[2:]
            //     return number
            // 
            // def calc_check_digit(number):
            //     """Calculate the check digit."""
            //     weights = (4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2)
            //     total = sum(int(n) * w for w, n in zip(weights, number))
            //     return str(-total % 11)
            // 
            // vat = compact(vat)
            // 
            // return (
            //     vat.isdigit()  # InvalidFormat
            //     and len(vat) == 12  # InvalidLength
            //     and '01' <= vat[:2] <= '22'  # InvalidComponent
            //     and vat[2:8] != '000000'
            //     and vat[8:11] == '001'
            //     and vat[-1] == calc_check_digit(vat)  # Invalid Check Digit
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatVeAsync(Guid id, ResPartnerCheckVatVeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ve(self, vat):
            // # https://tin-check.com/en/venezuela/
            // # https://techdocs.broadcom.com/us/en/symantec-security-software/information-security/data-loss-prevention/15-7/About-content-packs/What-s-included-in-Content-Pack-2021-02/Updated-data-identifiers-in-Content-Pack-2021-02/venezuela-national-identification-number-v115451096-d327e108002-CP2021-02.html
            // # Sources last visited on 2022-12-09
            // 
            // # VAT format: (kind - 1 letter)(identifier number - 8-digit number)(check digit - 1 digit)
            // vat_regex = re.compile(r"""
            //     ([vecjpg])                          # group 1 - kind
            //     (
            //         (?P<optional_1>-)?                      # optional '-' (1)
            //         [0-9]{2}
            //         (?(optional_1)(?P<optional_2>[.])?)     # optional '.' (2) only if (1)
            //         [0-9]{3}
            //         (?(optional_2)[.])                      # mandatory '.' if (2)
            //         [0-9]{3}
            //         (?(optional_1)-)                        # mandatory '-' if (1)
            //     )                                   # group 2 - identifier number
            //     ([0-9]{1})                          # group X - check digit
            // """, re.VERBOSE | re.IGNORECASE)
            // 
            // matches = re.fullmatch(vat_regex, vat)
            // if not matches:
            //     return False
            // 
            // kind, identifier_number, *_, check_digit = matches.groups()
            // kind = kind.lower()
            // identifier_number = identifier_number.replace("-", "").replace(".", "")
            // check_digit = int(check_digit)
            // 
            // if kind == 'v':                   # Venezuela citizenship
            //     kind_digit = 1
            // elif kind == 'e':                 # Foreigner
            //     kind_digit = 2
            // elif kind == 'c' or kind == 'j':  # Township/Communal Council or Legal entity
            //     kind_digit = 3
            // elif kind == 'p':                 # Passport
            //     kind_digit = 4
            // else:                             # Government ('g')
            //     kind_digit = 5
            // 
            // # === Checksum validation ===
            // multipliers = [3, 2, 7, 6, 5, 4, 3, 2]
            // checksum = kind_digit * 4
            // checksum += sum(map(lambda n, m: int(n) * m, identifier_number, multipliers))
            // 
            // checksum_digit = 11 - checksum % 11
            // if checksum_digit > 9:
            //     checksum_digit = 0
            // 
            // return check_digit == checksum_digit
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CheckVatVnAsync(Guid id, ResPartnerCheckVatVnRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_vn(self, vat):
            // """
            // VAT format validator for Vietnam.
            // Supported formats:
            // - 10-digit format (Enterprise tax ID): e.g., 0101243150
            // - 13-digit format with branch suffix: e.g., 0101243150-001
            // - 12-digit format (Personal ID / Citizen ID - CCCD): e.g., 079123456789
            //   (used as tax ID for individuals from July 1st, 2025)
            // 
            // Note:
            // - stdnum.vn.mst.validate() currently only supports 10- and 13-digit VAT numbers
            // - and does not accept the 12-digit personal tax ID (CCCD) format introduced from 01/07/2025.
            // - This helper provides a lightweight format-level validator for use in the meantime.
            // - Can be removed once stdnum.vn.mst adds CCCD support.
            // """
            // vat = vat.strip()
            // return bool(self.__check_vat_vn_re.match(vat))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> ChildrenSyncInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _children_sync(self, values):
            // if not self.child_ids:
            //     return
            // # 2a. Commercial Fields: sync if commercial entity
            // if self.commercial_partner_id == self:
            //     fields_to_sync = values.keys() & self._commercial_fields()
            //     self.sudo()._commercial_sync_to_children(fields_to_sync)
            // # 2b. Address fields: sync if address changed
            // address_fields = self._address_fields()
            // if any(field in values for field in address_fields):
            //     contacts = self.child_ids.filtered(lambda c: c.type == 'contact')
            //     contacts.update_address(values)
            */
            return default;
        }

        protected async Task<ResPartner> CleanWebsiteInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _clean_website(self, website):
            // url = urls.url_parse(website)
            // if not url.scheme:
            //     if not url.netloc:
            //         url = url.replace(netloc=url.path, path='')
            //     website = url.replace(scheme='http').to_url()
            // return website
            */
            return default;
        }

        protected async Task<ResPartner> CommercialFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _commercial_fields(self):
            // return super(ResPartner, self)._commercial_fields() + \
            //     ['debit_limit', 'property_account_payable_id', 'property_account_receivable_id', 'property_account_position_id',
            //      'property_payment_term_id', 'property_supplier_payment_term_id', 'credit_limit']
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['property_product_pricelist']
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super(res_partner, self)._commercial_fields()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. These fields are meant to be hidden on
            // partners that aren't `commercial entities` themselves, and will be
            // delegated to the parent `commercial entity`. The list is meant to be
            // extended by inheriting classes. """
            // return ['vat', 'company_registry', 'industry_id']
            */
            return default;
        }

        protected async Task<ResPartner> CommercialSyncFromCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_from_company(self):
            // """ Handle sync of commercial fields when a new parent commercial entity is set,
            // as if they were related fields """
            // commercial_partner = self.commercial_partner_id
            // if commercial_partner != self:
            //     sync_vals = commercial_partner._update_fields_values(self._commercial_fields())
            //     self.write(sync_vals)
            //     self._company_dependent_commercial_sync()
            //     self._commercial_sync_to_children()
            */
            return default;
        }

        protected async Task<ResPartner> CommercialSyncToChildrenInternalAsync(object fields_to_sync)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_to_children(self, fields_to_sync=None):
            // """ Handle sync of commercial fields to descendants """
            // commercial_partner = self.commercial_partner_id
            // if fields_to_sync is None:
            //     fields_to_sync = self._commercial_fields()
            // sync_vals = commercial_partner._update_fields_values(fields_to_sync)
            // sync_children = self.child_ids.filtered(lambda c: not c.is_company)
            // for child in sync_children:
            //     child._commercial_sync_to_children(fields_to_sync)
            // res = sync_children.write(sync_vals)
            // return res
            */
            return default;
        }

        protected async Task<ResPartner> CompanyDependentCommercialFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _company_dependent_commercial_fields(self):
            // return [
            //     *super()._company_dependent_commercial_fields(),
            //     'specific_property_product_pricelist'
            // ]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_fields(self):
            // return [
            //     fname for fname in self._commercial_fields()
            //     if self._fields[fname].company_dependent
            // ]
            */
            return default;
        }

        protected async Task<ResPartner> CompanyDependentCommercialSyncInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_sync(self):
            // if not (fields_to_sync := self._company_dependent_commercial_fields()):
            //     return
            // 
            // for company_sudo in self.env['res.company'].sudo().search([]):
            //     if company_sudo == self.env.company:
            //         continue  # already handled by _commercial_sync_from_company
            //     self_in_company = self.with_company(company_sudo)
            //     self_in_company.write(
            //         self_in_company.commercial_partner_id._update_fields_values(fields_to_sync)
            //     )
            */
            return default;
        }

        protected async Task<ResPartner> ComputeActiveLangCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_active_lang_count(self):
            // lang_count = len(self.env['res.lang'].get_installed())
            // for partner in self:
            //     partner.active_lang_count = lang_count
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvailablePeppolEdiFormatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _compute_available_peppol_edi_formats(self):
            // for partner in self:
            //     if partner.invoice_sending_method == 'peppol':
            //         partner.available_peppol_edi_formats = self._get_peppol_formats()
            //     else:
            //         partner.available_peppol_edi_formats = list(dict(self._fields['invoice_edi_format'].selection))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvailablePeppolSendingMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _compute_available_peppol_sending_methods(self):
            // methods = dict(self._fields['invoice_sending_method'].selection)
            // if self.env.company.country_code not in PEPPOL_LIST:
            //     methods.pop('peppol')
            // self.available_peppol_sending_methods = list(methods)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar1024InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar128InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar1920InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar256InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar512InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatarInternalAsync(object avatar_field, object image_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // partners_with_internal_user = self.filtered(lambda partner: partner.user_ids - partner.user_ids.filtered('share'))
            // super(Partner, partners_with_internal_user)._compute_avatar(avatar_field, image_field)
            // partners_without_image = (self - partners_with_internal_user).filtered(lambda p: not p[image_field])
            // for _, group in tools.groupby(partners_without_image, key=lambda p: p._avatar_get_placeholder_path()):
            //     group_partners = self.env['res.partner'].concat(*group)
            //     group_partners[avatar_field] = base64.b64encode(group_partners[0]._avatar_get_placeholder())
            // 
            // for partner in self - partners_with_internal_user - partners_without_image:
            //     partner[avatar_field] = partner[image_field]
            */
            return default;
        }

        protected async Task<ResPartner> ComputeBankCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_bank_count(self):
            // bank_data = self.env['res.partner.bank']._read_group([('partner_id', 'in', self.ids)], ['partner_id'], ['__count'])
            // mapped_data = {partner.id: count for partner, count in bank_data}
            // for partner in self:
            //     partner.bank_account_count = mapped_data.get(partner.id, 0)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeBomIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_bom_ids(self):
            // results = self.env['mrp.bom']._read_group([('subcontractor_ids.commercial_partner_id', 'in', self.commercial_partner_id.ids)], ['subcontractor_ids'], ['id:array_agg'])
            // for partner in self:
            //     bom_ids = []
            //     for subcontractor, ids in results:
            //         if partner.id == subcontractor.id or subcontractor.id in partner.child_ids.ids:
            //             bom_ids += ids
            //     partner.bom_ids = bom_ids
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCanPublishInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def _compute_can_publish(self):
            // self2 = self.with_context(can_publish_unsudo_main_object=False)
            // super(Partner, self2)._compute_can_publish()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCertificationsCompanyCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def _compute_certifications_company_count(self):
            // self.certifications_company_count = sum(child.certifications_count for child in self.child_ids)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCertificationsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def _compute_certifications_count(self):
            // read_group_res = self.env['survey.user_input'].sudo()._read_group(
            //     [('partner_id', 'in', self.ids), ('scoring_success', '=', True)],
            //     ['partner_id'], ['__count']
            // )
            // data = {partner.id: count for partner, count in read_group_res}
            // for partner in self:
            //     partner.certifications_count = data.get(partner.id, 0)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCommercialCompanyNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_company_name(self):
            // for partner in self:
            //     p = partner.commercial_partner_id
            //     partner.commercial_company_name = p.is_company and p.name or partner.company_name
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCommercialPartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_partner(self):
            // for partner in self:
            //     if partner.is_company or not partner.parent_id:
            //         partner.commercial_partner_id = partner
            //     else:
            //         partner.commercial_partner_id = partner.parent_id.commercial_partner_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyRegistryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # exists to allow overrides
            // for company in self:
            //     company.company_registry = company.company_registry
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyRegistryLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry_label(self):
            // label_by_country = self._get_company_registry_labels()
            // for company in self:
            //     country_code = company.country_id.code
            //     company.company_registry_label = label_by_country.get(country_code, _("Company ID"))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeContactAddressInlineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _compute_contact_address_inline(self):
            // """Compute an inline-friendly address based on contact_address."""
            // for partner in self:
            //     # replace any successive \n with a single comma
            //     partner.contact_address_inline = re.sub(r'\n(\s|\n)*', ', ', partner.contact_address).strip().strip(',')
            */
            return default;
        }

        protected async Task<ResPartner> ComputeContactAddressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCountActiveCardsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py) ---
            // def _compute_count_active_cards(self):
            // loyalty_groups = self.env['loyalty.card']._read_group(
            //     domain=[
            //         '|', ('company_id', '=', False), ('company_id', 'in', self.env.companies.ids),
            //         ('partner_id', 'in', self.with_context(active_test=False)._search([('id', 'child_of', self.ids)])),
            //         ('points', '>', '0'),
            //         ('program_id.active', '=', True),
            //         '|',
            //             ('expiration_date', '>=', fields.Date().context_today(self)),
            //             ('expiration_date', '=', False),
            //     ],
            //     groupby=['partner_id'],
            //     aggregates=['__count'],
            // )
            // self.loyalty_card_count = 0
            // for partner, count in loyalty_groups:
            //     while partner:
            //         if partner in self:
            //             partner.loyalty_card_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCreditToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_credit_to_invoice(self):
            // # To be overridden in Sales
            // self.credit_to_invoice = False
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _compute_credit_to_invoice(self):
            // # EXTENDS 'account'
            // super()._compute_credit_to_invoice()
            // if not (commercial_partners := self.commercial_partner_id & self):
            //     return  # nothing to compute
            // company = self.env.company
            // if not company.account_use_credit_limit:
            //     return
            // 
            // sale_orders = self.env['sale.order'].search([
            //     ('company_id', '=', company.id),
            //     ('partner_invoice_id', 'any', [
            //         ('commercial_partner_id', 'in', commercial_partners.ids),
            //     ]),
            //     ('order_line', 'any', [('untaxed_amount_to_invoice', '>', 0)]),
            //     ('state', '=', 'sale'),
            // ])
            // for (partner, currency), orders in sale_orders.grouped(
            //     lambda so: (so.partner_invoice_id, so.currency_id),
            // ).items():
            //     amount_to_invoice_sum = sum(orders.mapped('amount_to_invoice'))
            //     credit_company_currency = currency._convert(
            //         amount_to_invoice_sum,
            //         company.currency_id,
            //         company,
            //         fields.Date.context_today(self),
            //     )
            //     partner.commercial_partner_id.credit_to_invoice += credit_company_currency
            */
            return default;
        }

        protected async Task<ResPartner> ComputeDaysSalesOutstandingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_days_sales_outstanding(self):
            // commercial_partners = {
            //     commercial_partner: (invoice_date_min, amount_total_signed_sum)
            //     for commercial_partner, invoice_date_min, amount_total_signed_sum in self.env['account.move']._read_group(
            //         domain=[
            //             ('state', 'not in', ['draft', 'cancel']),
            //             ('move_type', 'in', self.env["account.move"].get_sale_types(include_receipts=True)),
            //             ('company_id', '=', self.env.company.id),
            //             ('commercial_partner_id', 'in', self.commercial_partner_id.ids),
            //         ],
            //         groupby=['commercial_partner_id'],
            //         aggregates=['invoice_date:min', 'amount_total_signed:sum'],
            //     )
            // }
            // for partner in self:
            //     oldest_invoice_date, total_invoiced_tax_included = commercial_partners.get(partner, (fields.Date.context_today(self), 0))
            //     days_since_oldest_invoice = (fields.Date.context_today(self) - oldest_invoice_date).days
            //     partner.days_sales_outstanding = ((partner.credit / total_invoiced_tax_included) * days_since_oldest_invoice) if total_invoiced_tax_included else 0
            */
            return default;
        }

        protected async Task<ResPartner> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // if not self._context.get('display_website') or not self.env.user.has_group('website.group_multi_website'):
            //     return
            // for partner in self:
            //     if partner.website_id:
            //         partner.display_name += f' [{partner.website_id.name}]'
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // for partner in self:
            //     name = partner.with_context(lang=self.env.lang)._get_complete_name()
            //     if partner._context.get('show_address'):
            //         name = name + "\n" + partner._display_address(without_company=True)
            //     name = re.sub(r'\s+\n', '\n', name)
            //     if partner._context.get('partner_show_db_id'):
            //         name = f"{name} ({partner.id})"
            //     if partner._context.get('address_inline'):
            //         splitted_names = name.split("\n")
            //         name = ", ".join([n for n in splitted_names if n.strip()])
            //     if partner._context.get('show_email') and partner.email:
            //         name = f"{name} <{partner.email}>"
            //     if partner._context.get('show_vat') and partner.vat:
            //         name = f"{name} ‒ {partner.vat}"
            // 
            //     partner.display_name = name.strip()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeDuplicatedBankAccountPartnersCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_duplicated_bank_account_partners_count(self):
            // for partner in self:
            //     partner.duplicated_bank_account_partners_count = len(partner._get_duplicated_bank_accounts())
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEmailFormattedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_email_formatted(self):
            // """ Compute formatted email for partner, using formataddr. Be defensive
            // in computation, notably
            // 
            //   * double format: if email already holds a formatted email like
            //     'Name' <email@domain.com> we should not use it as it to compute
            //     email formatted like "Name <'Name' <email@domain.com>>";
            //   * multi emails: sometimes this field is used to hold several addresses
            //     like email1@domain.com, email2@domain.com. We currently let this value
            //     untouched, but remove any formatting from multi emails;
            //   * invalid email: if something is wrong, keep it in email_formatted as
            //     this eases management and understanding of failures at mail.mail,
            //     mail.notification and mailing.trace level;
            //   * void email: email_formatted is False, as we cannot do anything with
            //     it;
            // """
            // self.email_formatted = False
            // for partner in self:
            //     emails_normalized = tools.email_normalize_all(partner.email)
            //     if emails_normalized:
            //         # note: multi-email input leads to invalid email like "Name" <email1, email2>
            //         # but this is current behavior in Odoo 14+ and some servers allow it
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             ','.join(emails_normalized)
            //         ))
            //     elif partner.email:
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             partner.email
            //         ))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEmployeesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def _compute_employees_count(self):
            // for partner in self:
            //     partner.employees_count = len(partner.sudo().employee_ids.filtered(lambda e: e.company_id in self.env.companies))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEventCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_event_count(self):
            // self.event_count = 0
            // for partner in self:
            //     partner.event_count = self.env['event.event'].search_count([('registration_ids.partner_id', 'child_of', partner.ids)])
            */
            return default;
        }

        protected async Task<ResPartner> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_fiscal_country_codes(self):
            // for record in self:
            //     allowed_companies = record.company_id or self.env.companies
            //     record.fiscal_country_codes = ",".join(allowed_companies.mapped('account_fiscal_country_id.code'))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeGetIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeImStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // status_by_partner = {}
            // for presence in self.env["bus.presence"].search([("user_id", "in", self.user_ids.ids)]):
            //     partner = presence.user_id.partner_id
            //     if (
            //         status_by_partner.get(partner, "offline") == "offline"
            //         or presence.status == "online"
            //     ):
            //         status_by_partner[partner] = presence.status
            // for partner in self:
            //     default_status = "offline" if partner.user_ids else "im_partner"
            //     partner.im_status = status_by_partner.get(partner, default_status)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // super(ResPartner, self)._compute_im_status()
            // absent_now = self._get_on_leave_ids()
            // for partner in self:
            //     if partner.id in absent_now:
            //         if partner.im_status == 'online':
            //             partner.im_status = 'leave_online'
            //         elif partner.im_status == 'away':
            //             partner.im_status = 'leave_away'
            //         elif partner.im_status == 'offline':
            //             partner.im_status = 'leave_offline'
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // super()._compute_im_status()
            // for user in self.user_ids:
            //     dayfield = self.env['hr.employee']._get_current_day_location_field()
            //     location_type = user[dayfield].location_type
            //     if not location_type:
            //         continue
            //     im_status = user.partner_id.im_status
            //     if im_status == "online" or im_status == "away" or im_status == "offline":
            //         user.partner_id.im_status = location_type + "_" + im_status
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _compute_im_status(self):
            // super()._compute_im_status()
            // odoobot_id = self.env['ir.model.data']._xmlid_to_res_id('base.partner_root')
            // odoobot = self.env['res.partner'].browse(odoobot_id)
            // if odoobot in self:
            //     odoobot.im_status = 'bot'
            */
            return default;
        }

        protected async Task<ResPartner> ComputeImplementedPartnerCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_implemented_partner_count(self):
            // rg_result = self.env['res.partner']._read_group(
            //     [('assigned_partner_id', 'in', self.ids),
            //      ('is_published', '=', True)],
            //     ['assigned_partner_id'],
            //     ['__count'],
            // )
            // rg_data = {assigned_partner.id: count for assigned_partner, count in rg_result}
            // for partner in self:
            //     partner.implemented_partner_count = rg_data.get(partner.id, 0)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeInvoiceEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_invoice_edi_format(self):
            // for partner in self:
            //     if not partner.commercial_partner_id or partner.commercial_partner_id.invoice_edi_format_store == 'none':
            //         partner.invoice_edi_format = False
            //     else:
            //         partner.invoice_edi_format = partner.commercial_partner_id.invoice_edi_format_store or partner.commercial_partner_id._get_suggested_invoice_edi_format()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsMondialrelayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py) ---
            // def _compute_is_mondialrelay(self):
            // for p in self:
            //     p.is_mondialrelay = p.ref and p.ref.startswith('MR#')
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsPeppolEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_is_peppol_edi_format(self):
            // for partner in self:
            //     partner.is_peppol_edi_format = partner.invoice_edi_format in self._get_peppol_formats()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsPublicInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_is_public(self):
            // for partner in self.with_context(active_test=False):
            //     users = partner.user_ids
            //     partner.is_public = users and any(user._is_public() for user in users)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsSubcontractorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_is_subcontractor(self):
            // """ Determine whether the partner is a subcontractor (for giving sudo access) """
            // for partner in self:
            //     partner.is_subcontractor = (
            //         any(user._is_portal() for user in partner.user_ids)
            //         and partner.env['mrp.bom'].search_count([
            //             ('type', '=', 'subcontract'),
            //             ('subcontractor_ids', 'in', (partner | partner.commercial_partner_id).ids),
            //         ], limit=1)
            //     )
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsUblFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_is_ubl_format(self):
            // for partner in self:
            //     partner.is_ubl_format = partner.invoice_edi_format in self._get_ubl_cii_formats()
            */
            return default;
        }

        protected async Task<ResPartner> ComputeJournalItemCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_journal_item_count(self):
            // AccountMoveLine = self.env['account.move.line']
            // for partner in self:
            //     partner.journal_item_count = AccountMoveLine.search_count([('partner_id', '=', partner.id)])
            */
            return default;
        }

        protected async Task<ResPartner> ComputeLastWebsiteSoIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def _compute_last_website_so_id(self):
            // SaleOrder = self.env['sale.order']
            // for partner in self:
            //     is_public = partner.is_public
            //     website = ir_http.get_request_website()
            //     if website and not is_public:
            //         partner.last_website_so_id = SaleOrder.search([
            //             ('partner_id', '=', partner.id),
            //             ('pricelist_id', '=', partner.property_product_pricelist.id),
            //             ('website_id', '=', website.id),
            //             ('state', '=', 'draft'),
            //         ], order='write_date desc', limit=1)
            //     else:
            //         partner.last_website_so_id = SaleOrder
            */
            return default;
        }

        protected async Task<ResPartner> ComputeMeetingCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _compute_meeting_count(self):
            // result = self._compute_meeting()
            // for p in self:
            //     p.meeting_count = len(result.get(p.id, []))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeMeetingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _compute_meeting(self):
            // if self.ids:
            //     # prefetch 'parent_id'
            //     all_partners = self.with_context(active_test=False).search_fetch(
            //         [('id', 'child_of', self.ids)], ['parent_id'],
            //     )
            // 
            //     query = self.env['calendar.event']._search([])  # ir.rules will be applied
            //     meeting_data = self.env.execute_query(SQL("""
            //         SELECT res_partner_id, calendar_event_id, count(1)
            //           FROM calendar_event_res_partner_rel
            //          WHERE res_partner_id IN %s AND calendar_event_id IN %s
            //       GROUP BY res_partner_id, calendar_event_id
            //         """,
            //         all_partners._ids,
            //         query.subselect(),
            //     ))
            // 
            //     # Create a dict {partner_id: event_ids} and fill with events linked to the partner
            //     meetings = {}
            //     for p_id, m_id, _ in meeting_data:
            //         meetings.setdefault(p_id, set()).add(m_id)
            // 
            //     # Add the events linked to the children of the partner
            //     for p in self.browse(meetings.keys()):
            //         partner = p
            //         while partner.parent_id:
            //             partner = partner.parent_id
            //             if partner in self:
            //                 meetings[partner.id] = meetings.get(partner.id, set()) | meetings[p.id]
            //     return {p_id: list(meetings.get(p_id, set())) for p_id in self.ids}
            // return {}
            */
            return default;
        }

        protected async Task<ResPartner> ComputeMembershipStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _compute_membership_state(self):
            // today = fields.Date.today()
            // for partner in self:
            //     partner.membership_start = self.env['membership.membership_line'].search([
            //         ('partner', 'in', (partner.associate_member or partner).ids), ('date_cancel', '=', False)
            //     ], limit=1, order='date_from').date_from
            //     partner.membership_stop = self.env['membership.membership_line'].search([
            //         ('partner', 'in', (partner.associate_member or partner).ids), ('date_cancel', '=', False)
            //     ], limit=1, order='date_to desc').date_to
            //     partner.membership_cancel = self.env['membership.membership_line'].search([
            //         ('partner', 'in', partner.ids)
            //     ], limit=1, order='date_cancel').date_cancel
            // 
            //     if partner.associate_member:
            //         partner.membership_state = partner.associate_member.membership_state
            //         continue
            // 
            //     if partner.free_member and partner.membership_state != 'paid':
            //         partner.membership_state = 'free'
            //         continue
            // 
            //     for mline in partner.member_lines:
            //         if (mline.date_to or date.min) >= today and (mline.date_from or date.min) <= today:
            //             partner.membership_state = mline.state
            //             break
            //         elif ((mline.date_from or date.min) < today and (mline.date_to or date.min) <= today and \
            //               (mline.date_from or date.min) < (mline.date_to or date.min)):
            //             if mline.account_invoice_id and mline.account_invoice_id.payment_state in ('in_payment', 'paid'):
            //                 partner.membership_state = 'old'
            //             elif mline.account_invoice_id and mline.account_invoice_id.state == 'cancel':
            //                 partner.membership_state = 'canceled'
            //             break
            //     else:
            //         partner.membership_state = 'none'
            */
            return default;
        }

        protected async Task<ResPartner> ComputeOnTimeRateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py) ---
            // def _compute_on_time_rate(self):
            // date_order_days_delta = int(self.env['ir.config_parameter'].sudo().get_param('purchase_stock.on_time_delivery_days', default='365'))
            // order_lines = self.env['purchase.order.line'].search([
            //     ('partner_id', 'in', self.ids),
            //     ('date_order', '>', fields.Date.today() - timedelta(date_order_days_delta)),
            //     ('qty_received', '!=', 0),
            //     ('order_id.state', 'in', ['done', 'purchase']),
            //     ('product_id', 'in', self.env['product.product'].sudo()._search([('type', '!=', 'service')]))
            // ])
            // lines_quantity = defaultdict(lambda: 0)
            // moves = self.env['stock.move'].search([
            //     ('purchase_line_id', 'in', order_lines.ids),
            //     ('state', '=', 'done')])
            // # Fetch fields from db and put them in cache.
            // order_lines.read(['date_planned', 'partner_id', 'product_uom_qty'], load='')
            // moves.read(['purchase_line_id', 'date'], load='')
            // moves = moves.filtered(lambda m: m.date.date() <= m.purchase_line_id.date_planned.date())
            // for move, quantity in zip(moves, moves.mapped('quantity')):
            //     lines_quantity[move.purchase_line_id.id] += quantity
            // partner_dict = {}
            // for line in order_lines:
            //     on_time, ordered = partner_dict.get(line.partner_id, (0, 0))
            //     ordered += line.product_uom_qty
            //     on_time += lines_quantity[line.id]
            //     partner_dict[line.partner_id] = (on_time, ordered)
            // seen_partner = self.env['res.partner']
            // for partner, numbers in partner_dict.items():
            //     seen_partner |= partner
            //     on_time, ordered = numbers
            //     partner.on_time_rate = on_time / ordered * 100 if ordered else -1   # use negative number to indicate no data
            // (self - seen_partner).on_time_rate = -1
            */
            return default;
        }

        protected async Task<ResPartner> ComputeOpportunityCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: res_partner.py) ---
            // def _compute_opportunity_count(self):
            // self.opportunity_count = 0
            // if not self.env.user._has_group('sales_team.group_sale_salesman'):
            //     return
            // 
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)], ['parent_id'],
            // )
            // 
            // opportunity_data = self.env['crm.lead'].with_context(active_test=False)._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // for partner, count in opportunity_data:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.opportunity_count += count
            //         partner = partner.parent_id
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_opportunity_count(self):
            // super()._compute_opportunity_count()
            // if not self.env.user.has_group('sales_team.group_sale_salesman'):
            //     return
            // 
            // opportunity_data = self.env['crm.lead'].with_context(active_test=False)._read_group(
            //     [('partner_assigned_id', 'in', self.ids)],
            //     ['partner_assigned_id'], ['__count']
            // )
            // assign_counts = {partner_assigned.id: count for partner_assigned, count in opportunity_data}
            // for partner in self:
            //     partner.opportunity_count += assign_counts.get(partner.id, 0)
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerCompanyRegistryPlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_partner_company_registry_placeholder(self):
            // """ Provides a dynamic placeholder on the company registry field for countries that may need it.
            // Add your country and the value you want in the _ref_company_registry map.
            // """
            // for partner in self:
            //     country_code = partner.country_id.code or ''
            //     partner.partner_company_registry_placeholder = _ref_company_registry.get(country_code.lower(), '')
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerIapInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py) ---
            // def _compute_partner_iap_info(self):
            // partner_iaps = self.env['res.partner.iap'].sudo().search([('partner_id', 'in', self.ids)])
            // partner_iaps_per_partner = {
            //     partner_iap.partner_id: partner_iap
            //     for partner_iap in partner_iaps
            // }
            // 
            // for partner in self:
            //     partner_iap = partner_iaps_per_partner.get(partner)
            //     if partner_iap:
            //         partner.iap_enrich_info = partner_iap.iap_enrich_info
            //         partner.iap_search_domain = partner_iap.iap_search_domain
            //     else:
            //         partner.iap_enrich_info = False
            //         partner.iap_search_domain = False
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerShareInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_partner_share(self):
            // super_partner = self.env['res.users'].browse(SUPERUSER_ID).partner_id
            // if super_partner in self:
            //     super_partner.partner_share = False
            // for partner in self - super_partner:
            //     partner.partner_share = not partner.user_ids or not any(not user.share for user in partner.user_ids)
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerVatPlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_partner_vat_placeholder(self):
            // for partner in self:
            //     placeholder = _("/ if not applicable")
            //     if partner.country_id:
            //         expected_vat = _ref_vat.get(partner.country_id.code.lower())
            //         if expected_vat:
            //             placeholder = _("%s, or / if not applicable", expected_vat)
            // 
            //     partner.partner_vat_placeholder = placeholder
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerWeightInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_partner_weight(self):
            // for partner in self:
            //     partner.partner_weight = partner.grade_id.partner_weight if partner.grade_id else 0
            */
            return default;
        }

        protected async Task<ResPartner> ComputePaymentTokenCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: res_partner.py) ---
            // def _compute_payment_token_count(self):
            // payments_data = self.env['payment.token']._read_group(
            //     [('partner_id', 'in', self.ids)], ['partner_id'], ['__count'],
            // )
            // partners_data = {partner.id: count for partner, count in payments_data}
            // for partner in self:
            //     partner.payment_token_count = partners_data.get(partner.id, 0)
            */
            return default;
        }

        protected async Task<ResPartner> ComputePeppolEasInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_peppol_eas(self):
            // """
            // If the country_code changes, recompute the EAS only if there is a country_code, it exists in the
            // EAS_MAPPING, and the current EAS is not consistent with the new country_code.
            // """
            // for partner in self:
            //     partner.peppol_eas = partner.peppol_eas
            //     country_code = partner._deduce_country_code()
            //     if country_code in EAS_MAPPING:
            //         eas_to_field = EAS_MAPPING[country_code]
            //         if partner.peppol_eas not in eas_to_field.keys():
            //             new_eas = next(iter(EAS_MAPPING[country_code].keys()))
            //             # Iterate on the possible EAS until a valid one is found
            //             for eas, field in eas_to_field.items():
            //                 if field and field in partner._fields and partner[field]:
            //                     if not partner._build_error_peppol_endpoint(eas, partner[field]):
            //                         new_eas = eas
            //                         break
            //             partner.peppol_eas = new_eas
            */
            return default;
        }

        protected async Task<ResPartner> ComputePeppolEndpointInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_peppol_endpoint(self):
            // """ If the EAS changes and a valid endpoint is available, set it. Otherwise, keep the existing value."""
            // for partner in self:
            //     partner.peppol_endpoint = partner.peppol_endpoint
            //     country_code = partner._deduce_country_code()
            //     if country_code in EAS_MAPPING:
            //         field = EAS_MAPPING[country_code].get(partner.peppol_eas)
            //         if field \
            //                 and field in partner._fields \
            //                 and partner[field] \
            //                 and not partner._build_error_peppol_endpoint(partner.peppol_eas, partner[field]):
            //             partner.peppol_endpoint = partner[field]
            */
            return default;
        }

        protected async Task<ResPartner> ComputePerformViesValidationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _compute_perform_vies_validation(self):
            // """ Determine whether to show VIES validity on the current VAT number """
            // for partner in self:
            //     to_check = partner.vies_vat_to_check
            //     company_code = self.env.company.account_fiscal_country_id.code
            //     partner.perform_vies_validation = (
            //         to_check
            //         and not to_check[:2].upper() == company_code
            //         and self.env.company.vat_check_vies
            //     )
            */
            return default;
        }

        protected async Task<ResPartner> ComputePickingIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_picking_ids(self):
            // results = self.env['stock.picking']._read_group([('partner_id.commercial_partner_id', 'in', self.commercial_partner_id.ids)], ['partner_id'], ['id:array_agg'])
            // for partner in self:
            //     picking_ids = []
            //     for partner_rg, ids in results:
            //         if partner_rg.id == partner.id or partner_rg.id in partner.child_ids.ids:
            //             picking_ids += ids
            //     partner.picking_ids = picking_ids
            */
            return default;
        }

        protected async Task<ResPartner> ComputePosOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def _compute_pos_order(self):
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // pos_order_data = self.env['pos.order']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // self.pos_order_count = 0
            // for partner, count in pos_order_data:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.pos_order_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeProductPricelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _compute_product_pricelist(self):
            // res = self.env['product.pricelist']._get_partner_pricelist_multi(self._ids)
            // for partner in self:
            //     partner.property_product_pricelist = res.get(partner.id)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeProductionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _compute_production_ids(self):
            // results = self.env['mrp.production']._read_group([('subcontractor_id.commercial_partner_id', 'in', self.commercial_partner_id.ids)], ['subcontractor_id'], ['id:array_agg'])
            // for partner in self:
            //     production_ids = []
            //     for subcontractor, ids in results:
            //         if partner.id == subcontractor.id or subcontractor.id in partner.child_ids.ids:
            //             production_ids += ids
            //     partner.production_ids = production_ids
            */
            return default;
        }

        protected async Task<ResPartner> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: res_partner.py) ---
            // def _compute_purchase_order_count(self):
            // self.purchase_order_count = 0
            // if not self.env.user._has_group('purchase.group_purchase_user'):
            //     return
            // 
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // purchase_order_groups = self.env['purchase.order']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count'],
            // )
            // self_ids = set(self._ids)
            // 
            // for partner, count in purchase_order_groups:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.purchase_order_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _compute_sale_order_count(self):
            // self.sale_order_count = 0
            // if not self.env.user._has_group('sales_team.group_sale_salesman'):
            //     return
            // 
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // sale_order_groups = self.env['sale.order']._read_group(
            //     domain=expression.AND([self._get_sale_order_domain_count(), [('partner_id', 'in', all_partners.ids)]]),
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // for partner, count in sale_order_groups:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.sale_order_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSameVatPartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_same_vat_partner_id(self):
            // for partner in self:
            //     # use _origin to deal with onchange()
            //     partner_id = partner._origin.id
            //     #active_test = False because if a partner has been deactivated you still want to raise the error,
            //     #so that you can reactivate it instead of creating a new one, which would loose its history.
            //     Partner = self.with_context(active_test=False).sudo()
            //     domain = [
            //         ('vat', '=', partner.vat),
            //     ]
            //     if partner.company_id:
            //         domain += [('company_id', 'in', [False, partner.company_id.id])]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     # For VAT number being only one character, we will skip the check just like the regular check_vat
            //     should_check_vat = partner.vat and len(partner.vat) != 1
            //     partner.same_vat_partner_id = should_check_vat and not partner.parent_id and Partner.search(domain, limit=1)
            //     # check company_registry
            //     domain = [
            //         ('company_registry', '=', partner.company_registry),
            //         ('company_id', 'in', [False, partner.company_id.id]),
            //     ]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     partner.same_company_registry_partner_id = bool(partner.company_registry) and not partner.parent_id and Partner.search(domain, limit=1)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeShowCreditLimitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_show_credit_limit(self):
            // for partner in self:
            //     partner.show_credit_limit = self.env.company.account_use_credit_limit
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSlideChannelCompanyCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _compute_slide_channel_company_count(self):
            // for partner in self:
            //     if partner.is_company:
            //         partner.slide_channel_company_count = self.env['slide.channel'].sudo().search_count(
            //             [('partner_ids', 'in', partner.child_ids.ids)]
            //         )
            //     else:
            //         partner.slide_channel_company_count = 0
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSlideChannelValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _compute_slide_channel_values(self):
            // data = {
            //     (partner.id, member_status): channel_ids
            //     for partner, member_status, channel_ids in self.env['slide.channel.partner'].sudo()._read_group(
            //         domain=[('partner_id', 'in', self.ids), ('member_status', '!=', 'invited')],
            //         groupby=['partner_id', 'member_status'],
            //         aggregates=['channel_id:array_agg']
            //     )
            // }
            // 
            // for partner in self:
            //     slide_channel_ids = data.get((partner.id, 'joined'), []) + data.get((partner.id, 'ongoing'), []) + data.get((partner.id, 'completed'), [])
            //     partner.slide_channel_ids = slide_channel_ids
            //     partner.slide_channel_completed_ids = self.env['slide.channel'].browse(data.get((partner.id, 'completed'), []))
            //     partner.slide_channel_count = len(slide_channel_ids)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeStaticMapUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_static_map_url(self):
            // for partner in self:
            //     partner.static_map_url = partner._google_map_signed_img(zoom=13, width=598, height=200)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeStaticMapUrlIsValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_static_map_url_is_valid(self):
            // """Compute whether the link is valid.
            // 
            // This should only remain valid for a relatively short time.
            // Here, for the duration it is in cache.
            // """
            // session = requests.Session()
            // for partner in self:
            //     url = partner.static_map_url
            //     if not url:
            //         partner.static_map_url_is_valid = False
            //         continue
            // 
            //     is_valid = False
            //     # If the response isn't strictly successful, assume invalid url
            //     try:
            //         res = session.get(url, timeout=2)
            //         if res.ok and not res.headers.get('X-Staticmap-API-Warning'):
            //             is_valid = True
            //     except requests.exceptions.RequestException:
            //         pass
            // 
            //     partner.static_map_url_is_valid = is_valid
            */
            return default;
        }

        protected async Task<ResPartner> ComputeStreetDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _compute_street_data(self):
            // """Splits street value into sub-fields.
            // Recomputes the fields of STREET_FIELDS when `street` of a partner is updated"""
            // for partner in self:
            //     partner.update(tools.street_split(partner.street))
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSupplierInvoiceCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_supplier_invoice_count(self):
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // supplier_invoice_groups = self.env['account.move']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids),
            //             *self.env['account.move']._check_company_domain(self.env.company),
            //             ('move_type', 'in', ('in_invoice', 'in_refund'))],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // self.supplier_invoice_count = 0
            // for partner, count in supplier_invoice_groups:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.supplier_invoice_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeTaskCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _compute_task_count(self):
            // # retrieve all children partners and prefetch 'parent_id' on them
            // all_partners = self.with_context(active_test=False).search_fetch(
            //     [('id', 'child_of', self.ids)],
            //     ['parent_id'],
            // )
            // task_data = self.env['project.task']._read_group(
            //     domain=[('partner_id', 'in', all_partners.ids)],
            //     groupby=['partner_id'], aggregates=['__count']
            // )
            // self_ids = set(self._ids)
            // 
            // self.task_count = 0
            // for partner, count in task_data:
            //     while partner:
            //         if partner.id in self_ids:
            //             partner.task_count += count
            //         partner = partner.parent_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeTzOffsetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        protected async Task<ResPartner> ComputeUsePartnerCreditLimitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_use_partner_credit_limit(self):
            // company_limit = self._fields['credit_limit'].get_company_dependent_fallback(self)
            // for partner in self:
            //     partner.use_partner_credit_limit = partner.credit_limit != company_limit
            */
            return default;
        }

        protected async Task<ResPartner> ComputeUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_user_id(self):
            // """ Synchronize sales rep with parent if partner is a person """
            // for partner in self.filtered(lambda partner: not partner.user_id and partner.company_type == 'person' and partner.parent_id.user_id):
            //     partner.user_id = partner.parent_id.user_id
            */
            return default;
        }

        protected async Task<ResPartner> ComputeUserLivechatUsernameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _compute_user_livechat_username(self):
            // for partner in self:
            //     partner.user_livechat_username = next(iter(partner.user_ids.mapped('livechat_username')), False)
            */
            return default;
        }

        protected async Task<ResPartner> ComputeVatLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        protected async Task<ResPartner> ComputeViesValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _compute_vies_valid(self):
            // """ Check the VAT number with VIES, if enabled."""
            // if not self.env['res.company'].sudo().search_count([('vat_check_vies', '=', True)]):
            //     self.vies_valid = False
            //     return
            // 
            // for partner in self:
            //     if not partner.vies_vat_to_check:
            //         partner.vies_valid = False
            //         continue
            //     if partner.parent_id and partner.parent_id.vies_vat_to_check == partner.vies_vat_to_check:
            //         partner.vies_valid = partner.parent_id.vies_valid
            //         continue
            //     try:
            //         _logger.info('Calling VIES service to check VAT for validation: %s', partner.vies_vat_to_check)
            //         vies_valid = check_vies(partner.vies_vat_to_check, timeout=10)
            //         partner.vies_valid = vies_valid['valid']
            //     except (OSError, InvalidComponent, zeep.exceptions.Fault) as e:
            //         if partner._origin.id:
            //             msg = ""
            //             if isinstance(e, OSError):
            //                 msg = _("Connection with the VIES server failed. The VAT number %s could not be validated.", partner.vies_vat_to_check)
            //             elif isinstance(e, InvalidComponent):
            //                 msg = _("The VAT number %s could not be interpreted by the VIES server.", partner.vies_vat_to_check)
            //             elif isinstance(e, zeep.exceptions.Fault):
            //                 msg = _('The request for VAT validation was not processed. VIES service has responded with the following error: %s', e.message)
            //             partner._origin.message_post(body=msg)
            //         _logger.warning("The VAT number %s failed VIES check.", partner.vies_vat_to_check)
            //         partner.vies_valid = False
            */
            return default;
        }

        protected async Task<ResPartner> ComputeViesVatToCheckInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _compute_vies_vat_to_check(self):
            // """ Retrieve the VAT number, if one such exists, to be used when checking against the VIES system """
            // eu_country_codes = self.env.ref('base.europe').country_ids.mapped('code')
            // for partner in self:
            //     # Skip checks when only one character is used. Some users like to put '/' or other as VAT to differentiate between
            //     # a partner for which they haven't yet input VAT, and one not subject to VAT
            //     if not partner.vat or len(partner.vat) == 1:
            //         partner.vies_vat_to_check = ''
            //         continue
            //     country_code, number = partner._split_vat(partner.vat)
            //     if not country_code.isalpha() and partner.country_id:
            //         country_code = partner.country_id.code
            //         number = partner.vat
            //     partner.vies_vat_to_check = (
            //         country_code.upper() in eu_country_codes or
            //         country_code.lower() in _region_specific_vat_codes
            //     ) and self._fix_vat_number(country_code + number, partner.country_id.id) or ''
            */
            return default;
        }

        protected async Task<ResPartner> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py) ---
            // def _compute_website_url(self):
            // super(WebsiteResPartner, self)._compute_website_url()
            // for partner in self:
            //     partner.website_url = "/partners/%s" % self.env['ir.http']._slug(partner)
            */
            return default;
        }

        protected async Task<ResPartner> ConvertHuLocalToEuVatInternalAsync(object local_vat)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _convert_hu_local_to_eu_vat(self, local_vat):
            // if self.__check_tin_hu_companies_re.match(local_vat):
            //     return f'HU{local_vat[:8]}'
            // return False
            */
            return default;
        }

        public async Task<ResPartner> CopyDataAsync(Guid id, ResPartnerCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if default.get('name'):
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", partner.name)) for partner, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ResPartner> CreateAsync(ResPartner entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def create(self, vals_list):
            // search_partner_mode = self.env.context.get('res_partner_search_mode')
            // is_customer = search_partner_mode == 'customer'
            // is_supplier = search_partner_mode == 'supplier'
            // if search_partner_mode:
            //     for vals in vals_list:
            //         if is_customer and 'customer_rank' not in vals:
            //             vals['customer_rank'] = 1
            //         elif is_supplier and 'supplier_rank' not in vals:
            //             vals['supplier_rank'] = 1
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // if res:
            //     res._update_peppol_state_per_company()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if values.get('vat'):
            //         country_id = values.get('country_id')
            //         values['vat'] = self._fix_vat_number(values['vat'], country_id)
            // res = super().create(vals_list)
            // if self.env.context.get('import_file'):
            //     res.env.remove_to_compute(self._fields['vies_valid'], res)
            // return res
            --- ODOO METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py) ---
            // def create(self, vals_list):
            // partners = super().create(vals_list)
            // # Not done with inverse method so we do not need to search
            // # for existing <res.partner.iap>
            // partner_iap_vals_list = [{
            //     'partner_id': partner.id,
            //     'iap_enrich_info': vals.get('iap_enrich_info'),
            //     'iap_search_domain': vals.get('iap_search_domain'),
            // } for partner, vals in zip(partners, vals_list) if vals.get('iap_enrich_info') or vals.get('iap_search_domain')]
            // self.env['res.partner.iap'].sudo().create(partner_iap_vals_list)
            // return partners
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create(self, vals_list):
            // if self.env.context.get('import_file'):
            //     self._check_import_consistency(vals_list)
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self._clean_website(vals['website'])
            //     if vals.get('parent_id'):
            //         vals['company_name'] = False
            // partners = super().create(vals_list)
            // 
            // if self.env.context.get('_partners_skip_fields_sync'):
            //     return partners
            // 
            // for partner, vals in zip(partners, vals_list):
            //     partner._fields_sync(vals)
            //     # Lang: propagate from parent if no value was given
            //     if 'lang' not in vals and partner.parent_id:
            //         partner._onchange_parent_id_for_lang()
            //     partner._handle_first_contact_creation()
            // return partners
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<ResPartner> CreateCompanyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create_company(self):
            // self.ensure_one()
            // if self.company_name:
            //     # Create parent company
            //     values = dict(name=self.company_name, is_company=True, vat=self.vat)
            //     values.update(self._update_fields_values(self._address_fields()))
            //     new_company = self.create(values)
            //     # Set new company as my parent
            //     self.write({
            //         'parent_id': new_company.id,
            //         'child_ids': [Command.update(partner_id, dict(parent_id=new_company.id)) for partner_id in self.child_ids.ids]
            //     })
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> CreateMembershipInvoiceAsync(Guid id, ResPartnerCreateMembershipInvoiceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def create_membership_invoice(self, product, amount):
            // """ Create Customer Invoice of Membership for partners.
            // """
            // invoice_vals_list = []
            // for partner in self:
            //     addr = partner.address_get(['invoice'])
            //     if partner.free_member:
            //         raise UserError(_("Partner is a free Member."))
            //     if not addr.get('invoice', False):
            //         raise UserError(_("Partner doesn't have an address to make the invoice."))
            // 
            //     invoice_vals_list.append({
            //         'move_type': 'out_invoice',
            //         'partner_id': partner.id,
            //         'invoice_line_ids': [
            //             (
            //                 0,
            //                 None,
            //                 {
            //                     'product_id': product.id,
            //                     'quantity': 1,
            //                     'price_unit': amount,
            //                     'tax_ids': [(6, 0, product.taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(self.env.company)).ids)]
            //                 }
            //              )
            //         ]
            //     })
            // 
            // return self.env['account.move'].create(invoice_vals_list)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> CreatePortalUsersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _create_portal_users(self):
            // partners_without_user = self.filtered(lambda partner: not partner.user_ids)
            // if not partners_without_user:
            //     return self.env['res.users']
            // created_users = self.env['res.users']
            // for partner in partners_without_user:
            //     created_users += self.env['res.users'].with_context(no_reset_password=True).sudo()._create_user_from_template({
            //         'email': email_normalize(partner.email),
            //         'login': email_normalize(partner.email),
            //         'partner_id': partner.id,
            //         'company_id': self.env.company.id,
            //         'company_ids': [(6, 0, self.env.company.ids)],
            //         'active': True,
            //     })
            // return created_users
            */
            return default;
        }

        protected async Task<ResPartner> CreditDebitGetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _credit_debit_get(self):
            // if not self.ids:
            //     self.debit = False
            //     self.credit = False
            //     return
            // query = self.env['account.move.line']._where_calc([
            //     ('parent_state', '=', 'posted'),
            //     ('company_id', 'child_of', self.env.company.root_id.id)
            // ])
            // self.env['account.move.line'].flush_model(
            //     ['account_id', 'amount_residual', 'company_id', 'parent_state', 'partner_id', 'reconciled']
            // )
            // self.env['account.account'].flush_model(['account_type'])
            // sql = SQL("""
            //     SELECT account_move_line.partner_id, a.account_type, SUM(account_move_line.amount_residual)
            //     FROM %s
            //     LEFT JOIN account_account a ON (account_move_line.account_id=a.id)
            //     WHERE a.account_type IN ('asset_receivable','liability_payable')
            //     AND account_move_line.partner_id IN %s
            //     AND account_move_line.reconciled IS NOT TRUE
            //     AND %s
            //     GROUP BY account_move_line.partner_id, a.account_type
            //     """,
            //     query.from_clause,
            //     tuple(self.ids),
            //     query.where_clause or SQL("TRUE"),
            // )
            // treated = self.browse()
            // for pid, account_type, val in self.env.execute_query(sql):
            //     partner = self.browse(pid)
            //     if account_type == 'asset_receivable':
            //         partner.credit = val
            //         if partner not in treated:
            //             partner.debit = False
            //             treated |= partner
            //     elif account_type == 'liability_payable':
            //         partner.debit = -val
            //         if partner not in treated:
            //             partner.credit = False
            //             treated |= partner
            // remaining = (self - treated)
            // remaining.debit = False
            // remaining.credit = False
            */
            return default;
        }

        protected async Task<ResPartner> CreditSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _credit_search(self, operator, operand):
            // return self._asset_difference_search('asset_receivable', operator, operand)
            */
            return default;
        }

        protected async Task<ResPartner> CronUpdateMembershipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _cron_update_membership(self):
            // partners = self.search([('membership_state', 'in', ['invoiced', 'paid'])])
            // # mark the field to be recomputed, and recompute it
            // self.env.add_to_compute(self._fields['membership_state'], partners)
            */
            return default;
        }

        protected async Task<ResPartner> DebitSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _debit_search(self, operator, operand):
            // return self._asset_difference_search('liability_payable', operator, operand)
            */
            return default;
        }

        protected async Task<ResPartner> DeduceCountryCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _deduce_country_code(self):
            // """ deduce the country code based on the information available.
            // we have three cases:
            // - country_code is BE but the VAT number starts with FR, the country code is FR, not BE
            // - if a country-specific field is set (e.g. the codice_fiscale), that country is used for the country code
            // - if the VAT number has no ISO country code, use the country_code in that case.
            // """
            // self.ensure_one()
            // 
            // country_code = self.country_code
            // if self.vat and self.vat[:2].isalpha():
            //     country_code = self.vat[:2].upper()
            // return country_code
            */
            return default;
        }

        protected async Task<ResPartner> DefaultCategoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self._context.get('category_id'))
            */
            return default;
        }

        protected async Task<ResPartner> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _default_display_invoice_template_pdf_report_id(self):
            // available_templates_count = self.env['ir.actions.report'].search_count([('is_invoice_report', '=', True)], limit=2)
            // return available_templates_count > 1
            */
            return default;
        }

        public override async Task<ResPartner> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: res_partner.py) ---
            // def default_get(self, fields):
            // rec = super(Partner, self).default_get(fields)
            // active_model = self.env.context.get('active_model')
            // if active_model == 'crm.lead' and len(self.env.context.get('active_ids', [])) <= 1:
            //     lead = self.env[active_model].browse(self.env.context.get('active_id')).exists()
            //     if lead:
            //         rec.update(
            //             phone=lead.phone,
            //             mobile=lead.mobile,
            //             function=lead.function,
            //             title=lead.title.id,
            //             website=lead.website,
            //             street=lead.street,
            //             street2=lead.street2,
            //             city=lead.city,
            //             state_id=lead.state_id.id,
            //             country_id=lead.country_id.id,
            //             zip=lead.zip,
            //         )
            // return rec
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def default_get(self, fields_list):
            // default_vals = super().default_get(fields_list)
            // if self.env.context.get('partner_set_default_grade_activation'):
            //     # sets the lowest grade and activation if no default values given, mainly useful while
            //     # creating assigned partner on the fly (to make it visible in same m2o again)
            //     if 'grade_id' in fields_list and not default_vals.get('grade_id'):
            //         default_vals['grade_id'] = self.env['res.partner.grade'].search([], order='sequence', limit=1).id
            //     if 'activation' in fields_list and not default_vals.get('activation'):
            //         default_vals['activation'] = self.env['res.partner.activation'].search([], order='sequence', limit=1).id
            // return default_vals
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def default_get(self, default_fields):
            // """Add the company of the parent as default if we are creating a child partner.
            // Also take the parent lang by default if any, otherwise, fallback to default DB lang."""
            // values = super().default_get(default_fields)
            // parent = self.env["res.partner"]
            // if 'parent_id' in default_fields and values.get('parent_id'):
            //     parent = self.browse(values.get('parent_id'))
            //     values['company_id'] = parent.company_id.id
            // if 'lang' in default_fields:
            //     values['lang'] = values.get('lang') or parent.lang or self.env.lang
            // # protection for `default_type` values leaking from menu action context (e.g. for crm's email)
            // if 'type' in default_fields and values.get('type'):
            //     if values['type'] not in self._fields['type'].get_values(self.env):
            //         values['type'] = None
            // return values
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<ResPartner> DisplayAddressDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address_depends(self):
            // # field dependencies of method _display_address()
            // return self._formatting_address_fields() + [
            //     'country_id', 'company_name', 'state_id',
            // ]
            */
            return default;
        }

        protected async Task<ResPartner> DisplayAddressInternalAsync(object without_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address(self, without_company=False):
            // '''
            // The purpose of this function is to build and return an address formatted accordingly to the
            // standards of the country where it belongs.
            // 
            // :param without_company: if address contains company
            // :returns: the address formatted in a display that fit its country habits (or the default ones
            //     if not country is specified)
            // :rtype: string
            // '''
            // address_format, args = self._prepare_display_address(without_company)
            // return address_format % args
            */
            return default;
        }

        public async Task<ResPartner> DoButtonPrintAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_button_print(self):
            // self.ensure_one()
            // company_id = self.env.user.company_id.id
            // if not self.env['account.move.line'].search(
            //         [('partner_id', '=', self.id),
            //          ('account_id.account_type', '=', 'asset_receivable'),
            //          ('full_reconcile_id', '=', False),
            //          ('company_id', '=', company_id),
            //          '|', ('date_maturity', '=', False),
            //          ('date_maturity', '<=', fields.Date.today())]):
            //     raise ValidationError(
            //         _("The partner does not have any accounting entries to "
            //           "print in the overdue report for the current company."))
            // self.message_post(body=_('Printed overdue payments report'))
            // self.message_post(body=_('Printed overdue payments report'))
            // 
            // wizard_partner_ids = [self.id * 10000 + company_id]
            // followup_ids = self.env['followup.followup'].search(
            //     [('company_id', '=', company_id)])
            // if not followup_ids:
            //     raise ValidationError(_(
            //         "There is no followup plan defined for the current company."))
            // data = {
            //     'date': fields.date.today(),
            //     'followup_id': followup_ids[0].id,
            // }
            // return self.do_partner_print(wizard_partner_ids, data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> DoPartnerMailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_mail(self):
            // ctx = self.env.context.copy()
            // ctx['followup'] = True
            // template = 'om_account_followup.email_template_om_account_followup_default'
            // unknown_mails = 0
            // for partner in self:
            //     partners_to_email = [child for child in partner.child_ids if
            //                          child.type == 'invoice' and child.email]
            //     if not partners_to_email and partner.email:
            //         partners_to_email = [partner]
            //     if partners_to_email:
            //         level = partner.latest_followup_level_id_without_lit
            //         for partner_to_email in partners_to_email:
            //             if level and level.send_email and \
            //                     level.email_template_id and \
            //                     level.email_template_id.id:
            //                 level.email_template_id.with_context(ctx).send_mail(
            //                     partner_to_email.id)
            //             else:
            //                 mail_template_id = self.env.ref(template)
            //                 mail_template_id.with_context(ctx).send_mail(
            //                     partner_to_email.id)
            //         if partner not in partners_to_email:
            //             partner.message_post(body=_(
            //                 'Overdue email sent to %s' % ', '.join(
            //                     ['%s <%s>' % (partner.name, partner.email) for
            //                      partner in partners_to_email])))
            //     else:
            //         unknown_mails = unknown_mails + 1
            //         action_text = _("Email not sent because of email address "
            //                         "of partner not filled in")
            //         if partner.payment_next_action_date:
            //             payment_action_date = min(
            //                 fields.Date.today(),
            //                 partner.payment_next_action_date)
            //         else:
            //             payment_action_date = fields.Date.today()
            //         if partner.payment_next_action:
            //             payment_next_action = \
            //                 partner.payment_next_action + " \n " + action_text
            //         else:
            //             payment_next_action = action_text
            //         partner.with_context(ctx).write(
            //             {'payment_next_action_date': payment_action_date,
            //              'payment_next_action': payment_next_action})
            // return unknown_mails
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> DoPartnerManualActionAsync(Guid id, ResPartnerDoPartnerManualActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_manual_action(self, partner_ids):
            // for partner in self.browse(partner_ids):
            //     followup_without_lit = partner.latest_followup_level_id_without_lit
            //     if partner.payment_next_action:
            //         action_text = \
            //             (partner.payment_next_action or '') + "\n" + \
            //             (followup_without_lit.manual_action_note or '')
            //     else:
            //         action_text = followup_without_lit.manual_action_note or ''
            // 
            //     action_date = partner.payment_next_action_date or \
            //         fields.Date.today()
            // 
            //     if partner.payment_responsible_id:
            //         responsible_id = partner.payment_responsible_id.id
            //     else:
            //         p = followup_without_lit.manual_action_responsible_id
            //         responsible_id = p and p.id or False
            //     partner.write({'payment_next_action_date': action_date,
            //                    'payment_next_action': action_text,
            //                    'payment_responsible_id': responsible_id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> DoPartnerManualDermanordAsync(Guid id, ResPartnerDoPartnerManualDermanordRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_manual_action_dermanord(self, followup_line):
            // action_text = followup_line.manual_action_note or ''
            // 
            // action_date = self.payment_next_action_date or \
            //     fields.Date.today()
            // if self.payment_responsible_id:
            //     responsible_id = self.payment_responsible_id.id
            // else:
            //     p = followup_line.manual_action_responsible_id
            //     responsible_id = p and p.id or False
            // self.write({'payment_next_action_date': action_date,
            //             'payment_next_action': action_text,
            //             'payment_responsible_id': responsible_id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> DoPartnerPrintAsync(Guid id, ResPartnerDoPartnerPrintRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def do_partner_print(self, wizard_partner_ids, data):
            // if not wizard_partner_ids:
            //     return {}
            // data['partner_ids'] = wizard_partner_ids
            // datas = {
            //     'ids': wizard_partner_ids,
            //     'model': 'followup.followup',
            //     'form': data
            // }
            // return self.env.ref(
            //     'om_account_followup.action_report_followup').report_action(
            //     self, data=datas)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> DoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def action_done(self):
            // return self.write({'payment_next_action_date': False,
            //                    'payment_next_action': '',
            //                    'payment_responsible_id': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> EnrichByDomainAsync(Guid id, ResPartnerEnrichByDomainRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_domain(self, domain, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_domain', {
            //     'domain': domain,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> EnrichByDunsAsync(Guid id, ResPartnerEnrichByDunsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_duns(self, duns, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_duns', {
            //     'duns': duns,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> EnrichByGstAsync(Guid id, ResPartnerEnrichByGstRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_gst(self, gst, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_gst', {
            //     'gst': gst,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> EnrichCompanyAsync(Guid id, ResPartnerEnrichCompanyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_company(self, company_domain, partner_gid, vat, timeout=15):
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> EnsureSameCompanyThanProjectsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _ensure_same_company_than_projects(self):
            // for partner in self:
            //     if partner.company_id and partner.project_ids.company_id and partner.project_ids.company_id != partner.company_id:
            //         raise UserError(_("Partner company cannot be different from its assigned projects' company"))
            */
            return default;
        }

        protected async Task<ResPartner> EnsureSameCompanyThanTasksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def _ensure_same_company_than_tasks(self):
            // for partner in self:
            //     if partner.company_id and partner.task_ids.company_id and partner.task_ids.company_id != partner.company_id:
            //         raise UserError(_("Partner company cannot be different from its assigned tasks' company"))
            */
            return default;
        }

        public async Task<ResPartner> EventViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def action_event_view(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("event.action_event_view")
            // action['context'] = {}
            // action['domain'] = [('registration_ids.partner_id', 'child_of', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> FieldsSyncInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _fields_sync(self, values):
            // """ Sync commercial fields and address fields from company and to children after create/update,
            // just as if those were all modeled as fields.related to the parent """
            // # 1. From UPSTREAM: sync from parent
            // if values.get('parent_id') or values.get('type') == 'contact':
            //     # 1a. Commercial fields: sync if parent changed
            //     if values.get('parent_id'):
            //         self.sudo()._commercial_sync_from_company()
            //     # 1b. Address fields: sync if parent or use_parent changed *and* both are now set
            //     if self.parent_id and self.type == 'contact':
            //         onchange_vals = self.onchange_parent_id().get('value', {})
            //         self.update_address(onchange_vals)
            // 
            // # 2. To DOWNSTREAM: sync children
            // self._children_sync(values)
            */
            return default;
        }

        public async Task<ResPartner> FieldsViewGetAsync(Guid id, ResPartnerFieldsViewGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def fields_view_get(self, view_id=None, view_type='form', toolbar=False,
            //                 submenu=False):
            // res = super(ResPartner, self).fields_view_get(
            //     view_id=view_id, view_type=view_type, toolbar=toolbar,
            //     submenu=submenu)
            // if view_type == 'form' and self.env.context.get('Followupfirst'):
            //     doc = etree.XML(res['arch'], parser=None, base_url=None)
            //     first_node = doc.xpath("//page[@name='followup_tab']")
            //     root = first_node[0].getparent()
            //     root.insert(0, first_node[0])
            //     res['arch'] = etree.tostring(doc, encoding="utf-8")
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> FindAccountingPartnerInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _find_accounting_partner(self, partner):
            // ''' Find the partner for which the accounting entries will be created '''
            // return partner.commercial_partner_id
            */
            return default;
        }

        public async Task<ResPartner> FindOrCreateAsync(Guid id, ResPartnerFindOrCreateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Override to use the email_normalized field. """
            // if not email:
            //     raise ValueError(_('An email is required for find_or_create to work'))
            // 
            // parsed_name, parsed_email_normalized = tools.parse_contact_from_email(email)
            // if not parsed_email_normalized and assert_valid_email:
            //     raise ValueError(_('%(email)s is not recognized as a valid email. This is required to create a new customer.'))
            // if parsed_email_normalized:
            //     partners = self.search([('email_normalized', '=', parsed_email_normalized)], limit=1)
            //     if partners:
            //         return partners
            // 
            // # We don't want to call `super()` to avoid searching twice on the email
            // # Especially when the search `email =ilike` cannot be as efficient as
            // # a search on email_normalized with a btree index
            // # If you want to override `find_or_create()` your module should depend on `mail`
            // create_values = {self._rec_name: parsed_name or parsed_email_normalized}
            // if parsed_email_normalized:  # otherwise keep default_email in context
            //     create_values['email'] = parsed_email_normalized
            // return self.create(create_values)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Find a partner with the given ``email`` or use :py:method:`~.name_create`
            // to create a new one.
            // 
            // :param str email: email-like string, which should contain at least one email,
            //     e.g. ``"Raoul Grosbedon <r.g@grosbedon.fr>"``
            // :param boolean assert_valid_email: raise if no valid email is found
            // :return: newly created record
            // """
            // if not email:
            //     raise ValueError(_('An email is required for find_or_create to work'))
            // 
            // parsed_name, parsed_email_normalized = tools.parse_contact_from_email(email)
            // if not parsed_email_normalized and assert_valid_email:
            //     raise ValueError(_('A valid email is required for find_or_create to work properly.'))
            // 
            // if parsed_email_normalized:
            //     partners = self.search([('email', '=ilike', parsed_email_normalized)], limit=1)
            //     if partners:
            //         return partners
            // 
            // create_values = {self._rec_name: parsed_name or parsed_email_normalized}
            // if parsed_email_normalized:  # keep default_email in context
            //     create_values['email'] = parsed_email_normalized
            // return self.create(create_values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> FindOrCreateFromEmailsInternalAsync(object emails, object additional_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _find_or_create_from_emails(self, emails, additional_values=None):
            // """ Based on a list of emails, find or create partners. Additional values
            // can be given to newly created partners. If an email is not unique (e.g.
            // multi-email input), only the first found email is considered.
            // 
            // Additional values allow to customize the created partner when context
            // allows to give more information. It data is based on email normalized
            // as it is the main information used in this method to distinguish or
            // find partners.
            // 
            // If no valid email is found for a given item, the given value is used to
            // find partners with same invalid email or create a new one with the wrong
            // value. It allows updating it afterwards. Notably with notifications
            // resend it is possible to update emails, if only a typo prevents from
            // having a real email for example.
            // 
            // :param list emails: list of emails that may be formatted (each input
            //   will be parsed and normalized);
            // :param dict additional_values: additional values per normalized email
            //   given to create if the partner is not found. Typically used to
            //   propagate a company_id and customer information from related record.
            //   Values for key 'False' are used when creating partner for invalid
            //   emails;
            // 
            // :return: res.partner records in a list, following order of emails. It
            //   is not a recordset, to keep Falsy values.
            // """
            // additional_values = additional_values if additional_values else {}
            // partners, tocreate_vals_list = self.env['res.partner'], []
            // name_emails = [tools.parse_contact_from_email(email) for email in emails]
            // 
            // # find valid emails_normalized, filtering out false / void values, and search
            // # for existing partners based on those emails
            // emails_normalized = {email_normalized
            //                      for _name, email_normalized in name_emails
            //                      if email_normalized}
            // # find partners for invalid (but not void) emails, aka either invalid email
            // # either no email and a name that will be used as email
            // names = {
            //     name.strip()
            //     for name, email_normalized in name_emails
            //     if not email_normalized and name.strip()
            // }
            // if emails_normalized or names:
            //     domains = []
            //     if emails_normalized:
            //         domains.append([('email_normalized', 'in', list(emails_normalized))])
            //     if names:
            //         domains.append([('email', 'in', list(names))])
            //     partners += self.search(expression.OR(domains))
            // 
            // # create partners for valid email without any existing partner. Keep
            // # only first found occurrence of each normalized email, aka: ('Norbert',
            // # 'norbert@gmail.com'), ('Norbert With Surname', 'norbert@gmail.com')'
            // # -> a single partner is created for email 'norbert@gmail.com'
            // seen = set()
            // notfound_emails = (emails_normalized - set(partners.mapped('email_normalized'))) if partners else emails_normalized
            // notfound_name_emails = [
            //     name_email
            //     for name_email in name_emails
            //     if name_email[1] in notfound_emails and name_email[1] not in seen
            //        and not seen.add(name_email[1])
            // ]
            // tocreate_vals_list += [
            //     {
            //         self._rec_name: name or email_normalized,
            //         'email': email_normalized,
            //         **additional_values.get(email_normalized, {}),
            //     }
            //     for name, email_normalized in notfound_name_emails
            // ]
            // 
            // # create partners for invalid emails (aka name and not email_normalized)
            // # without any existing partner
            // tocreate_vals_list += [
            //     {
            //         self._rec_name: name,
            //         'email': name,
            //         **additional_values.get(False, {}),
            //     }
            //     for name in names if name not in partners.mapped('email')
            // ]
            // 
            // # create partners once
            // if tocreate_vals_list:
            //     partners += self.create(tocreate_vals_list)
            // 
            // return [
            //     next(
            //         (partner for partner in partners
            //             if (email_normalized and partner.email_normalized == email_normalized)
            //             or (not email_normalized and email and partner.email == email)
            //             or (not email_normalized and name and partner.name == name)
            //         ),
            //         self.env['res.partner']
            //     )
            //     for (name, email_normalized), email in zip(name_emails, emails)
            // ]
            */
            return default;
        }

        public async Task<ResPartner> FixEuVatNumberAsync(Guid id, ResPartnerFixEuVatNumberRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def fix_eu_vat_number(self, country_id, vat):
            // europe = self.env.ref('base.europe')
            // country = self.env["res.country"].browse(country_id)
            // # In Romania, the CUI can be used as tax identifier and it is not prefixed with the country code
            // country_codes_to_not_prepend = ['RO']
            // if not europe:
            //     europe = self.env["res.country.group"].search([('name', '=', 'Europe')], limit=1)
            // if europe and country and country.id in europe.country_ids.ids:
            //     vat = re.sub('[^A-Za-z0-9]', '', vat).upper()
            //     country_code = _eu_country_vat.get(country.code, country.code).upper()
            //     if vat[:2] != country_code and (
            //         country_code not in country_codes_to_not_prepend or
            //         country_code != self.env.company.country_code
            //     ):
            //         vat = country_code + vat
            // return vat
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> FixVatNumberInternalAsync(object vat, Guid country_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _fix_vat_number(self, vat, country_id):
            // code = self.env['res.country'].browse(country_id).code if country_id else False
            // vat_country, vat_number = self._split_vat(vat)
            // if code and code.lower() != vat_country:
            //     return vat
            // stdnum_vat_fix_func = getattr(stdnum.util.get_cc_module(vat_country, 'vat'), 'compact', None)
            // #If any localization module need to define vat fix method for it's country then we give first priority to it.
            // format_func_name = 'format_vat_' + vat_country
            // format_func = getattr(self, format_func_name, None) or stdnum_vat_fix_func
            // if format_func:
            //     vat_number = format_func(vat_number)
            // return vat_country.upper() + vat_number
            */
            return default;
        }

        protected async Task<ResPartner> FormatDataCompanyInternalAsync(object iap_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _format_data_company(self, iap_data):
            // self._iap_replace_location_codes(iap_data)
            // self._iap_replace_language_codes(iap_data)
            // return iap_data
            */
            return default;
        }

        public async Task<ResPartner> FormatVatChAsync(Guid id, ResPartnerFormatVatChRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_ch(self, vat):
            // stdnum_vat_format = getattr(stdnum.util.get_cc_module('ch', 'vat'), 'format', None)
            // return stdnum_vat_format('CH' + vat)[2:] if stdnum_vat_format else vat
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> FormatVatEuAsync(Guid id, ResPartnerFormatVatEuRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_eu(self, vat):
            // # Foreign companies that trade with non-enterprises in the EU
            // # may have a VATIN starting with "EU" instead of a country code.
            // return vat
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> FormatVatSmAsync(Guid id, ResPartnerFormatVatSmRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_sm(self, vat):
            // stdnum_vat_format = stdnum.util.get_cc_module('sm', 'vat').compact
            // return stdnum_vat_format('SM' + vat)[2:]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> FormattingAddressFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        protected async Task<ResPartner> GelatoPrepareAddressPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py) ---
            // def _gelato_prepare_address_payload(self):
            // first_name, last_name = payment_utils.split_partner_name(self.name)
            // return {
            //     'companyName': self.commercial_company_name or '',
            //     'firstName': first_name or last_name,  # Gelato require a first name.
            //     'lastName': last_name,
            //     'addressLine1': self.street,
            //     'addressLine2': self.street2 or '',
            //     'state': self.state_id.code,
            //     'city': self.city,
            //     'postCode': self.zip,
            //     'country': self.country_id.code,
            //     'email': self.email,
            //     'phone': self.phone or ''
            // }
            */
            return default;
        }

        protected async Task<ResPartner> GenerateSignupTokenInternalAsync(object expiration)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _generate_signup_token(self, expiration=None):
            // """ This function generate the signup token for the partner in self.
            //     pre-condition: self.signup_type must be either 'signup' or 'reset'
            //     :return: the signed payload/token that can be used to reset the password/signup.
            //         - 'expiration': the time in hours before the expiration of the token
            // Since the last_login_date is part of the payload, this token is invalidated as soon as the user logs in
            // """
            // self.ensure_one()
            // if not expiration:
            //     if self.signup_type == 'reset':
            //         expiration = int(self.env['ir.config_parameter'].get_param("auth_signup.reset_password.validity.hours", 4))
            //     else:
            //         expiration = int(self.env['ir.config_parameter'].get_param("auth_signup.signup.validity.hours", 144))
            // plist = [self.id, self.user_ids.ids, self._get_login_date(), self.signup_type]
            // payload = tools.hash_sign(self.sudo().env, 'signup', plist, expiration_hours=expiration)
            // return payload
            */
            return default;
        }

        public async Task<ResPartner> GeoLocalizeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py) ---
            // def geo_localize(self):
            // # We need country names in English below
            // if not self._context.get('force_geo_localize') \
            //         and (self._context.get('import_file') \
            //              or any(config[key] for key in ['test_enable', 'test_file', 'init', 'update'])):
            //     return False
            // partners_not_geo_localized = self.env['res.partner']
            // for partner in self.with_context(lang='en_US'):
            //     result = self._geo_localize(partner.street,
            //                                 partner.zip,
            //                                 partner.city,
            //                                 partner.state_id.name,
            //                                 partner.country_id.name)
            // 
            //     if result:
            //         partner.write({
            //             'partner_latitude': result[0],
            //             'partner_longitude': result[1],
            //             'date_localization': fields.Date.context_today(partner)
            //         })
            //     else:
            //         partners_not_geo_localized |= partner
            // if partners_not_geo_localized:
            //     self.env.user._bus_send("simple_notification", {
            //         'type': 'danger',
            //         'title': _("Warning"),
            //         'message': _('No match found for %(partner_names)s address(es).', partner_names=', '.join(partners_not_geo_localized.mapped('name')))
            //     })
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GeoLocalizeInternalAsync(object street, object zip, object city, object state, object country)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py) ---
            // def _geo_localize(self, street='', zip='', city='', state='', country=''):
            // geo_obj = self.env['base.geocoder']
            // search = geo_obj.geo_query_address(street=street, zip=zip, city=city, state=state, country=country)
            // result = geo_obj.geo_find(search, force_country=country)
            // if result is None:
            //     search = geo_obj.geo_query_address(city=city, state=state, country=country)
            //     result = geo_obj.geo_find(search, force_country=country)
            // return result
            */
            return default;
        }

        protected async Task<ResPartner> GetAddressFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // # When sending a letter, the fields 'street' and 'street2' should be on a single line to fit in the address area
            // if self.env.context.get('snailmail_layout') and self.country_id.code == 'DE':
            //     # Germany requires specific address formatting for Pingen
            //     result = "%(street)s"
            //     if self.street2:
            //         result += " // %(street2)s"
            //     return result + "\n%(zip)s %(city)s\n%(country_name)s"
            // if self.env.context.get('snailmail_layout') and self.street2:
            //     return "%(street)s, %(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            // 
            // return super(ResPartner, self)._get_address_format()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // return self.country_id.address_format or self._get_default_address_format()
            */
            return default;
        }

        protected async Task<ResPartner> GetAllAddrInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def _get_all_addr(self):
            // self.ensure_one()
            // employee_id = self.env['hr.employee'].search(
            //     [('id', 'in', self.employee_ids.ids)],
            //     limit=1,
            // )
            // if not employee_id:
            //     return super()._get_all_addr()
            // 
            // pstl_addr = {
            //     'contact_type': 'employee',
            //     'street': employee_id.private_street,
            //     'zip': employee_id.private_zip,
            //     'city': employee_id.private_city,
            //     'country': employee_id.private_country_id.code,
            // }
            // return [pstl_addr] + super()._get_all_addr()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_all_addr(self):
            // self.ensure_one()
            // return [{
            //     'contact_type': self.street,
            //     'street': self.street,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country': self.country_id.code,
            // }]
            */
            return default;
        }

        protected async Task<ResPartner> GetAmountsAndDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_amounts_and_date(self):
            // company = self.env.user.company_id
            // current_date = fields.Date.today()
            // for partner in self:
            //     worst_due_date = False
            //     amount_due = amount_overdue = 0.0
            //     for aml in partner.unreconciled_aml_ids:
            //         if (aml.company_id == company):
            //             date_maturity = aml.date_maturity or aml.date
            //             if not worst_due_date or date_maturity < worst_due_date:
            //                 worst_due_date = date_maturity
            //             amount_due += aml.result
            //             if (date_maturity <= current_date):
            //                 amount_overdue += aml.result
            //     partner.payment_amount_due = amount_due
            //     partner.payment_amount_overdue = amount_overdue
            //     partner.payment_earliest_due_date = worst_due_date
            */
            return default;
        }

        public async Task<ResPartner> GetAttendeeDetailAsync(Guid id, ResPartnerGetAttendeeDetailRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def get_attendee_detail(self, meeting_ids):
            // """ Return a list of dict of the given meetings with the attendees details
            //     Used by:
            //         - many2many_attendee.js: Many2ManyAttendee
            //         - calendar_model.js (calendar.CalendarModel)
            // """
            // attendees_details = []
            // meetings = self.env['calendar.event'].browse(meeting_ids)
            // for attendee in meetings.attendee_ids:
            //     if attendee.partner_id not in self:
            //         continue
            //     attendee_is_organizer = self.env.user == attendee.event_id.user_id and attendee.partner_id == self.env.user.partner_id
            //     attendees_details.append({
            //         'id': attendee.partner_id.id,
            //         'name': attendee.partner_id.display_name,
            //         'status': attendee.state,
            //         'event_id': attendee.event_id.id,
            //         'attendee_id': attendee.id,
            //         'is_alone': attendee.event_id.is_organizer_alone and attendee_is_organizer,
            //         # attendees data is sorted according to this key in JS.
            //         'is_organizer': 1 if attendee.partner_id == attendee.event_id.user_id.partner_id else 0,
            //     })
            // return attendees_details
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> GetBackendMenuIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('contacts.menu_contacts').id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GetBackendRootMenuIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: contacts, FILE: res_partner.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('contacts.menu_contacts').id]
            */
            return default;
        }

        protected async Task<ResPartner> GetCompanyCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_company_currency(self):
            // for partner in self:
            //     if partner.company_id:
            //         partner.currency_id = partner.sudo().company_id.currency_id
            //     else:
            //         partner.currency_id = self.env.company.currency_id
            */
            return default;
        }

        protected async Task<ResPartner> GetCompanyRegistryLabelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        protected async Task<ResPartner> GetCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_complete_name(self):
            // self.ensure_one()
            // 
            // displayed_types = self._complete_name_displayed_types
            // type_description = dict(self._fields['type']._description_selection(self.env))
            // 
            // name = self.name or ''
            // if self.company_name or self.parent_id:
            //     if not name and self.type in displayed_types:
            //         name = type_description[self.type]
            //     if not self.is_company:
            //         name = f"{self.commercial_company_name or self.sudo().parent_id.name}, {name}"
            // return name.strip()
            */
            return default;
        }

        protected async Task<ResPartner> GetCountryNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // # when sending a letter, thus rendering the report with the snailmail_layout,
            // # we need to override the country name to its english version following the
            // # dictionary imported in country_utils.py
            // country_code = self.country_id.code
            // if self.env.context.get('snailmail_layout') and country_code in SNAILMAIL_COUNTRIES:
            //     return SNAILMAIL_COUNTRIES.get(country_code)
            // 
            // return super(ResPartner, self)._get_country_name()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // return self.country_id.name or ''
            */
            return default;
        }

        protected async Task<ResPartner> GetCurrentPersonaInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_current_persona(self):
            // if not self.env.user or self.env.user._is_public():
            //     return (self.env["res.partner"], self.env["mail.guest"]._get_guest_from_context())
            // return (self.env.user.partner_id, self.env["mail.guest"])
            */
            return default;
        }

        protected async Task<ResPartner> GetDefaultAddressFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        protected async Task<ResPartner> GetDuplicatedBankAccountsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_duplicated_bank_accounts(self):
            // self.ensure_one()
            // if not self.bank_ids:
            //     return self.env['res.partner.bank']
            // domains = []
            // for bank in self.bank_ids:
            //     domains.append([('acc_number', '=', bank.acc_number), ('bank_id', '=', bank.bank_id.id)])
            // domain = expression.OR(domains)
            // if self.company_id:
            //     domain = expression.AND([domain, [('company_id', 'in', (False, self.company_id.id))]])
            // domain = expression.AND([domain, [('partner_id', '!=', self._origin.id)]])
            // return self.env['res.partner.bank'].search(domain)
            */
            return default;
        }

        protected async Task<ResPartner> GetEdiBuilderInternalAsync(object invoice_edi_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // if invoice_edi_format == 'xrechnung':
            //     return self.env['account.edi.xml.ubl_de']
            // if invoice_edi_format == 'facturx':
            //     return self.env['account.edi.xml.cii']
            // if invoice_edi_format == 'ubl_a_nz':
            //     return self.env['account.edi.xml.ubl_a_nz']
            // if invoice_edi_format == 'nlcius':
            //     return self.env['account.edi.xml.ubl_nl']
            // if invoice_edi_format == 'ubl_bis3':
            //     return self.env['account.edi.xml.ubl_bis3']
            // if invoice_edi_format == 'ubl_sg':
            //     return self.env['account.edi.xml.ubl_sg']
            */
            return default;
        }

        protected async Task<ResPartner> GetEmployeesFromAttendeesInternalAsync(object everybody)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def _get_employees_from_attendees(self, everybody=False):
            // domain = [
            //     ('company_id', 'in', self.env.companies.ids),
            //     ('work_contact_id', '!=', False),
            // ]
            // if not everybody:
            //     domain = expression.AND([
            //         domain,
            //         [('work_contact_id', 'in', self.ids)]
            //     ])
            // return dict(self.env['hr.employee'].sudo()._read_group(domain, groupby=['work_contact_id'], aggregates=['id:recordset']))
            */
            return default;
        }

        protected async Task<ResPartner> GetFollowupOverdueQueryInternalAsync(object args, object overdue_only)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_followup_overdue_query(self, args, overdue_only=False):
            // company_id = self.env.user.company_id.id
            // having_clauses = []
            // having_values = []
            // 
            // for field, operator, value in args:
            //     if operator in ['=', '!=', '>', '>=', '<', '<=']:
            //         having_clauses.append(f'SUM(bal2) {operator} %s')
            //         having_values.append(value)
            //     else:
            //         raise ValueError(f"Unsupported operator: {operator}")
            // 
            // having_where_clause = ' AND '.join(having_clauses)
            // overdue_only_str = 'AND date_maturity <= NOW()' if overdue_only else ''
            // 
            // query = ('''
            //     SELECT pid AS partner_id, SUM(bal2) FROM (
            //         SELECT 
            //             CASE WHEN bal IS NOT NULL THEN bal ELSE 0.0 END AS bal2, 
            //             p.id as pid 
            //         FROM (
            //             SELECT 
            //                 (debit - credit) AS bal, 
            //                 partner_id 
            //             FROM account_move_line l
            //             LEFT JOIN account_account a ON a.id = l.account_id
            //             WHERE a.account_type = 'asset_receivable'
            //             %s AND full_reconcile_id IS NULL
            //             AND l.company_id = %%s
            //         ) AS l
            //         RIGHT JOIN res_partner p ON p.id = partner_id 
            //     ) AS pl
            //     GROUP BY pid HAVING %s
            // ''') % (overdue_only_str, having_where_clause)
            // 
            // params = [company_id] + having_values
            // return query, params
            */
            return default;
        }

        public async Task<ResPartner> GetFollowupTableHtmlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def get_followup_table_html(self):
            // self.ensure_one()
            // partner = self.commercial_partner_id
            // followup_table = ''
            // if partner.unreconciled_aml_ids:
            //     company = self.env.user.company_id
            //     current_date = fields.Date.today()
            //     report = self.env['report.om_account_followup.report_followup']
            //     final_res = report._lines_get_with_partner(partner, company.id)
            // 
            //     for currency_dict in final_res:
            //         currency = currency_dict.get('line', [
            //             {'currency_id': company.currency_id}])[0]['currency_id']
            //         followup_table += '''
            //         <table border="2" width=100%%>
            //         <tr>
            //             <td>''' + _("Invoice Date") + '''</td>
            //             <td>''' + _("Description") + '''</td>
            //             <td>''' + _("Reference") + '''</td>
            //             <td>''' + _("Due Date") + '''</td>
            //             <td>''' + _("Amount") + " (%s)" % (
            //             currency.symbol) + '''</td>
            //             <td>''' + _("Lit.") + '''</td>
            //         </tr>
            //         '''
            //         total = 0
            //         for aml in currency_dict['line']:
            //             total += aml['balance']
            //             strbegin = "<TD>"
            //             strend = "</TD>"
            //             date = aml['date_maturity'] or aml['date']
            //             date = datetime.strptime(date, "%d/%m/%Y").date()
            //             if date <= current_date and aml['balance'] > 0:
            //                 strbegin = "<TD><B>"
            //                 strend = "</B></TD>"
            //             followup_table += "<TR>" + strbegin + str(aml['date']) + \
            //                               strend + strbegin + aml['name'] + \
            //                               strend + strbegin + \
            //                               (aml['ref'] or '') + strend + \
            //                               strbegin + str(date) + strend + \
            //                               strbegin + str(aml['balance']) + \
            //                               strend + "</TR>"
            // 
            //         total = reduce(lambda x, y: x + y['balance'],
            //                        currency_dict['line'], 0.00)
            //         total = formatLang(self.env, total, currency_obj=currency)
            //         followup_table += '''<tr> </tr>
            //                         </table>
            //                         <center>''' + _(
            //             "Amount due") + ''' : %s </center>''' % (total)
            // return followup_table
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GetGravatarImageInternalAsync(object email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_gravatar_image(self, email):
            // email_hash = hashlib.md5(email.lower().encode('utf-8')).hexdigest()
            // url = "https://www.gravatar.com/avatar/" + email_hash
            // try:
            //     res = requests.get(url, params={'d': '404', 's': '128'}, timeout=5)
            //     if res.status_code != requests.codes.ok:
            //         return False
            // except requests.exceptions.ConnectionError as e:
            //     return False
            // except requests.exceptions.Timeout as e:
            //     return False
            // return base64.b64encode(res.content)
            */
            return default;
        }

        public async Task<ResPartner> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Customers'),
            //     'template': '/base/static/xls/res_partner.xlsx'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GetLatestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_latest(self):
            // company = self.env.user.company_id
            // for partner in self:
            //     amls = partner.unreconciled_aml_ids
            //     latest_date = False
            //     latest_level = False
            //     latest_days = False
            //     latest_level_without_lit = False
            //     latest_days_without_lit = False
            //     for aml in amls:
            //         aml_followup = aml.followup_line_id
            //         if (aml.company_id == company) and aml_followup and \
            //                 (not latest_days or latest_days < aml_followup.delay):
            //             latest_days = aml_followup.delay
            //             latest_level = aml_followup.id
            //         if (aml.company_id == company) and aml.followup_date and (
            //                 not latest_date or latest_date < aml.followup_date):
            //             latest_date = aml.followup_date
            //         if (aml.company_id == company) and \
            //                 (aml_followup and (not latest_days_without_lit or
            //                  latest_days_without_lit < aml_followup.delay)):
            //             latest_days_without_lit = aml_followup.delay
            //             latest_level_without_lit = aml_followup.id
            //     partner.latest_followup_date = latest_date
            //     partner.latest_followup_level_id = latest_level
            //     partner.latest_followup_level_id_without_lit = latest_level_without_lit
            */
            return default;
        }

        protected async Task<ResPartner> GetLoginDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_login_date(self):
            // self.ensure_one()
            // users_login_dates = self.user_ids.mapped('login_date')
            // users_login_dates = list(filter(None, users_login_dates))  # remove falsy values
            // if any(users_login_dates):
            //     return int(max(map(datetime.timestamp, users_login_dates)))
            // return None
            */
            return default;
        }

        public async Task<ResPartner> GetMentionSuggestionsAsync(Guid id, ResPartnerGetMentionSuggestionsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """ Return 'limit'-first partners' such that the name or email matches a 'search' string.
            //     Prioritize partners that are also (internal) users, and then extend the research to all partners.
            //     The return format is a list of partner data (as per returned by `_to_store()`).
            // """
            // domain = self._get_mention_suggestions_domain(search)
            // partners = self._search_mention_suggestions(domain, limit)
            // return Store(partners).get_result()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GetMentionSuggestionsDomainInternalAsync(object search)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_mention_suggestions_domain(self, search):
            // return expression.AND([
            //     expression.OR([
            //         [('name', 'ilike', search)],
            //         [('email', 'ilike', search)],
            //     ]),
            //     [('active', '=', True)],
            // ])
            */
            return default;
        }

        public async Task<ResPartner> GetMentionSuggestionsFromChannelAsync(Guid id, ResPartnerGetMentionSuggestionsFromChannelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def get_mention_suggestions_from_channel(self, channel_id, search, limit=8):
            // """Return 'limit'-first partners' such that the name or email matches a 'search' string.
            // Prioritize partners that are also (internal) users, and then extend the research to all partners.
            // Only members of the given channel are returned.
            // The return format is a list of partner data (as per returned by `_to_store()`).
            // """
            // channel = self.env["discuss.channel"].search([("id", "=", channel_id)])
            // if not channel:
            //     return []
            // domain = expression.AND(
            //     [
            //         self._get_mention_suggestions_domain(search),
            //         [("channel_ids", "in", channel.id)],
            //     ]
            // )
            // extra_domain = expression.AND([
            //     [('user_ids', '!=', False)],
            //     [('user_ids.active', '=', True)],
            //     [('partner_share', '=', False)]
            // ])
            // allowed_group = (channel.parent_channel_id or channel).group_public_id
            // if allowed_group:
            //     extra_domain = expression.AND(
            //         [
            //             extra_domain,
            //             [("user_ids.groups_id", "in", allowed_group.id)],
            //         ]
            //     )
            // partners = self._search_mention_suggestions(domain, limit, extra_domain)
            // members = self.env["discuss.channel.member"].search(
            //     [
            //         ("channel_id", "=", channel.id),
            //         ("partner_id", "in", partners.ids),
            //     ]
            // )
            // store = Store(members, fields={"channel": [], "persona": []})
            // if allowed_group:
            //     for p in partners:
            //         store.add(p, {"groups_id": [("ADD", (allowed_group & p.user_ids.groups_id).ids)]})
            // return store.get_result()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GetNeedactionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_needaction_count(self):
            // """ compute the number of needaction of the current partner """
            // self.ensure_one()
            // self.env['mail.notification'].flush_model(['is_read', 'res_partner_id'])
            // self.env.cr.execute("""
            //     SELECT count(*) as needaction_count
            //     FROM mail_notification R
            //     WHERE R.res_partner_id = %s AND (R.is_read = false OR R.is_read IS NULL)""", (self.id,))
            // return self.env.cr.dictfetchall()[0].get('needaction_count')
            */
            return default;
        }

        protected async Task<ResPartner> GetOnLeaveIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _get_on_leave_ids(self):
            // return self.env['res.users']._get_on_leave_ids(partner=True)
            */
            return default;
        }

        protected async Task<ResPartner> GetParticipantInfoInternalAsync(object edi_identification)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _get_participant_info(self, edi_identification):
            // hash_participant = md5(edi_identification.lower().encode()).hexdigest()
            // endpoint_participant = parse.quote_plus(f"iso6523-actorid-upis::{edi_identification}")
            // edi_mode = self.env.company._get_peppol_edi_mode()
            // sml_zone = 'acc.edelivery' if edi_mode == 'test' else 'edelivery'
            // smp_url = f"http://B-{hash_participant}.iso6523-actorid-upis.{sml_zone}.tech.ec.europa.eu/{endpoint_participant}"
            // 
            // try:
            //     response = requests.get(smp_url, timeout=TIMEOUT)
            //     response.raise_for_status()
            // except requests.exceptions.RequestException as e:
            //     _logger.debug(e)
            //     return None
            // return etree.fromstring(response.content)
            */
            return default;
        }

        protected async Task<ResPartner> GetPartnerFromTokenInternalAsync(object token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_partner_from_token(self, token):
            // if payload := tools.verify_hash_signed(self.sudo().env, 'signup', token):
            //     partner_id, user_ids, login_date, signup_type = payload
            //     # login_date can be either an int or "None" as a string for signup
            //     partner = self.browse(partner_id)
            //     if login_date == partner._get_login_date() and partner.user_ids.ids == user_ids and signup_type == partner.browse(partner_id).signup_type:
            //         return partner
            // return None
            */
            return default;
        }

        public async Task<ResPartner> GetPartnerLocalisationFieldsRequiredToInvoiceAsync(Guid id, ResPartnerGetPartnerLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def get_partner_localisation_fields_required_to_invoice(self, country_id):
            // """ Returns the list of fields that needs to be filled when creating an invoice for the selected country.
            // This is required for some flows that would allow a user to request an invoice from the portal.
            // Using these, we can get their information and dynamically create form inputs based for the fields required legally for the company country_id.
            // The returned fields must be of type ir.model.fields in order to handle translations
            // 
            // :param country_id: The country for which we want the fields.
            // :return: an array of ir.model.fields for which the user should provide values.
            // """
            // return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GetPartnersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _get_partners(self):
            // partners = set()
            // for aml in self:
            //     if aml.partner_id:
            //         partners.add(aml.partner_id.id)
            // return list(partners)
            */
            return default;
        }

        protected async Task<ResPartner> GetPeppolEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_peppol_edi_format(self):
            // self.ensure_one()
            // return self.invoice_edi_format or self._get_suggested_peppol_edi_format()
            */
            return default;
        }

        protected async Task<ResPartner> GetPeppolFormatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_peppol_formats(self):
            // formats_info = self._get_ubl_cii_formats_info()
            // return [format_key for format_key, format_vals in formats_info.items() if format_vals.get('on_peppol')]
            */
            return default;
        }

        protected async Task<ResPartner> GetPeppolVerificationStateInternalAsync(object peppol_endpoint, object peppol_eas, object invoice_edi_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _get_peppol_verification_state(self, peppol_endpoint, peppol_eas, invoice_edi_format):
            // if not (peppol_eas and peppol_endpoint) or invoice_edi_format not in self._get_peppol_formats():
            //     return 'not_verified'
            // 
            // edi_identification = f"{peppol_eas}:{peppol_endpoint}".lower()
            // participant_info = self._get_participant_info(edi_identification)
            // if participant_info is None:
            //     return 'not_valid'
            // else:
            //     is_participant_on_network = self._check_peppol_participant_exists(participant_info, edi_identification)
            //     if is_participant_on_network:
            //         is_valid_format = self._check_document_type_support(participant_info, invoice_edi_format)
            //         if is_valid_format:
            //             return 'valid'
            //         else:
            //             return 'not_valid_format'
            //     else:
            //         return 'not_valid'
            */
            return default;
        }

        protected async Task<ResPartner> GetSaleOrderDomainCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _get_sale_order_domain_count(self):
            // return []
            */
            return default;
        }

        protected async Task<ResPartner> GetScheduleInternalAsync(object start_period, object stop_period, object everybody, object merge)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def _get_schedule(self, start_period, stop_period, everybody=False, merge=True):
            // """
            // This method implements the general case where employees might have different resource calendars at different
            // times, even though this is not the case with only this module installed.
            // This way it will work with these other modules by just overriding
            // `_get_calendar_periods`.
            // 
            // :param datetime start_period: the start of the period
            // :param datetime stop_period: the stop of the period
            // :param boolean everybody: represents the "everybody" filter on calendar
            // :param boolean merge: specifies if calendar's work_intervals needs to be merged
            // :return: schedule (merged or not) by partner
            // :rtype: defaultdict
            // """
            // employees_by_partner = self._get_employees_from_attendees(everybody)
            // if not employees_by_partner:
            //     return {}
            // interval_by_calendar = defaultdict()
            // calendar_periods_by_employee = defaultdict(list)
            // resources_by_calendar = defaultdict(lambda: self.env['resource.resource'])
            // 
            // # Compute employee's calendars's period and order employee by his involved calendars
            // employees = sum(employees_by_partner.values(), start=self.env['hr.employee'])
            // calendar_periods_by_employee = employees._get_calendar_periods(start_period, stop_period)
            // for employee, calendar_periods in calendar_periods_by_employee.items():
            //     for (start, stop, calendar) in calendar_periods:
            //         calendar = calendar or self.env.company.resource_calendar_id  # No calendar if fully flexible
            //         resources_by_calendar[calendar] += employee.resource_id
            // 
            // # Compute all work intervals per calendar
            // for calendar, resources in resources_by_calendar.items():
            //     work_intervals = calendar._work_intervals_batch(start_period, stop_period, resources=resources, tz=timezone(calendar.tz))
            //     del work_intervals[False]
            //     # Merge all employees intervals to avoid to compute it multiples times
            //     if merge:
            //         interval_by_calendar[calendar] = reduce(Intervals.__and__, work_intervals.values())
            //     else:
            //         interval_by_calendar[calendar] = work_intervals
            // 
            // # Compute employee's schedule based own his calendar's periods
            // schedule_by_employee = defaultdict(list)
            // for employee, calendar_periods in calendar_periods_by_employee.items():
            //     employee_interval = Intervals([])
            //     for (start, stop, calendar) in calendar_periods:
            //         calendar = calendar or self.env.company.resource_calendar_id # No calendar if fully flexible
            //         interval = Intervals([(start, stop, self.env['resource.calendar'])])
            //         if merge:
            //             calendar_interval = interval_by_calendar[calendar]
            //         else:
            //             calendar_interval = interval_by_calendar[calendar][employee.resource_id.id]
            //         employee_interval = employee_interval | (calendar_interval & interval)
            //     schedule_by_employee[employee] = employee_interval
            // 
            // # Compute partner's schedule equals to the union between his employees's schedule
            // schedules = defaultdict()
            // for partner, employees in employees_by_partner.items():
            //     partner_schedule = Intervals([])
            //     for employee in employees:
            //         if schedule_by_employee[employee]:
            //             partner_schedule = partner_schedule | schedule_by_employee[employee]
            //     schedules[partner] = partner_schedule
            // return schedules
            */
            return default;
        }

        protected async Task<ResPartner> GetSignupUrlForActionInternalAsync(object url, object action, object view_type, Guid menu_id, Guid res_id, object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_signup_url_for_action(self, url=None, action=None, view_type=None, menu_id=None, res_id=None, model=None):
            // """ generate a signup url for the given partner ids and action, possibly overriding
            //     the url state components (menu_id, id, view_type) """
            // 
            // res = dict.fromkeys(self.ids, False)
            // for partner in self:
            //     base_url = partner.get_base_url()
            //     # when required, make sure the partner has a valid signup token
            //     if self.env.context.get('signup_valid') and not partner.user_ids:
            //         partner.sudo().signup_prepare()
            // 
            //     route = 'login'
            //     # the parameters to encode for the query
            //     query = {'db': self.env.cr.dbname}
            //     if self.env.context.get('create_user'):
            //         query['signup_email'] = partner.email
            // 
            //     signup_type = self.env.context.get('signup_force_type_in_url', partner.sudo().signup_type or '')
            //     if signup_type:
            //         route = 'reset_password' if signup_type == 'reset' else signup_type
            // 
            //     query['token'] = partner.sudo()._generate_signup_token()
            // 
            //     if url:
            //         query['redirect'] = url
            //     else:
            //         fragment = dict()
            //         base = '/odoo/'
            //         if action == '/mail/view':
            //             base = '/mail/view?'
            //         elif action:
            //             fragment['action'] = action
            //         if view_type:
            //             fragment['view_type'] = view_type
            //         if menu_id:
            //             fragment['menu_id'] = menu_id
            //         if model:
            //             fragment['model'] = model
            //         if res_id:
            //             fragment['res_id'] = res_id
            // 
            //         if fragment:
            //             query['redirect'] = base + werkzeug.urls.url_encode(fragment)
            // 
            //     signup_url = "/web/%s?%s" % (route, werkzeug.urls.url_encode(query))
            //     if not self.env.context.get('relative_url'):
            //         signup_url = werkzeug.urls.url_join(base_url, signup_url)
            //     res[partner.id] = signup_url
            // return res
            */
            return default;
        }

        protected async Task<ResPartner> GetSignupUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _get_signup_url(self):
            // self.ensure_one()
            // result = self.sudo()._get_signup_url_for_action()
            // if any(u._is_internal() for u in self.user_ids if u != self.env.user):
            //     self.env['res.users'].check_access('write')
            // if any(u._is_portal() for u in self.user_ids if u != self.env.user):
            //     self.env['res.partner'].check_access('write')
            // return result.get(self.id, False)
            */
            return default;
        }

        protected async Task<ResPartner> GetStreetSplitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return {
            //     'street_name': self.street_name,
            //     'street_number': self.street_number,
            //     'street_number2': self.street_number2
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return tools.street_split(self.street or '')
            */
            return default;
        }

        protected async Task<ResPartner> GetSuggestedInvoiceEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_suggested_invoice_edi_format(self):
            // # TO OVERRIDE
            // self.ensure_one()
            // return False
            */
            return default;
        }

        protected async Task<ResPartner> GetSuggestedPeppolEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_suggested_peppol_edi_format(self):
            // self.ensure_one()
            // suggested_format = self.commercial_partner_id._get_suggested_ubl_cii_edi_format()
            // return suggested_format if suggested_format in self.env['res.partner']._get_peppol_formats() else 'ubl_bis3'
            */
            return default;
        }

        protected async Task<ResPartner> GetSuggestedUblCiiEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_suggested_ubl_cii_edi_format(self):
            // self.ensure_one()
            // format_mapping = self._get_ubl_cii_formats_by_country()
            // country_code = self.commercial_partner_id._deduce_country_code()
            // if country_code in format_mapping:
            //     formats_by_country = format_mapping[country_code]
            //     # return the format with the smallest sequence
            //     if len(formats_by_country) == 1:
            //         return formats_by_country[0]
            //     else:
            //         formats_info = self._get_ubl_cii_formats_info()
            //         return min(formats_by_country, key=lambda e: formats_info[e].get('sequence', 100))  # we use a sequence of 100 by default
            // return False
            */
            return default;
        }

        protected async Task<ResPartner> GetUblCiiFormatsByCountryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_by_country(self):
            // formats_info = self._get_ubl_cii_formats_info()
            // countries = {country for format_val in formats_info.values() for country in (format_val.get('countries') or [])}
            // return {
            //     country_code: [
            //         format_key
            //         for format_key, format_val in formats_info.items() if country_code in (format_val.get('countries') or [])
            //     ]
            //     for country_code in countries
            // }
            */
            return default;
        }

        protected async Task<ResPartner> GetUblCiiFormatsInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // return {
            //     'ubl_bis3': {'countries': list(PEPPOL_DEFAULT_COUNTRIES), 'on_peppol': True, 'sequence': 200},
            //     'xrechnung': {'countries': ['DE'], 'on_peppol': True},
            //     'ubl_a_nz': {'countries': ['NZ', 'AU'], 'on_peppol': False},  # Not yet available through Odoo's Access Point, although it's a Peppol valid format
            //     'nlcius': {'countries': ['NL'], 'on_peppol': True},
            //     'ubl_sg': {'countries': ['SG'], 'on_peppol': False},  # Same.
            //     'facturx': {'countries': ['FR'], 'on_peppol': False},
            // }
            */
            return default;
        }

        protected async Task<ResPartner> GetUblCiiFormatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats(self):
            // return list(self._get_ubl_cii_formats_info().keys())
            */
            return default;
        }

        protected async Task<ResPartner> GetVcardFileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_partner.py) ---
            // def _get_vcard_file(self):
            // vcard = self._build_vcard()
            // if vcard:
            //     return vcard.serialize().encode()
            // return False
            */
            return default;
        }

        protected async Task<ResPartner> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """Add context variable force_email in the key as _get_view depends on it."""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + (self._context.get('force_email'),)
            */
            return default;
        }

        protected async Task<ResPartner> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // 
            // if view_type == 'form':
            //     for node in arch.xpath("//field[@name='name' or @name='vat']"):
            //         node.set('widget', 'field_partner_autocomplete')
            // 
            // return arch, view
            */
            return default;
        }

        public async Task<ResPartner> GetWorkingHoursForAllAttendeesAsync(Guid id, ResPartnerGetWorkingHoursForAllAttendeesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def get_working_hours_for_all_attendees(self, attendee_ids, date_from, date_to, everybody=False):
            // 
            // start_period = datetime.fromisoformat(date_from).replace(hour=0, minute=0, second=0, tzinfo=UTC)
            // stop_period = datetime.fromisoformat(date_to).replace(hour=23, minute=59, second=59, tzinfo=UTC)
            // 
            // schedule_by_partner = self.env['res.partner'].browse(attendee_ids)._get_schedule(start_period, stop_period, everybody)
            // if not schedule_by_partner:
            //     return []
            // return self._interval_to_business_hours(reduce(Intervals.__and__, schedule_by_partner.values()))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> GetWorklocationAsync(Guid id, ResPartnerGetWorklocationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py) ---
            // def get_worklocation(self, start_date, end_date):
            // employee_id = self.env['hr.employee'].search([
            //     ('work_contact_id.id', 'in', self.ids),
            //     ('company_id.id', '=', self.env.company.id)])
            // return employee_id._get_worklocation(start_date, end_date)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> GoogleMapImgAsync(Guid id, ResPartnerGoogleMapImgRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def google_map_img(self, zoom=8, width=298, height=298):
            // google_maps_api_key = self.env['website'].get_current_website().google_maps_api_key
            // if not google_maps_api_key:
            //     return False
            // params = {
            //     'center': '%s, %s %s, %s' % (self.street or '', self.city or '', self.zip or '', self.country_id and self.country_id.display_name or ''),
            //     'size': "%sx%s" % (width, height),
            //     'zoom': zoom,
            //     'sensor': 'false',
            //     'key': google_maps_api_key,
            // }
            // return '//maps.googleapis.com/maps/api/staticmap?' + werkzeug.urls.url_encode(params)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> GoogleMapLinkAsync(Guid id, ResPartnerGoogleMapLinkRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def google_map_link(self, zoom=10):
            // params = {
            //     'q': '%s, %s %s, %s' % (self.street or '', self.city or '', self.zip or '', self.country_id and self.country_id.display_name or ''),
            //     'z': zoom,
            // }
            // return 'https://maps.google.com/maps?' + werkzeug.urls.url_encode(params)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> GoogleMapSignedImgInternalAsync(object zoom, object width, object height)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _google_map_signed_img(self, zoom=13, width=298, height=298):
            // """Create a signed static image URL for the location of this partner."""
            // GOOGLE_MAPS_STATIC_API_KEY = self.env['ir.config_parameter'].sudo().get_param('google_maps.signed_static_api_key')
            // GOOGLE_MAPS_STATIC_API_SECRET = self.env['ir.config_parameter'].sudo().get_param('google_maps.signed_static_api_secret')
            // if not GOOGLE_MAPS_STATIC_API_KEY or not GOOGLE_MAPS_STATIC_API_SECRET:
            //     return None
            // # generate signature as per https://developers.google.com/maps/documentation/maps-static/digital-signature#server-side-signing
            // location_string = f"{self.street}, {self.city} {self.zip}, {self.country_id and self.country_id.display_name or ''}"
            // params = {
            //     'center': location_string,
            //     'markers': f'size:mid|{location_string}',
            //     'size': f"{width}x{height}",
            //     'zoom': zoom,
            //     'sensor': "false",
            //     'key': GOOGLE_MAPS_STATIC_API_KEY,
            // }
            // unsigned_path = '/maps/api/staticmap?' + werkzeug.urls.url_encode(params)
            // try:
            //     api_secret_bytes = base64.urlsafe_b64decode(GOOGLE_MAPS_STATIC_API_SECRET + "====")
            // except binascii.Error:
            //     return None
            // url_signature_bytes = hmac.digest(api_secret_bytes, unsigned_path.encode(), 'sha1')
            // params['signature'] = base64.urlsafe_b64encode(url_signature_bytes)
            // 
            // return 'https://maps.googleapis.com/maps/api/staticmap?' + werkzeug.urls.url_encode(params)
            */
            return default;
        }

        protected async Task<ResPartner> HandleFirstContactCreationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _handle_first_contact_creation(self):
            // """ On creation of first contact for a company (or root) that has no address, assume contact address
            // was meant to be company address """
            // parent = self.parent_id
            // address_fields = self._address_fields()
            // if (
            //     (parent.is_company or not parent.parent_id)
            //     and any(self[f] for f in address_fields)
            //     and not any(parent[f] for f in address_fields)
            //     and len(parent.child_ids) == 1
            // ):
            //     addr_vals = self._update_fields_values(address_fields)
            //     parent.update_address(addr_vals)
            */
            return default;
        }

        protected async Task<ResPartner> HasInvoiceInternalAsync(object partner_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _has_invoice(self, partner_domain):
            // self.ensure_one()
            // invoice = self.env['account.move'].sudo().search(
            //     expression.AND([
            //         partner_domain,
            //         [
            //             ('move_type', 'in', ['out_invoice', 'out_refund']),
            //             ('state', '=', 'posted'),
            //         ]
            //     ]),
            //     limit=1
            // )
            // return bool(invoice)
            */
            return default;
        }

        protected async Task<ResPartner> HasOrderInternalAsync(object partner_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _has_order(self, partner_domain):
            // self.ensure_one()
            // sale_order = self.env['sale.order'].sudo().search(
            //     expression.AND([
            //         partner_domain,
            //         [
            //             ('state', 'in', ('sent', 'sale')),
            //         ]
            //     ]),
            //     limit=1,
            // )
            // return bool(sale_order)
            */
            return default;
        }

        public async Task<ResPartner> IapPartnerAutocompleteAddTagsAsync(Guid id, ResPartnerIapPartnerAutocompleteAddTagsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def iap_partner_autocomplete_add_tags(self, unspsc_codes):
            // """Called by JS to create the activity tags from the UNSPSC codes"""
            // # If the UNSPSC module is installed, we might have a translation, so let's use it
            // if self.env['ir.module.module']._get('product_unspsc').state == 'installed':
            //     tag_names = self.env['product.unspsc.code']\
            //                     .with_context(active_test=False)\
            //                     .search([('code', 'in', [unspsc_code for unspsc_code, __ in unspsc_codes])])\
            //                     .mapped('name')
            // # If it's not, then we use the default English name provided by DnB
            // else:
            //     tag_names = [unspsc_name for __, unspsc_name in unspsc_codes]
            // 
            // tag_ids = self.env['res.partner.category']
            // for tag_name in tag_names:
            //     if existing_tag := self.env['res.partner.category'].search([('name', '=', tag_name)]):
            //         tag_ids |= existing_tag
            //     else:
            //         tag_ids |= self.env['res.partner.category'].create({'name': tag_name})
            // return tag_ids.ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> IapReplaceLanguageCodesInternalAsync(object iap_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _iap_replace_language_codes(self, iap_data):
            // if lang := iap_data.pop('preferred_language', False):
            //     if installed_lang := (
            //         self.env['res.lang'].search([('code', '=', lang), ('iso_code', '=', lang)])  # specific lang (e.g.: fr_BE)
            //         or
            //         self.env['res.lang'].search([('code', 'ilike', lang[:2]), ('iso_code', 'ilike', lang[:2])], limit=1)  # fallback to generic lang (e.g. fr)
            //     ):
            //         iap_data['lang'] = installed_lang.code
            // return iap_data
            */
            return default;
        }

        protected async Task<ResPartner> IapReplaceLocationCodesInternalAsync(object iap_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _iap_replace_location_codes(self, iap_data):
            // country_code, country_name = iap_data.pop('country_code', False), iap_data.pop('country_name', False)
            // state_code, state_name = iap_data.pop('state_code', False), iap_data.pop('state_name', False)
            // 
            // country, state = None, None
            // if country_code:
            //     country = self.env['res.country'].search([['code', '=ilike', country_code]])
            // if not country and country_name:
            //     country = self.env['res.country'].search([['name', '=ilike', country_name]])
            // 
            // if country:
            //     if state_code:
            //         state = self.env['res.country.state'].search([
            //             ('country_id', '=', country.id), ('code', '=ilike', state_code)
            //         ], limit=1)
            //     if not state and state_name:
            //         state = self.env['res.country.state'].search([
            //             ('country_id', '=', country.id), ('name', '=ilike', state_name)
            //         ], limit=1)
            // 
            // if country:
            //     iap_data['country_id'] = {'id': country.id, 'display_name': country.display_name}
            // if state:
            //     iap_data['state_id'] = {'id': state.id, 'display_name': state.display_name}
            // 
            // return iap_data
            */
            return default;
        }

        protected async Task<ResPartner> IeCheckCharInternalAsync(object vat)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _ie_check_char(self, vat):
            // vat = vat.zfill(8)
            // extra = 0
            // if vat[7] not in ' W':
            //     if vat[7].isalpha():
            //         extra = 9 * (ord(vat[7]) - 64)
            //     else:
            //         # invalid
            //         return -1
            // checksum = extra + sum((8-i) * int(x) for i, x in enumerate(vat[:7]))
            // return 'WABCDEFGHIJKLMNOPQRSTUV'[checksum % 23]
            */
            return default;
        }

        public async Task<ResPartner> ImSearchAsync(Guid id, ResPartnerImSearchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def im_search(self, name, limit=20, excluded_ids=None):
            // """ Search partner with a name and return its id, name and im_status.
            //     Note : the user must be logged
            //     :param name : the partner name to search
            //     :param limit : the limit of result to return
            //     :param excluded_ids : the ids of excluded partners
            // """
            // # This method is supposed to be used only in the context of channel creation or
            // # extension via an invite. As both of these actions require the 'create' access
            // # right, we check this specific ACL.
            // if excluded_ids is None:
            //     excluded_ids = []
            // users = self.env['res.users'].search([
            //     ('id', '!=', self.env.user.id),
            //     ('name', 'ilike', name),
            //     ('active', '=', True),
            //     ('share', '=', False),
            //     ('partner_id', 'not in', excluded_ids)
            // ], order='name, id', limit=limit)
            // return Store(users.partner_id).get_result()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> IncreaseRankInternalAsync(object field, object n)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _increase_rank(self, field, n=1):
            // if self.ids and field in ['customer_rank', 'supplier_rank']:
            //     try:
            //         with self.env.cr.savepoint(flush=False), mute_logger('odoo.sql_db'):
            //             self.env.execute_query(SQL("""
            //                 SELECT %(field)s FROM res_partner WHERE ID IN %(partner_ids)s FOR NO KEY UPDATE NOWAIT;
            //                 UPDATE res_partner SET %(field)s = %(field)s + %(n)s
            //                 WHERE id IN %(partner_ids)s
            //                 """,
            //                 field=SQL.identifier(field),
            //                 partner_ids=tuple(self.ids),
            //                 n=n,
            //             ))
            //             self.invalidate_recordset([field])
            //             self.modified([field])
            //     except (pgerrors.LockNotAvailable, pgerrors.SerializationFailure):
            //         _logger.debug('Another transaction already locked partner rows. Cannot update partner ranks.')
            */
            return default;
        }

        protected async Task<ResPartner> IntervalToBusinessHoursInternalAsync(object working_intervals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py) ---
            // def _interval_to_business_hours(self, working_intervals):
            // # This is the format expected by the fullcalendar library to do the overlay
            // return [{
            //     "daysOfWeek": [(interval[0].weekday() + 1) % 7],
            //     "startTime":  interval[0].astimezone(timezone(self.env.user.tz or 'UTC')).strftime("%H:%M"),
            //     "endTime": interval[1].astimezone(timezone(self.env.user.tz or 'UTC')).strftime("%H:%M"),
            // } for interval in working_intervals] if working_intervals else [{
            //     # 7 is used a dummy value to gray the full week
            //     # Returning an empty list would leave the week uncolored
            //     "daysOfWeek": [7],
            //     "startTime":  datetime.today().strftime("00:00"),
            //     "endTime": datetime.today().strftime("00:00"),
            // }]
            */
            return default;
        }

        protected async Task<ResPartner> InverseInvoiceEdiFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _inverse_invoice_edi_format(self):
            // for partner in self:
            //     if partner.invoice_edi_format == partner._get_suggested_invoice_edi_format():
            //         partner.invoice_edi_format_store = False
            //     elif not partner.invoice_edi_format:
            //         partner.invoice_edi_format_store = 'none'
            //     else:
            //         partner.invoice_edi_format_store = partner.invoice_edi_format
            */
            return default;
        }

        protected async Task<ResPartner> InverseProductPricelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_partner.py) ---
            // def _inverse_product_pricelist(self):
            // for partner in self:
            //     pls = self.env['product.pricelist'].search(
            //         [('country_group_ids.country_ids.code', '=', partner.country_id and partner.country_id.code or False)],
            //         limit=1
            //     )
            //     default_for_country = pls
            //     actual = partner.specific_property_product_pricelist
            //     # update at each change country, and so erase old pricelist
            //     if partner.property_product_pricelist or (actual and default_for_country and default_for_country.id != actual.id):
            //         partner.specific_property_product_pricelist = False if partner.property_product_pricelist.id == default_for_country.id else partner.property_product_pricelist.id
            */
            return default;
        }

        protected async Task<ResPartner> InverseStreetDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _inverse_street_data(self):
            // """ update self.street based on street_name, street_number and street_number2 """
            // for partner in self:
            //     street = ((partner.street_name or '') + " " + (partner.street_number or '')).strip()
            //     if partner.street_number2:
            //         street = street + " - " + partner.street_number2
            //     partner.street = street
            */
            return default;
        }

        protected async Task<ResPartner> InverseUsePartnerCreditLimitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _inverse_use_partner_credit_limit(self):
            // company_limit = self._fields['credit_limit'].get_company_dependent_fallback(self)
            // for partner in self:
            //     if not partner.use_partner_credit_limit:
            //         partner.credit_limit = company_limit
            */
            return default;
        }

        protected async Task<ResPartner> InvoiceTotalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _invoice_total(self):
            // self.total_invoiced = 0
            // if not self.ids:
            //     return True
            // 
            // all_partners_and_children = {}
            // all_partner_ids = []
            // for partner in self.filtered('id'):
            //     # price_total is in the company currency
            //     all_partners_and_children[partner] = self.with_context(active_test=False).search([('id', 'child_of', partner.id)]).ids
            //     all_partner_ids += all_partners_and_children[partner]
            // 
            // domain = [
            //     ('partner_id', 'in', all_partner_ids),
            //     ('state', 'not in', ['draft', 'cancel']),
            //     ('move_type', 'in', ('out_invoice', 'out_refund')),
            // ]
            // price_totals = self.env['account.invoice.report']._read_group(domain, ['partner_id'], ['price_subtotal:sum'])
            // for partner, child_ids in all_partners_and_children.items():
            //     partner.total_invoiced = sum(price_subtotal_sum for partner, price_subtotal_sum in price_totals if partner.id in child_ids)
            */
            return default;
        }

        public async Task<ResPartner> IsValidRucEcAsync(Guid id, ResPartnerIsValidRucEcRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def is_valid_ruc_ec(self, vat):
            // if len(vat) in (10, 13) and vat.isdecimal():
            //     return True
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def _load_pos_data_domain(self, data):
            // config_id = self.env['pos.config'].browse(data['pos.config']['data'][0]['id'])
            // 
            // # Collect partner IDs from loaded orders
            // loaded_order_partner_ids = {order['partner_id'] for order in data['pos.order']['data']}
            // 
            // # Extract partner IDs from the tuples returned by get_limited_partners_loading
            // limited_partner_ids = {partner[0] for partner in config_id.get_limited_partners_loading()}
            // 
            // limited_partner_ids.add(self.env.user.partner_id.id)  # Ensure current user is included
            // partner_ids = limited_partner_ids.union(loaded_order_partner_ids)
            // return [('id', 'in', list(partner_ids))]
            */
            return default;
        }

        protected async Task<ResPartner> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return [
            //     'id', 'name', 'street', 'city', 'state_id', 'country_id', 'vat', 'lang', 'phone', 'zip', 'mobile', 'email',
            //     'barcode', 'write_date', 'property_account_position_id', 'property_product_pricelist', 'parent_name', 'contact_address',
            //     'company_type',
            // ]
            */
            return default;
        }

        protected async Task<ResPartner> LoadRecordsCreateInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _load_records_create(self, vals_list):
            // partners = super(Partner, self.with_context(_partners_skip_fields_sync=True))._load_records_create(vals_list)
            // 
            // # batch up first part of _fields_sync
            // # group partners by commercial_partner_id (if not self) and parent_id (if type == contact)
            // groups = collections.defaultdict(list)
            // for partner, vals in zip(partners, vals_list):
            //     cp_id = None
            //     if vals.get('parent_id') and partner.commercial_partner_id != partner:
            //         cp_id = partner.commercial_partner_id.id
            // 
            //     add_id = None
            //     if partner.parent_id and partner.type == 'contact':
            //         add_id = partner.parent_id.id
            //     groups[(cp_id, add_id)].append(partner.id)
            // 
            // for (cp_id, add_id), children in groups.items():
            //     # values from parents (commercial, regular) written to their common children
            //     to_write = {}
            //     # commercial fields from commercial partner
            //     if cp_id:
            //         to_write = self.browse(cp_id)._update_fields_values(self._commercial_fields())
            //     # address fields from parent
            //     if add_id:
            //         parent = self.browse(add_id)
            //         for f in self._address_fields():
            //             v = parent[f]
            //             if v:
            //                 to_write[f] = v.id if isinstance(v, models.BaseModel) else v
            //     if to_write:
            //         self.sudo().browse(children).write(to_write)
            // 
            // # do the second half of _fields_sync the "normal" way
            // for partner, vals in zip(partners, vals_list):
            //     partner._children_sync(vals)
            //     partner._handle_first_contact_creation()
            // return partners
            */
            return default;
        }

        protected async Task<ResPartner> LogVerificationStateUpdateInternalAsync(object company, object old_value, object new_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _log_verification_state_update(self, company, old_value, new_value):
            // # log the update of the peppol verification state
            // # we do this instead of regular tracking because of the customized message
            // # and because we want to log the change for every company in the db
            // if old_value == new_value:
            //     return
            // 
            // peppol_verification_state_field = self._fields['peppol_verification_state']
            // selection_values = dict(peppol_verification_state_field.selection)
            // old_label = selection_values[old_value] if old_value else False  # get translated labels
            // new_label = selection_values[new_value] if new_value else False
            // 
            // body = Markup("""
            //     <ul>
            //         <li>
            //             <span class='o-mail-Message-trackingOld me-1 px-1 text-muted fw-bold'>{old}</span>
            //             <i class='o-mail-Message-trackingSeparator fa fa-long-arrow-right mx-1 text-600'/>
            //             <span class='o-mail-Message-trackingNew me-1 fw-bold text-info'>{new}</span>
            //             <span class='o-mail-Message-trackingField ms-1 fst-italic text-muted'>({field})</span>
            //             <span class='o-mail-Message-trackingCompany ms-1 fst-italic text-muted'>({company})</span>
            //         </li>
            //     </ul>
            // """).format(
            //     old=old_label,
            //     new=new_label,
            //     field=peppol_verification_state_field.string,
            //     company=company.display_name,
            // )
            // self._message_log(body=body)
            */
            return default;
        }

        protected async Task<ResPartner> MailGetPartnersInternalAsync(object introspect_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _mail_get_partners(self, introspect_fields=False):
            // return dict((partner.id, partner) for partner in self)
            */
            return default;
        }

        protected async Task<ResPartner> MergeMethodInternalAsync(object destination, object source)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _merge_method(self, destination, source):
            // """
            // Prevent merging partners that are linked to already hashed journal items.
            // """
            // if self.env['account.move.line'].sudo().search_count([('move_id.inalterable_hash', '!=', False), ('partner_id', 'in', source.ids)], limit=1):
            //     raise UserError(_('Partners that are used in hashed entries cannot be merged.'))
            // return super()._merge_method(destination, source)
            */
            return default;
        }

        protected async Task<ResPartner> MessageGetDefaultRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id:
            //     {'partner_ids': [r.id],
            //      'email_to': False,
            //      'email_cc': False
            //     }
            //     for r in self
            // }
            */
            return default;
        }

        protected async Task<ResPartner> MessageGetSuggestedRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // self._message_add_suggested_recipient(recipients, partner=self, reason=_('Partner Profile'))
            // return recipients
            */
            return default;
        }

        protected async Task<ResPartner> MondialrelaySearchOrCreateInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py) ---
            // def _mondialrelay_search_or_create(self, data):
            // ref = 'MR#%s' % data['id']
            // partner = self.search([
            //     ('id', 'child_of', self.commercial_partner_id.ids),
            //     ('ref', '=', ref),
            //     # fast check that address always the same
            //     ('street', '=', data['street']),
            //     ('zip', '=', data['zip']),
            // ])
            // if not partner:
            //     partner = self.create({
            //         'ref': ref,
            //         'name': data['name'],
            //         'street': data['street'],
            //         'street2': data['street2'],
            //         'zip': data['zip'],
            //         'city': data['city'],
            //         'country_id': self.env.ref('base.%s' % data['country_code']).id,
            //         'type': 'delivery',
            //         'parent_id': self.id,
            //     })
            // return partner
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeCityIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _onchange_city_id(self):
            // if self.city_id:
            //     self.city = self.city_id.name
            //     self.zip = self.city_id.zipcode
            //     self.state_id = self.city_id.state_id
            // elif self._origin:
            //     self.city = False
            //     self.zip = False
            //     self.state_id = False
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<ResPartner> OnchangeCompanyTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> OnchangeCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id and self.country_id != self.state_id.country_id:
            //     self.state_id = False
            */
            return default;
        }

        public async Task<ResPartner> OnchangeEmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_email(self):
            // if not self.image_1920 and self._context.get('gravatar_image') and self.email:
            //     self.image_1920 = self._get_gravatar_image(self.email)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> OnchangeMobileValidationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        public async Task<ResPartner> OnchangeParentIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_parent_id(self):
            // # return values in result, as this method is used by _fields_sync()
            // if not self.parent_id:
            //     return
            // result = {}
            // partner = self._origin
            // if partner.parent_id and partner.parent_id != self.parent_id:
            //     result['warning'] = {
            //         'title': _('Warning'),
            //         'message': _('Changing the company of a contact should only be done if it '
            //                      'was never correctly set. If an existing contact starts working for a new '
            //                      'company then a new contact should be created under that new '
            //                      'company. You can use the "Discard" button to abandon this change.')}
            // if partner.type == 'contact' or self.type == 'contact':
            //     # for contacts: copy the parent address, if set (aka, at least one
            //     # value is set in the address: otherwise, keep the one from the
            //     # contact)
            //     address_fields = self._address_fields()
            //     if any(self.parent_id[key] for key in address_fields):
            //         def convert(value):
            //             return value.id if isinstance(value, models.BaseModel) else value
            //         result['value'] = {key: convert(self.parent_id[key]) for key in address_fields}
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> OnchangeParentIdForLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_parent_id_for_lang(self):
            // # While creating / updating child contact, take the parent lang by default if any
            // # otherwise, fallback to default context / DB lang
            // if self.parent_id:
            //     self.lang = self.parent_id.lang or self.env.context.get('default_lang') or self.env.lang
            */
            return default;
        }

        protected async Task<ResPartner> OnchangePhoneValidationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        protected async Task<ResPartner> OnchangePropertyProductPricelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def _onchange_property_product_pricelist(self):
            // open_order = self.env['sale.order'].sudo().search([
            //     ('partner_id', '=', self._origin.id),
            //     ('pricelist_id', '=', self._origin.property_product_pricelist.id),
            //     ('pricelist_id', '!=', self.property_product_pricelist.id),
            //     ('website_id', '!=', False),
            //     ('state', '=', 'draft'),
            // ], limit=1)
            // 
            // if open_order:
            //     return {'warning': {
            //         'title': _('Open Sale Orders'),
            //         'message': _(
            //             "This partner has an open cart. "
            //             "Please note that the pricelist will not be updated on that cart. "
            //             "Also, the cart might not be visible for the customer until you update the pricelist of that cart."
            //         ),
            //     }}
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id and self.country_id != self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<ResPartner> OpenBusinessDocAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_open_business_doc(self):
            // return self._get_records_action()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> OpenCommercialEntityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def open_commercial_entity(self):
            // return {
            //     **super().open_commercial_entity(),
            //     **({'target': 'new'} if self.env.context.get('target') == 'new' else {}),
            // }
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def open_commercial_entity(self):
            // """ Utility method used to add an "Open Company" button in partner views """
            // self.ensure_one()
            // return {'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'form',
            //         'res_id': self.commercial_partner_id.id,
            //         'target': 'current',
            //         }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> OpenEmployeesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def action_open_employees(self):
            // self.ensure_one()
            // if self.employees_count > 1:
            //     return {
            //         'name': _('Related Employees'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'hr.employee',
            //         'view_mode': 'kanban',
            //         'domain': [('id', 'in', self.employee_ids.ids),
            //                    ('company_id', 'in', self.env.companies.ids)],
            //     }
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'res_id': self.employee_ids.filtered(lambda e: e.company_id in self.env.companies).id,
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> OrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _order(self):
            // res = super()._order
            // partner_search_mode = self.env.context.get('res_partner_search_mode')
            // if partner_search_mode not in ('customer', 'supplier'):
            //     return res
            // order_by_field = f"{partner_search_mode}_rank DESC"
            // return '%s, %s' % (order_by_field, res) if res else order_by_field
            */
            return default;
        }

        protected async Task<ResPartner> PaymentDueSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _payment_due_search(self, operator, operand):
            // args = [('payment_amount_due', operator, operand)]
            // query, params = self._get_followup_overdue_query(args, overdue_only=False)
            // self._cr.execute(query, params)
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [x[0] for x in res])]
            */
            return default;
        }

        protected async Task<ResPartner> PaymentEarliestDateSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _payment_earliest_date_search(self, operator, operand):
            // args = [('payment_earliest_due_date', operator, operand)]
            // company_id = self.env.user.company_id.id
            // having_where_clause = ' AND '.join(
            //     map(lambda x: "(MIN(l.date_maturity) %s '%%s')" % (x[1]), args))
            // having_values = [x[2] for x in args]
            // having_where_clause = having_where_clause % (having_values[0])
            // query = """SELECT partner_id FROM account_move_line l
            //         LEFT JOIN account_account a ON a.id = l.account_id
            //         WHERE a.account_type = 'asset_receivable' 
            //         AND l.company_id = %s 
            //         AND l.full_reconcile_id IS NULL 
            //         AND partner_id IS NOT NULL GROUP BY partner_id"""
            // query = query % company_id
            // if having_where_clause:
            //     query += ' HAVING %s ' % (having_where_clause)
            // self._cr.execute(query)
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [x[0] for x in res])]
            */
            return default;
        }

        protected async Task<ResPartner> PaymentOverdueSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def _payment_overdue_search(self, operator, operand):
            // args = [('payment_amount_overdue', operator, operand)]
            // query, params = self._get_followup_overdue_query(args, overdue_only=True)
            // self._cr.execute(query, params)
            // res = self._cr.fetchall()
            // if not res:
            //     return [('id', '=', '0')]
            // return [('id', 'in', [x[0] for x in res])]
            */
            return default;
        }

        protected async Task<ResPartner> PeppolEasEndpointDependsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # field dependencies of methods _compute_peppol_endpoint() and _compute_peppol_eas()
            // # because we need to extend depends in l10n modules
            // return ['country_code', 'vat', 'company_registry']
            */
            return default;
        }

        protected async Task<ResPartner> PrepareDisplayAddressInternalAsync(object without_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _prepare_display_address(self, without_company=False):
            // # get the information that will be injected into the display format
            // # get the address format
            // address_format = self._get_address_format()
            // args = defaultdict(str, {
            //     'state_code': self.state_id.code or '',
            //     'state_name': self.state_id.name or '',
            //     'country_code': self.country_id.code or '',
            //     'country_name': self._get_country_name(),
            //     'company_name': self.commercial_company_name or '',
            // })
            // for field in self._formatting_address_fields():
            //     args[field] = self[field] or ''
            // if without_company:
            //     args['company_name'] = ''
            // elif self.commercial_company_name:
            //     address_format = '%(company_name)s\n' + address_format
            // return address_format, args
            */
            return default;
        }

        public async Task<ResPartner> PrivacyLookupAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py) ---
            // def action_privacy_lookup(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('privacy_lookup.action_privacy_lookup_wizard')
            // action['context'] = {
            //     'default_email': self.email,
            //     'default_name': self.name,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> ProcessEnrichedResponseInternalAsync(object response, object error)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def _process_enriched_response(self, response, error):
            // if response and response.get('data'):
            //     result = self._format_data_company(response.get('data'))
            // else:
            //     result = {}
            // 
            // if response and response.get('credit_error'):
            //     result.update({
            //         'error': True,
            //         'error_message': 'Insufficient Credit'
            //     })
            // elif response and response.get('error'):
            //     result.update({
            //         'error': True,
            //         'error_message': _('Unable to enrich company (no credit was consumed).'),
            //     })
            // elif error:
            //     result.update({
            //         'error': True,
            //         'error_message': error
            //     })
            // return result
            */
            return default;
        }

        public async Task<ResPartner> ReadByVatAsync(Guid id, ResPartnerReadByVatRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def read_by_vat(self, vat, timeout=15):
            // return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> RetrievePartnerInternalAsync(object name, object phone, object email, object vat, object domain, object company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner(self, name=None, phone=None, email=None, vat=None, domain=None, company=None):
            // '''Search all partners and find one that matches one of the parameters.
            // :param name:    The name of the partner.
            // :param phone:   The phone or mobile of the partner.
            // :param mail:    The mail of the partner.
            // :param vat:     The vat number of the partner.
            // :param domain:  An extra domain to apply.
            // :param company: The company of the partner.
            // :returns:       A partner or an empty recordset if not found.
            // '''
            // 
            // def search_with_vat(extra_domain):
            //     return self._retrieve_partner_with_vat(vat, extra_domain)
            // 
            // def search_with_phone_mail(extra_domain):
            //     return self._retrieve_partner_with_phone_email(phone, email, extra_domain)
            // 
            // def search_with_name(extra_domain):
            //     return self._retrieve_partner_with_name(name, extra_domain)
            // 
            // def search_with_domain(extra_domain):
            //     if not domain:
            //         return None
            //     return self.env['res.partner'].search(domain + extra_domain, limit=1)
            // 
            // for search_method in (search_with_vat, search_with_domain, search_with_phone_mail, search_with_name):
            //     for extra_domain in (
            //         [*self.env['res.partner']._check_company_domain(company or self.env.company), ('company_id', '!=', False)],
            //         [('company_id', '=', False)],
            //     ):
            //         partner = search_method(extra_domain)
            // 
            //         # The VAT should be a sufficiently distinctive criterion
            //         if partner and search_method == search_with_vat:
            //             return partner[:1]
            //         if partner and len(partner) == 1:
            //             return partner
            // return self.env['res.partner']
            */
            return default;
        }

        protected async Task<ResPartner> RetrievePartnerWithNameInternalAsync(object name, object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner_with_name(self, name, extra_domain):
            // if not name:
            //     return None
            // return self.env['res.partner'].search([('name', 'ilike', name)] + extra_domain, limit=2)
            */
            return default;
        }

        protected async Task<ResPartner> RetrievePartnerWithPhoneEmailInternalAsync(object phone, object email, object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner_with_phone_email(self, phone, email, extra_domain):
            // domains = []
            // if phone:
            //     domains.append([('phone', '=', phone)])
            //     domains.append([('mobile', '=', phone)])
            // if email:
            //     domains.append([('email', '=', email)])
            // 
            // if not domains:
            //     return None
            // 
            // domain = expression.OR(domains)
            // if extra_domain:
            //     domain = expression.AND([domain, extra_domain])
            // return self.env['res.partner'].search(domain, limit=2)
            */
            return default;
        }

        protected async Task<ResPartner> RetrievePartnerWithVatInternalAsync(object vat, object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _retrieve_partner_with_vat(self, vat, extra_domain):
            // if not vat:
            //     return None
            // 
            // # Sometimes, the vat is specified with some whitespaces.
            // normalized_vat = vat.replace(' ', '')
            // country_prefix = re.match('^[a-zA-Z]{2}|^', vat).group()
            // 
            // partner = self.env['res.partner'].search(extra_domain + [('vat', 'in', (normalized_vat, vat))], limit=2)
            // 
            // # Try to remove the country code prefix from the vat.
            // if not partner and country_prefix:
            //     partner = self.env['res.partner'].search(extra_domain + [
            //         ('vat', 'in', (normalized_vat[2:], vat[2:])),
            //         ('country_id.code', '=', country_prefix.upper()),
            //     ], limit=2)
            // 
            //     # The country could be not specified on the partner.
            //     if not partner:
            //         partner = self.env['res.partner'].search(extra_domain + [
            //             ('vat', 'in', (normalized_vat[2:], vat[2:])),
            //             ('country_id', '=', False),
            //         ], limit=2)
            // 
            // # The vat could be a string of alphanumeric values without country code but with missing zeros at the
            // # beginning.
            // if not partner:
            //     try:
            //         vat_only_numeric = str(int(re.sub(r'^\D{2}', '', normalized_vat) or 0))
            //     except ValueError:
            //         vat_only_numeric = None
            // 
            //     if vat_only_numeric:
            //         if country_prefix:
            //             vat_prefix_regex = f'({country_prefix})?'
            //         else:
            //             vat_prefix_regex = '([A-z]{2})?'
            //         Partner = self.env['res.partner']
            //         query = Partner._search(extra_domain + [('active', '=', True)], limit=2)
            //         query.add_where(SQL(
            //             "%s ~ %s",
            //             Partner._field_to_sql(Partner._table, 'vat'),
            //             f'^{vat_prefix_regex}0*{vat_only_numeric}$',
            //         ))
            //         partner_row = list(query)
            //         if partner_row and len(partner_row) == 1:
            //             partner = Partner.browse(partner_row[0])
            // 
            // return partner
            */
            return default;
        }

        protected async Task<ResPartner> RunVatTestInternalAsync(object vat_number, object default_country, object partner_is_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _run_vat_test(self, vat_number, default_country, partner_is_company=True):
            // """ Checks a VAT number syntactically to ensure its validity upon saving.
            // 
            // :param vat_number: a string with the VAT number to check.
            // :param default_country: a res.country object
            // :param partner_is_company: True if the partner is a company, else False.
            //     .. deprecated:: 16.0
            //         Will be removed in 16.2
            // 
            // :return: The country code (in lower case) of the country the VAT number
            //          was validated for, if it was validated. False if it could not be validated
            //          against the provided or guessed country. None if no country was available
            //          for the check, and no conclusion could be made with certainty.
            // """
            // return default_country.code.lower()
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _run_vat_test(self, vat_number, default_country, partner_is_company=True):
            // # OVERRIDE account
            // check_result = None
            // 
            // # First check with country code as prefix of the TIN
            // vat_country_code, vat_number_split = self._split_vat(vat_number)
            // 
            // if vat_country_code == 'eu' and default_country not in self.env.ref('base.europe').country_ids:
            //     # Foreign companies that trade with non-enterprises in the EU
            //     # may have a VATIN starting with "EU" instead of a country code.
            //     return True
            // 
            // vat_has_legit_country_code = self.env['res.country'].search([('code', '=', vat_country_code.upper())], limit=1)
            // if not vat_has_legit_country_code:
            //     vat_has_legit_country_code = vat_country_code.lower() in _region_specific_vat_codes
            // if vat_has_legit_country_code:
            //     check_result = self.simple_vat_check(vat_country_code, vat_number_split)
            //     if check_result:
            //         return vat_country_code
            // 
            // # If it fails, check with default_country (if it exists)
            // if default_country:
            //     check_result = self.simple_vat_check(default_country.code.lower(), vat_number)
            //     if check_result:
            //         return default_country.code.lower()
            // 
            // # We allow any number if it doesn't start with a country code and the partner has no country.
            // # This is necessary to support an ORM limitation: setting vat and country_id together on a company
            // # triggers two distinct write on res.partner, one for each field, both triggering this constraint.
            // # If vat is set before country_id, the constraint must not break.
            // return check_result
            */
            return default;
        }

        public async Task<ResPartner> ScheduleMeetingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def schedule_meeting(self):
            // self.ensure_one()
            // partner_ids = self.ids
            // partner_ids.append(self.env.user.partner_id.id)
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // action['context'] = {
            //     'default_partner_ids': partner_ids,
            // }
            // action['domain'] = ['|', ('id', 'in', self._compute_meeting()[self.id]), ('partner_ids', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> SearchForChannelInviteAsync(Guid id, ResPartnerSearchForChannelInviteRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def search_for_channel_invite(self, search_term, channel_id=None, limit=30):
            // """Returns partners matching search_term that can be invited to a channel.
            // If the channel_id is specified, only partners that can actually be invited to the channel
            // are returned (not already members, and in accordance to the channel configuration).
            // """
            // domain = expression.AND(
            //     [
            //         expression.OR(
            //             [
            //                 [("name", "ilike", search_term)],
            //                 [("email", "ilike", search_term)],
            //             ]
            //         ),
            //         [("active", "=", True)],
            //         [("user_ids", "!=", False)],
            //         [("user_ids.active", "=", True)],
            //         [("user_ids.share", "=", False)],
            //     ]
            // )
            // channel = self.env["discuss.channel"]
            // if channel_id:
            //     channel = self.env["discuss.channel"].search([("id", "=", int(channel_id))])
            //     domain = expression.AND([domain, [("channel_ids", "not in", channel.id)]])
            //     if channel.group_public_id:
            //         domain = expression.AND(
            //             [domain, [("user_ids.groups_id", "in", channel.group_public_id.id)]]
            //         )
            // query = self._search(domain, limit=limit)
            // # bypass lack of support for case insensitive order in search()
            // query.order = SQL('LOWER(%s), "res_partner"."id"', self._field_to_sql(self._table, "name"))
            // store = Store()
            // self.env["res.partner"].browse(query)._search_for_channel_invite_to_store(store, channel)
            // return {
            //     "count": self.env["res.partner"].search_count(domain),
            //     "data": store.get_result(),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> SearchForChannelInviteToStoreInternalAsync(object store, object channel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _search_for_channel_invite_to_store(self, store: Store, channel):
            // super()._search_for_channel_invite_to_store(store, channel)
            // if channel.channel_type != "livechat" or not self:
            //     return
            // lang_name_by_code = dict(self.env["res.lang"].get_installed())
            // invite_by_self_count_by_partner_id = dict(
            //     self.env["discuss.channel.member"]._read_group(
            //         [["create_uid", "=", self.env.user.id], ["partner_id", "in", self.ids]],
            //         groupby=["partner_id"],
            //         aggregates=["__count"],
            //     )
            // )
            // active_livechat_partners = (
            //     self.env["im_livechat.channel"].search([]).available_operator_ids.partner_id
            // )
            // for partner in self:
            //     store.add(
            //         partner,
            //         {
            //             "invite_by_self_count": invite_by_self_count_by_partner_id.get(partner, 0),
            //             "is_available": partner in active_livechat_partners,
            //             "lang_name": lang_name_by_code[partner.lang],
            //         },
            //     )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _search_for_channel_invite_to_store(self, store: Store, channel):
            // store.add(self)
            */
            return default;
        }

        protected async Task<ResPartner> SearchIsSubcontractorInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py) ---
            // def _search_is_subcontractor(self, operator, value):
            // assert operator in ('=', '!=', '<>') and value in (True, False), 'Operation not supported'
            // subcontractor_ids = self.env['mrp.bom'].search(
            //     [('type', '=', 'subcontract')]).subcontractor_ids.ids
            // if (operator == '=' and value is True) or (operator in ('<>', '!=') and value is False):
            //     search_operator = 'in'
            // else:
            //     search_operator = 'not in'
            // return [('id', search_operator, subcontractor_ids)]
            */
            return default;
        }

        protected async Task<ResPartner> SearchMentionSuggestionsInternalAsync(object domain, object limit, object extra_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _search_mention_suggestions(self, domain, limit, extra_domain=None):
            // domain_is_user = expression.AND([[('user_ids', '!=', False)], [('user_ids.active', '=', True)], domain])
            // priority_conditions = [
            //     expression.AND([domain_is_user, [('partner_share', '=', False)]]),  # Search partners that are internal users
            //     domain_is_user,  # Search partners that are users
            //     domain,  # Search partners that are not users
            // ]
            // if extra_domain:
            //     priority_conditions.append(extra_domain)
            // partners = self.env['res.partner']
            // for domain in priority_conditions:
            //     remaining_limit = limit - len(partners)
            //     if remaining_limit <= 0:
            //         break
            //     # We are using _search to avoid the default order that is
            //     # automatically added by the search method. "Order by" makes the query
            //     # really slow.
            //     query = self._search(expression.AND([[('id', 'not in', partners.ids)], domain]), limit=remaining_limit)
            //     partners |= self.browse(query)
            // return partners
            */
            return default;
        }

        protected async Task<ResPartner> SearchSlideChannelCompletedIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _search_slide_channel_completed_ids(self, operator, value):
            // cp_done = self.env['slide.channel.partner'].sudo().search([
            //     ('channel_id', operator, value),
            //     ('member_status', '=', 'completed')
            // ])
            // return [('id', 'in', cp_done.partner_id.ids)]
            */
            return default;
        }

        protected async Task<ResPartner> SearchSlideChannelIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def _search_slide_channel_ids(self, operator, value):
            // cp_enrolled = self.env['slide.channel.partner'].search([
            //     ('channel_id', operator, value),
            //     ('member_status', '!=', 'invited')
            // ])
            // return [('id', 'in', cp_enrolled.partner_id.ids)]
            */
            return default;
        }

        protected async Task<ResPartner> SetCalendarLastNotifAckInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _set_calendar_last_notif_ack(self):
            // partner = self.env['res.users'].browse(self.env.context.get('uid', self.env.uid)).partner_id
            // partner.write({'calendar_last_notif_ack': datetime.now()})
            */
            return default;
        }

        public async Task<ResPartner> SignupCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_cancel(self):
            // return self.write({'signup_type': None})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> SignupGetAuthParamAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_get_auth_param(self):
            // """ Get a signup token related to the partner if signup is enabled.
            //     If the partner already has a user, get the login parameter.
            // """
            // if not self.env.user._is_internal() and not self.env.is_admin():
            //     raise exceptions.AccessDenied()
            // 
            // res = defaultdict(dict)
            // 
            // allow_signup = self.env['res.users']._get_signup_invitation_scope() == 'b2c'
            // for partner in self:
            //     partner = partner.sudo()
            //     if allow_signup and not partner.user_ids:
            //         partner.signup_prepare()
            //         res[partner.id]['auth_signup_token'] = partner._generate_signup_token()
            //     elif partner.user_ids:
            //         res[partner.id]['auth_login'] = partner.user_ids[0].login
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> SignupPrepareAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def action_signup_prepare(self):
            // return self.signup_prepare()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> SignupPrepareAsync(Guid id, ResPartnerSignupPrepareRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_prepare(self, signup_type="signup"):
            // """ generate a new token for the partners with the given validity, if necessary
            //     :param expiration: the expiration datetime of the token (string, optional)
            // """
            // self.write({'signup_type': signup_type})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> SignupRetrieveInfoInternalAsync(object token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _signup_retrieve_info(self, token):
            // """ retrieve the user info about the token
            //     :return: a dictionary with the user information if the token is valid, None otherwise:
            //         - 'db': the name of the database
            //         - 'token': the token, if token is valid
            //         - 'name': the name of the partner, if token is valid
            //         - 'login': the user login, if the user already exists
            //         - 'email': the partner email, if the user does not exist
            // """
            // partner = self._get_partner_from_token(token)
            // if not partner:
            //     return None
            // res = {'db': self.env.cr.dbname}
            // res['token'] = token
            // res['name'] = partner.name
            // if partner.user_ids:
            //     res['login'] = partner.user_ids[0].login
            // else:
            //     res['email'] = res['login'] = partner.email or ''
            // return res
            */
            return default;
        }

        protected async Task<ResPartner> SignupRetrievePartnerInternalAsync(object token, object check_validity, object raise_exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def _signup_retrieve_partner(self, token, check_validity=False, raise_exception=False):
            // """ find the partner corresponding to a token, and possibly check its validity
            //     :param token: the token to resolve
            //     :param check_validity: if True, also check validity
            //     :param raise_exception: if True, raise exception instead of returning False
            //     :return: partner (browse record) or False (if raise_exception is False)
            // """
            // partner = self._get_partner_from_token(token)
            // if not partner:
            //     raise exceptions.UserError(_("Signup token '%s' is not valid or expired", token))
            // return partner
            */
            return default;
        }

        public async Task<ResPartner> SimpleVatCheckAsync(Guid id, ResPartnerSimpleVatCheckRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def simple_vat_check(self, country_code, vat_number):
            // '''
            // Check the VAT number depending of the country.
            // http://sima-pc.com/nif.php
            // '''
            // if not country_code.encode().isalpha():
            //     return False
            // check_func_name = 'check_vat_' + country_code
            // check_func = getattr(self, check_func_name, None) or getattr(stdnum.util.get_cc_module(country_code, 'vat'), 'is_valid', None)
            // if not check_func:
            //     # No VAT validation available, default to check that the country code exists
            //     country_code = _eu_country_vat_inverse.get(country_code, country_code)
            //     return bool(self.env['res.country'].search([('code', '=ilike', country_code)]))
            // return check_func(vat_number)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> SplitVatInternalAsync(object vat)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def _split_vat(self, vat):
            // '''
            // Splits the VAT Number to get the country code in a first place and the code itself in a second place.
            // This has to be done because some countries' code are one character long instead of two (i.e. "T" for Japan)
            // '''
            // if len(vat) > 1 and vat[1].isalpha():
            //     vat_country, vat_number = vat[:2].lower(), vat[2:].replace(' ', '')
            // else:
            //     vat_country, vat_number = vat[:1].lower(), vat[1:].replace(' ', '')
            // return vat_country, vat_number
            */
            return default;
        }

        protected async Task<ResPartner> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, **kwargs):
            // """Override to add the current leave status."""
            // super()._to_store(store, fields=fields, **kwargs)
            // if fields is None:
            //     fields = ["out_of_office_date_end"]
            // for partner in self:
            //     if "out_of_office_date_end" in fields:
            //         # in the rare case of multi-user partner, return the earliest possible return date
            //         dates = partner.mapped("user_ids.leave_date_to")
            //         states = partner.mapped("user_ids.current_leave_state")
            //         date = sorted(dates)[0] if dates and all(dates) else False
            //         state = sorted(states)[0] if states and all(states) else False
            //         store.add(
            //             partner, {"out_of_office_date_end": date if state == "validate" else False}
            //         )
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, **kwargs):
            // """Override to add name when user_livechat_username is not set."""
            // super()._to_store(store, fields=fields, **kwargs)
            // if fields and "user_livechat_username" in fields:
            //     if partners := self.filtered(lambda p: not p.user_livechat_username):
            //         super(Partners, partners)._to_store(store, fields=["name"])
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, main_user_by_partner=None):
            // if fields is None:
            //     fields = ["active", "avatar_128", "email", "im_status", "is_company", "name", "user"]
            // if not self.env.user._is_internal() and "email" in fields:
            //     fields.remove("email")
            // for partner in self:
            //     data = partner._read_format(
            //         [
            //             field
            //             for field in fields
            //             if field
            //             not in [
            //                 "avatar_128",
            //                 "country",
            //                 "display_name",
            //                 "isAdmin",
            //                 "notification_type",
            //                 "signature",
            //                 "user",
            //             ]
            //         ],
            //         load=False,
            //     )[0]
            //     if "avatar_128" in fields:
            //         data["avatar_128_access_token"] = limited_field_access_token(partner, "avatar_128")
            //         data["write_date"] = partner.write_date
            //     if "country" in fields:
            //         c = partner.country_id
            //         data["country"] = {"code": c.code, "id": c.id, "name": c.name} if c else False
            //     if "display_name" in fields:
            //         data["displayName"] = partner.display_name
            //     if 'user' in fields:
            //         main_user = main_user_by_partner and main_user_by_partner.get(partner)
            //         if not main_user:
            //             users = partner.with_context(active_test=False).user_ids
            //             internal_users = users - users.filtered("share")
            //             main_user = (
            //                 internal_users[0]
            //                 if len(internal_users) > 0
            //                 else users[0] if len(users) > 0 else self.env["res.users"]
            //             )
            //         data['userId'] = main_user.id
            //         data["isInternalUser"] = not main_user.share if main_user else False
            //         if "isAdmin" in fields:
            //             data["isAdmin"] = main_user._is_admin()
            //         if "notification_type" in fields:
            //             data["notification_preference"] = main_user.notification_type
            //         if "signature" in fields:
            //             data["signature"] = main_user.signature
            //     store.add(partner, data)
            */
            return default;
        }

        protected async Task<ResPartner> UnlinkExceptUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _unlink_except_user(self):
            // users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            // if not users:
            //     return  # no linked user, operation is allowed
            // if self.env['res.users'].sudo(False).has_access('write'):
            //     error_msg = _('You cannot delete contacts linked to an active user.\n'
            //                   'You should rather archive them after archiving their associated user.\n\n'
            //                   'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //     action_error = users._action_show()
            //     raise RedirectWarning(error_msg, action_error, _('Go to users'))
            // else:
            //     raise ValidationError(_('You cannot delete contacts linked to an active user.\n'
            //                             'Ask an administrator to archive their associated user first.\n\n'
            //                             'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            */
            return default;
        }

        protected async Task<ResPartner> UnlinkIfPartnerInAccountMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _unlink_if_partner_in_account_move(self):
            // """
            // Prevent the deletion of a partner "Individual", child of a company if:
            // - partner in 'account.move'
            // - state: all states (draft and posted)
            // """
            // moves = self.sudo().env['account.move'].search_count([
            //     ('partner_id', 'in', self.ids),
            //     ('state', 'in', ['draft', 'posted']),
            // ])
            // if moves:
            //     raise UserError(_("The partner cannot be deleted because it is used in Accounting"))
            */
            return default;
        }

        public async Task<ResPartner> UpdateAddressAsync(Guid id, ResPartnerUpdateAddressRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def update_address(self, vals):
            // addr_vals = {key: vals[key] for key in self._address_fields() if key in vals}
            // if addr_vals:
            //     return super().write(addr_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartner> UpdateFieldsValuesInternalAsync(object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _update_fields_values(self, fields):
            // """ Returns dict of write() values for synchronizing ``fields`` """
            // values = {}
            // for fname in fields:
            //     field = self._fields[fname]
            //     if field.type == 'many2one':
            //         values[fname] = self[fname].id
            //     elif field.type == 'one2many':
            //         raise AssertionError(_('One2Many fields cannot be synchronized as part of `commercial_fields` or `address fields`'))
            //     elif field.type == 'many2many':
            //         values[fname] = [Command.set(self[fname].ids)]
            //     else:
            //         values[fname] = self[fname]
            // return values
            */
            return default;
        }

        protected async Task<ResPartner> UpdatePeppolStatePerCompanyInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def _update_peppol_state_per_company(self, vals=None):
            // partners = self.env['res.partner']
            // if vals is None:
            //     partners = self.filtered(lambda p: all([p.peppol_eas, p.peppol_endpoint, p.is_ubl_format, p.country_code in PEPPOL_LIST]))
            // elif {'peppol_eas', 'peppol_endpoint', 'invoice_edi_format'}.intersection(vals.keys()):
            //     partners = self.filtered(lambda p: p.country_code in PEPPOL_LIST)
            // 
            // all_companies = None
            // for partner in partners.sudo():
            //     if partner.company_id:
            //         partner.button_account_peppol_check_partner_endpoint(company=partner.company_id)
            //         continue
            // 
            //     if all_companies is None:
            //         all_companies = self.env['res.company'].sudo().search([])
            // 
            //     for company in all_companies:
            //         partner.button_account_peppol_check_partner_endpoint(company=company)
            */
            return default;
        }

        public async Task<ResPartner> ViewCertificationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def action_view_certifications(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("survey.res_partner_action_certifications")
            // action['view_mode'] = 'list'
            // action['domain'] = ['|', ('partner_id', 'in', self.ids), ('partner_id', 'in', self.child_ids.ids)]
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewCoursesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py) ---
            // def action_view_courses(self):
            // """ View partners courses. In singleton mode, return courses followed
            // by all its contacts (if company) or by themselves (if not a company).
            // Otherwise simply set a domain on required partners. The courses to which
            // the partner(s) is not enrolled (e.g. invited) are not shown. """
            // action = self.env["ir.actions.actions"]._for_xml_id("website_slides.slide_channel_partner_action")
            // action['display_name'] = _('Courses')
            // action['domain'] = [('member_status', '!=', 'invited')]
            // if len(self) == 1 and self.is_company:
            //     action['domain'] = expression.AND([action['domain'], [('partner_id', 'in', self.child_ids.ids)]])
            // elif len(self) == 1:
            //     action['context'] = {'search_default_partner_id': self.id}
            // else:
            //     action['domain'] = expression.AND([action['domain'], [('partner_id', 'in', self.ids)]])
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewHeaderGetAsync(Guid id, ResPartnerViewHeaderGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def view_header_get(self, view_id, view_type):
            // if self.env.context.get('category_id'):
            //     return  _(
            //         'Partners: %(category)s',
            //         category=self.env['res.partner.category'].browse(self.env.context['category_id']).name,
            //     )
            // return super().view_header_get(view_id, view_type)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewLoyaltyCardsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py) ---
            // def action_view_loyalty_cards(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('loyalty.loyalty_card_action')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action['domain'] = [('partner_id', 'in', all_child.ids)]
            // action['context'] = {'search_default_active' : True, 'create': False}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewOpportunityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: res_partner.py) ---
            // def action_view_opportunity(self):
            // '''
            // This function returns an action that displays the opportunities from partner.
            // '''
            // action = self.env['ir.actions.act_window']._for_xml_id('crm.crm_lead_opportunities')
            // action['context'] = {}
            // if self.is_company:
            //     action['domain'] = [('partner_id.commercial_partner_id', '=', self.id)]
            // else:
            //     action['domain'] = [('partner_id', '=', self.id)]
            // action['domain'] = expression.AND([action['domain'], [('active', 'in', [True, False])]])
            // return action
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def action_view_opportunity(self):
            // self.ensure_one()  # especially here as we are doing an id, in, IDS domain
            // action = super().action_view_opportunity()
            // action_domain_origin = action.get('domain')
            // action_context_origin = action.get('context') or {}
            // action_domain_assign = [('partner_assigned_id', '=', self.id)]
            // if not action_domain_origin:
            //     action['domain'] = action_domain_assign
            //     return action
            // # perform searches independently as having OR with those leaves seems to
            // # be counter productive
            // Lead = self.env['crm.lead'].with_context(**action_context_origin, active_test=False)
            // ids_origin = Lead.search(action_domain_origin).ids
            // ids_new = Lead.search(action_domain_assign).ids
            // action['domain'] = [('id', 'in', sorted(list(set(ids_origin) | set(ids_new))))]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewPartnerInvoicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_view_partner_invoices(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_out_invoice_type")
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action['domain'] = [
            //     ('move_type', 'in', ('out_invoice', 'out_refund')),
            //     ('partner_id', 'in', all_child.ids)
            // ]
            // action['context'] = {'default_move_type': 'out_invoice', 'move_type': 'out_invoice', 'journal_type': 'sale', 'search_default_unpaid': 1}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewPartnerWithSameBankAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_view_partner_with_same_bank(self):
            // self.ensure_one()
            // bank_partners = self._get_duplicated_bank_accounts()
            // # Open a list view or form view of the partner(s) with the same bank accounts
            // if self.duplicated_bank_account_partners_count == 1:
            //     action_vals = {
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'form',
            //         'res_id': bank_partners.partner_id.id,
            //         'views': [(False, 'form')],
            //     }
            // else:
            //     action_vals = {
            //         'name': _("Partners"),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'list,form',
            //         'views': [(False, 'list'), (False, 'form')],
            //         'domain': [('id', 'in', bank_partners.partner_id.ids)],
            //     }
            // 
            // return action_vals
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewPosOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py) ---
            // def action_view_pos_order(self):
            // '''
            // This function returns an action that displays the pos orders from partner.
            // '''
            // action = self.env['ir.actions.act_window']._for_xml_id('point_of_sale.action_pos_pos_form')
            // if self.is_company:
            //     action['domain'] = [('partner_id.commercial_partner_id', '=', self.id)]
            // else:
            //     action['domain'] = [('partner_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def action_view_sale_order(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('sale.act_res_partner_2_sale_order')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action["domain"] = [("partner_id", "in", all_child.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewStockLotsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_partner.py) ---
            // def action_view_stock_lots(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.action_lot_report')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action["domain"] = [("partner_id", "in", all_child.ids)]
            // action["context"] = {'search_default_filter_not_has_return': True}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartner> ViewTasksAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_partner.py) ---
            // def action_view_tasks(self):
            // self.ensure_one()
            // action = {
            //     **self.env["ir.actions.actions"]._for_xml_id("project.project_task_action_from_partner"),
            //     'display_name': _("%(partner_name)s's Tasks", partner_name=self.name),
            //     'context': {
            //         'default_partner_id': self.id,
            //     },
            // }
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // search_domain = [('partner_id', 'in', (self | all_child).ids)]
            // if self.task_count <= 1:
            //     task_id = self.env['project.task'].search(search_domain, limit=1)
            //     action['res_id'] = task_id.id
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == "form"]
            // else:
            //     action['domain'] = search_domain
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResPartner entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def write(self, vals):
            // if 'parent_id' in vals:
            //     partner2moves = self.sudo().env['account.move'].search([('partner_id', 'in', self.ids)]).grouped('partner_id')
            //     parent_vat = self.env['res.partner'].browse(vals['parent_id']).vat
            //     if partner2moves and vals['parent_id'] and {parent_vat} != set(self.mapped('vat')):
            //         raise UserError(_("You cannot set a partner as an invoicing address of another if they have a different %(vat_label)s.", vat_label=self.vat_label))
            // 
            // res = super().write(vals)
            // 
            // if 'parent_id' in vals:
            //     for partner, moves in partner2moves.items():
            //         partner._compute_commercial_partner()
            //         # Make sure to write on all the lines at the same time to avoid breaking the reconciliation check
            //         moves.line_ids.with_context(bypass_lock_check=BYPASS_LOCK_CHECK).partner_id = partner.commercial_partner_id
            //         moves.with_context(bypass_lock_check=BYPASS_LOCK_CHECK).commercial_partner_id = partner.commercial_partner_id
            //         partner._message_log(body=_("The commercial partner has been updated for all related accounting entries."))
            // return res
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // self._update_peppol_state_per_company(vals=vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py) ---
            // def write(self, vals):
            // # Reset latitude/longitude in case we modify the address without
            // # updating the related geolocation fields
            // if any(field in vals for field in ['street', 'zip', 'city', 'state_id', 'country_id']) \
            //         and not all('partner_%s' % field in vals for field in ['latitude', 'longitude']):
            //     vals.update({
            //         'partner_latitude': 0.0,
            //         'partner_longitude': 0.0,
            //     })
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def write(self, values):
            // if values.get('vat') and len(self.mapped('country_id')) == 1:
            //     country_id = values.get('country_id', self.country_id.id)
            //     values['vat'] = self._fix_vat_number(values['vat'], country_id)
            // res = super().write(values)
            // if self.env.context.get('import_file'):
            //     self.env.remove_to_compute(self._fields['vies_valid'], self)
            // return res
            --- ODOO METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py) ---
            // def write(self, vals):
            // res = super(ResPartner, self).write(vals)
            // 
            // if 'iap_enrich_info' in vals or 'iap_search_domain' in vals:
            //     # Not done with inverse method so we do need to search
            //     # for existing <res.partner.iap> only once
            //     partner_iaps = self.env['res.partner.iap'].sudo().search([('partner_id', 'in', self.ids)])
            //     missing_partners = self
            //     for partner_iap in partner_iaps:
            //         if 'iap_enrich_info' in vals:
            //             partner_iap.iap_enrich_info = vals['iap_enrich_info']
            //         if 'iap_search_domain' in vals:
            //             partner_iap.iap_search_domain = vals['iap_search_domain']
            // 
            //         missing_partners -= partner_iap.partner_id
            // 
            //     if missing_partners:
            //         # Create new <res.partner.iap> for missing records
            //         self.env['res.partner.iap'].sudo().create([
            //             {
            //                 'partner_id': partner.id,
            //                 'iap_enrich_info': vals.get('iap_enrich_info'),
            //                 'iap_search_domain': vals.get('iap_search_domain'),
            //             } for partner in missing_partners
            //         ])
            // return res
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py) ---
            // def write(self, vals):
            // letter_address_vals = {}
            // address_fields = ['street', 'street2', 'city', 'zip', 'state_id', 'country_id']
            // for field in address_fields:
            //     if field in vals:
            //         letter_address_vals[field] = vals[field]
            // 
            // if letter_address_vals:
            //     letters = self.env['snailmail.letter'].search([
            //         ('state', 'not in', ['sent', 'canceled']),
            //         ('partner_id', 'in', self.ids),
            //     ])
            //     letters.write(letter_address_vals)
            // 
            // return super(ResPartner, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if {'country_id', 'vat', 'zip'} & vals.keys():
            //     # Recompute fiscal position for open website orders
            //     if orders_sudo := self.env['sale.order'].sudo().search([
            //         ('state', '=', 'draft'),
            //         ('website_id', '!=', False),
            //         '|', ('partner_id', 'in', self.ids), ('partner_shipping_id', 'in', self.ids),
            //     ]):
            //         orders_by_fpos = orders_sudo.grouped('fiscal_position_id')
            //         self.env.add_to_compute(orders_sudo._fields['fiscal_position_id'], orders_sudo)
            //         if fpos_changed := orders_sudo.filtered(
            //             lambda so: so not in orders_by_fpos.get(so.fiscal_position_id, []),
            //         ):
            //             fpos_changed._recompute_taxes()
            //             fpos_changed._recompute_prices()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def write(self, vals):
            // if vals.get('active') is False:
            //     # DLE: It should not be necessary to modify this to make work the ORM. The problem was just the recompute
            //     # of partner.user_ids when you create a new user for this partner, see test test_70_archive_internal_partners
            //     # You modified it in a previous commit, see original commit of this:
            //     # https://github.com/odoo/odoo/commit/9d7226371730e73c296bcc68eb1f856f82b0b4ed
            //     #
            //     # RCO: when creating a user for partner, the user is automatically added in partner.user_ids.
            //     # This is wrong if the user is not active, as partner.user_ids only returns active users.
            //     # Hence this temporary hack until the ORM updates inverse fields correctly.
            //     self.invalidate_recordset(['user_ids'])
            //     users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            //     if users:
            //         if self.env['res.users'].sudo(False).has_access('write'):
            //             error_msg = _('You cannot archive contacts linked to an active user.\n'
            //                           'You first need to archive their associated user.\n\n'
            //                           'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //             action_error = users._action_show()
            //             raise RedirectWarning(error_msg, action_error, _('Go to users'))
            //         else:
            //             raise ValidationError(_('You cannot archive contacts linked to an active user.\n'
            //                                     'Ask an administrator to archive their associated user first.\n\n'
            //                                     'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            // # res.partner must only allow to set the company_id of a partner if it
            // # is the same as the company of all users that inherit from this partner
            // # (this is to allow the code from res_users to write to the partner!) or
            // # if setting the company_id to False (this is compatible with any user
            // # company)
            // if vals.get('website'):
            //     vals['website'] = self._clean_website(vals['website'])
            // if vals.get('parent_id'):
            //     vals['company_name'] = False
            // if 'company_id' in vals:
            //     company_id = vals['company_id']
            //     for partner in self:
            //         if company_id and partner.user_ids:
            //             company = self.env['res.company'].browse(company_id)
            //             companies = set(user.company_id for user in partner.user_ids)
            //             if len(companies) > 1 or company not in companies:
            //                 raise UserError(
            //                     ("The selected company is not compatible with the companies of the related user(s)"))
            //         if partner.child_ids:
            //             partner.child_ids.write({'company_id': company_id})
            // result = True
            // # To write in SUPERUSER on field is_company and avoid access rights problems.
            // if 'is_company' in vals and not self.env.su and self.env.user.has_group('base.group_partner_manager'):
            //     result = super(Partner, self.sudo()).write({'is_company': vals.get('is_company')})
            //     del vals['is_company']
            // result = result and super().write(vals)
            // for partner in self:
            //     if any(u._is_internal() for u in partner.user_ids if u != self.env.user):
            //         self.env['res.users'].check_access('write')
            //     partner._fields_sync(vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def write(self, vals):
            // if vals.get("payment_responsible_id", False):
            //     for part in self:
            //         if part.payment_responsible_id != \
            //                 self.env['res.users'].browse(vals["payment_responsible_id"]):
            //             # Find partner_id of user put as responsible
            //             responsible_partner_id = self.env["res.users"].browse(
            //                 vals['payment_responsible_id']).partner_id.id
            //             part.message_post(
            //                 body=_("You became responsible to do the next action "
            //                        "for the payment follow-up of") +
            //                 " <b><a href='#id=" + str(part.id) +
            //                 "&view_type=form&model=res.partner'> " + part.name +
            //                 " </a></b>",
            //                 type='comment',
            //                 context=self.env.context,
            //                 partner_ids=[responsible_partner_id])
            // return super(ResPartner, self).write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }

        protected async Task<ResPartner> WriteCompanyTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _write_company_type(self):
            // for partner in self:
            //     partner.is_company = partner.company_type == 'company'
            */
            return default;
        }
    }
}