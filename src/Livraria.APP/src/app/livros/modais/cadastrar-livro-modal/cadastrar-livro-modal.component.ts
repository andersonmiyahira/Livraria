import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { LivroModel } from 'app/livros/models/livro.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastrar-livro-modal',
  templateUrl: './cadastrar-livro-modal.component.html',
  styleUrls: ['./cadastrar-livro-modal.component.css'],
  providers:[LivroModel]
})
export class CadastrarLivroModalComponent implements OnInit {

  @ViewChild('cadastrar') modal: NgbModal;
  @Output() onCloseModalCadastrar = new EventEmitter();

  private modalReference: NgbModalRef;
  private model : LivroModel;

  form: FormGroup;
  
  constructor(private modalService: NgbModal) { }

  ngOnInit() {
  }
  
  initFormControl() {

    this.form = new FormGroup({
      autor: new FormControl(this.model.autor, [
        Validators.required
      ]),
      titulo: new FormControl(this.model.titulo, [
        Validators.required
      ]),
      descricao: new FormControl(this.model.descricao, [
        Validators.required
      ]),
      edicao: new FormControl(this.model.edicao, [
        Validators.required
      ]),
      editora: new FormControl(this.model.editora, [
        Validators.required
      ]),
      idioma: new FormControl(this.model.idioma, [
        Validators.required
      ]),
      isbn: new FormControl(this.model.isbn, [
        Validators.required
      ])
    });
  }

  openModal(model) {

    this.model = model;
    this.initFormControl();
    this.modalReference = this.modalService.open(this.modal, { size: 'lg' });
  }

  salvar() {

    this.onCloseModalCadastrar.emit({ status: 'OK', model: this.model });
    this.modalReference.close();
  }
}
