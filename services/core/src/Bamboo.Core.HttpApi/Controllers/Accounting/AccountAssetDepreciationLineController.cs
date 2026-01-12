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
    // Category: Accounting, Module: om_account_asset
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountAssetDepreciationLine")]
    public partial class AccountAssetDepreciationLineController : AbpController
    {
        private readonly IAccountAssetDepreciationLineAppService _appService;
        public AccountAssetDepreciationLineController(IAccountAssetDepreciationLineAppService appService) { _appService = appService; }
    }
}