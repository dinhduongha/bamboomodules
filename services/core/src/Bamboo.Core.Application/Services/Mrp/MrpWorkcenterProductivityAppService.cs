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
    [Module("Mrp", Depends = new[] { "product", "stock", "resource" })]
    public class MrpWorkcenterProductivityAppService : GenericApplicationService<MrpWorkcenterProductivity>, IMrpWorkcenterProductivityAppService
    {

        public MrpWorkcenterProductivityAppService(IRepository<MrpWorkcenterProductivity, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<MrpWorkcenterProductivity> ButtonBlockAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def button_block(self):
            // self.ensure_one()
            // self.workcenter_id.order_ids.end_all()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpWorkcenterProductivity> CheckOpenTimeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _check_open_time_ids(self):
            // for workorder in self.workorder_id:
            //     open_time_ids_by_user = self.env["mrp.workcenter.productivity"]._read_group(
            //         [("id", "in", workorder.time_ids.ids), ("date_end", "=", False)],
            //         ["user_id"], having=[("__count", ">", 1)],
            //     )
            //     if open_time_ids_by_user:
            //         raise ValidationError(_('The Workorder (%s) cannot be started twice!', workorder.display_name))
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> CloseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _close(self):
            // underperformance_timers = self.env['mrp.workcenter.productivity']
            // for timer in self:
            //     wo = timer.workorder_id
            //     timer.write({'date_end': fields.Datetime.now()})
            //     if wo.duration > wo.duration_expected:
            //         productive_date_end = timer.date_end - relativedelta.relativedelta(minutes=wo.duration - wo.duration_expected)
            //         if productive_date_end <= timer.date_start:
            //             underperformance_timers |= timer
            //         else:
            //             underperformance_timers |= timer.copy({'date_start': productive_date_end})
            //             timer.write({'date_end': productive_date_end})
            // if underperformance_timers:
            //     underperformance_type = self.env['mrp.workcenter.productivity.loss'].search([('loss_type', '=', 'performance')], limit=1)
            //     if not underperformance_type:
            //         raise UserError(_("You need to define at least one unactive productivity loss in the category 'Performance'. Create one from the Manufacturing app, menu: Configuration / Productivity Losses."))
            //     underperformance_timers.write({'loss_id': underperformance_type.id})
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_duration(self):
            // for blocktime in self:
            //     if blocktime.date_start and blocktime.date_end:
            //         blocktime.duration = blocktime.loss_id._convert_to_duration(blocktime.date_start.replace(microsecond=0), blocktime.date_end.replace(microsecond=0), blocktime.workcenter_id)
            //     else:
            //         blocktime.duration = 0.0
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> DateEndChangedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _date_end_changed(self):
            // if not self.date_end:
            //     return
            // self.date_start = self.date_end - timedelta(minutes=self.duration)
            // self._loss_type_change()
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> DateStartChangedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _date_start_changed(self):
            // if not self.date_start:
            //     return
            // self.date_end = self.date_start + timedelta(minutes=self.duration)
            // self._loss_type_change()
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> DurationChangedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _duration_changed(self):
            // if not self.date_end:
            //     return
            // self.date_start = self.date_end - timedelta(minutes=self.duration)
            // self._loss_type_change()
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> GetDefaultCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_default_company_id(self):
            // company_id = False
            // if self.env.context.get('default_company_id'):
            //     company_id = self.env.context['default_company_id']
            // if not company_id and self.env.context.get('default_workorder_id'):
            //     workorder = self.env['mrp.workorder'].browse(self.env.context['default_workorder_id'])
            //     company_id = workorder.company_id
            // if not company_id and self.env.context.get('default_workcenter_id'):
            //     workcenter = self.env['mrp.workcenter'].browse(self.env.context['default_workcenter_id'])
            //     company_id = workcenter.company_id
            // if not company_id:
            //     company_id = self.env.company
            // return company_id
            */
            return default;
        }

        protected async Task<MrpWorkcenterProductivity> LossTypeChangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _loss_type_change(self):
            // self.ensure_one()
            // if self.workorder_id.duration > self.workorder_id.duration_expected:
            //     self.loss_id = self.env.ref("mrp.block_reason4").id
            // else:
            //     self.loss_id = self.env.ref("mrp.block_reason7").id
            */
            return default;
        }
    }
}