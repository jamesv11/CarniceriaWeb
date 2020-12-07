import { Component, OnInit } from '@angular/core';
import { FiltroProductoPipe } from 'src/app/pipe/filtro-producto.pipe';
import { ProductoService } from 'src/app/services/producto.service';
import { Producto } from '../../models/producto';

@Component({
  selector: 'app-producto-cerdo',
  templateUrl: './producto-cerdo.component.html',
  styleUrls: ['./producto-cerdo.component.css']
})
export class ProductoCerdoComponent implements OnInit {

  categoria="Pollo";
  hayProducto=false;
  Productos:Producto[];
  pageSize=20;
  page =1;
  constructor(private productoService:ProductoService) { }

  ngOnInit(): void {
    this.productoService.get().subscribe(p=>{
      this.Productos = p;
      this.HayProducto();
    });

    


   

  }

  HayProducto(){
    var contador= 0;
    this.Productos.forEach(element => {
      if(element.categoria.toLowerCase()==this.categoria.toLowerCase()) contador ++;
    });
    if(contador == 0) this.hayProducto = true;
  }
  addCarrito(addProducto:Producto){
    this.productoService.AñadirCarrito(addProducto,1);
  }




}
