import { Component, OnInit } from '@angular/core';
import { Domiciliario } from 'src/app/Carniceria/models/domiciliario';
import { DataDomiciliarioService } from 'src/app/services/data-domiciliario.service';
import { DomiciliarioService } from 'src/app/services/domiciliario.service';
import { SignalRService } from 'src/app/services/SignalRService.service';

@Component({
  selector: 'app-consultar-domiciliario',
  templateUrl: './consultar-domiciliario.component.html',
  styleUrls: ['./consultar-domiciliario.component.css']
})
export class ConsultarDomiciliarioComponent implements OnInit {

  searchText: string;
  domiciliarios: Domiciliario[];

  constructor(private domiciliarioService: DomiciliarioService,private dataDomiciliario : DataDomiciliarioService,
              private SignalRService:SignalRService) { 
    this.domiciliarioService.get().subscribe(result => 
      {
        this.domiciliarios = result;
      });
    this.SignalRService.signalDomiciliarioReceived.subscribe((signal:Domiciliario)=>{
        this.domiciliarios.push(signal);
    })
      
  }

  ngOnInit(): void {
   

   
  }
  selectedClient(domicilario : Domiciliario)
  {
    this.dataDomiciliario.domiciliario =  domicilario;
  }

}
