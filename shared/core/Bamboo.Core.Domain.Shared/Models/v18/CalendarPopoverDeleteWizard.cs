using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("calendar_popover_delete_wizard")]
public partial class CalendarPopoverDeleteWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("record")]
    public Guid? Record { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("delete")]
    public string? Delete { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CalendarPopoverDeleteWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("Record")]
    //[InverseProperty("CalendarPopoverDeleteWizards")]
    [NotMapped]
    public virtual CalendarEvent? RecordNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CalendarPopoverDeleteWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
