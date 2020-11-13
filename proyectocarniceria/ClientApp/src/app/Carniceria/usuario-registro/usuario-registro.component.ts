import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/cliente';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ClienteService } from 'src/app/services/cliente.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
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

  constructor(private clienteService: ClienteService, private formBuilder: FormBuilder,private modalService: NgbModal) { }

  ngOnInit(): void {
    this.formRegistroCliente = this.formBuilder.group({
      inputNombre: ['', Validators.required],
      inputApellido: ['', Validators.required],
      inputEmail: ['', Validators.required],
      inputPassword: ['', Validators.required],
    });

    this.cliente = new Cliente();
  }

  onSubmit() {
    this.submitted = true;
    if (this.formRegistroCliente.invalid) {
      return;
    }
    this.add();
  }

  get control() {
    return this.formRegistroCliente.controls;
  }

  add() {
    this.clienteService.post(this.cliente).subscribe(c => {
      if (c != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Cliente registrado con exito';
        this.cliente = c;
      }
    });
  }

  onReset() {
    this.submitted = false;
    this.formRegistroCliente.reset();
  }

}
