using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventExhibitor
{
    [Route("api/v1/marketing/EventSponsor")]
    public partial class EventSponsorController : AbpControllerBase
    {
        private readonly IEventSponsorAppService _appService;
        public EventSponsorController(IEventSponsorAppService appService) { _appService = appService; }
    }
}