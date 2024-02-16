import { Routes } from '@angular/router';
import { AlbumComponent } from '@pages/album/album.component';
import { TodosComponent } from '@pages/todos/todos.component';

export const routes: Routes = [
	{
		path: 'album',
		component: AlbumComponent
	},
	{
		path: 'todos',
		component: TodosComponent
	},
	{
		path: '',
		redirectTo: '/album',
		pathMatch: 'full'
	}
];
