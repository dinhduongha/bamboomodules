using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.DataRecycle
{
    [Route("api/v1/productivity/DataRecycleRecord")]
    public partial class DataRecycleRecordController : AbpControllerBase
    {
        private readonly IDataRecycleRecordAppService _appService;
        public DataRecycleRecordController(IDataRecycleRecordAppService appService) { _appService = appService; }
    }
}