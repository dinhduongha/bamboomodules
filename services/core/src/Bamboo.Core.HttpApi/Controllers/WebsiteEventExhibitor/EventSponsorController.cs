using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventExhibitor
{
    [Route("api/v1/marketing/EventSponsor")]
    public partial class EventSponsorController : AbpControllerBase
    {
        private readonly IEventSponsorAppService _appService;
        public EventSponsorController(IEventSponsorAppService appService) { _appService = appService; }
    }
}