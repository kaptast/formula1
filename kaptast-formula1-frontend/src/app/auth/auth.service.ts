import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';

import { AppConfigService } from '../app-config.service';
import { User } from '../user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;

  constructor(
    private appConfigService: AppConfigService,
    private http: HttpClient
  ) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  checkLogin() {
    const url = `${this.appConfigService.apiBaseUrl}/auth`;

    return this.http.get(url)
      .toPromise()
      .then(() => {
        this.isLoggedIn = true; // set login status to true if the request was successful
      })
      .catch(err => {
        // otherwise log the error and set the login status to false
        console.error(err);
        this.isLoggedIn = false;
      });
  }

  login(username: string, password: string): Observable<boolean> {
    const url = `${this.appConfigService.apiBaseUrl}/auth/login`;
    const user: User = new User(username, password);

    return this.http.post<boolean>(url, user, this.httpOptions)
      .pipe(
        map(result => {
          // if the request was successful, then set the session token and set the login status to true
          this.setSession(result); 
          this.isLoggedIn = true;
          return true;
        }),
        catchError(this.handleError<boolean>('error at login', false))
      );
  }

  logout(): Observable<boolean> {
    const url = `${this.appConfigService.apiBaseUrl}/auth/logout`;
    return this.http.post<boolean>(url, null, this.httpOptions)
      .pipe(
        tap(() => {
          // if the request was successful, then remove the session token and set the login status to false
          this.isLoggedIn = false;
          this.removeSession();
        }),
        catchError(this.handleError<boolean>('error at logout', false))
      );
  }

  getToken(): string {
    return localStorage.getItem('access_token');
  }

  private handleError<T>(msg = 'message', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      console.log(msg);
      return of(result as T);
    }
  }

  private setSession(authResult): void {
    localStorage.setItem('access_token', authResult.token);
    localStorage.setItem('expires_at', authResult.expires);
  }

  private removeSession(): void {
    localStorage.removeItem('access_token');
    localStorage.removeItem('expires_at');
  }
}
