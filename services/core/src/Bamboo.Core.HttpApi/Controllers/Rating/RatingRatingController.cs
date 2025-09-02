using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Rating
{
    [Route("api/v1/productivity/RatingRating")]
    public partial class RatingRatingController : AbpControllerBase
    {
        private readonly IRatingRatingAppService _appService;
        public RatingRatingController(IRatingRatingAppService appService) { _appService = appService; }
    }
}