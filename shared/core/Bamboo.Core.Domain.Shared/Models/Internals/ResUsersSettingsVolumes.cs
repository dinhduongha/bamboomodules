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

[Table("res_users_settings_volumes")]
//[Index("GuestId", Name = "res_users_settings_volumes__guest_id_index")]
//[Index("PartnerId", Name = "res_users_settings_volumes__partner_id_index")]
//[Index("UserSettingId", Name = "res_users_settings_volumes__user_setting_id_index")]
public partial class ResUsersSettingsVolumes: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    
    [Column("user_setting_id")]
    public Guid? UserSettingId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("volume")]
    public double? Volume { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResUsersSettingsVolumesCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("GuestId")]
    // [InverseProperty("ResUsersSettingsVolumesGuest")] //Many2one
    public virtual ResPartner? Guest { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ResUsersSettingsVolumesPartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("UserSettingId")]
    // [InverseProperty("ResUsersSettingsVolumes")] //Many2one
    public virtual ResUsersSettings? UserSetting { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResUsersSettingsVolumesWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
