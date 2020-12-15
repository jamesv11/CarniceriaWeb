import { Injectable } from '@angular/core';
import { Domiciliario } from '../Carniceria/models/domiciliario';

@Injectable({
  providedIn: 'root'
})
export class DataDomiciliarioService {

  domiciliario: Domiciliario;

  constructor() { }
}
