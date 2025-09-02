using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PartnerAutocomplete
{
    [Route("api/v1/partner-autocomplete/ResPartnerAutocompleteSync")]
    public partial class ResPartnerAutocompleteSyncController : AbpControllerBase
    {
        private readonly IResPartnerAutocompleteSyncAppService _appService;
        public ResPartnerAutocompleteSyncController(IResPartnerAutocompleteSyncAppService appService) { _appService = appService; }
    }
}