import { Component, OnInit, signal } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { TicketService } from '../../services/ticketService/ticket.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { merge } from 'rxjs';
import { Ticket } from '../../models/ticket';

@Component({
  selector: 'app-open-ticket',
  imports: [MatCardModule, MatFormFieldModule, MatInputModule, MatSelectModule],
  templateUrl: './open-ticket.component.html',
  styleUrl: './open-ticket.component.css'
})
export class OpenTicketComponent implements OnInit{

  constructor(private ticketService: TicketService, private fb: FormBuilder){

  }

  form: FormGroup | undefined  = undefined;
  imageUrl: string = ''

  ngOnInit(): void {
     this.form = new FormGroup({
    name: new FormControl<string>('', [Validators.required]),
    email: new FormControl<string>('', [Validators.required]),
    description: new FormControl<string>('', [Validators.required]),
  });

  }


  //email
  readonly email = new FormControl('', [Validators.required, Validators.email]);

  errorMessage = signal('');


    emailTreat = () => {
      merge(this.email.statusChanges, this.email.valueChanges)
      .pipe(takeUntilDestroyed())
      .subscribe(() => this.updateErrorMessage());
    }  

  updateErrorMessage() {
    if (this.email.hasError('required')) {
      this.errorMessage.set('You must enter a value');
    } else if (this.email.hasError('email')) {
      this.errorMessage.set('Not a valid email');
    } else {
      this.errorMessage.set('');
    }
  }

  uploadFile(file: File){

    this.imageUrl;


  }

  submit(){
    if(this.form?.valid){

      this.ticketService.addTicket({...this.form.value, imageUrl: this.imageUrl}).subscribe();
    }

  }
}
