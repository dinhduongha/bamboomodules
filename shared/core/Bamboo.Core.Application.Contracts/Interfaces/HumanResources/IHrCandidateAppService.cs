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
    public interface IHrCandidateAppService : IGenericAppService<HrCandidate>
    {
        Task<HrCandidate> CreateApplicationAsync(Guid[] ids);
        Task<HrCandidate> CreateEmployeeFromCandidateAsync(Guid[] ids);
        Task<HrCandidate> CreateMeetingAsync(Guid[] ids);
        Task<HrCandidate> InitAsync(Guid[] ids);
        Task<HrCandidate> OpenApplicationsAsync(Guid[] ids);
        Task<HrCandidate> OpenAttachmentsAsync(Guid[] ids);
        Task<HrCandidate> OpenEmployeeAsync(Guid[] ids);
        Task<HrCandidate> OpenSimilarCandidatesAsync(Guid[] ids);
        Task<HrCandidate> SendEmailAsync(Guid[] ids);
    }
}