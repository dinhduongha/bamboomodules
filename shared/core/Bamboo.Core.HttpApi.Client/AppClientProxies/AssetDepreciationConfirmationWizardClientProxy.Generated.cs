
// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;

using Bamboo.Core.Models;
using Bamboo.Core.Services;

// ReSharper disable once CheckNamespace
namespace Bamboo.Core.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IAssetDepreciationConfirmationWizardAppService), typeof(AssetDepreciationConfirmationWizardClientProxy))]
public partial class AssetDepreciationConfirmationWizardClientProxy : ClientProxyBase<IAssetDepreciationConfirmationWizardAppService>, IAssetDepreciationConfirmationWizardAppService
{
    //public virtual async Task<ListResultDto<AssetDepreciationConfirmationWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AssetDepreciationConfirmationWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AssetDepreciationConfirmationWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AssetDepreciationConfirmationWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AssetDepreciationConfirmationWizard> GetAsync(Guid id)
    {
        return await RequestAsync<AssetDepreciationConfirmationWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AssetDepreciationConfirmationWizard> CreateAsync(AssetDepreciationConfirmationWizard input)
    {
        return await RequestAsync<AssetDepreciationConfirmationWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AssetDepreciationConfirmationWizard), input }
        });
    }

    public virtual async Task<AssetDepreciationConfirmationWizard> UpdateAsync(Guid id, AssetDepreciationConfirmationWizard input)
    {
        return await RequestAsync<AssetDepreciationConfirmationWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AssetDepreciationConfirmationWizard), input }
        });
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }
}