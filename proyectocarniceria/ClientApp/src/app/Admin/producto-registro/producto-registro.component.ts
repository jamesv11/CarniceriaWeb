
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {Observable} from 'rxjs';
import {debounceTime, distinctUntilChanged, map, startWith} from 'rxjs/operators';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Producto } from 'src/app/Carniceria/models/producto';
import { ProductoCarne } from 'src/app/Carniceria/models/productoCarne';
import { ProductoService } from 'src/app/services/producto.service';

interface HtmlInputEvent extends Event{
  target: HTMLInputElement & EventTarget;
}


  

@Component({
  selector: 'app-producto-registro',
  templateUrl: './producto-registro.component.html',
  styleUrls: ['./producto-registro.component.css']
})
export class ProductoRegistroComponent implements OnInit {
  myControl = new FormControl();
  options: string[] = ['Cola', 'Centro de pierna', 'Punta de anca', 'Lomito', 'Bola', 'Cadera', 'Muchacho',
  'Bota', 'Murillo', 'Sobrebarriga', 'Costilla', 'Chatas churrasco', 'Bola de brazo',
  'Falda', ' Pecho', 'Paletero', 'Morrillo'];
  filteredOptions: Observable<string[]>;
  carneRes : any;
  categoria: any;
  ImagenBase64:any;
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
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }
  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().indexOf(filterValue) === 0);
  }

  crearFormGroupProducto()
  {
      return this.formBuilder.group(
        {
        categoria : ["",Validators.required],
        nombreProducto : ["",Validators.required],
        descripcion : ["",Validators.required],
        valorUnitario : [,Validators.required],
        cantidad : [,Validators.required],
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
    if(this.categoria == "Res")
    {
      this.addCarne();
    }
    else
    {
      this.add();
    }
    
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
  addCarne() {
    console.log(this.carneRes);
    this.productoCarne = new ProductoCarne();
    this.productoCarne = this.registroProductoForm.value;
    this.productoCarne.corteRes =  this.carneRes;
    this.productoCarne.imagenProducto = this.ImagenBase64;
    console.log(this.productoCarne);
    this.productoService.postRes(this.productoCarne).subscribe((p) => {
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
    } 
  }
}
