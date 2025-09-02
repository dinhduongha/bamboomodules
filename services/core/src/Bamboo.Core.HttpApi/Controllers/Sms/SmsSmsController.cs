using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sms
{
    [Route("api/v1/sms/SmsSms")]
    public partial class SmsSmsController : AbpControllerBase
    {
        private readonly ISmsSmsAppService _appService;
        public SmsSmsController(ISmsSmsAppService appService) { _appService = appService; }
    }
}