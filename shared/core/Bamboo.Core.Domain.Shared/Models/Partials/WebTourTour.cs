using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("web_tour_tour")]
public partial class WebTourTour
{

    [Column("user_id")]
    public Guid? UserId { get; set; }


    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }
}
