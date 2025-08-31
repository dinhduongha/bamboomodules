using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrRecruitment
{
    [Route("api/v1/human-resources/HrApplicant")]
    public partial class HrApplicantController : AbpControllerBase
    {
        private readonly IHrApplicantAppService _appService;
        public HrApplicantController(IHrApplicantAppService appService) { _appService = appService; }
    }
}