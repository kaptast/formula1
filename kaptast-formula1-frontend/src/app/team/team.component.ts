import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  isSaving: boolean = false;

  constructor(
    private teamService: TeamService,
    private route: ActivatedRoute,
    private location: Location,
    private authService: AuthService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getTeam();
  }

  getTeam(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.teamService.getTeam(id)
      .subscribe(team => {
        this.team = team;
      });
  }

  save(): void {
    if (this.validateValues()) {
      this.isSaving = true;

      this.teamService.updateTeam(this.team)
        .subscribe(() => {
          this.isSaving = false;
          this.getTeam();
        });
    }
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

  private validateValues(): boolean {
    return this.validateTeamName() && this.validateChampionships() && this.validateFoundation();
  }

  private validateTeamName(): boolean {
    this.team.name = this.team.name.trim();
    if (!this.team.name) {
      this.openSnackBar("Team name can't be empty!");
      return false;
    }

    return true;
  }

  private validateChampionships(): boolean {
    if (isNaN(this.team.championshipsWon)) {
      this.openSnackBar('Number of championships is not a number!');
      return false;
    }

    if (this.team.championshipsWon < 0) {
      this.openSnackBar("Number of championships can't be less than 0!");
      return false;
    }

    return true;
  }

  private validateFoundation(): boolean {
    if (isNaN(this.team.yearOfFoundation)) {
      this.openSnackBar('Year of foundation is not a number!');
      return false;
    }

    const currentYear: number = new Date().getFullYear();
    if (this.team.yearOfFoundation > currentYear) {
      this.openSnackBar(`Year of foundation can't be more than ${currentYear}!`);
      return false;
    }

    return true;
  }

  private openSnackBar(message: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      panelClass: ['alert-snackbar']
    });
  }
}
