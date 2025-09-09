using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrSkills
{
    [Route("api/v1/human-resources/HrSkillType")]
    public partial class HrSkillTypeController : AbpController
    {
        private readonly IHrSkillTypeAppService _appService;
        public HrSkillTypeController(IHrSkillTypeAppService appService) { _appService = appService; }
    }
}