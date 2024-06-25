import { Component } from '@angular/core';
import { UserDataService } from './services/user-data.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'User Form';
  users: any;
  errorMessage: string = '';

  constructor(private userData: UserDataService) {
    this.fetchUsers();
  }

  fetchUsers() {
    this.userData.users().pipe(
      catchError((error) => {
        this.errorMessage = 'Error fetching users: ' + this.getErrorMessage(error);
        return throwError(this.errorMessage); // Rethrow the error
      })
    ).subscribe(
      (data) => {
        this.users = data;
      }
    );
  }

  getUserFormData(data: any) {
    this.userData.saveUsers(data).pipe(
      catchError((error) => {
        this.errorMessage = 'Error saving user: ' + this.getErrorMessage(error);
        return throwError(this.errorMessage); // Rethrow the error
      })
    ).subscribe(
      (result) => {
        console.warn(result);
        // Optionally reset form or perform other actions upon successful save
      }
    );
  }

  private getErrorMessage(error: any): string {
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      return `An error occurred: ${error.error.message}`;
    } else {
      // Server-side error
      return `Backend returned status code ${error.status}: ${error.message}`;
    }
  }
}
