import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private location: Location
    ) { }

  ngOnInit(): void {
  }

  login(username: string, password: string): void {
    console.log(username);
    console.log(password);
    this.authService.login(username, password)
      .subscribe(() => this.location.back());
  }
}
