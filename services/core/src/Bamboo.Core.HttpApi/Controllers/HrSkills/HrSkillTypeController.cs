using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrSkills
{
    [Route("api/v1/human-resources/HrSkillType")]
    public partial class HrSkillTypeController : AbpControllerBase
    {
        private readonly IHrSkillTypeAppService _appService;
        public HrSkillTypeController(IHrSkillTypeAppService appService) { _appService = appService; }
    }
}