import { Student } from './../model/student.model';
import { Component, OnInit, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { first, map } from "rxjs/operators";
import { ApiService } from '../core/api.services';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  user: Student;
  editForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: ApiService) { }

  ngOnInit() {

    let userId = window.localStorage.getItem("editUserId");
    if (!userId) {
      alert("Invalid action.")
      this.router.navigate(['list-user']);
      return;
    }

    this.editForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.compose([Validators.required])],
      lastname: ['', Validators.compose([Validators.required])],
      phone: ['', Validators.compose([Validators.required])],
      address: ['', Validators.compose([Validators.required])],
      city: ['', Validators.compose([Validators.required])],
      state: ['', Validators.compose([Validators.required])],
      country: ['', Validators.compose([Validators.required])]
    });

    this.apiService.getStudentsById(+userId)
      .pipe(map((item: Student) => item))
      .subscribe(data => {
        this.user = data;
        this.editForm.setValue({
          id: this.user.id,
          name: this.user.name,
          lastname: this.user.lastName,
          phone: this.user.phone,
          address: this.user.address,
          city: this.user.city,
          state: this.user.state,
          country: this.user.country
        });
      });
  }

  onSubmit() {

    let userId = window.localStorage.getItem("editUserId");
    if (!userId) {
      alert("Invalid action.")
      this.router.navigate(['list-user']);
      return;
    }

    this.apiService.updateStudent(this.editForm.value)
      .pipe(first())
      .subscribe(
        data => {
          alert('Student updated successfully.');
          this.router.navigate(['list-user']);
        },
        error => {
          alert('algo deu errado:' + error.message);
        });
  }

  goBack() {
    this.router.navigate(['list-user']);
  }

}
