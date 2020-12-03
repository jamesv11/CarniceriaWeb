import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  botonMenu(){
    this.desactivarIcono();
    this.añadirAnimacion();
    if(document.getElementById("caja-items").classList.contains("desactive")){

      document.getElementById("caja-items").classList.remove("desactive");
      

    }else{
      setTimeout(function() { 
        document.getElementById("caja-items").classList.add("desactive");
       }, 2980); 
    }
    
    
  }

  desactivarIcono(){
    if(document.getElementById("caja-items").classList.contains("desactive")){
      document.getElementById("Boton-cerrar").classList.remove("desactive");
      document.getElementById("Boton-abrir").classList.add("desactive");
    }else{
      document.getElementById("Boton-abrir").classList.remove("desactive");
      document.getElementById("Boton-cerrar").classList.add("desactive");
    }

  }

  añadirAnimacion(){
    if(document.getElementById("caja-items").classList.contains("desactive")){
      document.getElementById("caja-items").classList.remove("animacionCerrarMenu");
      document.getElementById("caja-items").classList.add("animacionAbrirMenu");
      document.getElementById("Items").classList.remove("animacionCerrarMenu");
      setTimeout(function() {
        
        document.getElementById("Items").classList.add("animacionAbrirMenu");
        document.getElementById("Items").classList.remove("desactive"); 
       }, 2000); 

    }else{
      document.getElementById("caja-items").classList.remove("animacionAbrirMenu");
      document.getElementById("caja-items").classList.add("animacionCerrarMenu");
      
      document.getElementById("Items").classList.remove("animacionAbrirMenu");
      document.getElementById("Items").classList.add("animacionCerrarMenu");
      document.getElementById("Items").classList.add("desactive");
    }
  }

  



}
