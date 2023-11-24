import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupService } from './signup.service';


@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [CommonModule],
  providers: [SignupService],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  constructor(private signupService: SignupService) {}
  editName: String | undefined; // the hero currently being edited
  names : String[] = [];

  add(name: String): void {
    this.editName = undefined;
    name = name.trim();
    if (!name) {
      return;
    }

    // The server will generate the id for this new hero

    this.signupService
    .signup(name)
      .subscribe(name => this.names.push(name));
  }
  
}
