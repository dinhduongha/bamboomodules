using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrRecruitment
{
    [Route("api/v1/human-resources/HrCandidate")]
    public partial class HrCandidateController : AbpControllerBase
    {
        private readonly IHrCandidateAppService _appService;
        public HrCandidateController(IHrCandidateAppService appService) { _appService = appService; }
    }
}