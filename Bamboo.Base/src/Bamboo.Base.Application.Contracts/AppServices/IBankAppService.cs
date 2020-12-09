using Bamboo.Base.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bamboo.Base.Services
{
    public interface IBankAppService :
        ICrudAppService< //Defines CRUD methods
            BankDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateBankDto, UpdateBankDto> //Used to create/update a book
    {

    }
}
