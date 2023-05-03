
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;

namespace Bamboo.Core.Services;
public interface IBaseImportTestsModelsM2oRequiredAppService :
    ICrudAppService<
        BaseImportTestsModelsM2oRequired,
        Guid,
        PagedAndSortedResultRequestDto>
{
}
