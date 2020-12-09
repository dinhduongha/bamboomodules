import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Product',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44398',
    redirectUri: baseUrl,
    clientId: 'Product_App',
    responseType: 'code',
    scope: 'offline_access Product',
  },
  apis: {
    default: {
      url: 'https://localhost:44398',
      rootNamespace: 'Bamboo.Product',
    },
    Product: {
      url: 'https://localhost:44370',
      rootNamespace: 'Bamboo.Product',
    },
  },
} as Environment;
