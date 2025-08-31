using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    [Route("api/v1/accounting/AccountAssetDepreciationLine")]
    public partial class AccountAssetDepreciationLineController : AbpControllerBase
    {
        private readonly IAccountAssetDepreciationLineAppService _appService;
        public AccountAssetDepreciationLineController(IAccountAssetDepreciationLineAppService appService) { _appService = appService; }
    }
}