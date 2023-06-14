import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TemplateTableService {

  constructor(public http: HttpClient) { }

  public getDataTable(objClass: string): Observable<any> {
    return this.http.get(`https://localhost:7205/api/${objClass}`);
  }


}
