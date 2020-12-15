import { Component, OnInit } from '@angular/core';
import { ProductoService } from 'src/app/services/producto.service';
import { Producto } from '../../models/producto';
import { SignalRService } from 'src/app/services/SignalRService.service';

@Component({
  selector: 'app-producto-pollo',
  templateUrl: './producto-pollo.component.html',
  styleUrls: ['./producto-pollo.component.css']
})
export class ProductoPolloComponent implements OnInit {

  categoria="Pollo";
  cargando=true;
  hayProducto=false;
  Cantidad:number[]=[];
  Productos:Producto[];
  pageSize=20;
  page =1;
  constructor(private productoService:ProductoService,
    private SignalRService:SignalRService) { 
  }

  ngOnInit(): void {
    this.productoService.get().subscribe(p=>{
      this.Productos = p;
      this.InicializarArrayCantidad();
      this.HayProducto();
    });  

    this.SignalRService.signalReceived.subscribe((signal:Producto)=>{
      this.Productos.push(signal);
      this.HayProducto();
    })
    
    
  
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
    console.log(this.Cantidad[id]);
    this.productoService.AñadirCarrito(addProducto,this.Cantidad[id]);
  }

  InicializarArrayCantidad(){
    for (let index = 0; index < this.Productos.length; index++) {
      this.Cantidad[index]=1;   
    }

 }



}
