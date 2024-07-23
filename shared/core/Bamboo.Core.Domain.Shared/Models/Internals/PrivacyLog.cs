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

[Table("privacy_log")]
public partial class PrivacyLog: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("anonymized_name")]
    public string? AnonymizedName { get; set; }

    [Column("anonymized_email")]
    public string? AnonymizedEmail { get; set; }

    [Column("execution_details")]
    public string? ExecutionDetails { get; set; }

    [Column("records_description")]
    public string? RecordsDescription { get; set; }

    [Column("additional_note")]
    public string? AdditionalNote { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PrivacyLogCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("PrivacyLogUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PrivacyLogWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Log")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizards { get; } = new List<PrivacyLookupWizard>();

}
