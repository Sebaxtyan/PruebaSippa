import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  empleadoId: number | null = null;
  empleadoSeleccionado: Employee | null = null;
  errorMessage: string | null = null;

  // Propiedades para la paginación
  itemsPerPage: number = 5;
  totalItems: number = 0;
  currentPage: number = 1;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.obtenerEmpleados();
  }

  obtenerEmpleados() {
    this.employeeService.getAllEmployees().subscribe(
      (data) => {
        this.totalItems = data.length;
        this.employees = data;
        this.empleadoSeleccionado = null;
      },
      (error) => {
        console.error('Error al obtener empleados', error);
      }
    );
  }

  buscarEmpleado() {
    if (this.empleadoId !== null) {
      this.employeeService.getEmployeeById(this.empleadoId).subscribe(
        (empleado) => {
          this.employees = [empleado];
          this.empleadoSeleccionado = empleado;
        },
        (error) => {
          console.error('Error al obtener empleado por ID', error);
          this.errorMessage = 'No se encontró ningún empleado con el ID proporcionado.';
          this.clearDataAndReload();
        }
      );
    } else {
      this.obtenerEmpleados();
    }
  }

  clearDataAndReload() {
    setTimeout(() => {
      this.errorMessage = null;
      this.obtenerEmpleados();
    }, 5000);
  }
}
