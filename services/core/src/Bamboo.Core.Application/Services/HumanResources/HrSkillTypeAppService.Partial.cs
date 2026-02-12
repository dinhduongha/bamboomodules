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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class HrSkillTypeAppService
    {

        protected async Task<HrSkillType> CheckNoNullSkillOrSkillLevelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py, METHOD: _check_no_null_skill_or_skill_level) ---
            */
            return default;
        }

        protected async Task<HrSkillType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrSkillType> ComputeLevelsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py, METHOD: _compute_levels_count) ---
            */
            return default;
        }

        protected async Task<HrSkillType> GetDefaultColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py, METHOD: _get_default_color) ---
            */
            return default;
        }

        protected async Task<HrSkillType> OnchangeSkillLevelIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py, METHOD: _onchange_skill_level_ids) ---
            */
            return default;
        }
    }
}