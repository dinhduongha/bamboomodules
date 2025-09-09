using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Bus
{
    [Route("api/v1/bus/BusPresence")]
    public partial class BusPresenceController : AbpController
    {
        private readonly IBusPresenceAppService _appService;
        public BusPresenceController(IBusPresenceAppService appService) { _appService = appService; }
    }
}