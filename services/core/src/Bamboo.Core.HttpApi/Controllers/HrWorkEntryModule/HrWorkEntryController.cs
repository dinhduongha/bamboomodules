using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrWorkEntryModule
{
    [Route("api/v1/human-resources/HrWorkEntry")]
    public partial class HrWorkEntryController : AbpControllerBase
    {
        private readonly IHrWorkEntryAppService _appService;
        public HrWorkEntryController(IHrWorkEntryAppService appService) { _appService = appService; }
    }
}