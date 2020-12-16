import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { DataFacturaService } from 'src/app/services/data-factura.service';

@Component({
  selector: 'app-consultar-factura',
  templateUrl: './consultar-factura.component.html',
  styleUrls: ['./consultar-factura.component.css']
})
export class ConsultarFacturaComponent implements OnInit {

  constructor(public dataFacturaService : DataFacturaService,public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

}
