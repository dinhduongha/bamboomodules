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
    public partial class IrSequenceAppService
    {

        protected async Task<IrSequence> CreateDateRangeSeqInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _create_date_range_seq) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrSequence> GetCurrentSequenceInternalAsync(object sequence_date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _get_current_sequence) ---
            */
            return default;
        }

        protected async Task<IrSequence> GetNumberNextActualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _get_number_next_actual) ---
            */
            return default;
        }

        protected async Task<IrSequence> GetPrefixSuffixInternalAsync(object date, object date_range)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _get_prefix_suffix) ---
            */
            return default;
        }

        protected async Task<IrSequence> NextDoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _next_do) ---
            */
            return default;
        }

        protected async Task<IrSequence> NextInternalAsync(object sequence_date)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _next) ---
            */
            return default;
        }

        protected async Task<IrSequence> SetNumberNextActualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: _set_number_next_actual) ---
            */
            return default;
        }

        protected async Task<IrSequence> UnlinkSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: ir_sequence.py, METHOD: _unlink_sequence) ---
            */
            return default;
        }
    }
}