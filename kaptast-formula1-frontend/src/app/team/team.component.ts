import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Team } from '../team';
import { TeamService } from '../team.service';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  @Input() team: Team;

  constructor(
    private teamService: TeamService,
    private route: ActivatedRoute,
    private location: Location,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getTeam();
  }

  getTeam(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.teamService.getTeam(id)
      .subscribe(team => {
        this.team = team;
        console.log(team);
      });
  }

  save(): void {
    console.log(this.team);
    this.teamService.updateTeam(this.team)
      .subscribe(() => this.getTeam());
  }

  delete(): void {
    this.teamService.deleteTeam(this.team)
      .subscribe(() => this.location.back());
  }

  checkboxValueChange(): void {
    this.team.entryPaid = !this.team.entryPaid;
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

}
