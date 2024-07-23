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

[Table("privacy_lookup_wizard")]
public partial class PrivacyLookupWizard: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("log_id")]
    public Guid? LogId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("execution_details")]
    public string? ExecutionDetails { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PrivacyLookupWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LogId")]
    //[InverseProperty("PrivacyLookupWizards")]
    [NotMapped]
    public virtual PrivacyLog? Log { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PrivacyLookupWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Wizard")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLines { get; } = new List<PrivacyLookupWizardLine>();

}
