using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResetViewArchWizard")]
    public partial class ResetViewArchWizardController : AbpControllerBase
    {
        private readonly IResetViewArchWizardAppService _appService;
        public ResetViewArchWizardController(IResetViewArchWizardAppService appService) { _appService = appService; }
    }
}