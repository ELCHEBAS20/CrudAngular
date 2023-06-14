import { Component, OnInit } from '@angular/core';
import { AppConsumo } from '../../Config/Services/Consumo.component'
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';



@Component({
  selector: 'app-view-productos',
  templateUrl: './view-productos.component.html',
  styleUrls: ['./view-productos.component.css']
})
export class ViewProductosComponent implements OnInit {


  public data = [];
  public keyData: any[];
  public dataFinal: MatTableDataSource<any>;
  public classObj = 'Productos';

  public ProductoForm = new FormGroup({
    status: new FormControl('', Validators.required),
    id: new FormControl(''),
    Codigo: new FormControl('', Validators.required),
    NombreProducto: new FormControl('', Validators.required),
    Valor: new FormControl('', Validators.required),
    TipoProducto: new FormControl('', Validators.required),
    FkFormulario: new FormControl('', Validators.required)
  })


  constructor(public appConsumo: AppConsumo) {
    this.dataFinal = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.function_Get_Listar();
    this.functionGetFkSelect();
  }

  public function_Get_Listar(): void {
    this.appConsumo.function_GET_LISTAR('Productos').subscribe((resp: any) => {
      this.data = resp;
      this.keyData = Object.keys(resp[0]);
      this.keyData.push('Acciones');
      this.dataFinal.data = this.data;
      this.appConsumo.classobjFk.next('idProveedor|entidadProveedor');
      this.appConsumo.function_GetContador(Object.values(this.data));
    })
  }

  public functionGetFkSelect() {
    this.appConsumo.function_GET_LISTAR('Proveedor').subscribe((resp: any) => {
      this.appConsumo.setdataComponent.next(resp);
    })
  }

}
