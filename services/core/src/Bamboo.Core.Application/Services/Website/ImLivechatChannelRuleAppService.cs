using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("ImLivechat", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public class ImLivechatChannelRuleAppService : GenericApplicationService<ImLivechatChannelRule>, IImLivechatChannelRuleAppService
    {

        public ImLivechatChannelRuleAppService(IRepository<ImLivechatChannelRule, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ImLivechatChannelRule> MatchRuleAsync(Guid id, ImLivechatChannelRuleMatchRuleRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def match_rule(self, channel_id, url, country_id=False):
            // """ determine if a rule of the given channel matches with the given url
            //     :param channel_id : the identifier of the channel_id
            //     :param url : the url to match with a rule
            //     :param country_id : the identifier of the country
            //     :returns the rule that matches the given condition. False otherwise.
            //     :rtype : im_livechat.channel.rule
            // """
            // def _match(rules):
            //     for rule in rules:
            //         # url might not be set because it comes from referer, in that
            //         # case match the first rule with no regex_url
            //         if not re.search(rule.regex_url or "", url or ""):
            //             continue
            //         if rule.chatbot_script_id and (
            //             not rule.chatbot_script_id.active or not rule.chatbot_script_id.script_step_ids
            //         ):
            //             continue
            //         if rule.chatbot_only_if_no_operator and rule.channel_id.available_operator_ids:
            //             continue
            //         return rule
            //     return False
            // # first, search the country specific rules (the first match is returned)
            // if country_id: # don't include the country in the research if geoIP is not installed
            //     domain = [('country_ids', 'in', [country_id]), ('channel_id', '=', channel_id)]
            //     rule = _match(self.search(domain))
            //     if rule:
            //         return rule
            // # second, fallback on the rules without country
            // domain = [('country_ids', '=', False), ('channel_id', '=', channel_id)]
            // return _match(self.search(domain))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}