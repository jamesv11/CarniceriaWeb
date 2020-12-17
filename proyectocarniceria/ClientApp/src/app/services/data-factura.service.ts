import { Injectable } from '@angular/core';
import { Factura } from '../Carniceria/models/factura';
import { Pedido } from '../Carniceria/models/pedido';

@Injectable({
  providedIn: 'root'
})
export class DataFacturaService {

  pedido : Pedido;
  
  constructor() { }
}
