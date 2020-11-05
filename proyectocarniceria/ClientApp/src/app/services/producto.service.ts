import { HttpClient } from '@angular/common/http';
import { Inject,Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError,map,tap} from 'rxjs/operators';
import { Cliente } from '../Carniceria/models/cliente';
import { Producto } from '../Carniceria/models/producto';


@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }

    
    get(): Observable<Producto[]>{
      return this.http.get<Producto[]>(this.baseUrl + 'api/Producto')
      .pipe(
        tap(_=> this.handleErrorService.handleError<Producto[]>('Consulta producto',null))  
      );
    }
    post(producto: Producto): Observable<Producto>{
      return this.http.post<Producto>(this.baseUrl + 'api/Producto',producto).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Producto>('Registrar Cliente',null))
        );

    }
 
} 
