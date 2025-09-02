using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResetViewArchWizard")]
    public partial class ResetViewArchWizardController : AbpControllerBase
    {
        private readonly IResetViewArchWizardAppService _appService;
        public ResetViewArchWizardController(IResetViewArchWizardAppService appService) { _appService = appService; }
    }
}