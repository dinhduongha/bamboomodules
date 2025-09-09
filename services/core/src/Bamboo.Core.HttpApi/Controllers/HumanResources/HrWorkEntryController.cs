using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrWorkEntryModule
{
    [Route("api/v1/human-resources/HrWorkEntry")]
    public partial class HrWorkEntryController : AbpController
    {
        private readonly IHrWorkEntryAppService _appService;
        public HrWorkEntryController(IHrWorkEntryAppService appService) { _appService = appService; }
    }
}