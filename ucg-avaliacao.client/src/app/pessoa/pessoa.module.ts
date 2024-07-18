import { NgModule } from '@angular/core';
import { ListagemPessoaComponent } from './listagem/listagem.component';
import { PessoaRoutingModule } from './pessoa.routing.module';
import { PessoaService } from './services/pessoa-service';
import { CommonModule } from '@angular/common';
import { DetalhePessoaComponent } from './detalhe/detalhe-pessoa.component';
import { CadastrarPessoaComponent } from './cadastrar/cadastrar-pessoa.component';

import { RouterModule } from '@angular/router';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    PessoaRoutingModule
  ],
  declarations: [
    ListagemPessoaComponent,
    DetalhePessoaComponent,
    CadastrarPessoaComponent
  ],
  providers: [PessoaService],
  exports: [],
  bootstrap: [
    ListagemPessoaComponent,
    CadastrarPessoaComponent
  ]
})

export class PessoaModule { }
