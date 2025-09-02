using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Crm
{
    [Route("api/v1/sales/CrmLostReason")]
    public partial class CrmLostReasonController : AbpControllerBase
    {
        private readonly ICrmLostReasonAppService _appService;
        public CrmLostReasonController(ICrmLostReasonAppService appService) { _appService = appService; }
    }
}