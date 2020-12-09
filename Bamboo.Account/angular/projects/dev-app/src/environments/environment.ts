import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Account',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44396',
    redirectUri: baseUrl,
    clientId: 'Account_App',
    responseType: 'code',
    scope: 'offline_access Account role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44396',
      rootNamespace: 'Bamboo.Account',
    },
    Account: {
      url: 'https://localhost:44346',
      rootNamespace: 'Bamboo.Account',
    },
  },
} as Environment;
