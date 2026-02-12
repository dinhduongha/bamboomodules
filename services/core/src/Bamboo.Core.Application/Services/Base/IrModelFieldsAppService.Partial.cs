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
    public partial class IrModelFieldsAppService
    {

        protected async Task<IrModelFields> AllManualFieldDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _all_manual_field_data) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckCurrencyFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_currency_field) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckDependsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_depends) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_domain) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckIfUsedInWebsiteFormInternalAsync()
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: _check_if_used_in_website_form) ---
            #endif
            return default;
        }

        protected async Task<IrModelFields> CheckNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_name) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckOnDeleteRequiredM2oInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_on_delete_required_m2o) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckRelatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_related) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckRelationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_relation) ---
            */
            return default;
        }

        protected async Task<IrModelFields> CheckRelationTableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_relation_table) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeCopiedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_copied) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeRelatedFieldIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_related_field_id) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeRelationFieldIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_relation_field_id) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ComputeSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_selection) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelFields> CustomMany2manyNamesInternalAsync(object model_name, object comodel_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _custom_many2many_names) ---
            */
            return default;
        }

        protected async Task<IrModelFields> DropColumnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _drop_column) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelFields> GetFieldsCachedInternalAsync(object model_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get_fields_cached) ---
            */
            return default;
        }

        protected async Task<IrModelFields> GetIdsInternalAsync(object model_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get_ids) ---
            */
            return default;
        }

        protected async Task<IrModelFields> GetInternalAsync(object model_name, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get) ---
            */
            return default;
        }

        protected async Task<IrModelFields> GetManualFieldDataInternalAsync(object model_name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get_manual_field_data) ---
            */
            return default;
        }

        protected async Task<IrModelFields> InModulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _in_modules) ---
            */
            return default;
        }

        protected async Task<IrModelFields> InstanciateAttrsInternalAsync(object field_data)
        {
            /*
            --- METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py, METHOD: _instanciate_attrs) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model_fields.py, METHOD: _instanciate_attrs) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _instanciate_attrs) ---
            */
            return default;
        }

        protected async Task<IrModelFields> InverseSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _inverse_selection) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelFields> IsManualNameInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _is_manual_name) ---
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeComputeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _onchange_compute) ---
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeRelatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _onchange_related) ---
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeRelationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _onchange_relation) ---
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeRelationTableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _onchange_relation_table) ---
            */
            return default;
        }

        protected async Task<IrModelFields> OnchangeTtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _onchange_ttype) ---
            */
            return default;
        }

        protected async Task<IrModelFields> PrepareUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _prepare_update) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ReflectFieldParamsInternalAsync(object field, Guid model_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model_fields.py, METHOD: _reflect_field_params) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _reflect_field_params) ---
            */
            return default;
        }

        protected async Task<IrModelFields> ReflectFieldsInternalAsync(object model_names)
        {
            /*
            --- METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py, METHOD: _reflect_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _reflect_fields) ---
            */
            return default;
        }

        protected async Task<IrModelFields> RelatedFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _related_field) ---
            */
            return default;
        }
    }
}