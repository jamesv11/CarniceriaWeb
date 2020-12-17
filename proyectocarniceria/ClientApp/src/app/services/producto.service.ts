import { HttpClient } from '@angular/common/http';
import { Inject,Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError,map,tap} from 'rxjs/operators';
import { Cliente } from '../Carniceria/models/cliente';
import { Producto } from '../Carniceria/models/producto';
import { ProductoCarne } from '../Carniceria/models/productoCarne';
import { DetalleFactura } from '../Carniceria/models/DetalleFactura';


@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  private ListaProductossubject: BehaviorSubject<DetalleFactura[]>;
  public ListaProductos: Observable<DetalleFactura[]>;
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
      this.baseUrl = baseUrl;
      this.ListaProductossubject = new BehaviorSubject<DetalleFactura[]>(
        JSON.parse(localStorage.getItem("ListaProducto"))
      );
      this.ListaProductos = this.ListaProductossubject.asObservable();
    }

    public get ProductosValues(): DetalleFactura[] {
      return this.ListaProductossubject.value;
    }

    
    get(): Observable<Producto []>{
      return this.http.get<Producto[]>(this.baseUrl + 'api/Producto')
      .pipe(
        tap(_=> this.handleErrorService.handleError<Producto[]>('Consulta todo los productos',null))  
      );
    }
    getCarnes(): Observable<ProductoCarne[]>{
      return this.http.get<ProductoCarne[]>(this.baseUrl + 'api/Producto/Res')
      .pipe(
        tap(_=> this.handleErrorService.handleError<ProductoCarne[]>('Consulta todo los productos',null))  
      );
    }

    post(producto: Producto): Observable<Producto>{

      return this.http.post<Producto>(this.baseUrl + 'api/Producto',producto).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Producto>('Registrar Cliente',null))
      );

    }
    postRes(producto: ProductoCarne): Observable<ProductoCarne>{
      return this.http.post<ProductoCarne>(this.baseUrl + 'api/Producto/Res',producto).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<ProductoCarne>('Registrar Producto Carne',null))
        );

    }
    AñadirCarrito(Producto:Producto,Cantidad:number){
      var ListaProductos = this.ProductosValues;   
      if(ListaProductos !=null){
        ListaProductos.push(this.CrearDetalle(Producto,Cantidad));
        localStorage.setItem("ListaProducto", JSON.stringify(ListaProductos));
        this.ListaProductossubject.next(ListaProductos);
      }
      else{
        var nuevaLista = [this.CrearDetalle(Producto,Cantidad)];
        localStorage.setItem("ListaProducto", JSON.stringify(nuevaLista));
        this.ListaProductossubject.next(nuevaLista);
      }
    }
    CrearDetalle(Producto:Producto,cantidad:number):DetalleFactura{
      var nuevaFactura = new DetalleFactura;
      nuevaFactura.productoDetalle = Producto;
      nuevaFactura.productoId = Producto.productoId;
      nuevaFactura.cantidadRequerida = cantidad;
      nuevaFactura.valorUnitario = Producto.valorUnitario;
      nuevaFactura.valorNeto = Producto.valorUnitario * cantidad;
      return nuevaFactura;
    }
    removeDetalle(DetalleFactura){
      var varlistaProducto = this.ProductosValues;
      var nuevaLista = varlistaProducto.filter( function( e ) {
        return e !== DetalleFactura;
      } );
      localStorage.setItem("ListaProducto", JSON.stringify(nuevaLista));
      this.ListaProductossubject.next(nuevaLista);
    }

    ActualizaLista(nuevaLista){
      localStorage.setItem("ListaProducto", JSON.stringify(nuevaLista));
      this.ListaProductossubject.next(nuevaLista);
    }
    LimpiarLista(){
      var nuevaLista = [];
      localStorage.setItem("ListaProducto", JSON.stringify(nuevaLista));
      this.ListaProductossubject.next(nuevaLista);
    }
    put(Productos:Producto[]): Observable<Producto[]>{
      return this.http.put<Producto []>(this.baseUrl + 'api/Producto',Productos).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Producto []>('Modificar productos',null))
        );
    }
}
    
