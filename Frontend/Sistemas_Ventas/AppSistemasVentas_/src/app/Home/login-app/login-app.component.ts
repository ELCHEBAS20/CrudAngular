import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AppConsumo } from '../../Config/Services/Consumo.component'
import { Renderer2, ElementRef, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-login-app',
  templateUrl: './login-app.component.html',
  styleUrls: ['./login-app.component.css']
})
export class LoginAppComponent implements OnInit {

  public isPswd: boolean;
  public ImgSrcPswd: string;

  constructor(public ApiConsumo: AppConsumo, public render: Renderer2) {
    this.isPswd = false;
  }

  ngOnInit(): void { }

  @ViewChild("Error") TxtError: ElementRef;
  @ViewChild("ImgBoxPswd") ImgPswd: ElementRef;
  @ViewChild("Chck_Admin") ChckAdmin: ElementRef;
  @ViewChild("Chck_Cajero") ChckCajero: ElementRef;

  public setUser = new FormGroup({
    user: new FormControl('', Validators.required),
    pswd: new FormControl('', [Validators.required, Validators.minLength(8)])
  })


  public functionViewContra(): boolean {
    if (!this.isPswd) {
      this.isPswd = true;
      this.ImgSrcPswd = '<i class="fa-sharp fa-solid fa-eye"></i>';
    } else {
      this.isPswd = false;
      this.ImgSrcPswd = '<i class="fa-solid fa-eye-slash"></i>';
    }
    this.render.setProperty(this.ImgPswd.nativeElement, 'innerHTML', this.ImgSrcPswd);
    return this.isPswd;
  }

  public onsubmit(): void {

    if (this.setUser.invalid) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Verifica los campos, por favor.!'
      })
    } else {

      let getUser = this.setUser.value.user;
      let getPswd = this.setUser.value.pswd;

      if (getUser == 'admin' && getPswd == '12345678') {
        localStorage.setItem('getUser', getUser);
        localStorage.setItem('getPswd', getPswd);
        location.href = '/'
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Creendeciales Incorrectas.!'
        })
      }
    }
  }

}
