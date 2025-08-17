using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("ImLivechat", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public class ChatbotScriptAppService : GenericApplicationService<ChatbotScript>, IChatbotScriptAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        private readonly IUtmSourceMixinAppService _utmSourceMixinAppService;
        public ChatbotScriptAppService(IRepository<ChatbotScript, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IImageMixinAppService imageMixinAppService, IUtmSourceMixinAppService utmSourceMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _imageMixinAppService = imageMixinAppService;
            _utmSourceMixinAppService = utmSourceMixinAppService;
        }

        protected async Task<ChatbotScript> CheckQuestionSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _check_question_selection(self):
            // for step in self.script_step_ids:
            //     if step.step_type == "question_selection" and not step.answer_ids:
            //         raise ValidationError(self.env._("Step of type 'Question' must have answers."))
            */
            return default;
        }

        protected async Task<ChatbotScript> ComputeFirstStepWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _compute_first_step_warning(self):
            // for script in self:
            //     allowed_first_step_types = [
            //         'question_selection',
            //         'question_email',
            //         'question_phone',
            //         'free_input_single',
            //         'free_input_multi',
            //     ]
            //     welcome_steps = script.script_step_ids and script._get_welcome_steps()
            //     if welcome_steps and welcome_steps[-1].step_type == 'forward_operator':
            //         script.first_step_warning = 'first_step_operator'
            //     elif welcome_steps and welcome_steps[-1].step_type not in allowed_first_step_types:
            //         script.first_step_warning = 'first_step_invalid'
            //     else:
            //         script.first_step_warning = False
            */
            return default;
        }

        protected async Task<ChatbotScript> ComputeLeadCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: chatbot_script.py) ---
            // def _compute_lead_count(self):
            // leads_data = self.env['crm.lead'].with_context(active_test=False).sudo()._read_group(
            //     [('source_id', 'in', self.mapped('source_id').ids)], ['source_id'], ['__count'])
            // mapped_leads = {source.id: count for source, count in leads_data}
            // for script in self:
            //     script.lead_count = mapped_leads.get(script.source_id.id, 0)
            */
            return default;
        }

        protected async Task<ChatbotScript> ComputeLivechatChannelCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _compute_livechat_channel_count(self):
            // channels_data = self.env['im_livechat.channel.rule']._read_group(
            //     [('chatbot_script_id', 'in', self.ids)], ['chatbot_script_id'], ['channel_id:count_distinct'])
            // mapped_channels = {chatbot_script.id: count_distinct for chatbot_script, count_distinct in channels_data}
            // for script in self:
            //     script.livechat_channel_count = mapped_channels.get(script.id, 0)
            */
            return default;
        }

        public async Task<ChatbotScript> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, title=self.env._("%s (copy)", script.title)) for script, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ChatbotScript> FormatForFrontendInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _format_for_frontend(self):
            // """ Small utility method that formats the script into a dict usable by the frontend code. """
            // self.ensure_one()
            // 
            // return {
            //     'id': self.id,
            //     'name': self.title,
            //     'partner': {'id': self.operator_partner_id.id, 'type': 'partner', 'name': self.operator_partner_id.name},
            //     'welcomeSteps': [
            //         step._format_for_frontend()
            //         for step in self._get_welcome_steps()
            //     ]
            // }
            */
            return default;
        }

        protected async Task<ChatbotScript> GetChatbotLanguageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _get_chatbot_language(self):
            // return get_lang(
            //     self.env, lang_code=request and request.httprequest.cookies.get("frontend_lang")
            // ).code
            */
            return default;
        }

        protected async Task<ChatbotScript> GetWelcomeStepsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _get_welcome_steps(self):
            // """ Returns a sub-set of script_step_ids that only contains the "welcoming steps".
            // We consider those as all the steps the bot will say before expecting a first answer from
            // the end user.
            // 
            // Example 1:
            // - step 1 (question_selection): What do you want to do? - Create a Lead, -Create a Ticket
            // - step 2 (text): Thank you for visiting our website!
            // -> The welcoming steps will only contain step 1, since directly after that we expect an
            // input from the user
            // 
            // Example 2:
            // - step 1 (text): Hello! I'm a bot!
            // - step 2 (text): I am here to help lost users.
            // - step 3 (question_selection): What do you want to do? - Create a Lead, -Create a Ticket
            // - step 4 (text): Thank you for visiting our website!
            // -> The welcoming steps will contain steps 1, 2 and 3.
            // Meaning the bot will have a small monologue with himself before expecting an input from the
            // end user.
            // 
            // This is important because we need to display those welcoming steps in a special fashion on
            // the frontend, since those are not inserted into the discuss.channel as actual mail.messages,
            // to avoid bloating the channels with bot messages if the end-user never interacts with it. """
            // self.ensure_one()
            // 
            // welcome_steps = self.env['chatbot.script.step']
            // for step in self.script_step_ids:
            //     welcome_steps += step
            //     if step.step_type != 'text':
            //         break
            // 
            // return welcome_steps
            */
            return default;
        }

        protected async Task<ChatbotScript> OnchangeScriptStepIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _onchange_script_step_ids(self):
            // for step in self.script_step_ids:
            //     if step.step_type != "question_selection" and step.answer_ids:
            //         step.answer_ids = [Command.clear()]
            */
            return default;
        }

        protected async Task<ChatbotScript> PostWelcomeStepsInternalAsync(object discuss_channel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _post_welcome_steps(self, discuss_channel):
            // """ Welcome messages are only posted after the visitor's first interaction with the chatbot.
            // See 'chatbot.script#_get_welcome_steps()' for more details.
            // 
            // Side note: it is important to set the 'chatbot_current_step_id' on each iteration so that
            // it's correctly set when going into 'discuss_channel#_message_post_after_hook()'. """
            // 
            // self.ensure_one()
            // posted_messages = self.env['mail.message']
            // 
            // for welcome_step in self._get_welcome_steps():
            //     discuss_channel.chatbot_current_step_id = welcome_step.id
            // 
            //     if not is_html_empty(welcome_step.message):
            //         posted_messages += discuss_channel.with_context(mail_create_nosubscribe=True).message_post(
            //             author_id=self.operator_partner_id.id,
            //             body=plaintext2html(welcome_step.message),
            //             message_type='comment',
            //             subtype_xmlid='mail.mt_comment',
            //         )
            // 
            // return posted_messages
            */
            return default;
        }

        public async Task<ChatbotScript> TestScriptAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: chatbot_script.py) ---
            // def action_test_script(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': '/chatbot/%s/test' % self.id,
            //     'target': 'self',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ChatbotScript> ValidateEmailInternalAsync(object email_address, object discuss_channel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def _validate_email(self, email_address, discuss_channel):
            // email_address = html2plaintext(email_address)
            // email_normalized = email_normalize(email_address)
            // 
            // posted_message = False
            // error_message = False
            // if not email_normalized:
            //     error_message = self.env._(
            //         "'%(input_email)s' does not look like a valid email. Can you please try again?",
            //         input_email=email_address
            //     )
            //     posted_message = discuss_channel._chatbot_post_message(self, plaintext2html(error_message))
            // 
            // return {
            //     'success': bool(email_normalized),
            //     'posted_message': posted_message,
            //     'error_message': error_message,
            // }
            */
            return default;
        }

        public async Task<ChatbotScript> ViewLeadsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: chatbot_script.py) ---
            // def action_view_leads(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('crm.crm_lead_all_leads')
            // action['domain'] = [('source_id', '=', self.source_id.id)]
            // action['context'] = {'create': False}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ChatbotScript> ViewLivechatChannelsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py) ---
            // def action_view_livechat_channels(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.im_livechat_channel_action')
            // action['domain'] = [('rule_ids.chatbot_script_id', 'in', self.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}