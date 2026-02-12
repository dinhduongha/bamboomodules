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
    public partial class IrModelAppService
    {

        protected async Task<IrModel> CheckFoldNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_fold_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModel> CheckManualNameInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_manual_name) ---
            */
            return default;
        }

        protected async Task<IrModel> CheckModelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_model_name) ---
            */
            return default;
        }

        protected async Task<IrModel> CheckOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _check_order) ---
            */
            return default;
        }

        protected async Task<IrModel> ComputeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_count) ---
            */
            return default;
        }

        protected async Task<IrModel> ComputeIsMailThreadSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_model.py, METHOD: _compute_is_mail_thread_sms) ---
            */
            return default;
        }

        protected async Task<IrModel> ComputeIsMailingEnabledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: ir_model.py, METHOD: _compute_is_mailing_enabled) ---
            */
            return default;
        }

        protected async Task<IrModel> DefaultFieldIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _default_field_id) ---
            */
            return default;
        }

        protected async Task<IrModel> DeleteLinkedCampaignsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: ir_model.py, METHOD: _delete_linked_campaigns) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModel> DisplayNameForInternalAsync(object models)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_model.py, METHOD: _display_name_for) ---
            */
            return default;
        }

        protected async Task<IrModel> DropTableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _drop_table) ---
            */
            return default;
        }

        protected async Task<IrModel> GetDefinitionsInternalAsync(object model_names)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model.py, METHOD: _get_definitions) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_model.py, METHOD: _get_definitions) ---
            */
            return default;
        }

        protected async Task<IrModel> GetFormWritableFieldsInternalAsync(object property_origins)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: _get_form_writable_fields) ---
            */
            return default;
        }

        protected async Task<IrModel> GetIdInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get_id) ---
            */
            return default;
        }

        protected async Task<IrModel> GetInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get) ---
            */
            return default;
        }

        protected async Task<IrModel> GetModelDefinitionsInternalAsync(object model_names_to_fetch)
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_model.py, METHOD: _get_model_definitions) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model.py, METHOD: _get_model_definitions) ---
            */
            return default;
        }

        protected async Task<IrModel> InModulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _in_modules) ---
            */
            return default;
        }

        protected async Task<IrModel> InheritedModelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _inherited_models) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModel> InstanciateAttrsInternalAsync(object model_data)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model.py, METHOD: _instanciate_attrs) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _instanciate_attrs) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModel> IsManualNameInternalAsync(object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _is_manual_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModel> IsValidForModelSelectorInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_model.py, METHOD: _is_valid_for_model_selector) ---
            */
            return default;
        }

        protected async Task<IrModel> ReflectModelParamsInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_model.py, METHOD: _reflect_model_params) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _reflect_model_params) ---
            */
            return default;
        }

        protected async Task<IrModel> ReflectModelsInternalAsync(object model_names)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _reflect_models) ---
            */
            return default;
        }

        protected async Task<IrModel> SearchIsMailThreadSmsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_model.py, METHOD: _search_is_mail_thread_sms) ---
            */
            return default;
        }

        protected async Task<IrModel> SearchIsMailingEnabledInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: ir_model.py, METHOD: _search_is_mailing_enabled) ---
            */
            return default;
        }

        protected async Task<IrModel> UnlinkIfManualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _unlink_if_manual) ---
            */
            return default;
        }

        protected async Task<IrModel> ViewIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _view_ids) ---
            */
            return default;
        }
    }
}