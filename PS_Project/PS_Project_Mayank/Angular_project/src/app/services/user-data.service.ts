import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class UserDataService {
  url="http://localhost:7102/api/userlists";
  constructor(private http:HttpClient) { }
  users()
  {
    return this.http.get(this.url);
  }
  saveUsers(data:any)
  {
 return this.http.post(this.url,data);  
  }
}
