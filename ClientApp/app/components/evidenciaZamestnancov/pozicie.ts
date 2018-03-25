﻿import { autoinject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Network, NetworkResponse } from '../../network';
import { BootstrapFormRenderer } from '../../bootstrap-form-renderer';
import { ValidationControllerFactory, ValidationController, ValidationRules, validateTrigger } from "aurelia-validation";
import { bindable } from "aurelia-templating/dist/aurelia-templating";

@autoinject
export class PozicieClient {
    private pozicie: any;
    private pozicia: Pozicia = new Pozicia();
    private poziciaValidationRules: ValidationRules;
    private validationController: ValidationController;

    constructor(
        private network: Network,
        private validationControllerFactory: ValidationControllerFactory,
        private baseUrl?: string)
    {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
        this.validationController = validationControllerFactory.createForCurrentScope();
        this.validationController.validateTrigger = validateTrigger.blur;
        this.validationController.addRenderer(new BootstrapFormRenderer());

        this.poziciaValidationRules = ValidationRules
            .ensure('nazov').required().withMessage("Povinný údaj")
            .ensure('nazov').minLength(3).withMessage("Minimálne 3 znaky")
            .on(Pozicia)
            .rules;
    }

    async activate() {
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/ZoznamPozicii");
        if (response.ok && response.hasData) {
            this.pozicie = response.data;
        }
}

    public addPozicia(pozicia: Pozicia): void {
        this.validationController.validate({ object: pozicia, rules: this.poziciaValidationRules }).then(result => {
            if (result.valid) {
                let request = {
                    method: "post",
                    body: json(pozicia)
                };

                this.network.request(this.baseUrl + "/api/Pozicia/", request).
                    then(response => {
                        this.activate();
                    });
                this.pozicia.nazov = "";
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
