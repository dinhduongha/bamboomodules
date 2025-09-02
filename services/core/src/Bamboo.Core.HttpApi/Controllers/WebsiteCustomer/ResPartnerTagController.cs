using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCustomer
{
    [Route("api/v1/website/ResPartnerTag")]
    public partial class ResPartnerTagController : AbpControllerBase
    {
        private readonly IResPartnerTagAppService _appService;
        public ResPartnerTagController(IResPartnerTagAppService appService) { _appService = appService; }
    }
}