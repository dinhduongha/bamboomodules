
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
[ExposeServices(typeof(IMrpDocumentAppService), typeof(MrpDocumentClientProxy))]
public partial class MrpDocumentClientProxy : ClientProxyBase<IMrpDocumentAppService>, IMrpDocumentAppService
{
    //public virtual async Task<ListResultDto<MrpDocument>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpDocument>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpDocument>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpDocument>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpDocument> GetAsync(Guid id)
    {
        return await RequestAsync<MrpDocument>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpDocument> CreateAsync(MrpDocument input)
    {
        return await RequestAsync<MrpDocument>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpDocument), input }
        });
    }

    public virtual async Task<MrpDocument> UpdateAsync(Guid id, MrpDocument input)
    {
        return await RequestAsync<MrpDocument>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpDocument), input }
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