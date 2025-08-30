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

//[Table("pos_order")]
//[Index("CompanyId", Name = "pos_order__company_id_index")]
//[Index("DateOrder", Name = "pos_order__date_order_index")]
//[Index("PosReference", Name = "pos_order__pos_reference_index")]
//[Index("SessionId", Name = "pos_order__session_id_index")]
//[Index("State", Name = "pos_order__state_index")]
public partial class PosOrder
{
    [Column("note")]
    public string? Note { get; set; }

    [Column("to_ship")]
    public bool? ToShip { get; set; }

    [Column("multiprint_resume")]
    public string? MultiprintResume { get; set; }

    // [Many2one]
    // [ForeignKey("AccountMove")]
    // public virtual AccountMove? AccountMoveNavigation { get; set; }
}
