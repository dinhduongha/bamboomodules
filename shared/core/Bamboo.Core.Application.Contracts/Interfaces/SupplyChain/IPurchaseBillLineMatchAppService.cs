using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IPurchaseBillLineMatchAppService : IApplicationService
    {
        Task<PurchaseBillLineMatch> AddToPoAsync(Guid[] ids);
        Task<PurchaseBillLineMatch> MatchLinesAsync(Guid[] ids);
        Task<PurchaseBillLineMatch> OpenLineAsync(Guid[] ids);
    }
}