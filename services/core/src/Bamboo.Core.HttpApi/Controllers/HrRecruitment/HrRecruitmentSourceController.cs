using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrRecruitment
{
    [Route("api/v1/human-resources/HrRecruitmentSource")]
    public partial class HrRecruitmentSourceController : AbpControllerBase
    {
        private readonly IHrRecruitmentSourceAppService _appService;
        public HrRecruitmentSourceController(IHrRecruitmentSourceAppService appService) { _appService = appService; }
    }
}