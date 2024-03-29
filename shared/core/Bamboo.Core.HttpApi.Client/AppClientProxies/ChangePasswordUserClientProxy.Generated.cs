
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
[ExposeServices(typeof(IChangePasswordUserAppService), typeof(ChangePasswordUserClientProxy))]
public partial class ChangePasswordUserClientProxy : ClientProxyBase<IChangePasswordUserAppService>, IChangePasswordUserAppService
{
    //public virtual async Task<ListResultDto<ChangePasswordUser>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ChangePasswordUser>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ChangePasswordUser>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ChangePasswordUser>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ChangePasswordUser> GetAsync(Guid id)
    {
        return await RequestAsync<ChangePasswordUser>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ChangePasswordUser> CreateAsync(ChangePasswordUser input)
    {
        return await RequestAsync<ChangePasswordUser>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ChangePasswordUser), input }
        });
    }

    public virtual async Task<ChangePasswordUser> UpdateAsync(Guid id, ChangePasswordUser input)
    {
        return await RequestAsync<ChangePasswordUser>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ChangePasswordUser), input }
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
