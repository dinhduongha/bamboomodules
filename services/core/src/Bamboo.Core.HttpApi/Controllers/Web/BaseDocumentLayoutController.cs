using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Web
{
    [Route("api/v1/web/BaseDocumentLayout")]
    public partial class BaseDocumentLayoutController : AbpControllerBase
    {
        private readonly IBaseDocumentLayoutAppService _appService;
        public BaseDocumentLayoutController(IBaseDocumentLayoutAppService appService) { _appService = appService; }
    }
}