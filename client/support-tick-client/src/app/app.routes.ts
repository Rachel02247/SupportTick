import { Routes } from '@angular/router';
import { OpenTicketComponent } from './components/open-ticket/open-ticket.component';
import { AdminTicketsComponent } from './components/admin-tickets/admin-tickets.component';
import { authGuard } from './guard/auth.guard';
import { HomePageComponent } from './components/home-page/home-page.component';
import { AuthComponent } from './components/auth/auth.component';

export const routes: Routes = [
        { path: '', component: HomePageComponent },
        { path: '/open-ticket', component: OpenTicketComponent },
        { path: '/tickets', component: AdminTicketsComponent, canActivate: [authGuard] },
        {path: "**", component: AuthComponent}
];
