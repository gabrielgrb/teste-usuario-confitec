import { Routes, RouterModule } from '@angular/router';
import { UsuariosComponent } from './features/usuarios/usuarios.component';
import { CadastrarComponent } from './features/usuarios/cadastrar/cadastrar.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {
      path: '',
      component: UsuariosComponent
  },
  {
      path: 'usuarios',
      children: [
        {
          path: '',
          component: UsuariosComponent
        },
        {
            path: 'novo',
            component: CadastrarComponent
        },
        {
          path: 'editar/:id',
          component: CadastrarComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
