using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IUomUomAppService : IGenericApplicationService<UomUom>
    {
        Task<UomUom> CompareAsync(Guid id, UomUomCompareRequestDto input);
        Task<bool> IsZeroAsync(Guid id, UomUomIsZeroRequestDto input);
        Task<UomUom> OpenPackagingBarcodesAsync(Guid id);
        Task<float> RoundAsync(Guid id, UomUomRoundRequestDto input);
    }
}