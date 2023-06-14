import { Injectable } from '@angular/core';
import { ToastrService } from "ngx-toastr";
import Swal from 'sweetalert2';


@Injectable({
  providedIn: 'root'
})

export class MessageServiceService {

  constructor(private MessageService: ToastrService) { }

  public showSucces(Message: string, HttpValor: string) {
    this.MessageService.error(Message, HttpValor);
  }

  public async showConfirmSwal(infoSwal: string): Promise<boolean> {
    let isCambio: boolean;

    await Swal.fire({
      title: `${infoSwal}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si,Por favor..'
    }).then((result: any) => {
      if (result.isConfirmed) {
        isCambio = true;
      } else {
        isCambio = false;
      }
    })

    return isCambio;
  }


}
