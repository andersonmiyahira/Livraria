import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirLivroModalComponent } from './excluir-livro-modal.component';

describe('ExcluirLivroModalComponent', () => {
  let component: ExcluirLivroModalComponent;
  let fixture: ComponentFixture<ExcluirLivroModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExcluirLivroModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExcluirLivroModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
