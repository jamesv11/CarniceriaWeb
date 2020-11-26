import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ClienteService } from 'src/app/services/cliente.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';


@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class UsuarioRegistroComponent implements OnInit {

  formRegistroCliente: FormGroup;
  cliente: Cliente;
  submitted = false;

  constructor( private clienteService: ClienteService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {

    this.cliente =  new Cliente();
    this.cliente.nombre = null;
    this.cliente.apellido = null;
    this.cliente.correo = null;
    this.cliente.password = null;

    this.formRegistroCliente = this.formBuilder.group({
      nombre: [this.cliente.nombre, Validators.required],
      apellido: [this.cliente.apellido, Validators.required],
      correo: [this.cliente.correo, Validators.required],
      password: [this.cliente.password, Validators.required]
    });

  }

  onSubmit() {
    this.submitted = true;
    if (this.formRegistroCliente.invalid) {
      return;
    }
    this.add();
  }

  get f() {
    return this.formRegistroCliente.controls;
  }

  add() {
    this.cliente = this.formRegistroCliente.value;
    this.clienteService.post(this.cliente).subscribe(c => {
    
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Domiciliario registrado con exito';
        this.cliente = c;
           
    });

  }

  onReset() {
    this.submitted = false;
    this.formRegistroCliente.reset();
  }

}
