using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

using Bamboo.AbpClient;
using Bamboo.AbpClient.Services;

namespace Bamboo.Base.Bank
{
	public class BankClientAppService : AbpCoreAppService, IBankAppService
	{
		public BankClientAppService(IAbpClient apiClient)
			: base(apiClient)
		{

		}

		public async Task<BankDto> Create(CreateBankDto input)
		{
			await Task.CompletedTask;
			return null;
		}
	}

}