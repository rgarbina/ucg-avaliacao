import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { pessoa } from "../model/pessoa-model";
import { Guid } from "guid-typescript";

@Injectable()
export class PessoaService {
  readonly backUrl = 'https://localhost:44359'

  constructor(private http: HttpClient) { }

    getTodas() {
      return this.http.get<pessoa[]>(this.backUrl+'/api/pessoa/todas');
    }

    getPorId(id: Guid) {
      return this.http.get<pessoa>(this.backUrl +`/api/pessoa/${id}`);
    }

    postAdd(pessoa: pessoa) {
      return this.http.post<pessoa>(this.backUrl + `/api/pessoa/`, pessoa);
    }
}
