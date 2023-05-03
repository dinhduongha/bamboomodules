
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
[ExposeServices(typeof(IBaseImportImportAppService), typeof(BaseImportImportClientProxy))]
public partial class BaseImportImportClientProxy : ClientProxyBase<IBaseImportImportAppService>, IBaseImportImportAppService
{
    //public virtual async Task<ListResultDto<BaseImportImport>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<BaseImportImport>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<BaseImportImport>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<BaseImportImport>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<BaseImportImport> GetAsync(Guid id)
    {
        return await RequestAsync<BaseImportImport>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<BaseImportImport> CreateAsync(BaseImportImport input)
    {
        return await RequestAsync<BaseImportImport>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(BaseImportImport), input }
        });
    }

    public virtual async Task<BaseImportImport> UpdateAsync(Guid id, BaseImportImport input)
    {
        return await RequestAsync<BaseImportImport>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(BaseImportImport), input }
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
