using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("PurchaseRequisitionModule", Category = "SupplyChain", Depends = new[] { "purchase" })]
    public class PurchaseRequisitionAppService : GenericApplicationService<PurchaseRequisition>, IPurchaseRequisitionAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public PurchaseRequisitionAppService(IRepository<PurchaseRequisition, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<PurchaseRequisition> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def action_cancel(self):
            // # try to set all associated quotations to cancel state
            // for requisition in self:
            //     for requisition_line in requisition.line_ids:
            //         requisition_line.supplier_info_ids.sudo().unlink()
            //     requisition.purchase_ids.button_cancel()
            //     for po in requisition.purchase_ids:
            //         po.message_post(body=_('Cancelled by the agreement associated to this quotation.'))
            // self.state = 'cancel'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseRequisition> CheckDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _check_dates(self):
            // invalid_requsitions = self.filtered(lambda r: r.date_end and r.date_start and r.date_end < r.date_start)
            // if invalid_requsitions:
            //     raise ValidationError(_(
            //         "End date cannot be earlier than start date. Please check dates for agreements: %s", ', '.join(invalid_requsitions.mapped('name'))
            //     ))
            */
            return default;
        }

        protected async Task<PurchaseRequisition> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _compute_currency_id(self):
            // for requisition in self:
            //     if not requisition.vendor_id or not requisition.vendor_id.property_purchase_currency_id:
            //         requisition.currency_id = requisition.company_id.currency_id.id
            //     else:
            //         requisition.currency_id = requisition.vendor_id.property_purchase_currency_id.id
            */
            return default;
        }

        protected async Task<PurchaseRequisition> ComputeOrdersNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _compute_orders_number(self):
            // for requisition in self:
            //     requisition.order_count = len(requisition.purchase_ids)
            */
            return default;
        }

        public async Task<PurchaseRequisition> ConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def action_confirm(self):
            // self.ensure_one()
            // if not self.line_ids:
            //     raise UserError(_("You cannot confirm agreement '%(agreement)s' because it does not contain any product lines.", agreement=self.name))
            // if self.requisition_type == 'blanket_order':
            //     for requisition_line in self.line_ids:
            //         if requisition_line.price_unit <= 0.0:
            //             raise UserError(_('You cannot confirm a blanket order with lines missing a price.'))
            //         if requisition_line.product_qty <= 0.0:
            //             raise UserError(_('You cannot confirm a blanket order with lines missing a quantity.'))
            //         requisition_line._create_supplier_info()
            // self.state = 'confirmed'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseRequisition> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: purchase_requisition.py) ---
            // def _default_picking_type_id(self):
            // picking_type = self.env['stock.picking.type'].search([('warehouse_id.company_id', '=', self.env.company.id), ('code', '=', 'incoming')], limit=1)
            // if not picking_type:
            //     self.env['stock.warehouse']._warehouse_redirect_warning()
            // return picking_type
            */
            return default;
        }

        public async Task<PurchaseRequisition> DoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def action_done(self):
            // """
            // Generate all purchase order based on selected lines, should only be called on one agreement at a time
            // """
            // if any(purchase_order.state in ['draft', 'sent', 'to approve'] for purchase_order in self.mapped('purchase_ids')):
            //     raise UserError(_("To close this purchase requisition, cancel related Requests for Quotation.\n\n"
            //         "Imagine the mess if someone confirms these duplicates: double the order, double the trouble :)"))
            // for requisition in self:
            //     for requisition_line in requisition.line_ids:
            //         requisition_line.supplier_info_ids.sudo().unlink()
            // self.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PurchaseRequisition> DraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def action_draft(self):
            // self.ensure_one()
            // self.state = 'draft'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PurchaseRequisition> OnchangeVendorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _onchange_vendor(self):
            // requisitions = self.env['purchase.requisition'].search([
            //     ('vendor_id', '=', self.vendor_id.id),
            //     ('state', '=', 'confirmed'),
            //     ('requisition_type', '=', 'blanket_order'),
            //     ('company_id', '=', self.company_id.id),
            // ])
            // if any(requisitions):
            //     title = _("Warning for %s", self.vendor_id.name)
            //     message = _("There is already an open blanket order for this supplier. We suggest you complete this open blanket order, instead of creating a new one.")
            //     warning = {
            //         'title': title,
            //         'message': message
            //     }
            //     return {'warning': warning}
            */
            return default;
        }

        protected async Task<PurchaseRequisition> UnlinkIfDraftOrCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _unlink_if_draft_or_cancel(self):
            // if any(requisition.state not in ('draft', 'cancel') for requisition in self):
            //     raise UserError(_('You can only delete draft or cancelled requisitions.'))
            */
            return default;
        }
    }
}