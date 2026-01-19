using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

public partial class StockMove
{
    [Column("sequence_in_route")]
    public int SequenceInRoute { get; set; } = 0;

    // Không có FK mới cần navigation
}