import { HttpClient } from '@angular/common/http';
import { Inject,Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError,map,tap} from 'rxjs/operators';
import { Domiciliario } from '../Carniceria/models/domiciliario';

@Injectable({
  providedIn: 'root'
})
export class DomiciliarioService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }

    get(): Observable<Domiciliario[]>{
      return this.http.get<Domiciliario[]>(this.baseUrl + 'api/Domiciliario')
      .pipe(
        tap(_=> this.handleErrorService.handleError<Domiciliario[]>('Consulta Domiciliario',null))  
      );
    }
    post(domiciliario: Domiciliario): Observable<Domiciliario>{
      return this.http.post<Domiciliario>(this.baseUrl + 'api/Domiciliario',domiciliario).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Domiciliario>('Registrar Domiciliario',null))
        );
    }

}
