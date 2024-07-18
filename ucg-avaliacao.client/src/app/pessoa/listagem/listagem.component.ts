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
        console.log(result);
        this.pessoas = result;
      }),
      catchError(error => {
        console.error(error);
        return of([]);
      })
    ).subscribe();
  }

  removerPessoa(id: Guid) {
    this._pessoaService.postRemover(id).pipe(
      tap(result => {
        location.reload();
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

  excluir(oPessoa: pessoa) {
    if (confirm("Quer Remover?" + oPessoa.nome)) {
      this.removerPessoa(oPessoa.id);
    }
  }

  cadastrar() {
    this.router.navigateByUrl("cadastrar/", { state: { redirect: "cadastrar/" } });
  }

  get hasResult() {
    return this.pessoas && this.pessoas.length > 0;
  }
}
