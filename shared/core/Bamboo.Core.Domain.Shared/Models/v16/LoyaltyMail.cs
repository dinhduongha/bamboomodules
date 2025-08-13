using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

[Table("loyalty_mail")]
public partial class LoyaltyMail : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("program_id")]
    public Guid? ProgramId { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("trigger")]
    public string? Trigger { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("points")]
    public double? Points { get; set; }

    [Column("pos_report_print_id")]
    public Guid? PosReportPrintId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LoyaltyMailCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailTemplateId")]
    // [InverseProperty("LoyaltyMail")] // [Many2one]
    public virtual MailTemplate? MailTemplate { get; set; }

    // [Many2one]
    [ForeignKey("PosReportPrintId")]
    // [InverseProperty("LoyaltyMail")] // [Many2one]
    public virtual IrActReportXml? PosReportPrint { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    // [InverseProperty("LoyaltyMail")] // [Many2one]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LoyaltyMailWriteU")] // [Many2one]
    public virtual ResUser? WriteU { get; set; }
}
