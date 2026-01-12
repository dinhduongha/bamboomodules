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
    public class EventQuestionAppService : GenericApplicationService<EventQuestion>, IEventQuestionAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public EventQuestionAppService(IRepository<EventQuestion, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<EventQuestion> ConstrainsEventInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_question.py) ---
            // def _constrains_event(self):
            // if any(question.event_type_id and question.event_id for question in self):
            //     raise UserError(_("Question cannot be linked to both an Event and an Event Type."))
            */
            return default;
        }

        protected async Task<EventQuestion> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_question.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('event_id', 'in', [event['id'] for event in data['event.event']['data']])]
            */
            return default;
        }

        protected async Task<EventQuestion> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_question.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['title', 'question_type', 'event_type_id', 'event_id', 'sequence', 'once_per_order', 'is_mandatory_answer', 'answer_ids']
            */
            return default;
        }

        protected async Task<EventQuestion> UnlinkExceptAnsweredQuestionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_question.py) ---
            // def _unlink_except_answered_question(self):
            // if self.env['event.registration.answer'].search_count([('question_id', 'in', self.ids)]):
            //     raise UserError(_('You cannot delete a question that has already been answered by attendees.'))
            */
            return default;
        }

        public async Task<EventQuestion> ViewQuestionAnswersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_question.py) ---
            // def action_view_question_answers(self):
            // """ Allow analyzing the attendees answers to event questions in a convenient way:
            // - A graph view showing counts of each suggestions for simple_choice questions
            //   (Along with secondary pivot and list views)
            // - A list view showing textual answers values for text_box questions. """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("event.action_event_registration_report")
            // action['domain'] = [('question_id', '=', self.id)]
            // if self.question_type == 'simple_choice':
            //     action['views'] = [(False, 'graph'), (False, 'pivot'), (False, 'list')]
            // elif self.question_type == 'text_box':
            //     action['views'] = [(False, 'list')]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}