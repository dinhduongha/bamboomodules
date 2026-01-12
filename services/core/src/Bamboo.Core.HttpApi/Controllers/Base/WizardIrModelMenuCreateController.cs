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
    // Category: Hidden, Module: base
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/base/WizardIrModelMenuCreate")]
    public partial class WizardIrModelMenuCreateController : AbpController
    {
        private readonly IWizardIrModelMenuCreateAppService _appService;
        public WizardIrModelMenuCreateController(IWizardIrModelMenuCreateAppService appService) { _appService = appService; }
    }
}