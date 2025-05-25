import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Ticket } from '../../models/ticket';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  apiUrl = '';

  constructor(private http: HttpClient) {
        this.apiUrl = environment.apiUrl + '/tickets';
       

   }

   getTickets = () => {

    return this.http.get<Ticket[]>(this.apiUrl).pipe(
     catchError(error => {
        alert( " failed: " + error.message);
        return throwError(error);
      })
    )

   }

   addTicket = (ticket: Ticket) => {
      return this.http.post(this.apiUrl, ticket);
   }
  }

