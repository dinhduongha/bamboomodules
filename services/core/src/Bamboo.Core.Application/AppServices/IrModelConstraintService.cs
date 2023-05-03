
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Models;

namespace Bamboo.Core.Services;

//[Authorize]
public partial class IrModelConstraintAppService :
    CrudAppService<IrModelConstraint, IrModelConstraint, Guid, PagedAndSortedResultRequestDto>,
    IIrModelConstraintAppService
{
    private readonly IDataFilter _dataFilter;

    public IrModelConstraintAppService(IDataFilter dataFilter, IRepository<IrModelConstraint, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
