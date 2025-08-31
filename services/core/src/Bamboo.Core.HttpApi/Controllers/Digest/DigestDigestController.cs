using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Digest
{
    [Route("api/v1/marketing/DigestDigest")]
    public partial class DigestDigestController : AbpControllerBase
    {
        private readonly IDigestDigestAppService _appService;
        public DigestDigestController(IDigestDigestAppService appService) { _appService = appService; }
    }
}