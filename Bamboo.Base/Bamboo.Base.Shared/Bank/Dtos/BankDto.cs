using System;
using Newtonsoft.Json;

using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class BankExtraData: IExtraData
    {

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateBankDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public string SortName { get; set; }

        public string LongName { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public string BIC { get; set; }

        public string Description { get; set; }

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateBankDto: CreateBankDto
    { 
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BankDto : CreateBankDto
    {

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

    }

}