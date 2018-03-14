import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';

@autoinject
export class ZamestnanecInfoClient {

    private baseUrl: string;

    public evidenciaZamestnanca: any;
    public zamestnanec: any
    public message: string;

    constructor(private network: Network, baseUrl?: string) {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate(params: any) {
        this.message = this.baseUrl + "/api/EvidenciaZamestnanca/" + params.zamestnanecID;
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/" + params.zamestnanecID);
        if (response.ok && response.hasData) {
            this.evidenciaZamestnanca = response.data;
            this.zamestnanec = this.evidenciaZamestnanca[0].zamestnanec;
        }
    }
}