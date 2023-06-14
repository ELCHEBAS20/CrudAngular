import { Component, ElementRef, Input, Renderer2, ViewChild, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AppConsumo } from "../../../Config/Services/Consumo.component";
import { ExampletableComponent } from "../../../Template/exampletable/exampletable.component";
import { MessageServiceService } from "../../../Config/Services/message-service.service";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-modal-template',
  templateUrl: './modal-template.component.html',
  styleUrls: ['./modal-template.component.css']
})
export class ModalTemplateComponent implements OnInit {

  @Input() getElements: any = [];
  @Input() formGeneral: FormGroup;
  @Input() setClass: any;

  public ExepArray: string[] = ['required', 'minlength'];
  public isValida: boolean = false;
  public selectFk: any[] = [];
  public rstSplit: string[] = [];

  @ViewChild('closeModal') closemodal: any;

  constructor(public consumo: AppConsumo, public tableTemplate: ExampletableComponent, public Toastservice: MessageServiceService) { }

  ngOnInit(): void {
    this.setFkInformacion();
  }

  public onSubmit(): void {
    this.formGeneral.get('id').setValue(-1);
    if (this.formGeneral.invalid) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Hay errores en los campos,verificar.!'
      })
    } else {

      // console.log(this.formGeneral.value);
      // console.log(this.setClass);
      this.consumo.function_POST(this.formGeneral.value, this.setClass).subscribe((resp: any) => {
        this.formGeneral.reset();
        this.closemodal.nativeElement.click();
        setTimeout(() => {
          this.tableTemplate.getDataFinal();
        }, 420);
      });
    }

  }

  public exepcionForm(AttrObj: string, typeError: string): boolean {
    return this.formGeneral.get(AttrObj)?.touched && this.formGeneral.get(AttrObj)?.errors?.[typeError] ? true : false;
  }

  public getMsgError(TypeError: string, AttrObj: string): string {
    if (TypeError === 'required') {
      return `${AttrObj} es requerido`;
    } else if (TypeError === 'minlength') {
      return ` ${AttrObj} es de minima longitud deseada`;
    }
    return "";
  }

  public KeyBlockPress(AttrObj: any, e: KeyboardEvent): boolean {
    if (AttrObj == 'estado' || AttrObj == 'status') {
      if (e.keyCode < 48 || e.keyCode > 49) {
        return false;
      }
    }

    return true;
  }

  public resetForm() {
    return this.formGeneral.reset();
  }

  public setFkInformacion() {
    this.consumo.classobjFk.subscribe((resp: any) => {
      this.rstSplit = resp.split('|');
      this.consumo.setdataComponent.subscribe((resp2: any) => {
        this.selectFk = this.consumo.function_FkSelect(resp2, this.rstSplit);
      })
    })
  }

}
