using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ResGroups
{

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("privilege_id")]
    public Guid? PrivilegeId { get; set; }

    [Column("lock_timeout")]
    public long? LockTimeout { get; set; }

    [Column("lock_timeout_inactivity")]
    public long? LockTimeoutInactivity { get; set; }

    [Column("lock_timeout_mfa")]
    public bool? LockTimeoutMfa { get; set; }

    [Column("lock_timeout_inactivity_mfa")]
    public bool? LockTimeoutInactivityMfa { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PrivilegeId")]
    public virtual ResGroupsPrivilege? Privilege { get; set; }

}