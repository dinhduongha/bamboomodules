using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    [Route("api/v1/accounting/AccountAssetCategory")]
    public partial class AccountAssetCategoryController : AbpControllerBase
    {
        private readonly IAccountAssetCategoryAppService _appService;
        public AccountAssetCategoryController(IAccountAssetCategoryAppService appService) { _appService = appService; }
    }
}