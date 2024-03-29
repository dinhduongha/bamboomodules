
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
[ExposeServices(typeof(IBaseImportTestsModelsM2oAppService), typeof(BaseImportTestsModelsM2oClientProxy))]
public partial class BaseImportTestsModelsM2oClientProxy : ClientProxyBase<IBaseImportTestsModelsM2oAppService>, IBaseImportTestsModelsM2oAppService
{
    //public virtual async Task<ListResultDto<BaseImportTestsModelsM2o>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<BaseImportTestsModelsM2o>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<BaseImportTestsModelsM2o>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<BaseImportTestsModelsM2o>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<BaseImportTestsModelsM2o> GetAsync(Guid id)
    {
        return await RequestAsync<BaseImportTestsModelsM2o>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<BaseImportTestsModelsM2o> CreateAsync(BaseImportTestsModelsM2o input)
    {
        return await RequestAsync<BaseImportTestsModelsM2o>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(BaseImportTestsModelsM2o), input }
        });
    }

    public virtual async Task<BaseImportTestsModelsM2o> UpdateAsync(Guid id, BaseImportTestsModelsM2o input)
    {
        return await RequestAsync<BaseImportTestsModelsM2o>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(BaseImportTestsModelsM2o), input }
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
