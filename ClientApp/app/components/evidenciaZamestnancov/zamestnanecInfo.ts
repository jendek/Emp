import { autoinject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Router } from 'aurelia-router';
import { Network, NetworkResponse } from '../../network';
import { FormatData } from '../../formatData';

@autoinject
export class ZamestnanecInfoClient {

    private baseUrl: string;
    private editable: boolean;
    public evidenciaZamestnanca: any;
    public evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam = new EvidenciaZamestnancaZaznam();
    public zamestnanec: Zamestnanec = new Zamestnanec();

    constructor(
        private network: Network,
        private formatData: FormatData,
        private router: Router,
        baseUrl?: string)
    {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
        this.network = network;
    }

    async activate(params: any) {
        this.editable = params.editable;
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/" + params.zamestnanecID);
        if (response.ok && response.hasData && params.zamestnanecID != null) {
            this.evidenciaZamestnanca = response.data;
            this.evidenciaZamestnancaZaznam = this.evidenciaZamestnanca[this.evidenciaZamestnanca.length - 1];
            this.zamestnanec = this.evidenciaZamestnanca[0].zamestnanec;
        }
    }

    public Save(zamestnanec: Zamestnanec, evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam): void {
        evidenciaZamestnancaZaznam.zamestnanec = zamestnanec;
        if (zamestnanec.zamestnanecID == null) {
            this.AddEvidenciaZamestnanca(evidenciaZamestnancaZaznam);
        } else {
            this.UpdateEvidenciaZamestnanca(evidenciaZamestnancaZaznam);
        }
    }

    public UpdateEvidenciaZamestnanca(evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam): void {

        let request = { method: "put", body: json(evidenciaZamestnancaZaznam)};

        this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/", request)
            .then(response => {
                this.activate({ zamestnanecID: this.evidenciaZamestnancaZaznam.zamestnanecID, editable: 'false' });
            });
    }

    public AddEvidenciaZamestnanca(evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam): void {

        let request = { method: "post", body: json(evidenciaZamestnancaZaznam)};

        this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/", request)
            .then(response => {
                this.activate({
                    editable: 'false', zamestnanecID: response.data.zamestnanecID
                });
            });
    }
 }

export class Zamestnanec {
    zamestnanecID: number;
    meno: string;
    priezvisko: string;
    adresa: string;
    datumNarodenia: Date;

    constructor(data = {}) {
        Object.assign(this, data);
    }

}

export class EvidenciaZamestnancaZaznam {
    evidenciaZamestnancaID: number;
    zamestnanecID: number;
    poziciaID: number;
    datumNastupu: Date;
    //Datum ukoncenia sa edituje pomocou zmazania zamestnanca zo zoznamu aktualnych zamestnancov
    //DatumUkoncenia: Date;
    plat: number;
    zamestnanec: Zamestnanec;

    constructor(data = {}) {
        Object.assign(this, data);
    }

}