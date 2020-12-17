import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignarUsuarioComponent } from './asignar-usuario.component';

describe('AsignarUsuarioComponent', () => {
  let component: AsignarUsuarioComponent;
  let fixture: ComponentFixture<AsignarUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AsignarUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AsignarUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
