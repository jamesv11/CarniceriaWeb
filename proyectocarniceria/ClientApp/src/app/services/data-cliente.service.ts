import { Injectable } from '@angular/core';
import { NumericLiteral } from 'typescript';
import { Cliente } from '../Carniceria/models/cliente';

@Injectable({
  providedIn: 'root'
})
export class DataClienteService {

  cliente : Cliente;

  constructor() { }

  
}
