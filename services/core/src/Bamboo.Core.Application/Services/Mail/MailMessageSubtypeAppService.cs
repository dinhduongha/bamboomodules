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
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailMessageSubtypeAppService : GenericApplicationService<MailMessageSubtype>, IMailMessageSubtypeAppService
    {

        public MailMessageSubtypeAppService(IRepository<MailMessageSubtype, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public override async Task<MailMessageSubtype> CreateAsync(MailMessageSubtype entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py) ---
            // def create(self, vals_list):
            // result = super(MailMessageSubtype, self).create(vals_list)
            // result.filtered(
            //     lambda st: st.res_model in ['hr.leave', 'hr.leave.allocation']
            // )._update_department_subtype()
            // return result
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py) ---
            // def create(self, vals_list):
            // self.env.registry.clear_cache()  # _get_auto_subscription_subtypes
            // return super(MailMessageSubtype, self).create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<MailMessageSubtype> DefaultSubtypesAsync(Guid id, object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py) ---
            // def default_subtypes(self, model_name):
            // """ Retrieve the default subtypes (all, internal, external) for the given model. """
            // subtype_ids, internal_ids, external_ids = self._default_subtypes(model_name)
            // return self.browse(subtype_ids), self.browse(internal_ids), self.browse(external_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessageSubtype> DefaultSubtypesInternalAsync(object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py) ---
            // def _default_subtypes(self, model_name):
            // domain = [('default', '=', True),
            //           '|', ('res_model', '=', model_name), ('res_model', '=', False)]
            // subtypes = self.search(domain)
            // internal = subtypes.filtered('internal')
            // return subtypes.ids, internal.ids, (subtypes - internal).ids
            */
            return default;
        }

        protected async Task<MailMessageSubtype> GetAutoSubscriptionSubtypesInternalAsync(object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py) ---
            // def _get_auto_subscription_subtypes(self, model_name):
            // """ Return data related to auto subscription based on subtype matching.
            // Here model_name indicates child model (like a task) on which we want to
            // make subtype matching based on its parents (like a project).
            // 
            // Example with tasks and project :
            // 
            //  * generic: discussion, res_model = False
            //  * task: new, res_model = project.task
            //  * project: task_new, parent_id = new, res_model = project.project, field = project_id
            // 
            // Returned data
            // 
            //   * child_ids: all subtypes that are generic or related to task (res_model = False or model_name)
            //   * def_ids: default subtypes ids (either generic or task specific)
            //   * all_int_ids: all internal-only subtypes ids (generic or task or project)
            //   * parent: dict(parent subtype id, child subtype id), i.e. {task_new.id: new.id}
            //   * relation: dict(parent_model, relation_fields), i.e. {'project.project': ['project_id']}
            // """
            // child_ids, def_ids = list(), list()
            // all_int_ids = list()
            // parent, relation = dict(), dict()
            // subtypes = self.sudo().search([
            //     '|', '|', ('res_model', '=', False),
            //     ('res_model', '=', model_name),
            //     ('parent_id.res_model', '=', model_name)
            // ])
            // for subtype in subtypes:
            //     if not subtype.res_model or subtype.res_model == model_name:
            //         child_ids += subtype.ids
            //         if subtype.default:
            //             def_ids += subtype.ids
            //     elif subtype.relation_field:
            //         parent[subtype.id] = subtype.parent_id.id
            //         relation.setdefault(subtype.res_model, set()).add(subtype.relation_field)
            //     # required for backward compatibility
            //     if subtype.internal:
            //         all_int_ids += subtype.ids
            // return child_ids, def_ids, all_int_ids, parent, relation
            */
            return default;
        }

        protected async Task<MailMessageSubtype> GetDepartmentSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py) ---
            // def _get_department_subtype(self):
            // return self.search([
            //     ('res_model', '=', 'hr.department'),
            //     ('parent_id', '=', self.id)])
            */
            return default;
        }

        protected async Task<MailMessageSubtype> UpdateDepartmentSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py) ---
            // def _update_department_subtype(self):
            // for subtype in self:
            //     department_subtype = subtype._get_department_subtype()
            //     if department_subtype:
            //         department_subtype.write({
            //             'name': subtype.name,
            //             'default': subtype.default,
            //         })
            //     else:
            //         department_subtype = self.create({
            //             'name': subtype.name,
            //             'res_model': 'hr.department',
            //             'default': False,
            //             'parent_id': subtype.id,
            //             'relation_field': 'department_id',
            //         })
            //     return department_subtype
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, MailMessageSubtype entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py) ---
            // def write(self, vals):
            // result = super(MailMessageSubtype, self).write(vals)
            // self.filtered(
            //     lambda subtype: subtype.res_model in ['hr.leave', 'hr.leave.allocation']
            // )._update_department_subtype()
            // return result
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py) ---
            // def write(self, vals):
            // self.env.registry.clear_cache()  # _get_auto_subscription_subtypes
            // return super(MailMessageSubtype, self).write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}