import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private baseUrl: string = "https://localhost:7242/api/Utilizator"
  constructor(private http: HttpClient) { }

  register(userObject: any) {
    return this.http.post<any>(this.baseUrl + "/register", userObject).pipe(
      catchError(error => {
        // Handle the error here
        if (error.status === 400) {
          alert("Invalid registration data. Please check your inputs.");
        } else {
          alert("An error occurred during registration.");
        }
  
        // Propagate a new error (or a modified one) to the subscriber
        return throwError(error);
      })
    );
  }

  login(userObject: any) {
    return this.http.post<any>(this.baseUrl + "/login", userObject).pipe(
      catchError(error => {
        // Handle the error here
        if (error.status === 404) {
          alert("User not found. Please check your credentials.");
        } else {
          alert("An error occurred during login.");
        }
  
        // Propagate a new error (or a modified one) to the subscriber
        return throwError(error);
      })
    );
  }
}
