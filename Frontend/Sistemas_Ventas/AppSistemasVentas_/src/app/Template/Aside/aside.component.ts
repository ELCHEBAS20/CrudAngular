import { Component } from '@angular/core';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-aside',
  templateUrl: './aside.component.html',
  styleUrls: ['./aside.component.css']
})
export class AsideComponent {


  public getUser = localStorage.getItem('getUser');

  constructor() { }

  public CerrarSesion(): void {
    Swal.fire({
      title: '¿Desea cerrar sesion?',
      showDenyButton: true,
      confirmButtonText: 'Aceptar',
      denyButtonText: `Cancelar`,
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
        localStorage.removeItem('getUser');
        localStorage.removeItem('getPswd');
      }
    })


  }

}
