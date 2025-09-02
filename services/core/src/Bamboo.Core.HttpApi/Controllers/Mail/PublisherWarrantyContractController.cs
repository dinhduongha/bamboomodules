using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/PublisherWarrantyContract")]
    public partial class PublisherWarrantyContractController : AbpControllerBase
    {
        private readonly IPublisherWarrantyContractAppService _appService;
        public PublisherWarrantyContractController(IPublisherWarrantyContractAppService appService) { _appService = appService; }
    }
}