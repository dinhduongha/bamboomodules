
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
[ExposeServices(typeof(ILotLabelLayoutAppService), typeof(LotLabelLayoutClientProxy))]
public partial class LotLabelLayoutClientProxy : ClientProxyBase<ILotLabelLayoutAppService>, ILotLabelLayoutAppService
{
    //public virtual async Task<ListResultDto<LotLabelLayout>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<LotLabelLayout>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<LotLabelLayout>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<LotLabelLayout>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<LotLabelLayout> GetAsync(Guid id)
    {
        return await RequestAsync<LotLabelLayout>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<LotLabelLayout> CreateAsync(LotLabelLayout input)
    {
        return await RequestAsync<LotLabelLayout>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(LotLabelLayout), input }
        });
    }

    public virtual async Task<LotLabelLayout> UpdateAsync(Guid id, LotLabelLayout input)
    {
        return await RequestAsync<LotLabelLayout>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(LotLabelLayout), input }
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
