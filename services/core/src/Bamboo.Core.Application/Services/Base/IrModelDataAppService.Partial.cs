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
    public partial class IrModelDataAppService
    {

        protected async Task<IrModelData> BuildInsertXmlidsValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _build_insert_xmlids_values) ---
            */
            return default;
        }

        protected async Task<IrModelData> BuildUpdateXmlidsQueryInternalAsync(object sub_rows, object update)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _build_update_xmlids_query) ---
            */
            return default;
        }

        protected async Task<IrModelData> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<IrModelData> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<IrModelData> ComputeReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _compute_reference) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> LoadXmlidInternalAsync(Guid xml_id)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _load_xmlid) ---
            */
            return default;
        }

        protected async Task<IrModelData> LookupXmlidsInternalAsync(List<Guid> xml_ids, object model)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _lookup_xmlids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> ModuleDataUninstallInternalAsync(object modules_to_remove)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _module_data_uninstall) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> ProcessEndInternalAsync(object modules)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _process_end) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> ProcessEndUnlinkRecordInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_model_data.py, METHOD: _process_end_unlink_record) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _process_end_unlink_record) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> UpdateXmlidsInternalAsync(object data_list, object update)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _update_xmlids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> XmlidLookupInternalAsync(string xmlid)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _xmlid_lookup) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> XmlidToResIdInternalAsync(object xmlid, object raise_if_not_found)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _xmlid_to_res_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrModelData> XmlidToResModelResIdInternalAsync(string xmlid, bool raise_if_not_found)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _xmlid_to_res_model_res_id) ---
            */
            return default;
        }
    }
}