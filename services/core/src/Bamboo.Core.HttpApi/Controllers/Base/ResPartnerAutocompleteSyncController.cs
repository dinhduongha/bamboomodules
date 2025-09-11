using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden/Tools, Module: partner_autocomplete
    [Authorize]
    [Route("api/v1/partner-autocomplete/ResPartnerAutocompleteSync")]
    public partial class ResPartnerAutocompleteSyncController : AbpController
    {
        private readonly IResPartnerAutocompleteSyncAppService _appService;
        public ResPartnerAutocompleteSyncController(IResPartnerAutocompleteSyncAppService appService) { _appService = appService; }
    }
}