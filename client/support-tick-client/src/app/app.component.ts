import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OpenTicketComponent } from './components/open-ticket/open-ticket.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, OpenTicketComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'support-tick-client';
}
