import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CarritoComponent } from '../Carniceria/Compra/carrito/carrito.component';
import { User } from '../seguridad/User';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  currentUser:User;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
      ) {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
      }
    

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  abrirCarrito(){
    var btnAbrir = document.getElementById("overlay");
    btnAbrir.classList.add("active");
  }

  cerrarCarrito(){
    var btnAbrir = document.getElementById("overlay");
    btnAbrir.classList.remove("active");
  }

    logout() {     
        this.authenticationService.logout();
        this.router.navigate(['/login']);
      }
    
}
