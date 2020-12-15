import { Component, OnInit,PipeTransform } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Domiciliario } from 'src/app/Carniceria/models/domiciliario';
import { Documento } from 'src/app/Carniceria/models/documento';
import { DomiciliarioService } from 'src/app/services/domiciliario.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';


@Component({
  selector: 'app-registro-domiciliario',
  templateUrl: './registro-domiciliario.component.html',
  styleUrls: ['./registro-domiciliario.component.css'],
})
export class RegistroDomiciliarioComponent implements OnInit {

  searchText: string;
  submitted = false;
  registerDomiciliaryForm:FormGroup;
  domiciliario:Domiciliario;
  documento:Documento;
  domiciliarios:Domiciliario[];

  constructor(
    private domiciliarioService: DomiciliarioService,
    private formBuilder : FormBuilder,
    private modalService: NgbModal )
  { 

  }


  ngOnInit(): void {

    this.domiciliario = new Domiciliario();
    this.domiciliario.persona.correo = "";
    this.domiciliario.persona.identificacion = "";
    this.domiciliario.persona.nombre = "";
    this.domiciliario.persona.apellido = ""; 
    this.domiciliario.persona.telefono = "";
    this.domiciliario.persona.password = "";
    this.domiciliario.persona.direccion = "";

    this.registerDomiciliaryForm = this.formBuilder.group(
      {
        correo : [this.domiciliario.persona.correo,Validators.required],
        identificacion : [this.domiciliario.persona.identificacion,Validators.required],
        nombre : [this.domiciliario.persona.nombre,Validators.required],
        apellido : [this.domiciliario.persona.apellido,Validators.required],
        telefono : [this.domiciliario.persona.telefono,Validators.required],
        password : [this.domiciliario.persona.password,Validators.required],
        direccion : [this.domiciliario.persona.direccion,Validators.required]
      });


   // this.domiciliarioService.get().subscribe(result =>{this.domiciliarios = result});
  }

  get f() { return this.registerDomiciliaryForm.controls; }

  //Manejo Registrar
  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.registerDomiciliaryForm.invalid) {
        return;
    }
    this.add();
   }

    add(){
      this.domiciliario.persona = this.registerDomiciliaryForm.value;
      console.log(this.domiciliario);
      this.domiciliarioService.post(this.domiciliario).subscribe(c => {
        if (c != null) {
          const messageBox = this.modalService.open(AlertModalComponent);
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Domiciliario registrado con exito';
          this.domiciliario = c;
        }       
      });

      

      this.onReset();
   }

   onReset() {
    this.submitted = false;
    this.registerDomiciliaryForm.reset();
    }
  

}
