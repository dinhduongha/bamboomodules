
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
public partial class AssetDepreciationConfirmationWizardAppService :
    CrudAppService<AssetDepreciationConfirmationWizard, AssetDepreciationConfirmationWizard, Guid, PagedAndSortedResultRequestDto>,
    IAssetDepreciationConfirmationWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public AssetDepreciationConfirmationWizardAppService(IDataFilter dataFilter, IRepository<AssetDepreciationConfirmationWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
