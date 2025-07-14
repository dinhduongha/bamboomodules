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

[Table("change_password_user")]
public partial class ChangePasswordUser: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("user_login")]
    public string? UserLogin { get; set; }

    [Column("new_passwd")]
    public string? NewPasswd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ChangePasswordUserCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ChangePasswordUserUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("ChangePasswordUsers")]
    [NotMapped]
    public virtual ChangePasswordWizard? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ChangePasswordUserWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
