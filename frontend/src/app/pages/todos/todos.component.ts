import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TodosApiService } from '@api';

@Component({
	selector: 'app-todos',
	standalone: true,
	imports: [NgFor, NgIf],
	templateUrl: './todos.component.html',
	styleUrl: './todos.component.scss'
})
export class TodosComponent implements OnInit {
	todoList: any[] = [];
	constructor(private todosApi: TodosApiService) {}

	ngOnInit(): void {
		this.todosApi.getList().subscribe({
			next: (response) => {
				this.todoList = response;
			}
		});
	}
}
