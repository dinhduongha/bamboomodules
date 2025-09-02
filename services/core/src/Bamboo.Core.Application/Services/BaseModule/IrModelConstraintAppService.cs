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
    public class IrModelConstraintAppService : GenericApplicationService<IrModelConstraint>, IIrModelConstraintAppService
    {

        public IrModelConstraintAppService(IRepository<IrModelConstraint, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<IrModelConstraint> CopyDataAsync(Guid id, IrModelConstraintCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=constraint.name + '_copy') for constraint, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModelConstraint> ReflectConstraintInternalAsync(object model, object conname, object type, object definition, object module, object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_constraint(self, model, conname, type, definition, module, message=None):
            // """ Reflect the given constraint, and return its corresponding record
            //     if a record is created or modified; returns ``None`` otherwise.
            //     The reflection makes it possible to remove a constraint when its
            //     corresponding module is uninstalled. ``type`` is either 'f' or 'u'
            //     depending on the constraint being a foreign key or not.
            // """
            // if not module:
            //     # no need to save constraints for custom models as they're not part
            //     # of any module
            //     return
            // assert type in ('f', 'u')
            // cr = self._cr
            // query = """ SELECT c.id, type, definition, message->>'en_US' as message
            //             FROM ir_model_constraint c, ir_module_module m
            //             WHERE c.module=m.id AND c.name=%s AND m.name=%s """
            // cr.execute(query, (conname, module))
            // cons = cr.dictfetchone()
            // if not cons:
            //     query = """ INSERT INTO ir_model_constraint
            //                     (name, create_date, write_date, create_uid, write_uid, module, model, type, definition, message)
            //                 VALUES (%s,
            //                         now() AT TIME ZONE 'UTC',
            //                         now() AT TIME ZONE 'UTC',
            //                         %s, %s,
            //                         (SELECT id FROM ir_module_module WHERE name=%s),
            //                         (SELECT id FROM ir_model WHERE model=%s),
            //                         %s, %s, %s)
            //                 RETURNING id"""
            //     cr.execute(query, (conname, self.env.uid, self.env.uid, module, model._name, type, definition, Json({'en_US': message})))
            //     return self.browse(cr.fetchone()[0])
            // 
            // cons_id = cons.pop('id')
            // if cons != dict(type=type, definition=definition, message=message):
            //     query = """ UPDATE ir_model_constraint
            //                 SET write_date=now() AT TIME ZONE 'UTC',
            //                     write_uid=%s, type=%s, definition=%s, message=%s
            //                 WHERE id=%s"""
            //     cr.execute(query, (self.env.uid, type, definition, Json({'en_US': message}), cons_id))
            //     return self.browse(cons_id)
            */
            return default;
        }

        protected async Task<IrModelConstraint> ReflectConstraintsInternalAsync(object model_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_constraints(self, model_names):
            // """ Reflect the SQL constraints of the given models. """
            // for model_name in model_names:
            //     self._reflect_model(self.env[model_name])
            */
            return default;
        }

        protected async Task<IrModelConstraint> ReflectModelInternalAsync(object model)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def _reflect_model(self, model):
            // """ Reflect the _sql_constraints of the given model. """
            // def cons_text(txt):
            //     return txt.lower().replace(', ',',').replace(' (','(')
            // 
            // # map each constraint on the name of the module where it is defined
            // constraint_module = {
            //     constraint[0]: cls._module
            //     for cls in reversed(self.env.registry[model._name].mro())
            //     if models.is_definition_class(cls)
            //     for constraint in getattr(cls, '_local_sql_constraints', ())
            // }
            // 
            // data_list = []
            // for (key, definition, message) in model._sql_constraints:
            //     conname = '%s_%s' % (model._table, key)
            //     module = constraint_module.get(key)
            //     record = self._reflect_constraint(model, conname, 'u', cons_text(definition), module, message)
            //     xml_id = '%s.constraint_%s' % (module, conname)
            //     if record:
            //         data_list.append(dict(xml_id=xml_id, record=record))
            //     else:
            //         self.env['ir.model.data']._load_xmlid(xml_id)
            // if data_list:
            //     self.env['ir.model.data']._update_xmlids(data_list)
            */
            return default;
        }
    }
}