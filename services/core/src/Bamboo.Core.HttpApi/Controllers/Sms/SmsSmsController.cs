using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Sms
{
    [Route("api/v1/sms/SmsSms")]
    public partial class SmsSmsController : AbpControllerBase
    {
        private readonly ISmsSmsAppService _appService;
        public SmsSmsController(ISmsSmsAppService appService) { _appService = appService; }
    }
}