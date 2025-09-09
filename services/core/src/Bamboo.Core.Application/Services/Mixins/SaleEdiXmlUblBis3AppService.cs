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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("sale_edi_ubl", Depends = new[] { "sale", "account_edi_ubl_cii" })]
    public class SaleEdiXmlUblBis3AppService : ApplicationService, ISaleEdiXmlUblBis3AppService
    {
        private readonly IServiceProvider _serviceProvider;
        public SaleEdiXmlUblBis3AppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
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

        public async Task<TEntity> ImportFillOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
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

        public async Task<TEntity> ImportFillOrderPrepareValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object order_values) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
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

        public async Task<TEntity> ImportRetrieveDeliveryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, ISaleEdiXmlUblBis3able
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