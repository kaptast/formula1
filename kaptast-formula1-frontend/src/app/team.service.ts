import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient} from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';

import { Team } from './team';
import { AppConfigService } from './app-config.service';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  constructor(
    private appConfigService: AppConfigService,
    private http: HttpClient
  ) { }

  getTeams(): Observable<Team[]> {
    const url = `${this.appConfigService.apiBaseUrl}/team`;
    return this.http.get<Team[]>(url)
      .pipe(
        catchError(this.handleError<Team[]>('getTeams', []))
      );
  }

  getTeam(id: string): Observable<Team> {
    const url = `${this.appConfigService.apiBaseUrl}/team/${id}`;
    console.log(url);
    return this.http.get<Team>(url)
      .pipe(
        catchError(this.handleError<Team>(`getTeam id=${id}`))
      )
  }

  private handleError<T>(msg = 'message', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      console.log(msg);
      return of(result as T);
    }
  }
}
