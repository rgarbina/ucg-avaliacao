import { Component, OnInit } from '@angular/core';
import { PessoaService } from '../services/pessoa-service';
import { pessoa } from '../model/pessoa-model';
import { Guid } from 'guid-typescript';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-pessoa-cadastrar',
  templateUrl: './cadastrar-pessoa.component.html',
  styleUrl: './cadastrar-pessoa.component.css'
})
export class CadastrarPessoaComponent implements OnInit {
  public title = 'UCG Avaliação';
  public pessoaId: string = Guid.EMPTY;
  public pessoa: pessoa | null = null;
  public dependentes: any[] = [];
  public pessoaForm = new FormControl('');  

  constructor(
    private _pessoaService: PessoaService,
    private route: ActivatedRoute
  ) {
    this.pessoaId = this.route.snapshot.params['id'];
  }

  ngOnInit() {

 
  }

  adicionar() {

  }

  get hasResult() {
    return this.pessoa;
  }
}
