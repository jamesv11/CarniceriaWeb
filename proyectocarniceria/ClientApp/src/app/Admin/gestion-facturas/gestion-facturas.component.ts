import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Factura } from 'src/app/Carniceria/models/factura';
import { DataFacturaService } from 'src/app/services/data-factura.service';
import { FacturaService } from 'src/app/services/factura.service';
import { ConsultarFacturaComponent } from '../consultar-factura/consultar-factura.component';
import { VisualizarFacturaComponent } from '../visualizar-factura/visualizar-factura.component';

@Component({
  selector: 'app-gestion-facturas',
  templateUrl: './gestion-facturas.component.html',
  styleUrls: ['./gestion-facturas.component.css']
})
export class GestionFacturasComponent implements OnInit {

  searchText: string;
  facturas: Factura[];

  constructor(private facturaService: FacturaService,private modalService: NgbModal,
    private dataFacturaService: DataFacturaService) {
    this.facturaService.get().subscribe(result => {
      this.facturas = result;
    });
   }

  ngOnInit(): void {
    
  }

  AbrirRegistro(factura:Factura){
    this.modalService.open(ConsultarFacturaComponent); 
    this.dataFacturaService.factura = factura;
    
  }

}
