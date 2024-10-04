import { ɵBrowserAnimationBuilder } from '@angular/animations';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { BsDropdownModule } from 'ng-bootstrap';
import {BrowserAnimationsModule, provideAnimations} from '@angular/platform-browser/animations'

import { routes } from './app.routes';
import { FormsModule } from '@angular/forms';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes),provideHttpClient(withFetch()),BrowserAnimationsModule,FormsModule,
  provideAnimations()]
};
