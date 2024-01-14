import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthenticationService } from '../authentification/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public message = new BehaviorSubject<string | null | undefined>(null);

  
  hide = true;
  registerForm = this.formBuilder.group({
    DisplayName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });
  
  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService) { }

  async ngOnInit() {
    
  }
  getErrorMessage(controlName: string) {
    const control = this.registerForm.get(controlName);

    if (control?.hasError('required')) {
      return 'You must enter a value';
    }

    return control?.hasError('email') ? 'Not a valid email' : '';
  }
  async onSubmit() {
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
      try {
        let result = await this.authService.register(this.registerForm.value).toPromise();
        console.log(result);
        this.router.navigate(['/authentication/login']);
      } catch (error) {
        console.log(error); // You can still log the error if needed
      }
    } else {
      console.log("Invalid data");
    }
  }
  

}
