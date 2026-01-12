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
    public interface ICardCampaignAppService : IGenericApplicationService<CardCampaign>
    {
        Task<CardCampaign> PreviewAsync(Guid id);
        Task<CardCampaign> ShareAsync(Guid id);
        Task<CardCampaign> ViewCardsAsync(Guid id);
        Task<CardCampaign> ViewCardsClickedAsync(Guid id);
        Task<CardCampaign> ViewCardsSharedAsync(Guid id);
        Task<CardCampaign> ViewMailingsAsync(Guid id);
    }
}