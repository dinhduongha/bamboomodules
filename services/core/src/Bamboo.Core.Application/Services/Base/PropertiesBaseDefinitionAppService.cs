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
    public partial class PropertiesBaseDefinitionAppService : GenericApplicationService<PropertiesBaseDefinition>, IPropertiesBaseDefinitionAppService
    {

        public PropertiesBaseDefinitionAppService(IRepository<PropertiesBaseDefinition, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<PropertiesBaseDefinition> CheckPropertiesFieldIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py) ---
            // def _check_properties_field_id(self):
            // if invalid_fields := self.mapped("properties_field_id").filtered(lambda f: f.ttype != 'properties'):
            //     raise ValidationError(
            //         _("The definition needs to be linked to a properties field. Those fields are not: %s.", ', '.join(invalid_fields.mapped('name')))
            //     )
            */
            return default;
        }

        protected async Task<PropertiesBaseDefinition> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py) ---
            // def _compute_display_name(self):
            // for definition in self:
            //     if not definition.properties_field_id.model:
            //         definition.display_name = False
            //         continue
            // 
            //     definition.display_name = _(
            //         "%s Properties",
            //         self.env[definition.properties_field_id.model]._description,
            //     )
            */
            return default;
        }

        protected async Task<PropertiesBaseDefinition> GetDefinitionForPropertyFieldInternalAsync(object model_name, object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py) ---
            // def _get_definition_for_property_field(self, model_name, field_name):
            // return self.browse(self._get_definition_id_for_property_field(model_name, field_name))
            */
            return default;
        }

        protected async Task<PropertiesBaseDefinition> GetDefinitionIdForPropertyFieldInternalAsync(object model_name, object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py) ---
            // def _get_definition_id_for_property_field(self, model_name, field_name):
            // definition_record = self.sudo().search(
            //     [
            //         ("properties_field_id.model", "=", model_name),
            //         ("properties_field_id.name", "=", field_name),
            //     ],
            //     limit=1,
            // )
            // if not definition_record:
            //     field = self.env["ir.model.fields"].sudo()._get(model_name, field_name)
            //     definition_record = self.sudo().create(
            //         {
            //             "properties_field_id": field.id,
            //         },
            //     )
            // return definition_record.id
            */
            return default;
        }

        public async Task<PropertiesBaseDefinition> GetPropertiesBaseDefinitionAsync(Guid id, PropertiesBaseDefinitionGetPropertiesBaseDefinitionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: properties_base_definition.py) ---
            // def get_properties_base_definition(self, model_name, field_name):
            // """Return the base properties definition if we can read the model."""
            // model = self.env[model_name]
            // model.check_access("read")
            // if model._fields[field_name].type != "properties":
            //     raise AccessError(_("You can not read that field definition."))
            // return self.sudo().web_search_read(
            //     [
            //         ["properties_field_id.name", "=", field_name],
            //         ["properties_field_id.model", "=", model_name],
            //     ],
            //     specification={"display_name": {}, "properties_definition": {}},
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}