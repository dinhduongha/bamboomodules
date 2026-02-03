using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsVMIProposal(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsVMIProposal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_vmi_proposal_pkey");

            entity.ToTable("dms_vmi_proposal");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProposedQty).HasColumnName("proposed_qty");
            entity.Property(e => e.BasedOnSalesHistory);
            entity.Property(e => e.SeasonFactor).HasColumnName("season_factor");
            entity.Property(e => e.ApprovalStatus).HasColumnName("approval_status");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Partner)
                .WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_vmi_proposal_res_partner_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}