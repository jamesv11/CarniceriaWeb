import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//forms
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuarioRegistroComponent } from './Carniceria/usuario-registro/usuario-registro.component';
import { UsuarioLoginComponent } from './Carniceria/usuario-login/usuario-login.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { UsuarioGestionPerfilComponent } from './Carniceria/usuario-gestion-perfil/usuario-gestion-perfil.component';
import { RegistroDomiciliarioComponent } from './Admin/registro-domiciliario/registro-domiciliario.component';
import { RegistroProductoComponent } from './Admin/registro-producto/registro-producto.component';
import { CarritoComponent } from './Carniceria/Compra/carrito/carrito.component';
import { GestionFacturaComponent } from './Carniceria/Compra/gestion-factura/gestion-factura.component';
import { ProductoCarneComponent } from './Carniceria/Producto/producto-carne/producto-carne.component';
import { ProductoPolloComponent } from './Carniceria/Producto/producto-pollo/producto-pollo.component';
import { ProductoCerdoComponent } from './Carniceria/Producto/producto-cerdo/producto-cerdo.component';
import { InformacionComponent } from './Carniceria/Compra/informacion/informacion.component';
import { ProductoCarritoComponent } from './Carniceria/Compra/producto-carrito/producto-carrito.component';
import { EnviosComponent } from './Carniceria/Compra/envios/envios.component';
import { CarouselComponent } from './carousel/carousel.component';



//bootstrap
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { FiltroPersonaPipe } from './pipe/filtro-persona.pipe';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuarioRegistroComponent,
    UsuarioLoginComponent,
    FooterComponent,
    UsuarioGestionPerfilComponent,
    RegistroDomiciliarioComponent,
    RegistroProductoComponent,
    CarritoComponent,
    GestionFacturaComponent,
    ProductoCarneComponent,
    ProductoPolloComponent,
    ProductoCerdoComponent,
    InformacionComponent,
    ProductoCarritoComponent,
    EnviosComponent,
    CarouselComponent,
    AlertModalComponent,
    FiltroPersonaPipe,


  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ]),
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
