import { HttpClient } from '@angular/common/http';
import { Inject,Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError,map,tap} from 'rxjs/operators';
import { Cliente } from '../Carniceria/models/cliente';
import { Producto } from '../Carniceria/models/producto';
import { ProductoCarne } from '../Carniceria/models/productoCarne';
import { DetalleFactura } from '../Carniceria/models/DetalleFactura';
import { Factura } from '../Carniceria/models/factura';
import { ProductoService } from './producto.service';


@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
    private productoService: ProductoService)
   { 
      this.baseUrl = baseUrl;
    }



    

    Post(factura:Factura): Observable<Factura>{
      
      return this.http.post<Factura>(this.baseUrl + 'api/Factura',factura).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Factura>('Registrar Cliente',null))
      );

    }

    get() : Observable<Factura[]>{
      return this.http.get<Factura[]>(this.baseUrl + 'api/factura').pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Factura[]>('Registrar Cliente',null))
      );
    }






}
    
