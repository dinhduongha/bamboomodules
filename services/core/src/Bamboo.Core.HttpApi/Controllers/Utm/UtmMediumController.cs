using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Utm
{
    [Route("api/v1/utm/UtmMedium")]
    public partial class UtmMediumController : AbpControllerBase
    {
        private readonly IUtmMediumAppService _appService;
        public UtmMediumController(IUtmMediumAppService appService) { _appService = appService; }
    }
}