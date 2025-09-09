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
    [Module("PointOfSale", Depends = new[] { "stock_account", "barcodes", "web_editor", "digest", "phone_validation" })]
    public class PosPaymentMethodAppService : GenericApplicationService<PosPaymentMethod>, IPosPaymentMethodAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosPaymentMethodAppService(IRepository<PosPaymentMethod, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<PosPaymentMethod> BearerTokenInternalAsync(object session)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _bearer_token(self, session):
            // self.ensure_one()
            // 
            // data = {'grant_type': 'client_credentials'}
            // auth = requests.auth.HTTPBasicAuth(self.viva_wallet_client_id, self.viva_wallet_client_secret)
            // try:
            //     resp = session.post(f"{self._viva_wallet_account_get_endpoint()}/connect/token", auth=auth, data=data, timeout=TIMEOUT)
            // except requests.exceptions.RequestException:
            //     _logger.exception("Failed to call viva_wallet_bearer_token endpoint")
            // 
            // access_token = resp.json().get('access_token')
            // if access_token:
            //     self.viva_wallet_bearer_token = access_token
            //     return {'Authorization': f"Bearer {access_token}"}
            // else:
            //     raise UserError(_('Unable to retrieve Viva Wallet Bearer Token: Please verify that the Client ID and Client Secret are correct'))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CallVivaWalletInternalAsync(object endpoint, object action, object data, object should_retry)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _call_viva_wallet(self, endpoint, action, data=None, should_retry=True):
            // session = get_viva_wallet_session(should_retry)
            // session.headers.update({'Authorization': f"Bearer {self.viva_wallet_bearer_token}"})
            // endpoint = f"{self._viva_wallet_api_get_endpoint()}/ecr/v1/{endpoint}"
            // try:
            //     resp = session.request(action, endpoint, json=data, timeout=TIMEOUT)
            // except requests.exceptions.RequestException as e:
            //     return {'error': _("There are some issues between us and Viva Wallet, try again later.%s)", e)}
            // if resp.text and resp.json().get('detail') == 'Could not validate credentials':
            //     session.headers.update(self._bearer_token(session))
            //     resp = session.request(action, endpoint, json=data, timeout=TIMEOUT)
            // 
            // if resp.status_code == 200:
            //     if resp.text:
            //         return resp.json()
            //     return {'success': resp.status_code}
            // else:
            //     return {'error': _("There are some issues between us and Viva Wallet, try again later. %s", resp.json().get('detail'))}
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckAdyenTerminalIdentifierInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _check_adyen_terminal_identifier(self):
            // for payment_method in self:
            //     if not payment_method.adyen_terminal_identifier:
            //         continue
            //     # sudo() to search all companies
            //     existing_payment_method = self.sudo().search([('id', '!=', payment_method.id),
            //                                            ('adyen_terminal_identifier', '=', payment_method.adyen_terminal_identifier)],
            //                                           limit=1)
            //     if existing_payment_method:
            //         if existing_payment_method.company_id == payment_method.company_id:
            //             raise ValidationError(_('Terminal %(terminal)s is already used on payment method %(payment_method)s.',
            //                               terminal=payment_method.adyen_terminal_identifier, payment_method=existing_payment_method.display_name))
            //         else:
            //             raise ValidationError(_('Terminal %(terminal)s is already used in company %(company)s on payment method %(payment_method)s.',
            //                                      terminal=payment_method.adyen_terminal_identifier,
            //                                      company=existing_payment_method.company_id.name,
            //                                      payment_method=existing_payment_method.display_name))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckPaymentMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _check_payment_method(self):
            // for rec in self:
            //     if rec.payment_method_type == "qr_code":
            //         if (rec.journal_id.type != 'bank' or not rec.journal_id.bank_account_id):
            //             raise ValidationError(_("At least one bank account must be defined on the journal to allow registering QR code payments with Bank apps."))
            //         if not rec.qr_code_method:
            //             raise ValidationError(_("You must select a QR-code method to generate QR-codes for this payment method."))
            //         error_msg = self.journal_id.bank_account_id._get_error_messages_for_qr(self.qr_code_method, False, rec.company_id.currency_id)
            //         if error_msg:
            //             raise ValidationError(error_msg)
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckPaytmTerminalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def _check_paytm_terminal(self):
            // for record in self:
            //     if record.use_payment_terminal == 'paytm' and record.company_id.currency_id.name != 'INR':
            //         raise UserError(_('This Payment Terminal is only valid for INR Currency'))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckPineLabsTerminalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py) ---
            // def _check_pine_labs_terminal(self):
            // if any(record.use_payment_terminal == 'pine_labs' and record.company_id.currency_id.name != 'INR' for record in self):
            //     raise UserError(_('This Payment Terminal is only valid for INR Currency'))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckRazorpayTerminalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py) ---
            // def _check_razorpay_terminal(self):
            // if any(record.use_payment_terminal == 'razorpay' and record.company_id.currency_id.name != 'INR' for record in self):
            //     raise UserError(_('This Payment Terminal is only valid for INR Currency'))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckSpecialAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def _check_special_access(self):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Do not have access to fetch token from Mercado Pago"))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckStripeSerialNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def _check_stripe_serial_number(self):
            // for payment_method in self:
            //     if not payment_method.stripe_serial_number:
            //         continue
            //     existing_payment_method = self.search([('id', '!=', payment_method.id),
            //                                            ('stripe_serial_number', '=', payment_method.stripe_serial_number)],
            //                                           limit=1)
            //     if existing_payment_method:
            //         raise ValidationError(_('Terminal %(terminal)s is already used on payment method %(payment_method)s.',
            //              terminal=payment_method.stripe_serial_number, payment_method=existing_payment_method.display_name))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckVivaWalletCredentialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _check_viva_wallet_credentials(self):
            // for record in self:
            //     if (record.use_payment_terminal == 'viva_wallet'
            //         and not all(record[f] for f in [
            //             'viva_wallet_merchant_id',
            //             'viva_wallet_api_key',
            //             'viva_wallet_client_id',
            //             'viva_wallet_client_secret',
            //             'viva_wallet_terminal_id']
            //         )
            //     ):
            //         raise UserError(_('It is essential to provide API key for the use of viva wallet'))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeHasAnOnlinePaymentProviderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _compute_has_an_online_payment_provider(self):
            // for pm in self:
            //     if pm.is_online_payment:
            //         pm.has_an_online_payment_provider = bool(pm._get_online_payment_providers())
            //     else:
            //         pm.has_an_online_payment_provider = False
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeHideQrCodeMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _compute_hide_qr_code_method(self):
            // for payment_method in self:
            //     payment_method.hide_qr_code_method = payment_method.payment_method_type != 'qr_code' or len(self.env['res.partner.bank'].get_available_qr_methods_in_sequence()) == 1
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeHideUsePaymentTerminalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _compute_hide_use_payment_terminal(self):
            // no_terminals = not bool(self._fields['use_payment_terminal'].selection(self))
            // for payment_method in self:
            //     payment_method.hide_use_payment_terminal = no_terminals or payment_method.type in ('cash', 'pay_later') or payment_method.payment_method_type != 'terminal'
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _compute_hide_use_payment_terminal(self):
            // opm = self.filtered(lambda pm: pm.type == 'online')
            // if opm:
            //     opm.hide_use_payment_terminal = True
            // super(PosPaymentMethod, self - opm)._compute_hide_use_payment_terminal()
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeIsCashCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _compute_is_cash_count(self):
            // for pm in self:
            //     pm.is_cash_count = pm.type == 'cash'
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeOpenSessionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _compute_open_session_ids(self):
            // for payment_method in self:
            //     payment_method.open_session_ids = self.env['pos.session'].search([('config_id', 'in', payment_method.config_ids.ids), ('state', '!=', 'closed')])
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeQrInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _compute_qr(self):
            // for pm in self:
            //     if pm.payment_method_type != "qr_code":
            //         pm.default_qr = False
            //         continue
            //     try:
            //         # Generate QR without amount that can then be used when the POS is offline
            //         pm.default_qr = pm.get_qr_code(False, '', '', pm.company_id.currency_id.id, False)
            //     except UserError:
            //         pm.default_qr = False
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _compute_type(self):
            // for pm in self:
            //     if pm.journal_id.type in {'cash', 'bank'}:
            //         pm.type = pm.journal_id.type
            //     else:
            //         pm.type = 'pay_later'
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _compute_type(self):
            // opm = self.filtered('is_online_payment')
            // if opm:
            //     opm.type = 'online'
            // 
            // super(PosPaymentMethod, self - opm)._compute_type()
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeVivaWalletWebhookEndpointInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _compute_viva_wallet_webhook_endpoint(self):
            // web_base_url = self.get_base_url()
            // self.viva_wallet_webhook_endpoint = f"{web_base_url}/pos_viva_wallet/notification?company_id={self.company_id.id}&token={self.viva_wallet_webhook_verification_key}"
            */
            return default;
        }

        public async Task<PosPaymentMethod> CopyDataAsync(Guid id, PosPaymentMethodCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {}, config_ids=[(5, 0, 0)])
            // vals_list = super().copy_data(default=default)
            // 
            // for pm, vals in zip(self, vals_list):
            //     if pm.journal_id and pm.journal_id.type == 'cash':
            //         if ('journal_id' in default and default['journal_id'] == pm.journal_id.id) or ('journal_id' not in default):
            //             vals['journal_id'] = False
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<PosPaymentMethod> CreateAsync(PosPaymentMethod entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('payment_method_type', False):
            //         self._force_payment_method_type_values(vals, vals['payment_method_type'])
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def create(self, vals):
            // records = super().create(vals)
            // 
            // for record in records:
            //     if record.mp_bearer_token:
            //         record.mp_id_point_smart_complet = record._find_terminal(record.mp_bearer_token, record.mp_id_point_smart)
            // 
            // return records
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('is_online_payment', False):
            //         self._force_online_payment_values(vals)
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def create(self, vals):
            // records = super().create(vals)
            // 
            // for record in records:
            //     if record.viva_wallet_merchant_id and record.viva_wallet_api_key:
            //         record.viva_wallet_webhook_verification_key = record._get_verification_key(
            //             record._viva_wallet_webhook_get_endpoint(),
            //             record.viva_wallet_merchant_id,
            //             record.viva_wallet_api_key,
            //         )
            //         if not record.viva_wallet_webhook_verification_key:
            //             raise UserError(_("Can't create payment method. Please check the data and update it."))
            // 
            // return records
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PosPaymentMethod> FindTerminalInternalAsync(object token, object point_smart)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def _find_terminal(self, token, point_smart):
            // mercado_pago = MercadoPagoPosRequest(token)
            // data = mercado_pago.call_mercado_pago("get", "/point/integration-api/devices", {})
            // if 'devices' in data:
            //     # Search for a device id that contains the serial number entered by the user
            //     found_device = next((device for device in data['devices'] if point_smart in device['id']), None)
            // 
            //     if not found_device:
            //         raise UserError(_("The terminal serial number is not registered on Mercado Pago"))
            // 
            //     return found_device.get('id', '')
            // else:
            //     raise UserError(_("Please verify your production user token as it was rejected"))
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ForceOnlinePaymentValuesInternalAsync(object if_present)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _force_online_payment_values(vals, if_present=False):
            // if 'type' in vals:
            //     vals['type'] = 'online'
            // 
            // disabled_fields_name = ('split_transactions', 'receivable_account_id', 'outstanding_account_id', 'journal_id', 'is_cash_count', 'use_payment_terminal', 'qr_code_method')
            // if if_present:
            //     for name in disabled_fields_name:
            //         if name in vals:
            //             vals[name] = False
            //     if 'payment_method_type' in vals:
            //         vals['payment_method_type'] = 'none'
            // else:
            //     for name in disabled_fields_name:
            //         vals[name] = False
            //     vals['payment_method_type'] = 'none'
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ForcePaymentMethodTypeValuesInternalAsync(object payment_method_type, object if_present)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _force_payment_method_type_values(vals, payment_method_type, if_present=False):
            // if payment_method_type == 'terminal':
            //     disabled_fields_name = ['qr_code_method']
            // elif payment_method_type == 'qr_code':
            //     disabled_fields_name = ['use_payment_terminal']
            // else:
            //     disabled_fields_name = ['use_payment_terminal', 'qr_code_method']
            // if if_present:
            //     for name in disabled_fields_name:
            //         if name in vals:
            //             vals[name] = False
            // else:
            //     for name in disabled_fields_name:
            //         vals[name] = False
            */
            return default;
        }

        public async Task<PosPaymentMethod> ForcePdvAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def force_pdv(self):
            // """
            // Triggered in debug mode when the user wants to force the "PDV" mode.
            // It calls the Mercado Pago API to set the terminal mode to "PDV".
            // """
            // self._check_special_access()
            // 
            // mercado_pago = MercadoPagoPosRequest(self.sudo().mp_bearer_token)
            // _logger.info('Calling Mercado Pago to force the terminal mode to "PDV"')
            // 
            // mode = {"operating_mode": "PDV"}
            // resp = mercado_pago.call_mercado_pago("patch", f"/point/integration-api/devices/{self.mp_id_point_smart_complet}", mode)
            // if resp.get("operating_mode") != "PDV":
            //     raise UserError(_("Unexpected Mercado Pago response: %s", resp))
            // _logger.debug("Successfully set the terminal mode to 'PDV'.")
            // return None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> GetAdyenEndpointsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _get_adyen_endpoints(self):
            // return {
            //     'terminal_request': 'https://terminal-api-%s.adyen.com/async',
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment_method.py) ---
            // def _get_adyen_endpoints(self):
            // return {
            //     **super(PosPaymentMethod, self)._get_adyen_endpoints(),
            //     'adjust': 'https://pal-%s.adyen.com/pal/servlet/Payment/v52/adjustAuthorisation',
            //     'capture': 'https://pal-%s.adyen.com/pal/servlet/Payment/v52/capture',
            // }
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetExpectedMessageHeaderInternalAsync(object expected_message_category)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _get_expected_message_header(self, expected_message_category):
            // return {
            //     'ProtocolVersion': '3.0',
            //     'MessageClass': 'Service',
            //     'MessageType': 'Request',
            //     'MessageCategory': expected_message_category,
            //     'SaleID': UNPREDICTABLE_ADYEN_DATA,
            //     'ServiceID': UNPREDICTABLE_ADYEN_DATA,
            //     'POIID': self.adyen_terminal_identifier,
            // }
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetExpectedPaymentRequestInternalAsync(object with_acquirer_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _get_expected_payment_request(self, with_acquirer_data):
            // res = {
            //     'SaleToPOIRequest': {
            //         'MessageHeader': self._get_expected_message_header('Payment'),
            //         'PaymentRequest': {
            //             'SaleData': {
            //                 'SaleTransactionID': {
            //                     'TransactionID': UNPREDICTABLE_ADYEN_DATA,
            //                     'TimeStamp': UNPREDICTABLE_ADYEN_DATA,
            //                 },
            //             },
            //             'PaymentTransaction': {
            //                 'AmountsReq': {
            //                     'Currency': UNPREDICTABLE_ADYEN_DATA,
            //                     'RequestedAmount': UNPREDICTABLE_ADYEN_DATA,
            //                 },
            //             },
            //         },
            //     },
            // }
            // 
            // if with_acquirer_data:
            //     res['SaleToPOIRequest']['PaymentRequest']['SaleData']['SaleToAcquirerData'] = UNPREDICTABLE_ADYEN_DATA
            // return res
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetHmacInternalAsync(Guid sale_id, Guid service_id, Guid poi_id, Guid sale_transaction_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _get_hmac(self, sale_id, service_id, poi_id, sale_transaction_id):
            // return hmac(
            //     env=self.env(su=True),
            //     scope='pos_adyen_payment',
            //     message=(sale_id, service_id, poi_id, sale_transaction_id)
            // )
            */
            return default;
        }

        public async Task<PosPaymentMethod> GetLatestAdyenStatusAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def get_latest_adyen_status(self):
            // self.ensure_one()
            // if not self.env.su and not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessDenied()
            // 
            // latest_response = self.sudo().adyen_latest_response
            // latest_response = json.loads(latest_response) if latest_response else False
            // return latest_response
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> GetLatestVivaWalletStatusAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def get_latest_viva_wallet_status(self):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Only 'group_pos_user' are allowed to get latest transaction status"))
            // 
            // self.ensure_one()
            // latest_response = self.sudo().viva_wallet_latest_response
            // return latest_response
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> GetOnlinePaymentProvidersInternalAsync(Guid pos_config_id, object error_if_invalid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _get_online_payment_providers(self, pos_config_id=False, error_if_invalid=True):
            // self.ensure_one()
            // providers_sudo = self.sudo().online_payment_provider_ids
            // if not providers_sudo: # Empty = all published providers
            //     providers_sudo = self.sudo().env['payment.provider'].search([('is_published', '=', True), ('state', 'in', ['enabled', 'test'])])
            // 
            // if not pos_config_id:
            //     return providers_sudo
            // 
            // config_currency = self.sudo().env['pos.config'].browse(pos_config_id).currency_id
            // valid_providers = providers_sudo.filtered(lambda p: not p.journal_id.currency_id or p.journal_id.currency_id == config_currency)
            // if error_if_invalid and len(providers_sudo) != len(valid_providers):
            //     raise ValidationError(_("All payment providers configured for an online payment method must use the same currency as the Sales Journal, or the company currency if that is not set, of the POS config."))
            // return valid_providers
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetOrCreateOnlinePaymentMethodInternalAsync(Guid company_id, Guid pos_config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _get_or_create_online_payment_method(self, company_id, pos_config_id):
            // """ Get the first online payment method compatible with the provided pos.config.
            //     If there isn't any, try to find an existing one in the same company and return it without adding the pos.config to it.
            //     If there is not, create a new one for the company and return it without adding the pos.config to it.
            // """
            // # Parameters are ids instead of a pos.config record because this method can be called from a web controller or internally
            // payment_method_id = self.env['pos.payment.method'].search([('is_online_payment', '=', True), ('company_id', '=', company_id), ('config_ids', 'in', pos_config_id)], limit=1).exists()
            // if not payment_method_id:
            //     payment_method_id = self.env['pos.payment.method'].search([('is_online_payment', '=', True), ('company_id', '=', company_id)], limit=1).exists()
            //     if not payment_method_id:
            //         payment_method_id = self.env['pos.payment.method'].create({
            //             'name': _('Online Payment'),
            //             'is_online_payment': True,
            //             'company_id': company_id,
            //         })
            //         if not payment_method_id:
            //             raise ValidationError(_(
            //                 "Could not create an online payment method (company_id=%(company_id)d, pos_config_id=%(pos_config_id)d)",
            //                 company_id=company_id,
            //                 pos_config_id=pos_config_id,
            //             ))
            // return payment_method_id
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetPaymentMethodTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _get_payment_method_type(self):
            // selection = [('none', 'None required'), ('terminal', 'Terminal')]
            // if self.env['res.partner.bank'].get_available_qr_methods_in_sequence():
            //     selection.append(('qr_code', 'Bank App (QR Code)'))
            // return selection
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetPaymentTerminalSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super(PosPaymentMethod, self)._get_payment_terminal_selection() + [('adyen', 'Adyen')]
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super()._get_payment_terminal_selection() + [('mercado_pago', 'Mercado Pago')]
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super(PosPaymentMethod, self)._get_payment_terminal_selection() if not self.is_online_payment else []
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super()._get_payment_terminal_selection() + [('paytm', 'PayTM')]
            --- ODOO METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super()._get_payment_terminal_selection() + [('pine_labs', 'Pine Labs')]
            --- ODOO METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super()._get_payment_terminal_selection() + [('razorpay', 'Razorpay')]
            --- ODOO METHOD SOURCE (MODULE: pos_six, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super(PosPaymentMethod, self)._get_payment_terminal_selection() + [('six', 'SIX')]
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super()._get_payment_terminal_selection() + [('stripe', 'Stripe')]
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _get_payment_terminal_selection(self):
            // return super()._get_payment_terminal_selection() + [('viva_wallet', 'Viva Wallet')]
            */
            return default;
        }

        public async Task<PosPaymentMethod> GetQrCodeAsync(Guid id, PosPaymentMethodGetQrCodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def get_qr_code(self, amount, free_communication, structured_communication, currency, debtor_partner):
            // """ Generates and returns a QR-code
            // """
            // self.ensure_one()
            // if self.payment_method_type != "qr_code" or not self.qr_code_method:
            //     raise UserError(_("This payment method is not configured to generate QR codes."))
            // payment_bank = self.journal_id.bank_account_id
            // debtor_partner = self.env['res.partner'].browse(debtor_partner)
            // currency = self.env['res.currency'].browse(currency)
            // 
            // return payment_bank.with_context(is_online_qr=True).build_qr_code_base64(
            //     float(amount), free_communication, structured_communication, currency, debtor_partner, self.qr_code_method, silent_errors=False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> GetStripePaymentProviderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def _get_stripe_payment_provider(self):
            // stripe_payment_provider = self.env['payment.provider'].search([
            //     ('code', '=', 'stripe'),
            //     ('company_id', '=', self.env.company.id)
            // ], limit=1)
            // 
            // if not stripe_payment_provider:
            //     raise UserError(_("Stripe payment provider for company %s is missing", self.env.company.name))
            // 
            // return stripe_payment_provider
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetStripeSecretKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def _get_stripe_secret_key(self):
            // # TODO: unused, remove in master
            // stripe_secret_key = self._get_stripe_payment_provider().stripe_secret_key
            // 
            // if not stripe_secret_key:
            //     raise ValidationError(_('Complete the Stripe onboarding for company %s.', self.env.company.name))
            // 
            // return stripe_secret_key
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetValidAcquirerDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _get_valid_acquirer_data(self):
            // return {
            //     'tenderOption': 'AskGratuity',
            //     'authorisationType': 'PreAuth'
            // }
            --- ODOO METHOD SOURCE (MODULE: pos_self_order_adyen, FILE: pos_payment_method.py) ---
            // def _get_valid_acquirer_data(self):
            // res = super()._get_valid_acquirer_data()
            // res['metadata.self_order_id'] = UNPREDICTABLE_ADYEN_DATA
            // return res
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetVerificationKeyInternalAsync(object endpoint, Guid viva_wallet_merchant_id, object viva_wallet_api_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _get_verification_key(self, endpoint, viva_wallet_merchant_id, viva_wallet_api_key):
            // # Get a key to configure the webhook.
            // # this key need to be the response when we receive a notifiaction
            // # do not execute this query in test mode
            // if tools.config['test_enable']:
            //     return 'viva_wallet_test'
            // 
            // auth = requests.auth.HTTPBasicAuth(viva_wallet_merchant_id, viva_wallet_api_key)
            // try:
            //     resp = requests.get(f"{endpoint}/api/messages/config/token", auth=auth, timeout=TIMEOUT)
            // except requests.exceptions.RequestException:
            //     _logger.exception('Failed to call https://%s/api/messages/config/token endpoint', endpoint)
            // return resp.json().get('Key')
            */
            return default;
        }

        protected async Task<PosPaymentMethod> IsValidAdyenRequestDataInternalAsync(object provided_data, object expected_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _is_valid_adyen_request_data(self, provided_data, expected_data):
            // if not isinstance(provided_data, dict) or set(provided_data.keys()) != set(expected_data.keys()):
            //     return False
            // 
            // for provided_key, provided_value in provided_data.items():
            //     expected_value = expected_data[provided_key]
            //     if expected_value == UNPREDICTABLE_ADYEN_DATA:
            //         continue
            //     if isinstance(expected_value, dict):
            //         if not self._is_valid_adyen_request_data(provided_value, expected_value):
            //             return False
            //     else:
            //         if provided_value != expected_value:
            //             return False
            // return True
            */
            return default;
        }

        protected async Task<PosPaymentMethod> IsWriteForbiddenInternalAsync(object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _is_write_forbidden(self, fields):
            // whitelisted_fields = {'sequence'}
            // return bool(fields - whitelisted_fields and self.open_session_ids)
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _is_write_forbidden(self, fields):
            // return super(PosPaymentMethod, self)._is_write_forbidden(fields - {'adyen_latest_response'})
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _is_write_forbidden(self, fields):
            // return super(PosPaymentMethod, self)._is_write_forbidden(fields - {'online_payment_provider_ids'})
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _is_write_forbidden(self, fields):
            // # Allow the modification of these fields even if a pos_session is open
            // whitelisted_fields = {'viva_wallet_bearer_token', 'viva_wallet_webhook_verification_key', 'viva_wallet_latest_response'}
            // return super(PosPaymentMethod, self)._is_write_forbidden(fields - whitelisted_fields)
            */
            return default;
        }

        protected async Task<PosPaymentMethod> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _load_pos_data_domain(self, data):
            // return ['|', ('active', '=', False), ('active', '=', True)]
            */
            return default;
        }

        protected async Task<PosPaymentMethod> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'is_cash_count', 'use_payment_terminal', 'split_transactions', 'type', 'image', 'sequence', 'payment_method_type', 'default_qr']
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['adyen_terminal_identifier']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['is_online_payment']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['adyen_merchant_account']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_six, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['six_terminal_ip']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // params = super()._load_pos_data_fields(config_id)
            // params += ['stripe_serial_number']
            // return params
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _load_pos_data_fields(self, config_id):
            // data = super()._load_pos_data_fields(config_id)
            // data += ['viva_wallet_terminal_id']
            // return data
            */
            return default;
        }

        protected async Task<PosPaymentMethod> LoadPosSelfDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_payment_method.py) ---
            // def _load_pos_self_data_domain(self, data):
            // if data['pos.config']['data'][0]['self_ordering_mode'] == 'kiosk':
            //     domain = super()._load_pos_self_data_domain(data)
            //     domain = expression.OR([[('is_online_payment', '=', True)], domain])
            //     return domain
            // else:
            //     return [('is_online_payment', '=', True)]
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_payment_method.py) ---
            // def _load_pos_self_data_domain(self, data):
            // if data['pos.config']['data'][0]['self_ordering_mode'] == 'kiosk':
            //     return [('use_payment_terminal', 'in', ['adyen', 'stripe']), ('id', 'in', data['pos.config']['data'][0]['payment_method_ids'])]
            // else:
            //     [('id', '=', False)]
            --- ODOO METHOD SOURCE (MODULE: pos_self_order_razorpay, FILE: pos_payment_method.py) ---
            // def _load_pos_self_data_domain(self, data):
            // domain = super()._load_pos_self_data_domain(data)
            // if data['pos.config']['data'][0]['self_ordering_mode'] == 'kiosk':
            //     domain = expression.OR([[('use_payment_terminal', '=', 'razorpay')], domain])
            // return domain
            */
            return default;
        }

        public async Task<PosPaymentMethod> MpGetPaymentStatusAsync(Guid id, PosPaymentMethodMpGetPaymentStatusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def mp_get_payment_status(self, payment_id):
            // """
            // Called from frontend to get the payment status from Mercado Pago
            // """
            // self._check_special_access()
            // 
            // mercado_pago = MercadoPagoPosRequest(self.sudo().mp_bearer_token)
            // 
            // resp = mercado_pago.call_mercado_pago("get", f"/v1/payments/{payment_id}", {})
            // _logger.debug("mp_get_payment_status(), response from Mercado Pago: %s", resp)
            // return resp
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> MpPaymentIntentCancelAsync(Guid id, PosPaymentMethodMpPaymentIntentCancelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def mp_payment_intent_cancel(self, payment_intent_id):
            // """
            // Called from frontend to cancel a payment intent in Mercado Pago
            // """
            // self._check_special_access()
            // 
            // mercado_pago = MercadoPagoPosRequest(self.sudo().mp_bearer_token)
            // # Call Mercado Pago for payment intend cancelation
            // resp = mercado_pago.call_mercado_pago("delete", f"/point/integration-api/devices/{self.mp_id_point_smart_complet}/payment-intents/{payment_intent_id}", {})
            // _logger.debug("mp_payment_intent_cancel(), response from Mercado Pago: %s", resp)
            // return resp
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> MpPaymentIntentCreateAsync(Guid id, PosPaymentMethodMpPaymentIntentCreateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def mp_payment_intent_create(self, infos):
            // """
            // Called from frontend for creating a payment intent in Mercado Pago
            // """
            // self._check_special_access()
            // 
            // mercado_pago = MercadoPagoPosRequest(self.sudo().mp_bearer_token)
            // # Call Mercado Pago for payment intend creation
            // resp = mercado_pago.call_mercado_pago("post", f"/point/integration-api/devices/{self.mp_id_point_smart_complet}/payment-intents", infos)
            // _logger.debug("mp_payment_intent_create(), response from Mercado Pago: %s", resp)
            // return resp
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> MpPaymentIntentGetAsync(Guid id, PosPaymentMethodMpPaymentIntentGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def mp_payment_intent_get(self, payment_intent_id):
            // """
            // Called from frontend to get the last payment intend from Mercado Pago
            // """
            // self._check_special_access()
            // 
            // mercado_pago = MercadoPagoPosRequest(self.sudo().mp_bearer_token)
            // # Call Mercado Pago for payment intend status
            // resp = mercado_pago.call_mercado_pago("get", f"/point/integration-api/payment-intents/{payment_intent_id}", {})
            // _logger.debug("mp_payment_intent_get(), response from Mercado Pago: %s", resp)
            // return resp
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> OnchangeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _onchange_journal_id(self):
            // for pm in self:
            //     if pm.journal_id and pm.journal_id.type not in ['cash', 'bank']:
            //         raise UserError(_("Only journals of type 'Cash' or 'Bank' could be used with payment methods."))
            //     if pm.journal_id and pm.journal_id.type == 'bank':
            //         chart_template = self.with_context(allowed_company_ids=self.env.company.root_id.ids).env['account.chart.template']
            //         pm.outstanding_account_id = chart_template.ref('account_journal_payment_debit_account_id', raise_if_not_found=False) or self.company_id.transfer_account_id
            // if self.is_cash_count:
            //     self.use_payment_terminal = False
            */
            return default;
        }

        protected async Task<PosPaymentMethod> OnchangePaymentMethodTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _onchange_payment_method_type(self):
            // # We don't display the field if there is only one option and cannot set a default on it
            // selection_options = self.env['res.partner.bank'].get_available_qr_methods_in_sequence()
            // if len(selection_options) == 1:
            //     self.qr_code_method = selection_options[0][0]
            // # Unset the use_payment_terminal field when switching to a payment method that doesn't use it
            // if self.payment_method_type != 'terminal':
            //     self.use_payment_terminal = None
            */
            return default;
        }

        protected async Task<PosPaymentMethod> OnchangeUsePaymentTerminalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def _onchange_use_payment_terminal(self):
            // """Used by inheriting model to unset the value of the field related to the unselected payment terminal."""
            // pass
            */
            return default;
        }

        protected async Task<PosPaymentMethod> PaymentRequestFromKioskInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_payment_method.py) ---
            // def _payment_request_from_kiosk(self, order):
            // pass
            --- ODOO METHOD SOURCE (MODULE: pos_self_order_adyen, FILE: pos_payment_method.py) ---
            // def _payment_request_from_kiosk(self, order):
            // if self.use_payment_terminal != 'adyen':
            //     return super()._payment_request_from_kiosk(order)
            // else:
            //     pos_config = order.session_id.config_id
            //     random_number = random.randrange(10**9, 10**10 - 1)
            // 
            //     # https://docs.adyen.com/point-of-sale/basic-tapi-integration/make-a-payment/#make-a-payment
            //     data = {
            //         'SaleToPOIRequest': {
            //             'MessageHeader': {
            //                 'ProtocolVersion': "3.0",
            //                 'MessageClass': "Service",
            //                 'MessageType': "Request",
            //                 'MessageCategory': "Payment",
            //                 'SaleID': f'{pos_config.display_name} (ID:{pos_config.id})', #  Your unique ID for the POS system component to send this request from.
            //                 'ServiceID': str(random_number), # Your unique ID for this request, consisting of 1-10 alphanumeric characters.
            //                 'POIID': self.adyen_terminal_identifier, #      The unique ID of the terminal to send this request to.
            //             },
            //             'PaymentRequest': {
            //                 'SaleData': {
            //                     'SaleTransactionID': {
            //                         'TransactionID': order.pos_reference, # your reference to identify a payment.
            //                         'TimeStamp': datetime.now(tz=timezone.utc).isoformat(timespec='seconds'), # date and time of the request in UTC format.
            //                     },
            //                     'SaleToAcquirerData': 'metadata.self_order_id=' + str(order.id),
            //                 },
            //                 'PaymentTransaction': {
            //                     'AmountsReq': {
            //                         'Currency': order.currency_id.name, # the transaction currency.
            //                         'RequestedAmount': order.amount_total, # The final transaction amount.
            //                     },
            //                 },
            //             },
            //         },
            //     }
            // 
            //     req = self.proxy_adyen_request(data)
            // 
            //     return req and (isinstance(req, bool) or not req.get('error'))
            --- ODOO METHOD SOURCE (MODULE: pos_self_order_razorpay, FILE: pos_payment_method.py) ---
            // def _payment_request_from_kiosk(self, order):
            // if self.use_payment_terminal != 'razorpay':
            //     return super()._payment_request_from_kiosk(order)
            // reference_prefix = order.config_id.name.replace(' ', '')
            // data = {
            //     'amount': order.amount_total,
            //     'referenceId': f'{reference_prefix}/Order/{order.id}/{uuid.uuid4().hex}',
            // }
            // return self.razorpay_make_payment_request(data)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order_stripe, FILE: pos_payment_method.py) ---
            // def _payment_request_from_kiosk(self, order):
            // if self.use_payment_terminal != 'stripe':
            //     return super()._payment_request_from_kiosk(order)
            // else:
            //     return self.stripe_payment_intent(order.amount_total)
            */
            return default;
        }

        public async Task<PosPaymentMethod> PaytmFetchPaymentStatusAsync(Guid id, PosPaymentMethodPaytmFetchPaymentStatusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def paytm_fetch_payment_status(self, transaction_id, reference_id, timestamp):
            // body = self._paytm_get_request_body(transaction_id, reference_id, timestamp)
            // head = self._paytm_get_request_head(body)
            // head_error = head.get('error') and head
            // if head_error:
            //     return head_error
            // payload = {'head': head, 'body': body}
            // response = self._paytm_make_request('V2/payment/status', payload=payload)
            // result_code = response.get('resultInfo', {}).get('resultCode')
            // if result_code == 'S':
            //     # Since we don't want to send extra data on RPC call
            //     # Only sending essential data when the transaction is successful
            //     data = response['resultInfo']
            //     data.update({
            //             'authCode': response.get('authCode'),
            //             'issuerMaskCardNo': response.get('issuerMaskCardNo'),
            //             'issuingBankName': response.get('issuingBankName'),
            //             'payMethod': response.get('payMethod'),
            //             'cardType': response.get('cardType'),
            //             'cardScheme': response.get('cardScheme'),
            //             'merchantReferenceNo': response.get('merchantReferenceNo'),
            //             'merchantTransactionId': response.get('merchantTransactionId'),
            //             'transactionDateTime': response.get('transactionDateTime'),
            //     })
            //     return data
            // elif result_code == 'F':
            //     return {'error': "%s" % response['resultInfo'].get('resultMsg', _('paytm transaction failure'))}
            // elif result_code == 'P':
            //     return response['resultInfo']
            // default_error_msg = _('paymentFetchRequest expected resultCode not found in the response')
            // error = response.get('error') or default_error_msg
            // return {'error': '%s' % error}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> PaytmGenerateSignatureInternalAsync(object params_dict, object key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def _paytm_generate_signature(self, params_dict, key):
            // params_list = []
            // for k in sorted(params_dict.keys()):
            //     value = params_dict[k]
            //     if value is None or params_dict[k].lower() == "null":
            //         value = ""
            //     params_list.append(str(value))
            // salt = ''.join(secrets.choice(string.ascii_letters + string.digits) for _ in range(4))
            // params_list.append(salt)
            // params_with_salt = '|'.join(params_list)
            // hashed_params = hashlib.sha256(params_with_salt.encode())
            // hashed_params_with_salt = hashed_params.hexdigest() + salt
            // padding = 12 #the padding value is a constant
            // padded_hashed_params_with_salt = bytes(hashed_params_with_salt + padding * chr(padding), 'utf-8')
            // try:
            //     cipher = Cipher(algorithms.AES(key.encode()), modes.CBC(iv))
            //     encryptor = cipher.encryptor()
            //     encrypted_hashed_params = encryptor.update(padded_hashed_params_with_salt) + encryptor.finalize()
            //     return base64.b64encode(encrypted_hashed_params).decode("UTF-8")
            // except ValueError as error:
            //     _logger.warning("Cannot generate PayTM signature. Error: %s", error)
            //     return {'error': '%s' % error}
            */
            return default;
        }

        protected async Task<PosPaymentMethod> PaytmGetRequestBodyInternalAsync(Guid transaction_id, Guid reference_id, object timestamp)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def _paytm_get_request_body(self, transaction_id, reference_id, timestamp):
            // 
            // time = datetime.fromtimestamp(timestamp).astimezone(tz=tz.gettz('Asia/Kolkata')).strftime("%Y-%m-%d %H:%M:%S")
            // return {
            //     'paytmMid': self.paytm_mid,
            //     'paytmTid': self.paytm_tid,
            //     'transactionDateTime': time,
            //     'merchantTransactionId': transaction_id,
            //     'merchantReferenceNo': reference_id,
            // }
            */
            return default;
        }

        protected async Task<PosPaymentMethod> PaytmGetRequestHeadInternalAsync(object body)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def _paytm_get_request_head(self, body):
            // paytm_signature = self._paytm_generate_signature(body, self.paytm_merchant_key)
            // error = isinstance(paytm_signature, dict) and paytm_signature.get('error')
            // if error:
            //     return {'error': '%s' % error}
            // return {
            //     'requestTimeStamp' : body["transactionDateTime"],
            //     'channelId' : self.channel_id,
            //     'checksum' : paytm_signature,
            // }
            */
            return default;
        }

        public async Task<PosPaymentMethod> PaytmMakePaymentRequestAsync(Guid id, PosPaymentMethodPaytmMakePaymentRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def paytm_make_payment_request(self, amount, transaction_id, reference_id, timestamp):
            // body = self._paytm_get_request_body(transaction_id, reference_id, timestamp)
            // body['transactionAmount'] = str(int(amount))
            // if self.accept_payment == 'auto':
            //     body['autoAccept'] = 'True'
            // body['paymentMode'] = self.allowed_payment_modes.upper()
            // head = self._paytm_get_request_head(body)
            // head_error = head.get('error')
            // if head_error:
            //     return {'error': '%s' % head_error}
            // merchantExtendedInfo = {'paymentMode': self.allowed_payment_modes.upper()}
            // if self.accept_payment == 'auto':
            //     merchantExtendedInfo['autoAccept'] = 'True'
            // body['merchantExtendedInfo'] = merchantExtendedInfo
            // payload = {'head': head, 'body': body}
            // response = self._paytm_make_request('payment/request', payload=payload)
            // result_code = response.get('resultInfo', {}).get('resultCode')
            // if result_code == 'A':
            //     return response['resultInfo']
            // elif result_code == 'F':
            //     return {'error': "%s" % response['resultInfo'].get('resultMsg', _('paytm transaction request declined'))}
            // default_error_msg = _('makePaymentRequest expected resultCode not found in the response')
            // error = response.get('error') or default_error_msg
            // return {'error': '%s' % error}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> PaytmMakeRequestInternalAsync(object url, object payload)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_paytm, FILE: pos_payment_method.py) ---
            // def _paytm_make_request(self, url, payload=None):
            // """ Make a request to PayTM API.
            // 
            // :param str url: The url to be reached by the request.
            // :param dict payload: The payload of the request.
            // :return The JSON-formatted content of the response.
            // :rtype: dict
            // """
            // try:
            //     if self.paytm_test_mode:
            //         api_url = 'https://securegw-stage.paytm.in/ecr/'
            //     else:
            //         api_url = 'https://securegw-edc.paytm.in/ecr/'
            //     response = requests.post(api_url+url, json=payload, timeout=REQUEST_TIMEOUT)
            //     response.raise_for_status()
            // except (requests.exceptions.Timeout, requests.exceptions.RequestException) as error:
            //     _logger.warning("Cannot connect with PayTM. Error: %s", error)
            //     return {'error': '%s' % error}
            // res_json = response.json()
            // if res_json.get('body'):
            //     return res_json['body']
            // default_error_msg = _('Something went wrong with paytm request. Please try later.')
            // error = res_json.get('error') or default_error_msg
            // return {'error': '%s' % error}
            */
            return default;
        }

        public async Task<PosPaymentMethod> PineLabsCancelPaymentRequestAsync(Guid id, PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py) ---
            // def pine_labs_cancel_payment_request(self, data):
            // """
            // Cancels a payment request via Pine Labs POS API.
            // 
            // :param dict data: Contains `amount` and `plutusTransactionReferenceID`.
            // :return: Success response with `responseCode` and `notification` or error with `errorMessage`.
            // :rtype: dict
            // """
            // body = {
            //     'Amount': data['amount'],
            //     'PlutusTransactionReferenceID': data['plutusTransactionReferenceID'],
            //     'TakeToHomeScreen': True,
            //     'ConfirmationRequired': True
            // }
            // response = call_pine_labs(payment_method=self, endpoint='CancelTransactionForced', payload=body)
            // if response.get('ResponseCode') == 0 and response.get('ResponseMessage') == "APPROVED":
            //     return {
            //         'responseCode': response['ResponseCode'],
            //         'notification': _('Pine Labs POS transaction cancelled. Retry again for collecting payment.')
            //     }
            // default_error = _('The expected error code for the Pine Labs POS status request was not included in the response.')
            // error = response.get('ResponseMessage') or response.get('errorMessage') or default_error
            // return { 'error': error }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> PineLabsFetchPaymentStatusAsync(Guid id, PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py) ---
            // def pine_labs_fetch_payment_status(self, data):
            // """
            // Fetches payment status from the Pine Labs POS API.
            // 
            // :param dict data: Contains `plutusTransactionReferenceID` for the status request.
            // :return: On success, returns `responseCode`, `status`, `plutusTransactionReferenceID`, and `data` (formatted transaction details). 
            //         On failure, returns an error message.
            // :rtype: dict
            // """
            // body = { 'PlutusTransactionReferenceID': data['plutusTransactionReferenceID'] }
            // response = call_pine_labs(payment_method=self, endpoint='GetCloudBasedTxnStatus', payload=body)
            // if response.get('ResponseCode') in [0, 1001]:
            //     formatted_transaction_data = { d['Tag']: d['Value'] for d in response['TransactionData'] } if response.get('ResponseCode') == 0 else {}
            //     return {
            //         'responseCode': response['ResponseCode'],
            //         'status': response['ResponseMessage'],
            //         'plutusTransactionReferenceID': response['PlutusTransactionReferenceID'],
            //         'data': formatted_transaction_data,
            //     }
            // default_error = _('The expected error code for the Pine Labs POS status request was not included in the response.')
            // error = response.get('ResponseMessage') or response.get('errorMessage') or default_error
            // return {'error': error}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> PineLabsMakePaymentRequestAsync(Guid id, PosPaymentMethodPineLabsMakePaymentRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py) ---
            // def pine_labs_make_payment_request(self, data):
            // """
            // Sends a payment request to the Pine Labs POS API.
            // 
            // :param dict data: Contains `amount`, `transactionNumber`, and `sequenceNumber`.
            // :return: On success, returns `responseCode`, `status`, and `plutusTransactionReferenceID`. 
            //         On failure, returns an error message.
            // :rtype: dict
            // """
            // body = {
            //     'Amount': data['amount'],
            //     'TransactionNumber': data['transactionNumber'],
            //     'SequenceNumber': data['sequenceNumber']
            // }
            // response = call_pine_labs(payment_method=self, endpoint='UploadBilledTransaction', payload=body)
            // if response.get('ResponseCode') == 0 and response.get('ResponseMessage') == "APPROVED":
            //     return {
            //         'responseCode': response['ResponseCode'],
            //         'status': response['ResponseMessage'],
            //         'plutusTransactionReferenceID': response['PlutusTransactionReferenceID'],
            //     }
            // default_error = _('The expected error code for the Pine Labs POS status request was not included in the response.')
            // error = response.get('ResponseMessage') or response.get('errorMessage') or default_error
            // return {"error": error}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> ProxyAdyenRequestAsync(Guid id, PosPaymentMethodProxyAdyenRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def proxy_adyen_request(self, data, operation=False):
            // ''' Necessary because Adyen's endpoints don't have CORS enabled '''
            // self.ensure_one()
            // if not self.env.su and not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessDenied()
            // if not data:
            //     raise UserError(_('Invalid Adyen request'))
            // 
            // if 'SaleToPOIRequest' in data and data['SaleToPOIRequest']['MessageHeader']['MessageCategory'] == 'Payment' and 'PaymentRequest' in data['SaleToPOIRequest']:  # Clear only if it is a payment request
            //     self.sudo().adyen_latest_response = ''  # avoid handling old responses multiple times
            // 
            // if not operation:
            //     operation = 'terminal_request'
            // 
            // # These checks are not optimal. This RPC method should be changed.
            // 
            // is_capture_data = operation == 'capture' and hasattr(self, 'adyen_merchant_account') and self._is_valid_adyen_request_data(data, {
            //     'originalReference': UNPREDICTABLE_ADYEN_DATA,
            //     'modificationAmount': {
            //         'value': UNPREDICTABLE_ADYEN_DATA,
            //         'currency': UNPREDICTABLE_ADYEN_DATA,
            //     },
            //     'merchantAccount': self.adyen_merchant_account,
            // })
            // 
            // is_adjust_data = operation == 'adjust' and hasattr(self, 'adyen_merchant_account') and self._is_valid_adyen_request_data(data, {
            //     'originalReference': UNPREDICTABLE_ADYEN_DATA,
            //     'modificationAmount': {
            //         'value': UNPREDICTABLE_ADYEN_DATA,
            //         'currency': UNPREDICTABLE_ADYEN_DATA,
            //     },
            //     'merchantAccount': self.adyen_merchant_account,
            //     'additionalData': {
            //         'industryUsage': 'DelayedCharge',
            //     },
            // })
            // 
            // is_cancel_data = operation == 'terminal_request' and self._is_valid_adyen_request_data(data, {
            //     'SaleToPOIRequest': {
            //         'MessageHeader': self._get_expected_message_header('Abort'),
            //         'AbortRequest': {
            //             'AbortReason': 'MerchantAbort',
            //             'MessageReference': {
            //                 'MessageCategory': 'Payment',
            //                 'SaleID': UNPREDICTABLE_ADYEN_DATA,
            //                 'ServiceID': UNPREDICTABLE_ADYEN_DATA,
            //             },
            //         },
            //     },
            // })
            // 
            // is_payment_request_with_acquirer_data = operation == 'terminal_request' and self._is_valid_adyen_request_data(data, self._get_expected_payment_request(True))
            // 
            // if is_payment_request_with_acquirer_data:
            //     parsed_sale_to_acquirer_data = parse_qs(data['SaleToPOIRequest']['PaymentRequest']['SaleData']['SaleToAcquirerData'])
            //     valid_acquirer_data = self._get_valid_acquirer_data()
            //     is_payment_request_with_acquirer_data = len(parsed_sale_to_acquirer_data.keys()) <= len(valid_acquirer_data.keys())
            //     if is_payment_request_with_acquirer_data:
            //         for key, values in parsed_sale_to_acquirer_data.items():
            //             if len(values) != 1:
            //                 is_payment_request_with_acquirer_data = False
            //                 break
            //             value = values[0]
            //             valid_value = valid_acquirer_data.get(key)
            //             if valid_value == UNPREDICTABLE_ADYEN_DATA:
            //                 continue
            //             if value != valid_value:
            //                 is_payment_request_with_acquirer_data = False
            //                 break
            // 
            // is_payment_request_without_acquirer_data = operation == 'terminal_request' and self._is_valid_adyen_request_data(data, self._get_expected_payment_request(False))
            // 
            // if not is_payment_request_without_acquirer_data and not is_payment_request_with_acquirer_data and not is_adjust_data and not is_cancel_data and not is_capture_data:
            //     raise UserError(_('Invalid Adyen request'))
            // 
            // if is_payment_request_with_acquirer_data or is_payment_request_without_acquirer_data:
            //     acquirer_data = data['SaleToPOIRequest']['PaymentRequest']['SaleData'].get('SaleToAcquirerData')
            //     msg_header = data['SaleToPOIRequest']['MessageHeader']
            //     metadata = 'metadata.pos_hmac=' + self._get_hmac(msg_header['SaleID'], msg_header['ServiceID'], msg_header['POIID'], data['SaleToPOIRequest']['PaymentRequest']['SaleData']['SaleTransactionID']['TransactionID'])
            // 
            //     data['SaleToPOIRequest']['PaymentRequest']['SaleData']['SaleToAcquirerData'] = acquirer_data + '&' + metadata if acquirer_data else metadata
            // 
            // return self._proxy_adyen_request_direct(data, operation)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> ProxyAdyenRequestDirectInternalAsync(object data, object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py) ---
            // def _proxy_adyen_request_direct(self, data, operation):
            // self.ensure_one()
            // TIMEOUT = 10
            // 
            // _logger.info('Request to Adyen by user #%d:\n%s', self.env.uid, pprint.pformat(data))
            // 
            // environment = 'test' if self.sudo().adyen_test_mode else 'live'
            // endpoint = self._get_adyen_endpoints()[operation] % environment
            // headers = {
            //     'x-api-key': self.sudo().adyen_api_key,
            // }
            // req = requests.post(endpoint, json=data, headers=headers, timeout=TIMEOUT)
            // 
            // # Authentication error doesn't return JSON
            // if req.status_code == 401:
            //     return {
            //         'error': {
            //             'status_code': req.status_code,
            //             'message': req.text
            //         }
            //     }
            // 
            // if req.text == 'ok':
            //     return True
            // 
            // return req.json()
            */
            return default;
        }

        public async Task<PosPaymentMethod> RazorpayCancelPaymentRequestAsync(Guid id, PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py) ---
            // def razorpay_cancel_payment_request(self, data):
            // razorpay = RazorpayPosRequest(self)
            // body = razorpay._razorpay_get_payment_request_body(payment_mode=False)
            // body.update({'origP2pRequestId': data.get('p2pRequestId')})
            // response = razorpay._call_razorpay(endpoint='cancel', payload=body)
            // if response.get('success') and not response.get('errorCode'):
            //     return {'error': _('Razorpay POS transaction canceled successfully')}
            // default_error_msg = _('Razorpay POS payment cancel request expected errorCode not found in the response')
            // errorMessage = response.get('errorMessage') or default_error_msg
            // return {'errorMessage': str(errorMessage)}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> RazorpayFetchPaymentStatusAsync(Guid id, PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py) ---
            // def razorpay_fetch_payment_status(self, data):
            // razorpay = RazorpayPosRequest(self)
            // body = razorpay._razorpay_get_payment_status_request_body()
            // body.update({'origP2pRequestId': data.get('p2pRequestId')})
            // response = razorpay._call_razorpay(endpoint='status', payload=body)
            // if response.get('success') and not response.get('errorCode'):
            //     payment_status = response.get('status')
            //     payment_messageCode = response.get('messageCode')
            //     if payment_status == 'AUTHORIZED' and payment_messageCode == 'P2P_DEVICE_TXN_DONE':
            //         return {
            //             'status': response.get('status'),
            //             'authCode': response.get('authCode'),
            //             'cardLastFourDigit': response.get('cardLastFourDigit'),
            //             'externalRefNumber': response.get('externalRefNumber'),
            //             'reverseReferenceNumber': response.get('reverseReferenceNumber'),
            //             'txnId': response.get('txnId'),
            //             'paymentMode': response.get('paymentMode'),
            //             'paymentCardType': response.get('paymentCardType'),
            //             'paymentCardBrand': response.get('paymentCardBrand'),
            //             'nameOnCard': response.get('nameOnCard'),
            //             'acquirerCode': response.get('acquirerCode'),
            //             'createdTime': response.get('createdTime'),
            //         }
            //     elif payment_status == 'FAILED' or payment_messageCode == 'P2P_DEVICE_CANCELED':
            //         return {'error': str(response.get('message', _('Razorpay POS transaction failed'))),
            //                 'payment_messageCode': payment_messageCode}
            //     elif payment_messageCode in ['P2P_DEVICE_RECEIVED', 'P2P_DEVICE_SENT', 'P2P_STATUS_QUEUED']:
            //         return {'status': payment_messageCode.split('_')[-1]}
            // default_error_msg = _('Razorpay POS payment status request expected errorCode not found in the response')
            // error = response.get('errorMessage') or default_error_msg
            // return {'error': str(error)}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> RazorpayMakePaymentRequestAsync(Guid id, PosPaymentMethodRazorpayMakePaymentRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py) ---
            // def razorpay_make_payment_request(self, data):
            // razorpay = RazorpayPosRequest(self)
            // body = razorpay._razorpay_get_payment_request_body(payment_mode=True)
            // body.update({
            //     'amount': data.get('amount'),
            //     'externalRefNumber': data.get('referenceId')
            // })
            // response = razorpay._call_razorpay(endpoint='pay', payload=body)
            // if response.get('success') and not response.get('errorCode'):
            //     return {
            //         'success': True,
            //         'p2pRequestId': str(response.get('p2pRequestId'))
            //     }
            // default_error_msg = _('Razorpay POS payment request expected errorCode not found in the response')
            // error = response.get('errorMessage') or default_error_msg
            // return {'error': str(error)}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> RetrieveSessionIdInternalAsync(object data_webhook)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _retrieve_session_id(self, data_webhook):
            // # Send a request to confirm the status of the sesions_id
            // # Need wait to the status of sesions_id is updated setted in session headers; code 202
            // 
            // MerchantTrns = data_webhook.get('MerchantTrns')
            // if not MerchantTrns:
            //     return self._send_notification(
            //         {'error': _(
            //             "Your transaction with Viva Wallet failed. Please try again later."
            //             )}
            //         )
            // session_id, pos_session_id = MerchantTrns.split("/")  # Split to retrieve pos_sessions_id
            // endpoint = f"sessions/{session_id}"
            // data = self._call_viva_wallet(endpoint, 'get')
            // 
            // if data.get('success'):
            //     data.update({'pos_session_id': pos_session_id, 'data_webhook': data_webhook})
            //     self.viva_wallet_latest_response = data
            //     self._send_notification(data)
            // else:
            //     self._send_notification(
            //         {'error': _(
            //             "There are some issues between us and Viva Wallet, try again later. %s",
            //             data.get('detail')
            //             )}
            //         )
            */
            return default;
        }

        protected async Task<PosPaymentMethod> SendNotificationInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _send_notification(self, data):
            // # Send a notification to the point of sale channel to indicate that the transaction are finish
            // pos_session_sudo = self.env["pos.session"].browse(int(data.get('pos_session_id', False)))
            // if pos_session_sudo:
            //     pos_session_sudo.config_id._notify('VIVA_WALLET_LATEST_RESPONSE', {
            //         'config_id': pos_session_sudo.config_id.id
            //     })
            */
            return default;
        }

        protected async Task<PosPaymentMethod> StripeCalculateAmountInternalAsync(object amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def _stripe_calculate_amount(self, amount):
            // currency = self.journal_id.currency_id or self.company_id.currency_id
            // return round(amount/currency.rounding)
            */
            return default;
        }

        public async Task<PosPaymentMethod> StripeCapturePaymentAsync(Guid id, PosPaymentMethodStripeCapturePaymentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def stripe_capture_payment(self, paymentIntentId, amount=None):
            // """Captures the payment identified by paymentIntentId.
            // 
            // :param paymentIntentId: the id of the payment to capture
            // :param amount: without this parameter the entire authorized
            //                amount is captured. Specifying a larger amount allows
            //                overcapturing to support tips.
            // """
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Do not have access to fetch token from Stripe"))
            // 
            // endpoint = ('payment_intents/%s/capture') % (werkzeug.urls.url_quote(paymentIntentId))
            // 
            // data = None
            // if amount is not None:
            //     data = {
            //         "amount_to_capture": self._stripe_calculate_amount(amount),
            //     }
            // 
            // return self.sudo()._get_stripe_payment_provider()._stripe_make_request(endpoint, data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> StripeConnectionTokenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def stripe_connection_token(self):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Do not have access to fetch token from Stripe"))
            // 
            // return self.sudo()._get_stripe_payment_provider()._stripe_make_request('terminal/connection_tokens')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> StripeKeyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def action_stripe_key(self):
            // res_id = self._get_stripe_payment_provider().id
            // # Redirect
            // return {
            //     'name': _('Stripe'),
            //     'res_model': 'payment.provider',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_id': res_id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> StripePaymentIntentAsync(Guid id, PosPaymentMethodStripePaymentIntentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py) ---
            // def stripe_payment_intent(self, amount):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Do not have access to fetch token from Stripe"))
            // 
            // # For Terminal payments, the 'payment_method_types' parameter must include
            // # at least 'card_present' and the 'capture_method' must be set to 'manual'.
            // currency = self.journal_id.currency_id or self.company_id.currency_id
            // 
            // params = [
            //     ("currency", currency.name),
            //     ("amount", self._stripe_calculate_amount(amount)),
            //     ("payment_method_types[]", "card_present"),
            //     ("capture_method", "manual"),
            // ]
            // 
            // if currency.name == 'AUD' and self.company_id.country_code == 'AU':
            //     # See https://stripe.com/docs/terminal/payments/regional?integration-country=AU
            //     # This parameter overrides "capture_method": "manual" above.
            //     params.append(("payment_method_options[card_present][capture_method]", "manual_preferred"))
            // elif currency.name == 'CAD' and self.company_id.country_code == 'CA':
            //     params.append(("payment_method_types[]", "interac_present"))
            // 
            // return self.sudo()._get_stripe_payment_provider()._stripe_make_request('payment_intents', params)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> VivaWalletAccountGetEndpointInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _viva_wallet_account_get_endpoint(self):
            // if self.viva_wallet_test_mode:
            //     return 'https://demo-accounts.vivapayments.com'
            // return 'https://accounts.vivapayments.com'
            */
            return default;
        }

        protected async Task<PosPaymentMethod> VivaWalletApiGetEndpointInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _viva_wallet_api_get_endpoint(self):
            // if self.viva_wallet_test_mode:
            //     return 'https://demo-api.vivapayments.com'
            // return 'https://api.vivapayments.com'
            */
            return default;
        }

        public async Task<PosPaymentMethod> VivaWalletGetPaymentStatusAsync(Guid id, PosPaymentMethodVivaWalletGetPaymentStatusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def viva_wallet_get_payment_status(self, session_id):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Only 'group_pos_user' are allowed to get the payment status from Viva Wallet"))
            // 
            // endpoint = f"sessions/{session_id}"
            // return self._call_viva_wallet(endpoint, 'get', should_retry=False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> VivaWalletSendPaymentCancelAsync(Guid id, PosPaymentMethodVivaWalletSendPaymentCancelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def viva_wallet_send_payment_cancel(self, data):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Only 'group_pos_user' are allowed to cancel a Viva Wallet payment"))
            // 
            // session_id = data.get('sessionId')
            // cash_register_id = data.get('cashRegisterId')
            // endpoint = f"sessions/{session_id}?cashRegisterId={cash_register_id}"
            // return self._call_viva_wallet(endpoint, 'delete')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PosPaymentMethod> VivaWalletSendPaymentRequestAsync(Guid id, PosPaymentMethodVivaWalletSendPaymentRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def viva_wallet_send_payment_request(self, data):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("Only 'group_pos_user' are allowed to send a Viva Wallet payment request"))
            // 
            // endpoint = "transactions:sale"
            // return self._call_viva_wallet(endpoint, 'post', data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosPaymentMethod> VivaWalletWebhookGetEndpointInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def _viva_wallet_webhook_get_endpoint(self):
            // if self.viva_wallet_test_mode:
            //     return 'https://demo.vivapayments.com'
            // return 'https://www.vivapayments.com'
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PosPaymentMethod entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py) ---
            // def write(self, vals):
            // if self._is_write_forbidden(set(vals.keys())):
            //     raise UserError(_('Please close and validate the following open PoS Sessions before modifying this payment method.\n'
            //                     'Open sessions: %s', (' '.join(self.open_session_ids.mapped('name')),)))
            // 
            // if 'payment_method_type' in vals:
            //     self._force_payment_method_type_values(vals, vals['payment_method_type'])
            //     return super().write(vals)
            // 
            // pmt_terminal = self.filtered(lambda pm: pm.payment_method_type == 'terminal')
            // pmt_qr = self.filtered(lambda pm: pm.payment_method_type == 'qr_code')
            // not_pmt = self - pmt_terminal - pmt_qr
            // 
            // res = True
            // forced_vals = vals.copy()
            // if pmt_terminal:
            //     self._force_payment_method_type_values(forced_vals, 'terminal', True)
            //     res = super(PosPaymentMethod, pmt_terminal).write(forced_vals) and res
            // if pmt_qr:
            //     self._force_payment_method_type_values(forced_vals, 'qr_code', True)
            //     res = super(PosPaymentMethod, pmt_qr).write(forced_vals) and res
            // if not_pmt:
            //     res = super(PosPaymentMethod, not_pmt).write(vals) and res
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py) ---
            // def write(self, vals):
            // records = super().write(vals)
            // 
            // if 'mp_id_point_smart' in vals or 'mp_bearer_token' in vals:
            //     self.mp_id_point_smart_complet = self._find_terminal(self.mp_bearer_token, self.mp_id_point_smart)
            // 
            // return records
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py) ---
            // def write(self, vals):
            // if 'is_online_payment' in vals:
            //     if vals['is_online_payment']:
            //         self._force_online_payment_values(vals)
            //     return super().write(vals)
            // 
            // opm = self.filtered('is_online_payment')
            // not_opm = self - opm
            // 
            // res = True
            // if opm:
            //     forced_vals = vals.copy()
            //     self._force_online_payment_values(forced_vals, True)
            //     res = super(PosPaymentMethod, opm).write(forced_vals) and res
            // if not_opm:
            //     res = super(PosPaymentMethod, not_opm).write(vals) and res
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: pos_viva_wallet, FILE: pos_payment_method.py) ---
            // def write(self, vals):
            // record = super().write(vals)
            // 
            // if vals.get('viva_wallet_merchant_id') and vals.get('viva_wallet_api_key'):
            //     self.viva_wallet_webhook_verification_key = self._get_verification_key(
            //         self._viva_wallet_webhook_get_endpoint(),
            //         self.viva_wallet_merchant_id,
            //         self.viva_wallet_api_key
            //         )
            //     if not self.viva_wallet_webhook_verification_key:
            //         raise UserError(_("Can't update payment method. Please check the data and update it."))
            // 
            // return record
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}