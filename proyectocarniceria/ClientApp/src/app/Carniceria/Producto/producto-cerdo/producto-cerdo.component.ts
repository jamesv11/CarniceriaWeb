import { Component, OnInit } from '@angular/core';
import { FiltroProductoPipe } from 'src/app/pipe/filtro-producto.pipe';
import { ProductoService } from 'src/app/services/producto.service';
import { SignalRService } from 'src/app/services/SignalRService.service';
import { Producto } from '../../models/producto';

@Component({
  selector: 'app-producto-cerdo',
  templateUrl: './producto-cerdo.component.html',
  styleUrls: ['./producto-cerdo.component.css']
})
export class ProductoCerdoComponent implements OnInit {

  categoria="Cerdo";
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
    this.productoService.AñadirCarrito(addProducto,this.Cantidad[id]);
  }

  InicializarArrayCantidad(){
    for (let index = 0; index < this.Productos.length; index++) {
      this.Cantidad[index]=1;   
    }

 }




}
