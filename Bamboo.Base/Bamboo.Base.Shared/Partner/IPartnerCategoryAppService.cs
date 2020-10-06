using System;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace Bamboo.Base.Shared
{
    public interface IPartnerCategoryAppService : IApplicationService
	{
		Task<PartnerCategoryDto> Create(CreatePartnerCategoryDto input);
	}

}