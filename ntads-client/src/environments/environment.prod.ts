export const environment = {
  production: false,
  apiEndpoint: 'https://nashtechadsapi20190713043743.azurewebsites.net',
  adalConfig: {
    tenant: 'e4865b25-da11-4f21-ae24-15e5033755aa',
    clientId: '5f6b292f-8b08-460c-bee1-a9263799770b',
    endpoints: {
      'https://nashtechadsapi20190713043743.azurewebsites.net': '5f6b292f-8b08-460c-bee1-a9263799770b'
    },
    redirectUri: window.location.origin,
    navigateToLoginRequestUrl: false
  }
};
