import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
    })
};

@Injectable()
export class WeeklyScheduleService {

    apiUrl = 'https://localhost:7189/';
    playersUrl = 'Players';

    constructor(private http: HttpClient) { }

    getParticipants(): Observable<any> {
        return this.http.get<any>(this.apiUrl + this.playersUrl);
    }

}