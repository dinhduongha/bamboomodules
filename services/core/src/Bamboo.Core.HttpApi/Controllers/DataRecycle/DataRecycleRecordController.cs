using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    [Route("api/v1/productivity/DataRecycleRecord")]
    public partial class DataRecycleRecordController : AbpControllerBase
    {
        private readonly IDataRecycleRecordAppService _appService;
        public DataRecycleRecordController(IDataRecycleRecordAppService appService) { _appService = appService; }
    }
}