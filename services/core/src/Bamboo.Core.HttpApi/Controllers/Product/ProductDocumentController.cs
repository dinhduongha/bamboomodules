using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductDocument")]
    public partial class ProductDocumentController : AbpControllerBase
    {
        private readonly IProductDocumentAppService _appService;
        public ProductDocumentController(IProductDocumentAppService appService) { _appService = appService; }
    }
}