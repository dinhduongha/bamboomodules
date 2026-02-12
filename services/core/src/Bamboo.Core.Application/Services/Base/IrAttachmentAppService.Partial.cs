using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class IrAttachmentAppService
    {

        protected async Task<IrAttachment> BuildZipFromAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: _build_zip_from_attachments) ---
            */
            return default;
        }

        protected async Task<IrAttachment> BusChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: ir_attachment.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        protected async Task<IrAttachment> CanBypassRightsOnMediaDialogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _can_bypass_rights_on_media_dialog) ---
            --- METHOD SOURCE (MODULE: web_unsplash, FILE: ir_attachment.py, METHOD: _can_bypass_rights_on_media_dialog) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: ir_attachment.py, METHOD: _can_bypass_rights_on_media_dialog) ---
            */
            return default;
        }

        protected async Task<IrAttachment> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<IrAttachment> CheckAccessInternalAsync(object operation)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _check_access) ---
            */
            return default;
        }

        protected async Task<IrAttachment> CheckContentsInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _check_contents) ---
            */
            return default;
        }

        protected async Task<IrAttachment> CheckServingAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _check_serving_attachments) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeChecksumInternalAsync(object bin_data)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_checksum) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeDatasInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_datas) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeHasThumbnailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _compute_has_thumbnail) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeImageSizeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _compute_image_size) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeImageSrcInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _compute_image_src) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeLocalUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _compute_local_url) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeMimetypeInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_mimetype) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeRawInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_raw) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeResNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _compute_res_name) ---
            */
            return default;
        }

        protected async Task<IrAttachment> CronMigrateLocalToCloudStorageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: ir_attachment.py, METHOD: _cron_migrate_local_to_cloud_storage) ---
            */
            return default;
        }

        protected async Task<IrAttachment> DeleteAndNotifyInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _delete_and_notify) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ExceptAuditTrailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: _except_audit_trail) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> FileDeleteInternalAsync(object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _file_delete) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> FileReadInternalAsync(object fname, object size)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _file_read) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> FileWriteInternalAsync(object bin_value, object checksum)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _file_write) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> FilestoreInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _filestore) ---
            */
            return default;
        }

        protected async Task<IrAttachment> FromRequestFileInternalAsync(object file)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _from_request_file) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> FullPathInternalAsync(object path)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _full_path) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GcDocIndexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: api_doc, FILE: ir_attachment.py, METHOD: _gc_doc_index) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GcFileStoreInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _gc_file_store) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GcFileStoreUnsafeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _gc_file_store_unsafe) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _generate_access_token) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageAzureSasUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_azure_sas_url) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageAzureUrlInternalAsync(object blob_name)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_azure_url) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageBlobNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_blob_name) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageDownloadInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_download_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_download_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_download_info) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageGoogleSignedUrlInternalAsync(object bucket_name, object blob_name)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_google_signed_url) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageGoogleUrlInternalAsync(object blob_name)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_google_url) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageUploadInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_upload_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_upload_info) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_upload_info) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_url) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_url) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _generate_cloud_storage_url) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetCloudStorageAzureInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py, METHOD: _get_cloud_storage_azure_info) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetCloudStorageGoogleInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py, METHOD: _get_cloud_storage_google_info) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetCloudStorageUnsupportedModelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _get_cloud_storage_unsupported_models) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetDatasRelatedValuesInternalAsync(object data, object mimetype)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_datas_related_values) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetMediaInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py, METHOD: _get_media_info) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetOwnershipTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _get_ownership_token) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> GetPathInternalAsync(object bin_data, object sha)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_path) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetRawAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_raw_access_token) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> GetServeAttachmentInternalAsync(object url, object extra_domain, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_attachment.py, METHOD: _get_serve_attachment) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_serve_attachment) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> GetStorageDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _get_storage_domain) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetStoreOwnershipFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _get_store_ownership_fields) ---
            */
            return default;
        }

        protected async Task<IrAttachment> GetThumbnailTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _get_thumbnail_token) ---
            */
            return default;
        }

        protected async Task<IrAttachment> HasAttachmentsOwnershipInternalAsync(object attachment_tokens)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _has_attachments_ownership) ---
            */
            return default;
        }

        protected async Task<IrAttachment> InaccessibleComodelRecordsInternalAsync(List<Guid> model_and_ids, string operation)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _inaccessible_comodel_records) ---
            */
            return default;
        }

        protected async Task<IrAttachment> IndexDocxInternalAsync(object bin_data)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_docx) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> IndexInternalAsync(object bin_data, string file_type, object checksum)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _index) ---
            */
            return default;
        }

        protected async Task<IrAttachment> IndexOpendocInternalAsync(object bin_data)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_opendoc) ---
            */
            return default;
        }

        protected async Task<IrAttachment> IndexPdfInternalAsync(object bin_data)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_pdf) ---
            */
            return default;
        }

        protected async Task<IrAttachment> IndexPptxInternalAsync(object bin_data)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_pptx) ---
            */
            return default;
        }

        protected async Task<IrAttachment> IndexXlsxInternalAsync(object bin_data)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: _index_xlsx) ---
            */
            return default;
        }

        protected async Task<IrAttachment> InverseDatasInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _inverse_datas) ---
            */
            return default;
        }

        protected async Task<IrAttachment> InverseRawInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _inverse_raw) ---
            */
            return default;
        }

        protected async Task<IrAttachment> IsRemoteSourceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _is_remote_source) ---
            */
            return default;
        }

        protected async Task<IrAttachment> MarkForGcInternalAsync(object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _mark_for_gc) ---
            */
            return default;
        }

        protected async Task<IrAttachment> MigrateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _migrate) ---
            */
            return default;
        }

        protected async Task<IrAttachment> MigrateLocalToCloudStorageInternalAsync(object session)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: ir_attachment.py, METHOD: _migrate_local_to_cloud_storage) ---
            */
            return default;
        }

        protected async Task<IrAttachment> MigrateRemoteToLocalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _migrate_remote_to_local) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _migrate_remote_to_local) ---
            */
            return default;
        }

        protected async Task<IrAttachment> PostAddCreateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _post_add_create) ---
            */
            return default;
        }

        protected async Task<IrAttachment> PostprocessContentsInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _postprocess_contents) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> SameContentInternalAsync(object bin_data, object filepath)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _same_content) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<IrAttachment> SetAttachmentDataInternalAsync(object asbytes)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _set_attachment_data) ---
            */
            return default;
        }

        protected async Task<IrAttachment> SetVoiceMetadataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _set_voice_metadata) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrAttachment> StorageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _storage) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ToHttpStreamInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py, METHOD: _to_http_stream) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: _to_http_stream) ---
            */
            return default;
        }

        protected async Task<IrAttachment> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<IrAttachment> UnlinkExceptGovernmentDocumentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: ir_attachment.py, METHOD: _unlink_except_government_document) ---
            */
            return default;
        }
    }
}