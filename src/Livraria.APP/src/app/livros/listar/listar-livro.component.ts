import { Component, OnInit, ViewChild } from '@angular/core';
import { LivroModel } from '../models/livro.model';
import { FormGroup } from '@angular/forms';
import { LivroService } from '../livro.service';
import { ExcluirLivroModalComponent } from '../modais/excluir-livro-modal/excluir-livro-modal.component';
import { CadastrarLivroModalComponent } from '../modais/cadastrar-livro-modal/cadastrar-livro-modal.component';
import { NotificationsService } from 'angular2-notifications';

@Component({
  selector: 'app-listar-livro',
  templateUrl: './listar-livro.component.html',
  styleUrls: ['./listar-livro.component.css'],
  providers: [LivroModel]
})
export class ListarLivroComponent implements OnInit {

  @ViewChild("modalExcluir") modalExcluir: ExcluirLivroModalComponent;
  @ViewChild("modalCadastrar") modalCadastrar: CadastrarLivroModalComponent;

  livros: Array<LivroModel>;
  model: LivroModel;

  public form: FormGroup;

  constructor(private livroService: LivroService,
    private _notifications: NotificationsService) { }

  ngOnInit() {

    this.obterLivros();
  }

  obterLivros() {

    this.livroService.obterLivros().subscribe(res => {
      this.livros = res;
    });
  }

  excluirOpenModal(model) {

    this.modalExcluir.openModal(model);
  }

  closeModalExcluir(result) {

    if (result.status === 'OK') {
      this.livroService.excluirLivro(result.model).subscribe(res => {

        this._notifications.success("Sucesso", "Livro excluído com sucesso.");
        var indexObjExcluido = this.livros.findIndex(_ => _.id == result.model.id);
        this.livros.splice(indexObjExcluido, 1);
      });
    }
  }

  novoOpenModal() {

    this.cadastrarOpenModal(new LivroModel());
  }

  cadastrarOpenModal(model) {

    this.modalCadastrar.openModal(model);
  }

  closeModalCadastrar(result) {

    if (result.status === 'OK') {
      if (result.model.id) {
        this.livroService.atualizarLivro(result.model).subscribe(res => {
        
          this._notifications.success("Sucesso", "Livro atualizado com sucesso.");
          this.obterLivros();
        });
      }
      else {
        this.livroService.salvarLivro(result.model).subscribe(res => {

          this._notifications.success("Sucesso", "Livro inserido com sucesso.");
          this.obterLivros();
        });
      }
    }
  }

}
