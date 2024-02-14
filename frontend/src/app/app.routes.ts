import { Routes } from '@angular/router';
import { AlbumComponent } from '@pages/album/album.component';

export const routes: Routes = [
	{
		path: 'album',
		component: AlbumComponent
	},
	{
		path: '',
		redirectTo: '/album',
		pathMatch: 'full'
	}
];
