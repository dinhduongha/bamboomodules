using Bamboo.Core.Application.Contracts.DTOs;
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
    public class IrProfileAppService : GenericApplicationService<IrProfile>, IIrProfileAppService
    {

        public IrProfileAppService(IRepository<IrProfile, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrProfile> ComputeSpeedscopeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def _compute_speedscope(self):
            // for execution in self:
            //     sp = Speedscope(init_stack_trace=json.loads(execution.init_stack_trace))
            //     if execution.sql:
            //         sp.add('sql', json.loads(execution.sql))
            //     if execution.traces_async:
            //         sp.add('frames', json.loads(execution.traces_async))
            //     if execution.traces_sync:
            //         sp.add('settrace', json.loads(execution.traces_sync))
            // 
            //     result = json.dumps(sp.add_default().make())
            //     execution.speedscope = base64.b64encode(result.encode('utf-8'))
            */
            return default;
        }

        protected async Task<IrProfile> ComputeSpeedscopeUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def _compute_speedscope_url(self):
            // for profile in self:
            //     profile.speedscope_url = f'/web/speedscope/{profile.id}'
            */
            return default;
        }

        protected async Task<IrProfile> EnabledUntilInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def _enabled_until(self):
            // """
            // If the profiling is enabled, return until when it is enabled.
            // Otherwise return ``None``.
            // """
            // limit = self.env['ir.config_parameter'].sudo().get_param('base.profiling_enabled_until', '')
            // return limit if str(fields.Datetime.now()) < limit else None
            */
            return default;
        }

        protected async Task<IrProfile> GcProfileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def _gc_profile(self):
            // # remove profiles older than 30 days
            // domain = [('create_date', '<', fields.Datetime.now() - datetime.timedelta(days=30))]
            // return self.sudo().search(domain).unlink()
            */
            return default;
        }

        public async Task<IrProfile> SetProfilingAsync(Guid id, IrProfileSetProfilingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_profile.py) ---
            // def set_profiling(self, profile=None, collectors=None, params=None):
            // """
            // Enable or disable profiling for the current user.
            // 
            // :param profile: ``True`` to enable profiling, ``False`` to disable it.
            // :param list collectors: optional list of collectors to use (string)
            // :param dict params: optional parameters set on the profiler object
            // """
            // # Note: parameters are coming from a rpc calls or route param (public user),
            // # meaning that corresponding session variables are client-defined.
            // # This allows to activate any profiler, but can be
            // # dangerous handling request.session.profile_collectors/profile_params.
            // if profile:
            //     limit = self._enabled_until()
            //     _logger.info("User %s started profiling", self.env.user.name)
            //     if not limit:
            //         request.session.profile_session = None
            //         if self.env.user._is_system():
            //             return {
            //                     'type': 'ir.actions.act_window',
            //                     'view_mode': 'form',
            //                     'res_model': 'base.enable.profiling.wizard',
            //                     'target': 'new',
            //                     'views': [[False, 'form']],
            //                 }
            //         raise UserError(_('Profiling is not enabled on this database. Please contact an administrator.'))
            //     if not request.session.profile_session:
            //         request.session.profile_session = make_session(self.env.user.name)
            //         request.session.profile_expiration = limit
            //         if request.session.profile_collectors is None:
            //             request.session.profile_collectors = []
            //         if request.session.profile_params is None:
            //             request.session.profile_params = {}
            // elif profile is not None:
            //     request.session.profile_session = None
            // 
            // if collectors is not None:
            //     request.session.profile_collectors = collectors
            // 
            // if params is not None:
            //     request.session.profile_params = params
            // 
            // return {
            //     'session': request.session.profile_session,
            //     'collectors': request.session.profile_collectors,
            //     'params': request.session.profile_params,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}