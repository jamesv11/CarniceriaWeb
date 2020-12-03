import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private autenticacion:AuthenticationService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser = this.autenticacion.currentUserValue;
    if(currentUser && currentUser.token){
      request = request.clone({
        setHeaders:{
          Autorization:`Bearer ${currentUser.token}`
        }
      });
    }
    return next.handle(request);
  }
}
