using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCustomer
{
    [Route("api/v1/website/ResPartnerTag")]
    public partial class ResPartnerTagController : AbpControllerBase
    {
        private readonly IResPartnerTagAppService _appService;
        public ResPartnerTagController(IResPartnerTagAppService appService) { _appService = appService; }
    }
}