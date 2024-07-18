import { Component, OnInit } from '@angular/core';
import { PessoaService } from '../services/pessoa-service';
import { pessoa } from '../model/pessoa-model';
import { Guid } from 'guid-typescript';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-pessoa-visualizar',
  templateUrl: './detalhe-pessoa.component.html',
  styleUrl: './detalhe-pessoa.component.css'
})
export class DetalhePessoaComponent implements OnInit {
  public title = 'UCG Avaliação';
  public pessoaId: string = Guid.EMPTY;
  public pessoa: pessoa | null = null;
  public dependentes: any[] = [];

  constructor(
    private _pessoaService: PessoaService,
    private route: ActivatedRoute
  ) {
    this.pessoaId = this.route.snapshot.params['id'];
  }

  ngOnInit() {
    this.getPessoa();
  }

  getPessoa() {
    this._pessoaService.getPorId(Guid.parse(this.pessoaId)).subscribe(
      (result) => {
        this.pessoa = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  get hasResult() {
    return this.pessoa;
  }

  get hasResultDependente() {
    return this.pessoa?.nomeDependentes;
  }
}
