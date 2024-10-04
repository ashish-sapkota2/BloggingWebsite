import { Component } from '@angular/core';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  constructor(public accountService:AccountService){
    console.log(accountService.currentUser$)
  }
}
