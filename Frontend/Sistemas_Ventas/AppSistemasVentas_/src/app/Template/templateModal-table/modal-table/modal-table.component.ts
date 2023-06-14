import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ExampletableComponent } from "../../exampletable/exampletable.component";
import { AppConsumo } from "../../../Config/Services/Consumo.component";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-modal-table',
  templateUrl: './modal-table.component.html',
  styleUrls: ['./modal-table.component.css']
})
export class ModalTableComponent implements OnInit {

  @Input() form: FormGroup;
  public ExepArray: string[] = ['required', 'minlength'];
  @ViewChild('closeModal') closemodal: any;

  constructor(private templateTable: ExampletableComponent, private consumo: AppConsumo) { }

  ngOnInit(): void {
    this.getFormValue();
  }

  onSubmit(): void {

    if (this.form.valid) {
      console.log(this.form.value)
      this.PromiseClass().then((info: any) => {
        this.consumo.function_Update_Total(info, this.form.value).subscribe((data: any) => {
          this.closemodal.nativeElement.click();
          this.templateTable.getDataFinal();
        })
      })
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Tienes errores de formularios!'
      })
    }
  }

  public async PromiseClass() {
    let RstPromesa: any;
    this.templateTable.setClass.subscribe((resp: any) => {
      RstPromesa = resp;
    })
    return await RstPromesa;
  }

  public getFormValue(): string[] {
    return Object.keys(this.form.value);
  }

  public exepcionForm(AttrObj: string, typeError: string): boolean {
    return this.form.get(AttrObj)?.touched && this.form.get(AttrObj)?.errors?.[typeError] ? true : false;
  }

  public getMsgError(TypeError: string, AttrObj: string): string {
    if (TypeError === 'required') {
      return `${AttrObj} es requerido`;
    } else if (TypeError === 'minlength') {
      return ` ${AttrObj} es de longitud 8`;
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
}
