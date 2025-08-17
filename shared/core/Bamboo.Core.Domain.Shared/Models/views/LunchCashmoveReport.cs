using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class LunchCashmoveReport: Entity<Guid>
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
