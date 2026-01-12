using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IHrCandidateAppService : IGenericApplicationService<HrCandidate>
    {
        Task<HrCandidate> CreateApplicationAsync(Guid id);
        Task<HrCandidate> CreateEmployeeFromCandidateAsync(Guid id);
        Task<HrCandidate> CreateMeetingAsync(Guid id);
        Task<HrCandidate> InitAsync(Guid id);
        Task<HrCandidate> OpenApplicationsAsync(Guid id);
        Task<HrCandidate> OpenAttachmentsAsync(Guid id);
        Task<HrCandidate> OpenEmployeeAsync(Guid id);
        Task<HrCandidate> OpenSimilarCandidatesAsync(Guid id);
        Task<HrCandidate> SendEmailAsync(Guid id);
    }
}