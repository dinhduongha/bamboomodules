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
//[Index("GuestId", Name = "res_users_settings_volumes_guest_id_index")]
//[Index("PartnerId", Name = "res_users_settings_volumes_partner_id_index")]
//[Index("UserSettingId", Name = "res_users_settings_volumes_user_setting_id_index")]
public partial class ResUsersSettingsVolume: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_setting_id")]
    public Guid? UserSettingId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("volume")]
    public double? Volume { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResUsersSettingsVolumeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GuestId")]
    //[InverseProperty("ResUsersSettingsVolumeGuests")]
    [NotMapped]
    public virtual ResPartner? Guest { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ResUsersSettingsVolumePartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("UserSettingId")]
    //[InverseProperty("ResUsersSettingsVolumes")]
    [NotMapped]
    public virtual ResUsersSetting? UserSetting { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResUsersSettingsVolumeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
