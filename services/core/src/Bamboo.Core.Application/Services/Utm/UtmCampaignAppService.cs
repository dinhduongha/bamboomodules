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
    [Module("Utm", Depends = new[] { "base", "web" })]
    public class UtmCampaignAppService : GenericApplicationService<UtmCampaign>, IUtmCampaignAppService
    {

        public UtmCampaignAppService(IRepository<UtmCampaign, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<UtmCampaign> ComputeAbTestingCompletedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py) ---
            // def _compute_ab_testing_completed(self):
            // for campaign in self:
            //     campaign.ab_testing_completed = bool(self.ab_testing_winner_mailing_id)
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeClicksCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: utm.py) ---
            // def _compute_clicks_count(self):
            // click_data = self.env['link.tracker.click']._read_group(
            //     [('campaign_id', 'in', self.ids)],
            //     ['campaign_id'], ['__count'])
            // 
            // mapped_data = {campaign.id: count for campaign, count in click_data}
            // 
            // for campaign in self:
            //     campaign.click_count = mapped_data.get(campaign.id, 0)
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeCrmLeadCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: utm.py) ---
            // def _compute_crm_lead_count(self):
            // lead_data = self.env['crm.lead'].with_context(active_test=False)._read_group([
            //     ('campaign_id', 'in', self.ids)],
            //     ['campaign_id'], ['__count'])
            // mapped_data = {campaign.id: count for campaign, count in lead_data}
            // for campaign in self:
            //     campaign.crm_lead_count = mapped_data.get(campaign.id, 0)
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeIsMailingCampaignActivatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py) ---
            // def _compute_is_mailing_campaign_activated(self):
            // self.is_mailing_campaign_activated = self.env.user.has_group('mass_mailing.group_mass_mailing_campaign')
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeMailingMailCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py) ---
            // def _compute_mailing_mail_count(self):
            // mailing_data = self.env['mailing.mailing']._read_group(
            //     [('campaign_id', 'in', self.ids), ('mailing_type', '=', 'mail')],
            //     ['campaign_id', 'ab_testing_enabled'],
            //     ['__count'],
            // )
            // ab_testing_mapped_data = defaultdict(list)
            // mapped_data = defaultdict(list)
            // for campaign, ab_testing_enabled, count in mailing_data:
            //     if ab_testing_enabled:
            //         ab_testing_mapped_data[campaign.id].append(count)
            //     mapped_data[campaign.id].append(count)
            // for campaign in self:
            //     campaign.mailing_mail_count = sum(mapped_data[campaign._origin.id or campaign.id])
            //     campaign.ab_testing_mailings_count = sum(ab_testing_mapped_data[campaign._origin.id or campaign.id])
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeMailingSmsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py) ---
            // def _compute_mailing_sms_count(self):
            // mailing_sms_data = self.env['mailing.mailing']._read_group(
            //     [('campaign_id', 'in', self.ids), ('mailing_type', '=', 'sms')],
            //     ['campaign_id', 'ab_testing_enabled'],
            //     ['__count'],
            // )
            // ab_testing_mapped_sms_data = defaultdict(list)
            // mapped_sms_data = defaultdict(list)
            // for campaign, ab_testing_enabled, count in mailing_sms_data:
            //     if ab_testing_enabled:
            //         ab_testing_mapped_sms_data[campaign.id].append(count)
            //     mapped_sms_data[campaign.id].append(count)
            // 
            // for campaign in self:
            //     campaign.mailing_sms_count = sum(mapped_sms_data[campaign.id])
            //     campaign.ab_testing_mailings_sms_count = sum(ab_testing_mapped_sms_data[campaign.id])
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_campaign.py) ---
            // def _compute_name(self):
            // new_names = self.env['utm.mixin'].with_context(
            //     utm_check_skip_record_ids=self.ids
            // )._get_unique_names(self._name, [c.title for c in self])
            // for campaign, new_name in zip(self, new_names):
            //     campaign.name = new_name
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeQuotationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py) ---
            // def _compute_quotation_count(self):
            // quotation_data = self.env['sale.order']._read_group([
            //     ('campaign_id', 'in', self.ids)],
            //     ['campaign_id'], ['__count'])
            // data_map = {campaign.id: count for campaign, count in quotation_data}
            // for campaign in self:
            //     campaign.quotation_count = data_map.get(campaign.id, 0)
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeSaleInvoicedAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py) ---
            // def _compute_sale_invoiced_amount(self):
            // self.env['account.move.line'].flush_model(['balance', 'move_id', 'account_id', 'display_type'])
            // self.env['account.move'].flush_model(['state', 'campaign_id', 'move_type'])
            // query = """SELECT move.campaign_id, -SUM(line.balance) as price_subtotal
            //             FROM account_move_line line
            //             INNER JOIN account_move move ON line.move_id = move.id
            //             WHERE move.state not in ('draft', 'cancel')
            //                 AND move.campaign_id IN %s
            //                 AND move.move_type IN ('out_invoice', 'out_refund', 'in_invoice', 'in_refund', 'out_receipt', 'in_receipt')
            //                 AND line.account_id IS NOT NULL
            //                 AND line.display_type = 'product'
            //             GROUP BY move.campaign_id
            //             """
            // 
            // self._cr.execute(query, [tuple(self.ids)])
            // query_res = self._cr.dictfetchall()
            // 
            // campaigns = self.browse()
            // for datum in query_res:
            //     campaign = self.browse(datum['campaign_id'])
            //     campaign.invoiced_amount = datum['price_subtotal']
            //     campaigns |= campaign
            // for campaign in (self - campaigns):
            //     campaign.invoiced_amount = 0
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeStatisticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py) ---
            // def _compute_statistics(self):
            // """ Compute statistics of the mass mailing campaign """
            // default_vals = {
            //     'received_ratio': 0,
            //     'opened_ratio': 0,
            //     'replied_ratio': 0,
            //     'bounced_ratio': 0
            // }
            // if not self.ids:
            //     self.update(default_vals)
            //     return
            // self.env.cr.execute("""
            //     SELECT
            //         c.id as campaign_id,
            //         COUNT(s.id) AS expected,
            //         COUNT(s.sent_datetime) AS sent,
            //         COUNT(s.trace_status) FILTER (WHERE s.trace_status in ('sent', 'open', 'reply')) AS delivered,
            //         COUNT(s.trace_status) FILTER (WHERE s.trace_status in ('open', 'reply')) AS open,
            //         COUNT(s.trace_status) FILTER (WHERE s.trace_status = 'reply') AS reply,
            //         COUNT(s.trace_status) FILTER (WHERE s.trace_status = 'bounce') AS bounce,
            //         COUNT(s.trace_status) FILTER (WHERE s.trace_status = 'cancel') AS cancel
            //     FROM
            //         mailing_trace s
            //     RIGHT JOIN
            //         utm_campaign c
            //         ON (c.id = s.campaign_id)
            //     WHERE
            //         c.id IN %s
            //     GROUP BY
            //         c.id
            // """, (tuple(self.ids), ))
            // 
            // all_stats = self.env.cr.dictfetchall()
            // stats_per_campaign = {
            //     stats['campaign_id']: stats
            //     for stats in all_stats
            // }
            // 
            // for campaign in self:
            //     stats = stats_per_campaign.get(campaign.id)
            //     if not stats:
            //         vals = default_vals
            //     else:
            //         total = (stats['expected'] - stats['cancel']) or 1
            //         delivered = stats['sent'] - stats['bounce']
            //         vals = {
            //             'received_ratio': float_round(100.0 * delivered / total, precision_digits=2),
            //             'opened_ratio': float_round(100.0 * stats['open'] / total, precision_digits=2),
            //             'replied_ratio': float_round(100.0 * stats['reply'] / total, precision_digits=2),
            //             'bounced_ratio': float_round(100.0 * stats['bounce'] / total, precision_digits=2)
            //         }
            // 
            //     campaign.update(vals)
            */
            return default;
        }

        protected async Task<UtmCampaign> ComputeUseLeadsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: utm.py) ---
            // def _compute_use_leads(self):
            // self.use_leads = self.env.user.has_group('crm.group_use_lead')
            */
            return default;
        }

        public async Task<UtmCampaign> CreateMassSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py) ---
            // def action_create_mass_sms(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing.action_create_mass_mailings_from_campaign")
            // action['context'] = {
            //     'default_campaign_id': self.id,
            //     'default_mailing_type': 'sms',
            //     'search_default_assigned_to_me': 1,
            //     'search_default_campaign_id': self.id,
            //     'default_user_id': self.env.user.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<UtmCampaign> CronProcessMassMailingAbTestingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py) ---
            // def _cron_process_mass_mailing_ab_testing(self):
            // """ Cron that manages A/B testing and sends a winner mailing computed based on
            // the value set on the A/B testing campaign.
            // In case there is no mailing sent for an A/B testing campaign we ignore this campaign
            // """
            // ab_testing_campaign = self.search([
            //     ('ab_testing_schedule_datetime', '<=', fields.Datetime.now()),
            //     ('ab_testing_winner_selection', '!=', 'manual'),
            //     ('ab_testing_completed', '=', False),
            // ])
            // for campaign in ab_testing_campaign:
            //     ab_testing_mailings = campaign.mailing_mail_ids.filtered(lambda m: m.ab_testing_enabled)
            //     if not ab_testing_mailings.filtered(lambda m: m.state == 'done'):
            //         continue
            //     ab_testing_mailings.action_send_winner_mailing()
            // return ab_testing_campaign
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py) ---
            // def _cron_process_mass_mailing_ab_testing(self):
            // ab_testing_campaign = super()._cron_process_mass_mailing_ab_testing()
            // for campaign in ab_testing_campaign:
            //     ab_testing_mailings = campaign.mailing_sms_ids.filtered(lambda m: m.ab_testing_enabled)
            //     if not ab_testing_mailings.filtered(lambda m: m.state == 'done'):
            //         continue
            //     ab_testing_mailings.action_send_winner_mailing()
            // return ab_testing_campaign
            */
            return default;
        }

        protected async Task<UtmCampaign> GetMailingRecipientsInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_campaign.py) ---
            // def _get_mailing_recipients(self, model=None):
            // """Return the recipients of a mailing campaign. This is based on the statistics
            // build for each mailing. """
            // res = dict.fromkeys(self.ids, {})
            // for campaign in self:
            //     domain = [('campaign_id', '=', campaign.id)]
            //     if model:
            //         domain += [('model', '=', model)]
            //     res[campaign.id] = set(self.env['mailing.trace'].search(domain).mapped('res_id'))
            // return res
            */
            return default;
        }

        protected async Task<UtmCampaign> GroupExpandStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_campaign.py) ---
            // def _group_expand_stage_ids(self, stages, domain):
            // """Read group customization in order to display all the stages in the
            // Kanban view, even if they are empty.
            // """
            // stage_ids = stages.sudo()._search([], order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<UtmCampaign> RedirectToInvoicedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py) ---
            // def action_redirect_to_invoiced(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_journal_line")
            // invoices = self.env['account.move'].search([('campaign_id', '=', self.id)])
            // action['context'] = {
            //     'create': False,
            //     'edit': False,
            //     'view_no_maturity': True
            // }
            // action['domain'] = [
            //     ('id', 'in', invoices.ids),
            //     ('move_type', 'in', ('out_invoice', 'out_refund', 'in_invoice', 'in_refund', 'out_receipt', 'in_receipt')),
            //     ('state', 'not in', ['draft', 'cancel'])
            // ]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<UtmCampaign> RedirectToLeadsOpportunitiesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: utm.py) ---
            // def action_redirect_to_leads_opportunities(self):
            // view = 'crm.crm_lead_all_leads' if self.use_leads else 'crm.crm_lead_opportunities'
            // action = self.env['ir.actions.act_window']._for_xml_id(view)
            // action['view_mode'] = 'list,kanban,graph,pivot,form,calendar'
            // action['domain'] = [('campaign_id', 'in', self.ids)]
            // action['context'] = {'active_test': False, 'create': False}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<UtmCampaign> RedirectToMailingSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py) ---
            // def action_redirect_to_mailing_sms(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing_sms.mailing_mailing_action_sms")
            // action['context'] = {
            //     'default_campaign_id': self.id,
            //     'default_mailing_type': 'sms',
            //     'search_default_assigned_to_me': 1,
            //     'search_default_campaign_id': self.id,
            //     'default_user_id': self.env.user.id,
            // }
            // action['domain'] = [('mailing_type', '=', 'sms')]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<UtmCampaign> RedirectToQuotationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: utm_campaign.py) ---
            // def action_redirect_to_quotations(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.action_quotations_with_onboarding")
            // action['domain'] = [('campaign_id', '=', self.id)]
            // action['context'] = {'default_campaign_id': self.id}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<UtmCampaign> UnlinkExceptUtmCampaignJobInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: utm_campaign.py) ---
            // def _unlink_except_utm_campaign_job(self):
            // utm_campaign_job = self.env.ref('hr_recruitment.utm_campaign_job', raise_if_not_found=False)
            // if utm_campaign_job and utm_campaign_job in self:
            //     raise UserError(_(
            //         "The UTM campaign '%s' cannot be deleted as it is used in the recruitment process.",
            //         utm_campaign_job.name
            //     ))
            */
            return default;
        }
    }
}