import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface Config {
    heroesUrl: string;
    textfile: string;
    date: any;
  }

@Injectable()
export class ConfigService {

  constructor(private http: HttpClient) { }
  configUrl = 'assets/config.json';

getConfig() {
    return this.http.get<Config>(this.configUrl);
    }
  
}