using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrDemoFailureWizard")]
    public partial class IrDemoFailureWizardController : AbpControllerBase
    {
        private readonly IIrDemoFailureWizardAppService _appService;
        public IrDemoFailureWizardController(IIrDemoFailureWizardAppService appService) { _appService = appService; }
    }
}