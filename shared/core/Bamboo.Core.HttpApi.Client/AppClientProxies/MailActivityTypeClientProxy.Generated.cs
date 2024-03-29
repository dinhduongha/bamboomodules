
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
[ExposeServices(typeof(IMailActivityTypeAppService), typeof(MailActivityTypeClientProxy))]
public partial class MailActivityTypeClientProxy : ClientProxyBase<IMailActivityTypeAppService>, IMailActivityTypeAppService
{
    //public virtual async Task<ListResultDto<MailActivityType>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailActivityType>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailActivityType>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailActivityType>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailActivityType> GetAsync(long id)
    {
        return await RequestAsync<MailActivityType>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<MailActivityType> CreateAsync(MailActivityType input)
    {
        return await RequestAsync<MailActivityType>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailActivityType), input }
        });
    }

    public virtual async Task<MailActivityType> UpdateAsync(long id, MailActivityType input)
    {
        return await RequestAsync<MailActivityType>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(MailActivityType), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}
