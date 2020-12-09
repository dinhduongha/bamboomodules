using System;
using Newtonsoft.Json;

using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Dtos
{
    public class BankAccountExtraData
    {

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateBankAccountDto
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
    public class UpdateBankAccountDto : CreateBankAccountDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BankAccountDto : UpdateBankAccountDto
    {
        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

    }

}