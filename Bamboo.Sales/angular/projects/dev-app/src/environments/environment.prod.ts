import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Sales',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44349',
    redirectUri: baseUrl,
    clientId: 'Sales_App',
    responseType: 'code',
    scope: 'offline_access Sales',
  },
  apis: {
    default: {
      url: 'https://localhost:44349',
      rootNamespace: 'Bamboo.Sales',
    },
    Sales: {
      url: 'https://localhost:44384',
      rootNamespace: 'Bamboo.Sales',
    },
  },
} as Environment;
