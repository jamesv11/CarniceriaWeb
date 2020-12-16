import { Producto } from "./producto";

export class DetalleFactura {

    productoId:number;
    productoDetalle:Producto;
    cantidadRequerida:number;
    valorUnitario:number;
    valorNeto:number;
}
