import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';
import { Inject } from '@angular/core';

import Konva from 'konva/lib';
import { Circle } from 'konva/lib/shapes/Circle';
import { Stage } from 'konva/lib/Stage';

@Component({
	selector: 'app-album',
	standalone: true,
	imports: [NgFor, NgIf],
	templateUrl: './album.component.html',
	styleUrl: './album.component.scss'
})
export class AlbumComponent implements OnInit {
	@ViewChild('canvasContainer', { static: true }) canvasContainer: ElementRef | null = null;
	@ViewChild('fileUpload', { static: true }) fileUpload: ElementRef | null = null;

	stage: Stage | null = null;
	imageSrc: string | ArrayBuffer | null = '';
	constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

	ngOnInit(): void {
		if (isPlatformBrowser(this.platformId)) {
			this.stage = new Konva.Stage({
				container: 'canvas_container',
				width: this.canvasContainer?.nativeElement.clientWidth,
				height: this.canvasContainer?.nativeElement.clientHeight
			});

			const layer = new Konva.Layer();

			// const circle = new Konva.Circle({
			// 	x: this.stage.width() / 2,
			// 	y: this.stage.height() / 2,
			// 	radius: 50,
			// 	fill: 'red',
			// 	stroke: 'black',
			// 	strokeWidth: 4,
			// 	opacity: 1,
			// 	draggable: true
			// });
			// layer.add(circle);

			this.stage.add(layer);
		}
	}

	drawImage() {
		const image = new Image();
		image.src = this.imageSrc as string;
		image.onload = () => {
			let img = new Konva.Image({
				x: 0,
				y: 0,
				image: image,
				stroke: '#000000',
				strokeWidth: 0,
				// strokeWidth: 1,
				draggable: true
			});
			this.stage?.children[0].add(img);
			this.imageSrc = null;
		};
	}

	getJson() {
		console.log(JSON.parse(this.stage?.toJSON() || '{}'));
	}

	onFileUpload($event: Event) {
		const el: any = $event.target;
		const file = el.files[0] as File;
		this.setImgSrc(file);
	}

	setImgSrc(file: File) {
		const reader = new FileReader();
		reader.onload = (e) => {
			this.imageSrc = reader.result;
			this.drawImage();
			if (this.fileUpload) {
				this.fileUpload.nativeElement.value = '';
			}
		};
		reader.readAsDataURL(file);
	}
}
