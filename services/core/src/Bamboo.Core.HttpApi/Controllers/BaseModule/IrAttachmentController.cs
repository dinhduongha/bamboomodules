using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrAttachment")]
    public partial class IrAttachmentController : AbpControllerBase
    {
        private readonly IIrAttachmentAppService _appService;
        public IrAttachmentController(IIrAttachmentAppService appService) { _appService = appService; }
    }
}