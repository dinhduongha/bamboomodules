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
    [Module("BaseModule", Category = "Base")]
    public partial class IrConfigParameterAppService : GenericApplicationService<IrConfigParameter>, IIrConfigParameterAppService
    {

        public IrConfigParameterAppService(IRepository<IrConfigParameter, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public override async Task<IrConfigParameter> CreateAsync(IrConfigParameter entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: ir_config_parameter.py) ---
            // def create(self, vals_list):
            // records = super().create(vals_list)
            // if any(record.key == "crm.pls_fields" for record in records):
            //     self.env.flush_all()
            //     self.env.registry._setup_models__(self.env.cr, ['crm.lead'])
            // return records
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py) ---
            // def create(self, vals_list):
            // configs = super().create(vals_list)
            // configs._sale_sync_linked_crons()
            // return configs
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def create(self, vals_list):
            // self.env.registry.clear_cache('stable')
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<IrConfigParameter> GetParamAsync(Guid id, IrConfigParameterGetParamRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def get_param(self, key, default=False):
            // """Retrieve the value for a given key.
            // 
            // :param string key: The key of the parameter value to retrieve.
            // :param string default: default value if parameter is missing.
            // :return: The value of the parameter, or ``default`` if it does not exist.
            // :rtype: string
            // """
            // self.browse().check_access('read')
            // return self._get_param(key) or default
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrConfigParameter> GetParamCronMappingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py) ---
            // def _get_param_cron_mapping(self):
            // """Return a mapping of config parameters to linked crons' XMLIDs.
            // 
            // :return: The config-cron mapping.
            // :rtype: dict
            // """
            // return const.PARAM_CRON_MAPPING
            */
            return default;
        }

        protected async Task<IrConfigParameter> GetParamInternalAsync(object key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def _get_param(self, key):
            // # we bypass the ORM because get_param() is used in some field's depends,
            // # and must therefore work even when the ORM is not ready to work
            // self.flush_model(['key', 'value'])
            // self.env.cr.execute("SELECT value FROM ir_config_parameter WHERE key = %s", [key])
            // result = self.env.cr.fetchone()
            // return result and result[0]
            */
            return default;
        }

        public async Task<IrConfigParameter> InitAsync(Guid id, IrConfigParameterInitRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: ir_config_parameter.py) ---
            // def init(self, force=False):
            // super().init(force=force)
            // if force:
            //     oauth_oe = self.env.ref('auth_oauth.provider_openerp', raise_if_not_found=False)
            //     if not oauth_oe:
            //         return
            //     dbuuid = self.sudo().get_param('database.uuid')
            //     oauth_oe.write({'client_id': dbuuid})
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def init(self, force=False):
            // """
            // Initializes the parameters listed in _default_parameters.
            // It overrides existing parameters if force is ``True``.
            // """
            // # avoid prefetching during module installation, as the res_users table
            // # may not have all prescribed columns
            // self = self.with_context(prefetch_fields=False)
            // for key, func in _default_parameters.items():
            //     # force=True skips search and always performs the 'if' body (because ids=False)
            //     params = self.sudo().search([('key', '=', key)])
            //     if force or not params:
            //         params.set_param(key, func())
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrConfigParameter> SaleSyncLinkedCronsInternalAsync(object unlink)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py) ---
            // def _sale_sync_linked_crons(self, unlink=False):
            // """Synchronize Sales-related crons' `active` field based on linked configuration parameters.
            // 
            // :param bool unlink: Whether this sync is triggered by parameter deletion.
            // :return: None
            // """
            // param_cron_mapping = self._get_param_cron_mapping()
            // for config in self.filtered(lambda c: c.key in param_cron_mapping):
            //     linked_cron_xmlid = param_cron_mapping[config.key]
            //     if linked_cron := self.env.ref(linked_cron_xmlid, raise_if_not_found=False):
            //         linked_cron.active = False if unlink else str2bool(config.value)
            */
            return default;
        }

        public async Task<IrConfigParameter> SetParamAsync(Guid id, IrConfigParameterSetParamRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_config_parameter.py) ---
            // def set_param(self, key, value):
            // if key == 'mail.restrict.template.rendering':
            //     group_user = self.env.ref('base.group_user')
            //     group_mail_template_editor = self.env.ref('mail.group_mail_template_editor')
            // 
            //     if not value and group_mail_template_editor not in group_user.implied_ids:
            //         group_user._apply_group(group_mail_template_editor)
            // 
            //     elif value and group_mail_template_editor in group_user.implied_ids:
            //         # remove existing users, including inactive template user
            //         # admin will regain the right via implied_ids on group_system
            //         group_user._remove_group(group_mail_template_editor)
            // # sanitize and normalize allowed catchall domains
            // elif key == 'mail.catchall.domain.allowed' and value:
            //     value = self.env['mail.alias']._sanitize_allowed_domains(value)
            // 
            // return super().set_param(key, value)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def set_param(self, key, value):
            // """Sets the value of a parameter.
            // 
            // :param string key: The key of the parameter value to set.
            // :param string value: The value to set.
            // :return: the previous value of the parameter or False if it did
            //          not exist.
            // :rtype: string
            // """
            // param = self.search([('key', '=', key)])
            // if param:
            //     old = param.value
            //     if value is not False and value is not None:
            //         if str(value) != old:
            //             param.write({'value': value})
            //     else:
            //         param.unlink()
            //     return old
            // else:
            //     if value is not False and value is not None:
            //         self.create({'key': key, 'value': value})
            //     return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: ir_config_parameter.py) ---
            // def unlink(self):
            // pls_emptied = any(record.key == "crm.pls_fields" for record in self)
            // result = super().unlink()
            // if pls_emptied and not self.env.context.get(MODULE_UNINSTALL_FLAG):
            //     self.env.flush_all()
            //     self.env.registry._setup_models__(self.env.cr, ['crm.lead'])
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py) ---
            // def unlink(self):
            // self._sale_sync_linked_crons(unlink=True)
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def unlink(self):
            // self.env.registry.clear_cache('stable')
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<IrConfigParameter> UnlinkDefaultParametersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def unlink_default_parameters(self):
            // for record in self.filtered(lambda p: p.key in _default_parameters.keys()):
            //     raise ValidationError(self.env._("You cannot delete the %s record.", record.key))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrConfigParameter entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: ir_config_parameter.py) ---
            // def write(self, vals):
            // ''' When this paramater is changed, dynamic fields needs to be recomputed '''
            // param = self.filtered(lambda x: x.key == 'analytic.project_plan')
            // if not param:
            //     return super().write(vals)
            // old_plan_id = param.value
            // new_plan_id = vals.get('value')
            // if not (
            //     new_plan_id
            //     and str(new_plan_id).isnumeric()
            //     and (plan := self.env['account.analytic.plan'].browse(int(new_plan_id)))
            //     and (plan_field := plan._find_plan_column())
            // ):
            //     raise UserError(_('The value for %s must be the ID to a valid analytic plan that is not a subplan', param.key))
            // res = super().write(vals)
            // self.env['account.analytic.plan'].browse(int(old_plan_id))._sync_all_plan_column()
            // plan_field.unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: ir_config_parameter.py) ---
            // def write(self, vals):
            // result = super().write(vals)
            // if any(record.key == "crm.pls_fields" for record in self):
            //     self.env.flush_all()
            //     self.env.registry._setup_models__(self.env.cr, ['crm.lead'])
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_config_parameter.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // self._sale_sync_linked_crons()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_config_parameter.py) ---
            // def write(self, vals):
            // if 'key' in vals:
            //     illegal = _default_parameters.keys() & self.mapped('key')
            //     if illegal:
            //         raise ValidationError(self.env._("You cannot rename config parameters with keys %s", ', '.join(illegal)))
            // self.env.registry.clear_cache('stable')
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}