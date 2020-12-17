import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Producto } from 'src/app/Carniceria/models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-consultar-poducto',
  templateUrl: './consultar-poducto.component.html',
  styleUrls: ['./consultar-poducto.component.css']
})
export class ConsultarPoductoComponent implements OnInit {

  displayedColumns: string[] = ['Id Producto', 'Cantidad', 'Nombre producto', 'Precio unitario','Categoria'];

  productos:Producto[]=[];
  NuevaCantidad:number[]=[];
  NuevaValor:number[]=[];
  searchText:string;
  cargando = true;

  constructor(private productoService:ProductoService,private modalService: NgbModal) {
     this.productoService.get().subscribe(p=>{
       if(p!=null){
         this.productos = p;
         this.cargando = !this.cargando;
       }
     });
   }

  

  ngOnInit(): void {
  }

  ModificarCantidad(i){
    if(this.NuevaCantidad[i]!=this.productos[i].cantidad) {
      this.productos[i].cantidad=this.NuevaCantidad[i];
    }

  }
  igualarCantidad(i){
    this.NuevaCantidad[i]=this.productos[i].cantidad;
    
  }
  igualarValorUnitario(i){
    this.NuevaValor[i]=this.productos[i].valorUnitario;
    
  }
  ModificarValorUnitario(i){
    if(this.NuevaValor[i]!=this.productos[i].valorUnitario) {
      this.productos[i].valorUnitario=this.NuevaValor[i];
    }

  }
  ActualiczarProductos(){
    this.cargando = true;
    this.productoService.put(this.productos).subscribe(p=>{
      if(p!=null){
        const messageBox = this.modalService.open(AlertModalComponent )
        messageBox.componentInstance.title = "Proceso terminado";
        messageBox.componentInstance.message = "Exitoso";
        this.productos = p;
        this.cargando = !this.cargando;
      }
      else this.cargando = !this.cargando;
    })
    
  }

}
