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
  page=1;
  pageSize=2;


  constructor(private productoService:ProductoService) {
    this.productoService.ListaProductos.subscribe(x => this.DetalleFacturas = x);
   }

  ngOnInit(): void {
    
  }

}
