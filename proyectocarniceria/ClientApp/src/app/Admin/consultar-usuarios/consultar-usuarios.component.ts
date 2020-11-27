import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Cliente } from 'src/app/Carniceria/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';
import { DataClienteService } from 'src/app/services/data-cliente.service';

@Component({
  selector: 'app-consultar-usuarios',
  templateUrl: './consultar-usuarios.component.html',
  styleUrls: ['./consultar-usuarios.component.css']
})
export class ConsultarUsuariosComponent implements OnInit {

  searchText: string;
  clientes: Cliente[];
 

  constructor(private clienteService :  ClienteService, private dataCliente: DataClienteService) { }

  ngOnInit(): void {
    this.clienteService.get().subscribe(result => 
      {
        this.clientes =  result;
      });
  }

  selectedClient(cliente : Cliente)
  {
    this.dataCliente.cliente =  cliente;
  }



}
