using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductDocument")]
    public partial class ProductDocumentController : AbpControllerBase
    {
        private readonly IProductDocumentAppService _appService;
        public ProductDocumentController(IProductDocumentAppService appService) { _appService = appService; }
    }
}