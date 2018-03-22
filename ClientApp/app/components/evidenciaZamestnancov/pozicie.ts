import { autoinject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';
import { BootstrapFormRenderer } from '../../bootstrap-form-renderer';
import { ValidationControllerFactory, ValidationController, ValidationRules, validateTrigger } from "aurelia-validation";

@autoinject
export class PozicieClient {
    private pozicie: any;
    private nazov: string;
    private validationController: ValidationController;
    public valid: boolean;

    constructor(
        private network: Network,
        private validationControllerFactory: ValidationControllerFactory,
        private baseUrl?: string)
    {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
        this.validationController = validationControllerFactory.createForCurrentScope();
        this.validationController.validateTrigger = validateTrigger.manual;
        
        ValidationRules
            .ensure('nazov').required().minLength(3)
            .on(PozicieClient);
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPozicii");
        if (response.ok && response.hasData) {
            this.pozicie = response.data;
        }
}

    public addPozicia(inputNazov: string): void {
        this.validationController.validate().then(result => {
            if (result.valid) {
                this.valid = true;
                let pozicia = new Pozicia({ nazov: inputNazov });

                let request = {
                    method: "post",
                    body: json(pozicia)
                };

                this.network.request(this.baseUrl + "/api/Pozicia/", request).
                    then(response => {
                        this.activate();
                        alert("Pozicia bola pridaná!");
                    });
                this.nazov = "";
            } else {
                this.valid = false;
            }
        });
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
    poziciaID: number;
    nazov: string;
    vymazana: boolean;

    constructor(data = {}) {
        Object.assign(this, data);
    }

}
