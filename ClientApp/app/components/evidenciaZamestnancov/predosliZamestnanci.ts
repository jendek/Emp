import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';
import { Router } from 'aurelia-router';
import { FormatData } from '../../formatData';

@autoinject
export class PredchadzajuciZamestnanciClient {

    private baseUrl: string;

    public evidenciaZamestnancov: any;

    constructor(private network: Network, private router: Router, private formatData: FormatData, baseUrl?: string) {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPredoslychZamestnancov");
        if (response.ok && response.hasData) {
            this.evidenciaZamestnancov = response.data;
        }
    }

    onClickMeno(evidenciaZamestnanca: any): void {
        this.router.navigateToRoute('zamestnanecInfo', { zamestnanecID: evidenciaZamestnanca.zamestnanec.zamestnanecID });
    }
}