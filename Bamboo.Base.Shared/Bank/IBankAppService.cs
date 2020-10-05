using System;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace Bamboo.Base.Bank
{
    public interface IBankAppService : IApplicationService
	{
		Task<BankDto> Create(CreateBankDto input);
	}

}