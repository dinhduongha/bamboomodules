import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Base',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44309',
    redirectUri: baseUrl,
    clientId: 'Base_App',
    responseType: 'code',
    scope: 'offline_access Base',
  },
  apis: {
    default: {
      url: 'https://localhost:44309',
      rootNamespace: 'Bamboo.Base',
    },
    Base: {
      url: 'https://localhost:44341',
      rootNamespace: 'Bamboo.Base',
    },
  },
} as Environment;
