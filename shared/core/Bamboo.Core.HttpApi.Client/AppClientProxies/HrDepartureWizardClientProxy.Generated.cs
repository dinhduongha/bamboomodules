
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
[ExposeServices(typeof(IHrDepartureWizardAppService), typeof(HrDepartureWizardClientProxy))]
public partial class HrDepartureWizardClientProxy : ClientProxyBase<IHrDepartureWizardAppService>, IHrDepartureWizardAppService
{
    //public virtual async Task<ListResultDto<HrDepartureWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrDepartureWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrDepartureWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrDepartureWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrDepartureWizard> GetAsync(Guid id)
    {
        return await RequestAsync<HrDepartureWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrDepartureWizard> CreateAsync(HrDepartureWizard input)
    {
        return await RequestAsync<HrDepartureWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrDepartureWizard), input }
        });
    }

    public virtual async Task<HrDepartureWizard> UpdateAsync(Guid id, HrDepartureWizard input)
    {
        return await RequestAsync<HrDepartureWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrDepartureWizard), input }
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
