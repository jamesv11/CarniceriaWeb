import { Pipe, PipeTransform } from '@angular/core';
import { Producto } from '../Carniceria/models/producto';

@Pipe({
  name: 'filtroBusquedaProducto'
})
export class FiltroBusquedaProductoPipe implements PipeTransform {

  transform(Productos:Producto[],Nombre:string): any {
    if(Productos== null) return Productos ;
    return Productos.filter(p =>
      p.nombreProducto.toLowerCase()
     .indexOf(Nombre.toLowerCase()) !== -1);
     
  }

}
