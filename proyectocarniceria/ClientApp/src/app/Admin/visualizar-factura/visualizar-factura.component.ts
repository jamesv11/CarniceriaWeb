import { Component, OnInit } from '@angular/core';
import { DetalleFactura } from 'src/app/Carniceria/models/DetalleFactura';
import { Factura } from 'src/app/Carniceria/models/factura';
import { DataFacturaService } from 'src/app/services/data-factura.service';

@Component({
  selector: 'app-visualizar-factura',
  templateUrl: './visualizar-factura.component.html',
  styleUrls: ['./visualizar-factura.component.css']
})
export class VisualizarFacturaComponent implements OnInit {

  constructor(public dataFacturaService : DataFacturaService) {
      
   }
  


  ngOnInit(): void {
  } 

}
