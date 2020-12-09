import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Stock',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44361',
    redirectUri: baseUrl,
    clientId: 'Stock_App',
    responseType: 'code',
    scope: 'offline_access Stock role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44361',
      rootNamespace: 'Bamboo.Stock',
    },
    Stock: {
      url: 'https://localhost:44358',
      rootNamespace: 'Bamboo.Stock',
    },
  },
} as Environment;
