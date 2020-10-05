using System;
using Abp.Domain.Entities;
using Newtonsoft.Json;
namespace Bamboo.Base.Bank
{
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
    public class UpdateBankDto: CreateBankDto
    { 
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BankDto : CreateBankDto
    {
        public Guid Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

    }

}