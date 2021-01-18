import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';

import { Team } from '../team';
import { TeamService } from '../team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  teams: Team[];
  isLoading: boolean;

  constructor(
    private teamService: TeamService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getTeams();
  }

  getTeams(): void {
    this.isLoading = true;
    this.teamService.getTeams()
      .subscribe(teams => {
        this.teams = teams;
        this.isLoading = false;
      });
  }

  add(name: string): void {
    name = name.trim();
    if (!name) {
      return;
    }

    this.teamService.addTeam({ name } as Team)
      .subscribe(_ => {
        this.getTeams();
      });
  }

  delete(team: Team): void {
    this.teams = this.teams.filter(t => t != team);
    this.teamService.deleteTeam(team)
      .subscribe();
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

}
