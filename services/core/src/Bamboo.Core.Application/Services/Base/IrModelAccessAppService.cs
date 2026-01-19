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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class IrModelAccessAppService : GenericApplicationService<IrModelAccess>, IIrModelAccessAppService
    {

        public IrModelAccessAppService(IRepository<IrModelAccess, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<IrModelAccess> CallCacheClearingMethodsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def call_cache_clearing_methods(self):
            // self.env.invalidate_all()
            // self.env.registry.clear_cache('stable')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModelAccess> CheckAsync(Guid id, IrModelAccessCheckRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def check(self, model, mode='read', raise_exception=True):
            // if self.env.su:
            //     # User root have all accesses
            //     return True
            // 
            // assert isinstance(model, str), 'Not a model name: %s' % (model,)
            // 
            // if model not in self.env:
            //     _logger.error('Missing model %s', model)
            // 
            // has_access = model in self._get_allowed_models(mode)
            // if not has_access and raise_exception:
            //     raise self._make_access_error(model, mode) from None
            // return has_access
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModelAccess> GetAccessGroupsInternalAsync(object model_name, object access_mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get_access_groups(self, model_name, access_mode='read'):
            // """ Return the group expression object that represents the users who
            // have ``access_mode`` to the model ``model_name``.
            // """
            // assert access_mode in ('read', 'write', 'create', 'unlink'), 'Invalid access mode'
            // model = self.env['ir.model']._get(model_name)
            // accesses = self.sudo().search([
            //     (f'perm_{access_mode}', '=', True), ('model_id', '=', model.id),
            // ])
            // 
            // group_definitions = self.env['res.groups']._get_group_definitions()
            // if not accesses:
            //     return group_definitions.empty
            // if not all(access.group_id for access in accesses):  # there is some global access
            //     return group_definitions.universe
            // return group_definitions.from_ids(accesses.group_id.ids)
            */
            return default;
        }

        protected async Task<IrModelAccess> GetAllowedModelsInternalAsync(object mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _get_allowed_models(self, mode='read'):
            // assert mode in ('read', 'write', 'create', 'unlink'), 'Invalid access mode'
            // 
            // group_ids = self.env.user._get_group_ids()
            // self.flush_model()
            // rows = self.env.execute_query(SQL("""
            //     SELECT m.model
            //       FROM ir_model_access a
            //       JOIN ir_model m ON (m.id = a.model_id)
            //      WHERE a.perm_%s
            //        AND a.active
            //        AND (
            //             a.group_id IS NULL OR
            //             a.group_id IN %s
            //         )
            //     GROUP BY m.model
            // """, SQL(mode), tuple(group_ids) or (None,)))
            // 
            // return frozenset(v[0] for v in rows)
            */
            return default;
        }

        public async Task<IrModelAccess> GroupNamesWithAccessAsync(Guid id, IrModelAccessGroupNamesWithAccessRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def group_names_with_access(self, model_name, access_mode):
            // """ Return the names of visible groups which have been granted
            //     ``access_mode`` on the model ``model_name``.
            // 
            //    :rtype: list
            // """
            // assert access_mode in ('read', 'write', 'create', 'unlink'), 'Invalid access mode'
            // lang = self.env.lang or 'en_US'
            // self.env.cr.execute(f"""
            //     SELECT COALESCE(c.name->>%s, c.name->>'en_US'), COALESCE(g.name->>%s, g.name->>'en_US')
            //       FROM ir_model_access a
            //       JOIN ir_model m ON (a.model_id = m.id)
            //       JOIN res_groups g ON (a.group_id = g.id)
            //  LEFT JOIN res_groups_privilege c ON (c.id = g.privilege_id)
            //      WHERE m.model = %s
            //        AND a.active = TRUE
            //        AND a.perm_{access_mode} = TRUE
            //   ORDER BY c.name, g.name NULLS LAST
            // """, [lang, lang, model_name])
            // return [('%s/%s' % x) if x[0] else x[1] for x in self.env.cr.fetchall()]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModelAccess> MakeAccessErrorInternalAsync(string model, string mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _make_access_error(self, model: str, mode: str):
            // """ Return the exception corresponding to an access error. """
            // _logger.info('Access Denied by ACLs for operation: %s, uid: %s, model: %s', mode, self.env.uid, model)
            // 
            // operation_error = str(ACCESS_ERROR_HEADER[mode]) % {
            //     'document_kind': self.env['ir.model']._get(model).name or model,
            //     'document_model': model,
            // }
            // 
            // groups = "\n".join(f"\t- {g}" for g in self.group_names_with_access(model, mode))
            // if groups:
            //     group_info = str(ACCESS_ERROR_GROUPS) % {'groups_list': groups}
            // else:
            //     group_info = str(ACCESS_ERROR_NOGROUP)
            // 
            // resolution_info = str(ACCESS_ERROR_RESOLUTION)
            // 
            // return AccessError(operation_error + "\n\n" + group_info + "\n\n" + resolution_info)
            */
            return default;
        }
    }
}