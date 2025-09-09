using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    [Route("api/v1/website/ThemeIrUiView")]
    public partial class ThemeIrUiViewController : AbpController
    {
        private readonly IThemeIrUiViewAppService _appService;
        public ThemeIrUiViewController(IThemeIrUiViewAppService appService) { _appService = appService; }
    }
}