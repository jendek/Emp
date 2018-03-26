export class Pozicia {
    poziciaID: number;
    nazov: string;
    vymazana: boolean;

    constructor(data = {}) {
        Object.assign(this, data);
    }

}