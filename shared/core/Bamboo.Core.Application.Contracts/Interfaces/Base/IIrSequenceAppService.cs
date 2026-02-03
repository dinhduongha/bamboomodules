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
    public interface IIrSequenceAppService : IGenericAppService<IrSequence>
    {
        Task<IrSequence> GetNextCharAsync(IrSequenceGetNextCharRequestDto input);
        Task<IrSequence> NextByCodeAsync(IrSequenceNextByCodeRequestDto input);
        Task<IrSequence> NextByIdAsync(IrSequenceNextByIdRequestDto input);
    }
}