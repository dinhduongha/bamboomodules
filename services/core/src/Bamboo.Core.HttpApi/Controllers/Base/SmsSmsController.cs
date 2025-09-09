using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sms
{
    [Route("api/v1/sms/SmsSms")]
    public partial class SmsSmsController : AbpController
    {
        private readonly ISmsSmsAppService _appService;
        public SmsSmsController(ISmsSmsAppService appService) { _appService = appService; }
    }
}