
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
[ExposeServices(typeof(IHrAttendanceAppService), typeof(HrAttendanceClientProxy))]
public partial class HrAttendanceClientProxy : ClientProxyBase<IHrAttendanceAppService>, IHrAttendanceAppService
{
    //public virtual async Task<ListResultDto<HrAttendance>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrAttendance>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrAttendance>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrAttendance>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrAttendance> GetAsync(Guid id)
    {
        return await RequestAsync<HrAttendance>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrAttendance> CreateAsync(HrAttendance input)
    {
        return await RequestAsync<HrAttendance>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrAttendance), input }
        });
    }

    public virtual async Task<HrAttendance> UpdateAsync(Guid id, HrAttendance input)
    {
        return await RequestAsync<HrAttendance>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrAttendance), input }
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
