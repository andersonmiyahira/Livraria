import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { LivroService } from 'app/livros/livro.service';
import { LivroModel } from 'app/livros/models/livro.model';

@Component({
  selector: 'app-excluir-livro-modal',
  templateUrl: './excluir-livro-modal.component.html',
  styleUrls: ['./excluir-livro-modal.component.css']
})
export class ExcluirLivroModalComponent implements OnInit {
  
  @ViewChild('exclude') modal: NgbModal;
  @Output() onCloseModalExcluir = new EventEmitter();
  
  private modalReference: NgbModalRef;
  model: LivroModel;
  
  constructor(private modalService: NgbModal) { }

  ngOnInit() {
  }

  openModal(model) {

    this.model = model;
    this.modalReference = this.modalService.open(this.modal, { size: 'sm' });
  }

  excluir() {
    
    this.onCloseModalExcluir.emit({ status: 'OK', model: this.model });
    this.modalReference.close();
  }
}
