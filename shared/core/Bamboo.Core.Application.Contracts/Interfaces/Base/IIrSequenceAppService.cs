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
    public interface IIrSequenceAppService : IGenericApplicationService<IrSequence>
    {
        Task<IrSequence> GetAsync(Guid id, IrSequenceGetRequestDto input);
        Task<IrSequence> GetIdAsync(Guid id, IrSequenceGetIdRequestDto input);
        Task<IrSequence> GetNextCharAsync(Guid id, IrSequenceGetNextCharRequestDto input);
        Task<IrSequence> NextByCodeAsync(Guid id, IrSequenceNextByCodeRequestDto input);
        Task<IrSequence> NextByIdAsync(Guid id, IrSequenceNextByIdRequestDto input);
    }
}