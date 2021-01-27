import { ErrorHandler, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { CoreModule } from './core/core.module';
import { UsuariosComponent } from './features/usuarios/usuarios.component';
import { CadastrarComponent } from './features/usuarios/cadastrar/cadastrar.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2IziToastModule } from 'ng2-izitoast';
@NgModule({
  declarations: [
    AppComponent,
    UsuariosComponent,
    CadastrarComponent,
  ],
  imports: [
    AppRoutingModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    CommonModule,
    CoreModule,
    ReactiveFormsModule,
    Ng2IziToastModule,
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
