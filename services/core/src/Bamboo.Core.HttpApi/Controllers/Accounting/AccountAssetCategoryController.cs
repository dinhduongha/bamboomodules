using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountAsset
{
    [Route("api/v1/accounting/AccountAssetCategory")]
    public partial class AccountAssetCategoryController : AbpController
    {
        private readonly IAccountAssetCategoryAppService _appService;
        public AccountAssetCategoryController(IAccountAssetCategoryAppService appService) { _appService = appService; }
    }
}