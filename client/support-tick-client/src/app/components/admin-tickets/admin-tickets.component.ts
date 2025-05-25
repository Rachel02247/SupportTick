import { Component } from '@angular/core';
import { TicketService } from '../../services/ticketService/ticket.service';
import { Ticket } from '../../models/ticket';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';
import {DatePipe} from '@angular/common';
import {MatListModule} from '@angular/material/list';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-tickets',
  imports: [MatListModule, MatIconModule, MatDividerModule, DatePipe],
  templateUrl: './admin-tickets.component.html',
  styleUrl: './admin-tickets.component.css'
})
export class AdminTicketsComponent {

constructor(private ticketService: TicketService, private router: ActivatedRoute){
    this.loadData();
}

tickets: Ticket[] = [];

loadData = () =>{

    this.ticketService.getTickets().subscribe(data =>
      this.tickets = data as Ticket[]
      

    )
}

openTicket(id: number) {
  this.router.navigate(['/tickets/', id])
}

}
