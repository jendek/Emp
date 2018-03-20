import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';
import { Router } from 'aurelia-router';

@autoinject
export class AktualniZamestnanciClient {

    private baseUrl: string;

    public message: string;

    public evidenciaZamestnancov: any;

    constructor(private network: Network, private router: Router, baseUrl?: string) {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamAktualnychZamestnancov");
        if (response.ok && response.hasData) {
            this.evidenciaZamestnancov = response.data;
        }
    }

    public detailZamestnanca(id: any, editable: boolean = false): void {
        if (id == null) {
            this.router.navigateToRoute('zamestnanecInfo', { editable: editable });
        }
        this.router.navigateToRoute('zamestnanecInfo', { zamestnanecID: id, editable: editable });
    }

    public deleteZamestnanec(id: any): void {
        let request = {
            method: "delete"
        };

        this.network.request(this.baseUrl + "/api/Zamestnanec/" + id, request).
            then(response => {
                this.activate();
                alert("Zamestnanec bol vymazaný!");
            });
    }
}