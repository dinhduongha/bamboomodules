using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: bus
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/bus/BusPresence")]
    public partial class BusPresenceController : AbpController
    {
        private readonly IBusPresenceAppService _appService;
        public BusPresenceController(IBusPresenceAppService appService) { _appService = appService; }
    }
}