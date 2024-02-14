import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';

@Component({
	selector: 'app-album',
	standalone: true,
	imports: [NgFor, NgIf],
	templateUrl: './album.component.html',
	styleUrl: './album.component.scss'
})
export class AlbumComponent {
	list = [
		{
			src: 'https://dummyimage.com/600x400/000/fff'
		},
		{
			src: 'https://dummyimage.com/600x400/000/fff'
		},
		{
			src: 'https://dummyimage.com/600x400/000/fff'
		},
		{
			src: 'https://dummyimage.com/600x400/000/fff'
		},
		{
			src: 'https://dummyimage.com/600x400/000/fff'
		}
	];
}
