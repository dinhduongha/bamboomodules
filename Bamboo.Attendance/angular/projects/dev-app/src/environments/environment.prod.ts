import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Attendance',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44379',
    redirectUri: baseUrl,
    clientId: 'Attendance_App',
    responseType: 'code',
    scope: 'offline_access Attendance',
  },
  apis: {
    default: {
      url: 'https://localhost:44379',
      rootNamespace: 'Bamboo.Attendance',
    },
    Attendance: {
      url: 'https://localhost:44340',
      rootNamespace: 'Bamboo.Attendance',
    },
  },
} as Environment;
