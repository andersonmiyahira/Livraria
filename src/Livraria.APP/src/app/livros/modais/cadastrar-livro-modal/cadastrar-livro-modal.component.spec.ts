import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarLivroModalComponent } from './cadastrar-livro-modal.component';

describe('CadastrarLivroModalComponent', () => {
  let component: CadastrarLivroModalComponent;
  let fixture: ComponentFixture<CadastrarLivroModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastrarLivroModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastrarLivroModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
