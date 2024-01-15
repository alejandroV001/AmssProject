import { CheltuialaDto } from "./cheltuiala";

export class GrupDto{
    id: number = 0;
    nume: string = '';
    capacitate: number = 0;
}

export class CalatorieDto{
    id: number = 0;
    destinatie: string = '';
    grupId: number = 0;
}

export class CalatorieGrupDto{
    id: number = 0;
    destinatie: string = '';
    grup: GrupDto = new GrupDto();
    cheltuieli: CheltuialaDto[] = [];
}
