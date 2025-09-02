using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IForumPostAppService : IGenericApplicationService<ForumPost>
    {
        Task<ForumPost> CloseAsync(Guid id, ForumPostCloseRequestDto input);
        Task<ForumPost> ConvertAnswerToCommentAsync(Guid id);
        Task<ForumPost> ConvertCommentToAnswerAsync(Guid id, ForumPostConvertCommentToAnswerRequestDto input);
        Task<ForumPost> GoToWebsiteAsync(Guid id);
        Task<ForumPost> MarkAsOffensiveBatchAsync(Guid id, ForumPostMarkAsOffensiveBatchRequestDto input);
        Task<ForumPost> MessagePostAsync(Guid id);
        Task<ForumPost> ReopenAsync(Guid id);
        Task<ForumPost> UnlinkCommentAsync(Guid id, ForumPostUnlinkCommentRequestDto input);
        Task<ForumPost> ValidateAsync(Guid id);
        Task<ForumPost> VoteAsync(Guid id, ForumPostVoteRequestDto input);
    }
}