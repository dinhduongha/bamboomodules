using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("rating", Category = "Productivity", Depends = new[] { "mail" })]
    public partial class RatingMixinAppService : ApplicationService, IRatingMixinAppService
    {

        public RatingMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: action_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_subtask) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_create_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: action_create_product_variants_from_gelato_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_dependent_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_product_lot) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_quants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_routes_diagram) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_product_tmpl_forecast_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_blocking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_subtasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_view_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_redirect_to_project_task_form) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: action_sync_gelato_template_info) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_undo_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: action_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object guest, object post_leave_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _action_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_unlink_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_used_in_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_mos) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_orderpoints) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: action_view_po) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_related_putaway_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: action_view_sales) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_stock_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_storage_category_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> AddArchivedCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _add_archived_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> guest_ids, object invite_to_rtc_call, object post_joined_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: add_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _add_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddNewMembersToChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object create_member_params, object inviting_partner, object users, object partners) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _add_new_members_to_channel) ---
            */
            return default;
        }

        public async Task<TEntity> AddNextStepMessageToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script_step) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _add_next_step_message_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> AllowInviteByEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _allow_invite_by_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _allow_publish_rating_stats) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _allow_publish_rating_stats) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _apply_taxes_to_price) ---
            */
            return default;
        }

        public async Task<TEntity> AttachmentToHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _attachment_to_html) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _auto_init) ---
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> BroadcastInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _broadcast) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: button_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _can_be_added_to_cart) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelChangeDescriptionAsync<TEntity>(IEnumerable<TEntity> entities, object description) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_change_description) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelFetchedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_fetched) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_join) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelPinAsync<TEntity>(IEnumerable<TEntity> entities, object pinned) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_pin) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: channel_pin) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelRenameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_rename) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelSetCustomNameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_set_custom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ChatbotFindCustomerValuesInMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object step_type_to_field) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_find_customer_values_in_messages) ---
            */
            return default;
        }

        public async Task<TEntity> ChatbotPostMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script, object body) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_post_message) ---
            */
            return default;
        }

        public async Task<TEntity> ChatbotRestartInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_restart) ---
            */
            return default;
        }

        public async Task<TEntity> ChatbotValidateEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address, object chatbot_script) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_validate_email) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanUpdateMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _check_can_update_message_content) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _check_combo_inclusions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _check_print_images_are_set_before_publishing) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _check_project_and_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_sale_product_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceTrackingForEventBoothsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _check_service_tracking_for_event_booths) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _check_uom_not_in_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_vendor_for_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CleanEmptyMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _clean_empty_message) ---
            */
            return default;
        }

        public async Task<TEntity> CloseLivechatSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _close_livechat_session) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_attachment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_can_be_expensed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelNameMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_name_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_cost_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_current_user_same_company_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_depend_on_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_dependent_tasks_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_follow_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_in_project) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_parent_task_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_elapsed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_missing_images) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGroupPublicIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_group_public_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_has_available_route_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasCrmLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: _compute_has_crm_lead) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitationUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invitation_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitedMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invited_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_invoice_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: compute_is_storable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_link_preview_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_history_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentProvidingHelpHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_providing_help_history) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatAgentRequestingHelpHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_requesting_help_history) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatBotHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_bot_history_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatBotPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_bot_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatCustomerGuestIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_customer_guest_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatCustomerHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_customer_history_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatCustomerPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_customer_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatIsEscalatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_is_escalated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatMatchesSelfExpertiseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_matches_self_expertise) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatMatchesSelfLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_matches_self_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatOutcomeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_outcome) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatStartHourInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_start_hour) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatWeekDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_week_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_lot_valuated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_member_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_message_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_mrp_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_reordering_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_next_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_publish_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchase_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchased_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingAvgTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_avg_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingLastValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_last_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingSatisfactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_satisfaction) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_stats) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_recurring_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_repeat) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_sales_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfMemberIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_self_member_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _compute_self_order_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_type) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_service_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_service_upsell_threshold_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyUpdateButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_update_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_allocated_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_task_template) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_used_in_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVariantsDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_variants_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintFromMessageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_from_message_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintGroupIdChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_group_id_channel) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintParentChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_parent_channel_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintPartnersChatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_partners_chat) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintSubscriptionDepartmentIdsChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py, METHOD: _constraint_subscription_department_ids_channel) ---
            */
            return default;
        }

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _construct_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertVisitorToLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object key) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: _convert_visitor_to_lead) ---
            --- METHOD SOURCE (MODULE: website_crm_livechat, FILE: discuss_channel.py, METHOD: _convert_visitor_to_lead) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsForPostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list, object extra_list) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_attachments_for_post) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid group_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_channel) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object default_display_mode, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_group) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_print_images_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantFromPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attribute_value_ids, Guid config_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: create_product_variant_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid from_message_id, object name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_sub_channel) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _create_task_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: default_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPosSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _default_pos_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultResponsibleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _default_responsible_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EmailLivechatTranscriptInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _email_livechat_transcript) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_company_consistency_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureFieldsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_fields_write) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_super_task_is_not_private) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureUnusedInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _ensure_unused_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_help) ---
            --- METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py, METHOD: execute_command_help) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpMessageExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _execute_command_help_message_extra) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHistoryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: execute_command_history) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandLeadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: execute_command_lead) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandLeaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_leave) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandWhoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_who) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_priority) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_tags_and_users) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> FindInternalUsersFromAddressMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, Guid project_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _find_internal_users_from_address_mail) ---
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateMemberForSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_member_for_self) ---
            */
            return default;
        }

        public async Task<TEntity> FindOrCreatePersonaForChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object guest_name, object timezone, object country_code, object create_member_params, object post_joined_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_persona_for_channel) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_purchase_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_sale_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForwardHumanOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script_step, object users) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _forward_human_operator) ---
            */
            return default;
        }

        public async Task<TEntity> GcBotOnlyOngoingSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _gc_bot_only_ongoing_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> GcEmptyLivechatSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _gc_empty_livechat_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_avatar) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateRandomTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_random_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_action_view_related_putaway_rules) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object uom, object date, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_all_subtasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_allowed_access_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedChannelMemberCreateParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_allowed_channel_member_create_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessageParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_partner_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_alternative_product_filter) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: product.py, METHOD: _get_asset_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_attachments_search_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeValueDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_value_dict) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_attribute_value_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetCallNotificationTagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_call_notification_tag) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_cannot_start_with_patterns) ---
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        public async Task<TEntity> GetChannelHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_channel_history) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetChannelsAsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_channels_as_member) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, Guid uom_id, object only_template) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_combination_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_configurator_display_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_configurator_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_partner_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_personal_stage_create_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_google_analytics_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_group_pattern) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups_patterns) ---
            */
            return default;
        }

        public async Task<TEntity> GetHumanOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users, object chatbot_script_step) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_human_operator) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_image_holder) ---
            */
            return default;
        }

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_images) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_last_messages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_list_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetLivechatSessionFieldsToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_livechat_session_fields_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetNotifyValidParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_notify_valid_parameters) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_onchange_service_policy_updates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrCreateChatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object pin) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_or_create_chat) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_possible_variants_sorted) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreviewedAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object product_query_params) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_previewed_attribute_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductInfoPosAsync<TEntity>(IEnumerable<TEntity> entities, object price, object quantity, Guid pos_config_id, Guid product_variant_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: get_product_info_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object query_params, object grouped_attributes_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_recurrence_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetRibbonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_vals, object auto_assign_ribbons, object variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_ribbon) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_sales_prices) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMessageUpdateExtraFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_store_message_update_extra_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtask_ids_per_task_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtasks_recursively) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_suitable_image_size) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py, METHOD: _get_template_matrix) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_thread_with_access) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_versioned_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetVisitorHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object visitor) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: _get_visitor_history) ---
            */
            return default;
        }

        public async Task<TEntity> GetVisitorLeaveMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object cancel) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_visitor_leave_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_accessory_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_alternative_product) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_is_custom_values) ---
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_no_variant_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _init_column) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> InverseChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _inverse_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _inverse_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> InverseParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InverseQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> InverseSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _inverse_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> InviteByEmailAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: invite_by_email) ---
            */
            return default;
        }

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _is_add_to_cart_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: is_blocked_by_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _is_in_wishlist) ---
            */
            return default;
        }

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _is_recurrence_valid) ---
            */
            return default;
        }

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _is_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> LazyLoadMembersChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _lazy_load_members_channel_types) ---
            */
            return default;
        }

        public async Task<TEntity> LivechatJoinChannelNeedingHelpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: livechat_join_channel_needing_help) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: product_template.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataSearchReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadProductFromPosAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: load_product_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> LoadProductWithDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object load_archived, object offset, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_product_with_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MemberBasedNamingChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _member_based_naming_channel_types) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_post_after_hook) ---
            #endif
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MessageReceiveBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object partner) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_receive_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids, List<Guid> customer_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_update) ---
            */
            return default;
        }

        protected async Task<object> MessageUpdateContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_update_content) ---
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: name_search) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_get_headers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByWebPushPreparePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object force_record_name) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_by_web_push_prepare_payload) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByWebPushInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread_by_web_push) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread) ---
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: OPEN_STATES) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _on_change_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _onchange_buy_route) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_sale_ok) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_fields) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _onchange_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _onchange_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_task_company) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _onchange_type_event_booth) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _onchange_type_event) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> PlanTaskInCalendarAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: plan_task_in_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _populate_missing_personal_stages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PortalAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_accessible_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_get_parent_hash_token) ---
            */
            return default;
        }

        public async Task<TEntity> PostCurrentChatbotStepMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object chatbot_script_step) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _post_current_chatbot_step_message) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _prepare_pattern_groups) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosSelfUiProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _process_pos_self_ui_products) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosUiProductProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, Guid config_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _process_pos_ui_product_product) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: project_sharing_toggle_is_follower) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: rating_apply) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_apply_get_default_subtype_id) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_domain) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _rating_domain) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetGradesAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: rating_get_grades) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_operator) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _rating_get_parent_field_name) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_parent_field_name) ---
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_partner) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetRepartitionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object add_stats, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_get_repartition) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetStatsAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: rating_get_stats) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetStatsPerRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_get_stats_per_record) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_personal_stage_type_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ResolveCopiedDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _resolve_copied_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> RtcCancelInvitationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> member_ids) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _rtc_cancel_invitations) ---
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SearchChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_channel_partner_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_incoming_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatAgentHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_agent_history_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatBotHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_bot_history_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatCustomerHistoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_customer_history_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatMatchesSelfExpertiseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_matches_self_expertise) ---
            */
            return default;
        }

        public async Task<TEntity> SearchLivechatMatchesSelfLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_matches_self_lang) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_on_comodel) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_outgoing_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRatingAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _search_rating_avg) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results_prices) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SearchValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _search_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_virtual_available) ---
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _selection_service_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _selection_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_email_notify_to_cc) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_task_rating_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: event_product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_id) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> SetMessagePinAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id, object pinned) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: set_message_pin) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_bottom) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_down) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_top) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_up) ---
            */
            return default;
        }

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _set_stage_on_project_from_task) ---
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldInviteMembersToJoinCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: discuss_channel.py, METHOD: _should_invite_members_to_join_call) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _should_invite_members_to_join_call) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldOpenProductQuantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _should_open_product_quants) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _should_open_product_quants) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: stage_find) ---
            */
            return default;
        }

        public async Task<TEntity> StoreLivechatOperatorIdFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _store_livechat_operator_id_fields) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyGetMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically_get_members) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically_get_members) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically) ---
            */
            return default;
        }

        public async Task<TEntity> SyncFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _sync_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_WRITABLE_FIELDS) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _task_message_auto_subscribe_notify) ---
            */
            return default;
        }

        public async Task<TEntity> ToMarkupDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _to_markup_data) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _to_store) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingSeenInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _types_allowing_seen_infos) ---
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _types_allowing_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptAllEmployeeChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _unlink_except_all_employee_channel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_template.py, METHOD: _unlink_except_loyalty_products) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _unlink_except_open_session) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _unsubscribe_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: update_date_end) ---
            */
            return default;
        }

        protected async Task<object> UpdateForwardedChannelDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _update_forwarded_channel_data) ---
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _website_show_quick_add) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IRatingMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: write) ---
            */
            return default;
        }
    }
}