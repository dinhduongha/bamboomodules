using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailComposerMixinAppService : ApplicationService, IMailComposerMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MailComposerMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ComputeBodyHasTemplateValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_body_has_template_value(self):
            // """ Computes if the current body is the same as the one from template.
            // Both real and sanitized values are considered, to avoid editor issues
            // as much as possible. """
            // for composer_mixin in self:
            //     if not tools.is_html_empty(composer_mixin.body) and composer_mixin.template_id:
            //         template_value = composer_mixin.template_id.body_html
            //         # matching email_outgoing sanitize level
            //         sanitize_vals = {
            //             'output_method': 'xml',
            //             'sanitize_attributes': False,
            //             'sanitize_conditional_comments': False,
            //             'sanitize_form': True,
            //             'sanitize_style': True,
            //             'sanitize_tags': False,
            //             'silent': True,
            //             'strip_classes': False,
            //             'strip_style': False,
            //         }
            //         sanitized_template_value = tools.html_sanitize(template_value, **sanitize_vals)
            //         composer_mixin.body_has_template_value = composer_mixin.body in (template_value,
            //             sanitized_template_value)
            //     else:
            //         composer_mixin.body_has_template_value = False
            */
            return default;
        }

        public async Task<TEntity> ComputeBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_body(self):
            // """ Computation is coming either from template, either reset. When
            // having a template with a value set, copy it. When removing the
            // template, reset it. """
            // for composer_mixin in self:
            //     if not tools.is_html_empty(composer_mixin.template_id.body_html):
            //         composer_mixin.body = composer_mixin.template_id.body_html
            //     elif not composer_mixin.template_id:
            //         composer_mixin.body = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCanEditBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_can_edit_body(self):
            // for record in self:
            //     record.can_edit_body = (
            //         record.is_mail_template_editor
            //         or not record.template_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMailTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_is_mail_template_editor(self):
            // is_mail_template_editor = self.env.is_admin() or self.env.user.has_group('mail.group_mail_template_editor')
            // for record in self:
            //     record.is_mail_template_editor = is_mail_template_editor
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_lang(self):
            // """ Computation is coming either from template, either reset. When
            // having a template with a value set, copy it. When removing the
            // template, reset it. """
            // for composer_mixin in self:
            //     if composer_mixin.template_id.lang:
            //         composer_mixin.lang = composer_mixin.template_id.lang
            //     elif not composer_mixin.template_id:
            //         composer_mixin.lang = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _compute_subject(self):
            // """ Computation is coming either from template, either reset. When
            // having a template with a value set, copy it. When removing the
            // template, reset it. """
            // for composer_mixin in self:
            //     if composer_mixin.template_id.subject:
            //         composer_mixin.subject = composer_mixin.template_id.subject
            //     elif not composer_mixin.template_id:
            //         composer_mixin.subject = False
            */
            return default;
        }

        public async Task<TEntity> RenderFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _render_field(self, field, *args, **kwargs):
            // """ Render the given field on the given records. This method enters
            // sudo mode to allow qweb rendering (which is otherwise reserved for
            // the 'mail template editor' group') if we consider it safe. Safe
            // means content comes from the template which is a validated master
            // data. As a summary the heuristic is :
            // 
            //   * if no template, do not bypass the check;
            //   * if current user is a template editor, do not bypass the check;
            //   * if record value and template value are the same (or equals the
            //     sanitized value in case of an HTML field), bypass the check;
            //   * for body: if current user cannot edit it, force template value back
            //     then bypass the check;
            // 
            // Also provide support to fetch translations on the remote template.
            // Indeed translations are often done on the master template, not on the
            // specific composer itself. In that case we need to work on template
            // value when it has not been modified in the composer. """
            // if field not in self:
            //     raise ValueError(
            //         _('Rendering of %(field_name)s is not possible as not defined on template.',
            //           field_name=field
            //          )
            //     )
            // 
            // if not self.template_id:
            //     # Do not need to bypass the verification
            //     return super()._render_field(field, *args, **kwargs)
            // 
            // # template-based access check + translation check
            // template_field = {
            //     'body': 'body_html',
            // }.get(field, field)
            // if template_field not in self.template_id:
            //     raise ValueError(
            //         _('Rendering of %(field_name)s is not possible as no counterpart on template.',
            //           field_name=field
            //          )
            //     )
            // 
            // composer_value = self[field]
            // template_value = self.template_id[template_field]
            // translation_asked = kwargs.get('compute_lang') or kwargs.get('set_lang')
            // equality = self.body_has_template_value if field == 'body' else composer_value == template_value
            // 
            // call_sudo = False
            // if (not self.is_mail_template_editor and field == 'body' and
            //     (not self.can_edit_body or self.body_has_template_value)):
            //     call_sudo = True
            //     # take the previous body which we can trust without HTML editor reformatting
            //     self.body = self.template_id.body_html
            // if (not self.is_mail_template_editor and field != 'body' and
            //       composer_value == template_value):
            //     call_sudo = True
            // 
            // if translation_asked and equality:
            //     template = self.template_id.sudo() if call_sudo else self.template_id
            //     return template._render_field(
            //         template_field, *args, **kwargs,
            //     )
            // 
            // record = self.sudo() if call_sudo else self
            // return super(MailComposerMixin, record)._render_field(field, *args, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> RenderLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py) ---
            // def _render_lang(self, *args, **kwargs):
            // """ Given some record ids, return the lang for each record based on
            // lang field of template or through specific context-based key.
            // This method enters sudo mode to allow qweb rendering (which
            // is otherwise reserved for the 'mail template editor' group')
            // if we consider it safe. Safe means content comes from the template
            // which is a validated master data. As a summary the heuristic is :
            // 
            //   * if no template, do not bypass the check;
            //   * if record lang and template lang are the same, bypass the check;
            // """
            // 
            // if not self.template_id:
            //     # Do not need to bypass the verification
            //     return super()._render_lang(*args, **kwargs)
            // 
            // composer_value = self.lang
            // template_value = self.template_id.lang
            // 
            // call_sudo = False
            // if (not self.is_mail_template_editor and composer_value == template_value):
            //     call_sudo = True
            // 
            // record = self.sudo() if call_sudo else self
            // return super(MailComposerMixin, record)._render_lang(*args, **kwargs)
            */
            return default;
        }
    }
}