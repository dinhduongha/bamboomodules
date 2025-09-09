using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    [Route("api/v1/accounting/AccountAssetAsset")]
    public partial class AccountAssetAssetController : AbpController
    {
        private readonly IAccountAssetAssetAppService _appService;
        public AccountAssetAssetController(IAccountAssetAssetAppService appService) { _appService = appService; }
    }
}