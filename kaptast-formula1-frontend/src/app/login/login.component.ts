import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  isLoading: boolean = false;

  constructor(
    private authService: AuthService,
    private location: Location,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  login(username: string, password: string): void {
    this.isLoading = true;
    this.authService.login(username, password)
      .subscribe(result => {
        this.isLoading = false;
        if (!result) {
          this.openSnackBar();
        } else {
          this.location.back();
        }
      });
  }

  private openSnackBar(): void {
    this.snackBar.open('Invalid credentials!', 'Close', {
      duration: 5000,
      panelClass: ['alert-snackbar']
    });
  }
}
