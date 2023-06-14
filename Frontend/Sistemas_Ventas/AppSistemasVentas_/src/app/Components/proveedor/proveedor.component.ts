import { Component, OnInit } from '@angular/core';
import { AppConsumo } from '../../Config/Services/Consumo.component'
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-proveedor',
  templateUrl: './proveedor.component.html',
  styleUrls: ['./proveedor.component.css']
})
export class ProveedorComponent implements OnInit {



  public data: any = [];
  public keydata: string[] = [];
  public dataFinal: MatTableDataSource<any>;

  public ProveForm = new FormGroup({
    status: new FormControl('', Validators.required),
    id: new FormControl('', Validators.required),
    entidad: new FormControl('', Validators.required),
    telefono: new FormControl('', Validators.required),
    celular: new FormControl('', Validators.required),
  })

  constructor(public appConsumo: AppConsumo) {
    this.dataFinal = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.function_Get_Listar();
  }

  public function_Get_Listar(): void {
    this.appConsumo.function_GET_LISTAR('Proveedor').subscribe((resp: any) => {
      this.data = resp;
      this.keydata = Object.keys(this.data[0]);
      this.keydata.push('Acciones')
      this.dataFinal.data = this.data;
      this.appConsumo.function_GetContador(Object.values(this.data));
    })
  }
}
