import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CRM',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44345',
    redirectUri: baseUrl,
    clientId: 'CRM_App',
    responseType: 'code',
    scope: 'offline_access CRM',
  },
  apis: {
    default: {
      url: 'https://localhost:44345',
      rootNamespace: 'Bamboo.CRM',
    },
    CRM: {
      url: 'https://localhost:44314',
      rootNamespace: 'Bamboo.CRM',
    },
  },
} as Environment;
