import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//forms
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {MatStepperModule} from '@angular/material/stepper';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import { MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatBadgeModule} from '@angular/material/badge';




import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuarioRegistroComponent } from './Carniceria/usuario-registro/usuario-registro.component';
import { UsuarioLoginComponent } from './Carniceria/usuario-login/usuario-login.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { UsuarioGestionPerfilComponent } from './Carniceria/usuario-gestion-perfil/usuario-gestion-perfil.component';
import { RegistroDomiciliarioComponent } from './Admin/Domiciliario/registro-domiciliario/registro-domiciliario.component';
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
import { GestionUsuariosComponent } from './Admin/gestion-usuarios/gestion-usuarios.component';
import { ConsultarUsuariosComponent } from './Admin/consultar-usuarios/consultar-usuarios.component';
import { VisualizarUsuarioComponent } from './Admin/visualizar-usuario/visualizar-usuario.component';
import { PedidosUsuarioComponent } from './Admin/pedidos-usuario/pedidos-usuario.component';
import { MenuComponent } from './Admin/menu/menu.component';
import { JwtInterceptor } from './services/jwt.interceptor';
import { ProductoRegistroComponent } from './Admin/producto-registro/producto-registro.component';
import { FiltroProductoPipe } from './pipe/filtro-producto.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VisualizarDomiciliarioComponent } from './Admin/Domiciliario/registro-domiciliario/visualizar-domiciliario/visualizar-domiciliario.component';
import { ConsultarDomiciliarioComponent } from './Admin/Domiciliario/registro-domiciliario/consultar-domiciliario/consultar-domiciliario.component';
import { CargaPaginaComponent } from './carga-pagina/carga-pagina.component';
import { GestionFacturasComponent } from './Admin/gestion-facturas/gestion-facturas.component';
import { BusquedaProductoComponent } from './busqueda-producto/busqueda-producto.component';
import { FiltroBusquedaProductoPipe } from './pipe/filtro-busqueda-producto.pipe';
import { VisualizarFacturaComponent } from './Admin/visualizar-factura/visualizar-factura.component';
import { ConsultarFacturaComponent } from './Admin/consultar-factura/consultar-factura.component';



const material =[
  MatStepperModule,
  MatButtonModule,
  MatTableModule,
  MatInputModule,
  MatAutocompleteModule,
  MatBadgeModule
];




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
    GestionUsuariosComponent,
    ConsultarUsuariosComponent,
    VisualizarUsuarioComponent,
    PedidosUsuarioComponent,
    MenuComponent,
    ProductoRegistroComponent,
    FiltroProductoPipe,
    VisualizarDomiciliarioComponent,
    ConsultarDomiciliarioComponent,
    CargaPaginaComponent,
    GestionFacturasComponent,
    BusquedaProductoComponent,
    FiltroBusquedaProductoPipe,
    VisualizarFacturaComponent,
    ConsultarFacturaComponent,
   
  


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
    NgbModule,
    material,
    BrowserAnimationsModule
  ],
  entryComponents:[BusquedaProductoComponent,AlertModalComponent],
  providers: [{provide: HTTP_INTERCEPTORS,useClass:JwtInterceptor, multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
