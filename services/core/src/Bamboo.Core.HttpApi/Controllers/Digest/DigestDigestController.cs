using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Digest
{
    [Route("api/v1/marketing/DigestDigest")]
    public partial class DigestDigestController : AbpControllerBase
    {
        private readonly IDigestDigestAppService _appService;
        public DigestDigestController(IDigestDigestAppService appService) { _appService = appService; }
    }
}