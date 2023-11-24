import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Console } from 'console';


const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

@Injectable()
export class SignupService {

    apiUrl = 'https://localhost:7189/';
    playersUrl = 'Players/';

  constructor(private http: HttpClient) { }

signup(name : String) : Observable<String> {
    console.log("name: ", name);
    return this.http.post<String>(this.apiUrl + this.playersUrl + name, name, httpOptions);
    }
  
}