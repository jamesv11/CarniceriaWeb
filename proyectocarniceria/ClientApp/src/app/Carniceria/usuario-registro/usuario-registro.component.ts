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
    this.cliente.persona.nombre = null;
    this.cliente.persona.apellido = null;
    this.cliente.persona.correo = null;
    this.cliente.persona.password = null;

    this.formRegistroCliente = this.formBuilder.group({
      nombre: [this.cliente.persona.nombre, Validators.required],
      apellido: [this.cliente.persona.apellido, Validators.required],
      correo: [this.cliente.persona.correo, Validators.required],
      password: [this.cliente.persona.password, Validators.required]
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
    this.cliente.persona = this.formRegistroCliente.value;
    console.log(this.cliente);
    this.clienteService.post(this.cliente).subscribe((c) => {
      if(c == null)
      {
        console.log(c);
        const messageBox = this.modalService.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Domiciliario registrado con exito';
        this.cliente = c;
        console.log(c);
      }        
    });

    this.onReset();

  }

  onReset() {
    this.submitted = false;
    this.formRegistroCliente.reset();
  }

}
