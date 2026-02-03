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
        Task<IrUiMenu> GetUserRootsAsync(Guid[] ids);
        Task<IrUiMenu> LoadMenusAsync(IrUiMenuLoadMenusRequestDto input);
        Task<IrUiMenu> LoadMenusRootAsync(Guid[] ids);
        Task<IrUiMenu> LoadWebMenusAsync(IrUiMenuLoadWebMenusRequestDto input);
    }
}