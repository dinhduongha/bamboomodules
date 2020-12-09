import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Employee',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44389',
    redirectUri: baseUrl,
    clientId: 'Employee_App',
    responseType: 'code',
    scope: 'offline_access Employee role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44389',
      rootNamespace: 'Bamboo.Employee',
    },
    Employee: {
      url: 'https://localhost:44324',
      rootNamespace: 'Bamboo.Employee',
    },
  },
} as Environment;
