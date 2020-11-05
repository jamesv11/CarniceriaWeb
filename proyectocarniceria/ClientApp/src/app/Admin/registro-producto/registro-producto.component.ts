import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { ImagenProducto } from 'src/app/Carniceria/models/ImagenProducto';
import { Producto } from 'src/app/Carniceria/models/producto';
import { ImagenProductoService } from 'src/app/services/ImagenProducto.service';
import { ProductoService } from 'src/app/services/producto.service';

interface HtmlInputEvent extends Event{
  target: HTMLInputElement & EventTarget;
}

@Component({
  selector: 'app-registro-producto',
  templateUrl: './registro-producto.component.html',
  styleUrls: ['./registro-producto.component.css']
})
export class RegistroProductoComponent implements OnInit {


  submitted = false;
  ListaTag:string[]=['nuevo'];
  imagenSelected: string | ArrayBuffer;

  imagenProducto: ImagenProducto;
  producto: Producto;
  registroProductoForm: FormGroup;

  constructor(private formBulder: FormBuilder,
    private productoService:ProductoService,
    private imagenService:ImagenProductoService) { }


  ngOnInit(): void {
    this.imagenProducto = new ImagenProducto;
    this.producto = new Producto;
    // this.producto.cantidadEnStock = 0;
    // this.producto.categoria = "none";
    // this.producto.imagenProducto = new ImagenProducto;
    // this.producto.nombreProducto= "";
    // this.producto.descripcion = "";
    // this.producto.tag = "none";
    // this.producto.valorUnitario =0;
    // this.registroProductoForm = this.formBulder.group(
    //  {
    //     inputNombreProducto : [this.producto.nombreProducto,Validators.required],
    //     //inputPrecio : [this.producto.valorUnitario,[Validators.required,Validators.min(1)]],
    //     //inputCantidadRegistrar:[this.producto.cantidadEnStock ,[Validators.required,Validators.min(1)]],
    //     //inputDescripcion: [this.producto.descripcion ,[Validators.required,Validators.min(1), Validators.max(200)]]
      
    //  });


  }

  get f() { return this.registroProductoForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.registroProductoForm.invalid) {
        return;
    }

   }


   onReset() {
    this.submitted = false;
    this.registroProductoForm.reset();
    }



  CargarImagen(event:HtmlInputEvent){
    if(event.target.files && event.target.files[0] ){
      
      this.imagenProducto.Imagen  = <File>event.target.files[0]
       //llenar imagen
      const reader = new FileReader;
      reader.onload = e => this.imagenSelected = reader.result;
      reader.readAsDataURL( this.imagenProducto.Imagen );
    }
  }

  add() {
    this.imagenService.post(this.imagenProducto).subscribe(c => {
      if (c != null) {

        this.producto.imagenProductoID  = c;
      }
    });

    // this.producto.imagenProductoID = this.imagenProducto.imagenProductoID;
     this.productoService.post(this.producto).subscribe(c => {
       if (c != null) {
         alert('Cliente registrado!');
         this.producto = c;
       }
     });
  }

}


