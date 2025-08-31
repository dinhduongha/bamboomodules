using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrSkills
{
    [Route("api/v1/human-resources/HrSkillType")]
    public partial class HrSkillTypeController : AbpControllerBase
    {
        private readonly IHrSkillTypeAppService _appService;
        public HrSkillTypeController(IHrSkillTypeAppService appService) { _appService = appService; }
    }
}