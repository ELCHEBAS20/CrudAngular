import { Component, OnInit } from '@angular/core';
import { AppConsumo } from '../../Config/Services/Consumo.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-view-sucursales',
  templateUrl: './view-sucursales.component.html',
  styleUrls: ['./view-sucursales.component.css']
})
export class ViewSucursalesComponent implements OnInit {


  public data: any = [];
  public keyData: string[] = [];
  public dataFinal: MatTableDataSource<any>;

  public SucursalForm = new FormGroup({
    estado: new FormControl('', [Validators.required]),
    id: new FormControl('', Validators.required),
    Localidad: new FormControl('', Validators.required),
    Direccion: new FormControl('', Validators.required)
  })

  constructor(public appConsumo: AppConsumo) {
    this.dataFinal = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.function_Get_Listar();
  }

  public function_Get_Listar(): void {
    this.appConsumo.function_GET_LISTAR('Sucursales').subscribe((resp: any) => {
      this.data = resp;
      this.keyData = Object.keys(this.data[0]);
      this.keyData.push('Acciones');
      this.dataFinal.data = this.data;
      this.appConsumo.function_GetContador(Object.values(this.data));
    })
  }
}
