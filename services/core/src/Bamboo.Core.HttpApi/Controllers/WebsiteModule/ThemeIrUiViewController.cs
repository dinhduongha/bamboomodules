using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/ThemeIrUiView")]
    public partial class ThemeIrUiViewController : AbpControllerBase
    {
        private readonly IThemeIrUiViewAppService _appService;
        public ThemeIrUiViewController(IThemeIrUiViewAppService appService) { _appService = appService; }
    }
}