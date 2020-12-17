import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { DataFacturaService } from 'src/app/services/data-factura.service';

@Component({
  selector: 'app-pedidos-usuario',
  templateUrl: './pedidos-usuario.component.html',
  styleUrls: ['./pedidos-usuario.component.css']
})
export class PedidosUsuarioComponent implements OnInit {

  constructor(public dataFacturaService : DataFacturaService,public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

}
