using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class ResPartnerBankAppService : GenericApplicationService<ResPartnerBank>, IResPartnerBankAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public ResPartnerBankAppService(IRepository<ResPartnerBank, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<ResPartnerBank> ArchiveBankAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def action_archive_bank(self):
            // """
            //     Custom archive function because the basic action_archive don't trigger a re-rendering of the page, so
            //     the archived value is still visible in the view.
            // """
            // self.ensure_one()
            // self.action_archive()
            // return {'type': 'ir.actions.client', 'tag': 'reload'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartnerBank> BuildQrCodeBase64Async(Guid id, ResPartnerBankBuildQrCodeBase64RequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def build_qr_code_base64(self, amount, free_communication, structured_communication, currency, debtor_partner, qr_method=None, silent_errors=True):
            // vals = self._build_qr_code_vals(amount, free_communication, structured_communication, currency, debtor_partner, qr_method, silent_errors)
            // if vals:
            //     return self._get_qr_code_base64(**vals)
            // return None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResPartnerBank> BuildQrCodeUrlAsync(Guid id, ResPartnerBankBuildQrCodeUrlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def build_qr_code_url(self, amount, free_communication, structured_communication, currency, debtor_partner, qr_method=None, silent_errors=True):
            // vals = self._build_qr_code_vals(amount, free_communication, structured_communication, currency, debtor_partner, qr_method, silent_errors)
            // if vals:
            //     return self._get_qr_code_url(**vals)
            // return None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartnerBank> BuildQrCodeValsInternalAsync(object amount, object free_communication, object structured_communication, object currency, object debtor_partner, object qr_method, object silent_errors)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _build_qr_code_vals(self, amount, free_communication, structured_communication, currency, debtor_partner, qr_method=None, silent_errors=True):
            // """ Returns the QR-code vals needed to generate the QR-code report link to pay this account with the given parameters,
            // or None if no QR-code could be generated.
            // 
            // :param amount: The amount to be paid
            // :param free_communication: Free communication to add to the payment when generating one with the QR-code
            // :param structured_communication: Structured communication to add to the payment when generating one with the QR-code
            // :param currency: The currency in which amount is expressed
            // :param debtor_partner: The partner to which this QR-code is aimed (so the one who will have to pay)
            // :param qr_method: The QR generation method to be used to make the QR-code. If None, the first one giving a result will be used.
            // :param silent_errors: If true, forbids errors to be raised if some tested QR-code format can't be generated because of incorrect data.
            // """
            // if not self:
            //     return None
            // 
            // self.ensure_one()
            // if not currency:
            //     raise UserError(_("Currency must always be provided in order to generate a QR-code"))
            // 
            // available_qr_methods = self.get_available_qr_methods_in_sequence()
            // candidate_methods = qr_method and [(qr_method, dict(available_qr_methods)[qr_method])] or available_qr_methods
            // for candidate_method, candidate_name in candidate_methods:
            //     error_message = self._get_error_messages_for_qr(candidate_method, debtor_partner, currency)
            //     if not error_message:
            //         error_message = self._check_for_qr_code_errors(candidate_method, amount, currency, debtor_partner, free_communication, structured_communication)
            // 
            //         if not error_message:
            //             return {
            //                 'qr_method': candidate_method,
            //                 'amount': amount,
            //                 'currency': currency,
            //                 'debtor_partner': debtor_partner,
            //                 'free_communication': free_communication,
            //                 'structured_communication': structured_communication,
            //             }
            // 
            //     if not silent_errors:
            //         error_header = _("The following error prevented '%s' QR-code to be generated though it was detected as eligible: ", candidate_name)
            //         raise UserError(error_header + error_message)
            // 
            // return None
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckAllowOutPaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _check_allow_out_payment(self):
            // """ Block enabling the setting, but it can be set to false without the group. (For example, at creation) """
            // for bank in self:
            //     if bank.allow_out_payment:
            //         if not self.env.user.has_group('account.group_validate_bank_account'):
            //             raise ValidationError(_('You do not have the right to trust or un-trust a bank account.'))
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckForQrCodeErrorsInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _check_for_qr_code_errors(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // """ Checks the data before generating a QR-code for the specified qr_method
            // (this method must have been checked for eligbility by _get_error_messages_for_qr() first).
            // 
            // Returns None if no error was found, or a string describing the first error encountered
            // so that it can be reported to the user.
            // """
            // return None
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _check_for_qr_code_errors(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // if qr_method == 'emv_qr':
            //     if not self._get_merchant_account_info():
            //         return _("Missing Merchant Account Information.")
            //     if not self.partner_id.city:
            //         return _("Missing Merchant City.")
            //     if not self.proxy_type:
            //         return _("Missing Proxy Type.")
            //     if not self.proxy_value:
            //         return _("Missing Proxy Value.")
            // return super()._check_for_qr_code_errors(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py) ---
            // def _check_for_qr_code_errors(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // if qr_method == 'sct_qr':
            //     if not self.acc_holder_name and not self.partner_id.name:
            //         return _("The account receiving the payment must have an account holder name or partner name set.")
            // 
            // return super()._check_for_qr_code_errors(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            */
            return default;
        }

        public async Task<ResPartnerBank> CheckIbanAsync(Guid id, ResPartnerBankCheckIbanRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def check_iban(self, iban=''):
            // try:
            //     validate_iban(iban)
            //     return True
            // except ValidationError:
            //     return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartnerBank> CheckIbanInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def _check_iban(self):
            // for bank in self:
            //     if bank.acc_type == 'iban':
            //         validate_iban(bank.acc_number)
            */
            return default;
        }

        protected async Task<ResPartnerBank> CheckJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _check_journal_id(self):
            // for bank in self:
            //     if len(bank.journal_id) > 1:
            //         raise ValidationError(_('A bank account can belong to only one journal.'))
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeAccTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def _compute_acc_type(self):
            // for bank in self:
            //     bank.acc_type = self.retrieve_acc_type(bank.acc_number)
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeAccountHolderNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def _compute_account_holder_name(self):
            // for bank in self:
            //     bank.acc_holder_name = bank.partner_id.name
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDisplayAccountWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _compute_display_account_warning(self):
            // for bank in self:
            //     if bank.allow_out_payment or not bank.sanitized_acc_number or bank.acc_type != 'iban':
            //         bank.has_iban_warning = False
            //         bank.has_money_transfer_warning = False
            //         continue
            //     bank_country = bank.sanitized_acc_number[:2]
            //     bank.has_iban_warning = bank.partner_id.country_id and bank_country != bank.partner_id.country_id.code
            // 
            //     bank_institution_code = bank.sanitized_acc_number[4:7]
            //     bank.has_money_transfer_warning = bank_institution_code in bank._get_money_transfer_services()
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // if self.env.context.get('display_account_trust'):
            //     for acc in self:
            //         trusted_label = _('trusted') if acc.allow_out_payment else _('untrusted')
            //         if acc.bank_id:
            //             name = f'{acc.acc_number} - {acc.bank_id.name} ({trusted_label})'
            //         else:
            //             name = f'{acc.acc_number} ({trusted_label})'
            //         acc.display_name = name
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // account_employee = self.browse()
            // if not self.env.user.has_group('hr.group_hr_user'):
            //     account_employee = self.sudo().filtered("partner_id.employee_ids")
            //     for account in account_employee:
            //         account.sudo(self.env.su).display_name = \
            //             account.acc_number[:2] + "*" * len(account.acc_number[2:-4]) + account.acc_number[-4:]
            // super(ResPartnerBank, self - account_employee)._compute_display_name()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def _compute_display_name(self):
            // for acc in self:
            //     acc.display_name = f'{acc.acc_number} - {acc.bank_id.name}' if acc.bank_id else acc.acc_number
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDisplayQrSettingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _compute_display_qr_setting(self):
            // self.display_qr_setting = False
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeDuplicateBankPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _compute_duplicate_bank_partner_ids(self):
            // id2duplicates = dict(self.env.execute_query(SQL(
            //     """
            //         SELECT this.id,
            //                ARRAY_AGG(other.partner_id)
            //           FROM res_partner_bank this
            //      LEFT JOIN res_partner_bank other ON this.acc_number = other.acc_number
            //                                      AND this.id != other.id
            //          WHERE this.id = ANY(%(ids)s)
            //            AND (
            //                 ((this.company_id = other.company_id) OR (this.company_id IS NULL AND other.company_id IS NULL))
            //                 OR
            //                 other.company_id IS NULL
            //                 )
            //       GROUP BY this.id
            //     """,
            //     ids=self.ids,
            // )))
            // for bank in self:
            //     bank.duplicate_bank_partner_ids = self.env['res.partner'].browse(id2duplicates.get(bank._origin.id))
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeLockTrustFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _compute_lock_trust_fields(self):
            // for bank in self:
            //     if not bank._origin or not bank.allow_out_payment:
            //         bank.lock_trust_fields = False
            //     elif bank._origin and bank.allow_out_payment:
            //         bank.lock_trust_fields = True
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeMoneyTransferServiceNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _compute_money_transfer_service_name(self):
            // for bank in self:
            //     if bank.sanitized_acc_number:
            //         bank_institution_code = bank.sanitized_acc_number[4:7]
            //         bank.money_transfer_service = bank._get_money_transfer_services().get(bank_institution_code, False)
            //     else:
            //         bank.money_transfer_service = False
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeSanitizedAccNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def _compute_sanitized_acc_number(self):
            // for bank in self:
            //     bank.sanitized_acc_number = sanitize_account_number(bank.acc_number)
            */
            return default;
        }

        protected async Task<ResPartnerBank> ComputeUserHasGroupValidateBankAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _compute_user_has_group_validate_bank_account(self):
            // user_has_group_validate_bank_account = self.env.user.has_group('account.group_validate_bank_account')
            // for bank in self:
            //     bank.user_has_group_validate_bank_account = user_has_group_validate_bank_account
            */
            return default;
        }

        protected async Task<object> ConditionToSqlInternalAsync(string @alias, string fname, string @operator, object @value, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def _condition_to_sql(self, alias: str, fname: str, operator: str, value, query) -> SQL:
            // if fname == 'acc_number':
            //     fname = 'sanitized_acc_number'
            //     if not isinstance(value, str) and isinstance(value, Iterable):
            //         value = [sanitize_account_number(i) for i in value]
            //     else:
            //         value = sanitize_account_number(value)
            // return super()._condition_to_sql(alias, fname, operator, value, query)
            */
            return default;
        }

        public override async Task<ResPartnerBank> CreateAsync(ResPartnerBank entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def create(self, vals_list):
            // # EXTENDS base res.partner.bank
            // 
            // if not self.env.user.has_group('account.group_validate_bank_account'):
            //     for vals in vals_list:
            //         # force the allow_out_payment field to False in order to prevent scam payments on newly created bank accounts
            //         vals['allow_out_payment'] = False
            // 
            // for vals in vals_list:
            //     if (partner_id := vals.get('partner_id')) and (acc_number := vals.get('acc_number')):
            //         archived_res_partner_bank = self.env['res.partner.bank'].search([('active', '=', False), ('partner_id', '=', partner_id), ('acc_number', '=', acc_number)])
            //         if archived_res_partner_bank:
            //             raise UserError(_("A bank account with Account Number %(number)s already exists for Partner %(partner)s, but is archived. Please unarchive it instead.", number=acc_number, partner=archived_res_partner_bank.partner_id.name))
            // 
            // res = super().create(vals_list)
            // for account in res:
            //     msg = _("Bank Account %s created", account._get_html_link(title=f"#{account.id}"))
            //     account.partner_id._message_log(body=msg)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('acc_number'):
            //         try:
            //             validate_iban(vals['acc_number'])
            //             vals['acc_number'] = pretty_iban(normalize_iban(vals['acc_number']))
            //         except ValidationError:
            //             pass
            // return super(ResPartnerBank, self).create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public override async Task<ResPartnerBank> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def default_get(self, fields_list):
            // if 'acc_number' not in fields_list:
            //     return super().default_get(fields_list)
            // 
            // # When create & edit, `name` could be used to pass (in the context) the
            // # value input by the user. However, we want to set the default value of
            // # `acc_number` variable instead.
            // default_acc_number = self._context.get('default_acc_number', False) or self._context.get('default_name', False)
            // return super(ResPartnerBank, self.with_context(default_acc_number=default_acc_number)).default_get(fields_list)
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<ResPartnerBank> GetAdditionalDataFieldInternalAsync(object comment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_additional_data_field(self, comment):
            // return None
            */
            return default;
        }

        public async Task<ResPartnerBank> GetAvailableQrMethodsInSequenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def get_available_qr_methods_in_sequence(self):
            // """ Same as _get_available_qr_methods but without returning the sequence,
            // and using it directly to order the returned list.
            // """
            // all_available = self._get_available_qr_methods()
            // all_available.sort(key=lambda x: x[2])
            // return [(code, name) for (code, name, sequence) in all_available]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartnerBank> GetAvailableQrMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_available_qr_methods(self):
            // """ Returns the QR-code generation methods that are available on this db,
            // in the form of a list of (code, name, sequence) elements, where
            // 'code' is a unique string identifier, 'name' the name to display
            // to the user to designate the method, and 'sequence' is a positive integer
            // indicating the order in which those mehtods need to be checked, to avoid
            // shadowing between them (lower sequence means more prioritary).
            // """
            // return []
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_available_qr_methods(self):
            // rslt = super()._get_available_qr_methods()
            // rslt.append(('emv_qr', _("EMV Merchant-Presented QR-code"), 30))
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py) ---
            // def _get_available_qr_methods(self):
            // rslt = super()._get_available_qr_methods()
            // rslt.append(('sct_qr', _("SEPA Credit Transfer QR"), 20))
            // return rslt
            */
            return default;
        }

        public async Task<ResPartnerBank> GetBbanAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def get_bban(self):
            // if self.acc_type != 'iban':
            //     raise UserError(self.env._("Cannot compute the BBAN because the account number is not an IBAN."))
            // return get_bban_from_iban(self.acc_number)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartnerBank> GetCrc16InternalAsync(object data, object poly, object init)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_crc16(self, data, poly=0x1021, init=0xFFFF):
            // crc = init
            // for byte in data:
            //     crc = crc ^ (byte << 8)
            //     for __ in range(8):
            //         if crc & 0x8000:
            //             crc = (crc << 1) ^ poly
            //         else:
            //             crc = crc << 1
            // return crc & 0xFFFF
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetErrorMessagesForQrInternalAsync(object qr_method, object debtor_partner, object currency)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_error_messages_for_qr(self, qr_method, debtor_partner, currency):
            // """ Tells whether or not the criteria to apply QR-generation
            // method qr_method are met for a payment on this account, in the
            // given currency, by debtor_partner. This does not impeach generation errors,
            // it only checks that this type of QR-code *should be* possible to generate.
            // If not, returns an adequate error message to be displayed to the user if need be.
            // Consistency of the required field needs then to be checked by _check_for_qr_code_errors().
            // :returns:  None if the qr method is eligible, or the error message
            // """
            // return None
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_error_messages_for_qr(self, qr_method, debtor_partner, currency):
            // """ Return an error for emv_qr if the account's country does no match any methods found in inheriting modules."""
            // if qr_method == 'emv_qr':
            //     if not self:
            //         return _("A bank account is required for EMV QR Code generation.")
            //     return _("No EMV QR Code is available for the country of the account %(account_number)s.", account_number=self.acc_number)
            // 
            // return super()._get_error_messages_for_qr(qr_method, debtor_partner, currency)
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py) ---
            // def _get_error_messages_for_qr(self, qr_method, debtor_partner, currency):
            // if qr_method == 'sct_qr':
            //     # Some countries share the same IBAN country code
            //     # (e.g. Åland Islands and Finland IBANs are 'FI', but Åland Islands' code is 'AX').
            //     sepa_country_codes = self.env.ref('base.sepa_zone').country_ids.mapped('code')
            //     non_iban_codes = {'AX', 'NC', 'YT', 'TF', 'BL', 'RE', 'MF', 'GP', 'PM', 'PF', 'GF', 'MQ', 'JE', 'GG', 'IM'}
            //     sepa_iban_codes = {code for code in sepa_country_codes if code not in non_iban_codes}
            //     error_messages = []
            //     if currency.name != 'EUR':
            //         error_messages.append(_("Can't generate a SEPA QR Code with the %s currency.", currency.name))
            //     if self.acc_type != 'iban':
            //         error_messages.append(_("Can't generate a SEPA QR code if the account type isn't IBAN."))
            //     if not (self.sanitized_acc_number and self.sanitized_acc_number[:2] in sepa_iban_codes):
            //         error_messages.append(_("Can't generate a SEPA QR code with a non SEPA iban."))
            //     if len(error_messages) > 0:
            //         return '\r\n'.join(error_messages)
            //     return None
            // return super()._get_error_messages_for_qr(qr_method, debtor_partner, currency)
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetMerchantAccountInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_merchant_account_info(self):
            // return None, None
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetMoneyTransferServicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_money_transfer_services(self):
            // return {
            //     '967': 'Wise',
            //     '977': 'Paynovate',
            //     '974': 'PPS EU SA',
            // }
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeBase64InternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_qr_code_base64(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // """ Hook for extension, to support the different QR generation methods.
            // This function uses the provided qr_method to try generation a QR-code for
            // the given data. It it succeeds, it returns QR code in base64 url; else None.
            // 
            // :param qr_method: The QR generation method to be used to make the QR-code.
            // :param amount: The amount to be paid
            // :param currency: The currency in which amount is expressed
            // :param debtor_partner: The partner to which this QR-code is aimed (so the one who will have to pay)
            // :param free_communication: Free communication to add to the payment when generating one with the QR-code
            // :param structured_communication: Structured communication to add to the payment when generating one with the QR-code
            // """
            // params = self._get_qr_code_generation_params(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            // if params:
            //     try:
            //         barcode = self.env['ir.actions.report'].barcode(**params)
            //     except (ValueError, AttributeError):
            //         raise werkzeug.exceptions.HTTPException(description='Cannot convert into barcode.')
            //     return image_data_uri(base64.b64encode(barcode))
            // return None
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeGenerationParamsInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_qr_code_generation_params(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // raise NotImplementedError()
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_qr_code_generation_params(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // if qr_method == 'emv_qr':
            //     return {
            //         'barcode_type': 'QR',
            //         'width': 128,
            //         'height': 128,
            //         'humanreadable': 1,
            //         'value': self._get_qr_vals(qr_method, amount, currency, debtor_partner, free_communication, structured_communication),
            //     }
            // return super()._get_qr_code_generation_params(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py) ---
            // def _get_qr_code_generation_params(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // if qr_method == 'sct_qr':
            //     return {
            //         'barcode_type': 'QR',
            //         'width': 128,
            //         'height': 128,
            //         'humanreadable': 1,
            //         'value': '\n'.join(self._get_qr_vals(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)),
            //     }
            // return super()._get_qr_code_generation_params(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeUrlInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_qr_code_url(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // """ Hook for extension, to support the different QR generation methods.
            // This function uses the provided qr_method to try generation a QR-code for
            // the given data. It it succeeds, it returns the report URL to make this
            // QR-code; else None.
            // 
            // :param qr_method: The QR generation method to be used to make the QR-code.
            // :param amount: The amount to be paid
            // :param currency: The currency in which amount is expressed
            // :param debtor_partner: The partner to which this QR-code is aimed (so the one who will have to pay)
            // :param free_communication: Free communication to add to the payment when generating one with the QR-code
            // :param structured_communication: Structured communication to add to the payment when generating one with the QR-code
            // """
            // params = self._get_qr_code_generation_params(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            // return '/report/barcode/?' + werkzeug.urls.url_encode(params) if params else None
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrCodeValsListInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_qr_code_vals_list(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // tag, merchant_account_info = self._get_merchant_account_info()
            // currency_code = CURRENCY_MAPPING[currency.name]
            // if not currency.is_zero(amount):
            //     amount = amount.is_integer() and int(amount) or amount
            // else:
            //     amount = None
            // merchant_name = self.partner_id.name and self._remove_accents(self.partner_id.name)[:25] or 'NA'
            // merchant_city = self.partner_id.city and self._remove_accents(self.partner_id.city)[:15] or ''
            // comment = structured_communication or free_communication or ''
            // comment = re.sub(r'[^ A-Za-z0-9_@.\\/#&+-]+', '', self._remove_accents(comment))
            // additional_data_field = self._get_additional_data_field(comment) if self.include_reference else None
            // return [
            //     (0, '01'),                                                              # Payload Format Indicator
            //     (1, '12'),                                                              # Dynamic QR Codes
            //     (tag, merchant_account_info),                                           # Merchant Account Information
            //     (52, '0000'),                                                           # Merchant Category Code
            //     (53, currency_code),                                                    # Transaction Currency
            //     (54, amount),                                                           # Transaction Amount
            //     (58, self.country_code),                                                # Country Code
            //     (59, merchant_name),                                                    # Merchant Name
            //     (60, merchant_city),                                                    # Merchant City
            //     (62, additional_data_field),                                            # Additional Data Field
            // ]
            */
            return default;
        }

        protected async Task<ResPartnerBank> GetQrValsInternalAsync(object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def _get_qr_vals(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // return None
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _get_qr_vals(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // if qr_method == 'emv_qr':
            //     qr_code_vals = self._get_qr_code_vals_list(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            //     qr_code_str = ''.join([self._serialize(*val) for val in qr_code_vals])
            //     qr_code_str += '6304'                                                   # CRC16
            //     crc = self._get_crc16(bytes(qr_code_str, 'utf-8'))
            //     qr_code_str += format(crc, '04x').upper()
            //     return qr_code_str
            // 
            // return super()._get_qr_vals(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_sepa, FILE: res_bank.py) ---
            // def _get_qr_vals(self, qr_method, amount, currency, debtor_partner, free_communication, structured_communication):
            // if qr_method == 'sct_qr':
            //     if structured_communication and is_valid_structured_reference(structured_communication):
            //         structured_communication = sanitize_structured_reference(structured_communication)
            //         comment = ''
            //     else:
            //         structured_communication = ''
            //         comment = free_communication or ''
            // 
            //     qr_code_vals = [
            //         'BCD',                                                  # Service Tag
            //         '002',                                                  # Version
            //         '1',                                                    # Character Set
            //         'SCT',                                                  # Identification Code
            //         self.bank_bic or '',                                    # BIC of the Beneficiary Bank
            //         (self.acc_holder_name or self.partner_id.name)[:71],    # Name of the Beneficiary
            //         self.sanitized_acc_number,                              # Account Number of the Beneficiary
            //         currency.name + str(amount),                            # Currency + Amount of the Transfer in EUR
            //         '',                                                     # Purpose of the Transfer
            //         structured_communication,                               # Remittance Information (Structured)
            //         comment[:141],                                          # Remittance Information (Unstructured) (can't be set if there is a structured one)
            //         '',                                                     # Beneficiary to Originator Information
            //     ]
            //     return qr_code_vals
            // return super()._get_qr_vals(qr_method, amount, currency, debtor_partner, free_communication, structured_communication)
            */
            return default;
        }

        public async Task<ResPartnerBank> GetSupportedAccountTypesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def get_supported_account_types(self):
            // return self._get_supported_account_types()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartnerBank> GetSupportedAccountTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def _get_supported_account_types(self):
            // rslt = super(ResPartnerBank, self)._get_supported_account_types()
            // rslt.append(('iban', self.env._('IBAN')))
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def _get_supported_account_types(self):
            // return [('bank', _('Normal'))]
            */
            return default;
        }

        protected async Task<ResPartnerBank> RemoveAccentsInternalAsync(object @string)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _remove_accents(self, string):
            // return remove_accents(string).replace('đ', 'd').replace('Đ', 'D')
            */
            return default;
        }

        public async Task<ResPartnerBank> RetrieveAccTypeAsync(Guid id, ResPartnerBankRetrieveAccTypeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def retrieve_acc_type(self, acc_number):
            // try:
            //     validate_iban(acc_number)
            //     return 'iban'
            // except ValidationError:
            //     return super(ResPartnerBank, self).retrieve_acc_type(acc_number)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def retrieve_acc_type(self, acc_number):
            // """ To be overridden by subclasses in order to support other account_types.
            // """
            // return 'bank'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResPartnerBank> SerializeInternalAsync(object header, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py) ---
            // def _serialize(self, header, value):
            // if value is not None and value != '':
            //     return f'{header:02}{len(str(value)):02}{value}'
            // else:
            //     return ''
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def unlink(self):
            // # EXTENDS base res.partner.bank
            // for account in self:
            //     msg = _("Bank Account %(link)s with number %(number)s archived", link=account._get_html_link(title=f"#{account.id}"), number=account.acc_number)
            //     account.partner_id._message_log(body=msg)
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_bank.py) ---
            // def unlink(self):
            // """
            //     Instead of deleting a bank account, we want to archive it since we cannot delete bank account that is linked
            //     to any entries
            // """
            // self.action_archive()
            // return True
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResPartnerBank entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py) ---
            // def write(self, vals):
            // # EXTENDS base res.partner.bank
            // # Track and log changes to partner_id, heavily inspired from account_move
            // account_initial_values = defaultdict(dict)
            // # Get all tracked fields (without related fields because these fields must be managed on their own model)
            // tracking_fields = []
            // for field_name in vals:
            //     field = self._fields[field_name]
            //     if not (hasattr(field, 'related') and field.related) and hasattr(field, 'tracking') and field.tracking:
            //         tracking_fields.append(field_name)
            // fields_definition = self.env['res.partner.bank'].fields_get(tracking_fields)
            // 
            // # Get initial values for each account
            // for account in self:
            //     for field in tracking_fields:
            //         # Group initial values by partner_id
            //         account_initial_values[account][field] = account[field]
            // 
            // # Some fields should not be editable based on conditions. It is enforced in the view, but not in python which
            // # leaves them vulnerable to edits via the shell/... So we need to ensure that the user has the rights to edit
            // # these fields when writing too.
            // # While we do lock changes if the account is trusted, we still want to allow to change them if we go from not trusted -> trusted or from trusted -> not trusted.
            // any_trusted_accounts = any(account.lock_trust_fields for account in self)
            // if not any_trusted_accounts:
            //     should_allow_changes = True  # If we were on a non-trusted account, we will allow to change (setting/... one last time before trusting)
            // else:
            //     # If we were on a trusted account, we only allow changes if the account is moving to untrusted.
            //     should_allow_changes = ('allow_out_payment' in vals and vals['allow_out_payment'] is False)
            // 
            // if ('acc_number' in vals or 'partner_id' in vals) and not should_allow_changes:
            //     raise UserError(_("You cannot modify the account number or partner of an account that has been trusted."))
            // 
            // if 'allow_out_payment' in vals and not self.env.user.has_group('account.group_validate_bank_account'):
            //     raise UserError(_("You do not have the rights to trust or un-trust accounts."))
            // 
            // res = super().write(vals)
            // 
            // # Log changes to move lines on each move
            // for account, initial_values in account_initial_values.items():
            //     tracking_value_ids = account._mail_track(fields_definition, initial_values)[1]
            //     if tracking_value_ids:
            //         msg = _("Bank Account %s updated", account._get_html_link(title=f"#{account.id}"))
            //         account.partner_id._message_log(body=msg, tracking_value_ids=tracking_value_ids)
            //         if 'partner_id' in initial_values:  # notify previous partner as well
            //             initial_values['partner_id']._message_log(body=msg, tracking_value_ids=tracking_value_ids)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py) ---
            // def write(self, vals):
            // if vals.get('acc_number'):
            //     try:
            //         validate_iban(vals['acc_number'])
            //         vals['acc_number'] = pretty_iban(normalize_iban(vals['acc_number']))
            //     except ValidationError:
            //         pass
            // return super(ResPartnerBank, self).write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}