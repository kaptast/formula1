import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";

import { AppComponent } from './app.component';
import { TeamsComponent } from './teams/teams.component';
import { TeamComponent } from './team/team.component';
import { LoginComponent } from './login/login.component';

import { AppConfigService } from './app-config.service';
import { AuthService } from './auth/auth.service';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';

export function tokenGetter() {
  console.log("getting access token");
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent,
    TeamComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5000", "localhost:44312"]
      }
    })
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      multi: true,
      deps: [
        AppConfigService,
        AuthService
      ],
      useFactory: (
        appConfigService: AppConfigService,
        authService: AuthService
        ) => {
        return () => {
          console.log('init');
          return appConfigService.loadAppConfig()
            .then(() => authService.checkLogin());
        };
      }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
