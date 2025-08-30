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

//[Table("product_fetch_image_wizard")]
public partial class ProductFetchImageWizard
{
    //[Column("nb_products_selected")]
    //public long? NbProductsSelected { get; set; }

    //[Column("nb_products_to_process")]
    //public long? NbProductsToProcess { get; set; }

    //[Column("nb_products_unable_to_process")]
    //public long? NbProductsUnableToProcess { get; set; }
}
