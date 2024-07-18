import { Guid } from "guid-typescript";

export interface pessoa {
    id: Guid;
    nome: string;
    nascimento: Date;
    cpf: string;
    rg: string;
    nomeDependentes: Array<any>[];
}
