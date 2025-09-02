using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("sale_edi_ubl", Depends = new[] { "sale", "account_edi_ubl_cii" })]
    public class SaleEdiCommonAppService : ApplicationService, ISaleEdiCommonAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public SaleEdiCommonAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _get_line_xpaths(self, document_type=None, qty_factor=1):
            // # Override account.edi.xml.ubl_bis3
            // return {
            //     **super()._get_line_xpaths(),
            //     'delivered_qty': ('./{*}Quantity'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerDetailStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _get_partner_detail_str(self, name, phone=False, email=False, vat=False):
            // """ Return partner details string to help user find or create proper contact with details.
            // """
            // partner_details = _("Name: %(name)s, Vat: %(vat)s", name=name, vat=vat)
            // if phone:
            //     partner_details += _(", Phone: %(phone)s", phone=phone)
            // if email:
            //     partner_details += _(", Email: %(email)s", email=email)
            // 
            // return partner_details
            */
            return default;
        }

        public async Task<TEntity> ImportDeliveryPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object name, object phone, object email) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_delivery_partner(self, order, name, phone, email):
            // """ Import delivery address from details if not found then log details."""
            // logs = []
            // dest_partner = self.env['res.partner'].with_company(
            //     order.company_id
            // )._retrieve_partner(name=name, phone=phone, email=email)
            // if not dest_partner:
            //     partner_detaits_str = self._get_partner_detail_str(name, phone, email)
            //     logs.append(_("Could not retrieve Delivery Address with Details: { %s }", partner_detaits_str))
            // 
            // return dest_partner, logs
            */
            return default;
        }

        public async Task<TEntity> ImportFillOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_fill_order(self, order, tree):
            // """ Fill order details by extracting details from xml tree.
            // 
            // param order: Order to fill details from xml tree.
            // param tree: Xml tree to extract details.
            // :return: list of logs to add warnig and information about data from xml.
            // """
            // logs = []
            // order_values = {}
            // partner, partner_logs = self._import_partner(
            //     order.company_id,
            //     **self._import_retrieve_partner_vals(tree, "BuyerCustomer"),
            // )
            // if partner:
            //     order_values['partner_id'] = partner.id
            // delivery_partner, delivery_partner_logs = self._import_delivery_partner(
            //     order,
            //     **self._import_retrieve_delivery_vals(tree),
            // )
            // if delivery_partner:
            //     order_values['partner_shipping_id'] = delivery_partner.id
            // order_values['currency_id'], currency_logs = self._import_currency(tree, './/{*}DocumentCurrencyCode')
            // 
            // order_values['date_order'] = tree.findtext('./{*}IssueDate')
            // order_values['client_order_ref'] = tree.findtext('./{*}ID')
            // order_values['note'] = self._import_description(tree, xpaths=['./{*}Note'])
            // order_values['origin'] = tree.findtext('./{*}OriginatorDocumentReference/{*}ID')
            // order_values['payment_term_id'] = self._import_payment_term_id(order, tree, './/cac:PaymentTerms/cbc:Note')
            // 
            // allowance_charges_line_vals, allowance_charges_logs = self._import_document_allowance_charges(tree, order, 'sale')
            // lines_vals, line_logs = self._import_order_lines(order, tree, './{*}OrderLine/{*}LineItem')
            // lines_vals += allowance_charges_line_vals
            // 
            // order_values = {
            //     **order_values,
            //     'order_line': [Command.create(line_vals) for line_vals in lines_vals],
            // }
            // order_values, order_logs = self._import_fill_order_prepare_vals(order, tree, order_values)
            // order.write(order_values)
            // logs += partner_logs + delivery_partner_logs + currency_logs + line_logs + allowance_charges_logs + order_logs
            // 
            // return logs
            */
            return default;
        }

        public async Task<TEntity> ImportFillOrderPrepareValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object order_values) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_fill_order_prepare_vals(self, order, tree, order_values):
            // """ Prepare order values before writing to the order.
            // 
            // :param order: Order to fill details from xml tree.
            // :param tree: Xml tree to extract details.
            // :param order_values: Values to write on the order.
            // :return: Tuple of order values and logs.
            // """
            // # Override this method if you need to add or modify values before writing
            // return order_values, []
            */
            return default;
        }

        public async Task<TEntity> ImportOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xpath) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_order_lines(self, order, tree, xpath):
            // """ Import order lines from xml tree.
            // 
            // :param order: Order to set order line on.
            // :param tree: Xml tree to extract OrderLine from.
            // :param xpath: Xpath for order line items.
            // :return: Logging information related orderlines details.
            // :rtype: List
            // """
            // logs = []
            // lines_values = []
            // for line_tree in tree.iterfind(xpath):
            //     line_values = self._retrieve_line_vals(line_tree)
            //     line_values = {
            //         **line_values,
            //         'product_uom_qty': line_values['quantity'],
            //         'product_uom': line_values['product_uom_id'],
            //     }
            //     del line_values['quantity']
            //     # To do: rename product_uom field to `product_uom_id` of sale.order.line
            //     del line_values['product_uom_id']
            //     if not line_values['product_id']:
            //         logs += [_("Could not retrieve product for line '%s'", line_values['name'])]
            //     # To do: rename tax_id field to `tax_ids` of sale.order.line
            //     line_values['tax_id'], tax_logs = self._retrieve_taxes(
            //         order, line_values, 'sale',
            //     )
            //     logs += tax_logs
            //     lines_values += self._retrieve_line_charges(order, line_values, line_values['tax_id'])
            //     if not line_values['product_uom']:
            //         line_values.pop('product_uom')  # if no uom, pop it so it's inferred from the product_id
            //     lines_values.append(line_values)
            // 
            // return lines_values, logs
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_order_ubl(self, order, file_data):
            // """ Common importing method to extract order data from file_data.
            // 
            // :param order: Order to fill details from file_data.
            // :param file_data: File data to extract order related data from.
            // :return: True if there no exception while extraction.
            // :rtype: Boolean
            // """
            // tree = file_data['xml_tree']
            // 
            // # Update the order.
            // logs = self._import_fill_order(order, tree)
            // if order:
            //     body = Markup("<strong>%s</strong>") % \
            //         _("Format used to import the invoice: %s",
            //           self.env['ir.model']._get(self._name).name)
            //     if logs:
            //         order._create_activity_set_details()
            //         body += Markup("<ul>%s</ul>") % \
            //             Markup().join(Markup("<li>%s</li>") % l for l in logs)
            //     order.message_post(body=body)
            // 
            // lines_with_products = order.order_line.filtered('product_id')
            // # Recompute product price and discount according to sale price
            // lines_with_products._compute_price_unit()
            // lines_with_products._compute_discount()
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ImportPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_partner(self, company_id, name, phone, email, vat, **kwargs):
            // """ Override of edi.mixin to set current user partner if there is no matching partner
            // found and log details related to partner."""
            // partner, logs = super()._import_partner(company_id, name, phone, email, vat, **kwargs)
            // if not partner:
            //     partner_detaits_str = self._get_partner_detail_str(name, phone, email, vat)
            //     if not vat:
            //         logs.append(_("Insufficient details to extract Customer: { %s }", partner_detaits_str))
            //     else:
            //         logs.append(_("Could not retrive Customer with Details: { %s }", partner_detaits_str))
            // 
            // return partner, logs
            */
            return default;
        }

        public async Task<TEntity> ImportPaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xapth) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_payment_term_id(self, order, tree, xapth):
            // """ Return payment term from given tree. """
            // payment_term_note = self._find_value(xapth, tree)
            // if not payment_term_note:
            //     return False
            // 
            // return self.env['account.payment.term'].search([
            //     *self.env['account.payment.term']._check_company_domain(order.company_id),
            //     ('name', '=', payment_term_note)
            // ], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ImportRetrieveDeliveryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, ISaleEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_retrieve_delivery_vals(self, tree):
            // """ Returns a dict of values that will be used to retrieve the delivery address. """
            // return {
            //     'phone': self._find_value('.//cac:Delivery/cac:DeliveryParty//cbc:Telephone', tree),
            //     'email': self._find_value('.//cac:Delivery/cac:DeliveryParty//cbc:ElectronicMail', tree),
            //     'name': self._find_value('.//cac:Delivery/cac:DeliveryParty//cbc:Name', tree),
            // }
            */
            return default;
        }
    }
}