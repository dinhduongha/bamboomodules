using Bamboo.Core.Domain.Shared.Interfaces;
using Volo.Abp.Domain.Entities;
using System;
using Bamboo.Core.Domain.Shared.Attributes;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Bamboo.Core.Models
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    [Model("publisher_warranty.contract", IsTransient = false)]
    [Table("publisher_warranty_contract")]
    public partial class PublisherWarrantyContract : FullAuditedEntity<Guid>
    {
        
        //<editor-fold desc="ABP ENTITY PROPERTIES">
        [Key]
        public override Guid Id { get => base.Id; protected set => base.Id = value; }
        //</editor-fold>
    }
}