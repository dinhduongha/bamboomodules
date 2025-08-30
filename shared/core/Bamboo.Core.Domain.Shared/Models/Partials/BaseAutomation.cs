using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("base_automation")]
public partial class BaseAutomation
{

    [Column("action_server_id")]
    public Guid? ActionServerId { get; set; }

    // [Many2one]
    [ForeignKey("ActionServerId")]
    public virtual IrActServer? ActionServer { get; set; }

}
