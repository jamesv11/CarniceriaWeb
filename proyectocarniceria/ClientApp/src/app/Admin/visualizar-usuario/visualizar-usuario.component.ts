import { Component, OnInit } from '@angular/core';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ClienteService } from 'src/app/services/cliente.service';
import { DataClienteService } from 'src/app/services/data-cliente.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-visualizar-usuario',
  templateUrl: './visualizar-usuario.component.html',
  styleUrls: ['./visualizar-usuario.component.css']
})
export class VisualizarUsuarioComponent implements OnInit {

  constructor(public dataCliente: DataClienteService, 
    private clienteService:ClienteService, 
    private modalService: NgbModal,
    private formBuilder :  FormBuilder) { }

    descuento: number = 0;
    rolcliente : string;

  ngOnInit(): void {
  }

  idSeleccionado(correo:string)
  {
    console.log(correo);
  }

  ModificarDescuento()
  {
    this.dataCliente.cliente.valorDescuento = this.descuento;
    this.clienteService.put(this.dataCliente.cliente).subscribe(c => {
      if(c != null){
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Descuento modificado con exito';
          this.dataCliente.cliente = c;
      }
    })
  }
  ModificarRol()
  {
    if(this.rolcliente != null)
    {
      this.dataCliente.cliente.persona.rol = this.rolcliente;
    this.clienteService.put(this.dataCliente.cliente).subscribe(c => {
      if(c != null){
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Rol modificado con exito';
          this.dataCliente.cliente = c;
      }
    })
    }
    else{
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.message = 'El campo esta vacio!';
         
    }
    
  }

}
