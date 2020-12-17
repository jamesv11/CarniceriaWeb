import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Factura } from 'src/app/Carniceria/models/factura';
import { Pedido } from 'src/app/Carniceria/models/pedido';
import { DataFacturaService } from 'src/app/services/data-factura.service';
import { FacturaService } from 'src/app/services/factura.service';
import { PedidoService } from 'src/app/services/pedido.service';
import { ConsultarFacturaComponent } from '../consultar-factura/consultar-factura.component';
import { TablaDomiciliarioComponent } from '../Domiciliario/tabla-domiciliario/tabla-domiciliario.component';
import { VisualizarFacturaComponent } from '../visualizar-factura/visualizar-factura.component';

@Component({
  selector: 'app-gestion-facturas',
  templateUrl: './gestion-facturas.component.html',
  styleUrls: ['./gestion-facturas.component.css']
})
export class GestionFacturasComponent implements OnInit {

  searchText: string;
  pedidos: Pedido[];

  constructor(private pedidoService: PedidoService,private modalService: NgbModal,
    private dataFacturaService: DataFacturaService) {
    this.pedidoService.get().subscribe(result => {
      this.pedidos = result;
    });
   }

  ngOnInit(): void {
    
  }

  AbrirRegistro(pedido:Pedido){
    this.modalService.open(ConsultarFacturaComponent); 
    this.dataFacturaService.pedido = pedido;
    
  }

  AbrirTablaDomiciliario(){
    this.modalService.open(TablaDomiciliarioComponent, { size: 'xl' });
  }

}
