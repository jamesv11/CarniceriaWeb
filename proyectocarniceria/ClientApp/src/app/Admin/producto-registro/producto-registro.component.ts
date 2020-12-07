import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {Observable} from 'rxjs';
import {debounceTime, distinctUntilChanged, map} from 'rxjs/operators';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Producto } from 'src/app/Carniceria/models/producto';
import { ProductoCarne } from 'src/app/Carniceria/models/productoCarne';
import { ProductoService } from 'src/app/services/producto.service';

interface HtmlInputEvent extends Event{
  target: HTMLInputElement & EventTarget;
}


const cortes = ['Cola', 'Centro de pierna', 'Punta de anca', 'Lomito', 'Bola', 'Cadera', 'Muchacho',
  'Bota', 'Murillo', 'Sobrebarriga', 'Costilla', 'Chatas churrasco', 'Bola de brazo',
  'Falda', ' Pecho', 'Paletero', 'Morrillo'];

@Component({
  selector: 'app-producto-registro',
  templateUrl: './producto-registro.component.html',
  styleUrls: ['./producto-registro.component.css']
})
export class ProductoRegistroComponent implements OnInit {
  public model: any;
  categoria: any;
  ImagenBase64:any;
  isRes:string;
  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(200),
      distinctUntilChanged(),
      map(term => term.length < 2 ? []
        : cortes.filter(v => v.toLowerCase().indexOf(term.toLowerCase()) > -1).slice(0, 10))
    )

  constructor(private productoService : ProductoService,private formBuilder :  FormBuilder,private modalService: NgbModal) 
  { 
    this.registroProductoForm = this.crearFormGroupProducto();
  }

  submitted = false;
  registroProductoForm : FormGroup;
  producto:Producto;
  productoCarne:ProductoCarne;
  selectedFile : string | ArrayBuffer;
  file: File;

  ngOnInit(): void {
  }

  crearFormGroupProducto()
  {
      return this.formBuilder.group(
        {
        categoria : ["",Validators.required],
        nombreProducto : ["",Validators.required],
        descripcion : ["",Validators.required],
        valorUnitario : [0,Validators.required],
        cantidad : [0,Validators.required],
        imagenProducto : ["",Validators.required]
        }
      );
  }

  get f() { return this.registroProductoForm.controls; }

  OnSubmit() {
    this.submitted = true;
    if (this.registroProductoForm.invalid) {
      return;    
    }
    this.add();
  }
  add() {
    this.producto = new Producto();
    this.producto = this.registroProductoForm.value;
    this.producto.imagenProducto = this.ImagenBase64;
    console.log(this.producto);
    this.productoService.post(this.producto).subscribe((p) => {
      if (p != null) {
        console.log(p);
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Proceso terminado";
        messageBox.componentInstance.message = "Exitoso";     
        this.producto = p;
      }
    });
  }
  categoriaSeleccionada(): boolean { 
    if(this.categoria == "Res")return true;
    else return false;   
  }

  onReset() {
    this.submitted = false;
    this.registroProductoForm.reset();
  }
  onPhotoSelected(event: HtmlInputEvent): void{
    console.log(event);
    if(event.target.files && event.target.files[0]){
      this.file = event.target.files[0];
      const reader = new FileReader();
      reader.onload =  e => {
        this.selectedFile = reader.result;
        this.ImagenBase64 = reader.result;
      }
      
      
      reader.readAsDataURL(this.file);
      

      // this._arrayBufferToBase64(this.file.arrayBuffer());
      
       
    } 
  }

//    _arrayBufferToBase64( buffer ) {
//     var binary = '';
//     var bytes = new Uint8Array( buffer );
//     var len = bytes.byteLength;
//     for (var i = 0; i < len; i++) {
//         binary += String.fromCharCode( bytes[ i ] );
//     }
//     this.ImagenBase64 = window.btoa( binary );
// }

 


}
