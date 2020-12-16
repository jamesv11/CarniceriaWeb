import { Injectable } from '@angular/core';
import { Factura } from '../Carniceria/models/factura';

@Injectable({
  providedIn: 'root'
})
export class DataFacturaService {

  factura : Factura;
  
  constructor() { }
}
