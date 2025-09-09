using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrRecruitment
{
    [Route("api/v1/human-resources/HrRecruitmentSource")]
    public partial class HrRecruitmentSourceController : AbpController
    {
        private readonly IHrRecruitmentSourceAppService _appService;
        public HrRecruitmentSourceController(IHrRecruitmentSourceAppService appService) { _appService = appService; }
    }
}