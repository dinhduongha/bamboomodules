using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Utm
{
    [Route("api/v1/utm/UtmMedium")]
    public partial class UtmMediumController : AbpControllerBase
    {
        private readonly IUtmMediumAppService _appService;
        public UtmMediumController(IUtmMediumAppService appService) { _appService = appService; }
    }
}