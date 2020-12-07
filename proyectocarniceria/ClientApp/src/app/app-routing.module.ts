import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsuarioRegistroComponent } from './Carniceria/usuario-registro/usuario-registro.component';
import { CarritoComponent } from './Carniceria/Compra/carrito/carrito.component';
import { UsuarioLoginComponent } from './Carniceria/usuario-login/usuario-login.component';
import { FooterComponent } from './footer/footer.component';
import { GestionFacturaComponent } from './Carniceria/Compra/gestion-factura/gestion-factura.component';
import { ProductoCarneComponent } from './Carniceria/Producto/producto-carne/producto-carne.component';
import { ProductoPolloComponent } from './Carniceria/Producto/producto-pollo/producto-pollo.component';
import { ProductoCarritoComponent } from './Carniceria/Compra/producto-carrito/producto-carrito.component';
import { InformacionComponent } from './Carniceria/Compra/informacion/informacion.component';
import { EnviosComponent } from './Carniceria/Compra/envios/envios.component';
import { ProductoCerdoComponent } from './Carniceria/Producto/producto-cerdo/producto-cerdo.component';
import { RegistroDomiciliarioComponent } from './Admin/registro-domiciliario/registro-domiciliario.component';
import { GestionUsuariosComponent } from './Admin/gestion-usuarios/gestion-usuarios.component';
import { AuthGuard } from './services/auth.guard';
import { ProductoRegistroComponent } from './Admin/producto-registro/producto-registro.component';


const routes: Routes = [

  //Admin
  {
    path:'registroDomiciliario',
    component: RegistroDomiciliarioComponent,canActivate:[AuthGuard]
  },

  {
    path:'usuarioRegistro',
    component: UsuarioRegistroComponent

  },
  
  {
    path:'carrito',
    component: CarritoComponent
  },

  {
    path:'usuarioLogin',
    component: UsuarioLoginComponent
  },

  {
    path:'gestionFactura',
    component: GestionFacturaComponent,canActivate:[AuthGuard]
  },

  {
    path:'productoCarrito',
    component: ProductoCarritoComponent,canActivate:[AuthGuard]
  },

  {
    path:'informacionCompra',
    component: InformacionComponent,canActivate:[AuthGuard]
  },

  {
    path:'enviosCompra',
    component: EnviosComponent,canActivate:[AuthGuard]
  },

  {
    path:'footer',
    component: FooterComponent
  },

    {
      path:'',
      component: HomeComponent
    },

  {
    path:'res',
    component: ProductoCarneComponent
  },
  {
    path:'cerdo',
    component: ProductoCerdoComponent
  },
  {
    path:'pollo',
    component: ProductoPolloComponent
  },
  {
    path:'registro-producto',
    component: ProductoRegistroComponent,canActivate:[AuthGuard]
  }
  ,
  {
    path:'gestionUsuarios',
    component: GestionUsuariosComponent,canActivate:[AuthGuard]
  }


  
  ]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
