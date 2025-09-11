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
    // Category: Productivity/Data Cleaning, Module: data_recycle
    [Authorize]
    [Route("api/v1/productivity/DataRecycleRecord")]
    public partial class DataRecycleRecordController : AbpController
    {
        private readonly IDataRecycleRecordAppService _appService;
        public DataRecycleRecordController(IDataRecycleRecordAppService appService) { _appService = appService; }
    }
}