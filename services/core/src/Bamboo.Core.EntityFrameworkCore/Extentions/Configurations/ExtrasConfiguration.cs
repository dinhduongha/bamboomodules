using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ApplyExtrasConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureIrModelFieldAccess();
            modelBuilder.ConfigureMrpWorkcenterCategory();
            modelBuilder.ConfigureMrpWorkcenterExtra();
            modelBuilder.ConfigureResCurrencyExtra();
        }

    }

}
