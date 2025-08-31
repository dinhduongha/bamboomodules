using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrWorkEntryModule
{
    [Route("api/v1/human-resources/HrWorkEntry")]
    public partial class HrWorkEntryController : AbpControllerBase
    {
        private readonly IHrWorkEntryAppService _appService;
        public HrWorkEntryController(IHrWorkEntryAppService appService) { _appService = appService; }
    }
}