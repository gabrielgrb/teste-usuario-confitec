import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from '../../core/services/usuario.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor(
    public usuarioService: UsuarioService,
    public router: Router
  ) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.obterUsuarios();
  }

  // tslint:disable-next-line: typedef
  obterUsuarios() {
    this.usuarioService.getAll()
    .subscribe(
      data => {
        this.usuarioService.usuarios = data;
        console.log(data);
      },
      error => {
        console.log(error);
      });
  }

  editar(usuarioId: number): void {
    this.router.navigate(['/usuarios/editar/', usuarioId]);
  }

  adicionar(): void {
    this.router.navigate(['/usuarios/novo/']);
  }

  // tslint:disable-next-line: typedef
  async apagar(usuarioId: number) {
    await this.usuarioService.delete(usuarioId).toPromise();
    this.obterUsuarios();
  }
}
