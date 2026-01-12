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
    // Category: Hidden/Tools, Module: partner_autocomplete
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/partner-autocomplete/ResPartnerAutocompleteSync")]
    public partial class ResPartnerAutocompleteSyncController : AbpController
    {
        private readonly IResPartnerAutocompleteSyncAppService _appService;
        public ResPartnerAutocompleteSyncController(IResPartnerAutocompleteSyncAppService appService) { _appService = appService; }
    }
}