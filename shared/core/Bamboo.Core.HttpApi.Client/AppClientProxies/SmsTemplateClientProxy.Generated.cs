
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
[ExposeServices(typeof(ISmsTemplateAppService), typeof(SmsTemplateClientProxy))]
public partial class SmsTemplateClientProxy : ClientProxyBase<ISmsTemplateAppService>, ISmsTemplateAppService
{
    //public virtual async Task<ListResultDto<SmsTemplate>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SmsTemplate>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SmsTemplate>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SmsTemplate>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SmsTemplate> GetAsync(Guid id)
    {
        return await RequestAsync<SmsTemplate>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SmsTemplate> CreateAsync(SmsTemplate input)
    {
        return await RequestAsync<SmsTemplate>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SmsTemplate), input }
        });
    }

    public virtual async Task<SmsTemplate> UpdateAsync(Guid id, SmsTemplate input)
    {
        return await RequestAsync<SmsTemplate>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SmsTemplate), input }
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
