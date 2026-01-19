using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

public partial class SaleOrder
{
    [Column("preferred_delivery_time_slot")]
    public string? PreferredDeliveryTimeSlot { get; set; }

    [Column("delivery_priority")]
    public int? DeliveryPriority { get; set; } = 5; // 1-10, 10 cao nhất

    // Không có FK mới cần navigation
}