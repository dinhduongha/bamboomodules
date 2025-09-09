using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResetViewArchWizard")]
    public partial class ResetViewArchWizardController : AbpController
    {
        private readonly IResetViewArchWizardAppService _appService;
        public ResetViewArchWizardController(IResetViewArchWizardAppService appService) { _appService = appService; }
    }
}