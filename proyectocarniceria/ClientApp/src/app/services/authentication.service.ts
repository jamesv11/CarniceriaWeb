import { HttpClient } from '@angular/common/http';
import { Injectable,Inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/internal/operators/map';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { User } from '../seguridad/User';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentUsersubject: BehaviorSubject<User>;
  public currentUser:Observable<User>;
  baseUrl: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') baseUrl:string,
              private handleErrorService:HandleHttpErrorService) {
                this.baseUrl = baseUrl;
                this.currentUsersubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
                this.currentUser = this.currentUsersubject.asObservable();
  }

  public get currentUserValue():User{
    return this.currentUsersubject.value;
  }

  login(correo:string,password:string){
    return this.http.post<any>(`${this.baseUrl}api/login`,{correo,password})
    .pipe(map(user => {
      // store user and jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('currentUser', JSON.stringify(user));
      this.currentUsersubject.next(user);
      return user;
      }));
     }
     
}
