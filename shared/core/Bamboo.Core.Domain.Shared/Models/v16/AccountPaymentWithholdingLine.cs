using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Entities;
namespace Bamboo.Core.Models
{
    [Module("l10n_account_withholding_tax", Depends = new[] { "account" })]
    [Model("account.payment.withholding.line", IsTransient = false)]
    [Table("account_payment_withholding_line")]
    public partial class AccountPaymentWithholdingLine : FullAuditedEntity<Guid>, IAccountWithholdingLineable
    {
        
        //<editor-fold desc="ABP ENTITY PROPERTIES">
        [Key]
        public override Guid Id { get => base.Id; protected set => base.Id = value; }
        
        [Column("create_date")]
        public override DateTime CreationTime { get => base.CreationTime; protected set => base.CreationTime = value; }
        
        [Column("create_uid")]
        public override Guid? CreatorId { get => base.CreatorId; protected set => base.CreatorId = value; }
        
        [Column("write_date")]
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
        
        [Column("write_uid")]
        public override Guid? LastModifierId { get => base.LastModifierId; set => base.LastModifierId = value; }
        
        [ForeignKey(nameof(CreatorId))]
        public virtual ResUsers? Creator { get; protected set; }
        
        [ForeignKey(nameof(LastModifierId))]
        public virtual ResUsers? LastModifier { get; protected set; }
        //</editor-fold>
        
        [Column("payment_id")] public Guid? PaymentId { get; set; }
        [Many2one(RelatedModel = "account.payment")]
        [ForeignKey(nameof(PaymentId))]
        public virtual AccountPayment? Payment { get; set; }
    }
}