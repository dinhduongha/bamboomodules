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
    // Category: Productivity/Data Cleaning, Module: data_recycle
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/DataRecycleRecord")]
    public partial class DataRecycleRecordController : AbpController
    {
        private readonly IDataRecycleRecordAppService _appService;
        public DataRecycleRecordController(IDataRecycleRecordAppService appService) { _appService = appService; }
    }
}