import { CommonModule } from '@angular/common';
import { Component, Input,Self } from '@angular/core';
import { FormsModule, NgControl, ReactiveFormsModule,ControlValueAccessor } from '@angular/forms';

@Component({
  selector: 'app-test-input',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './test-input.component.html',
  styleUrl: './test-input.component.css'
})
export class TestInputComponent implements ControlValueAccessor {
@Input() label:string;
@Input() type:string;

constructor(@Self() public ngControl:NgControl){
  if(this.ngControl){
    this.ngControl.valueAccessor=this;
  }
}
  writeValue(obj: any): void {
    
  }
  registerOnChange(fn: any): void { 
   
  }
  registerOnTouched(fn: any): void {
    
  }

}
