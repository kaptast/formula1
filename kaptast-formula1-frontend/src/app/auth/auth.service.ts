import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { tap, delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;

  redirectUrl: string;

  constructor() { }

  login(username: string, password: string): Observable<boolean> {
    console.log('auth login')
    return of(true)
      .pipe(
        delay(1000),
        tap(val => this.isLoggedIn = true)
    );
  }

  logout(): Observable<boolean> {
    return of(true)
      .pipe(
        tap(val => this.isLoggedIn = false)
      );
  }
}
