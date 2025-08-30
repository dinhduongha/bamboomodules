using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("product_product")]
//[Index("CombinationIndices", Name = "product_product__combination_indices_index")]
//[Index("DefaultCode", Name = "product_product__default_code_index")]
//[Index("ProductTmplId", Name = "product_product__product_tmpl_id_index")]
public partial class ProductProduct
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (ProjectCreateSaleOrderLine) is commented out
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (RepairFee) is commented out
    // public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (RepairLine) is commented out
    // public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("DepositDefaultProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DepositDefaultProduct")] // One2many // Peer relationship (ResConfigSettings) is commented out
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsDepositDefaultProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ProductProduct'
    // [One2many] [ForeignKey("ProductId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Product")] // One2many // Peer relationship (SaleAdvancePaymentInv) is commented out
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }
}
