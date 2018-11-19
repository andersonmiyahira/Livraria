import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListarLivroComponent } from './listar/listar-livro.component';
import { LivroService } from './livro.service';
import { RouterModule } from '@angular/router';
import { ExcluirLivroModalComponent } from './modais/excluir-livro-modal/excluir-livro-modal.component';
import { CadastrarLivroModalComponent } from './modais/cadastrar-livro-modal/cadastrar-livro-modal.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ],
    declarations: [
        ListarLivroComponent,
        ExcluirLivroModalComponent,
        CadastrarLivroModalComponent
    ],
    providers: [
        LivroService,
    ]
})
export class LivroModule {

}