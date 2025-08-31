using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrAttachment")]
    public partial class IrAttachmentController : AbpControllerBase
    {
        private readonly IIrAttachmentAppService _appService;
        public IrAttachmentController(IIrAttachmentAppService appService) { _appService = appService; }
    }
}