import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-usuario-login',
  templateUrl: './usuario-login.component.html',
  styleUrls: ['./usuario-login.component.css']
})
export class UsuarioLoginComponent implements OnInit {

  loginFrom: FormGroup;
  loading: boolean;
  submitted: boolean;
  returnUrl: String;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private autenticacion: AuthenticationService,
    private modalService: NgbModal,
  ) {
    if(this.autenticacion.currentUserValue){
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    this.loginFrom = this.formBuilder.group({
      correo:['',Validators.required],
      password:['',Validators.required]
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f (){return this.loginFrom.controls;}

  onSubmit(){
    this.submitted = true; 
    if(this.loginFrom.invalid){
      return;
    }

    this.loading = true;
    this.autenticacion.login(this.f.correo.value,this.f.password.value).pipe(first()).subscribe(data=>{
      this.router.navigate([this.returnUrl]);
    },error=>{
      const modalRef = this.modalService.open(AlertModalComponent);
      modalRef.componentInstance.title = 'Acceso Denegado';
      modalRef.componentInstance.message = error.error;
      this.loading = false;
    });
    
  }

}
