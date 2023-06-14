import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { AppConsumo } from '../../Config/Services/Consumo.component';
import pdfMake from 'pdfmake/build/pdfMake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';

pdfMake.vfs = pdfFonts.pdfMake.vfs;


@Component({
  selector: 'app-view-factura',
  templateUrl: './view-factura.component.html',
  styleUrls: ['./view-factura.component.css']
})
export class ViewFacturaComponent implements OnInit {


  public data: any = [];
  public dataFinal: MatTableDataSource<any>;
  public keyData: string[] = [];

  @ViewChild('cmbProductos') cmbxProducto: ElementRef;

  public formFactura = new FormGroup({
    status: new FormControl('', Validators.required),
    id: new FormControl('', Validators.required),
    fecha: new FormControl('', Validators.required),
    total: new FormControl('', Validators.required),
    FkFormulario: new FormControl('Seleccion el Fk', Validators.required),
    descripcion: new FormControl('', Validators.required),

  });

  constructor(public appConsumo: AppConsumo, public render: Renderer2) {
    this.dataFinal = new MatTableDataSource();
  }

  ngOnInit(): void {
    this.function_SetFactura();
    this.functionGetFkSelect();
  }

  public function_SetFactura(): void {
    this.appConsumo.function_GET_LISTAR('Facturas').subscribe((resp: any) => {
      this.data = resp;
      this.keyData = Object.keys(this.data[0]);
      this.keyData.push('Acciones');
      this.dataFinal.data = this.data;
      this.appConsumo.function_GetContador(Object.values(this.data));
      this.appConsumo.classobjFk.next('idCliente|nombreCliente');
    })
  }

  public functionGetFkSelect() {
    this.appConsumo.function_GET_LISTAR('Clientes').subscribe((resp: any) => {
      this.appConsumo.setdataComponent.next(resp);
    })
  }



}
