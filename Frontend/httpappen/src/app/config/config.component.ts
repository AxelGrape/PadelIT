import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Config, ConfigService } from './config.service';

@Component({
    standalone: true,
    selector: 'app-config',
    templateUrl: './config.component.html',
    imports: [ CommonModule ],
    providers: [ ConfigService ],
    styles: ['.error { color: #b30000; }']
  })

export class ConfigComponent {
constructor(private configService: ConfigService) {}

    error: any;
    headers: string[] = [];
    config: Config | undefined;

    showConfig() {
    this.configService.getConfig()
        .subscribe(data => this.config = {
            heroesUrl: data.heroesUrl,
            textfile:  data.textfile,
            date: data.date,
        });
    }
}