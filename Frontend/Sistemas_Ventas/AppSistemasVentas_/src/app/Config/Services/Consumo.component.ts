import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExepcionApp } from '../ExepcionesTS/Exepcion.component';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AppConsumo {

  private url: string = ' ';
  public static ActionDb: string;
  public httpInterceport = new BehaviorSubject<any>({});
  public countActive = new BehaviorSubject<number>(0);
  public countNotActive = new BehaviorSubject<number>(0);
  public classobjFk = new BehaviorSubject<string>('');
  public setdataComponent = new BehaviorSubject<any>({});

  constructor(public HtppCliente: HttpClient, public Exepcion: ExepcionApp) {
    // this.url = 'http://localhost/dashboard/AppSistemas_Ventas/Backend/';
  }

  /*======================*/
  /*Consumo de C# backend*/
  /*======================*/
  /**======================================= */
  public validar_Url(objClass: string, idObj?: number) {
    this.url = '';
    this.url = `https://localhost:7101/api/${objClass}`;
    return this.url;
  }

  public validar_Url_Max_Two_Params(objClass: string, idObj: number) {
    this.url = '';
    this.url = `https://localhost:7101/api/${objClass}/${idObj}`;
    return this.url;
  }

  public validar_Login(objClass: string, user: string, pswd: string) {
    this.url = '';
    this.url = `https://localhost:7101/api/${objClass}/user=${user}&pswd=${pswd}`;
    return this.url;
  }

  public cantidadCards(objClass: string, VSearch: string, FilterValor: string) {
    this.url = '';
    this.url = `https://localhost:7101/api/${objClass}/${FilterValor}?${FilterValor}=${VSearch}`;
    return this.url;
  }
  /**======================================= */


  public function_GET_LISTAR(objClass: string): Observable<any> {
    return this.HtppCliente.get(this.validar_Url(objClass));
  }

  public function_POST(data: any, objClass: string): Observable<any> {
    return this.HtppCliente.post(this.validar_Url(objClass), data, { responseType: 'text' });
  }

  public function_PUT(data: any, objClass: string): Observable<any> {
    return this.HtppCliente.put(this.validar_Url(objClass), data, { responseType: 'text' });
  }

  public function_GET_ID(idObj: number, objClass: string): Observable<any> {
    return this.HtppCliente.get(this.validar_Url_Max_Two_Params(objClass, idObj));
  }

  public function_Login_Rol(obj: string, usuario: string, contra: string): Observable<any> {
    return this.HtppCliente.get(this.validar_Login(obj, usuario, contra), { responseType: 'text' });
  }

  public function_GetCantidadCards(objClass: string, StrlSearch: string, FilterValor: string): Observable<any> {
    return this.HtppCliente.get(this.cantidadCards(objClass, StrlSearch, FilterValor), { responseType: 'text' })
  }

  public function_GrupoBYProductos(objClass: string, StrlSearch: string, FilterValor: string): Observable<any> {
    return this.HtppCliente.get(this.cantidadCards(objClass, StrlSearch, FilterValor), { responseType: 'text' });
  }

  public getProducto(objClass: string, idCodigo: string): Observable<any> {
    return this.HtppCliente.get(this.validar_Url_Max_Two_Params(objClass, parseInt(idCodigo)));
  }

  public function_getEliminar(objClass: string, id: string): Observable<any> {
    return this.HtppCliente.delete(this.validar_Url_Max_Two_Params(objClass, parseInt(id)));
  }

  public function_GetContador(data: any) {
    let setCount_ = 0
    let setNotCount_ = 0;

    for (let index = 0; index < data.length; ++index) {
      if (data[index].status != '0') {
        setCount_++;
      } else {
        setNotCount_++;
      }
    }
    this.countActive.next(setCount_);
    this.countNotActive.next(setNotCount_);
  }

  public function_FkSelect(data: any, strlSplit: any[]): any[] {
    let DataFinal = [];
    for (let index = 0; index < data.length; ++index) {
      DataFinal.push({
        id: data[index][strlSplit[0]],
        value: data[index][strlSplit[1]]
      })
    }
    return DataFinal;
  }

  public function_Update_Total(objClass: any, body: any) {
    return this.HtppCliente.patch(this.validar_Url(objClass), body)
  }

}