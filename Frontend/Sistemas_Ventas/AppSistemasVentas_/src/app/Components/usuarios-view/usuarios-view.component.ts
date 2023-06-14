import { Component, OnInit } from '@angular/core';
import { AppConsumo } from '../../Config/Services/Consumo.component';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import Swal from 'sweetalert2';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-usuarios-view',
  templateUrl: './usuarios-view.component.html',
  styleUrls: ['./usuarios-view.component.css']
})

export class UsuariosViewComponent implements OnInit {


  public data: any = [];
  public dataFinal: MatTableDataSource<any>;
  public keyData: string[] = [];


  public UserForm = new FormGroup({
    estado: new FormControl('', [Validators.required]),
    id: new FormControl('', Validators.required),
    nombre: new FormControl('', Validators.required),
    apellido: new FormControl('', Validators.required),
    genero: new FormControl('', Validators.required),
    usuario: new FormControl('', Validators.required),
    contraseña: new FormControl('', [Validators.required, Validators.minLength(8)]),
  })

  constructor(public appConsumo: AppConsumo) {
    this.dataFinal = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.function_GETListarUser();
  }

  public function_GETListarUser(): void {
    this.appConsumo.function_GET_LISTAR('Cajeros').subscribe((resp: any) => {
      this.data = resp;
      this.keyData = Object.keys(this.data[0]);
      this.keyData.push('Acciones');
      this.dataFinal.data = this.data;
      this.appConsumo.function_GetContador(Object.values(this.data));
    })
  }





}
