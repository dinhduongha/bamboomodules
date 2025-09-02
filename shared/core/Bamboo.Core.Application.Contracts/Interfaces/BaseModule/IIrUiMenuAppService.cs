using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IIrUiMenuAppService : IGenericApplicationService<IrUiMenu>
    {
        Task<IrUiMenu> GetUserRootsAsync(Guid id);
        Task<IrUiMenu> LoadMenusAsync(Guid id, IrUiMenuLoadMenusRequestDto input);
        Task<IrUiMenu> LoadMenusRootAsync(Guid id);
        Task<IrUiMenu> LoadWebMenusAsync(Guid id, IrUiMenuLoadWebMenusRequestDto input);
        Task<IrUiMenu> SearchCountAsync(Guid id, IrUiMenuSearchCountRequestDto input);
        Task<IrUiMenu> SearchFetchAsync(Guid id, IrUiMenuSearchFetchRequestDto input);
    }
}