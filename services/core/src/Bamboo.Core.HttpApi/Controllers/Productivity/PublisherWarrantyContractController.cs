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
    // Category: Productivity/Discuss, Module: mail
    [Authorize]
    [Route("api/v1/productivity/PublisherWarrantyContract")]
    public partial class PublisherWarrantyContractController : AbpController
    {
        private readonly IPublisherWarrantyContractAppService _appService;
        public PublisherWarrantyContractController(IPublisherWarrantyContractAppService appService) { _appService = appService; }
    }
}