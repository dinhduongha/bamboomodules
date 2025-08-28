using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_resume_line")]
public partial class HrResumeLine
{
    // v16-Compat    
    //[Column("name")]
    //public string? Name { get; set; }

    // v16-Compat
    //[Column("description")]
    //public string? Description { get; set; }

}
