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
    // Category: Hidden/Tools, Module: snailmail
    [Authorize]
    [Route("api/v1/snailmail/SnailmailLetter")]
    public partial class SnailmailLetterController : AbpController
    {
        private readonly ISnailmailLetterAppService _appService;
        public SnailmailLetterController(ISnailmailLetterAppService appService) { _appService = appService; }
    }
}