using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

using Bamboo.AbpClient;
using Bamboo.AbpClient.Services;
using Bamboo.Base.Shared;

namespace Bamboo.Base.Client
{
	public class BankClientAppService : AbpCoreAppService, IBankAppService
	{
		public BankClientAppService(IAbpClient apiClient)
			: base(apiClient)
		{

		}

		public async Task<BankDto> CreateAsync(CreateBankDto input)
		{
			await Task.CompletedTask;
			return null;
		}
	}

}