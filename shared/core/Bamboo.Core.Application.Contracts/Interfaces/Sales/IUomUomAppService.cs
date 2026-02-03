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
        Task<UomUom> CompareAsync(UomUomCompareRequestDto input);
        Task<bool> IsZeroAsync(UomUomIsZeroRequestDto input);
        Task<UomUom> OpenPackagingBarcodesAsync(Guid[] ids);
        Task<float> RoundAsync(UomUomRoundRequestDto input);
    }
}