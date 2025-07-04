import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TodoService } from '../_services/todo.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})

export class TodoComponent implements OnInit {
  newTask: string = '';
  tasks: any[] = [];
  errorMessage = '';
  successMessage = '';

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.todoService.getTodoList().subscribe({
      next: (data) => {
        this.tasks = data.map(t => ({ ...t, editing: false }));
      },
      error: () => {
        this.errorMessage = 'Błąd ładowania zadań.';
      }
    });
  }

  addTask(): void {
    const trimmed = this.newTask.trim();
    if (!trimmed) return;

    this.todoService.addTask(trimmed).subscribe({
      next: () => {
        this.successMessage = 'Zadanie dodane!';
        this.newTask = '';
        this.loadTasks();
      },
      error: () => {
        this.errorMessage = 'Nie udało się dodać zadania.';
      }
    });
  }

  editTask(index: number): void {
    this.tasks[index].editing = true;
  }

  saveTask(index: number): void {
    this.tasks[index].editing = false;
  }

  deleteTask(index: number): void {
    this.tasks.splice(index, 1);
  }
}
