import { Injectable } from '@angular/core';
import { Ng2IzitoastService } from 'ng2-izitoast';

@Injectable({
  providedIn: 'root'
})
export class AlertaService {
  constructor(
    public iziToast: Ng2IzitoastService
  ) { }

  // tslint:disable-next-line: typedef
  informarErro(titulo: string, mensagem: string, posicao: string = 'topRight') {
    this.iziToast.error({
        title: titulo,
        message: mensagem,
        position: posicao
    });
    return;
  }

  // tslint:disable-next-line: typedef
  informarErroEVoltar(titulo: string, mensagem: string, posicao: string = 'topCenter') {
    this.iziToast.error({
        title: titulo,
        message: mensagem,
        position: posicao,
        // tslint:disable-next-line: typedef
        onClosed() { history.back(); }
    });
    return;
  }

  // tslint:disable-next-line: typedef
  informarMensagem(titulo: string, mensagem: string, posicao: string = 'topRight') {
    this.iziToast.warning({
        title: titulo,
        message: mensagem,
        position: posicao
    });
    return;
  }

  // tslint:disable-next-line: typedef
  informarSucesso(titulo: string, mensagem: string, posicao: string = 'topRight') {
    this.iziToast.success({
        title: titulo,
        message: mensagem,
        position: posicao
    });
    return;
  }
}

