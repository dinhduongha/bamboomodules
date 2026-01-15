using System;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public partial class CoreDbContext
{
    public virtual DbSet<MrpWorkcenterCategory> MrpWorkcenterCategories { get; set; }
    public virtual DbSet<IrModelFieldAccess> IrModelFieldAccesses { get; set; }

}