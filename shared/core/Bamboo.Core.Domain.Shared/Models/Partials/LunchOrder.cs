using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("lunch_order")]
//[Index("State", Name = "lunch_order_state_index")]
//[Index("SupplierId", Name = "lunch_order_supplier_id_index")]
//[Index("UserId", "ProductId", "Date", Name = "lunch_order_user_product_date")]
public partial class LunchOrder
{
    // v16-Compat
    //[Column("name", TypeName = "jsonb")]
    //public string? Name { get; set; }

}
