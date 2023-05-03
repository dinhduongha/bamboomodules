
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
[ExposeServices(typeof(ICrmIapLeadHelperAppService), typeof(CrmIapLeadHelperClientProxy))]
public partial class CrmIapLeadHelperClientProxy : ClientProxyBase<ICrmIapLeadHelperAppService>, ICrmIapLeadHelperAppService
{
    //public virtual async Task<ListResultDto<CrmIapLeadHelper>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<CrmIapLeadHelper>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<CrmIapLeadHelper>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<CrmIapLeadHelper>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<CrmIapLeadHelper> GetAsync(Guid id)
    {
        return await RequestAsync<CrmIapLeadHelper>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<CrmIapLeadHelper> CreateAsync(CrmIapLeadHelper input)
    {
        return await RequestAsync<CrmIapLeadHelper>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(CrmIapLeadHelper), input }
        });
    }

    public virtual async Task<CrmIapLeadHelper> UpdateAsync(Guid id, CrmIapLeadHelper input)
    {
        return await RequestAsync<CrmIapLeadHelper>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(CrmIapLeadHelper), input }
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
