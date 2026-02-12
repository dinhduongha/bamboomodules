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
    [Module("base_geolocalize", Category = "Sales", Depends = new[] { "base_setup" })]
    public partial class BaseGeocoderAppService : ApplicationService, IBaseGeocoderAppService
    {

        public BaseGeocoderAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> CallGooglemapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object addr) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _call_googlemap) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CallOpenstreetmapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object addr) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _call_openstreetmap) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CallOpenstreetmapReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lat, object lon) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _call_openstreetmap_reverse) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoFindAsync<TEntity>(IEnumerable<TEntity> entities, object addr) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: geo_find) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoQueryAddressAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: geo_query_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoQueryAddressDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _geo_query_address_default) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoQueryAddressGooglemapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _geo_query_address_googlemap) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocalisationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object latitude, object longitude) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _get_localisation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProviderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _get_provider) ---
            */
            return default;
        }

        public async Task<TEntity> RaiseQueryErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IBaseGeocoderable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: base_geocoder.py, METHOD: _raise_query_error) ---
            */
            return default;
        }
    }
}