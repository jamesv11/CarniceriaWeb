import { Component, OnInit } from '@angular/core';
import { Factura } from 'src/app/Carniceria/models/factura';
import { FacturaService } from 'src/app/services/factura.service';

@Component({
  selector: 'app-gestion-facturas',
  templateUrl: './gestion-facturas.component.html',
  styleUrls: ['./gestion-facturas.component.css']
})
export class GestionFacturasComponent implements OnInit {

  searchText: string;
  facturas: Factura[];

  constructor(private facturaService: FacturaService) {
    this.facturaService.get().subscribe(result => {
      this.facturas = result;
    });
   }

  ngOnInit(): void {
    
  }

}
