import { Pipe, PipeTransform } from '@angular/core';
import { Producto } from '../Carniceria/models/producto';

@Pipe({
  name: 'filtroProducto'
})
export class FiltroProductoPipe implements PipeTransform {

  transform(Productos:Producto[],Categoria:string): any {
    if(Productos== null) return Productos ;
    return Productos.filter(p =>
      p.categoria.toLowerCase()
     .indexOf(Categoria.toLowerCase()) !== -1);
     
  }

}
