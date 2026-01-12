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
    // Category: Marketing, Module: digest
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/DigestDigest")]
    public partial class DigestDigestController : AbpController
    {
        private readonly IDigestDigestAppService _appService;
        public DigestDigestController(IDigestDigestAppService appService) { _appService = appService; }
    }
}