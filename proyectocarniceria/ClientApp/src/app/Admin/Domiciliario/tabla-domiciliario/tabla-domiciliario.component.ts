import { Component, OnInit } from '@angular/core';
import { Domiciliario } from 'src/app/Carniceria/models/domiciliario';
import { DataDomiciliarioService } from 'src/app/services/data-domiciliario.service';
import { DomiciliarioService } from 'src/app/services/domiciliario.service';
import { SignalRService } from 'src/app/services/SignalRService.service';

@Component({
  selector: 'app-tabla-domiciliario',
  templateUrl: './tabla-domiciliario.component.html',
  styleUrls: ['./tabla-domiciliario.component.css']
})
export class TablaDomiciliarioComponent implements OnInit {
  searchText: string;
  domiciliarios: Domiciliario[];
  constructor(private domiciliarioService: DomiciliarioService,private dataDomiciliario : DataDomiciliarioService,
    private signalR: SignalRService
   ) {

    this.domiciliarioService.get().subscribe(result => 
      {
        this.domiciliarios = result;
      });

    this.signalR.signalDomiciliarioReceived.subscribe((data:Domiciliario)=>{
      this.domiciliarios.push(data);
    })  
    }

  ngOnInit(): void {
  }
  selectedClient(domicilario : Domiciliario)
  {
    this.dataDomiciliario.domiciliario =  domicilario;
  }

}
