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
    public partial class HrResumeLineAppService
    {

        protected async Task<HrResumeLine> ComputeChannelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py, METHOD: _compute_channel_id) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_resume_line.py, METHOD: _compute_color) ---
            --- METHOD SOURCE (MODULE: hr_skills_event, FILE: hr_resume_line.py, METHOD: _compute_color) ---
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeEventIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_event, FILE: hr_resume_line.py, METHOD: _compute_event_id) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeExpirationStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_survey, FILE: hr_resume_line.py, METHOD: _compute_expiration_status) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeExternalUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_resume_line.py, METHOD: _compute_external_url) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> OnchangeChannelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py, METHOD: _onchange_channel_id) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> OnchangeEventIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_event, FILE: hr_resume_line.py, METHOD: _onchange_event_id) ---
            */
            return default;
        }

        protected async Task<HrResumeLine> OnchangeExternalUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_resume_line.py, METHOD: _onchange_external_url) ---
            */
            return default;
        }
    }
}