import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Pedido } from '../Carniceria/models/pedido';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }

    get(): Observable<Pedido[]>{
      return this.http.get<Pedido[]>(this.baseUrl + 'api/Pedido')
      .pipe(
        tap(_=> this.handleErrorService.handleError<Pedido[]>('Consulta Pedido',null))  
      );
    }
    put(pedido: Pedido): Observable<Pedido>{
      return this.http.put<Pedido>(this.baseUrl + 'api/Cliente',pedido).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Pedido>('Modificar Pedido',null))
        );
    }
 
}
