import { Component, OnInit } from '@angular/core';
import { DataDomiciliarioService } from 'src/app/services/data-domiciliario.service';

@Component({
  selector: 'app-visualizar-domiciliario',
  templateUrl: './visualizar-domiciliario.component.html',
  styleUrls: ['./visualizar-domiciliario.component.css']
})
export class VisualizarDomiciliarioComponent implements OnInit {

  constructor(public dataDomiciliario : DataDomiciliarioService) { }

  ngOnInit(): void {
  }

}
