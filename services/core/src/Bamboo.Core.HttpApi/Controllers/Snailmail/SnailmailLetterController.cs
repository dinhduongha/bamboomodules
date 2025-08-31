using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Snailmail
{
    [Route("api/v1/snailmail/SnailmailLetter")]
    public partial class SnailmailLetterController : AbpControllerBase
    {
        private readonly ISnailmailLetterAppService _appService;
        public SnailmailLetterController(ISnailmailLetterAppService appService) { _appService = appService; }
    }
}