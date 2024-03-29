
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
[ExposeServices(typeof(IWizardIrModelMenuCreateAppService), typeof(WizardIrModelMenuCreateClientProxy))]
public partial class WizardIrModelMenuCreateClientProxy : ClientProxyBase<IWizardIrModelMenuCreateAppService>, IWizardIrModelMenuCreateAppService
{
    //public virtual async Task<ListResultDto<WizardIrModelMenuCreate>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<WizardIrModelMenuCreate>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<WizardIrModelMenuCreate>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<WizardIrModelMenuCreate>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<WizardIrModelMenuCreate> GetAsync(Guid id)
    {
        return await RequestAsync<WizardIrModelMenuCreate>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<WizardIrModelMenuCreate> CreateAsync(WizardIrModelMenuCreate input)
    {
        return await RequestAsync<WizardIrModelMenuCreate>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(WizardIrModelMenuCreate), input }
        });
    }

    public virtual async Task<WizardIrModelMenuCreate> UpdateAsync(Guid id, WizardIrModelMenuCreate input)
    {
        return await RequestAsync<WizardIrModelMenuCreate>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(WizardIrModelMenuCreate), input }
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
