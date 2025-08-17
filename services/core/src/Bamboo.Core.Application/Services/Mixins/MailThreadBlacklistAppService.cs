using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailThreadBlacklistAppService : ApplicationService, IMailThreadBlacklistAppService
    {

        public MailThreadBlacklistAppService() 
        {

        }

        public async Task<TEntity> AddToListAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid list_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def add_to_list(self, name, list_id):
            // name, email = tools.parse_contact_from_email(name)
            // contact = self.create({'name': name, 'email': email, 'list_ids': [(4, list_id)]})
            // return contact.id, contact.display_name
            */
            return default;
        }

        public async Task<TEntity> AddToMailingListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def action_add_to_mailing_list(self):
            // ctx = dict(self.env.context, default_contact_ids=self.ids)
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing.mailing_contact_to_list_action")
            // action['view_mode'] = 'form'
            // action['target'] = 'new'
            // action['context'] = ctx
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py) ---
            // def _address_fields(self):
            // return super()._address_fields() + ['city_id']
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: res_partner.py) ---
            // def _address_fields(self):
            // return super()._address_fields() + ['l10n_eg_building_no']
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: res_partner.py) ---
            // def _address_fields(self):
            // return super()._address_fields() + ['l10n_sa_edi_building_number',
            //                                     'l10n_sa_edi_plot_identification']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _alias_get_creation_values(self):
            // values = super(MailTestGatewayGroups, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('mail.test.gateway.groups').id
            // if self.id:
            //     values['alias_force_thread_id'] = self.id
            //     values['alias_parent_thread_id'] = self.id
            // return values
            */
            return default;
        }

        public async Task<TEntity> ArUnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_pos, FILE: res_partner.py) ---
            // def _ar_unlink_except_master_data(self):
            // consumidor_final_anonimo = self.env.ref('l10n_ar.par_cfa').id
            // for partner in self.ids:
            //     if partner == consumidor_final_anonimo:
            //         raise UserError(_('Deleting this partner is not allowed.'))
            */
            return default;
        }

        public async Task<TEntity> AssertPrimaryEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _assert_primary_email(self):
            // if not hasattr(self, "_primary_email") or not isinstance(self._primary_email, str):
            //     raise UserError(_('Invalid primary email field on model %s', self._name))
            // if self._primary_email not in self._fields or self._fields[self._primary_email].type != 'char':
            //     raise UserError(_('Invalid primary email field on model %s', self._name))
            */
            return default;
        }

        public async Task<TEntity> AssetDifferenceSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // tools.create_index(self._cr, 'crm_lead_user_id_team_id_type_index',
            //                    self._table, ['user_id', 'team_id', 'type'])
            // tools.create_index(self._cr, 'crm_lead_create_date_team_id_idx',
            //                    self._table, ['create_date', 'team_id'])
            */
            return default;
        }

        public async Task<TEntity> AutocompleteAsync<TEntity>(IEnumerable<TEntity> entities, object query, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def autocomplete(self, query, timeout=15):
            // return []
            */
            return default;
        }

        public async Task<TEntity> AutocompleteByNameAsync<TEntity>(IEnumerable<TEntity> entities, object query, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> AutocompleteByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> BuildErrorPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eas, object endpoint) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> BuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object wrong_vat, object record_label) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> BuildVcardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> BusSendHistoryMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object page_history) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ButtonAccountPeppolCheckPartnerEndpointAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CanBeEditedByCurrentCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CanEditNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CanEditVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CheckCompanyRegistryMaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ma, FILE: res_partner.py) ---
            // def _check_company_registry_ma(self):
            // for record in self:
            //     if record.country_code == 'MA' and record.company_registry and (len(record.company_registry) != 15 or not record.company_registry.isdigit()):
            //         raise ValidationError(_("ICE number should have exactly 15 digits."))
            */
            return default;
        }

        public async Task<TEntity> CheckDocumentTypeSupportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object ubl_cii_format) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CheckGstInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def check_gst_in(self, vat):
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CheckInterviewerAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _check_interviewer_access(self):
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     raise UserError(_('You are not allowed to perform this action.'))
            */
            return default;
        }

        public async Task<TEntity> CheckL10nRsEdiPublicFundsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: res_partner.py) ---
            // def _check_l10n_rs_edi_public_funds(self):
            // for record in self:
            //     if record.l10n_rs_edi_public_funds and \
            //         (len(record.l10n_rs_edi_public_funds) < 5 or not record.l10n_rs_edi_public_funds.isdigit()):
            //         raise ValidationError(_('Public Funds ID(JBKJS) must be exactly five digits'))
            */
            return default;
        }

        public async Task<TEntity> CheckL10nRsEdiRegistrationNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: res_partner.py) ---
            // def _check_l10n_rs_edi_registration_number(self):
            // for record in self:
            //     if record.l10n_rs_edi_registration_number and \
            //         (len(record.l10n_rs_edi_registration_number) not in [8, 13] or not record.l10n_rs_edi_registration_number.isdigit()):
            //         raise ValidationError(_('Customer identification number should be 8 or 13 digits'))
            */
            return default;
        }

        public async Task<TEntity> CheckNilveraCustomerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera, FILE: res_partner.py) ---
            // def check_nilvera_customer(self):
            // self.ensure_one()
            // if not self.vat:
            //     return
            // 
            // with _get_nilvera_client(self.env.company) as client:
            //     response = client.request("GET", "/general/GlobalCompany/Check/TaxNumber/" + urllib.parse.quote(self.vat), handle_response=False)
            //     if response.status_code == 200:
            //         query_result = response.json()
            // 
            //         if not query_result:
            //             self.l10n_tr_nilvera_customer_status = 'earchive'
            //             self.l10n_tr_nilvera_customer_alias_id = False
            //         else:
            //             self.l10n_tr_nilvera_customer_status = 'einvoice'
            // 
            //             # We need to sync the data from the API with the records in database.
            //             aliases = {result.get('Name') for result in query_result}
            //             persisted_aliases = self.l10n_tr_nilvera_customer_alias_ids
            //             # Find aliases to add (in query result but not in database).
            //             aliases_to_add = aliases - set(persisted_aliases.mapped('name'))
            //             # Find aliases to remove (in database but not in query result).
            //             aliases_to_remove = set(persisted_aliases.mapped('name')) - aliases
            // 
            //             newly_persisted_aliases = self.env['l10n_tr.nilvera.alias'].create([{
            //                 'name': alias_name,
            //                 'partner_id': self.id,
            //             } for alias_name in aliases_to_add])
            //             to_keep = persisted_aliases.filtered(lambda a: a.name not in aliases_to_remove)
            //             (persisted_aliases - to_keep).unlink()
            // 
            //             # If no alias was previously selected, automatically select the first alias.
            //             remaining_aliases = newly_persisted_aliases | to_keep
            //             if not self.l10n_tr_nilvera_customer_alias_id and remaining_aliases:
            //                 self.l10n_tr_nilvera_customer_alias_id = remaining_aliases[0]
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CheckPeppolFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CheckPeppolParticipantExistsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object edi_identification, object check_company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CheckRecursionAssociateMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: membership, FILE: partner.py) ---
            // def _check_recursion_associate_member(self):
            // if self._has_cycle('associate_member'):
            //     raise ValidationError(_('You cannot create recursive associated members.'))
            */
            return default;
        }

        public async Task<TEntity> CheckVatAlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def check_vat(self):
            // """ Since we validate more documents than the vat for Argentinean partners (CUIT - VAT AR, CUIL, DNI) we
            // extend this method in order to process it. """
            // # NOTE by the moment we include the CUIT (VAT AR) validation also here because we extend the messages
            // # errors to be more friendly to the user. In a future when Odoo improve the base_vat message errors
            // # we can change this method and use the base_vat.check_vat_ar method.s
            // l10n_ar_partners = self.filtered(lambda p: p.l10n_latam_identification_type_id.l10n_ar_afip_code or p.country_code == 'AR')
            // l10n_ar_partners.l10n_ar_identification_validation()
            // return super(ResPartner, self - l10n_ar_partners).check_vat()
            --- ODOO METHOD SOURCE (MODULE: l10n_co, FILE: res_partner.py) ---
            // def check_vat(self):
            // # check_vat is implemented by base_vat which this localization
            // # doesn't directly depend on. It is however automatically
            // # installed for Colombia.
            // if self.sudo().env.ref('base.module_base_vat').state == 'installed':
            //     # don't check Colombian partners unless they have RUT (= Colombian VAT) set as document type
            //     self = self.filtered(lambda partner: partner.country_id.code != "CO" or\
            //                                          partner.l10n_latam_identification_type_id.l10n_co_document_code == 'rut')
            //     return super(ResPartner, self).check_vat()
            // else:
            //     return True
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: res_partner.py) ---
            // def check_vat(self):
            // it_ruc = self.env.ref("l10n_ec.ec_ruc", False)
            // it_dni = self.env.ref("l10n_ec.ec_dni", False)
            // ecuadorian_partners = self.filtered(
            //     lambda x: x.country_id == self.env.ref("base.ec")
            // )
            // for partner in ecuadorian_partners:
            //     if partner.vat:
            //         if partner.l10n_latam_identification_type_id.id in (
            //             it_ruc.id,
            //             it_dni.id,
            //         ):
            //             if partner.l10n_latam_identification_type_id.id == it_dni.id and len(partner.vat) != 10:
            //                 raise ValidationError(_('If your identification type is %s, it must be 10 digits',
            //                                         it_dni.display_name))
            //             if partner.l10n_latam_identification_type_id.id == it_ruc.id and len(partner.vat) != 13:
            //                 raise ValidationError(_('If your identification type is %s, it must be 13 digits',
            //                                         it_ruc.display_name))
            // return super(ResPartner, self - ecuadorian_partners).check_vat()
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_base, FILE: res_partner.py) ---
            // def check_vat(self):
            // with_vat = self.filtered(lambda x: x.l10n_latam_identification_type_id.is_vat)
            // return super(ResPartner, with_vat).check_vat()
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: res_partner.py) ---
            // def check_vat(self):
            // # EXTEND account/base_vat
            // """ Add validation of UY document types CI and NIE """
            // ci_nie_types = self.filtered(
            //     lambda p: p.l10n_latam_identification_type_id.l10n_uy_dgi_code in ("1", "3")
            //               and p.l10n_latam_identification_type_id.country_id.code == "UY" and p.vat)
            // for partner in ci_nie_types:
            //     if not partner._l10n_uy_ci_nie_is_valid():
            //         raise ValidationError(self._l10n_uy_build_vat_error_message(partner))
            // return super(ResPartner, self - ci_nie_types).check_vat()
            */
            return default;
        }

        public async Task<TEntity> CheckVatBrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_br(self, vat):
            // is_cpf_valid = stdnum.get_cc_module('br', 'cpf').is_valid
            // is_cnpj_valid = stdnum.get_cc_module('br', 'cnpj').is_valid
            // return is_cpf_valid(vat) or is_cnpj_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatCrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatDeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_de(self, vat):
            // is_valid_vat = stdnum.util.get_cc_module("de", "vat").is_valid
            // is_valid_stnr = stdnum.util.get_cc_module("de", "stnr").is_valid
            // return is_valid_vat(vat) or is_valid_stnr(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ec(self, vat):
            // vat = clean(vat, ' -.').upper().strip()
            // return self.is_valid_ruc_ec(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatGrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatIdAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatIeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ie(self, vat):
            // return stdnum.util.get_cc_module('ie', 'vat').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatIlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_il(self, vat):
            // check_func = stdnum.util.get_cc_module('il', 'idnr').is_valid
            // return check_func(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def check_vat_in(self, vat):
            // """
            //     This TEST_GST_NUMBER is used as test credentials for EDI
            //     but this is not a valid number as per the regular expression
            //     so TEST_GST_NUMBER is considered always valid
            // """
            // if vat == TEST_GST_NUMBER:
            //     return True
            // return super().check_vat_in(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatMaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ma(self, vat):
            // return vat.isdigit() and len(vat) == 8
            */
            return default;
        }

        public async Task<TEntity> CheckVatMxAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatNoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatPeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatPhAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_ph(self, vat):
            // return len(vat) >= 11 and len(vat) <= 17 and self.__check_vat_ph_re.match(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatRoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatRuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatSaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatTAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_t(self, vat):
            // if self.country_id.code == 'JP':
            //     return self.simple_vat_check('jp', vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatTrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def check_vat_tr(self, vat):
            // return stdnum.util.get_cc_module('tr', 'tckimlik').is_valid(vat) or stdnum.util.get_cc_module('tr', 'vkn').is_valid(vat)
            */
            return default;
        }

        public async Task<TEntity> CheckVatUaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatUyAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatVeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CheckVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _commercial_fields(self):
            // return super(ResPartner, self)._commercial_fields() + \
            //     ['debit_limit', 'property_account_payable_id', 'property_account_receivable_id', 'property_account_position_id',
            //      'property_payment_term_id', 'property_supplier_payment_term_id', 'credit_limit']
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_ar_afip_responsibility_type_id']
            --- ODOO METHOD SOURCE (MODULE: l10n_cl, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_cl_sii_taxpayer_type']
            --- ODOO METHOD SOURCE (MODULE: l10n_eg_edi_eta, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_eg_building_no']
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + [
            //     'l10n_hu_group_vat',
            // ]
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // res = super()._commercial_fields()
            // return res + ['l10n_in_gst_treatment', 'l10n_in_pan']
            --- ODOO METHOD SOURCE (MODULE: l10n_ke_edi_tremol, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_ke_exemption_number']
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_base, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_latam_identification_type_id']
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_my_identification_type', 'l10n_my_identification_number']
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_my_edi_industrial_classification', 'l10n_my_edi_malaysian_tin']
            --- ODOO METHOD SOURCE (MODULE: l10n_my_ubl_pint, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['sst_registration_number', 'ttx_registration_number']
            --- ODOO METHOD SOURCE (MODULE: l10n_ph, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['branch_code']
            --- ODOO METHOD SOURCE (MODULE: l10n_ro, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super(ResPartner, self)._commercial_fields() + ['nrc']
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // return super()._commercial_fields() + ['l10n_sa_edi_building_number',
            //                                        'l10n_sa_edi_plot_identification',
            //                                        'l10n_sa_additional_identification_scheme',
            //                                        'l10n_sa_additional_identification_number']
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

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CommercialSyncToChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_application_count(self):
            // read_group_res = self.env['hr.applicant'].with_context(active_test=False)._read_group(
            //     [('candidate_id', 'in', self.ids)],
            //     ['candidate_id'], ['__count'])
            // application_data = dict(read_group_res)
            // for candidate in self:
            //     candidate.application_count = application_data.get(candidate, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_applications_count(self):
            // result = defaultdict(lambda: {"total": 0, "refused": 0, "accepted": 0})
            // for applicant in self.with_context(active_test=False).applicant_ids:
            //     result[applicant.candidate_id.id]["total"] += 1
            //     if applicant.application_status == "refused":
            //         result[applicant.candidate_id.id]["refused"] += 1
            //     elif applicant.application_status == "hired":
            //         result[applicant.candidate_id.id]["accepted"] += 1
            // for candidate in self:
            //     candidate.applications_count = result[candidate.id]['total']
            //     candidate.refused_applications_count = result[candidate.id]['refused']
            //     candidate.accepted_applications_count = result[candidate.id]['accepted']
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_attachment_count(self):
            // read_group_res = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.candidate'), ('res_id', 'in', self.ids)],
            //     ['res_id'], ['__count'])
            // attach_data = dict(read_group_res)
            // for candidate in self:
            //     candidate.attachment_count = attach_data.get(candidate.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeAvailablePeppolSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeBankCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeBomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeBranchCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ph, FILE: res_partner.py) ---
            // def _compute_branch_code(self):
            // for partner in self:
            //     branch_code = '000'
            //     if partner.country_id.code == 'PH' and partner.vat:
            //         match = partner.__check_vat_ph_re.match(partner.vat)
            //         branch_code = match and match.group(1) and match.group(1)[1:] or branch_code
            //     partner.branch_code = branch_code
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_partner.py) ---
            // def _compute_can_publish(self):
            // self2 = self.with_context(can_publish_unsudo_main_object=False)
            // super(Partner, self2)._compute_can_publish()
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: res_partner.py) ---
            // def _compute_certifications_company_count(self):
            // self.certifications_company_count = sum(child.certifications_count for child in self.child_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_currency(self):
            // for lead in self:
            //     if not lead.company_id:
            //         lead.company_currency = self.env.company.currency_id
            //     else:
            //         lead.company_currency = lead.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_id(self):
            // """ Compute company_id coherency. """
            // for lead in self:
            //     proposal = lead.company_id
            // 
            //     # invalidate wrong configuration
            //     if proposal:
            //         # company not in responsible companies
            //         if lead.user_id and proposal not in lead.user_id.company_ids:
            //             proposal = False
            //         # inconsistent
            //         elif lead.team_id.company_id and proposal != lead.team_id.company_id:
            //             proposal = False
            //         # void company on team and no assignee
            //         elif lead.team_id and not lead.team_id.company_id and not lead.user_id:
            //             proposal = False
            //         # no user and no team -> void company and let assignment do its job
            //         # unless customer has a company
            //         elif not lead.team_id and not lead.user_id and \
            //                 (not lead.partner_id or lead.partner_id.company_id != proposal):
            //             proposal = False
            // 
            //     # propose a new company based on team > user (respecting context) > partner
            //     if not proposal:
            //         if lead.team_id.company_id:
            //             lead.company_id = lead.team_id.company_id
            //         elif lead.user_id:
            //             if self.env.company in lead.user_id.company_ids:
            //                 lead.company_id = self.env.company
            //             else:
            //                 lead.company_id = lead.user_id.company_id & self.env.companies
            //         elif lead.partner_id:
            //             lead.company_id = lead.partner_id.company_id
            //         else:
            //             lead.company_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_be, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # OVERRIDE
            // # If a belgian company has a VAT number then its company registry is its VAT Number (without country code).
            // super()._compute_company_registry()
            // for partner in self.filtered(lambda p: p._deduce_country_code() == 'BE' and p.vat):
            //     vat_country, vat_number = self._split_vat(partner.vat)
            //     if vat_country.isnumeric():
            //         vat_country = 'be'
            //         vat_number = partner.vat
            //     if vat_country == 'be' and self.simple_vat_check(vat_country, vat_number):
            //         partner.company_registry = vat_number
            --- ODOO METHOD SOURCE (MODULE: l10n_dk, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # OVERRIDE
            // # In Denmark, if you have a VAT number, it's also your company registry (CVR) number
            // super()._compute_company_registry()
            // for partner in self.filtered(lambda p: p.country_id.code == 'DK' and p.vat):
            //     vat_country, vat_number = self._split_vat(partner.vat)
            //     if vat_country.isnumeric():
            //         vat_country = 'dk'
            //         vat_number = partner.vat
            //     if vat_country == 'dk' and self.simple_vat_check(vat_country, vat_number):
            //         partner.company_registry = vat_number
            --- ODOO METHOD SOURCE (MODULE: l10n_ro, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # OVERRIDE
            // # In Romania, if you have a VAT number, it's also your company registry (CUI) number
            // super()._compute_company_registry()
            // for partner in self.filtered(lambda p: p.country_id.code == 'RO' and p.vat):
            //     vat_country, vat_number = self._split_vat(partner.vat)
            //     if vat_country.isnumeric():
            //         vat_country = 'ro'
            //         vat_number = partner.vat
            //     if vat_country == 'ro' and self.simple_vat_check(vat_country, vat_number):
            //         partner.company_registry = vat_number
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # exists to allow overrides
            // for company in self:
            //     company.company_registry = company.company_registry
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_contact_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_contact_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputeCountActiveCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeCreditToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_last_stage_update(self):
            // for lead in self:
            //     if not lead.date_last_stage_update:
            //         lead.date_last_stage_update = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_open(self):
            // for lead in self:
            //     if not lead.date_open and lead.user_id:
            //         lead.date_open = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_close(self):
            // """ Compute difference between current date and log date """
            // leads = self.filtered(lambda l: l.date_closed and l.create_date)
            // others = self - leads
            // others.day_close = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date)
            //     date_close = fields.Datetime.from_string(lead.date_closed)
            //     lead.day_close = abs((date_close - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_open(self):
            // """ Compute difference between create date and open date """
            // leads = self.filtered(lambda l: l.date_open and l.create_date)
            // others = self - leads
            // others.day_open = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date).replace(microsecond=0)
            //     date_open = fields.Datetime.from_string(lead.date_open)
            //     lead.day_open = abs((date_open - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysSalesOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_display_name(self):
            // for candidate in self:
            //     candidate.display_name = candidate.partner_name or candidate.partner_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayPanWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def _compute_display_pan_warning(self):
            // for partner in self:
            //     partner.display_pan_warning = partner.vat and partner.l10n_in_pan and partner.l10n_in_pan != partner.vat[2:12]
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedBankAccountPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_duplicated_bank_account_partners_count(self):
            // for partner in self:
            //     partner.duplicated_bank_account_partners_count = len(partner._get_duplicated_bank_accounts())
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_domain_criterion(self):
            // self.email_domain_criterion = False
            // for lead in self.filtered('email_normalized'):
            //     lead.email_domain_criterion = iap_tools.mail_prepare_for_domain_search(
            //         lead.email_normalized
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_from(self):
            // for lead in self:
            //     if lead.partner_id.email and lead._get_partner_email_update():
            //         lead.email_from = lead.partner_id.email
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _compute_email_from(self):
            // for ticket in self.filtered(lambda r: r.customer_id and not r.email_from):
            //     ticket.email_from = ticket.customer_id.email_formatted
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _compute_email_from(self):
            // for source in self.filtered(lambda r: r.customer_id and not r.email_from):
            //     source.email_from = source.customer_id.email_formatted
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailNormalizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _compute_email_normalized(self):
            // self._assert_primary_email()
            // for record in self:
            //     record.email_normalized = tools.email_normalize(record[self._primary_email], strict=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_state(self):
            // for lead in self:
            //     email_state = False
            //     if lead.email_from:
            //         email_state = 'incorrect'
            //         for email in email_split(lead.email_from):
            //             if mail_validation.mail_validate(email):
            //                 email_state = 'correct'
            //                 break
            //     lead.email_state = email_state
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def _compute_employees_count(self):
            // for partner in self:
            //     partner.employees_count = len(partner.sudo().employee_ids.filtered(lambda e: e.company_id in self.env.companies))
            */
            return default;
        }

        public async Task<TEntity> ComputeEventCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_function(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.function or lead.partner_id.function:
            //         lead.function = lead.partner_id.function
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
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

        public async Task<TEntity> ComputeImplementedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_automated_probability(self):
            // """ If probability and automated_probability are equal probability computation
            // is considered as automatic, aka probability is sync with automated_probability """
            // for lead in self:
            //     lead.is_automated_probability = tools.float_compare(lead.probability, lead.automated_probability, 2) == 0
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _compute_is_blacklisted(self):
            // # TODO : Should remove the sudo as compute_sudo defined on methods.
            // # But if user doesn't have access to mail.blacklist, doen't work without sudo().
            // blacklist = set(self.env['mail.blacklist'].sudo().search([
            //     ('email', 'in', self.mapped('email_normalized'))]).mapped('email'))
            // for record in self:
            //     record.is_blacklisted = record.email_normalized in blacklist
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py) ---
            // def _compute_is_mondialrelay(self):
            // for p in self:
            //     p.is_mondialrelay = p.ref and p.ref.startswith('MR#')
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_partner_visible(self):
            // """ When the crm.lead is of type 'lead', we don't want to display the "Customer" field on the form view
            // unless it's set (or debug mode).
            // 
            // Indeed, most of the times leads will not have this information set, since when we assign a Customer we
            // usually convert the lead to an opportunity as well.
            // 
            // This means that on the lead form, we don't want to display this field since it may be misleading for the
            // end user.
            // When it's set however, we want to display it, mainly because there are a few automatic synchronizations between
            // the lead and its partner (phone and email for examples), and this needs to be clear that modifying
            // one of those fields will in turn modify the linked partner."""
            // is_debug_mode = self.env.user.has_group('base.group_no_one')
            // for lead in self:
            //     lead.is_partner_visible = bool(lead.type == 'opportunity' or lead.partner_id or is_debug_mode)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_is_peppol_edi_format(self):
            // for partner in self:
            //     partner.is_peppol_edi_format = partner.invoice_edi_format in self._get_peppol_formats()
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeIsUblFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _compute_is_ubl_format(self):
            // for partner in self:
            //     partner.is_ubl_format = partner.invoice_edi_format in self._get_ubl_cii_formats()
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalItemCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeL10nArFormattedVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def _compute_l10n_ar_formatted_vat(self):
            // """ This will add some dash to the CUIT number (VAT AR) in order to show in his natural format:
            // {person_category}-{number}-{validation_number} """
            // recs_ar_vat = self.filtered('l10n_ar_vat')
            // for rec in recs_ar_vat:
            //     try:
            //         rec.l10n_ar_formatted_vat = stdnum.ar.cuit.format(rec.l10n_ar_vat)
            //     except Exception as error:
            //         rec.l10n_ar_formatted_vat = rec.l10n_ar_vat
            //         _logger.runbot("Argentinean VAT was not formatted: %s", repr(error))
            // remaining = self - recs_ar_vat
            // remaining.l10n_ar_formatted_vat = False
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nArVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def _compute_l10n_ar_vat(self):
            // """ We add this computed field that returns cuit (VAT AR) or nothing if this one is not set for the partner.
            // This Validation can be also done by calling ensure_vat() method that returns the cuit (VAT AR) or error if this
            // one is not found """
            // recs_ar_vat = self.filtered(lambda x: x.l10n_latam_identification_type_id.l10n_ar_afip_code == '80' and x.vat)
            // for rec in recs_ar_vat:
            //     rec.l10n_ar_vat = stdnum.ar.cuit.compact(rec.vat)
            // remaining = self - recs_ar_vat
            // remaining.l10n_ar_vat = False
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nEcVatValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: res_partner.py) ---
            // def _compute_l10n_ec_vat_validation(self):
            // it_ruc = self.env.ref("l10n_ec.ec_ruc", False)
            // it_dni = self.env.ref("l10n_ec.ec_dni", False)
            // ruc = stdnum.util.get_cc_module("ec", "ruc")
            // ci = stdnum.util.get_cc_module("ec", "ci")
            // for partner in self:
            //     partner.l10n_ec_vat_validation = False
            //     if partner and partner.l10n_latam_identification_type_id in (it_ruc, it_dni) and partner.vat:
            //         final_consumer = verify_final_consumer(partner.vat)
            //         if not final_consumer:
            //             if partner.l10n_latam_identification_type_id.id == it_dni.id and not ci.is_valid(partner.vat):
            //                 partner.l10n_ec_vat_validation = _("The VAT %s seems to be invalid as the tenth digit doesn't comply with the validation algorithm "
            //                                                    "(could be an old VAT number)", partner.vat)
            //             if partner.l10n_latam_identification_type_id.id == it_ruc.id and not ruc.is_valid(partner.vat):
            //                 partner.l10n_ec_vat_validation = _("The VAT %s seems to be invalid as the tenth digit doesn't comply with the validation algorithm "
            //                                                    "(SRI has stated that this validation is not required anymore for some VAT numbers)", partner.vat)
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nEsEdiFacturaeResidenceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: res_partner.py) ---
            // def _compute_l10n_es_edi_facturae_residence_type(self):
            // eu_country_ids = self.env.ref('base.europe').country_ids.ids
            // for partner in self:
            //     country = partner.country_id
            //     if country.code == 'ES':
            //         partner.l10n_es_edi_facturae_residence_type = 'R'
            //     elif country.id in eu_country_ids:
            //         partner.l10n_es_edi_facturae_residence_type = 'U'
            //     else:
            //         partner.l10n_es_edi_facturae_residence_type = 'E'
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nGrEdiBranchNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gr_edi, FILE: res_partner.py) ---
            // def _compute_l10n_gr_edi_branch_number(self):
            // for partner in self:
            //     if partner.country_code == 'GR':
            //         partner.l10n_gr_edi_branch_number = partner.l10n_gr_edi_branch_number or 0
            //     else:
            //         partner.l10n_gr_edi_branch_number = False
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nHuEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu, FILE: res_partner.py) ---
            // def _compute_l10n_hu_eu_vat(self):
            // for partner in self:
            //     if partner.country_code == 'HU' and partner.vat:
            //         partner.l10n_hu_eu_vat = partner._convert_hu_local_to_eu_vat(partner.vat)
            //     else:
            //         partner.l10n_hu_eu_vat = False
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nIdPkpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_id_efaktur, FILE: res_partner.py) ---
            // def _compute_l10n_id_pkp(self):
            // for record in self:
            //     record.l10n_id_pkp = record.vat and record.country_code == 'ID'
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nInGstStateWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def _compute_l10n_in_gst_state_warning(self):
            // for partner in self:
            //     if (
            //         "IN" in partner.fiscal_country_codes
            //         and partner.check_vat_in(partner.vat)
            //     ):
            //         if partner.vat[:2] == "99":
            //             partner.l10n_in_gst_state_warning = _(
            //                 "As per GSTN the country should be other than India, so it's recommended to"
            //             )
            //         else:
            //             state_id = self.env['res.country.state'].search([('l10n_in_tin', '=', partner.vat[:2])], limit=1)
            //             if state_id and state_id != partner.state_id:
            //                 partner.l10n_in_gst_state_warning = _(
            //                     "As per GSTN the state should be %s, so it's recommended to", state_id.name
            //                 )
            //             else:
            //                 partner.l10n_in_gst_state_warning = False
            //     else:
            //         partner.l10n_in_gst_state_warning = False
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nMyEdiDisplayTinWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: res_partner.py) ---
            // def _compute_l10n_my_edi_display_tin_warning(self):
            // """ We want to display the tin warning for companies registered to use MyInvois. """
            // # We need to sudo here, as all users having access to partners may not have the rights to access the proxy users.
            // proxy_user = self.env.company.sudo().l10n_my_edi_proxy_user_id
            // is_edi_used = proxy_user and proxy_user.proxy_type == 'l10n_my_edi'
            // for partner in self:
            //     # Users with no business number can't be validated using the api
            //     partner.l10n_my_edi_display_tin_warning = is_edi_used and partner.l10n_my_identification_number
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nMyEdiIndustrialClassificationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: res_partner.py) ---
            // def _compute_l10n_my_edi_industrial_classification(self):
            // default_classification = self.env.ref('l10n_my_edi.class_00000', raise_if_not_found=False)
            // self.filtered(lambda p: not p.l10n_my_edi_industrial_classification).l10n_my_edi_industrial_classification = default_classification
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nMyIdentificationNumberPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: res_partner.py) ---
            // def _compute_l10n_my_identification_number_placeholder(self):
            // """ Computes a dynamic placeholder that depends on the selected type to help the user inputs their data.
            // The placeholders have been taken from the MyInvois doc.
            // """
            // for partner in self:
            //     placeholder = 'N/A'
            //     if partner.l10n_my_identification_type == 'NRIC':
            //         placeholder = '830503-11-4923'
            //     elif partner.l10n_my_identification_type == 'BRN':
            //         placeholder = '202201234565'
            //     elif partner.l10n_my_identification_type == 'PASSPORT':
            //         placeholder = 'A00000000'
            //     elif partner.l10n_my_identification_type == 'ARMY':
            //         placeholder = '830805-13-4983'
            //     partner.l10n_my_identification_number_placeholder = placeholder
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nMyTinValidationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: res_partner.py) ---
            // def _compute_l10n_my_tin_validation_state(self):
            // """ The three @depends are used for the validation. If they change, we will invalidate it and expect the user to revalidate. """
            // self.l10n_my_tin_validation_state = False
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: res_partner.py) ---
            // def _compute_l10n_my_tin_validation_state(self):
            // # EXTEND 'l10n_my_edi' to add the depends
            // super()._compute_l10n_my_tin_validation_state()
            */
            return default;
        }

        public async Task<TEntity> ComputeL10nThBranchNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_th, FILE: res_partner.py) ---
            // def _compute_l10n_th_branch_name(self):
            // for partner in self:
            //     if not partner.is_company or partner.country_code != 'TH':
            //         partner.l10n_th_branch_name = ""
            //     else:
            //         code = partner.company_registry
            //         partner.l10n_th_branch_name = f"Branch {code}" if code else "Headquarter"
            */
            return default;
        }

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_active_count(self):
            // self.lang_active_count = len(self.env['res.lang'].get_installed())
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_id(self):
            // """ compute the lang based on partner, erase any value to force the partner
            // one if set. """
            // # prepare cache
            // lang_codes = [code for code in self.mapped('partner_id.lang') if code]
            // if lang_codes:
            //     lang_id_by_code = dict(
            //         (code, self.env['res.lang']._get_data(code=code).id)
            //         for code in lang_codes
            //     )
            // else:
            //     lang_id_by_code = {}
            // for lead in self.filtered('partner_id'):
            //     lead.lang_id = lang_id_by_code.get(lead.partner_id.lang, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeLastWebsiteSoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeMeetingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_meeting_display(self):
            // now = fields.Datetime.now()
            // meeting_data = self.env['calendar.event'].sudo()._read_group([
            //     ('opportunity_id', 'in', self.ids),
            // ], ['opportunity_id'], ['start:array_agg', 'start:max'])
            // mapped_data = {
            //     lead: {
            //         'last_meeting_date': last_meeting_date,
            //         'next_meeting_date': min([dt for dt in meeting_start_dates if dt > now] or [False]),
            //     } for lead, meeting_start_dates, last_meeting_date in meeting_data
            // }
            // for lead in self:
            //     lead_meeting_info = mapped_data.get(lead)
            //     if not lead_meeting_info:
            //         lead.meeting_display_date = False
            //         lead.meeting_display_label = _('No Meeting')
            //     elif lead_meeting_info['next_meeting_date']:
            //         lead.meeting_display_date = lead_meeting_info['next_meeting_date']
            //         lead.meeting_display_label = _('Next Meeting')
            //     else:
            //         lead.meeting_display_date = lead_meeting_info['last_meeting_date']
            //         lead.meeting_display_label = _('Last Meeting')
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_meeting_display(self):
            // candidate_with_meetings = self.filtered('meeting_ids')
            // (self - candidate_with_meetings).update({
            //     'meeting_display_text': _('No Meeting'),
            //     'meeting_display_date': ''
            // })
            // today = fields.Date.today()
            // for candidate in candidate_with_meetings:
            //     count = len(candidate.meeting_ids)
            //     dates = candidate.meeting_ids.mapped('start')
            //     min_date, max_date = min(dates).date(), max(dates).date()
            //     if min_date >= today:
            //         candidate.meeting_display_date = min_date
            //     else:
            //         candidate.meeting_display_date = max_date
            //     if count == 1:
            //         candidate.meeting_display_text = _('1 Meeting')
            //     elif candidate.meeting_display_date >= today:
            //         candidate.meeting_display_text = _('Next Meeting')
            //     else:
            //         candidate.meeting_display_text = _('Last Meeting')
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeMembershipStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_mobile(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.mobile or lead.partner_id.mobile:
            //         lead.mobile = lead.partner_id.mobile
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_name(self):
            // for lead in self:
            //     if not lead.name and lead.partner_id and lead.partner_id.name:
            //         lead.name = _("%s's opportunity") % lead.partner_id.name
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def _compute_name(self):
            // for record in self:
            //     if record.first_name or record.last_name:
            //         record.name = ' '.join(name_part for name_part in (record.first_name, record.last_name) if name_part)
            */
            return default;
        }

        public async Task<TEntity> ComputeNilveraCustomerStatusAndAliasIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera, FILE: res_partner.py) ---
            // def _compute_nilvera_customer_status_and_alias_id(self):
            // if modules.module.current_test:
            //     return
            // for partner in self:
            //     if partner.vat and partner.invoice_edi_format == 'ubl_tr':
            //         try:
            //             partner.check_nilvera_customer()
            //         except UserError:
            //             # In case of an internet connection issue, exit silently.
            //             continue
            //     else:
            //         # Reset the alias if no VAT or UBL format changed.
            //         partner.l10n_tr_nilvera_customer_status = 'not_checked'
            //         partner.l10n_tr_nilvera_customer_alias_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeOnTimeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeOpportunityCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeOptOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def _compute_opt_out(self):
            // if 'default_list_ids' in self._context and isinstance(self._context['default_list_ids'], (list, tuple)) and len(self._context['default_list_ids']) == 1:
            //     [active_list_id] = self._context['default_list_ids']
            //     for record in self:
            //         active_subscription_list = record.subscription_ids.filtered(lambda l: l.list_id.id == active_list_id)
            //         record.opt_out = active_subscription_list.opt_out
            // else:
            //     for record in self:
            //         record.opt_out = False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_address_values(self):
            // """ Sync all or none of address fields """
            // for lead in self:
            //     lead.update(lead._prepare_address_values_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_email_update(self):
            // for lead in self:
            //     lead.partner_email_update = lead._get_partner_email_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIapInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mass_mailing, FILE: mailing_models_cornercase.py) ---
            // def _compute_partner_id(self):
            // partners = self.env['res.partner'].search(
            //     [('email_normalized', 'in', self.filtered('email_from').mapped('email_normalized'))]
            // )
            // self.partner_id = False
            // for record in self.filtered('email_from'):
            //     record.partner_id = next(
            //         (partner.id for partner in partners
            //          if partner.email_normalized == record.email_normalized),
            //         False
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_partner_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_partner_phone_email(self):
            // for candidate in self:
            //     if not candidate.partner_id:
            //         continue
            //     candidate.email_from = candidate.partner_id.email
            //     if not candidate.partner_phone:
            //         candidate.partner_phone = candidate.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_partner_phone_sanitized(self):
            // for candidate in self:
            //     candidate.partner_phone_sanitized = candidate._phone_format(fname='partner_phone') or candidate.partner_phone
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_phone_update(self):
            // for lead in self:
            //     lead.partner_phone_update = lead._get_partner_phone_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePartnerVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePartnerWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py) ---
            // def _compute_partner_weight(self):
            // for partner in self:
            //     partner.partner_weight = partner.grade_id.partner_weight if partner.grade_id else 0
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTokenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePerformViesValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone(self):
            // for lead in self:
            //     if lead.partner_id.phone and lead._get_partner_phone_update():
            //         lead.phone = lead.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone_state(self):
            // for lead in self:
            //     phone_status = False
            //     if lead.phone:
            //         country_code = lead.country_id.code if lead.country_id and lead.country_id.code else None
            //         try:
            //             if phone_validation.phone_parse(lead.phone, country_code):  # otherwise library not installed
            //                 phone_status = 'correct'
            //         except UserError:
            //             phone_status = 'incorrect'
            //     lead.phone_state = phone_status
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePosOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_potential_lead_duplicates(self):
            // """ Override potential lead duplicates computation to be more efficient
            // with high lead volume.
            // Criterions:
            //   * email domain exact match;
            //   * phone_sanitized exact match;
            //   * same commercial entity;
            // """
            // SEARCH_RESULT_LIMIT = 21
            // 
            // def return_if_relevant(model_name, domain):
            //     """ Returns the recordset obtained by performing a search on the provided
            //     model with the provided domain if the cardinality of that recordset is
            //     below a given threshold (i.e: `SEARCH_RESULT_LIMIT`). Otherwise, returns
            //     an empty recordset of the provided model as it indicates search term
            //     was not relevant.
            //     Note: The function will use the administrator privileges to guarantee
            //     that a maximum amount of leads will be included in the search results
            //     and transcend multi-company record rules. It also includes archived
            //     records. Idea is that counter indicates duplicates are present and
            //     the lead could be escalated to managers.
            //     """
            //     model = self.env[model_name].sudo().with_context(active_test=False)
            //     res = model.search(domain, limit=SEARCH_RESULT_LIMIT)
            //     return res if len(res) < SEARCH_RESULT_LIMIT else model
            // 
            // for lead in self:
            //     lead_id = lead._origin.id if isinstance(lead.id, models.NewId) else lead.id
            //     common_lead_domain = [
            //         ('id', '!=', lead_id)
            //     ]
            // 
            //     duplicate_lead_ids = self.env['crm.lead']
            // 
            //     # check the "company" email domain duplicates
            //     if lead.email_domain_criterion:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('email_domain_criterion', '=', lead.email_domain_criterion)
            //         ])
            //     # check for "same commercial entity" duplicates
            //     if lead.partner_id and lead.partner_id.commercial_partner_id:
            //         duplicate_lead_ids |= lead.with_context(active_test=False).search(common_lead_domain + [
            //             ("partner_id", "child_of", lead.partner_id.commercial_partner_id.ids)
            //         ])
            //     # check the phone number duplicates, based on phone_sanitized. Only
            //     # exact matches are found, and the single one stored in phone_sanitized
            //     # in case phone and mobile are both set.
            //     if lead.phone_sanitized:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('phone_sanitized', '=', lead.phone_sanitized)
            //         ])
            // 
            //     lead.duplicate_lead_ids = duplicate_lead_ids + lead
            //     lead.duplicate_lead_count = len(duplicate_lead_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_priority(self):
            // for candidate in self:
            //     if not candidate.applicant_ids:
            //         candidate.priority = "0"
            //     else:
            //         candidate.priority = str(round(sum(int(a.priority) for a in candidate.applicant_ids) / len(candidate.applicant_ids)))
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_probabilities(self):
            // lead_probabilities = self._pls_get_naive_bayes_probabilities()
            // for lead in self:
            //     if lead.id in lead_probabilities:
            //         was_automated = lead.active and lead.is_automated_probability
            //         lead.automated_probability = lead_probabilities[lead.id]
            //         if was_automated:
            //             lead.probability = lead.automated_probability
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeProductionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_prorated_revenue(self):
            // for lead in self:
            //     lead.prorated_revenue = round((lead.expected_revenue or 0.0) * (lead.probability or 0) / 100.0, 2)
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly = (lead.recurring_revenue or 0.0) / (lead.recurring_plan.number_of_months or 1)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly_prorated = (lead.recurring_revenue_monthly or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_prorated = (lead.recurring_revenue or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeShowCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _compute_show_credit_limit(self):
            // for partner in self:
            //     partner.show_credit_limit = self.env.company.account_use_credit_limit
            */
            return default;
        }

        public async Task<TEntity> ComputeSimilarCandidatesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_similar_candidates_count(self):
            // """
            //     The field similar_candidates_count is only used on the form view.
            //     Thus, using ORM rather then querying, should not make much
            //     difference in terms of performance, while being more readable and secure.
            // """
            // if not any(self._ids):
            //     for candidate in self:
            //         domain = candidate._get_similar_candidates_domain()
            //         if domain:
            //             candidate.similar_candidates_count = max(0, self.env["hr.candidate"].with_context(active_test=False).search_count(domain) - 1)
            //         else:
            //             candidate.similar_candidates_count = 0
            //     return
            // self.flush_recordset(['email_normalized', 'partner_phone_sanitized'])
            // self.env.cr.execute("""
            //     SELECT
            //         id,
            //         (
            //             SELECT COUNT(*)
            //             FROM hr_candidate AS sub
            //             WHERE c.id != sub.id
            //              AND ((coalesce(c.email_normalized, '') <> '' AND sub.email_normalized = c.email_normalized)
            //                OR (coalesce(c.partner_phone_sanitized, '') <> '' AND c.partner_phone_sanitized = sub.partner_phone_sanitized))
            //               AND c.company_id = sub.company_id
            //         ) AS similar_candidates
            //     FROM hr_candidate AS c
            //     WHERE id IN %(ids)s
            // """, {'ids': tuple(self._origin.ids)})
            // query_results = self.env.cr.dictfetchall()
            // mapped_data = {result['id']: result['similar_candidates'] for result in query_results}
            // for candidate in self:
            //     candidate.similar_candidates_count = mapped_data.get(candidate.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeSlideChannelValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_stage_id(self):
            // for lead in self:
            //     if not lead.stage_id:
            //         lead.stage_id = lead._stage_find(domain=[('fold', '=', False)]).id
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def _compute_static_map_url(self):
            // for partner in self:
            //     partner.static_map_url = partner._google_map_signed_img(zoom=13, width=598, height=200)
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeSupplierInvoiceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_team_id(self):
            // """ When changing the user, also set a team_id or restrict team id
            // to the ones user_id is member of. """
            // for lead in self:
            //     # setting user as void should not trigger a new team computation
            //     if not lead.user_id:
            //         continue
            //     user = lead.user_id
            //     if lead.team_id and user in (lead.team_id.member_ids | lead.team_id.user_id):
            //         continue
            //     team_domain = [('use_leads', '=', True)] if lead.type == 'lead' else [('use_opportunities', '=', True)]
            //     team = self.env['crm.team']._get_default_team_id(user_id=user.id, domain=team_domain)
            //     if lead.team_id != team:
            //         lead.team_id = team.id
            */
            return default;
        }

        public async Task<TEntity> ComputeTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_title(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.title or lead.partner_id.title:
            //         lead.title = lead.partner_id.title
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<TEntity> ComputeUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_user_company_ids(self):
            // all_companies = self.env['res.company'].search([])
            // for lead in self:
            //     if not lead.company_id:
            //         lead.user_company_ids = all_companies
            //     else:
            //         lead.user_company_ids = lead.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeUserLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py) ---
            // def _compute_user_livechat_username(self):
            // for partner in self:
            //     partner.user_livechat_username = next(iter(partner.user_ids.mapped('livechat_username')), False)
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        public async Task<TEntity> ComputeViesValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeViesVatToCheckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_website(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.website or lead.partner_id.website:
            //         lead.website = lead.partner_id.website
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ConvertHuLocalToEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def convert_opportunity(self, partner, user_ids=False, team_id=False):
            // customer = partner if partner else self.env['res.partner']
            // for lead in self:
            //     if not lead.active or lead.probability == 100:
            //         continue
            //     vals = lead._convert_opportunity_data(customer, team_id)
            //     lead.write(vals)
            // 
            // if user_ids or team_id:
            //     self._handle_salesmen_assignment(user_ids=user_ids, team_id=team_id)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _convert_opportunity_data(self, customer, team_id=False):
            // """ Extract the data from a lead to create the opportunity
            //     :param customer : res.partner record
            //     :param team_id : identifier of the Sales Team to determine the stage
            // """
            // new_team_id = team_id if team_id else self.team_id.id
            // upd_values = {
            //     'type': 'opportunity',
            //     'date_conversion': self.env.cr.now(),
            // }
            // if customer != self.partner_id:
            //     upd_values['partner_id'] = customer.id if customer else False
            // if not self.stage_id:
            //     stage = self._stage_find(team_id=new_team_id)
            //     upd_values['stage_id'] = stage.id
            // return upd_values
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def copy(self, default=None):
            // """ Cleans the default_list_ids while duplicating mailing contact in context of
            // a mailing list because we already have subscription lists copied over for newly
            // created contact, no need to add the ones from default_list_ids again """
            // if self.env.context.get('default_list_ids'):
            //     self = self.with_context(default_list_ids=False)
            // return super().copy(default)
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def copy_data(self, default=None):
            // # set default value in context, if not already set (Put stage to 'new' stage)
            // # Set date_open to today if it is an opp
            // default = dict(default or {})
            // if not self.env.user.has_group('crm.group_use_recurring_revenues'):
            //     default['recurring_revenue'] = 0
            //     default['recurring_plan'] = False
            // vals_list = super().copy_data(default=default)
            // now = self.env.cr.now()
            // for lead, vals in zip(self, vals_list):
            //     vals.setdefault('type', lead.type)
            //     vals.setdefault('team_id', lead.team_id.id)
            //     vals['date_open'] = now if lead.type == 'opportunity' else False
            //     if not lead.user_id.active:
            //         vals['user_id'] = False
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // leads = super(Lead, self).create(vals_list)
            // 
            // for lead, values in zip(leads, vals_list):
            //     if any(field in ['active', 'stage_id'] for field in values):
            //         lead._handle_won_lost(values)
            // 
            // return leads
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def create(self, vals_list):
            // """ Synchronize default_list_ids (currently used notably for computed
            // fields) default key with subscription_ids given by user when creating
            // contacts.
            // 
            // Those two values have the same purpose, adding a list to to the contact
            // either through a direct write on m2m, either through a write on middle
            // model subscription.
            // 
            // This is a bit hackish but is due to default_list_ids key being
            // used to compute oupt_out field. This should be cleaned in master but here
            // we simply try to limit issues while keeping current behavior. """
            // default_list_ids = self._context.get('default_list_ids')
            // default_list_ids = default_list_ids if isinstance(default_list_ids, (list, tuple)) else []
            // 
            // for vals in vals_list:
            //     if vals.get('list_ids') and vals.get('subscription_ids'):
            //         raise UserError(_('You should give either list_ids, either subscription_ids to create new contacts.'))
            // 
            // if default_list_ids:
            //     for vals in vals_list:
            //         if vals.get('list_ids'):
            //             continue
            //         current_list_ids = []
            //         subscription_ids = vals.get('subscription_ids') or []
            //         for subscription in subscription_ids:
            //             if len(subscription) == 3:
            //                 current_list_ids.append(subscription[2]['list_id'])
            //         for list_id in set(default_list_ids) - set(current_list_ids):
            //             subscription_ids.append((0, 0, {'list_id': list_id}))
            //         vals['subscription_ids'] = subscription_ids
            // 
            // return super(MassMailingContact, self.with_context(default_list_ids=False)).create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _create_customer(self):
            // """ Create a partner from lead data and link it to the lead.
            // 
            // :return: newly-created partner browse record
            // """
            // Partner = self.env['res.partner']
            // contact_name = self.contact_name
            // if not contact_name:
            //     contact_name = parse_contact_from_email(self.email_from)[0] if self.email_from else False
            // 
            // if self.partner_name:
            //     partner_company = Partner.create(self._prepare_customer_values(self.partner_name, is_company=True))
            // elif self.partner_id:
            //     partner_company = self.partner_id
            // else:
            //     partner_company = None
            // 
            // if contact_name:
            //     return Partner.create(self._prepare_customer_values(contact_name, is_company=False, parent_id=partner_company.id if partner_company else False))
            // 
            // if partner_company:
            //     return partner_company
            // return Partner.create(self._prepare_customer_values(self.name, is_company=False))
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromCandidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def create_employee_from_candidate(self):
            // self.ensure_one()
            // self._check_interviewer_access()
            // 
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('Please provide an candidate name.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // action = self.env['ir.actions.act_window']._for_xml_id('hr.open_view_employee_list')
            // employee = self.env['hr.employee'].create(self._get_employee_create_vals())
            // action['res_id'] = employee.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> CreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_create_meeting(self):
            // """ This opens Meeting's calendar view to schedule meeting on current candidate
            //     @return: Dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('You must define a Contact Name for this candidate.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // partners = self.partner_id
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     partners |= self.env.user.partner_id
            // else:
            //     partners |= self.user_id.partner_id
            // 
            // res = self.env['ir.actions.act_window']._for_xml_id('calendar.action_calendar_event')
            // # As we are redirected from the hr.candidate, calendar checks rules on "hr.applicant",
            // # in order to decide whether to allow creation of a meeting.
            // # As interviewer does not have create right on the hr.applicant, in order to allow them
            // # to create a meeting for an applicant, we pass 'create': True to the context.
            // res['context'] = {
            //     'create': True,
            //     'default_candidate_id': self.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
            */
            return default;
        }

        public async Task<TEntity> CreateMembershipInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object product, object amount) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> CreatePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.team_id:
            //     return _('A new lead has been created for the team "%(team_name)s".', team_name=self.team_id.display_name)
            // return _('A new lead has been created and is not assigned to any team.')
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_lead.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // return _('A new lead has been created and is assigned to %(user_name)s.', user_name=self.user_id.name or _('nobody'))
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('crm.mt_lead_create')
            */
            return default;
        }

        public async Task<TEntity> CreditDebitGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> CreditSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _credit_search(self, operator, operand):
            // return self._asset_difference_search('asset_receivable', operator, operand)
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _cron_update_automated_probabilities(self):
            // """ This cron will :
            //   - rebuild the lead scoring frequency table
            //   - recompute all the automated_probability and align probability if both were aligned
            // """
            // cron_start_date = datetime.now()
            // self._rebuild_pls_frequency_table()
            // self._update_automated_probabilities()
            // _logger.info("Predictive Lead Scoring : Cron duration = %d seconds" % ((datetime.now() - cron_start_date).total_seconds()))
            */
            return default;
        }

        public async Task<TEntity> CronUpdateMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> DebitSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _debit_search(self, operator, operand):
            // return self._asset_difference_search('liability_payable', operator, operand)
            */
            return default;
        }

        public async Task<TEntity> DeduceCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            --- ODOO METHOD SOURCE (MODULE: l10n_fr, FILE: res_partner.py) ---
            // def _deduce_country_code(self):
            // if self.siret:
            //     return 'FR'
            // return super()._deduce_country_code()
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _deduce_country_code(self):
            // if self.l10n_it_codice_fiscale:
            //     return 'IT'
            // return super()._deduce_country_code()
            --- ODOO METHOD SOURCE (MODULE: l10n_no, FILE: res_partner.py) ---
            // def _deduce_country_code(self):
            // if self.l10n_no_bronnoysund_number:
            //     return 'NO'
            // return super()._deduce_country_code()
            --- ODOO METHOD SOURCE (MODULE: l10n_sg, FILE: res_partner.py) ---
            // def _deduce_country_code(self):
            // if self.l10n_sg_unique_entity_number:
            //     return 'SG'
            // return super()._deduce_country_code()
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self._context.get('category_id'))
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _default_display_invoice_template_pdf_report_id(self):
            // available_templates_count = self.env['ir.actions.report'].search_count([('is_invoice_report', '=', True)], limit=2)
            // return available_templates_count > 1
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def default_get(self, fields_list):
            // """ When coming from a mailing list we may have a default_list_ids context
            // key. We should use it to create subscription_ids default value that
            // are displayed to the user as list_ids is not displayed on form view. """
            // res = super(MassMailingContact, self).default_get(fields_list)
            // if 'subscription_ids' in fields_list and not res.get('subscription_ids'):
            //     list_ids = self.env.context.get('default_list_ids')
            //     if 'default_list_ids' not in res and list_ids and isinstance(list_ids, (list, tuple)):
            //         res['subscription_ids'] = [
            //             (0, 0, {'list_id': list_id}) for list_id in list_ids]
            // return res
            */
            return default;
        }

        public async Task<TEntity> DetectLoopSenderDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from_normalized) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _detect_loop_sender_domain(self, email_from_normalized):
            // """Return the domain to be used to detect duplicated records created by alias.
            // 
            // :param email_from_normalized: FROM of the incoming email, normalized
            // """
            // return [('email_normalized', '=', email_from_normalized)]
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> DoButtonPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> DoPartnerMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> DoPartnerManualDermanordAsync<TEntity>(IEnumerable<TEntity> entities, object followup_line) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> DoPartnerPrintAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> wizard_partner_ids, object data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> DoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py) ---
            // def action_done(self):
            // return self.write({'payment_next_action_date': False,
            //                    'payment_next_action': '',
            //                    'payment_responsible_id': False})
            */
            return default;
        }

        public async Task<TEntity> EnrichByDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_domain(self, domain, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_domain', {
            //     'domain': domain,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            return default;
        }

        public async Task<TEntity> EnrichByDunsAsync<TEntity>(IEnumerable<TEntity> entities, object duns, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_duns(self, duns, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_duns', {
            //     'duns': duns,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            return default;
        }

        public async Task<TEntity> EnrichByGstAsync<TEntity>(IEnumerable<TEntity> entities, object gst, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_by_gst(self, gst, timeout=15):
            // response, error = self.env['iap.autocomplete.api']._request_partner_autocomplete('enrich_by_gst', {
            //     'gst': gst,
            // }, timeout=timeout)
            // return self._process_enriched_response(response, error)
            */
            return default;
        }

        public async Task<TEntity> EnrichCompanyAsync<TEntity>(IEnumerable<TEntity> entities, object company_domain, object partner_gid, object vat, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def enrich_company(self, company_domain, partner_gid, vat, timeout=15):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> EnsureSameCompanyThanTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> EnsureVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def ensure_vat(self):
            // """ This method is a helper that returns the VAT number is this one is defined if not raise an UserError.
            // 
            // VAT is not mandatory field but for some Argentinean operations the VAT is required, for eg  validate an
            // electronic invoice, build a report, etc.
            // 
            // This method can be used to validate is the VAT is proper defined in the partner """
            // self.ensure_one()
            // if not self.l10n_ar_vat:
            //     raise UserError(_('No VAT configured for partner [%i] %s', self.id, self.name))
            // return self.l10n_ar_vat
            */
            return default;
        }

        public async Task<TEntity> EventViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: res_partner.py) ---
            // def action_event_view(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("event.action_event_view")
            // action['context'] = {}
            // action['domain'] = [('registration_ids.partner_id', 'child_of', self.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> FieldsGetAsync<TEntity>(IEnumerable<TEntity> entities, object allfields, object attributes) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // """ Hide first and last name field if the split name feature is not enabled. """
            // res = super().fields_get(allfields, attributes)
            // if not self._is_name_split_activated():
            //     if 'first_name' in res:
            //         res['first_name']['searchable'] = False
            //     if 'last_name' in res:
            //         res['last_name']['searchable'] = False
            // return res
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> FieldsViewGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type, object toolbar, object submenu) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> FindAccountingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _find_accounting_partner(self, partner):
            // ''' Find the partner for which the accounting entries will be created '''
            // return partner.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_only) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _find_matching_partner(self, email_only=False):
            // """ Try to find a matching partner with available information on the
            // lead, using notably customer's name, email, ...
            // 
            // :param email_only: Only find a matching based on the email. To use
            //     for automatic process where ilike based on name can be too dangerous
            // :return: partner browse record
            // """
            // self.ensure_one()
            // partner = self.partner_id
            // 
            // if not partner and self.email_from:
            //     partner = self.env['res.partner'].search([('email', '=', self.email_from)], limit=1)
            // 
            // if not partner and not email_only:
            //     # search through the existing partners based on the lead's partner or contact name
            //     # to be aligned with _create_customer, search on lead's name as last possibility
            //     for customer_potential_name in [self[field_name] for field_name in ['partner_name', 'contact_name', 'name'] if self[field_name]]:
            //         partner = self.env['res.partner'].search([('name', 'ilike', customer_potential_name)], limit=1)
            //         if partner:
            //             break
            // 
            // return partner
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object additional_values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> FixEuVatNumberAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> FixVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid country_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> FormatDataCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> FormatDottedVatClInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cl, FILE: res_partner.py) ---
            // def _format_dotted_vat_cl(self, vat):
            // vat_l = vat.split('-')
            // n_vat, n_dv = vat_l[0], vat_l[1]
            // return '%s-%s' % (format(int(n_vat), ',d').replace(',', '.'), n_dv)
            */
            return default;
        }

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _format_properties(self):
            // """Format the properties to build the merge message.
            // 
            // Return a list of dict containing the label, and a value key if there's only
            // one value, or a "values" key if we have multiple values (e.g. many2many, tags).
            // 
            // E.G.
            //     [{
            //         'label': 'My Partner',
            //         'value': 'Alice',
            //     }, {
            //         'label': 'My Partners',
            //         'values': [
            //             {'name': 'Alice'},
            //             {'name': 'Bob'},
            //         ],
            //     }, {
            //         'label': 'My Tags',
            //         'values': [
            //             {'name': 'A', 'color': 1},
            //             {'name': 'C', 'color': 3},
            //         ],
            //     }]
            // """
            // self.ensure_one()
            // # read to have the display names already in the value
            // properties = self.read(['lead_properties'])[0]['lead_properties']
            // 
            // formatted = []
            // for definition in properties:
            //     label = definition.get('string')
            //     value = definition.get('value')
            //     property_type = definition['type']
            //     if not value and property_type != 'boolean':
            //         continue
            // 
            //     property_dict = {'label': label}
            //     if property_type == 'boolean':
            //         property_dict['value'] = _('Yes') if value else _('No')
            //     elif value and property_type == 'many2one':
            //         property_dict['value'] = value[1]
            //     elif value and property_type == 'many2many':
            //         # show many2many in badge
            //         property_dict['values'] = [{'name': rec[1]} for rec in value]
            //     elif value and property_type in ['selection', 'tags']:
            //         # retrieve the option label from the value
            //         options = {
            //             option[0]: option[1:]
            //             for option in (definition.get(property_type) or [])
            //         }
            //         if property_type == 'selection':
            //             value = options.get(value)
            //             property_dict['value'] = value[0] if value else None
            //         else:
            //             property_dict['values'] = [{
            //                 'name': options[tag][0],
            //                 'color': options[tag][1],
            //                 } for tag in value if tag in options
            //             ]
            //     else:
            //         property_dict['value'] = value
            // 
            //     formatted.append(property_dict)
            // 
            // return formatted
            */
            return default;
        }

        public async Task<TEntity> FormatVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_ch(self, vat):
            // stdnum_vat_format = getattr(stdnum.util.get_cc_module('ch', 'vat'), 'format', None)
            // return stdnum_vat_format('CH' + vat)[2:] if stdnum_vat_format else vat
            */
            return default;
        }

        public async Task<TEntity> FormatVatClInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_cl, FILE: res_partner.py) ---
            // def _format_vat_cl(self, values):
            // identification_types = [self.env.ref('l10n_latam_base.it_vat').id, self.env.ref('l10n_cl.it_RUT').id,
            //                         self.env.ref('l10n_cl.it_RUN').id]
            // country = self.env["res.country"].browse(values.get('country_id'))
            // identification_type = self.env['l10n_latam.identification.type'].browse(
            //     values.get('l10n_latam_identification_type_id')
            // )
            // partner_country_is_chile = country.code == "CL" or identification_type.country_id.code == "CL"
            // if partner_country_is_chile and \
            //         values.get('l10n_latam_identification_type_id') in identification_types and values.get('vat') and\
            //         stdnum.util.get_cc_module('cl', 'vat').is_valid(values['vat']):
            //     return stdnum.util.get_cc_module('cl', 'vat').format(values['vat']).replace('.', '').replace(
            //         'CL', '').upper()
            // else:
            //     return values['vat']
            */
            return default;
        }

        public async Task<TEntity> FormatVatEuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_eu(self, vat):
            // # Foreign companies that trade with non-enterprises in the EU
            // # may have a VATIN starting with "EU" instead of a country code.
            // return vat
            */
            return default;
        }

        public async Task<TEntity> FormatVatSmAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def format_vat_sm(self, vat):
            // stdnum_vat_format = stdnum.util.get_cc_module('sm', 'vat').compact
            // return stdnum_vat_format('SM' + vat)[2:]
            */
            return default;
        }

        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pe, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return super()._formatting_address_fields() + ['l10n_pe_district_name']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        public async Task<TEntity> GelatoPrepareAddressPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GenerateSignupTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expiration) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GeoLocalizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GeoLocalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetAmountsAndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetAttendeeDetailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> meeting_ids) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_customer, FILE: res_partner.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('contacts.menu_contacts').id
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: contacts, FILE: res_partner.py) ---
            // def _get_backend_root_menu_ids(self):
            // return super()._get_backend_root_menu_ids() + [self.env.ref('contacts.menu_contacts').id]
            */
            return default;
        }

        public async Task<TEntity> GetCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_au, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // labels = super()._get_company_registry_labels()
            // labels['AU'] = _("ACN")
            // return labels
            --- ODOO METHOD SOURCE (MODULE: l10n_ma, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // labels = super()._get_company_registry_labels()
            // labels['MA'] = _("ICE")
            // return labels
            --- ODOO METHOD SOURCE (MODULE: l10n_nz, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // labels = super()._get_company_registry_labels()
            // labels['NZ'] = _("NZBN")
            // return labels
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetCurrentPersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_customer_information(self):
            // email_normalized_to_values = super()._get_customer_information()
            // Partner = self.env['res.partner']
            // 
            // for record in self.filtered('email_normalized'):
            //     values = email_normalized_to_values.setdefault(record.email_normalized, {})
            //     contact_name = record.contact_name or record.partner_name or parse_contact_from_email(record.email_from)[0] or record.email_from
            //     # Note that we don't attempt to create the parent company even if partner name is set
            //     values.update(record._prepare_customer_values(contact_name, is_company=False))
            //     values['company_name'] = record.partner_name
            //     if contact_name == record.partner_name:
            //         values['company_type'] = 'company'
            // return email_normalized_to_values
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_lead.py) ---
            // def _get_customer_information(self):
            // email_normalized_to_values = super()._get_customer_information()
            // 
            // for lead in self:
            //     email_key = lead.email_normalized or lead.email
            //     values = email_normalized_to_values.setdefault(email_key, {})
            //     values['lang'] = values.get('lang') or lead.lang_code
            //     values['name'] = values.get('name') or lead.customer_name or parse_contact_from_email(lead.email_from)[0] or lead.email_from
            //     values['mobile'] = values.get('mobile') or lead.mobile
            //     values['phone'] = values.get('phone') or lead.phone
            // return email_normalized_to_values
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        public async Task<TEntity> GetDuplicatedBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetEdiBuilderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_edi_format) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice_edi_format == 'pint_anz':
            //     return self.env['account.edi.xml.pint_anz']
            // return super()._get_edi_builder(invoice_edi_format)
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice_edi_format == 'oioubl_201':
            //     return self.env['account.edi.xml.oioubl_201']
            // return super()._get_edi_builder(invoice_edi_format)
            --- ODOO METHOD SOURCE (MODULE: l10n_jp_ubl_pint, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice_edi_format == 'pint_jp':
            //     return self.env['account.edi.xml.pint_jp']
            // return super()._get_edi_builder(invoice_edi_format)
            --- ODOO METHOD SOURCE (MODULE: l10n_my_ubl_pint, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice_edi_format == 'pint_my':
            //     return self.env['account.edi.xml.pint_my']
            // return super()._get_edi_builder(invoice_edi_format)
            --- ODOO METHOD SOURCE (MODULE: l10n_ro_edi, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_ubl_cii'
            // if invoice_edi_format == 'ciusro':
            //     return self.env['account.edi.xml.ubl_ro']
            // return super()._get_edi_builder(invoice_edi_format)
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice_edi_format == 'pint_sg':
            //     return self.env['account.edi.xml.pint_sg']
            // return super()._get_edi_builder(invoice_edi_format)
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera, FILE: res_partner.py) ---
            // def _get_edi_builder(self, invoice_edi_format):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice_edi_format == 'ubl_tr':
            //     return self.env['account.edi.xml.ubl.tr']
            // return super()._get_edi_builder(invoice_edi_format)
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _get_employee_create_vals(self):
            // self.ensure_one()
            // address_id = self.partner_id.address_get(['contact'])['contact']
            // address_sudo = self.env['res.partner'].sudo().browse(address_id)
            // return {
            //     'name': self.partner_name or self.partner_id.display_name,
            //     'work_contact_id': self.partner_id.id,
            //     'private_street': address_sudo.street,
            //     'private_street2': address_sudo.street2,
            //     'private_city': address_sudo.city,
            //     'private_state_id': address_sudo.state_id.id,
            //     'private_zip': address_sudo.zip,
            //     'private_country_id': address_sudo.country_id.id,
            //     'private_phone': address_sudo.phone,
            //     'private_email': address_sudo.email,
            //     'lang': address_sudo.lang,
            //     'address_id': self.company_id.partner_id.id,
            //     'candidate_id': self.ids,
            //     'phone': self.partner_phone
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEmployeesFromAttendeesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object everybody) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_empty_list_help(self, help_message):
            // """ This method returns the action helpers for the leads. If help is already provided
            //     on the action, the same is returned. Otherwise, we build the help message which
            //     contains the alias responsible for creating the lead (if available) and return it.
            // """
            // if not is_html_empty(help_message):
            //     return help_message
            // 
            // help_title, sub_title = "", ""
            // if self._context.get('default_type') == 'lead':
            //     help_title = _('Create a new lead')
            // else:
            //     help_title = _('Create an opportunity to start playing with your pipeline.')
            // alias_domain = [
            //     ('company_id', 'in', [self.env.company.id, False]),
            //     ('alias_id.alias_name', '!=', False),
            //     ('alias_id.alias_name', '!=', ''),
            //     ('alias_id.alias_model_id.model', '=', 'crm.lead'),
            // ]
            // # sort by use_leads, then by our membership of the team
            // alias_records = self.env['crm.team'].search(alias_domain).sorted(
            //     lambda r: (r.use_leads, self.env.user in r.member_ids), reverse=True
            // )
            // alias_record = alias_records[0] if alias_records else None
            // if alias_record and alias_record.alias_domain and alias_record.alias_name:
            //     sub_title = Markup(_('Use the <i>New</i> button, or send an email to %(email_link)s to test the email gateway.')) % {
            //         'email_link': Markup("<b><a href='mailto:%s'>%s</a></b>") % (alias_record.alias_email, alias_record.alias_email),
            //     }
            // return super().get_empty_list_help(
            //     f'<p class="o_view_nocontent_smiling_face">{help_title}</p><p class="oe_view_nocontent_alias">{sub_title}</p>'
            // )
            */
            return default;
        }

        public async Task<TEntity> GetFollowupOverdueQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object args, object overdue_only) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetFollowupTableHtmlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GetGravatarImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetIdNumberSanitizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def _get_id_number_sanitize(self):
            // """ Sanitize the identification number. Return the digits/integer value of the identification number
            // If not vat number defined return 0 """
            // self.ensure_one()
            // if not self.vat:
            //     return 0
            // if self.l10n_latam_identification_type_id.l10n_ar_afip_code in ['80', '86']:
            //     # Compact is the number clean up, remove all separators leave only digits
            //     res = int(stdnum.ar.cuit.compact(self.vat))
            // else:
            //     id_number = re.sub('[^0-9]', '', self.vat)
            //     res = int(id_number)
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Leads & Opportunities'),
            //     'template': '/crm/static/xls/crm_lead.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Mailing List Contacts'),
            //     'template': '/mass_mailing/static/xls/mailing_contact.xls'
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetLatestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_lead_duplicates(self, partner=None, email=None, include_lost=False):
            // """ Search for leads that seem duplicated based on partner / email.
            // 
            // :param partner : optional customer when searching duplicated
            // :param email: email (possibly formatted) to search
            // :param boolean include_lost: if True, search includes archived opportunities
            //   (still only active leads are considered). If False, search for active
            //   and not won leads and opportunities;
            // """
            // if not email and not partner:
            //     return self.env['crm.lead']
            // 
            // domain = []
            // for normalized_email in [tools.email_normalize(email) for email in tools.email_split(email)]:
            //     domain.append(('email_normalized', '=', normalized_email))
            // if partner:
            //     domain.append(('partner_id', '=', partner.id))
            // 
            // if not domain:
            //     return self.env['crm.lead']
            // 
            // domain = ['|'] * (len(domain) - 1) + domain
            // if include_lost:
            //     domain += ['|', ('type', '=', 'opportunity'), ('active', '=', True)]
            // else:
            //     domain += ['&', ('active', '=', True), '|', ('stage_id', '=', False), ('stage_id.is_won', '=', False)]
            // 
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetLoginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetMailMessageAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object operation, object model_name) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_access.py) ---
            // def _get_mail_message_access(self, res_ids, operation, model_name=None):
            // # customize message creation
            // if operation == "create":
            //     if any(record.is_locked for record in self.browse(res_ids)):
            //         raise exceptions.AccessError('Cannot post on locked records')
            //     else:
            //         return "read"
            // return super()._get_mail_message_access(res_ids, operation, model_name=model_name)
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetMentionSuggestionsFromChannelAsync<TEntity>(IEnumerable<TEntity> entities, Guid channel_id, object search, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GetNeedactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetOnLeaveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py) ---
            // def _get_on_leave_ids(self):
            // return self.env['res.users']._get_on_leave_ids(partner=True)
            */
            return default;
        }

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_opportunity_meeting_view_parameters(self):
            // """ Return the most relevant parameters for calendar view when viewing meetings linked to an opportunity.
            //     If there are any meetings that are not finished yet, only consider those meetings,
            //     since the user would prefer no to see past meetings. Otherwise, consider all meetings.
            //     Allday events datetimes are used without taking tz into account.
            //     -If there is no event, return week mode and false (The calendar will target 'now' by default)
            //     -If there is only one, return week mode and date of the start of the event.
            //     -If there are several events entirely on the same week, return week mode and start of first event.
            //     -Else, return month mode and the date of the start of first event as initial date. (If they are
            //     on the same month, this will display that month and therefore show all of them, which is expected)
            // 
            //     :return tuple(mode, initial_date)
            //         - mode: selected mode of the calendar view, 'week' or 'month'
            //         - initial_date: date of the start of the first relevant meeting. The calendar will target that date.
            // """
            // self.ensure_one()
            // meeting_results = self.env["calendar.event"].search_read([('opportunity_id', '=', self.id)], ['start', 'stop', 'allday'])
            // if not meeting_results:
            //     return "week", False
            // 
            // user_tz = self.env.user.tz or self.env.context.get('tz')
            // user_pytz = pytz.timezone(user_tz) if user_tz else pytz.utc
            // 
            // # meeting_dts will contain one tuple of datetimes per meeting : (Start, Stop)
            // # meetings_dts and now_dt are as per user time zone.
            // meeting_dts = []
            // now_dt = datetime.now().astimezone(user_pytz).replace(tzinfo=None)
            // 
            // # When creating an allday meeting, whatever the TZ, it will be stored the same e.g. 00.00.00->23.59.59 in utc or
            // # 08.00.00->18.00.00. Therefore we must not put it back in the user tz but take it raw.
            // for meeting in meeting_results:
            //     if meeting.get('allday'):
            //         meeting_dts.append((meeting.get('start'), meeting.get('stop')))
            //     else:
            //         meeting_dts.append((meeting.get('start').astimezone(user_pytz).replace(tzinfo=None),
            //                            meeting.get('stop').astimezone(user_pytz).replace(tzinfo=None)))
            // 
            // # If there are meetings that are still ongoing or to come, only take those.
            // unfinished_meeting_dts = [meeting_dt for meeting_dt in meeting_dts if meeting_dt[1] >= now_dt]
            // relevant_meeting_dts = unfinished_meeting_dts if unfinished_meeting_dts else meeting_dts
            // relevant_meeting_count = len(relevant_meeting_dts)
            // 
            // if relevant_meeting_count == 1:
            //     return "week", relevant_meeting_dts[0][0].date()
            // else:
            //     # Range of meetings
            //     earliest_start_dt = min(relevant_meeting_dt[0] for relevant_meeting_dt in relevant_meeting_dts)
            //     latest_stop_dt = max(relevant_meeting_dt[1] for relevant_meeting_dt in relevant_meeting_dts)
            // 
            //     # The week start day depends on language. We fetch the week_start of user's language. 1 is monday.
            //     lang_week_start = self.env["res.lang"].search_read([('code', '=', self.env.user.lang)], ['week_start'])
            //     # We substract one to make week_start_index range 0-6 instead of 1-7
            //     week_start_index = int(lang_week_start[0].get('week_start', '1')) - 1
            // 
            //     # We compute the weekday of earliest_start_dt according to week_start_index. earliest_start_dt_index will be 0 if we are on the
            //     # first day of the week and 6 on the last. weekday() returns 0 for monday and 6 for sunday. For instance, Tuesday in UK is the
            //     # third day of the week, so earliest_start_dt_index is 2, and remaining_days_in_week includes tuesday, so it will be 5.
            //     # The first term 7 is there to avoid negative left side on the modulo, improving readability.
            //     earliest_start_dt_weekday = (7 + earliest_start_dt.weekday() - week_start_index) % 7
            //     remaining_days_in_week = 7 - earliest_start_dt_weekday
            // 
            //     # We compute the start of the week following the one containing the start of the first meeting.
            //     next_week_start_date = earliest_start_dt.date() + timedelta(days=remaining_days_in_week)
            // 
            //     # Latest_stop_dt must be before the start of following week. Limit is therefore set at midnight of first day, included.
            //     meetings_in_same_week = latest_stop_dt <= datetime(next_week_start_date.year, next_week_start_date.month, next_week_start_date.day, 0, 0, 0)
            // 
            //     if meetings_in_same_week:
            //         return "week", earliest_start_dt.date()
            //     else:
            //         return "month", earliest_start_dt.date()
            */
            return default;
        }

        public async Task<TEntity> GetParticipantInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_email_update(self, force_void=True):
            // """Calculate if we should write the email on the related partner. When
            // the email of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of email update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void email value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.email_from) and self.email_from != self.partner_id.email:
            //     lead_email_normalized = tools.email_normalize(self.email_from) or self.email_from or False
            //     partner_email_normalized = tools.email_normalize(self.partner_id.email) or self.partner_id.email or False
            //     return lead_email_normalized != partner_email_normalized
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPartnerFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetPartnerLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_phone_update(self, force_void=True):
            // """Calculate if we should write the phone on the related partner. When
            // the phone of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of phone update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void phone value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.phone) and self.phone != self.partner_id.phone:
            //     lead_phone_formatted = self._phone_format(fname='phone') or self.phone or False
            //     partner_phone_formatted = self.partner_id._phone_format(fname='phone') or self.partner_id.phone or False
            //     return lead_phone_formatted != partner_phone_formatted
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_peppol_edi_format(self):
            // self.ensure_one()
            // return self.invoice_edi_format or self._get_suggested_peppol_edi_format()
            */
            return default;
        }

        public async Task<TEntity> GetPeppolFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_peppol_formats(self):
            // formats_info = self._get_ubl_cii_formats_info()
            // return [format_key for format_key, format_vals in formats_info.items() if format_vals.get('on_peppol')]
            */
            return default;
        }

        public async Task<TEntity> GetPeppolVerificationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object peppol_endpoint, object peppol_eas, object invoice_edi_format) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_rainbowman_message(self):
            // self.ensure_one()
            // if self.stage_id.is_won:
            //     return self._get_rainbowman_message()
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rainbowman_message(self):
            // if not self.user_id or not self.team_id:
            //     return False
            // if not self.expected_revenue:
            //     # Show rainbow man for the first won lead of a salesman, even if expected revenue is not set. It is not
            //     # very often that leads without revenues are marked won, so simply get count using ORM instead of query
            //     today = fields.Datetime.today()
            //     user_won_leads_count = self.search_count([
            //         ('type', '=', 'opportunity'),
            //         ('user_id', '=', self.user_id.id),
            //         ('probability', '=', 100),
            //         ('date_closed', '>=', date_utils.start_of(today, 'year')),
            //         ('date_closed', '<', date_utils.end_of(today, 'year')),
            //     ])
            //     if user_won_leads_count == 1:
            //         return _('Go, go, go! Congrats for your first deal.')
            //     return False
            // 
            // self.flush_model()  # flush fields to make sure DB is up to date
            // query = """
            //     SELECT
            //         SUM(CASE WHEN user_id = %(user_id)s THEN 1 ELSE 0 END) as total_won,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_7,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_7
            //     FROM crm_lead
            //     WHERE
            //         type = 'opportunity'
            //     AND
            //         active = True
            //     AND
            //         probability = 100
            //     AND
            //         DATE_TRUNC('year', date_closed) = DATE_TRUNC('year', CURRENT_DATE)
            //     AND
            //         (user_id = %(user_id)s OR team_id = %(team_id)s)
            // """
            // self.env.cr.execute(query, {'user_id': self.user_id.id,
            //                             'team_id': self.team_id.id})
            // query_result = self.env.cr.dictfetchone()
            // 
            // message = False
            // if query_result['total_won'] == 1:
            //     message = _('Go, go, go! Congrats for your first deal.')
            // elif query_result['max_team_30'] == self.expected_revenue:
            //     message = _('Boom! Team record for the past 30 days.')
            // elif query_result['max_team_7'] == self.expected_revenue:
            //     message = _('Yeah! Deal of the last 7 days for the team.')
            // elif query_result['max_user_30'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 30 days.')
            // elif query_result['max_user_7'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 7 days.')
            // return message
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderDomainCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def _get_sale_order_domain_count(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_period, object stop_period, object everybody, object merge) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetSignupUrlForActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object action, object view_type, Guid menu_id, Guid res_id, object model) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetSignupUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetSimilarCandidatesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _get_similar_candidates_domain(self):
            // """
            //     This method returns a domain for the applicants whitch match with the
            //     current candidate according to email_from, partner_phone.
            //     Thus, search on the domain will return the current candidate as well if any of
            //     the following fields are filled.
            // """
            // self.ensure_one()
            // if not self:
            //     return []
            // domain = [('id', 'in', self.ids)]
            // if self.email_normalized:
            //     domain = expression.OR([domain, [('email_normalized', '=', self.email_normalized)]])
            // if self.partner_phone_sanitized:
            //     domain = expression.OR([domain, [('partner_phone_sanitized', '=', self.partner_phone_sanitized)]])
            // domain = expression.AND([domain, [('company_id', '=', self.company_id.id)]])
            // return domain
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetSuggestedInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def _get_suggested_invoice_edi_format(self):
            // # TO OVERRIDE
            // self.ensure_one()
            // return False
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _get_suggested_invoice_edi_format(self):
            // # EXTENDS 'account'
            // res = super()._get_suggested_invoice_edi_format()
            // if self.country_code == 'IT':
            //     return 'it_edi_xml'
            // else:
            //     return res
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetSuggestedUblCiiEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetUblCiiFormatsByCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetUblCiiFormatsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['pint_anz'] = {'countries': ['AU', 'NZ'], 'on_peppol': True, 'sequence': 90}  # has priority over UBL_ANZ from 'account_edi_ubl_cii'
            // return formats_info
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['oioubl_201'] = {'countries': ['DK']}
            // return formats_info
            --- ODOO METHOD SOURCE (MODULE: l10n_jp_ubl_pint, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['pint_jp'] = {'countries': ['JP'], 'on_peppol': True}
            // return formats_info
            --- ODOO METHOD SOURCE (MODULE: l10n_my_ubl_pint, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['pint_my'] = {'countries': ['MY'], 'on_peppol': True}
            // return formats_info
            --- ODOO METHOD SOURCE (MODULE: l10n_ro_edi, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['ciusro'] = {'countries': ['RO']}
            // return formats_info
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['pint_sg'] = {'countries': ['SG'], 'on_peppol': True, 'sequence': 90}  # has priority over UBL_SG from 'account_edi_ubl_cii'
            // return formats_info
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats_info(self):
            // # EXTENDS 'account_edi_ubl_cii'
            // formats_info = super()._get_ubl_cii_formats_info()
            // formats_info['ubl_tr'] = {'countries': ['TR']}
            // return formats_info
            */
            return default;
        }

        public async Task<TEntity> GetUblCiiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _get_ubl_cii_formats(self):
            // return list(self._get_ubl_cii_formats_info().keys())
            */
            return default;
        }

        public async Task<TEntity> GetValidationModuleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def _get_validation_module(self):
            // self.ensure_one()
            // if self.l10n_latam_identification_type_id.l10n_ar_afip_code in ['80', '86']:
            //     return stdnum.ar.cuit
            // elif self.l10n_latam_identification_type_id.l10n_ar_afip_code == '96':
            //     return stdnum.ar.dni
            */
            return default;
        }

        public async Task<TEntity> GetVcardFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> GetWorkingHoursForAllAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids, object date_from, object date_to, object everybody) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GetWorklocationAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py) ---
            // def get_worklocation(self, start_date, end_date):
            // employee_id = self.env['hr.employee'].search([
            //     ('work_contact_id.id', 'in', self.ids),
            //     ('company_id.id', '=', self.env.company.id)])
            // return employee_id._get_worklocation(start_date, end_date)
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> GoogleMapSignedImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_partner_assignment(self, force_partner_id=False, create_missing=True):
            // """ Update customer (partner_id) of leads. Purpose is to set the same
            // partner on most leads; either through a newly created partner either
            // through a given partner_id.
            // 
            // :param int force_partner_id: if set, update all leads to that customer;
            // :param create_missing: for leads without customer, create a new one
            //   based on lead information;
            // """
            // for lead in self:
            //     if force_partner_id:
            //         lead.partner_id = force_partner_id
            //     if not lead.partner_id and create_missing:
            //         partner = lead._create_customer()
            //         lead.partner_id = partner.id
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_salesmen_assignment(self, user_ids=False, team_id=False):
            // """ Assign salesmen and salesteam to a batch of leads.  If there are more
            // leads than salesmen, these salesmen will be assigned in round-robin. E.g.
            // 4 salesmen (S1, S2, S3, S4) for 6 leads (L1, L2, ... L6) will assigned as
            // following: L1 - S1, L2 - S2, L3 - S3, L4 - S4, L5 - S1, L6 - S2.
            // 
            // :param list user_ids: salesmen to assign
            // :param int team_id: salesteam to assign
            // """
            // update_vals = {'team_id': team_id} if team_id else {}
            // if not user_ids and team_id:
            //     self.write(update_vals)
            // else:
            //     lead_ids = self.ids
            //     steps = len(user_ids)
            //     # pass 1 : lead_ids[0:6:3] = [L1,L4]
            //     # pass 2 : lead_ids[1:6:3] = [L2,L5]
            //     # pass 3 : lead_ids[2:6:3] = [L3,L6]
            //     # ...
            //     for idx in range(0, steps):
            //         subset_ids = lead_ids[idx:len(lead_ids):steps]
            //         update_vals['user_id'] = user_ids[idx]
            //         self.env['crm.lead'].browse(subset_ids).write(update_vals)
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_won_lost(self, vals):
            // """ This method handle the state changes :
            // - To lost : We need to increment corresponding lost count in scoring frequency table
            // - To won : We need to increment corresponding won count in scoring frequency table
            // - From lost to Won : We need to decrement corresponding lost count + increment corresponding won count
            // in scoring frequency table.
            // - From won to lost : We need to decrement corresponding won count + increment corresponding lost count
            // in scoring frequency table."""
            // Lead = self.env['crm.lead']
            // leads_reach_won = Lead
            // leads_leave_won = Lead
            // leads_reach_lost = Lead
            // leads_leave_lost = Lead
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead in self:
            //     if 'stage_id' in vals:
            //         if vals['stage_id'] in won_stage_ids:
            //             if lead.probability == 0:
            //                 leads_leave_lost += lead
            //             leads_reach_won += lead
            //         elif lead.stage_id.id in won_stage_ids and lead.active:  # a lead can be lost at won_stage
            //             leads_leave_won += lead
            //     if 'active' in vals:
            //         if not vals['active'] and lead.active:  # archive lead
            //             if lead.stage_id.id in won_stage_ids and lead not in leads_leave_won:
            //                 leads_leave_won += lead
            //             leads_reach_lost += lead
            //         elif vals['active'] and not lead.active:  # restore lead
            //             leads_leave_lost += lead
            // 
            // leads_reach_won._pls_increment_frequencies(to_state='won')
            // leads_leave_won._pls_increment_frequencies(from_state='won')
            // leads_reach_lost._pls_increment_frequencies(to_state='lost')
            // leads_leave_lost._pls_increment_frequencies(from_state='lost')
            */
            return default;
        }

        public async Task<TEntity> HasInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> HasOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> IapPartnerAutocompleteAddTagsAsync<TEntity>(IEnumerable<TEntity> entities, object unspsc_codes) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> IapReplaceLanguageCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> IapReplaceLocationCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> IeCheckCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ImSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object limit, List<Guid> excluded_ids) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ImportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def action_import(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing.mailing_contact_import_action")
            // context = self.env.context.copy()
            // action['context'] = context
            // if (not context.get('default_mailing_list_ids') and context.get('from_mailing_list_ids')):
            //     action['context'].update({
            //         'default_mailing_list_ids': context.get('from_mailing_list_ids'),
            //     })
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> IncreaseRankInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object n) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def init(self):
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS hr_candidate_email_partner_phone_mobile
            //     ON hr_candidate(email_normalized, partner_phone_sanitized);
            // """)
            */
            return default;
        }

        public async Task<TEntity> IntervalToBusinessHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities, object working_intervals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_email_from(self):
            // for lead in self:
            //     if lead._get_partner_email_update(force_void=False):
            //         lead.partner_id.email = lead.email_from
            */
            return default;
        }

        public async Task<TEntity> InverseInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> InversePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _inverse_partner_email(self):
            // for candidate in self:
            //     if not candidate.email_from:
            //         continue
            //     if not candidate.partner_id:
            //         if not candidate.partner_name:
            //             raise UserError(_('You must define a Contact Name for this candidate.'))
            //         candidate.partner_id = self.env['res.partner'].with_context(default_lang=self.env.lang).find_or_create(candidate.email_from)
            //     if candidate.partner_name and not candidate.partner_id.name:
            //         candidate.partner_id.name = candidate.partner_name
            //     if tools.email_normalize(candidate.email_from) != tools.email_normalize(candidate.partner_id.email):
            //         # change email on a partner will trigger other heavy code, so avoid to change the email when
            //         # it is the same. E.g. "email@example.com" vs "My Email" <email@example.com>""
            //         candidate.partner_id.email = candidate.email_from
            //     if candidate.partner_phone:
            //         candidate.partner_id.phone = candidate.partner_phone
            */
            return default;
        }

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_phone(self):
            // for lead in self:
            //     if lead._get_partner_phone_update(force_void=False):
            //         lead.partner_id.phone = lead.phone
            */
            return default;
        }

        public async Task<TEntity> InverseProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> InverseStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> InverseUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> InvoiceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> IsNameSplitActivatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def _is_name_split_activated(self):
            // """ Return whether the contact names are populated as first and last name or as a single field (name). """
            // view = self.env.ref("mass_mailing.mailing_contact_view_tree_split_name", raise_if_not_found=False)
            // return view and view.sudo().active
            */
            return default;
        }

        public async Task<TEntity> IsValidRucEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py) ---
            // def is_valid_ruc_ec(self, vat):
            // if len(vat) in (10, 13) and vat.isdecimal():
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> L10nArIdentificationValidationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar, FILE: res_partner.py) ---
            // def l10n_ar_identification_validation(self):
            // for rec in self.filtered('vat'):
            //     try:
            //         module = rec._get_validation_module()
            //     except Exception as error:
            //         module = False
            //         _logger.runbot("Argentinean document was not validated: %s", repr(error))
            // 
            //     if not module:
            //         continue
            //     try:
            //         module.validate(rec.vat)
            //     except module.InvalidChecksum:
            //         raise ValidationError(_('The validation digit is not valid for "%s"',
            //                                 rec.l10n_latam_identification_type_id.name))
            //     except module.InvalidLength:
            //         raise ValidationError(_('Invalid length for "%s"', rec.l10n_latam_identification_type_id.name))
            //     except module.InvalidFormat:
            //         raise ValidationError(_('Only numbers allowed for "%s"', rec.l10n_latam_identification_type_id.name))
            //     except module.InvalidComponent:
            //         valid_cuit = ('20', '23', '24', '27', '30', '33', '34', '50', '51', '55')
            //         raise ValidationError(_('CUIT number must be prefixed with one of the following: %s', ', '.join(valid_cuit)))
            //     except Exception as error:
            //         raise ValidationError(repr(error))
            */
            return default;
        }

        public async Task<TEntity> L10nEcGetIdentificationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ec, FILE: res_partner.py) ---
            // def _l10n_ec_get_identification_type(self):
            // """Maps Odoo identification types to Ecuadorian ones.
            // Useful for document type domains, electronic documents, ats, others.
            // """
            // self.ensure_one()
            // 
            // id_types_by_xmlid = {
            //     'l10n_ec.ec_dni': 'cedula',  # DNI
            //     'l10n_ec.ec_ruc': 'ruc',  # RUC
            //     'l10n_ec.ec_passport': 'ec_passport',  # EC passport
            //     'l10n_latam_base.it_pass': 'passport',  # Passport
            //     'l10n_latam_base.it_fid': 'foreign',  # Foreign ID
            //     'l10n_latam_base.it_vat': 'foreign',
            // }
            // 
            // # This method is orm-cached, which makes it more efficient in loops than get_external_id()
            // xmlid_by_res_id = {
            //     self.env['ir.model.data']._xmlid_to_res_model_res_id(xmlid, raise_if_not_found=True)[1]: xmlid
            //     for xmlid in id_types_by_xmlid
            // }
            // 
            // id_type_xmlid = xmlid_by_res_id.get(self.l10n_latam_identification_type_id.id)
            // if id_type_xmlid in id_types_by_xmlid:
            //     return id_types_by_xmlid[id_type_xmlid]
            // 
            // if self.l10n_latam_identification_type_id.country_id.code != 'EC':
            //     return 'foreign'
            */
            return default;
        }

        public async Task<TEntity> L10nEsIsForeignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es, FILE: res_partner.py) ---
            // def _l10n_es_is_foreign(self):
            // self.ensure_one()
            // 
            // return self.country_id.code not in ('ES', False) or (self.vat or '').startswith("ESN")
            */
            return default;
        }

        public async Task<TEntity> L10nInGetPartnerValsByVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def _l10n_in_get_partner_vals_by_vat(self, vat):
            // partner_data = self.enrich_by_gst(vat)
            // for fname in list(partner_data.keys()):
            //     if fname not in self.env['res.partner']._fields:
            //         partner_data.pop(fname, None)
            // partner_data.update({
            //     'country_id': partner_data.get('country_id', {}).get('id'),
            //     'state_id': partner_data.get('state_id', {}).get('id'),
            //     'company_type': 'company',
            //     'l10n_in_gst_treatment': 'regular',
            // })
            // return partner_data
            */
            return default;
        }

        public async Task<TEntity> L10nInVerifyGstinStatusAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in_gstin_status, FILE: res_partner.py) ---
            // def action_l10n_in_verify_gstin_status(self):
            // self.ensure_one()
            // self.check_access('write')
            // if self.env.company.sudo().account_fiscal_country_id.code != 'IN':
            //     raise UserError(_('You must be logged in an Indian company to use this feature'))
            // if not self.vat:
            //     raise ValidationError(_("Please enter the GSTIN"))
            // is_production = self.env.company.sudo().l10n_in_edi_production_env
            // params = {
            //     "gstin_to_search": self.vat,
            // }
            // try:
            //     response = self.env['iap.account']._l10n_in_connect_to_server(
            //         is_production,
            //         params,
            //         '/iap/l10n_in_reports/1/public/search',
            //         "l10n_in_gstin_status.endpoint"
            //     )
            // except AccessError:
            //     raise UserError(_("Unable to connect with GST network"))
            // if response.get('error') and any(e.get('code') == 'no-credit' for e in response['error']):
            //     return self.env["bus.bus"]._sendone(self.env.user.partner_id, "iap_notification",
            //         {
            //             "type": "no_credit",
            //             "title": _("Not enough credits to check GSTIN status"),
            //             "get_credits_url": self.env["iap.account"].get_credits_url(service_name=IAP_SERVICE_NAME),
            //         },
            //     )
            // gst_status = response.get('data', {}).get('sts', "")
            // if gst_status.casefold() == 'active':
            //     l10n_in_gstin_verified_status = True
            // elif gst_status:
            //     l10n_in_gstin_verified_status = False
            //     date_from = response.get("data", {}).get("cxdt", '')
            //     if date_from and re.search(r'\d', date_from):
            //         message = _(
            //             "GSTIN %(vat)s is %(status)s and Effective from %(date_from)s.",
            //             vat=self.vat,
            //             status=gst_status,
            //             date_from=date_from,
            //         )
            //     else:
            //         message = _(
            //             "GSTIN %(vat)s is %(status)s, effective date is not available.",
            //             vat=self.vat,
            //             status=gst_status
            //         )
            //     if not is_production:
            //         message += _(" Warning: You are currently in a test environment. The result is a dummy.")
            //     self.message_post(body=message)
            // else:
            //     _logger.info("GST status check error %s", response)
            //     if response.get('error') and any(e.get('code') == 'SWEB_9035' for e in response['error']):
            //         raise UserError(
            //             _("The provided GSTIN is invalid. Please check the GSTIN and try again.")
            //         )
            //     default_error_message = _(
            //         "Something went wrong while fetching the GST status."
            //         "Please Contact Support if the error persists with"
            //         "Response: %(response)s",
            //         response=response
            //     )
            //     error_messages = [
            //         f"[{error.get('code') or _('Unknown')}] {error.get('message') or default_error_message}"
            //         for error in response.get('error')
            //     ]
            //     raise UserError(
            //         error_messages
            //         and '\n'.join(error_messages)
            //         or default_error_message
            //     )
            // self.write({
            //     "l10n_in_gstin_verified_status": l10n_in_gstin_verified_status,
            //     "l10n_in_gstin_verified_date": fields.Date.today(),
            // })
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "display_notification",
            //     "params": {
            //         "type": "info",
            //         "message": _("GSTIN Status Updated Successfully"),
            //         "next": {"type": "ir.actions.act_window_close"},
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> L10nItEdiDoiOpenDeclarationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi_doi, FILE: res_partner.py) ---
            // def l10n_it_edi_doi_action_open_declarations(self):
            // self.ensure_one()
            // return {
            //     'name': _("Declaration of Intent of %s", self.display_name),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'l10n_it_edi_doi.declaration_of_intent',
            //     'domain': [('partner_id', '=', self.commercial_partner_id.id)],
            //     'views': [(self.env.ref('l10n_it_edi_doi.view_l10n_it_edi_doi_tree').id, 'list'),
            //               (self.env.ref('l10n_it_edi_doi.view_l10n_it_edi_doi_form').id, 'form')],
            //     'context': {
            //         'default_partner_id': self.id,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> L10nItEdiExportCheckInternalAsync<TEntity>(IEnumerable<TEntity> entities, object checks) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _l10n_it_edi_export_check(self, checks=None):
            // checks = checks or ['partner_vat_codice_fiscale_missing', 'partner_address_missing']
            // fields_to_check = {
            //     'partner_vat_missing': {
            //         'fields': [('vat',)],
            //         'message': _("Partner(s) should have a VAT number."),
            //     },
            //     'partner_vat_codice_fiscale_missing': {
            //         'fields': [('vat', 'l10n_it_codice_fiscale')],
            //         'message': _("Partner(s) should have a VAT number or Codice Fiscale."),
            //     },
            //     'partner_country_missing': {
            //         'fields': [('country_id',)],
            //         'message': _("Partner(s) should have a Country when used for simplified invoices."),
            //     },
            //     'partner_address_missing': {
            //         'fields': [('street', 'street2'), ('zip',), ('city',), ('country_id',)],
            //         'message': _("Partner(s) should have a complete address, verify their Street, City, Zipcode and Country."),
            //     },
            // }
            // selected_checks = {k: v for k, v in fields_to_check.items() if k in checks}
            // single_views = [(False, 'form')]
            // list_view = (self.env.ref('l10n_it_edi.res_partner_tree_l10n_it', raise_if_not_found=False))
            // multi_views = [(list_view.id if list_view else False, 'list'), (False, 'form')]
            // errors = {}
            // for key, check in selected_checks.items():
            //     for fields_tuple in check['fields']:
            //         if invalid_records := self.filtered(lambda record: not any(record[field] for field in fields_tuple)):
            //             views = single_views if len(invalid_records) == 1 else multi_views
            //             errors[f"l10n_it_edi_{key}"] = {
            //                 'message': check['message'],
            //                 'action_text': _("View Partner(s)"),
            //                 'action': invalid_records._get_records_action(name=_("Check Partner(s)"), views=views),
            //             }
            // return errors
            */
            return default;
        }

        public async Task<TEntity> L10nItEdiGetValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _l10n_it_edi_get_values(self):
            // """ Generates all partner values needed by l10n_it_edi XML export.
            // 
            //     VAT number:
            //     If there is a VAT number and the partner is not in EU, then we use the VAT number as is,
            //         as an alphanumeric value identifying the counterparty, up to a maximum of
            //         28 alphanumeric characters, on which the SdI does not perform validity checks.
            //     If there is a VAT number and the partner is in EU, then remove the country prefix
            //     If there is no VAT and the partner is not in EU, then the exported value is 'OO99999999999'
            //     If there is no VAT and the partner is in EU, then the exported value is '0000000'
            //     If there is no VAT and the partner is in Italy, the VAT is not set and Codice Fiscale will be relevant in the XML.
            //     If there is no VAT and no Codice Fiscale, the invoice is not even exported, so this case is not handled.
            // 
            //     Country:
            //     First, try and deduct the country from the VAT number.
            //     If not, take the country directly from the partner.
            //     If there's a codice fiscale, the country is 'IT'.
            // 
            //     PA Index:
            //     If the partner is in Italy, then the l10n_it_pa_index is used, and '0000000' if missing.
            //     If the partner is not in Italy, the default 'XXXXXXX' is used.
            // 
            //     Codice Fiscale:
            //     If the Tax Code is equal to the Italian VAT, it may mistakenly have the country prefix,
            //     so we try and remove it if we can
            // 
            //     Zip(code):
            //     Non-italian countries are not mapped by the Tax Agency, so it's fixed at '00000'
            // """
            // if not self or len(self) > 1:
            //     return {}
            // 
            // europe = self.env.ref('base.europe', raise_if_not_found=False)
            // in_eu = not europe or not self.country_id or self.country_id in europe.country_ids
            // is_sm = self.country_id and self.country_id.code == "SM"
            // 
            // # VAT number and country code
            // normalized_vat = self.vat
            // normalized_country = self.country_code
            // if has_vat := self.vat not in [False, '/', 'NA']:
            //     normalized_vat = self.vat.replace(' ', '')
            //     if in_eu:
            //         # If there is no country-code prefix, it's domestic to Italy
            //         if normalized_vat[:2].isdecimal():
            //             if not normalized_country:
            //                 normalized_country = 'IT'
            //         # If the partner is from the EU, the country-code prefix of the VAT must be taken away
            //         else:
            //             if not normalized_country:
            //                 normalized_country = normalized_vat[:2].upper()
            //             normalized_vat = normalized_vat[2:]
            //     # If customer is from San Marino
            //     elif is_sm:
            //         normalized_vat = normalized_vat if normalized_vat[:2].isdecimal() else normalized_vat[2:]
            // 
            // # If it has a codice fiscale (and no country), it's an Italian partner
            // if not normalized_country and self.l10n_it_codice_fiscale:
            //     normalized_country = 'IT'
            // elif not has_vat and self.country_id and self.country_id.code != 'IT':
            //     if in_eu:
            //         normalized_vat = '0000000'
            //     else:
            //         normalized_vat = 'OO99999999999'
            // 
            // if normalized_country == 'IT':
            //     pa_index = (self.l10n_it_pa_index or '0000000').upper()
            //     zipcode = self.zip
            //     state_code = self.state_id and self.state_id.code
            // else:
            //     # San Marino is externally integrated with the SdI.
            //     # The country as a whole has a single fixed Destination Code.
            //     # https://www.agenziaentrate.gov.it/portale/documents/20143/3788702/Modifiche+ProvvedimentonSanMarino+0248717-2021.pdf/429b5571-17b9-0cce-7f62-f79cf53086d7
            //     pa_index = '2R4GTO8' if is_sm else 'XXXXXXX'
            //     zipcode = '00000'
            //     state_code = False
            // 
            // return {
            //     'codice_fiscale': self._l10n_it_edi_normalized_codice_fiscale(),
            //     'vat': normalized_vat,
            //     'country_code': normalized_country,
            //     'state_code': state_code,
            //     'pa_index': pa_index,
            //     'zip': zipcode,
            //     'in_eu': in_eu,
            //     'is_company': self.is_company,
            //     'first_name': ' '.join(self.name.split()[:1]),
            //     'last_name': ' '.join(self.name.split()[1:]),
            // }
            */
            return default;
        }

        public async Task<TEntity> L10nItEdiIsPublicAdministrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _l10n_it_edi_is_public_administration(self):
            // """ Returns True if the destination of the FatturaPA belongs to the Public Administration. """
            // self.ensure_one()
            // return self.country_id.code == 'IT' and len(self.l10n_it_pa_index or '') == 6
            */
            return default;
        }

        public async Task<TEntity> L10nItEdiNormalizedCodiceFiscaleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object l10n_it_codice_fiscale) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _l10n_it_edi_normalized_codice_fiscale(self, l10n_it_codice_fiscale=None):
            // """ Normalize the Italian Tax Code for export.
            //     If the Tax Code is equal to the Italian VAT, it may mistakenly have the country prefix,
            //     so we try and remove it if we can
            // """
            // if l10n_it_codice_fiscale is None:
            //     self.ensure_one()
            //     l10n_it_codice_fiscale = self.l10n_it_codice_fiscale
            // if l10n_it_codice_fiscale:
            //     if codicefiscale._code_re.match(l10n_it_codice_fiscale):
            //         # Personal codice
            //         return codicefiscale.compact(l10n_it_codice_fiscale)
            //     # Company codice
            //     return iva.compact(l10n_it_codice_fiscale)
            */
            return default;
        }

        public async Task<TEntity> L10nItOnchangeVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _l10n_it_onchange_vat(self):
            // if self.vat and (
            //     self.country_code == "IT"
            //     if self.country_code
            //     else self.vat.startswith("IT")
            // ):
            //     self.l10n_it_codice_fiscale = self._l10n_it_edi_normalized_codice_fiscale(self.vat)
            // else:
            //     self.l10n_it_codice_fiscale = False
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetTinForMyinvoisInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: res_partner.py) ---
            // def _l10n_my_edi_get_tin_for_myinvois(self):
            // """ Helper to return the VAT number relevant to the situation. """
            // self.ensure_one()
            // return self.vat
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: res_partner.py) ---
            // def _l10n_my_edi_get_tin_for_myinvois(self):
            // # EXTEND 'l10n_my_edi'
            // # When l10n_my_edi_malaysian_tin is set, it will be used instead of the VAT.
            // # A user may want to keep the correct VAT on a foreign contact while also use myinvois with a malaysia TIN/Generic TIN
            // # Using the Tax ID field also causes issue when base_vat is enabled, which block setting foreign VAT numbers.
            // return self.l10n_my_edi_malaysian_tin or super()._l10n_my_edi_get_tin_for_myinvois()
            */
            return default;
        }

        public async Task<TEntity> L10nTrNilveraValidatePartnerDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_delivery_partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_edispatch, FILE: res_partner.py) ---
            // def _l10n_tr_nilvera_validate_partner_details(self, is_delivery_partner=False):
            // error_messages = {}
            // 
            // for record in self:
            //     country_code = record.country_id.code
            //     msg = []
            //     required_fields = {
            //         _("Street"): record.street,
            //         _("City"): record.city,
            //         _("State"): record.state_id,
            //         _("Country"): record.country_id,
            //     }
            // 
            //     missing_fields = [name for name, value in required_fields.items() if not value]
            //     if country_code == 'TR' and not record.vat:
            //         missing_fields.append(_("TCKN/VKN"))
            // 
            //     if (country_code == 'TR' or is_delivery_partner) and not record.zip:
            //         missing_fields.append(_("ZIP"))
            // 
            //     if missing_fields:
            //         msg.append(_("%s is required", ', '.join(missing_fields)))
            // 
            //     if country_code != "TR" and (
            //         not record.l10n_tr_nilvera_edispatch_customs_zip
            //         or len(record.l10n_tr_nilvera_edispatch_customs_zip) != 5
            //     ):
            //         msg.append(_("Customs ZIP of 5 characters must be present"))
            // 
            //     if msg:
            //         error_messages[f"invalid_{record.name.replace(' ', '_')}"] = {
            //             'message': _("%(name)s's %(message)s.", name=record.name, message=', '.join(msg)),
            //             'action_text': _("View %s", record.name),
            //             'action': record._get_records_action(name=_("View Partner"))
            //         }
            // return error_messages
            */
            return default;
        }

        public async Task<TEntity> L10nUyBuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: res_partner.py) ---
            // def _l10n_uy_build_vat_error_message(self, partner):
            // """ Similar to _build_vat_error_message but using latam doc type name instead of vat_label
            // NOTE: maybe can be implemented in master to l10n_latam_base for the use of different doc types """
            // vat_label = _("CI/NIE")
            // expected_format = _("3:402.010-2 or 93:402.010-1 (CI or NIE)")
            // 
            // # Catch use case where the record label is about the public user (name: False)
            // if partner.name:
            //     msg = "\n" + _(
            //         "The %(vat_label)s number [%(wrong_vat)s] for %(partner_label)s does not seem to be valid."
            //         "\nNote: the expected format is %(expected_format)s",
            //         vat_label=vat_label,
            //         wrong_vat=partner.vat,
            //         partner_label=_("partner [%s]", partner.name),
            //         expected_format=expected_format,
            //     )
            // else:
            //     msg = "\n" + _(
            //         "The %(vat_label)s number [%(wrong_vat)s] does not seem to be valid."
            //         "\nNote: the expected format is %(expected_format)s",
            //         vat_label=vat_label,
            //         wrong_vat=partner.vat,
            //         expected_format=expected_format,
            //     )
            // return msg
            */
            return default;
        }

        public async Task<TEntity> L10nUyCiNieIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_uy, FILE: res_partner.py) ---
            // def _l10n_uy_ci_nie_is_valid(self):
            // """ Check if the partner's CI or NIE number is a valid one.
            // 
            // CI:
            //     1) The ID number is taken up to the second to last position, that is, the first 6 or 7 digits.
            //     2) Each digit is multiplied by a different factor starting from right to left, the factors are:
            //         2, 9, 8, 7, 6, 3, 4.
            //     3) The products obtained are added:
            //     4) The base module 10 is calculated on this result to obtain the check digit, expressed in another way,
            //     the next number ending in zero is taken that follows the result of the addition (for the example
            //     would be 60) subtracting the sum itself: 60 - 59 = 1. The verification digit of the example ID is 1.
            // 
            //     NOTE: If the ID has fewer digits, it is preceded with zeros and the mechanism described above is applied
            // 
            // NIE:
            //     The calculation for the NIE is the same as that used for the CI. The only difference is that we skip the
            //     first number
            // 
            // Both algorithms where extracted from Uruware's Technical Manual (section 9.2 and 9.3)
            // 
            // Return: False is not valid, True is valid
            // """
            // self.ensure_one()
            // 
            // # The VAT must consist only numbers (format could have these characters ":., " we can skip them later)
            // invalid_chars = re.findall(r"[^0-9:., \-]", self.vat)
            // if invalid_chars:
            //     return False
            // 
            // ci_nie_number = re.sub("[^0-9]", "", self.vat)
            // 
            // # we get the validation digit, if NIE doc type we skip the first digit
            // is_nie = self.l10n_latam_identification_type_id.l10n_uy_dgi_code == "1"
            // verif_digit = int(ci_nie_number[-1])
            // ci_nie_number = ci_nie_number[1:-1] if is_nie else ci_nie_number[0:-1]
            // 
            // # If number is < 7 digits we add 0 to the left
            // ci_nie_number = "%07d" % int(ci_nie_number)
            // 
            // # If NIE > 7 digits is not valid
            // if len(ci_nie_number) > 7:
            //     return False
            // 
            // verification_vector = (2, 9, 8, 7, 6, 3, 4)
            // num_sum = sum(int(ci_nie_number[i]) * verification_vector[i] for i in range(7))
            // 
            // res = -num_sum % 10
            // return res == verif_digit
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ar_pos, FILE: res_partner.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // if self.env.company.country_id.code == 'AR':
            //     params += ['l10n_ar_afip_responsibility_type_id', 'l10n_latam_identification_type_id']
            // return params
            --- ODOO METHOD SOURCE (MODULE: l10n_pe_pos, FILE: res_partner.py) ---
            // def _load_pos_data_fields(self, config_id):
            // fields = super()._load_pos_data_fields(config_id)
            // if self.env.company.country_id.code == "PE":
            //     fields += ["city_id", "l10n_latam_identification_type_id", "l10n_pe_district"]
            // return fields
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

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def log_meeting(self, meeting):
            // """ Log the meeting info with a link to it in the chatter
            // :param record meeting: the meeting we want to log
            // """
            // if not meeting.duration:
            //     duration = _('unknown')
            // else:
            //     duration = self.env['ir.qweb.field.duration'].value_to_html(meeting.duration, {'unit': 'hour'})
            // meeting_usertime = fields.Datetime.to_string(fields.Datetime.context_timestamp(self, meeting.start))
            // meeting_time = Markup("<time datetime='%(meeting_start)s+00:00'>%(meeting_user_time)s</time>") % {
            //     'meeting_start': meeting.start,
            //     'meeting_user_time': meeting_usertime,
            // }
            // message = Markup("<p>%(meeting)s<br/>%(subject_string)s %(subject_link)s<br/>%(duration)s<p>") % {
            //     'meeting': _("Meeting scheduled at %s", meeting_time),
            //     'subject_string': _("Subject: "),
            //     'subject_link': meeting._get_html_link(),
            //     'duration': _("Duration: %s", duration),
            // }
            // return self.message_post(body=message)
            */
            return default;
        }

        public async Task<TEntity> LogVerificationStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object old_value, object new_value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> MailBlacklistRemoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def mail_action_blacklist_remove(self):
            // # wizard access rights currently not working as expected and allows users without access to
            // # open this wizard, therefore we check to make sure they have access before the wizard opens.
            // can_access = self.env['mail.blacklist'].has_access('write')
            // if can_access:
            //     return {
            //         'name': _('Are you sure you want to unblacklist this Email Address?'),
            //         'type': 'ir.actions.act_window',
            //         'view_mode': 'form',
            //         'res_model': 'mail.blacklist.remove',
            //         'target': 'new',
            //     }
            // else:
            //     raise AccessError(_("You do not have the access right to unblacklist emails. Please contact your administrator."))
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_access.py) ---
            // def _mail_get_partner_fields(self):
            // return ['customer_id']
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_access.py) ---
            // def _mail_get_partner_fields(self):
            // return ['customer_id']
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['customer_id']
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['customer_id']
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _mail_get_partners(self, introspect_fields=False):
            // return dict((partner.id, partner) for partner in self)
            */
            return default;
        }

        public async Task<TEntity> MailingGetOptOutListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mass_mailing, FILE: mailing_models.py) ---
            // def _mailing_get_opt_out_list(self, mailing):
            // res_ids = mailing._get_recipients()
            // opt_out_contacts = set(self.search([
            //     ('id', 'in', res_ids),
            //     ('opt_out', '=', True)
            // ]).mapped('email_normalized'))
            // return opt_out_contacts
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_data(self, fnames=None):
            // """ Prepare lead/opp data into a dictionary for merging. Different types
            //     of fields are processed in different ways:
            //         - text: all the values are concatenated
            //         - m2m and o2m: those fields aren't processed
            //         - m2o: the first not null value prevails (the other are dropped)
            //         - any other type of field: same as m2o
            // 
            //     :param fields: list of fields to process
            //     :return dict data: contains the merged values of the new opportunity
            // """
            // if fnames is None:
            //     fnames = self._merge_get_fields()
            // fcallables = self._merge_get_fields_specific()
            // address_values = self._merge_get_fields_address()
            // 
            // # helpers
            // def _get_first_not_null(attr, opportunities):
            //     value = False
            //     for opp in opportunities:
            //         if opp[attr]:
            //             value = opp[attr].id if isinstance(opp[attr], models.BaseModel) else opp[attr]
            //             break
            //     return value
            // 
            // # process the field's values
            // data = {}
            // for field_name in fnames:
            //     field = self._fields.get(field_name)
            //     if field is None:
            //         continue
            // 
            //     fcallable = fcallables.get(field_name)
            //     if fcallable and callable(fcallable):
            //         data[field_name] = fcallable(field_name, self)
            //     elif field_name in address_values:
            //         data[field_name] = address_values[field_name]
            //     elif not fcallable and field.type in ('many2many', 'one2many'):
            //         continue
            //     else:
            //         data[field_name] = _get_first_not_null(field_name, self)  # take the first not null
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_attachments(self, opportunities):
            // """ Move attachments of given opportunities to the current one `self`, and rename
            //     the attachments having same name than native ones.
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // 
            // all_attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', opportunities.ids)
            // ])
            // 
            // for opportunity in opportunities:
            //     attachments = all_attachments.filtered(lambda attach: attach.res_id == opportunity.id)
            //     for attachment in attachments:
            //         attachment.write({
            //             'res_id': self.id,
            //             'name': _("%(attach_name)s (from %(lead_name)s)",
            //                       attach_name=attachment.name,
            //                       lead_name=opportunity.name[:20]
            //                      )
            //         })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_calendar_events(self, opportunities):
            // """ Move calender.event from the given opportunities to the current one. `self` is the
            //     crm.lead record destination for event of `opportunities`.
            // :param opportunities: see ``merge_dependences``
            // """
            // self.ensure_one()
            // meetings = self.env['calendar.event'].search([('opportunity_id', 'in', opportunities.ids)])
            // return meetings.write({
            //     'res_id': self.id,
            //     'opportunity_id': self.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_history(self, opportunities):
            // """ Move history from the given opportunities to the current one. `self`
            // is the crm.lead record destination for message of `opportunities`.
            // 
            // This method moves
            //   * messages
            //   * activities
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // # sudo usage: because we want to go through all messages, whatever the real ACLs
            // # current user has on them
            // for opportunity_su in opportunities.sudo():
            //     for message_su in opportunity_su.message_ids:
            //         if message_su.subject:
            //             subject = _("From %(source_name)s: %(source_subject)s", source_name=opportunity_su.name, source_subject=message_su.subject)
            //         else:
            //             subject = _("From %(source_name)s", source_name=opportunity_su.name)
            //         message_su.write({
            //             'res_id': self.id,
            //             'subject': subject,
            //         })
            // opportunities.activity_ids.write({
            //     'res_id': self.id,
            // })
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences(self, opportunities):
            // """ Merge dependences (messages, attachments,activities, calendar events,
            // ...). These dependences will be transfered to `self` considered as the
            // master lead.
            // 
            // :param opportunities : recordset of opportunities to transfer. Does not
            //   include `self` which is the target crm.lead being the result of the
            //   merge;
            // """
            // self.ensure_one()
            // self._merge_dependences_history(opportunities)
            // self._merge_dependences_attachments(opportunities)
            // self._merge_dependences_calendar_events(opportunities)
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_followers(self, opportunities):
            // """Add the followers into the destination lead if they post a message in the last 30 days.
            // 
            // :param opportunities : Record<crm.lead> of opportunities to transfer
            // :return: {old_lead_id: Record<mail.followers>} Followers which have been added in
            //     the destination lead grouped by source lead ID.
            // """
            // self.ensure_one()
            // 
            // self.env['mail.message'].flush_model()
            // self.env['mail.followers'].flush_model()
            // 
            // # Get the active followers (followers whose partner post a message on the
            // # leads in the last 30 days) which should be moved on the destination lead
            // self.env.cr.execute(
            //     '''
            //     SELECT MAX(mf.id) AS id
            //       FROM mail_followers AS mf
            //       JOIN mail_message AS mm
            //         ON mm.author_id = mf.partner_id
            //        AND mm.res_id = mf.res_id
            //        AND mm.model = 'crm.lead'
            //        AND mm.date > NOW() - INTERVAL '30 DAY'
            //            /* Check if the partner is already
            //               following the destination lead */
            //  LEFT JOIN mail_followers AS destf
            //         ON destf.res_model = 'crm.lead'
            //        AND destf.res_id = %(lead_id)s
            //        AND destf.partner_id = mf.partner_id
            //            /* Select only once each partner
            //               to not create duplicated followers */
            //      WHERE mf.res_model = 'crm.lead'
            //        AND mf.res_id IN %(lead_ids)s
            //        AND destf IS NULL
            //   GROUP BY mf.partner_id
            //     ''',
            //     {'lead_ids': tuple(opportunities.ids), 'lead_id': self.id},
            // )
            // followers_to_update = [r[0] for r in self.env.cr.fetchall()]
            // followers_to_update = self.env['mail.followers'].browse(followers_to_update).sudo()
            // followers_by_old_lead = dict(groupby(followers_to_update, lambda f: f.res_id))
            // followers_to_update.write({'res_id': self.id})
            // return followers_by_old_lead
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_address(self):
            // """The address fields are propagated as a whole.
            // 
            // The address is taken from the lead with the most non-empty address field
            // (sorted by highest rank if multiple lead have the same amount of non-empty
            // fields).
            // """
            // source_lead = max(self, key=lambda lead: len(list(
            //     lead[field] for field in PARTNER_ADDRESS_FIELDS_TO_SYNC
            //     if lead[field]
            // )))
            // return {fname: source_lead[fname] for fname in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return (
            //     CRM_LEAD_FIELDS_TO_MERGE
            //     + list(self._merge_get_fields_specific().keys())
            //     + PARTNER_ADDRESS_FIELDS_TO_SYNC
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // return {
            //     'description': lambda fname, leads: '<br/><br/>'.join(desc for desc in leads.mapped('description') if not is_html_empty(desc)),
            //     'type': lambda fname, leads: 'opportunity' if any(lead.type == 'opportunity' for lead in leads) else 'lead',
            //     'priority': lambda fname, leads: max(priorities) if (priorities := leads.filtered('priority').mapped('priority')) else False,
            //     'tag_ids': lambda fname, leads: leads.mapped('tag_ids'),
            //     'lost_reason_id': lambda fname, leads:
            //         False if leads and leads[0].probability
            //         else next((lead.lost_reason_id for lead in leads if lead.lost_reason_id), False),
            // }
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_log_summary(self, merged_followers, opportunities_tail):
            // """Log the merge message on the lead."""
            // self.ensure_one()
            // self.message_post_with_source(
            //     "crm.crm_lead_merge_summary",
            //     render_values={
            //         "merged_followers": merged_followers,
            //         "opportunities": opportunities_tail,
            //         "is_html_empty": is_html_empty,
            //     },
            //     subtype_xmlid='mail.mt_note',
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True):
            // """ Merge opportunities in one. Different cases of merge:
            //         - merge leads together = 1 new lead
            //         - merge at least 1 opp with anything else (lead or opp) = 1 new opp
            //     The resulting lead/opportunity will be the most important one (based on its confidence level)
            //     updated with values from other opportunities to merge.
            // 
            // :param user_id : the id of the saleperson. If not given, will be determined by `_merge_data`.
            // :param team : the id of the Sales Team. If not given, will be determined by `_merge_data`.
            // 
            // :return crm.lead record resulting of th merge
            // """
            // return self._merge_opportunity(user_id=user_id, team_id=team_id, auto_unlink=auto_unlink)
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True, max_length=5):
            // """ Private merging method. This one allows to relax rules on record set
            // length allowing to merge more than 5 opportunities at once if requested.
            // This should not be called by action buttons.
            // 
            // See ``merge_opportunity`` for more details. """
            // if len(self.ids) <= 1:
            //     raise UserError(_('Select at least two Leads/Opportunities from the list to merge them.'))
            // 
            // if max_length and len(self.ids) > max_length and not self.env.is_superuser():
            //     raise UserError(_("To prevent data loss, Leads and Opportunities can only be merged by groups of %(max_length)s.", max_length=max_length))
            // 
            // opportunities = self._sort_by_confidence_level(reverse=True)
            // 
            // # get SORTED recordset of head and tail, and complete list
            // opportunities_head = opportunities[0]
            // opportunities_tail = opportunities[1:]
            // 
            // # merge all the sorted opportunity. This means the value of
            // # the first (head opp) will be a priority.
            // merged_data = opportunities._merge_data(self._merge_get_fields())
            // 
            // # force value for saleperson and Sales Team
            // if user_id:
            //     merged_data['user_id'] = user_id
            // if team_id:
            //     merged_data['team_id'] = team_id
            // 
            // merged_followers = opportunities_head._merge_followers(opportunities_tail)
            // 
            // # log merge message
            // opportunities_head._merge_log_summary(merged_followers, opportunities_tail)
            // # merge other data (mail.message, attachments, ...) from tail into head
            // opportunities_head._merge_dependences(opportunities_tail)
            // 
            // # check if the stage is in the stages of the Sales Team. If not, assign the stage with the lowest sequence
            // if merged_data.get('team_id'):
            //     team_stage_ids = self.env['crm.stage'].search(['|', ('team_id', '=', merged_data['team_id']), ('team_id', '=', False)], order='sequence, id')
            //     if merged_data.get('stage_id') not in team_stage_ids.ids:
            //         merged_data['stage_id'] = team_stage_ids[0].id if team_stage_ids else False
            // 
            // # write merged data into first opportunity; remove some keys if already
            // # set on opp to avoid useless recomputes
            // if 'user_id' in merged_data and opportunities_head.user_id.id == merged_data['user_id']:
            //     merged_data.pop('user_id')
            // if 'team_id' in merged_data and opportunities_head.team_id.id == merged_data['team_id']:
            //     merged_data.pop('team_id')
            // opportunities_head.write(merged_data)
            // 
            // # delete tail opportunities
            // # we use the SUPERUSER to avoid access rights issues because as the user had the rights to see the records it should be safe to do so
            // if auto_unlink:
            //     opportunities_tail.sudo().unlink()
            // 
            // return opportunities_head
            */
            return default;
        }

        public async Task<TEntity> MessageComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _message_compute_subject(self):
            // self.ensure_one()
            // return f"Ticket for {self.name} on {self.datetime.strftime('%m/%d/%Y, %H:%M:%S')}"
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(r.email_from)) or r.email_from,
            //         'email_cc': False,
            //     } for r in self
            // }
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
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(r.email)) or r.email,
            //         'email_cc': False,
            //     } for r in self
            // }
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _message_get_default_recipients(self):
            // return dict(
            //     (record.id, {
            //         'email_cc': False,
            //         'email_to': record.email_from if not record.customer_id.ids else False,
            //         'partner_ids': record.customer_id.ids,
            //     })
            //     for record in self
            // )
            --- ODOO METHOD SOURCE (MODULE: test_mass_mailing, FILE: mailing_models.py) ---
            // def _message_get_default_recipients(self):
            // """ Default recipient checks for 'partner_id', here the field is named
            // 'customer_id'. """
            // default_recipients = super()._message_get_default_recipients()
            // for record in self:
            //     if record.customer_id:
            //         default_recipients[record.id] = {
            //             'email_cc': False,
            //             'email_to': False,
            //             'partner_ids': record.customer_id.ids,
            //         }
            // return default_recipients
            --- ODOO METHOD SOURCE (MODULE: test_mass_mailing, FILE: mailing_models.py) ---
            // def _message_get_default_recipients(self):
            // """ Default recipient checks for 'partner_id', here the field is named
            // 'customer_id'. """
            // default_recipients = super()._message_get_default_recipients()
            // for record in self:
            //     if record.customer_id:
            //         default_recipients[record.id] = {
            //             'email_cc': False,
            //             'email_to': False,
            //             'partner_ids': record.customer_id.ids,
            //         }
            // return default_recipients
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // try:
            //     # check if that language is correctly installed (and active) before using it
            //     lang_code = self.env['res.lang']._get_data(code=self.lang_code).code or None
            //     if self.partner_id:
            //         self._message_add_suggested_recipient(
            //             recipients, partner=self.partner_id, lang=lang_code, reason=_('Customer'))
            //     elif self.email_from:
            //         self._message_add_suggested_recipient(
            //             recipients, email=self.email_from, lang=lang_code, reason=_('Customer Email'))
            // except AccessError:  # no read access rights -> just ignore suggested recipients because this imply modifying followers
            //     pass
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_partner.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // self._message_add_suggested_recipient(recipients, partner=self, reason=_('Partner Profile'))
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_lead.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // # check if that language is correctly installed (and active) before using it
            // lang_code = self.env['res.lang']._get_data(code=self.lang_code).code or None
            // if self.partner_id:
            //     self._message_add_suggested_recipient(
            //         recipients, partner=self.partner_id, lang=lang_code, reason=_('Customer'))
            // elif self.email_from:
            //     self._message_add_suggested_recipient(
            //         recipients, email=self.email_from, lang=lang_code, reason=_('Customer Email'))
            // return recipients
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set an user as responsible. We prefer that
            // # assignment is done automatically (scoring) or manually. Otherwise it
            // # would always be root (gateway user). It also allows to exclude portal
            // # and public users.
            // self = self.with_context(default_user_id=False)
            // 
            // if custom_values is None:
            //     custom_values = {}
            // defaults = {
            //     'name':  msg_dict.get('subject') or _("No Subject"),
            //     'email_from': msg_dict.get('from'),
            //     'partner_id': msg_dict.get('author_id', False),
            // }
            // if msg_dict.get('priority') in dict(crm_stage.AVAILABLE_PRIORITIES):
            //     defaults['priority'] = msg_dict.get('priority')
            // defaults.update(custom_values)
            // 
            // return super(Lead, self).message_new(msg_dict, custom_values=defaults)
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """ Check override of 'message_new' allowing to update record values
            // base on incoming email. """
            // defaults = {
            //     'email_from': msg_dict.get('from'),
            // }
            // defaults.update(custom_values or {})
            // return super().message_new(msg_dict, custom_values=defaults)
            */
            return default;
        }

        public async Task<TEntity> MessagePartnerInfoFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object link_mail) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_partner_info_from_emails(self, emails, link_mail=False):
            // """ Try to propose a better recipient when having only an email by populating
            // it with the partner_name / contact_name field of the lead e.g. if lead
            // contact_name is "Raoul" and email is "raoul@raoul.fr", suggest
            // "Raoul" <raoul@raoul.fr> as recipient. """
            // result = super(Lead, self)._message_partner_info_from_emails(emails, link_mail=link_mail)
            // if not (self.partner_name or self.contact_name) or not self.email_from:
            //     return result
            // for email, partner_info in zip(emails, result):
            //     if partner_info.get('partner_id') or not email:
            //         continue
            //     # reformat email if no name information
            //     name_emails = tools.mail.email_split_tuples(email)
            //     name_from_email = name_emails[0][0] if name_emails else False
            //     if name_from_email:
            //         continue  # already containing name + email
            //     name_from_email = self.partner_name or self.contact_name
            //     emails_normalized = tools.email_normalize_all(email)
            //     email_normalized = emails_normalized[0] if emails_normalized else False
            //     if email.lower() == self.email_from.lower() or (email_normalized and self.email_normalized == email_normalized):
            //         partner_info['full_name'] = tools.formataddr((
            //             name_from_email,
            //             ','.join(emails_normalized) if emails_normalized else email))
            //         break
            // return result
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (self.email_normalized and partner.email_normalized == self.email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_normalized', '=', new_partner[0].email_normalized)
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(Lead, self)._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: mail_test_lead.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (self.email_normalized and partner.email_normalized == self.email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_normalized', '=', new_partner[0].email_normalized)
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([('partner_id', '=', False), email_domain]).write({'partner_id': new_partner[0].id})
            // return super()._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<TEntity> MessageReceiveBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _message_receive_bounce(self, email, partner):
            // """ Override of mail.thread generic method. Purpose is to increment the
            // bounce counter of the record. """
            // super(MailBlackListMixin, self)._message_receive_bounce(email, partner)
            // for record in self:
            //     record.message_bounce = record.message_bounce + 1
            */
            return default;
        }

        public async Task<TEntity> MessageResetBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _message_reset_bounce(self, email):
            // """ Override of mail.thread generic method. Purpose is to reset the
            // bounce counter of the record. """
            // super(MailBlackListMixin, self)._message_reset_bounce(email)
            // self.write({'message_bounce': 0})
            */
            return default;
        }

        public async Task<TEntity> MondialrelaySearchOrCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def name_create(self, name):
            // name, email = tools.parse_contact_from_email(name)
            // contact = self.create({'name': name, 'email': email})
            // return contact.id, contact.display_name
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.date_deadline:
            //     render_context['subtitles'].append(
            //         _('Deadline: %s', self.date_deadline.strftime(get_lang(self.env).date_format)))
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle salesman recipients that can convert leads into opportunities
            // and set opportunities as won / lost. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // local_msg_vals = dict(msg_vals or {})
            // 
            // self.ensure_one()
            // if self.type == 'lead':
            //     convert_action = self._notify_get_action_link('controller', controller='/lead/convert', **local_msg_vals)
            //     salesman_actions = [{'url': convert_action, 'title': _('Convert to opportunity')}]
            // else:
            //     won_action = self._notify_get_action_link('controller', controller='/lead/case_mark_won', **local_msg_vals)
            //     lost_action = self._notify_get_action_link('controller', controller='/lead/case_mark_lost', **local_msg_vals)
            //     salesman_actions = [
            //         {'url': won_action, 'title': _('Mark Won')},
            //         {'url': lost_action, 'title': _('Mark Lost')}]
            // 
            // salesman_group_id = self.env.ref('sales_team.group_sale_salesman').id
            // new_group = (
            //     'group_sale_salesman',
            //     lambda pdata: pdata['type'] == 'user' and salesman_group_id in pdata['groups'],
            //     {
            //         'actions': salesman_actions,
            //         'active': True,
            //         'has_button_access': True,
            //     }
            // )
            // 
            // return [new_group] + groups
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of lead and opportunities to their sales team if any. """
            // aliases = self.mapped('team_id').sudo()._notify_get_reply_to(default=default)
            // res = {lead.id: aliases.get(lead.team_id.id) for lead in self}
            // leftover = self.filtered(lambda rec: not rec.team_id)
            // if leftover:
            //     res.update(super(Lead, leftover)._notify_get_reply_to(default=default))
            // return res
            */
            return default;
        }

        public async Task<TEntity> OnchangeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id and self.country_id != self.state_id.country_id:
            //     self.state_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_latam_base, FILE: res_partner.py) ---
            // def _onchange_country(self):
            // country = self.country_id or self.company_id.account_fiscal_country_id or self.env.company.account_fiscal_country_id
            // identification_type = self.l10n_latam_identification_type_id
            // if not identification_type or (identification_type.country_id != country):
            //     self.l10n_latam_identification_type_id = self.env['l10n_latam.identification.type'].search(
            //         [('country_id', '=', country.id), ('is_vat', '=', True)], limit=1) or self.env.ref(
            //             'l10n_latam_base.it_vat', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> OnchangeEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_email(self):
            // if not self.image_1920 and self._context.get('gravatar_image') and self.email:
            //     self.image_1920 = self._get_gravatar_image(self.email)
            */
            return default;
        }

        public async Task<TEntity> OnchangeL10nInGstStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in_gstin_status, FILE: res_partner.py) ---
            // def _onchange_l10n_in_gst_status(self):
            // """
            // Reset GST Status Whenever the `vat` of partner changes
            // """
            // for partner in self:
            //     if partner.country_code == 'IN':
            //         partner.l10n_in_gstin_verified_status = False
            //         partner.l10n_in_gstin_verified_date = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeL10nPeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pe, FILE: res_partner.py) ---
            // def _onchange_l10n_pe_city_id(self):
            // if self.city_id and self.l10n_pe_district.city_id and self.l10n_pe_district.city_id != self.city_id:
            //     self.l10n_pe_district = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeL10nPeDistrictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pe, FILE: res_partner.py) ---
            // def _onchange_l10n_pe_district(self):
            // if self.l10n_pe_district:
            //     self.city_id = self.l10n_pe_district.city_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeL10nSeDefaultVendorPaymentRefAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_se, FILE: res_partner.py) ---
            // def onchange_l10n_se_default_vendor_payment_ref(self):
            // if not self.l10n_se_default_vendor_payment_ref == "" and self.l10n_se_check_vendor_ocr:
            //     reference = self.l10n_se_default_vendor_payment_ref
            //     try:
            //         luhn.validate(reference)
            //     except: 
            //         return {'warning': {'title': _('Warning'), 'message': _('Default vendor OCR number isn\'t a valid OCR number.')}}
            */
            return default;
        }

        public async Task<TEntity> OnchangeMobileValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> OnchangeParentIdForLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        public async Task<TEntity> OnchangePropertyProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id and self.country_id != self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def onchange_vat(self):
            // if self.vat and self.check_vat_in(self.vat):
            //     state_id = self.env['res.country.state'].search([('l10n_in_tin', '=', self.vat[:2])], limit=1)
            //     if state_id:
            //         self.state_id = state_id
            //     if self.vat[2].isalpha():
            //         self.l10n_in_pan = self.vat[2:12]
            */
            return default;
        }

        public async Task<TEntity> OpenApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_applications(self):
            // self.ensure_one()
            // return {
            //     'name': _('Applications'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.applicant',
            //     'view_mode': 'list,kanban,form,pivot,graph,calendar,activity',
            //     'domain': [('id', 'in', self.applicant_ids.ids)],
            //     'context': {
            //         'active_test': False,
            //         'search_default_stage': 1,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': 'hr.candidate',
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list,form',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': [('res_model', '=', 'hr.candidate'), ('res_id', 'in', self.ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: partner.py) ---
            // def action_open_business_doc(self):
            // return self._get_records_action()
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> OpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'view_mode': 'form',
            //     'res_id': self.employee_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> OpenSimilarCandidatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_similar_candidates(self):
            // self.ensure_one()
            // domain = self._get_similar_candidates_domain()
            // similar_candidates = self.env['hr.candidate'].with_context(active_test=False).search(domain)
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Similar Candidates'),
            //     'res_model': self._name,
            //     'view_mode': 'list,kanban,form,activity',
            //     'domain': [('id', 'in', similar_candidates.ids)],
            //     'context': {
            //         'active_test': False,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> OrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> PaymentDueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> PaymentEarliestDateSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> PaymentOverdueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> PeUnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_pe_pos, FILE: res_partner.py) ---
            // def _pe_unlink_except_master_data(self):
            // consumidor_final_anonimo = self.env.ref("l10n_pe_pos.partner_pe_cf")
            // if consumidor_final_anonimo & self:
            //     raise UserError(
            //         _(
            //             "Deleting the partner %s is not allowed because it is required by the Peruvian point of sale.",
            //             consumidor_final_anonimo.display_name,
            //         )
            //     )
            */
            return default;
        }

        public async Task<TEntity> PeppolEasEndpointDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # field dependencies of methods _compute_peppol_endpoint() and _compute_peppol_eas()
            // # because we need to extend depends in l10n modules
            // return ['country_code', 'vat', 'company_registry']
            --- ODOO METHOD SOURCE (MODULE: l10n_fr, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # extends account_edi_ubl_cii
            // return super()._peppol_eas_endpoint_depends() + ['siret']
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # extends account_edi_ubl_cii
            // return super()._peppol_eas_endpoint_depends() + ['l10n_it_codice_fiscale']
            --- ODOO METHOD SOURCE (MODULE: l10n_no, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # extends account_edi_ubl_cii
            // return super()._peppol_eas_endpoint_depends() + ['l10n_no_bronnoysund_number']
            --- ODOO METHOD SOURCE (MODULE: l10n_sg, FILE: res_partner.py) ---
            // def _peppol_eas_endpoint_depends(self):
            // # extends account_edi_ubl_cii
            // return super()._peppol_eas_endpoint_depends() + ['l10n_sg_unique_entity_number']
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _phone_get_number_fields(self):
            // return ['partner_phone']
            */
            return default;
        }

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_lead_pls_values(self, domain=[]):
            // """
            // This methods builds a dict where, for each lead in self or matching the given domain,
            // we will get a list of field/value couple.
            // Due to onchange and create, we don't always have the id of the lead to recompute.
            // When we update few records (one, typically) with onchanges, we build the lead_values (= couple field/value)
            // using the ORM.
            // To speed up the computation and avoid making too much DB read inside loops,
            // we can give a domain to make sql queries to bypass the ORM.
            // This domain will be used in sql queries to get the values for every lead matching the domain.
            // :param domain: If set, we get all the leads values via unique sql queries (one for tags, one for other fields),
            //                     using the given domain on leads.
            //                If not set, get lead values lead by lead using the ORM.
            // :return: {lead_id: [(field1: value1), (field2: value2), ...], ...}
            // """
            // leads_values_dict = OrderedDict()
            // pls_fields = ["stage_id", "team_id"] + self._pls_get_safe_fields()
            // 
            // # Check if tag_ids is in the pls_fields and removed it from the list. The tags will be managed separately.
            // use_tags = 'tag_ids' in pls_fields
            // if use_tags:
            //     pls_fields.remove('tag_ids')
            // 
            // if domain:
            //     # Get leads values
            //     self.flush_model()
            //     # active_test = False as domain should take active into 'active' field it self
            //     query = self.env['crm.lead'].with_context(active_test=False)._where_calc(domain)
            //     table = query.table
            //     query.order = SQL("%(table)s.team_id asc, %(table)s.id desc", table=SQL.identifier(table))
            //     sql_fields = [SQL.identifier(field) for field in pls_fields]
            //     self._cr.execute(query.select(
            //         SQL("id"),
            //         SQL("probability"),
            //         *sql_fields,
            //     ))
            //     lead_results = self._cr.dictfetchall()
            // 
            //     if use_tags:
            //         # Get tags values
            //         tag_rel_alias = query.left_join(table, 'id', 'crm_tag_rel', 'lead_id', 'crm_tag_rel')
            //         tag_alias = query.left_join(tag_rel_alias, 'tag_id', 'crm_tag', 'id', 'crm_tag')
            //         self._cr.execute(query.select(
            //             SQL("%s AS lead_id", SQL.identifier(table, "id")),
            //             SQL("%s AS tag_id", SQL.identifier(tag_alias, "id")),
            //         ))
            //         tag_results = self._cr.dictfetchall()
            //     else:
            //         tag_results = []
            // 
            //     # get all (variable, value) couple for all in self
            //     for lead in lead_results:
            //         lead_values = []
            //         for field in pls_fields + ['probability']:  # add probability as used in _pls_prepare_frequencies (needed in rebuild mode)
            //             value = lead[field]
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             if value or field == 'probability':  # 0 is a correct value for probability
            //                 lead_values.append((field, value))
            //             elif field in ('email_state', 'phone_state'):  # As ORM reads 'None' as 'False', do the same here
            //                 lead_values.append((field, False))
            //             leads_values_dict[lead['id']] = {'values': lead_values, 'team_id': lead['team_id'] or 0}
            // 
            //     for tag in tag_results:
            //         if tag['tag_id']:
            //             leads_values_dict[tag['lead_id']]['values'].append(('tag_id', tag['tag_id']))
            //     return leads_values_dict
            // else:
            //     for lead in self:
            //         lead_values = []
            //         for field in pls_fields:
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             value = lead[field].id if isinstance(lead[field], models.BaseModel) else lead[field]
            //             if value or field in ('email_state', 'phone_state'):
            //                 lead_values.append((field, value))
            //         if use_tags:
            //             for tag in lead.tag_ids:
            //                 lead_values.append(('tag_id', tag.id))
            //         leads_values_dict[lead.id] = {'values': lead_values, 'team_id': lead['team_id'].id}
            //     return leads_values_dict
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_naive_bayes_probabilities(self, batch_mode=False):
            // """
            // In machine learning, naive Bayes classifiers (NBC) are a family of simple "probabilistic classifiers" based on
            // applying Bayes theorem with strong (naive) independence assumptions between the variables taken into account.
            // E.g: will TDE eat m&m's depending on his sleep status, the amount of work he has and the fullness of his stomach?
            // As we use experience to compute the statistics, every day, we will register the variables state + the result.
            // As the days pass, we will be able to determine, with more and more precision, if TDE will eat m&m's
            // for a specific combination :
            //     - did sleep very well, a lot of work and stomach full > Will never happen !
            //     - didn't sleep at all, no work at all and empty stomach > for sure !
            // Following Bayes' Theorem: the probability that an event occurs (to win) under certain conditions is proportional
            // to the probability to win under each condition separately and the probability to win. We compute a 'Win score'
            // -> P(Won | A∩B) ∝ P(A∩B | Won)*P(Won) OR S(Won | A∩B) = P(A∩B | Won)*P(Won)
            // To compute a percentage of probability to win, we also compute the 'Lost score' that is proportional to the
            // probability to lose under each condition separately and the probability to lose.
            // -> Probability =  S(Won | A∩B) / ( S(Won | A∩B) + S(Lost | A∩B) )
            // See https://www.youtube.com/watch?v=CPqOCI0ahss can help to get a quick and simple example.
            // One issue about NBC is when a event occurence is never observed.
            // E.g: if when TDE has an empty stomach, he always eat m&m's, than the "not eating m&m's when empty stomach' event
            // will never be observed.
            // This is called 'zero frequency' and that leads to division (or at least multiplication) by zero.
            // To avoid this, we add 0.1 in each frequency. With few data, the computation is than not really realistic.
            // The more we have records to analyse, the more the estimation will be precise.
            // :return: probability in percent (and integer rounded) that the lead will be won at the current stage.
            // """
            // lead_probabilities = {}
            // if not self:
            //     return lead_probabilities
            // 
            // # Get all leads values, no matter the team_id
            // domain = []
            // if batch_mode:
            //     domain = [
            //         '&',
            //             ('active', '=', True), ('id', 'in', self.ids),
            //             '|',
            //                 ('probability', '=', None),
            //                 '&',
            //                     ('probability', '<', 100), ('probability', '>', 0)
            //     ]
            // leads_values_dict = self._pls_get_lead_pls_values(domain=domain)
            // 
            // if not leads_values_dict:
            //     return lead_probabilities
            // 
            // # Get unique couples to search in frequency table and won leads.
            // leads_fields = set()  # keep unique fields, as a lead can have multiple tag_ids
            // won_leads = set()
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead_id, values in leads_values_dict.items():
            //     for field, value in values['values']:
            //         if field == 'stage_id' and value in won_stage_ids:
            //             won_leads.add(lead_id)
            //         leads_fields.add(field)
            // leads_fields = sorted(leads_fields)
            // # get all variable related records from frequency table, no matter the team_id
            // frequencies = self.env['crm.lead.scoring.frequency'].search([('variable', 'in', list(leads_fields))], order="team_id asc, id")
            // 
            // # get all team_ids from frequencies
            // frequency_teams = frequencies.mapped('team_id')
            // frequency_team_ids = [team.id for team in frequency_teams]
            // 
            // # 1. Compute each variable value count individually
            // # regroup each variable to be able to compute their own probabilities
            // # As all the variable does not enter into account (as we reject unset values in the process)
            // # each value probability must be computed only with their own variable related total count
            // # special case: for lead for which team_id is not in frequency table or lead with no team_id,
            // # we consider all the records, independently from team_id (this is why we add a result[-1])
            // result = dict((team_id, dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)) for team_id in frequency_team_ids)
            // result[-1] = dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)
            // for frequency in frequencies:
            //     field = frequency['variable']
            //     value = frequency['value']
            // 
            //     # To avoid that a tag take too much importance if its subset is too small,
            //     # we ignore the tag frequencies if we have less than 50 won or lost for this tag.
            //     if field == 'tag_id' and (frequency['won_count'] + frequency['lost_count']) < 50:
            //         continue
            // 
            //     if frequency.team_id:
            //         team_result = result[frequency.team_id.id]
            //         team_result[field][value] = {'won': frequency['won_count'], 'lost': frequency['lost_count']}
            //         team_result[field]['won_total'] += frequency['won_count']
            //         team_result[field]['lost_total'] += frequency['lost_count']
            // 
            //     if value not in result[-1][field]:
            //         result[-1][field][value] = {'won': 0, 'lost': 0}
            //     result[-1][field][value]['won'] += frequency['won_count']
            //     result[-1][field][value]['lost'] += frequency['lost_count']
            //     result[-1][field]['won_total'] += frequency['won_count']
            //     result[-1][field]['lost_total'] += frequency['lost_count']
            // 
            // # Get all won, lost and total count for all records in frequencies per team_id
            // for team_id in result:
            //     result[team_id]['team_won'], \
            //     result[team_id]['team_lost'], \
            //     result[team_id]['team_total'] = self._pls_get_won_lost_total_count(result[team_id])
            // 
            // save_team_id = None
            // p_won, p_lost = 1, 1
            // for lead_id, lead_values in leads_values_dict.items():
            //     # if stage_id is null, return 0 and bypass computation
            //     lead_fields = [value[0] for value in lead_values.get('values', [])]
            //     if not 'stage_id' in lead_fields:
            //         lead_probabilities[lead_id] = 0
            //         continue
            //     # if lead stage is won, return 100
            //     elif lead_id in won_leads:
            //         lead_probabilities[lead_id] = 100
            //         continue
            // 
            //     # team_id not in frequency Table -> convert to -1
            //     lead_team_id = lead_values['team_id'] if lead_values['team_id'] in result else -1
            //     if lead_team_id != save_team_id:
            //         save_team_id = lead_team_id
            //         team_won = result[save_team_id]['team_won']
            //         team_lost = result[save_team_id]['team_lost']
            //         team_total = result[save_team_id]['team_total']
            //         # if one count = 0, we cannot compute lead probability
            //         if not team_won or not team_lost:
            //             continue
            //         p_won = team_won / team_total
            //         p_lost = team_lost / team_total
            // 
            //     # 2. Compute won and lost score using each variable's individual probability
            //     s_lead_won, s_lead_lost = p_won, p_lost
            //     for field, value in lead_values['values']:
            //         field_result = result.get(save_team_id, {}).get(field)
            //         value = value.origin if hasattr(value, 'origin') else value
            //         value_result = field_result.get(str(value)) if field_result else False
            //         if value_result:
            //             total_won = team_won if field == 'stage_id' else field_result['won_total']
            //             total_lost = team_lost if field == 'stage_id' else field_result['lost_total']
            // 
            //             # if one count = 0, we cannot compute lead probability
            //             if not total_won or not total_lost:
            //                 continue
            //             s_lead_won *= value_result['won'] / total_won
            //             s_lead_lost *= value_result['lost'] / total_lost
            // 
            //     # 3. Compute Probability to win
            //     probability = s_lead_won / (s_lead_won + s_lead_lost)
            //     lead_probabilities[lead_id] = min(max(round(100 * probability, 2), 0.01), 99.99)
            // return lead_probabilities
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_fields(self):
            // """ As config_parameters does not accept M2M field,
            //     we the fields from the formated string stored into the Char config field.
            //     To avoid sql injections when using that list, we return only the fields
            //     that are defined on the model. """
            // pls_fields_config = self.env['ir.config_parameter'].sudo().get_param('crm.pls_fields')
            // pls_fields = pls_fields_config.split(',') if pls_fields_config else []
            // pls_safe_fields = [field for field in pls_fields if field in self._fields.keys()]
            // return pls_safe_fields
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_start_date(self):
            // """ As config_parameters does not accept Date field,
            //     we get directly the date formated string stored into the Char config field,
            //     as we directly use this string in the sql queries.
            //     To avoid sql injections when using this config param,
            //     we ensure the date string can be effectively a date."""
            // str_date = self.env['ir.config_parameter'].sudo().get_param('crm.pls_start_date')
            // if not fields.Date.to_date(str_date):
            //     return False
            // return str_date
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_won_lost_total_count(self, team_results):
            // """ Get all won and all lost + total :
            //        first stage can be used to know how many lost and won there is
            //        as won count are equals for all stage
            //        and first stage is always incremented in lost_count
            // :param frequencies: lead_scoring_frequencies
            // :return: won count, lost count and total count for all records in frequencies
            // """
            // # TODO : check if we need to handle specific team_id stages [for lost count] (if first stage in sequence is team_specific)
            // first_stage_id = self.env['crm.stage'].search([('team_id', '=', False)], order='sequence, id', limit=1)
            // if str(first_stage_id.id) not in team_results.get('stage_id', []):
            //     return 0, 0, 0
            // stage_result = team_results['stage_id'][str(first_stage_id.id)]
            // return stage_result['won'], stage_result['lost'], stage_result['won'] + stage_result['lost']
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequencies(self, from_state=None, to_state=None):
            // """
            // When losing or winning a lead, this method is called to increment each PLS parameter related to the lead
            // in won_count (if won) or in lost_count (if lost).
            // 
            // This method is also used when reactivating a mistakenly lost lead (using the decrement argument).
            // In this case, the lost count should be de-increment by 1 for each PLS parameter linked to the lead.
            // 
            // Live increment must be done before writing the new values because we need to know the state change (from and to).
            // This would not be an issue for the reach won or reach lost as we just need to increment the frequencies with the
            // final state of the lead.
            // This issue is when the lead leaves a closed state because once the new values have been writen, we do not know
            // what was the previous state that we need to decrement.
            // This is why 'is_won' and 'decrement' parameters are used to describe the from / to change of its state.
            // """
            // new_frequencies_by_team, existing_frequencies_by_team = self._pls_prepare_update_frequency_table(target_state=from_state or to_state)
            // 
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1 if to_state else -1,
            //                                  existing_frequencies_by_team=existing_frequencies_by_team)
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequency_dict(self, frequencies, field, value, won, lost):
            // value = str(value)  # Ensure we will always compare strings.
            // if value not in frequencies[field]:
            //     frequencies[field][value] = {'won': won, 'lost': lost}
            // else:
            //     frequencies[field][value]['won'] += won
            //     frequencies[field][value]['lost'] += lost
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_frequencies(self, lead_values, leads_pls_fields, target_state=None):
            // """new state is used when getting frequencies for leads that are changing to lost or won.
            // Stays none if we are checking frequencies for leads already won or lost."""
            // pls_fields = leads_pls_fields.copy()
            // frequencies = dict((field, {}) for field in pls_fields)
            // 
            // stage_ids = self.env['crm.stage'].search_read([], ['sequence', 'name', 'id'], order='sequence, id')
            // stage_sequences = {stage['id']: stage['sequence'] for stage in stage_ids}
            // 
            // # Increment won / lost frequencies by criteria (field / value couple)
            // for values in lead_values:
            //     if target_state:  # ignore probability values if target state (as probability is the old value)
            //         won_count = values['count'] if target_state == 'won' else 0
            //         lost_count = values['count'] if target_state == 'lost' else 0
            //     else:
            //         won_count = values['count'] if values.get('probability', 0) == 100 else 0
            //         lost_count = values['count'] if values.get('probability', 1) == 0  else 0
            // 
            //     if 'tag_id' in values:
            //         frequencies = self._pls_increment_frequency_dict(frequencies, 'tag_id', values['tag_id'], won_count, lost_count)
            //         continue
            // 
            //     # Else, treat other fields
            //     if 'tag_id' in pls_fields:  # tag_id already treated here above.
            //         pls_fields.remove('tag_id')
            //     for field in pls_fields:
            //         if field not in values:
            //             continue
            //         value = values[field]
            //         if value or field in ('email_state', 'phone_state'):
            //             if field == 'stage_id':
            //                 if won_count:  # increment all stages if won
            //                     stages_to_increment = [stage['id'] for stage in stage_ids]
            //                 else:  # increment only current + previous stages if lost
            //                     current_stage_sequence = stage_sequences[value]
            //                     stages_to_increment = [stage['id'] for stage in stage_ids if stage['sequence'] <= current_stage_sequence]
            //                 for stage_id in stages_to_increment:
            //                     frequencies = self._pls_increment_frequency_dict(frequencies, field, stage_id, won_count, lost_count)
            //             else:
            //                 frequencies = self._pls_increment_frequency_dict(frequencies, field, value, won_count, lost_count)
            // 
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_update_frequency_table(self, rebuild=False, target_state=False):
            // """
            // This method is common to Live Increment or Full Rebuild mode, as it shares the main steps.
            // This method will prepare the frequency dict needed to update the frequency table:
            //     - New frequencies: frequencies that we need to add in the frequency table.
            //     - Existing frequencies: frequencies that are already in the frequency table.
            // In rebuild mode, only the new frequencies are needed as existing frequencies are truncated.
            // For each team, each dict contains the frequency in won and lost for each field/value couple
            // of the target leads.
            // Target leads are :
            //     - in Live increment mode : given ongoing leads (self)
            //     - in Full rebuild mode : all the closed (won and lost) leads in the DB.
            // During the frequencies update, with both new and existing frequencies, we can split frequencies to update
            // and frequencies to add. If a field/value couple already exists in the frequency table, we just update it.
            // Otherwise, we need to insert a new one.
            // """
            // # Keep eligible leads
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return {}, {}
            // 
            // if rebuild:  # rebuild will treat every closed lead in DB, increment will treat current ongoing leads
            //     pls_leads = self
            // else:
            //     # Only treat leads created after the PLS start Date
            //     pls_leads = self.filtered(
            //         lambda lead: fields.Date.to_date(pls_start_date) <= fields.Date.to_date(lead.create_date))
            //     if not pls_leads:
            //         return {}, {}
            // 
            // # Extract target leads values
            // if rebuild:  # rebuild is ok
            //     domain = [
            //         '&',
            //             ('create_date', '>=', pls_start_date),
            //             '|',
            //                 ('probability', '=', 100),
            //                 '&',
            //                     ('probability', '=', 0), ('active', '=', False)
            //       ]
            //     team_ids = self.env['crm.team'].with_context(active_test=False).search([]).ids + [0]  # If team_id is unset, consider it as team 0
            // else:  # increment
            //     domain = [('id', 'in', pls_leads.ids)]
            //     team_ids = pls_leads.mapped('team_id').ids + [0]
            // 
            // leads_values_dict = pls_leads._pls_get_lead_pls_values(domain=domain)
            // 
            // # split leads values by team_id
            // # get current frequencies related to the target leads
            // leads_frequency_values_by_team = dict((team_id, []) for team_id in team_ids)
            // leads_pls_fields = set()  # ensure to keep each field unique (can have multiple tag_id leads_values_dict)
            // for lead_id, values in leads_values_dict.items():
            //     team_id = values.get('team_id', 0)  # If team_id is unset, consider it as team 0
            //     lead_frequency_values = {'count': 1}
            //     for field, value in values['values']:
            //         if field != "probability":  # was added to lead values in batch mode to know won/lost state, but is not a pls fields.
            //             leads_pls_fields.add(field)
            //         else:  # extract lead probability - needed to increment tag_id frequency. (proba always before tag_id)
            //             lead_probability = value
            //         if field == 'tag_id':  # handle tag_id separatelly (as in One Shot rebuild mode)
            //             leads_frequency_values_by_team[team_id].append({field: value, 'count': 1, 'probability': lead_probability})
            //         else:
            //             lead_frequency_values[field] = value
            //     leads_frequency_values_by_team[team_id].append(lead_frequency_values)
            // leads_pls_fields = sorted(leads_pls_fields)
            // 
            // # get new frequencies
            // new_frequencies_by_team = {}
            // for team_id in team_ids:
            //     # prepare fields and tag values for leads by team
            //     new_frequencies_by_team[team_id] = self._pls_prepare_frequencies(
            //         leads_frequency_values_by_team[team_id], leads_pls_fields, target_state=target_state)
            // 
            // # get existing frequencies
            // existing_frequencies_by_team = {}
            // if not rebuild:  # there is no existing frequency in rebuild mode as they were all deleted.
            //     # read all fields to get everything in memory in one query (instead of having query + prefetch)
            //     existing_frequencies = self.env['crm.lead.scoring.frequency'].search_read(
            //         ['&', ('variable', 'in', leads_pls_fields),
            //               '|', ('team_id', 'in', pls_leads.mapped('team_id').ids), ('team_id', '=', False)])
            //     for frequency in existing_frequencies:
            //         team_id = frequency['team_id'][0] if frequency.get('team_id') else 0
            //         if team_id not in existing_frequencies_by_team:
            //             existing_frequencies_by_team[team_id] = dict((field, {}) for field in leads_pls_fields)
            // 
            //         existing_frequencies_by_team[team_id][frequency['variable']][frequency['value']] = {
            //             'frequency_id': frequency['id'],
            //             'won': frequency['won_count'],
            //             'lost': frequency['lost_count']
            //         }
            // 
            // return new_frequencies_by_team, existing_frequencies_by_team
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_update_frequency_table(self, new_frequencies_by_team, step, existing_frequencies_by_team=None):
            // """ Create / update the frequency table in a cross company way, per team_id"""
            // values_to_update = {}
            // values_to_create = []
            // if not existing_frequencies_by_team:
            //     existing_frequencies_by_team = {}
            // # build the create multi + frequencies to update
            // for team_id, new_frequencies in new_frequencies_by_team.items():
            //     for field, value in new_frequencies.items():
            //         # frequency already present ?
            //         current_frequencies = existing_frequencies_by_team.get(team_id, {})
            //         for param, result in value.items():
            //             current_frequency_for_couple = current_frequencies.get(field, {}).get(param, {})
            //             # If frequency already present : UPDATE IT
            //             if current_frequency_for_couple:
            //                 new_won = current_frequency_for_couple['won'] + (result['won'] * step)
            //                 new_lost = current_frequency_for_couple['lost'] + (result['lost'] * step)
            //                 # ensure to have always positive frequencies
            //                 values_to_update[current_frequency_for_couple['frequency_id']] = {
            //                     'won_count': new_won if new_won > 0 else 0.1,
            //                     'lost_count': new_lost if new_lost > 0 else 0.1
            //                 }
            //                 continue
            // 
            //             # Else, CREATE a new frequency record.
            //             # We add + 0.1 in won and lost counts to avoid zero frequency issues
            //             # should be +1 but it weights too much on small recordset.
            //             values_to_create.append({
            //                 'variable': field,
            //                 'value': param,
            //                 'won_count': result['won'] + 0.1,
            //                 'lost_count': result['lost'] + 0.1,
            //                 'team_id': team_id if team_id else None  # team_id = 0 means no team_id
            //             })
            // 
            // LeadScoringFrequency = self.env['crm.lead.scoring.frequency'].sudo()
            // for frequency_id, values in values_to_update.items():
            //     LeadScoringFrequency.browse(frequency_id).write(values)
            // 
            // if values_to_create:
            //     LeadScoringFrequency.create(values_to_create)
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_address_values_from_partner(self, partner):
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // if any(partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC):
            //     values = {f: partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // else:
            //     values = {f: self[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // return values
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_contact_name_from_partner(self, partner):
            // contact_name = False if partner.is_company else partner.name
            // return {'contact_name': contact_name or self.contact_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_customer_values(self, partner_name, is_company=False, parent_id=False):
            // """ Extract data from lead to create a partner.
            // 
            // :param name : furtur name of the partner
            // :param is_company : True if the partner is a company
            // :param parent_id : id of the parent partner (False if no parent)
            // 
            // :return: dictionary of values to give at res_partner.create()
            // """
            // email_parts = tools.email_split(self.email_from)
            // res = {
            //     'name': partner_name,
            //     'user_id': self.env.context.get('default_user_id') or self.user_id.id,
            //     'comment': self.description,
            //     'parent_id': parent_id,
            //     'phone': self.phone,
            //     'mobile': self.mobile,
            //     'email': email_parts[0] if email_parts else False,
            //     'title': self.title.id,
            //     'function': self.function,
            //     'street': self.street,
            //     'street2': self.street2,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country_id': self.country_id.id,
            //     'state_id': self.state_id.id,
            //     'website': self.website,
            //     'is_company': is_company,
            //     'type': 'contact'
            // }
            // if self.lang_id.active:
            //     res['lang'] = self.lang_id.code
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_partner_name_from_partner(self, partner):
            // """ Company name: name of partner parent (if set) or name of partner
            // (if company) or company_name of partner (if not a company). """
            // partner_name = partner.parent_id.name
            // if not partner_name and partner.is_company:
            //     partner_name = partner.name
            // elif not partner_name and partner.company_name:
            //     partner_name = partner.company_name
            // return {'partner_name': partner_name or self.partner_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_values_from_partner(self, partner):
            // """ Get a dictionary with values coming from partner information to
            // copy on a lead. Non-address fields get the current lead
            // values to avoid being reset if partner has no value for them. """
            // 
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // values = self._prepare_address_values_from_partner(partner)
            // 
            // # For other fields, get the info from the partner, but only if set
            // values.update({f: partner[f] or self[f] for f in PARTNER_FIELDS_TO_SYNC if f != 'lang'})
            // if partner.lang:
            //     values['lang_id'] = self.env['res.lang']._get_data(code=partner.lang).id
            // 
            // # Fields with specific logic
            // values.update(self._prepare_contact_name_from_partner(partner))
            // values.update(self._prepare_partner_name_from_partner(partner))
            // 
            // return self._convert_to_write(values)
            */
            return default;
        }

        public async Task<TEntity> PrivacyLookupAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ProcessEnrichedResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object response, object error) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> ReadByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object timeout) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py) ---
            // def read_by_vat(self, vat, timeout=15):
            // return []
            */
            return default;
        }

        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve team_id from the context and write the domain
            // # - ('id', 'in', stages.ids): add columns that should be present
            // # - OR ('fold', '=', False): add default columns that are not folded
            // # - OR ('team_ids', '=', team_id), ('fold', '=', False) if team_id: add team columns that are not folded
            // team_id = self._context.get('default_team_id')
            // if team_id:
            //     search_domain = ['|', ('id', 'in', stages.ids), '|', ('team_id', '=', False), ('team_id', '=', team_id)]
            // else:
            //     search_domain = ['|', ('id', 'in', stages.ids), ('team_id', '=', False)]
            // 
            // # perform search
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _rebuild_pls_frequency_table(self):
            // # Clear the frequencies table (in sql to speed up the cron)
            // try:
            //     self.browse().check_access('unlink')
            // except AccessError:
            //     raise UserError(_("You don't have the access needed to run this cron."))
            // else:
            //     self._cr.execute('TRUNCATE TABLE crm_lead_scoring_frequency')
            // 
            // new_frequencies_by_team, unused = self._pls_prepare_update_frequency_table(rebuild=True)
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1)
            // 
            // _logger.info("Predictive Lead Scoring : crm.lead.scoring.frequency table rebuilt")
            */
            return default;
        }

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def redirect_lead_opportunity_view(self):
            // self.ensure_one()
            // return {
            //     'name': _('Lead or Opportunity'),
            //     'view_mode': 'form',
            //     'res_model': 'crm.lead',
            //     'domain': [('type', '=', self.type)],
            //     'res_id': self.id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_type': self.type}
            // }
            */
            return default;
        }

        public async Task<TEntity> RescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_reschedule_meeting(self):
            // self.ensure_one()
            // action = self.action_schedule_meeting(smart_calendar=False)
            // next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // if next_activity.calendar_event_id:
            //     action['context']['initial_date'] = next_activity.calendar_event_id.start
            // return action
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat, object domain, object company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> RetrievePartnerWithNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> RetrievePartnerWithPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone, object email, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> RetrievePartnerWithVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> RunVatTestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat_number, object default_country, object partner_is_company) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> RunViesTestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat_number, object default_country) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: res_partner.py) ---
            // def _run_vies_test(self, vat_number, default_country):
            // """Convert back the hungarian format to EU format: 12345678-1-12 => HU12345678"""
            // if default_country and default_country.code == 'HU' and not vat_number.startswith('HU'):
            //     vat_number = f'HU{vat_number[:8]}'
            // return super()._run_vies_test(vat_number, default_country)
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_schedule_meeting(self, smart_calendar=True):
            // """ Open meeting's calendar view to schedule meeting on current opportunity.
            // 
            //     :param smart_calendar: boolean, to set to False if the view should not try to choose relevant
            //       mode and initial date for calendar view, see ``_get_opportunity_meeting_view_parameters``
            //     :return dict: dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // partner_ids = self.env.user.partner_id.ids
            // if self.partner_id:
            //     partner_ids.append(self.partner_id.id)
            // current_opportunity_id = self.id if self.type == 'opportunity' else False
            // action['context'] = {
            //     'search_default_opportunity_id': current_opportunity_id,
            //     'default_opportunity_id': current_opportunity_id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_partner_ids': partner_ids,
            //     'default_team_id': self.team_id.id,
            //     'default_name': self.name,
            // }
            // 
            // # 'Smart' calendar view : get the most relevant time period to display to the user.
            // if current_opportunity_id and smart_calendar:
            //     mode, initial_date = self._get_opportunity_meeting_view_parameters()
            //     action['context'].update({'default_mode': mode, 'initial_date': initial_date})
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // """ Override to support ordering on my_activity_date_deadline.
            // 
            // Ordering through web client calls search_read() with an order parameter
            // set. Method search_read() then calls search_fetch(). Here we override
            // search_fetch() to intercept a search with an order on field
            // my_activity_date_deadline. In that case we do the search in two steps.
            // 
            // First step: fill with deadline-based results
            // 
            //   * Perform a read_group on my activities to get a mapping lead_id / deadline
            //     Remember date_deadline is required, we always have a value for it. Only
            //     the earliest deadline per lead is kept.
            //   * Search leads linked to those activities that also match the asked domain
            //     and order from the original search request.
            //   * Results of that search will be at the top of returned results. Use limit
            //     None because we have to search all leads linked to activities as ordering
            //     on deadline is done in post processing.
            //   * Reorder them according to deadline asc or desc depending on original
            //     search ordering. Finally take only a subset of those leads to fill with
            //     results matching asked offset / limit.
            // 
            // Second step: fill with other results. If first step does not gives results
            // enough to match offset and limit parameters we fill with a search on other
            // leads. We keep the asked domain and ordering while filtering out already
            // scanned leads to keep a coherent results.
            // 
            // All other search and search_read are left untouched by this override to avoid
            // side effects. Search_count is not affected by this override.
            // """
            // if not order or 'my_activity_date_deadline' not in order:
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // order_items = [order_item.strip().lower() for order_item in (order or self._order).split(',')]
            // 
            // # Perform a read_group on my activities to get a mapping lead_id / deadline
            // # Remember date_deadline is required, we always have a value for it. Only
            // # the earliest deadline per lead is kept.
            // activity_asc = any('my_activity_date_deadline asc' in item for item in order_items)
            // my_lead_activities = self.env['mail.activity']._read_group(
            //     [('res_model', '=', self._name), ('user_id', '=', self.env.uid)],
            //     ['res_id'],
            //     ['date_deadline:min'],
            //     order='date_deadline:min ASC, res_id',
            // )
            // my_lead_mapping = dict(my_lead_activities)
            // my_lead_ids = list(my_lead_mapping.keys())
            // my_lead_domain = expression.AND([[('id', 'in', my_lead_ids)], domain])
            // my_lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // # Search leads linked to those activities and order them. See docstring
            // # of this method for more details.
            // search_res = super().search_fetch(my_lead_domain, field_names, order=my_lead_order)
            // my_lead_ids_ordered = sorted(search_res.ids, key=lambda lead_id: my_lead_mapping[lead_id], reverse=not activity_asc)
            // # keep only requested window (offset + limit, or offset+)
            // my_lead_ids_keep = my_lead_ids_ordered[offset:(offset + limit)] if limit else my_lead_ids_ordered[offset:]
            // # keep list of already skipped lead ids to exclude them from future search
            // my_lead_ids_skip = my_lead_ids_ordered[:(offset + limit)] if limit else my_lead_ids_ordered
            // 
            // # do not go further if limit is achieved
            // if limit and len(my_lead_ids_keep) >= limit:
            //     return self.browse(my_lead_ids_keep)
            // 
            // # Fill with remaining leads. If a limit is given, simply remove count of
            // # already fetched. Otherwise keep none. If an offset is set we have to
            // # reduce it by already fetch results hereabove. Order is updated to exclude
            // # my_activity_date_deadline when calling super() .
            // lead_limit = (limit - len(my_lead_ids_keep)) if limit else None
            // if offset:
            //     lead_offset = max((offset - len(search_res), 0))
            // else:
            //     lead_offset = 0
            // lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // other_lead_res = super().search_fetch(
            //     expression.AND([[('id', 'not in', my_lead_ids_skip)], domain]),
            //     field_names, lead_offset, lead_limit, lead_order,
            // )
            // return self.browse(my_lead_ids_keep) + other_lead_res
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object channel) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SearchIsBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py) ---
            // def _search_is_blacklisted(self, operator, value):
            // # Assumes operator is '=' or '!=' and value is True or False
            // self.flush_model(['email_normalized'])
            // self.env['mail.blacklist'].flush_model(['email', 'active'])
            // self._assert_primary_email()
            // if operator != '=':
            //     if operator == '!=' and isinstance(value, bool):
            //         value = not value
            //     else:
            //         raise NotImplementedError()
            // 
            // if value:
            //     sql = SQL("""
            //         SELECT m.id
            //             FROM mail_blacklist bl
            //             JOIN %s m
            //             ON m.email_normalized = bl.email AND bl.active
            //     """, SQL.identifier(self._table))
            // else:
            //     sql = SQL("""
            //         SELECT m.id
            //             FROM %s m
            //             LEFT JOIN mail_blacklist bl
            //             ON m.email_normalized = bl.email AND bl.active
            //             WHERE bl.id IS NULL
            //     """, SQL.identifier(self._table))
            // 
            // self._cr.execute(SQL("%s FETCH FIRST ROW ONLY", sql))
            // res = self._cr.fetchall()
            // if not res:
            //     return [(0, '=', 1)]
            // return [('id', 'in', SQL("(%s)", sql))]
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SearchMentionSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object limit, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SearchOptOutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_contact.py) ---
            // def _search_opt_out(self, operator, value):
            // # Assumes operator is '=' or '!=' and value is True or False
            // if operator != '=':
            //     if operator == '!=' and isinstance(value, bool):
            //         value = not value
            //     else:
            //         raise NotImplementedError()
            // 
            // if 'default_list_ids' in self._context and isinstance(self._context['default_list_ids'], (list, tuple)) and len(self._context['default_list_ids']) == 1:
            //     [active_list_id] = self._context['default_list_ids']
            //     contacts = self.env['mailing.subscription'].search([('list_id', '=', active_list_id)])
            //     return [('id', 'in', [record.contact_id.id for record in contacts if record.opt_out == value])]
            // return expression.FALSE_DOMAIN if value else expression.TRUE_DOMAIN
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelCompletedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SearchSlideChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'candidate.send.mail',
            //     'context': {
            //         'default_candidate_ids': self.ids,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> SetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_automated_probability(self):
            // self.write({'probability': self.automated_probability})
            */
            return default;
        }

        public async Task<TEntity> SetCalendarLastNotifAckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_partner.py) ---
            // def _set_calendar_last_notif_ack(self):
            // partner = self.env['res.users'].browse(self.env.context.get('uid', self.env.uid)).partner_id
            // partner.write({'calendar_last_notif_ack': datetime.now()})
            */
            return default;
        }

        public async Task<TEntity> SetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_lost(self, **additional_values):
            // """ Lost semantic: probability = 0 or active = False """
            // res = self.action_archive()
            // if additional_values:
            //     self.write(dict(additional_values))
            // return res
            */
            return default;
        }

        public async Task<TEntity> SetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won(self):
            // """ Won semantic: probability = 100 (active untouched) """
            // self.action_unarchive()
            // # group the leads by team_id, in order to write once by values couple (each write leads to frequency increment)
            // leads_by_won_stage = {}
            // for lead in self:
            //     won_stages = self._stage_find(domain=[('is_won', '=', True)], limit=None)
            //     # ABD : We could have a mixed pipeline, with "won" stages being separated by "standard"
            //     # stages. In the future, we may want to prevent any "standard" stage to have a higher
            //     # sequence than any "won" stage. But while this is not the case, searching
            //     # for the "won" stage while alterning the sequence order (see below) will correctly
            //     # handle such a case :
            //     #       stage sequence : [x] [x (won)] [y] [y (won)] [z] [z (won)]
            //     #       when in stage [y] and marked as "won", should go to the stage [y (won)],
            //     #       not in [x (won)] nor [z (won)]
            //     stage_id = next((stage for stage in won_stages if stage.sequence > lead.stage_id.sequence), None)
            //     if not stage_id:
            //         stage_id = next((stage for stage in reversed(won_stages) if stage.sequence <= lead.stage_id.sequence), won_stages)
            //     if stage_id in leads_by_won_stage:
            //         leads_by_won_stage[stage_id] += lead
            //     else:
            //         leads_by_won_stage[stage_id] = lead
            // for won_stage_id, leads in leads_by_won_stage.items():
            //     leads.write({'stage_id': won_stage_id.id, 'probability': 100})
            // return True
            */
            return default;
        }

        public async Task<TEntity> SetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won_rainbowman(self):
            // self.ensure_one()
            // self.action_set_won()
            // 
            // message = self._get_rainbowman_message()
            // if message:
            //     return {
            //         'effect': {
            //             'fadeout': 'slow',
            //             'message': message,
            //             'img_url': '/web/image/%s/%s/image_1024' % (self.team_id.user_id._name, self.team_id.user_id.id) if self.team_id.user_id.image_1024 else '/web/static/img/smile.svg',
            //             'type': 'rainbow_man',
            //         }
            //     }
            // return True
            */
            return default;
        }

        public async Task<TEntity> ShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_show_potential_duplicates(self):
            // """ Open kanban view to display duplicate leads or opportunity.
            //     :return dict: dictionary value for created kanban view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_opportunities")
            // action['domain'] = [('id', 'in', self.duplicate_lead_ids.ids)]
            // action['context'] = {
            //     'active_test': False,
            //     'create': False
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> SignupCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def signup_cancel(self):
            // return self.write({'signup_type': None})
            */
            return default;
        }

        public async Task<TEntity> SignupGetAuthParamAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py) ---
            // def action_signup_prepare(self):
            // return self.signup_prepare()
            */
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> SignupRetrieveInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SignupRetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object check_validity, object raise_exception) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> SimpleVatCheckAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat_number) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> SnoozeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_snooze(self):
            // self.ensure_one()
            // my_next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // my_next_activity.action_snooze()
            // return True
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _sort_by_confidence_level(self, reverse=False):
            // """ Sorting the leads/opps according to the confidence level to it
            // being won. It is sorted following this incremental heuristics :
            // 
            //   * "not lost" first (inactive leads are lost); normally all leads
            //     should be active but in case lost one, they are always last.
            //     Inactive opportunities are considered as valid;
            //   * opportunity is more reliable than a lead which is a pre-stage
            //     used mainly for first classification;
            //   * stage sequence: the higher the better as it indicates we are moving
            //     towards won stage;
            //   * probability: the higher the better as it is more likely to be won;
            //   * ID: the higher the better when all other parameters are equal. We
            //     consider newer leads to be more reliable;
            // """
            // def opps_key(opportunity):
            //     return opportunity.type == 'opportunity' or opportunity.active,  \
            //         opportunity.type == 'opportunity', \
            //         opportunity.stage_id.sequence, \
            //         opportunity.probability, \
            //         -opportunity._origin.id
            // 
            // return self.sorted(key=opps_key, reverse=reverse)
            */
            return default;
        }

        public async Task<TEntity> SplitVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _stage_find(self, team_id=False, domain=None, order='sequence, id', limit=1):
            // """ Determine the stage of the current lead with its teams, the given domain and the given team_id
            //     :param team_id
            //     :param domain : base search domain for stage
            //     :param order : base search order for stage
            //     :param limit : base search limit for stage
            //     :returns crm.stage recordset
            // """
            // # collect all team_ids by adding given one, and the ones related to the current leads
            // team_ids = set()
            // if team_id:
            //     team_ids.add(team_id)
            // for lead in self:
            //     if lead.team_id:
            //         team_ids.add(lead.team_id.id)
            // # generate the domain
            // if team_ids:
            //     search_domain = ['|', ('team_id', '=', False), ('team_id', 'in', list(team_ids))]
            // else:
            //     search_domain = [('team_id', '=', False)]
            // # AND with the domain in parameter
            // if domain:
            //     search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['crm.stage'].search(search_domain, order=order, limit=limit)
            */
            return default;
        }

        protected async Task<object> ToStoreInternalAsync()
        {
            /*
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

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def toggle_active(self):
            // """ When archiving: mark probability as 0. When re-activating
            // update probability again, for leads and opportunities. """
            // res = super(Lead, self).toggle_active()
            // activated = self.filtered(lambda lead: lead.active)
            // archived = self.filtered(lambda lead: not lead.active)
            // if activated:
            //     activated.write({'lost_reason_id': False})
            //     activated._compute_probabilities()
            // if archived:
            //     archived.write({'probability': 0, 'automated_probability': 0})
            // return res
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values and self.probability == 100 and self.stage_id:
            //     return self.env.ref('crm.mt_lead_won')
            // elif 'lost_reason_id' in init_values and self.lost_reason_id:
            //     return self.env.ref('crm.mt_lead_lost')
            // elif 'stage_id' in init_values:
            //     return self.env.ref('crm.mt_lead_stage')
            // elif 'active' in init_values and self.active:
            //     return self.env.ref('crm.mt_lead_restored')
            // elif 'active' in init_values and not self.active:
            //     return self.env.ref('crm.mt_lead_lost')
            // return super(Lead, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _track_template(self, changes):
            // res = super(MailTestTicket, self)._track_template(changes)
            // record = self[0]
            // if 'customer_id' in changes and record.mail_template:
            //     res['customer_id'] = (
            //         record.mail_template,
            //         {
            //             'composition_mode': 'mass_mail',
            //             'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         }
            //     )
            // elif 'datetime' in changes:
            //     res['datetime'] = (
            //         'test_mail.mail_test_ticket_tracking_view',
            //         {
            //             'composition_mode': 'mass_mail',
            //             'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         }
            //     )
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def unlink(self):
            // """ Update meetings when removing opportunities, otherwise you have
            // a link to a record that does not lead anywhere. """
            // meetings = self.env['calendar.event'].search([
            //     ('res_id', 'in', self.ids),
            //     ('res_model', '=', self._name),
            // ])
            // if meetings:
            //     meetings.write({
            //         'res_id': False,
            //         'res_model_id': False,
            //     })
            // return super(Lead, self).unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLinkedEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _unlink_except_linked_employee(self):
            // if self.employee_id:
            //     raise UserError(_("The candidate is linked to an employee, to avoid losing information, archive it instead."))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> UnlinkIfPartnerInAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> UpdateAddressAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def update_address(self, vals):
            // addr_vals = {key: vals[key] for key in self._address_fields() if key in vals}
            // if addr_vals:
            //     return super().write(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _update_automated_probabilities(self):
            // """ Recompute all the automated_probability (and align probability if both were aligned) for all the leads
            // that are active (not won, nor lost).
            // 
            // For performance matter, as there can be a huge amount of leads to recompute, this cron proceed by batch.
            // Each batch is performed into its own transaction, in order to minimise the lock time on the lead table
            // (and to avoid complete lock if there was only 1 transaction that would last for too long -> several minutes).
            // If a concurrent update occurs, it will simply be put in the queue to get the lock.
            // """
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return
            // 
            // # 1. Get all the leads to recompute created after pls_start_date that are nor won nor lost
            // # (Won : probability = 100 | Lost : probability = 0 or inactive. Here, inactive won't be returned anyway)
            // # Get also all the lead without probability --> These are the new leads. Activate auto probability on them.
            // pending_lead_domain = [
            //     '&',
            //         '&',
            //             ('stage_id', '!=', False), ('create_date', '>=', pls_start_date),
            //         '|',
            //             ('probability', '=', False),
            //             '&',
            //                 ('probability', '<', 100), ('probability', '>', 0)
            // ]
            // leads_to_update = self.env['crm.lead'].search(pending_lead_domain)
            // leads_to_update_count = len(leads_to_update)
            // 
            // # 2. Compute by batch to avoid memory error
            // lead_probabilities = {}
            // for i in range(0, leads_to_update_count, PLS_COMPUTE_BATCH_STEP):
            //     leads_to_update_part = leads_to_update[i:i + PLS_COMPUTE_BATCH_STEP]
            //     lead_probabilities.update(leads_to_update_part._pls_get_naive_bayes_probabilities(batch_mode=True))
            // _logger.info("Predictive Lead Scoring : New automated probabilities computed")
            // 
            // # 3. Group by new probability to reduce server roundtrips when executing the update
            // probability_leads = defaultdict(list)
            // for lead_id, probability in sorted(lead_probabilities.items()):
            //     probability_leads[probability].append(lead_id)
            // 
            // # 4. Update automated_probability (+ probability if both were equal)
            // update_sql = """UPDATE crm_lead
            //                 SET automated_probability = %s,
            //                     probability = CASE WHEN (probability = automated_probability OR probability is null)
            //                                        THEN (%s)
            //                                        ELSE (probability)
            //                                   END
            //                 WHERE id in %s"""
            // 
            // # Update by a maximum number of leads at the same time, one batch by transaction :
            // # - avoid memory errors
            // # - avoid blocking the table for too long with a too big transaction
            // transactions_count, transactions_failed_count = 0, 0
            // cron_update_lead_start_date = datetime.now()
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // self.flush_model()
            // for probability, probability_lead_ids in probability_leads.items():
            //     for lead_ids_current in tools.split_every(PLS_UPDATE_BATCH_STEP, probability_lead_ids):
            //         transactions_count += 1
            //         try:
            //             self.env.cr.execute(update_sql, (probability, probability, tuple(lead_ids_current)))
            //             # auto-commit except in testing mode
            //             if auto_commit:
            //                 self.env.cr.commit()
            //         except Exception as e:
            //             _logger.warning("Predictive Lead Scoring : update transaction failed. Error: %s" % e)
            //             transactions_failed_count += 1
            // self.invalidate_model()
            // 
            // _logger.info(
            //     "Predictive Lead Scoring : All automated probabilities updated (%d leads / %d transactions (%d failed) / %d seconds)" % (
            //         leads_to_update_count,
            //         transactions_count,
            //         transactions_failed_count,
            //         (datetime.now() - cron_update_lead_start_date).total_seconds(),
            //     )
            // )
            */
            return default;
        }

        public async Task<TEntity> UpdateFieldsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> UpdatePeppolStatePerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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

        public async Task<TEntity> UpdateStateAsPerGstinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_in, FILE: res_partner.py) ---
            // def action_update_state_as_per_gstin(self):
            // self.ensure_one()
            // state_id = self.env['res.country.state'].search([('l10n_in_tin', '=', self.vat[:2])], limit=1)
            // self.state_id = state_id
            // if self.ref_company_ids:
            //     self.ref_company_ids._update_l10n_in_fiscal_position()
            */
            return default;
        }

        public async Task<TEntity> ValidateCodiceFiscaleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: res_partner.py) ---
            // def validate_codice_fiscale(self):
            // for record in self:
            //     if record.l10n_it_codice_fiscale and (not codicefiscale.is_valid(record.l10n_it_codice_fiscale) and not iva.is_valid(record.l10n_it_codice_fiscale)):
            //         raise UserError(_("Invalid Codice Fiscale '%s': should be like 'MRTMTT91D08F205J' for physical person and '12345670546' for businesses.", record.l10n_it_codice_fiscale))
            */
            return default;
        }

        public async Task<TEntity> ValidateL10nEsEdiFacturaeAcLogicalOperationalPointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: res_partner.py) ---
            // def _validate_l10n_es_edi_facturae_ac_logical_operational_point(self):
            // for p in self:
            //     if not p.l10n_es_edi_facturae_ac_logical_operational_point:
            //         continue
            //     if not check_barcode_encoding(p.l10n_es_edi_facturae_ac_logical_operational_point, 'ean13'):
            //         raise ValidationError(_('The Logical Operational Point entered is not valid.'))
            */
            return default;
        }

        public async Task<TEntity> ValidateL10nEsEdiFacturaeAcPhysicalGlnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: res_partner.py) ---
            // def _validate_l10n_es_edi_facturae_ac_physical_gln(self):
            // for p in self:
            //     if not p.l10n_es_edi_facturae_ac_physical_gln:
            //         continue
            //     if not check_barcode_encoding(p.l10n_es_edi_facturae_ac_physical_gln, 'ean13'):
            //         raise ValidationError(_('The Physical GLN entered is not valid.'))
            */
            return default;
        }

        public async Task<TEntity> ValidateTinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: res_partner.py) ---
            // def action_validate_tin(self):
            // """ Calling this action will reach our EDI proxy in order to validate the TIN against the provided identification information. """
            // self.ensure_one()
            // if not self._l10n_my_edi_get_tin_for_myinvois() or not self.l10n_my_identification_type or not self.l10n_my_identification_number:
            //     raise UserError(_('In order to validate the TIN, you must provide the Identification type and number.'))
            // 
            // # Sudo to allow a user without access to the proxy user to validate the ID if needed.
            // proxy_user = self.env.company.sudo().l10n_my_edi_proxy_user_id
            // if not proxy_user:
            //     raise UserError(_("Please register for the E-Invoicing service in the settings first."))
            // 
            // response = proxy_user._l10n_my_edi_contact_proxy('api/l10n_my_edi/1/validate_tin', params={
            //     'identification_values': {
            //         'tin': self._l10n_my_edi_get_tin_for_myinvois(),
            //         'id_type': self.l10n_my_identification_type,
            //         'id_val': self.l10n_my_identification_number,
            //     }
            // })
            // 
            // if 'error' in response:
            //     ref = response['error']['reference']
            //     # No need to rollback, we don't want to be blocking on that.
            //     if ref == 'document_tin_not_found':
            //         self._message_log(body=_('MyInvois was not able to match the TIN with the provided identification number.\nThis may happen when using generic TIN and will not prevent you from invoicing.'))
            //         self.l10n_my_tin_validation_state = 'invalid'
            //     else:
            //         self._message_log(body=_('An unexpected error occurred while validating the TIN. Please try again later.'))
            // else:
            //     self.l10n_my_tin_validation_state = 'valid' if response.get('success') else 'invalid'
            */
            return default;
        }

        public async Task<TEntity> ViewCertificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewCoursesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewOpportunityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewPartnerInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewPartnerWithSameBankAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewPosOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_partner.py) ---
            // def action_view_sale_order(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('sale.act_res_partner_2_sale_order')
            // all_child = self.with_context(active_test=False).search([('id', 'child_of', self.ids)])
            // action["domain"] = [("partner_id", "in", all_child.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ViewStockLotsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> ViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def write(self, vals):
            // if vals.get('website'):
            //     vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // 
            // now = self.env.cr.now()
            // stage_updated, stage_is_won = False, False
            // # stage change (or reset): update date_last_stage_update if at least one
            // # lead does not have the same stage
            // if 'stage_id' in vals:
            //     stage_updated = any(lead.stage_id.id != vals['stage_id'] for lead in self)
            //     if stage_updated:
            //         vals['date_last_stage_update'] = now
            //     if stage_updated and vals.get('stage_id'):
            //         stage = self.env['crm.stage'].browse(vals['stage_id'])
            //         if stage.is_won:
            //             vals.update({'probability': 100, 'automated_probability': 100})
            //             stage_is_won = True
            // # user change; update date_open if at least one lead does not
            // # have the same user
            // if 'user_id' in vals and not vals.get('user_id'):
            //     vals['date_open'] = False
            // elif vals.get('user_id'):
            //     user_updated = any(lead.user_id.id != vals['user_id'] for lead in self)
            //     if user_updated:
            //         vals['date_open'] = now
            // 
            // # stage change with new stage: update probability and date_closed
            // if vals.get('probability', 0) >= 100 or not vals.get('active', True):
            //     vals['date_closed'] = fields.Datetime.now()
            // elif vals.get('probability', 0) > 0:
            //     vals['date_closed'] = False
            // elif stage_updated and not stage_is_won and not 'probability' in vals:
            //     vals['date_closed'] = False
            // 
            // if any(field in ['active', 'stage_id'] for field in vals):
            //     self._handle_won_lost(vals)
            // 
            // if not stage_is_won:
            //     return super(Lead, self).write(vals)
            // 
            // # stage change between two won stages: does not change the date_closed
            // leads_already_won = self.filtered(lambda lead: lead.stage_id.is_won)
            // remaining = self - leads_already_won
            // if remaining:
            //     result = super(Lead, remaining).write(vals)
            // if leads_already_won:
            //     vals.pop('date_closed', False)
            //     result = super(Lead, leads_already_won).write(vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // 
            // if vals.get("company_id") and not self.env.context.get('do_not_propagate_company', False):
            //     self.applicant_ids.with_context(do_not_propagate_company=True).write({"company_id": vals["company_id"]})
            // return res
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadBlacklistable
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