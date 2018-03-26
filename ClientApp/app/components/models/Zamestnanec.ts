export class Zamestnanec {
    zamestnanecID: number;
    meno: string = '';
    priezvisko: string = '';
    adresa: string = '';
    datumNarodenia: any;

    constructor(data = {}) {
        Object.assign(this, data);
    }
}