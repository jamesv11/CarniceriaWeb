import { DetalleFactura } from "./DetalleFactura";

export class Factura {

    correo:string;
    fechaExpedicion:Date;
    detallesFacturas:DetalleFactura[];
    valorTotal:number;
    estadoFactura:string;

}
