using System;
using Newtonsoft.Json;

using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

using Bamboo.Common;

namespace Bamboo.Base.Shared
{
    public class BankAccountExtraData: IExtraData
    {

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateBankAccountDto: EntityDto<Guid>
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
    public class UpdateBankAccountDto: CreateBankAccountDto
    { 
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BankAccountDto : CreateBankAccountDto
    {
        public Guid Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

    }

}