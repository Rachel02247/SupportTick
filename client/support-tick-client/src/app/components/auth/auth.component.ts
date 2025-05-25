import { Component } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent {
  email = '';
  password = '';
  hidePassword = true;

  constructor(private authService: AuthService, private router: Router) { }

  login() {

    if (this.email && this.password) {

      this.authService.login(this.email, this.password).subscribe({
        next: (res) => {
          localStorage.setItem('token', res.token);
          const isAdmin = this.authService.isAdmin();
        }
      });
    }
  }
}