using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrRecruitment
{
    [Route("api/v1/human-resources/HrCandidate")]
    public partial class HrCandidateController : AbpController
    {
        private readonly IHrCandidateAppService _appService;
        public HrCandidateController(IHrCandidateAppService appService) { _appService = appService; }
    }
}