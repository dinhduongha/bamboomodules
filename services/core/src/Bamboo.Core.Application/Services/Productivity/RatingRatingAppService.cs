using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Rating", Category = "Productivity", Depends = new[] { "mail" })]
    public partial class RatingRatingAppService : GenericAppService<RatingRating>, IRatingRatingAppService
    {

        public RatingRatingAppService(IRepository<RatingRating, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public override async Task<RatingRating> CreateAsync(CreateRequestDto<RatingRating> input)
        {
            /*
            --- METHOD SOURCE (MODULE: portal_rating, FILE: rating_rating.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: rating, FILE: rating.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<RatingRating> OpenRatedObjectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: rating_rating.py, METHOD: action_open_rated_object) ---
            --- METHOD SOURCE (MODULE: rating, FILE: rating.py, METHOD: action_open_rated_object) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RatingRating> ResetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating.py, METHOD: reset) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<RatingRating> input)
        {
            /*
            --- METHOD SOURCE (MODULE: portal_rating, FILE: rating_rating.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: rating, FILE: rating.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}