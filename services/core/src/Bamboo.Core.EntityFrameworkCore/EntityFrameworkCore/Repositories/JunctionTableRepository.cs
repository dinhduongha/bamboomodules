using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Volo.Abp.DependencyInjection;

using Bamboo.Core.Domain.Repositories;

namespace Bamboo.Core.EntityFrameworkCore
{

    public class JunctionTableRepository : IJunctionTableRepository
    {
        private readonly CoreDbContext _dbContext;

        public JunctionTableRepository(CoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertJunctionRecordsAsync(string tableName, string leftKey, Guid leftId, string rightKey, List<Guid> rightIds, Guid? tenantId)
        {
            if (rightIds == null || rightIds.Count == 0)
            {
                return;
            }

            var columns = tenantId.HasValue ? $"{leftKey}, {rightKey}, tenant_id" : $"{leftKey}, {rightKey}";
            var values = rightIds.Select((_, i) => $"(@p0, @p{i}1" + (tenantId.HasValue ? ", @p2" : "") + ")").ToList();
            var sql = $"INSERT INTO {tableName} ({columns}) VALUES {string.Join(", ", values)}";

            var parameters = new List<object> { leftId };
            parameters.AddRange((IEnumerable<object>)rightIds);
            if (tenantId.HasValue)
            {
                parameters.Add(tenantId.Value);
            }

            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters.ToArray());
        }
    }
}