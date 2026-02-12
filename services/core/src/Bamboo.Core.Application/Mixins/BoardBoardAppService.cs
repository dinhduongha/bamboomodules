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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("board", Category = "Productivity", Depends = new[] { "spreadsheet_dashboard" })]
    public partial class BoardBoardAppService : ApplicationService, IBoardBoardAppService
    {

        public BoardBoardAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> ArchPreprocessingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IBoardBoardable
        {
            /*
            --- METHOD SOURCE (MODULE: board, FILE: board.py, METHOD: _arch_preprocessing) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IBoardBoardable
        {
            /*
            --- METHOD SOURCE (MODULE: board, FILE: board.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBoardBoardable
        {
            /*
            --- METHOD SOURCE (MODULE: board, FILE: board.py, METHOD: get_view) ---
            */
            return default;
        }
    }
}