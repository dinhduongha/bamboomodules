using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Website/Website, Module: website
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/website/ThemeIrUiView")]
    public partial class ThemeIrUiViewController : AbpController
    {
        private readonly IThemeIrUiViewAppService _appService;
        public ThemeIrUiViewController(IThemeIrUiViewAppService appService) { _appService = appService; }
    }
}