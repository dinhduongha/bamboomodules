
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
[ExposeServices(typeof(ICrmQuotationPartnerAppService), typeof(CrmQuotationPartnerClientProxy))]
public partial class CrmQuotationPartnerClientProxy : ClientProxyBase<ICrmQuotationPartnerAppService>, ICrmQuotationPartnerAppService
{
    //public virtual async Task<ListResultDto<CrmQuotationPartner>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<CrmQuotationPartner>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<CrmQuotationPartner>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<CrmQuotationPartner>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<CrmQuotationPartner> GetAsync(Guid id)
    {
        return await RequestAsync<CrmQuotationPartner>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<CrmQuotationPartner> CreateAsync(CrmQuotationPartner input)
    {
        return await RequestAsync<CrmQuotationPartner>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(CrmQuotationPartner), input }
        });
    }

    public virtual async Task<CrmQuotationPartner> UpdateAsync(Guid id, CrmQuotationPartner input)
    {
        return await RequestAsync<CrmQuotationPartner>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(CrmQuotationPartner), input }
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
