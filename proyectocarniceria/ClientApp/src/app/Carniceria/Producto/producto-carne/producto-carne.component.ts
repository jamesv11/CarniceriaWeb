import { Component, OnInit } from '@angular/core';
import { ImagenProductoService } from 'src/app/services/ImagenProducto.service';
import { ImagenProducto } from '../../models/ImagenProducto';

@Component({
  selector: 'app-producto-carne',
  templateUrl: './producto-carne.component.html',
  styleUrls: ['./producto-carne.component.css']
})
export class ProductoCarneComponent implements OnInit {

  
  productoImagen:ImagenProducto;
  buscar:string;
  constructor(private ImagenService:ImagenProductoService) { }

  ngOnInit(): void {
    this.productoImagen = new ImagenProducto();
  }

  Buscar(){
    this.ImagenService.get(this.buscar).subscribe(p => {
      if (p != null) {
        alert('Imagen Encontrada');
        this.productoImagen = p;
      }
    })
  }

}
