using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventExhibitor
{
    [Route("api/v1/marketing/EventSponsor")]
    public partial class EventSponsorController : AbpController
    {
        private readonly IEventSponsorAppService _appService;
        public EventSponsorController(IEventSponsorAppService appService) { _appService = appService; }
    }
}