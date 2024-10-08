import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TestInputComponent } from '../forms/test-input/test-input.component';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,FormsModule,TestInputComponent,ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  registerForm:FormGroup;
  validationErrors:string[]=[];

  constructor(private accountService:AccountService,private fb:FormBuilder,
    private router:Router){
      this.initializeForm()
    }

  initializeForm(){
    this.registerForm=this.fb.group({
      username:['',Validators.required],
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required,Validators.minLength(6),Validators.maxLength(15)]],
      confirmPassword:['',[Validators.required,this.matchValues('password')]]

    })
  }

  matchValues(matchTo:string):ValidatorFn{
    return(control:AbstractControl)=>{
      return control?.value===control?.parent?.controls[matchTo].value ? null : {isMatching:true}
    }
  }
  register(){
    var result = this.accountService.register(this.registerForm.value).subscribe(response=>{
      this.router.navigateByUrl('/members');
      console.log(response)
    }
    )
    if(!result){
      this.validationErrors=["Something went wrong"]
    }
  }
}

