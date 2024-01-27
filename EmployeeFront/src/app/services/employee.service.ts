import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { Employee } from "../models/employee";

@Injectable({
  providedIn: 'root',
})

export class EmployeeService {

  constructor(private http: HttpClient) { }
  baseApiUrl = "http://localhost:5041/api/Empleado";

  public getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseApiUrl}`);
  }

  public getEmployeeById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.baseApiUrl}/${id}`).pipe(
      catchError((error) => {
        console.error('Error en la solicitud HTTP al obtener empleado por ID', error);
        throw error;
      })
    );
  }
}
