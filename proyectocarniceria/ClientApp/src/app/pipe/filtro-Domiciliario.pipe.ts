import { Pipe, PipeTransform } from '@angular/core';
import { Domiciliario } from '../Carniceria/models/domiciliario';

@Pipe({
  name: 'filtroDomiciliario'
})
export class FiltroDomiciliarioPipe implements PipeTransform {

  transform(domiciliarios: Domiciliario[], searchText: string): any {
    if(searchText == null) return domiciliarios;
    return domiciliarios.filter(p => p.persona.nombre.toLowerCase()
    .indexOf(searchText.toLowerCase()) != -1 || p.persona.rol.toLowerCase().indexOf(searchText.toLowerCase()) != -1);
  }

}
