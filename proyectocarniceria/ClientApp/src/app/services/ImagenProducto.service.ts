import { HttpClient } from '@angular/common/http';
import { Inject,Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError,map,tap} from 'rxjs/operators';
import { Cliente } from '../Carniceria/models/cliente';
import { Producto } from '../Carniceria/models/producto';
import { ImagenProducto } from '../Carniceria/models/ImagenProducto';


@Injectable({
  providedIn: 'root'
})
export class ImagenProductoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
    }

    
    get(IdImagen:string): Observable<ImagenProducto>{
      return this.http.get<ImagenProducto>(this.baseUrl + 'api/Producto/Imagen/'+IdImagen)
      .pipe(
        tap(_=> this.handleErrorService.handleError<ImagenProducto>('Consulta imagen producto',null))  
      );
    }
    post(imagenProducto: ImagenProducto): Observable<number>{
      const formData = new FormData();
      formData.append('file', imagenProducto.Imagen, imagenProducto.Imagen.name);

      return this.http.post<number>(this.baseUrl + 'api/ImagenProducto',formData).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<number>('Registrar Cliente',null))
        );

    }


    
 
} 
