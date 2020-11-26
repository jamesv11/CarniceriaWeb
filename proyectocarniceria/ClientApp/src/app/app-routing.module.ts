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
import { RegistroProductoComponent } from './Admin/registro-producto/registro-producto.component';
import { GestionUsuariosComponent } from './Admin/gestion-usuarios/gestion-usuarios.component';


const routes: Routes = [

  //Admin
  {
    path:'registroDomiciliario',
    component: RegistroDomiciliarioComponent
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
    component: GestionFacturaComponent
  },

  {
    path:'productoCarrito',
    component: ProductoCarritoComponent
  },

  {
    path:'informacionCompra',
    component: InformacionComponent
  },

  {
    path:'enviosCompra',
    component: EnviosComponent
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
    component: RegistroProductoComponent
  }
  ,
  {
    path:'registro-producto',
    component: RegistroProductoComponent
  }
  ,
  {
    path:'gestionUsuarios',
    component: GestionUsuariosComponent
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
