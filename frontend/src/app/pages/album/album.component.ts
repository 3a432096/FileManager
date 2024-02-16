import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TodosApiService } from '@api';

@Component({
	selector: 'app-album',
	standalone: true,
	imports: [NgFor, NgIf],
	templateUrl: './album.component.html',
	styleUrl: './album.component.scss'
})
export class AlbumComponent implements OnInit {
	list = Array(48).fill({
		src: 'https://dummyimage.com/600x400/000/fff'
	});

	constructor(private todosApi: TodosApiService) {}

	ngOnInit(): void {
		this.todosApi.getList().subscribe({
			next: (response) => {
				console.log(response);
			}
		});
	}
}
