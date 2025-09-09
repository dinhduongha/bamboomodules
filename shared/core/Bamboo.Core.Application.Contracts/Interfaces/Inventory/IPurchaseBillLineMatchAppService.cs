using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IPurchaseBillLineMatchAppService : IApplicationService
    {
        Task<PurchaseBillLineMatch> AddToPoAsync(Guid id);
        Task<PurchaseBillLineMatch> MatchLinesAsync(Guid id);
        Task<PurchaseBillLineMatch> OpenLineAsync(Guid id);
    }
}