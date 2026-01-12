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
    public interface IIrUiMenuAppService : IGenericApplicationService<IrUiMenu>
    {
        Task<IrUiMenu> GetUserRootsAsync(Guid id);
        Task<IrUiMenu> LoadMenusAsync(Guid id, IrUiMenuLoadMenusRequestDto input);
        Task<IrUiMenu> LoadMenusRootAsync(Guid id);
        Task<IrUiMenu> LoadWebMenusAsync(Guid id, IrUiMenuLoadWebMenusRequestDto input);
    }
}