import { HttpClient } from '@angular/common/http';
import { Inject,Injectable,EventEmitter  } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError,map,tap} from 'rxjs/operators';
import { Cliente } from '../Carniceria/models/cliente';
import { Producto } from '../Carniceria/models/producto';
import { ProductoCarne } from '../Carniceria/models/productoCarne';
import { DetalleFactura } from '../Carniceria/models/DetalleFactura';
import { Factura } from '../Carniceria/models/factura';
import { ProductoService } from './producto.service';
import * as signalR from "@aspnet/signalr";
import { Domiciliario } from '../Carniceria/models/domiciliario';


@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  signalReceived = new EventEmitter<Producto>();
  signalDomiciliarioReceived = new EventEmitter<Domiciliario>();

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
    private productoService: ProductoService)
   { 
      this.baseUrl = baseUrl;
      this.buildConnection();
      this.startConnection();
    }

    private buildConnection = () => {
      this.hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl(this.baseUrl+"Signalhub") //use your api adress here and make sure you use right hub name.
        .build();
    };
  
    private startConnection = () => {
      this.hubConnection
        .start()
        .then(() => {
          console.log("Connecion iniciada...");
          this.RegistroProductoEvents();
          this.RegistroDomiciliarioEvents() ;
        })
        .catch(err => {
          console.log("Error al iniciar coneccion: " + err);
  
          //if you get error try to start connection again after 3 seconds.
          setTimeout(function() {
            this.startConnection();
          }, 3000);
        });
    };
  
    private RegistroProductoEvents() {
      this.hubConnection.on("ProductoRegistrado", (data: Producto) => {
        this.signalReceived.emit(data);
      });
    }
    
    private RegistroDomiciliarioEvents() {
      this.hubConnection.on("DomiciliarioRegistrado", (datos: Domiciliario) => {
        this.signalDomiciliarioReceived.emit(datos);
      });
    } 


}
    
