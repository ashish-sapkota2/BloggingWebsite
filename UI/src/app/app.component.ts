import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { User } from './Models/User';
import { NavbarComponent } from './navbar/navbar.component';
import { AccountService } from './_Services/account.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Scattered Tales';

  constructor(private http:HttpClient,private accountService:AccountService,
     ){
      this.setCurrentUser();
  }

  setCurrentUser(){
    var response= localStorage.getItem('user')
    if(response){
      const user:User= JSON.parse(response);
      if(user){
        this.accountService.setCurrentUser(user);
      }
    }
  }
}
