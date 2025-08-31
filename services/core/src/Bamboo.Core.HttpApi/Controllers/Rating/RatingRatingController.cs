using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Rating
{
    [Route("api/v1/productivity/RatingRating")]
    public partial class RatingRatingController : AbpControllerBase
    {
        private readonly IRatingRatingAppService _appService;
        public RatingRatingController(IRatingRatingAppService appService) { _appService = appService; }
    }
}