using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ChangePasswordOwn")]
    public partial class ChangePasswordOwnController : AbpController
    {
        private readonly IChangePasswordOwnAppService _appService;
        public ChangePasswordOwnController(IChangePasswordOwnAppService appService) { _appService = appService; }
    }
}