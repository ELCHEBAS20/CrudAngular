import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { FacturacionAppComponent } from './Components/Cajero/Facturacion_Cajero/facturacion-app.component';
import { LoginAppComponent } from './Home/login-app/login-app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PageNotFoundComponent } from '../app/Config/page-not-found/page-not-found.component';
import { NavbarFacturacionComponent } from '../app/Components/Facturacion/navbar-facturacion.component';
import { ViewProductosComponent } from '../app/Components/view-productos/view-productos.component';
import { InicioAppComponent } from './Home/inicio-app/inicio-app.component';
import { UsuariosViewComponent } from '../app/Components/usuarios-view/usuarios-view.component';
import { HeaderComponent } from '../app/Template/header/header.component';
import { AsideComponent } from './Template/Aside/aside.component';
import { FooterComponent } from '../app/Template/footer/footer.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ProveedorComponent } from './Components/proveedor/proveedor.component';
import { MatIconModule } from '@angular/material/icon';
import { ViewFacturaComponent } from './Components/view-factura/view-factura.component';
import { ViewSucursalesComponent } from './Components/view-sucursales/view-sucursales.component';
import { NgChartsModule } from 'ng2-charts';
import { MatTooltip, MatTooltipModule } from '@angular/material/tooltip';
import { DataTablesModule } from 'angular-datatables';
import { PreguntaFrecuentesComponent } from './Components/pregunta-frecuentes/pregunta-frecuentes.component';
import { MatSelectModule } from '@angular/material/select';
import { AppConsumo } from "../app/Config/Services/Consumo.component";
import { ExampletableComponent } from './Template/exampletable/exampletable.component';
import { ModalTemplateComponent } from './Template/template-Modal/modal-template/modal-template.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ModalTableComponent } from './Template/templateModal-table/modal-table/modal-table.component';
import { AvatarModule } from "ngx-avatar";
import { MatProgressSpinner, MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpInterceptorService } from './Config/Services/http-interceptor.service';
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { CardTemplateComponent } from './Template/cardTemplate/card-template/card-template.component';



@NgModule({
  declarations: [
    AppComponent,
    FacturacionAppComponent,
    LoginAppComponent,
    PageNotFoundComponent,
    NavbarFacturacionComponent,
    ViewProductosComponent,
    InicioAppComponent,
    UsuariosViewComponent,
    HeaderComponent,
    AsideComponent,
    FooterComponent,
    ProveedorComponent,
    ViewFacturaComponent,
    ViewSucursalesComponent,
    PreguntaFrecuentesComponent,
    ExampletableComponent,
    ModalTemplateComponent,
    ModalTableComponent,
    CardTemplateComponent,

  ],
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 1800,
      progressBar: true,
      progressAnimation: 'increasing',
      preventDuplicates: true
    }),
    AppRoutingModule,
    MatSlideToggleModule,
    MatIconModule,
    NgChartsModule,
    MatTooltipModule,
    DataTablesModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatRadioModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    AvatarModule,
    MatProgressSpinnerModule,
    MatSlideToggleModule,
    MatSnackBarModule
  ],
  providers: [AppConsumo, { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
