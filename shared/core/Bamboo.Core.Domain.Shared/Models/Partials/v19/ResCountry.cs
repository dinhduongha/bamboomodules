using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ResCountry
{
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrAttendanceOvertimeRuleset) is commented out
    // public virtual ICollection<HrAttendanceOvertimeRuleset> HrAttendanceOvertimeRuleset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrDepartureReason) is commented out
    // public virtual ICollection<HrDepartureReason> HrDepartureReason { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryOfBirth")]
    // [NotMapped] // One2many 
    // [InverseProperty("CountryOfBirthNavigation")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrLeaveType) is commented out
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrVersion) is commented out
    // public virtual ICollection<HrVersion> HrVersionCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("PrivateCountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PrivateCountry")] // One2many // Peer relationship (HrVersion) is commented out
    // public virtual ICollection<HrVersion> HrVersionPrivateCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (L10nLatamDocumentType) is commented out
    // public virtual ICollection<L10nLatamDocumentType> L10nLatamDocumentType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (L10nLatamIdentificationType) is commented out
    // public virtual ICollection<L10nLatamIdentificationType> L10nLatamIdentificationType { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (SmsTwilioNumber) is commented out
    // public virtual ICollection<SmsTwilioNumber> SmsTwilioNumber { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

}