import { Pipe, PipeTransform } from '@angular/core';
import { Domiciliario } from '../Carniceria/models/domiciliario';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(domiciliarios: Domiciliario[], searchText: string): any {
    if(searchText == null) return domiciliarios;
    return domiciliarios.filter(p => p.nombre.toLowerCase()
    .indexOf(searchText.toLowerCase()) != -1 || p.identificacion.toLowerCase().indexOf(searchText.toLowerCase()) != -1);
  }

}
