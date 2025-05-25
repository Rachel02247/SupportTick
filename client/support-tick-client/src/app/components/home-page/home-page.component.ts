import { Component } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {

  constructor(private router: Router){}

  login(){
    
  }
 navToHome(){
  this.router.navigate(['/']);
}

navToOpenTicket(){
  this.router.navigate(['/open-ticket']);
}

navToManageTicket(){
  this.router.navigate(['/tickets']);
}
}
