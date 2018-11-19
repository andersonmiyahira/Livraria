import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './routes/app-routing.module';
import { ApiService } from './services/api.service';

import { AppComponent } from './app.component';
import { NavBarComponent } from './menu/nav-bar.component';
import { LoadScreenComponent } from './load-screen/load-screen.component';
import { LoaderInterceptorService } from './shared/interceptors/load-screen.interceptor';
import { LoaderService } from './load-screen/service/load-screen.service';

import { ListarLivroComponent } from './livros/listar/listar-livro.component';
import { LivroService } from './livros/livro.service';
import { ExcluirLivroModalComponent } from './livros/modais/excluir-livro-modal/excluir-livro-modal.component';
import { CadastrarLivroModalComponent } from './livros/modais/cadastrar-livro-modal/cadastrar-livro-modal.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule.forRoot()
  ],
  declarations: [
    AppComponent,
    LoadScreenComponent,

    NavBarComponent,
    ListarLivroComponent,
    ExcluirLivroModalComponent,
    CadastrarLivroModalComponent,
  ],
  entryComponents: [
  ],
  exports: [
  ],
  providers: [
    ApiService,
    LoaderService,
    LivroService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
