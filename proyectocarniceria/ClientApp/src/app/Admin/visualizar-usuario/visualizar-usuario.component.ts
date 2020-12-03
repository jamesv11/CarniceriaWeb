import { Component, OnInit } from '@angular/core';
import { DataClienteService } from 'src/app/services/data-cliente.service';

@Component({
  selector: 'app-visualizar-usuario',
  templateUrl: './visualizar-usuario.component.html',
  styleUrls: ['./visualizar-usuario.component.css']
})
export class VisualizarUsuarioComponent implements OnInit {

  constructor(public dataCliente: DataClienteService) { }

  ngOnInit(): void {
  }

  idSeleccionado(correo:string)
  {
    console.log(correo);
  }

}
