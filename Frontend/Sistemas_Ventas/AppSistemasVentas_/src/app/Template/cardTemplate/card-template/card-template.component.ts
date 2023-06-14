import { Component, Input, DoCheck } from '@angular/core';
import { AppConsumo } from "../../../Config/Services/Consumo.component";

@Component({
  selector: 'app-card-template',
  templateUrl: './card-template.component.html',
  styleUrls: ['./card-template.component.css']
})
export class CardTemplateComponent implements DoCheck {


  @Input() public countActivos = 0;
  @Input() public countNoActivos = 0;

  constructor(private service: AppConsumo) { }

  ngDoCheck(): void {
    this.function_getTotal();
  }

  public function_getTotal() {
    this.service.countActive.subscribe((resp: any) => {
      this.countActivos = resp;
    })
    this.service.countNotActive.subscribe((resp: any) => {
      this.countNoActivos = resp;
    })

  }

}
