import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Producto } from '../Carniceria/models/producto';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-busqueda-producto',
  templateUrl: './busqueda-producto.component.html',
  styleUrls: ['./busqueda-producto.component.css']
})
export class BusquedaProductoComponent implements OnInit {
  Productos:Producto[]=[];
  categoria="Pollo";
  cargando=true;
  hayProducto=false;
  Cantidad:number[]=[];
  pageSize=20;
  page =1;

  constructor(public activeModal: NgbActiveModal,private productoService:ProductoService) { }
  @Input() title;
  @Input() StringbusquedaProducto;
  ngOnInit(): void {
    this.productoService.get().subscribe(p=>{
      this.Productos = p;
    });
  }
  addCarrito(addProducto:Producto,id:number){
    console.log(this.Cantidad[id]);
    this.productoService.AñadirCarrito(addProducto,this.Cantidad[id]);
  }

}
