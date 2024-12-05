import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users: any[] = []; // Array to store existing users
  newUser: any = { username: '', email: '' }; // Object to store new user data

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.fetchUsers();
  }

  // Fetch existing users from the backend
  fetchUsers(): void {
    this.apiService.getUsers().subscribe(
      (data: any) => {
        this.users = data;
      },
      (error: any) => {
        console.error('Failed to fetch users:', error);
      }
    );
  }

  // Create a new user
  createUser(): void {
    if (!this.newUser.username || !this.newUser.email) {
      alert('Both username and email are required!');
      return;
    }

    this.apiService.createUser(this.newUser).subscribe(
      (data: any) => {
        this.users.push(data); // Add the newly created user to the list
        this.newUser = { username: '', email: '' }; // Reset the form
      },
      (error: any) => {
        console.error('Failed to create user:', error);
      }
    );
  }
}
