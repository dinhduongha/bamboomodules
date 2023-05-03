
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;

namespace Bamboo.Core.Services;
public interface IProductProductAppService :
    ICrudAppService<
        ProductProduct,
        Guid,
        PagedAndSortedResultRequestDto>
{
}
