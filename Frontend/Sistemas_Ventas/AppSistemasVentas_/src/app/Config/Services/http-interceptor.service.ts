import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, tap } from 'rxjs';
import { AppConsumo } from "../Services/Consumo.component";


@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {

  constructor(private consumo: AppConsumo) { }


  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    return next.handle(req).pipe(
      tap(event => {
        this.consumo.httpInterceport.next(false);
        if (event.status == 200) {
          setTimeout(() => {
            this.consumo.httpInterceport.next(true);
          }, 1000)
        }
      })
    );
  }
}
