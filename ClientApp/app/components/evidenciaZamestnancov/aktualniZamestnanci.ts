import { autoinject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';
import { Router } from 'aurelia-router';
import { DialogService } from 'aurelia-dialog';
import { Prompt } from '../modal/modal';
import * as moment from 'moment';

@autoinject
export class AktualniZamestnanciClient {

    private baseUrl: string;
    public message: string;
    public evidenciaZamestnancov: any;

    constructor(
        private network: Network,
        private router: Router,
        private dialogService: DialogService,
        baseUrl?: string) {
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

    public deleteZamestnanec(evidenciaZamestnancaZaznam: any): void {
        this.dialogService.open({ viewModel: Prompt, model: 'Archivovať zamestnanca?', lock: true }).whenClosed(response => {
            if (!response.wasCancelled) {
                let request = { method: "delete" };

                this.network.request(this.baseUrl + "/api/Zamestnanec/" + evidenciaZamestnancaZaznam.zamestnanecID, request).
                    then(response => {
                        this.activate();
                    });
            } else {
                evidenciaZamestnancaZaznam.datumUkoncenia = moment().format('L').toString();
                let request = { method: "put", body: json(evidenciaZamestnancaZaznam) };

                this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/", request).
                    then(response => {
                        this.activate();
                    });                
            }
        });
    }
}