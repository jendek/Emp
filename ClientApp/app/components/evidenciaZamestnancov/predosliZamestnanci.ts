import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';
import { Router } from 'aurelia-router';
import { DialogService } from 'aurelia-dialog';
import { Prompt } from '../modal/modal';

@autoinject
export class PredchadzajuciZamestnanciClient {

    public evidenciaZamestnancov: any;

    constructor(
        private network: Network,
        private router: Router,
        private dialogService: DialogService,
        private baseUrl?: string) {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPredoslychZamestnancov");
        if (response.ok && response.hasData) {
            this.evidenciaZamestnancov = response.data;
        }
    }

    detailZamestnanca(id: any): void {
        this.router.navigateToRoute('zamestnanecInfo', { zamestnanecID: id, editable: false });
    }

    public deleteZamestnanec(evidenciaZamestnancaZaznam: any): void {
        this.dialogService.open({ viewModel: Prompt, model: 'Natrvalo zmazať zamestnanca?', lock: true }).whenClosed(response => {
            if (!response.wasCancelled) { } else {
                let request = { method: "delete" };

                this.network.request(this.baseUrl + "/api/Zamestnanec/" + evidenciaZamestnancaZaznam.zamestnanecID, request).
                    then(response => {
                        this.activate();
                    });
            }
        });
    }
}