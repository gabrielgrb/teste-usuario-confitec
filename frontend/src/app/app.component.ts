import { Component, OnInit } from '@angular/core';
import { User } from './models/user';
import { UsuarioService } from './services/usuario.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  users: any;
  userForm: boolean;
  isNewUser: boolean;
  newUser: any = {};
  editUserForm: boolean;
  editedUser: any = {};

  constructor(
    public usuarioService: UsuarioService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers(): any {
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

  showEditUserForm(user: User) {
    if (!user) {
      this.userForm = false;
      return;
    }
  
    this.usuarioService.get(user.id)
    .subscribe(
      data => {
        this.editedUser = data;
        this.editUserForm = true;
        console.log(data);
      },
      error => {
        console.log(error);
      });
    
  }

  showAddUserForm() {
    // resets form if edited user
    if (this.usuarioService.usuarios && this.usuarioService.usuarios.length) {
      this.newUser = {};
    }
    this.userForm = true;
    this.isNewUser = true;

  }

  async salvarUsuario(user: any) {
    if (this.isNewUser) {
    await this.usuarioService.create(user).toPromise();
    this.getUsers()
   }
  }

  async atualizarUsuario() {
    await this.usuarioService.create(this.editedUser).toPromise();
    this.getUsers()

    this.userForm = false;
    this.editUserForm = false;
    this.editedUser = {};
  }

  removeUser(user: any) {
    this.usuarioService.delete(user.id)
      .subscribe(
        response => {
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  cancelarEdicao() {
    this.editedUser = {};
    this.editUserForm = false;
  }

  cancelar() {
    this.newUser = {};
    this.userForm = false;
  }

}
