import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Router, RouterLink } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink,BsDropdownModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  isMenuOpen: boolean = false;
  model:any={};

  constructor(public accountService: AccountService, private router:Router){

  }
  login(){
    this.accountService.login(this.model).subscribe(response=>{
      this.router.navigateByUrl('/dashboard')
      console.log(response);
    })
  }
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/')

  }

  toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen;
  }
}
