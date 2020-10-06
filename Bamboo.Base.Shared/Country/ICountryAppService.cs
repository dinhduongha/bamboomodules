using System;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace Bamboo.Base.Shared
{
    public interface ICountryAppService : IApplicationService
	{
		Task<CountryDto> Create(CreateCountryDto input);
	}

}