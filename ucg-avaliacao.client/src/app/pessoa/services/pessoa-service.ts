import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { pessoa } from "../model/pessoa-model";
import { Guid } from "guid-typescript";

@Injectable()
export class PessoaService {

    constructor(private http: HttpClient) { }

    getTodas() {
        return this.http.get<pessoa[]>('/api/pessoa/todas');
    }

    getPorId(id: Guid) {
        return this.http.get<pessoa>(`/api/pessoa/${id}`);
    }
}