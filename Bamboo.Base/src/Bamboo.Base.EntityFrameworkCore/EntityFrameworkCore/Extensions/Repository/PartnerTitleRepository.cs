using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Timing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

using Bamboo.Base.Entities;
using Bamboo.Base.EntityFrameworkCore;

namespace Bamboo.IOT.EntityFrameworkCore
{
    public class EfCoreTitleRepository : EfCoreRepository<IBaseDbContext, PartnerTitle, long>, IPartnerTitleRepository
    {
        public EfCoreTitleRepository(
            IDbContextProvider<IBaseDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}