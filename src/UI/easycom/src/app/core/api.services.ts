import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { ApiResponse } from "../model/api.response";
import { Student } from '../model/student.model';

@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }
  baseUrl: string = 'http://localhost:55243/api/Student/';

  getStudents(): Observable<any> {
    return this.http.get<any>(this.baseUrl);
  }

  getStudentsById(id: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + id);
  }

  createStudent(user: Student): Observable<any> {
    return this.http.post<ApiResponse>(this.baseUrl, user);
  }

  updateStudent(user: Student): Observable<any> {
    return this.http.put<any>(this.baseUrl + user.id, user);
  }
  deleteStudent(id: number): Observable<any> {
    return this.http.delete<ApiResponse>(this.baseUrl + id);
  }
}
