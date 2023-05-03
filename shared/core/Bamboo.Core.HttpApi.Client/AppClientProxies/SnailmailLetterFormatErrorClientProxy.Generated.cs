
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
[ExposeServices(typeof(ISnailmailLetterFormatErrorAppService), typeof(SnailmailLetterFormatErrorClientProxy))]
public partial class SnailmailLetterFormatErrorClientProxy : ClientProxyBase<ISnailmailLetterFormatErrorAppService>, ISnailmailLetterFormatErrorAppService
{
    //public virtual async Task<ListResultDto<SnailmailLetterFormatError>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SnailmailLetterFormatError>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SnailmailLetterFormatError>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SnailmailLetterFormatError>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SnailmailLetterFormatError> GetAsync(Guid id)
    {
        return await RequestAsync<SnailmailLetterFormatError>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SnailmailLetterFormatError> CreateAsync(SnailmailLetterFormatError input)
    {
        return await RequestAsync<SnailmailLetterFormatError>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SnailmailLetterFormatError), input }
        });
    }

    public virtual async Task<SnailmailLetterFormatError> UpdateAsync(Guid id, SnailmailLetterFormatError input)
    {
        return await RequestAsync<SnailmailLetterFormatError>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SnailmailLetterFormatError), input }
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
