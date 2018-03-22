import { autoinject, transient } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Router } from 'aurelia-router';
import { Network, NetworkResponse } from '../../network';
import { PozicieClient, Pozicia } from './pozicie';

@autoinject
export class ZamestnanecInfoClient {

    private baseUrl: string;
    private editable: boolean;
    public evidenciaZamestnanca: any;
    public evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam = new EvidenciaZamestnancaZaznam();
    public zamestnanec: Zamestnanec = new Zamestnanec();
    public pozicie: Pozicia[];

    constructor(
        private network: Network,
        private router: Router,
        baseUrl?: string)
    {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
        this.network = network;
    }

    async activate(params: any) {
        this.editable = params.editable;
        this.getPozicie();
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/" + params.zamestnanecID);
        if (response.ok && response.hasData && params.zamestnanecID != null) {
            this.evidenciaZamestnanca = response.data;
            this.evidenciaZamestnancaZaznam = this.evidenciaZamestnanca[this.evidenciaZamestnanca.length - 1];
            this.zamestnanec = this.evidenciaZamestnanca[0].zamestnanec;
        } else { this.evidenciaZamestnancaZaznam.datumNastupu = new Date().toISOString().substring(0, 10); }
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

    async getPozicie() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPozicii");
        if (response.ok && response.hasData) {
            this.pozicie = response.data;
        }
    }

    private DropdownChanged(id: number) {
        this.evidenciaZamestnancaZaznam.poziciaID = id;
    }
 }

@transient()
export class Zamestnanec {
    zamestnanecID: number;
    meno: string;
    priezvisko: string;
    adresa: string;
    datumNarodenia: any;

    constructor(data = {}) {
        Object.assign(this, data);
    }

}

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