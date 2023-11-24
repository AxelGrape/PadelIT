import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { WeeklyScheduleService } from './weekly-schedule.service';
import { response } from 'express';

@Component({
  selector: 'app-weekly-schedule',
  standalone: true,
  imports: [CommonModule],
  providers: [WeeklyScheduleService],
  templateUrl: './weekly-schedule.component.html',
  styleUrl: './weekly-schedule.component.css'
})
export class WeeklyScheduleComponent {
  participants: Array<any> = [];
  constructor(private weeklysScheduleService: WeeklyScheduleService) {
    this.weeklysScheduleService.getParticipants().subscribe((response) => {
      console.log(response)
      this.participants = response;
    })
  }

}

