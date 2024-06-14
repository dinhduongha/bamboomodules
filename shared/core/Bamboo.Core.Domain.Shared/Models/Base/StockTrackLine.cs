using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("stock_track_line")]
public partial class StockTrackLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockTrackLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockTrackLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("StockTrackLines")]
    [NotMapped]
    public virtual StockTrackConfirmation? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockTrackLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
