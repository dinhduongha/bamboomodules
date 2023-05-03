
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
[ExposeServices(typeof(IPosCloseSessionWizardAppService), typeof(PosCloseSessionWizardClientProxy))]
public partial class PosCloseSessionWizardClientProxy : ClientProxyBase<IPosCloseSessionWizardAppService>, IPosCloseSessionWizardAppService
{
    //public virtual async Task<ListResultDto<PosCloseSessionWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PosCloseSessionWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PosCloseSessionWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PosCloseSessionWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PosCloseSessionWizard> GetAsync(Guid id)
    {
        return await RequestAsync<PosCloseSessionWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PosCloseSessionWizard> CreateAsync(PosCloseSessionWizard input)
    {
        return await RequestAsync<PosCloseSessionWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PosCloseSessionWizard), input }
        });
    }

    public virtual async Task<PosCloseSessionWizard> UpdateAsync(Guid id, PosCloseSessionWizard input)
    {
        return await RequestAsync<PosCloseSessionWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PosCloseSessionWizard), input }
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