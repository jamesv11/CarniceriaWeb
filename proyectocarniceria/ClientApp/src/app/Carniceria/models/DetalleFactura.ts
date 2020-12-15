import { Producto } from "./producto";

export class DetalleFactura {

    ProductoId:number;
    productoDetalle:Producto;
    CantidadRequerida:number;
    ValorUnitario:number;
    SubTotal:number;
}
