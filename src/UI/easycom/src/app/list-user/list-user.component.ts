import { Component, OnInit, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { ApiService } from '../core/api.services';
import { Student } from '../model/student.model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  users: Student[];

  constructor(private router: Router, private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getStudents()
      .pipe(map((item: Student[]) => item))
      .subscribe(data => {
        this.users = data;
        console.log(data);
      });
  }

  deleteUser(user: Student): void {
    this.apiService.deleteStudent(user.id)
      .subscribe(data => {
        this.users = this.users.filter(u => u !== user);
      })
  };

  editUser(user: Student): void {
    window.localStorage.removeItem("editUserId");
    window.localStorage.setItem("editUserId", user.id.toString());
    this.router.navigate(['edit-user']);
  };

  addUser(): void {
    this.router.navigate(['add-user']);
  };
}
