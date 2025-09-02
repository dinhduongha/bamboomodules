using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    [Route("api/v1/accounting/AccountAssetDepreciationLine")]
    public partial class AccountAssetDepreciationLineController : AbpControllerBase
    {
        private readonly IAccountAssetDepreciationLineAppService _appService;
        public AccountAssetDepreciationLineController(IAccountAssetDepreciationLineAppService appService) { _appService = appService; }
    }
}