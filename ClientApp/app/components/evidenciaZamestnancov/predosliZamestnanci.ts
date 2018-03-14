import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';

@autoinject
export class PredchadzajuciZamestnanciClient {

    private baseUrl: string;

    public evidenciaZamestnancov: any;

    constructor(private network: Network, baseUrl?: string) {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPredoslychZamestnancov");
        if (response.ok && response.hasData) {
            this.evidenciaZamestnancov = response.data;
        }
    }

    // click handlers
    //tileClick(droid: any): void {
    //  this.router.navigateToRoute('droidInfo', { id: droid.id });
}