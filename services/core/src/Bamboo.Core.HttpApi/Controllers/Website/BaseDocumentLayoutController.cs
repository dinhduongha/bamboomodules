using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: web
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/web/BaseDocumentLayout")]
    public partial class BaseDocumentLayoutController : AbpController
    {
        private readonly IBaseDocumentLayoutAppService _appService;
        public BaseDocumentLayoutController(IBaseDocumentLayoutAppService appService) { _appService = appService; }
    }
}