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

//[Table("hr_departure_wizard")]
public partial class HrDepartureWizard
{
    [Column("archive_private_address")]
    public bool? ArchivePrivateAddress { get; set; }

    [Column("cancel_leaves")]
    public bool? CancelLeaves { get; set; }

    [Column("archive_allocation")]
    public bool? ArchiveAllocation { get; set; }
}
