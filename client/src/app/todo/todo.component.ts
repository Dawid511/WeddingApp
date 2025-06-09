// import { CommonModule } from '@angular/common';
// import { Component } from '@angular/core';
// import { FormsModule } from '@angular/forms';

// @Component({
//   selector: 'app-todo',
//   standalone: true,
//   imports: [FormsModule, CommonModule],
//   templateUrl: './todo.component.html',
//   styleUrl: './todo.component.css'
// })

// export class TodoComponent {
//   tasks: { text: string, editing: boolean }[] = [];
//   newTask: string = '';

//   addTask() {
//     if (this.newTask.trim()) {
//       this.tasks.push({ text: this.newTask.trim(), editing: false });
//       this.newTask = '';
//     }
//   }

//   deleteTask(index: number) {
//     this.tasks.splice(index, 1);
//   }

//   editTask(index: number) {
//     this.tasks[index].editing = true;
//   }

//   saveTask(index: number, newText: string) {
//     if (newText.trim()) {
//       this.tasks[index].text = newText.trim();
//       this.tasks[index].editing = false;
//     }
//   }
// }



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
// export class TodoComponent implements OnInit {
//   taskForm!: FormGroup;
//   tasks: any[] = [];
//   errorMessage = '';
//   successMessage = '';

//   constructor(
//     private fb: FormBuilder,
//     private todoService: TodoService
//   ) {}

//   ngOnInit(): void {
//     this.taskForm = this.fb.group({
//       title: ['', Validators.required]
//     });

//     this.loadTasks();
//   }

//   loadTasks(): void {
//     this.todoService.getTodoList().subscribe({
//       next: (data) => {
//         this.tasks = data;
//       },
//       error: (err) => {
//         console.error('Błąd pobierania tasków:', err);
//         this.errorMessage = 'Nie udało się załadować zadań.';
//       }
//     });
//   }

//   onSubmit(): void {
//     if (this.taskForm.invalid) return;

//     const title = this.taskForm.value.title;

//     this.todoService.addTask(title).subscribe({
//       next: () => {
//         this.successMessage = 'Zadanie dodane!';
//         this.taskForm.reset();
//         this.loadTasks(); // Odśwież listę
//       },
//       error: (err) => {
//         console.error('Błąd dodawania zadania:', err);
//         this.errorMessage = 'Nie udało się dodać zadania.';
//       }
//     });
//   }
// }



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
        // Dodaj pole "editing" do każdego taska
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
    // Tu można dorobić edycję przez backend, np. PUT
  }

  deleteTask(index: number): void {
    this.tasks.splice(index, 1);
    // Tu można dorobić DELETE przez backend
  }
}
