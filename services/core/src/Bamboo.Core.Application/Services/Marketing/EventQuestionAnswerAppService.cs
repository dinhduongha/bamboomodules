using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Event", Category = "Marketing", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public partial class EventQuestionAnswerAppService : GenericApplicationService<EventQuestionAnswer>, IEventQuestionAnswerAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public EventQuestionAnswerAppService(IRepository<EventQuestionAnswer, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<EventQuestionAnswer> AddRuleButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_question_answer.py) ---
            // def action_add_rule_button(self):
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('event_crm.event_lead_rule_answer_action')
            // action['context'] = {
            //     'default_name': self.name,
            //     'default_lead_user_id': self.env.user.id,
            //     'default_event_registration_filter': [
            //         '&',
            //         ('registration_answer_ids.question_id', 'in', self.question_id.ids),
            //         ('registration_answer_choice_ids.value_answer_id', 'in', self.ids)
            //     ]
            // }
            // action['target'] = 'new'
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventQuestionAnswer> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_question_answer.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('question_id', 'in', [quest['id'] for quest in data['event.question']])]
            */
            return default;
        }

        protected async Task<EventQuestionAnswer> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_question_answer.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['question_id', 'name', 'sequence']
            */
            return default;
        }

        protected async Task<EventQuestionAnswer> UnlinkExceptSelectedAnswerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_question_answer.py) ---
            // def _unlink_except_selected_answer(self):
            // if self.env['event.registration.answer'].search_count([('value_answer_id', 'in', self.ids)]):
            //     raise UserError(_('You cannot delete an answer that has already been selected by attendees.'))
            */
            return default;
        }
    }
}