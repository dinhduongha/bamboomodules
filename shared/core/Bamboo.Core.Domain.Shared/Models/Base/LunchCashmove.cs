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

[Table("lunch_cashmove")]
public partial class LunchCashmove: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LunchCashmoveCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("LunchCashmoves")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("LunchCashmoveUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LunchCashmoveWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
