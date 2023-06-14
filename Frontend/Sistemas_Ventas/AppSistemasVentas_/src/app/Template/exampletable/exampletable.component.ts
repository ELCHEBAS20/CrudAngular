import { Component, OnInit, Input, AfterViewInit, ViewChild, Renderer2 } from '@angular/core';
import { TemplateTableService } from "../../Config/Services/template-table.service";
import { FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { AppConsumo } from "../../Config/Services/Consumo.component";
import Swal from 'sweetalert2';
import { ThemePalette } from '@angular/material/core';
import { MessageServiceService } from "./../../Config/Services/message-service.service";
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-exampletable',
  templateUrl: './exampletable.component.html',
  styleUrls: ['./exampletable.component.css']
})
export class ExampletableComponent implements OnInit, AfterViewInit {


  @Input() public datafinal: any = [];
  @Input() public keyData: any = [];
  @Input() public Form: FormGroup;
  @Input() public objClass: any;
  public keyform: any = [];
  public isVisible: any;
  public objItem: any;

  public setClass = new BehaviorSubject<any>({});

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private consumoApp: AppConsumo,
    private serviceMessage: MessageServiceService,
    private render: Renderer2) { }

  ngOnInit(): void {
    this.getkeyForm();
    this.consumoApp.httpInterceport.subscribe((resp: any) => {
      this.isVisible = resp;
    })
  }

  ngAfterViewInit(): void {
    this.datafinal.paginator = this.paginator;
    this.datafinal.sort = this.sort;
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.datafinal.filter = filterValue.trim().toLowerCase();
  }

  public getDataFinal() {

    this.consumoApp.function_GET_LISTAR(this.objClass).subscribe((resp: any) => {
      this.datafinal.data = resp;
      this.consumoApp.function_GetContador(Object.values(resp));
      console.log('Esta consumiendo');
    })

  }

  public getkeyForm() {
    this.keyform = Object.keys(this.Form.value);
  }

  public OpenModal(data: any): void {

    let keyData = Object.keys(this.Form.value);
    let dataForm = Object.values(data);
    this.setClass.next(this.objClass);

    for (let index = 0; index < keyData.length; ++index) {
      this.Form.controls[keyData[index]].setValue(dataForm[index])
    }
  }

  public getDelete(item: string): void {

    let setId = Object.values(item);
    let StrlSplit = setId.join(',').split(',')[0];

    Swal.fire({
      title: `¿Deseas eliminar el usuario ${StrlSplit}?`,
      text: 'La eliminacion de informacion es permanentemente.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si,eliminar.'
    }).then((result) => {
      if (result.isConfirmed) {
        this.consumoApp.function_getEliminar(this.objClass, StrlSplit).subscribe((resp: any) => {
          this.isVisible = false;
          this.getDataFinal();
          setTimeout(() => {
            this.isVisible = true;
          }, 1000);
        });
      }
    })


  }

  public async getFunctionSwitch(id: number, item: any, e: Event) {

    e.preventDefault();
    this.objItem = Object.values(item)[0];
    let btnSw = this.render.selectRootElement(`#customSwitches${id}`);
    btnSw.blur();
    let infoSwal = this.objItem == '0' ? '¿Desea Activar la informacion?' : '¿Desea desactivar la Informacion?';
    let ResultConfirm = await this.serviceMessage.showConfirmSwal(infoSwal);

    if (ResultConfirm) {
      this.consumoApp.function_PUT(item, this.objClass).subscribe((resp: any) => {
        this.getDataFinal();
      });
    }
  }


}
