import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarLivroComponent } from 'app/livros/listar/listar-livro.component';

const routes: Routes = [
  { path: '', redirectTo: '/livros', pathMatch: 'full' },
  {
    path: "livros",
    component: ListarLivroComponent
  } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
