using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Web
{
    [Route("api/v1/web/BaseDocumentLayout")]
    public partial class BaseDocumentLayoutController : AbpControllerBase
    {
        private readonly IBaseDocumentLayoutAppService _appService;
        public BaseDocumentLayoutController(IBaseDocumentLayoutAppService appService) { _appService = appService; }
    }
}