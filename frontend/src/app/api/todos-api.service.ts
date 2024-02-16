import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environment';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class TodosApiService {
	key: string = 'todos';

	constructor(private http: HttpClient) {}

	getList(): Observable<any[]> {
		return this.http.get<any[]>(`${environment.apiUri}/${this.key}`);
	}

	get(id: number) {
		return this.http.get(`${environment.apiUri}/${this.key}/${id}`);
	}

	create() {}

	update() {}

	delete() {}
}
