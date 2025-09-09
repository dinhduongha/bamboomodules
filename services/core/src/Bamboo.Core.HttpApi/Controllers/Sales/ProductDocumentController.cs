using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    [Route("api/v1/sales/ProductDocument")]
    public partial class ProductDocumentController : AbpController
    {
        private readonly IProductDocumentAppService _appService;
        public ProductDocumentController(IProductDocumentAppService appService) { _appService = appService; }
    }
}