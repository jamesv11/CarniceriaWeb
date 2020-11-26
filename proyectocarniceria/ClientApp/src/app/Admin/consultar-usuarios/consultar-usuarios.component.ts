import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/Carniceria/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-consultar-usuarios',
  templateUrl: './consultar-usuarios.component.html',
  styleUrls: ['./consultar-usuarios.component.css']
})
export class ConsultarUsuariosComponent implements OnInit {

  searchText: string;
  clientes: Cliente[];
  constructor(private clienteService :  ClienteService) { }

  ngOnInit(): void {
    this.clienteService.get().subscribe(result => 
      {
        this.clientes =  result;
      });
  }

  selectedClient(id :number)
  {
    console.log(id);
  }

}
