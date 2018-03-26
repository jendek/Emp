import { Pozicia } from './Pozicia';
import { Zamestnanec } from './Zamestnanec';

export class EvidenciaZamestnancaZaznam {
    evidenciaZamestnancaID: number;
    zamestnanecID: number;
    poziciaID: number;
    datumNastupu: string;
    //Datum ukoncenia sa edituje pomocou zmazania zamestnanca zo zoznamu aktualnych zamestnancov
    //DatumUkoncenia: Date;
    plat: string;
    zamestnanec: Zamestnanec;
    pozicia: Pozicia;

    constructor(data = {}) {
        Object.assign(this, data);
    }
}