import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';
import { Inject } from '@angular/core';

import Konva from 'konva/lib';
import { Circle } from 'konva/lib/shapes/Circle';

@Component({
	selector: 'app-album',
	standalone: true,
	imports: [NgFor, NgIf],
	templateUrl: './album.component.html',
	styleUrl: './album.component.scss'
})
export class AlbumComponent implements OnInit {
	constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

	ngOnInit(): void {
		if (isPlatformBrowser(this.platformId)) {
			// Your Konva code here
			const stage = new Konva.Stage({
				container: 'canvas_container',
				width: 600,
				height: 600
			});

			const layer = new Konva.Layer();

			const circle = new Konva.Circle({
				x: stage.width() / 2,
				y: stage.height() / 2,
				radius: 50,
				fill: 'red',
				stroke: 'black',
				strokeWidth: 4,
				opacity: 1
			});

			layer.add(circle);

			stage.add(layer);
		}
	}
}
