using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Website/Website, Module: website_customer
    [Authorize]
    [Route("api/v1/website/ResPartnerTag")]
    public partial class ResPartnerTagController : AbpController
    {
        private readonly IResPartnerTagAppService _appService;
        public ResPartnerTagController(IResPartnerTagAppService appService) { _appService = appService; }
    }
}