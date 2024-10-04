import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { environment } from '../../environment/environment';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.baseUrl;

  private currentUserSource = new ReplaySubject<User>(1)

  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http:HttpClient) { }

  login(model:any){
    return this.http.post<User>(this.baseUrl + 'account/login',model).pipe(
      map((response:User)=>{
        const user=response;
        if(user){
          this.setCurrentUser(user)
        }
        return user;
      })
      )
    }
    logout(){
      localStorage.removeItem('user');
      this.currentUserSource.next(null);
    }
    
    setCurrentUser(user:User){
    localStorage.setItem('user',JSON.stringify(user));
      this.currentUserSource.next(user);
  }
}
