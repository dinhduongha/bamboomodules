using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    [Route("api/v1/accounting/AccountAssetAsset")]
    public partial class AccountAssetAssetController : AbpControllerBase
    {
        private readonly IAccountAssetAssetAppService _appService;
        public AccountAssetAssetController(IAccountAssetAssetAppService appService) { _appService = appService; }
    }
}