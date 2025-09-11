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
    // Category: Marketing, Module: digest
    [Authorize]
    [Route("api/v1/marketing/DigestDigest")]
    public partial class DigestDigestController : AbpController
    {
        private readonly IDigestDigestAppService _appService;
        public DigestDigestController(IDigestDigestAppService appService) { _appService = appService; }
    }
}