import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import {ConfigComponent} from './config/config.component';
import { WeeklyScheduleComponent } from './weekly-schedule/weekly-schedule.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, SignupComponent, ConfigComponent, WeeklyScheduleComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'httpappen';

  readonly ROOT_URL = "localhost:5011";
  
}
