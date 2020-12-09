using System;
using Newtonsoft.Json;

using Bamboo.Common;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Dtos
{
    public class BankExtraData
    {

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateBankDto
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
    public class UpdateBankDto: CreateBankDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BankDto : UpdateBankDto
    {

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

    }

}