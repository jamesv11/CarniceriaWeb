import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanDeactivate, CanLoad, Route, Router,  UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate{

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {}


  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot){
    const currentUser = this.authenticationService.currentUserValue;
    if(currentUser){
      return true;
    }
    this.router.navigate(['/usuarioLogin'], { queryParams: { returnUrl: state.url }});
    return false;
  }

}
