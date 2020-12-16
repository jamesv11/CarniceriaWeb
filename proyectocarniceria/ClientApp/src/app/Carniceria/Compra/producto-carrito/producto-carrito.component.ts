import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ClienteService } from 'src/app/services/cliente.service';
import { FacturaService } from 'src/app/services/factura.service';
import { ProductoService } from 'src/app/services/producto.service';
import { Cliente } from '../../models/cliente';
import { DetalleFactura } from '../../models/DetalleFactura';
import { Factura } from '../../models/factura';

@Component({
  selector: 'app-producto-carrito',
  templateUrl: './producto-carrito.component.html',
  styleUrls: ['./producto-carrito.component.css']
})
export class ProductoCarritoComponent implements OnInit {
  public cliente:Cliente;
  public factura : Factura;
  correoCliente="hola";
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  isCompleted = false;
  EstadoRegistro = 0;
  NuevaCantidad:number[]=[];
  ListaProductos:DetalleFactura[];
  displayedColumns: string[] = ['position', 'Productos', 'Cantidad', 'Precio Producto','ValorNeto','Eliminar producto'];
  constructor(private _formBuilder: FormBuilder,
              private productoService:ProductoService,
              private clienteService:ClienteService,
              private facturaService:FacturaService,
              private autenticacion:AuthenticationService,
              private modalService: NgbModal) 
  {
    this.productoService.ListaProductos.subscribe(x=>this.ListaProductos = x),
    this.autenticacion.currentUser.subscribe(x=>{
      this.clienteService.getCliente(x.correo).subscribe(c=>{
        this.cliente = c;
      })
    });
    
    
  }

  ngOnInit() {   
    this.secondFormGroup = this.crearFomGroup();
    
  }
 

  crearFomGroup()
  {    
    return this._formBuilder.group({ //
      identificacion: ["", Validators.required],
      direccion: ["", Validators.required],     
      telefono: ["", Validators.required],
    });
  }



  get f() { return this.secondFormGroup.controls; }

  ModificarCantidad(i){
    if(this.NuevaCantidad[i]!=this.ListaProductos[i].cantidadRequerida) {
      this.ListaProductos[i].cantidadRequerida=this.NuevaCantidad[i];
      this.productoService.ActualizaLista(this.ListaProductos);
    }

  }
  igualarCantidad(i){
    this.NuevaCantidad[i]=this.ListaProductos[i].cantidadRequerida;
    
  }
  EliminarProducto(i){
    this.productoService.removeDetalle(this.ListaProductos[i]);
  }
  Guardarfactura(){
    if(this.secondFormGroup.invalid==false){
      this.factura = new Factura();
      // this.ActualizarCliente();
      this.factura.detallesFacturas = this.ListaProductos;
      this.factura.correo = this.cliente.persona.correo;
      this.facturaService.Post(this.factura).subscribe((p) => {
        if (p != null) {
          this.EstadoRegistro = 1;
          this.factura = p;
          this.productoService.LimpiarLista();
        }
        else this.EstadoRegistro = 2;
      });
    }
  }
  
  ActualizarCliente(){
    var formularioRespuesta = this.secondFormGroup.value;
    this.cliente.persona.direccion = formularioRespuesta["direccion"];
    this.cliente.persona.identificacion = formularioRespuesta["identificacion"];
    this.cliente.persona.telefono = formularioRespuesta["telefono"];
    this.clienteService.put(this.cliente);
  }


}
