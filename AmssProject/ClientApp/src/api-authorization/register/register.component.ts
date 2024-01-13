import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthorizeService } from '../authorize.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public message = new BehaviorSubject<string | null | undefined>(null);

  
  hide = true;
  loginForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });
  
  constructor(
    private formBuilder: FormBuilder,
    private authorizeService: AuthorizeService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  async ngOnInit() {
    
  }
  getErrorMessage(controlName: string) {
    const control = this.loginForm.get(controlName);

    if (control?.hasError('required')) {
      return 'You must enter a value';
    }

    return control?.hasError('email') ? 'Not a valid email' : '';
  }
  onSubmit() {}

}
