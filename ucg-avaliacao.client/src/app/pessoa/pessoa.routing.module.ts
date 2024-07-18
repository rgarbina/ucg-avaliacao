import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListagemPessoaComponent } from './listagem/listagem.component';
import { DetalhePessoaComponent } from './detalhe/detalhe-pessoa.component';

const routes: Routes = [
    {
        path: '',
        component: ListagemPessoaComponent
    },
    {
        path: 'visualizar/:id',
        component: DetalhePessoaComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class PessoaRoutingModule { }