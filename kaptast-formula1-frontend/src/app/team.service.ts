import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  updateTeam(team: Team): Observable<any> {
    const url = `${this.appConfigService.apiBaseUrl}/team`;
    console.log(team);
    console.log(url);
    return this.http.put(url, team, this.httpOptions)
      .pipe(
        catchError(this.handleError<any>('updateTeam'))
      );
  }

  addTeam(team: Team): Observable<Team> {
    const url = `${this.appConfigService.apiBaseUrl}/team`;
    console.log(team);
    console.log(url);
    return this.http.post<Team>(url, team, this.httpOptions)
      .pipe(
        catchError(this.handleError<Team>('addTeam'))
      );
  }

  deleteTeam(team: Team | string): Observable<Team> {
    const id = typeof team === 'string' ? team : team.id;
    const url = `${this.appConfigService.apiBaseUrl}/team/${id}`;

    return this.http.delete<Team>(url, this.httpOptions)
      .pipe(
        catchError(this.handleError<Team>('deleteTeam'))
      );
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  }


  private handleError<T>(msg = 'message', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      console.log(msg);
      return of(result as T);
    }
  }
}
