import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SimpleNotificationsModule } from 'angular2-notifications';

import { AppRoutingModule } from './routes/app-routing.module';
import { ApiService } from './services/api.service';

import { AppComponent } from './app.component';
import { NavBarComponent } from './menu/nav-bar.component';
import { LoadScreenComponent } from './load-screen/load-screen.component';
import { LoaderInterceptorService } from './shared/interceptors/load-screen.interceptor';
import { LoaderService } from './load-screen/service/load-screen.service';
import { LivroModule } from './livros/livro.module';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule, 
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule.forRoot(),
    SimpleNotificationsModule.forRoot(),

    LivroModule
  ],
  declarations: [
    AppComponent,
    LoadScreenComponent,
    NavBarComponent,
  ],
  entryComponents: [
  ],
  exports: [
  ],
  providers: [
    ApiService,
    LoaderService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
