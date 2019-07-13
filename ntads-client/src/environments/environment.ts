// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiEndpoint: 'https://sd0975api.azurewebsites.net',
  adalConfig: {
    tenant: '5f6b292f-8b08-460c-bee1-a9263799770b',
    clientId: 'e4865b25-da11-4f21-ae24-15e5033755aa',
    endpoints: {
      'https://sd0975api.azurewebsites.net': 'e4865b25-da11-4f21-ae24-15e5033755aa'
    },
    redirectUri: window.location.origin,
    navigateToLoginRequestUrl: false
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
