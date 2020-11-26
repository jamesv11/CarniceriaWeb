import { Factura } from "./factura";

export class Cliente {
    personaID:number;
    nombre:string;
    apellido:string;
    correo:string;
    password:string;
    carrito : Factura;
}
