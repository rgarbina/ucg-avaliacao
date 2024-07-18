import { Component, OnInit } from '@angular/core';
import { PessoaService } from '../services/pessoa-service';
import { pessoa } from '../model/pessoa-model';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { catchError, of, tap } from 'rxjs';

@Component({
  selector: 'app-pessoa-listagem',
  templateUrl: './listagem.component.html',
  styleUrl: './listagem.component.css'
})
export class ListagemPessoaComponent implements OnInit {
  public title = 'UCG Avaliação';
  public pessoas: pessoa[] = [];

  constructor(
    private _pessoaService: PessoaService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.getPessoas();
  }


  getPessoas() {
    this._pessoaService.getTodas().pipe(
      tap(result => {
        this.pessoas = result;
      }),
      catchError(error => {
        console.error(error);
        return of([]);
      })
    ).subscribe();
  }

  visualizar(id: Guid) {
    this.router.navigate(["visualizar/" + id], { relativeTo: this.route });
  }

  editar() {
    alert('Editar não implementado!');
  }

  excluir() {
    alert('Excluir não implementado!');
  }

  cadastrar() {
    alert('Cadastrar não implementado!');
  }

  get hasResult() {
    return this.pessoas && this.pessoas.length > 0;
  }
}
