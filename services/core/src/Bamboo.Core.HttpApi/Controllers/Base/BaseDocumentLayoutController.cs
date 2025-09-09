using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Web
{
    [Route("api/v1/web/BaseDocumentLayout")]
    public partial class BaseDocumentLayoutController : AbpController
    {
        private readonly IBaseDocumentLayoutAppService _appService;
        public BaseDocumentLayoutController(IBaseDocumentLayoutAppService appService) { _appService = appService; }
    }
}