using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Crm
{
    [Route("api/v1/sales/CrmLostReason")]
    public partial class CrmLostReasonController : AbpControllerBase
    {
        private readonly ICrmLostReasonAppService _appService;
        public CrmLostReasonController(ICrmLostReasonAppService appService) { _appService = appService; }
    }
}