using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class PropertiesBaseDefinitionAppService
    {

        protected async Task<PropertiesBaseDefinition> CheckPropertiesFieldIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py, METHOD: _check_properties_field_id) ---
            */
            return default;
        }

        protected async Task<PropertiesBaseDefinition> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<PropertiesBaseDefinition> GetDefinitionForPropertyFieldInternalAsync(object model_name, object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py, METHOD: _get_definition_for_property_field) ---
            */
            return default;
        }

        protected async Task<PropertiesBaseDefinition> GetDefinitionIdForPropertyFieldInternalAsync(object model_name, object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: properties_base_definition.py, METHOD: _get_definition_id_for_property_field) ---
            */
            return default;
        }
    }
}