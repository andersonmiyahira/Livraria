import { Injectable } from '@angular/core';
import { ApiService } from 'app/services/api.service';
import { ServiceBase } from 'app/shared/services/service-base';
import { map } from 'rxjs/operators';

import { LivroModel } from './models/livro.model';
import { Observable } from 'rxjs';

@Injectable()
export class LivroService extends ServiceBase {

  constructor(private apiService: ApiService) {
    super("livro");
  }

  obterLivros(): Observable<any> {

    return this.apiService.get(this.urlAPI).pipe(
      map((res: any) => {
        return <LivroModel[]>res.data;
      }));
  }

  obterLivroPorId(id: string): Observable<any> {

    return this.apiService.get(this.urlAPI + id).pipe(
      map((res: any) => {
        return <LivroModel[]>res.data;
      }));
  }

  salvarLivro(model: LivroModel) {

    return this.apiService.post(this.urlAPI, model).pipe(
      map((res: any) => {
        return <LivroModel>res.data;
      }));
  } 

  atualizarLivro(model: LivroModel) {

    return this.apiService.put(this.urlAPI, model).pipe(
      map((res: any) => {
        return <LivroModel>res.data;
      }));
  } 
   
  excluirLivro(model: LivroModel) {

    return this.apiService.delete(this.urlAPI, model.id).pipe(
      map((res: any) => {
        return <LivroModel>res.data;
      }));
  }
}
