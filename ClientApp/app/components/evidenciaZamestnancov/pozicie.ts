import { autoinject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';

@autoinject
export class PozicieClient {

    private baseUrl: string;
    private pozicie: any;
    private poziciaNazov: string;

    constructor(private network: Network, baseUrl?: string) {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPozicii");
        if (response.ok && response.hasData) {
            this.pozicie = response.data;
        }
    }

    public addPozicia(poziciaNazov: string): void {
        let pozicia = new Pozicia({ Nazov: poziciaNazov });

        let request = {
            method: "post",
            body: json(pozicia)
        };

        this.network.request(this.baseUrl + "/api/Pozicia/", request).
            then(response => {
                this.activate();
                alert("Pozicia bola pridaná!");
            });
        this.poziciaNazov = "";
    }

    public deletePozicia(id: any): void {
        let request = {
            method: "delete"
        };

        this.network.request(this.baseUrl + "/api/Pozicia/" + id, request).
            then(response => {
                this.activate();
                alert("Pozicia bola vymazaná!");
            });
    }
}

export class Pozicia {
    PoziciaID: number;
    Nazov: string;
    Vymazana: boolean;

    constructor(data = {}) {
        Object.assign(this, data);
    }

}