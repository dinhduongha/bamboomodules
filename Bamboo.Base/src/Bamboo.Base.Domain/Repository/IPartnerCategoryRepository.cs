using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Timing;
using Volo.Abp.Domain.Repositories;
using Bamboo.Base.Entities;

namespace Bamboo.IOT.EntityFrameworkCore
{
    public interface IPartnerCategoryRepository : IBasicRepository<PartnerCategory, Guid> //, INodeRepository
    {
        //Task<List<Bank>> GetListAsync(BankFilter input, bool includeDetails = false,
        //    CancellationToken cancellationToken = default);
        //Task<long> GetCountAsync(
        //    BankFilter input,
        //    CancellationToken cancellationToken = default);
    }
}