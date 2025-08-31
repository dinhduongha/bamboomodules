using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PartnerAutocomplete
{
    [Route("api/v1/partner-autocomplete/ResPartnerAutocompleteSync")]
    public partial class ResPartnerAutocompleteSyncController : AbpControllerBase
    {
        private readonly IResPartnerAutocompleteSyncAppService _appService;
        public ResPartnerAutocompleteSyncController(IResPartnerAutocompleteSyncAppService appService) { _appService = appService; }
    }
}