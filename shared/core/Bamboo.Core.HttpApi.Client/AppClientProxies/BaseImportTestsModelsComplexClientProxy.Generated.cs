
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
[ExposeServices(typeof(IBaseImportTestsModelsComplexAppService), typeof(BaseImportTestsModelsComplexClientProxy))]
public partial class BaseImportTestsModelsComplexClientProxy : ClientProxyBase<IBaseImportTestsModelsComplexAppService>, IBaseImportTestsModelsComplexAppService
{
    //public virtual async Task<ListResultDto<BaseImportTestsModelsComplex>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<BaseImportTestsModelsComplex>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<BaseImportTestsModelsComplex>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<BaseImportTestsModelsComplex>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<BaseImportTestsModelsComplex> GetAsync(Guid id)
    {
        return await RequestAsync<BaseImportTestsModelsComplex>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<BaseImportTestsModelsComplex> CreateAsync(BaseImportTestsModelsComplex input)
    {
        return await RequestAsync<BaseImportTestsModelsComplex>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(BaseImportTestsModelsComplex), input }
        });
    }

    public virtual async Task<BaseImportTestsModelsComplex> UpdateAsync(Guid id, BaseImportTestsModelsComplex input)
    {
        return await RequestAsync<BaseImportTestsModelsComplex>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(BaseImportTestsModelsComplex), input }
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
