import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from '../../../core/services/alerta.service';
import { UsuarioService } from '../../../core/services/usuario.service';
import * as moment from 'moment';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.css']
})
export class CadastrarComponent implements OnInit {
  novoUsuario: any = {};
  usuarioId: number;
  possuiErro = false;

  form = new FormGroup({
    nome: new FormControl('', [Validators.required, Validators.minLength(3)]),
    sobrenome: new FormControl('', [Validators.required, Validators.email]),
    email: new FormControl('', Validators.required),
    dataNascimento: new FormControl('', Validators.required),
    escolaridade: new FormControl('', Validators.required)
  });

  constructor(
    private router: Router,
    private usuarioService: UsuarioService,
    private alertaService: AlertaService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.usuarioId = this.activatedRoute.snapshot.params.id;
    if (this.usuarioId && this.usuarioId > 0) {
      this.popularCampos();
    }
  }

  // tslint:disable-next-line: typedef
  async popularCampos() {
    const usuario = await this.usuarioService.get(this.usuarioId).toPromise().catch((e) => this.mostrarErro(e.error));
    const dataFormatada = moment(usuario.dataNascimentoFormatada, 'DD/MM/YYYY', true).format('YYYY-MM-DD');

    this.form.get('nome').setValue(usuario.nome);
    this.form.get('sobrenome').setValue(usuario.sobrenome);
    this.form.get('email').setValue(usuario.email);
    this.form.get('dataNascimento').setValue(dataFormatada);
    this.form.get('escolaridade').setValue(usuario.escolaridade);
  }

  submit(): void {
    console.log(this.form.controls);
  }

  get f(){
    return this.form.controls;
  }

  voltar(): void {
    this.router.navigateByUrl('');
  }

  // tslint:disable-next-line: typedef
  async salvar() {
    const usuario = this.obterUsuario();
    await this.usuarioService.create(usuario).toPromise().catch((e) => this.mostrarErro(e.error));

    if (!this.possuiErro) {
      this.router.navigateByUrl('');
    }

  }

  mostrarErro(error: any): any {
    if (error) {
      this.possuiErro = true;
      const errorType = typeof(error.errorMessages);
      const errorIsString = errorType === 'string';
      const erros = Array.isArray(error.errorMessages) ? error : JSON.parse(error.errorMessages);
      let texto = '';

      if (errorIsString) {
        return error;
      }

      erros.errorMessages.forEach(erro => {
        texto += '<span>- ' + erro + '</span><br>';
      });
      this.alertaService.informarErro('Atenção', texto);
    }
  }

  obterUsuario(): any{
    return {
      id: (this.usuarioId && this.usuarioId > 0) ? this.usuarioId : 0,
      nome: this.form.get('nome').value,
      sobrenome: this.form.get('sobrenome').value,
      email: this.form.get('email').value,
      dataNascimento: this.form.get('dataNascimento').value,
      escolaridade: this.form.get('escolaridade').value,
    };
  }
}
