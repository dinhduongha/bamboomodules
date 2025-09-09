using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Digest
{
    [Route("api/v1/marketing/DigestDigest")]
    public partial class DigestDigestController : AbpController
    {
        private readonly IDigestDigestAppService _appService;
        public DigestDigestController(IDigestDigestAppService appService) { _appService = appService; }
    }
}