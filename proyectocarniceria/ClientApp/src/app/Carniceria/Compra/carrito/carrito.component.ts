import { Component, OnInit } from '@angular/core';
import { ProductoService } from 'src/app/services/producto.service';
import { DetalleFactura } from '../../models/DetalleFactura';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent implements OnInit {

  DetalleFacturas:DetalleFactura[];
  NuevaCantidad:number[]=[];
  NuevoSubtotal:number[]=[];
  CantidadProducto:number;
  page=1;
  pageSize=2;


  constructor(private productoService:ProductoService) {
    this.productoService.ListaProductos.subscribe(x => this.DetalleFacturas = x);
    if(this.DetalleFacturas!=null) this.igualarCantidad();
    
   }

  ngOnInit(): void {
    
  }

  
  ModificarCantidad(i){
    this.productoService.ActualizaLista(this.DetalleFacturas);
  }

  igualarCantidad(){
    let i=0;
    this.DetalleFacturas.forEach(element => {
      this.NuevaCantidad[i]=this.DetalleFacturas[i].CantidadRequerida;
      this.NuevoSubtotal[i]=this.DetalleFacturas[i].SubTotal;
      i+=1;
    });
    
    
  }

  

}
