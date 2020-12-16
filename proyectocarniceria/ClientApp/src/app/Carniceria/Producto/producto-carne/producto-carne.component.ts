import { Component, OnInit } from '@angular/core';
import { ProductoService } from 'src/app/services/producto.service';
import { Producto } from '../../models/producto';
import { ProductoCarne } from '../../models/productoCarne';

@Component({
  selector: 'app-producto-carne',
  templateUrl: './producto-carne.component.html',
  styleUrls: ['./producto-carne.component.css']
})
export class ProductoCarneComponent implements OnInit {

  categoria="Res";
  cargando=true;
  hayProducto=false;
  Cantidad:number[]=[];
  Productos:ProductoCarne[];
  pageSize=20;
  page =1;
  constructor(private productoService:ProductoService) { 
  }

  ngOnInit(): void {
    this.productoService.getCarnes().subscribe(p=>{
      this.Productos = p;
      this.InicializarArrayCantidad(); 
      this.HayProducto();
    });
 
    

  
  }

  HayProducto(){
    var contador= 0;
    this.Productos.forEach(element => {
      if(element.categoria.toLowerCase()==this.categoria.toLowerCase()) contador ++;
    });
    if(contador == 0) this.hayProducto = true;

    setTimeout(()=>{                           
      this.cargando = false;
    }, 1000);
  }
  addCarrito(addProducto:Producto,id:number){
    this.productoService.AñadirCarrito(addProducto,this.Cantidad[id]);
  }

  InicializarArrayCantidad(){
    for (let index = 0; index < this.Productos.length; index++) {
      this.Cantidad[index]=1;   
    }
  }

 

}
