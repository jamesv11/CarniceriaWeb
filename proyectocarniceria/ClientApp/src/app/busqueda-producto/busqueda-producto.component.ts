import { Component, HostBinding, HostListener, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
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
  isOpen = false;

  constructor(config: NgbModalConfig, private modalService: NgbModal,
    public activeModal: NgbActiveModal,private productoService:ProductoService) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }


  ngOnInit(): void {
    this.productoService.get().subscribe(p=>{
      this.Productos = p;
    });
  }


  open(content) {
    this.modalService.open(content);
  }



}
