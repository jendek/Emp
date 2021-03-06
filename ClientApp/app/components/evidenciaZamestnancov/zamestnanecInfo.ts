﻿import * as moment from 'moment';
import { autoinject, transient } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import { Router } from 'aurelia-router';
import { Network, NetworkResponse } from '../../network';
import { ValidationControllerFactory, ValidationController, ValidationRules, validateTrigger } from "aurelia-validation";
import { BootstrapFormRenderer } from "../../bootstrap-form-renderer";
import { Pozicia } from '../models/Pozicia';
import { Zamestnanec } from '../models/Zamestnanec';
import { EvidenciaZamestnancaZaznam } from '../models/EvidenciaZamestnancaZaznam';

@autoinject
export class ZamestnanecInfoClient {
    private validationController: ValidationController;
    private baseUrl: string;
    private editable: boolean;
    private evidenciaZamestnanca: any;
    private evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam = new EvidenciaZamestnancaZaznam();
    private zamestnanec: Zamestnanec = new Zamestnanec();
    private pozicie: Pozicia[];
    private pozicia: Pozicia = new Pozicia;
    private poziciaMatcher: any;
    private evidenciaZamestnancaZaznamValidationRules: ValidationRules; 
    private zamestnanecValidationRules: ValidationRules; 

    constructor(
        private network: Network,
        private router: Router,
        private validationControllerFactory: ValidationControllerFactory,
        baseUrl?: string)
    {
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:55622";
    }

    async activate(params: any) {
        this.editable = params.editable;
        this.getPozicie();
        let response: NetworkResponse = await this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/" + params.zamestnanecID);
        if (response.ok && response.hasData && params.zamestnanecID != null) {
            this.evidenciaZamestnanca = response.data;
            this.evidenciaZamestnancaZaznam = this.evidenciaZamestnanca[this.evidenciaZamestnanca.length - 1];
            this.zamestnanec = this.evidenciaZamestnancaZaznam.zamestnanec;
        } else {
            this.evidenciaZamestnancaZaznam.zamestnanec = this.zamestnanec;
            this.evidenciaZamestnancaZaznam.zamestnanec.datumNarodenia = moment().format('L').toString();
            this.evidenciaZamestnancaZaznam.datumNastupu = moment().format('L').toString();
        }

        this.validationController = this.validationControllerFactory.createForCurrentScope();
        this.validationController.validateTrigger = validateTrigger.blur;
        this.validationController.addRenderer(new BootstrapFormRenderer());
        this.defineValidationRules();
    }

    public save(zamestnanec: Zamestnanec, evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam): void {
        this.validationController.validate()
            .then(result => {
                if (result.valid) {
                    if (evidenciaZamestnancaZaznam.zamestnanec.zamestnanecID == null) {
                        this.addEvidenciaZamestnanca(evidenciaZamestnancaZaznam);
                    } else {
                        this.updateEvidenciaZamestnanca(evidenciaZamestnancaZaznam);
                    }
                }
            });        
    }

    public updateEvidenciaZamestnanca(evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam): void {

        let request = { method: "put", body: json(evidenciaZamestnancaZaznam)};

        this.network.request(this.baseUrl + "/api/EvidenciaZamestnanca/", request)
            .then(response => {
                this.activate({ zamestnanecID: this.evidenciaZamestnancaZaznam.zamestnanecID, editable: 'false' });
            });
    }

    public addEvidenciaZamestnanca(evidenciaZamestnancaZaznam: EvidenciaZamestnancaZaznam): void {

        let request = { method: "post", body: json(evidenciaZamestnancaZaznam) };

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

    private defineValidationRules() {
        ValidationRules.customRule(
            'datumNarodeniaRule',
            (value, obj) => {
                let now = moment().format('L');
                value = moment(value).format('L');
                return moment(now) > moment(value);
            }, 'Dátum narodenia musí byť dátum z minulosti.'
        );

        ValidationRules.customRule(
            'datumNastupuRule',
            (value, obj) => {
                let now = moment().format('L');
                value = moment(value).format('L');
                return moment(value) >= moment(now);
            }, 'Dátum nastupu musí byť dátum dnešný alebo z buducnosti.'
        );

        this.zamestnanecValidationRules = ValidationRules
            .ensure('meno').required().withMessage('Meno je povinný údaj.')
            .ensure('priezvisko').required().withMessage('Priezvisko je povinný údaj.')
            .ensure('datumNarodenia').satisfiesRule('datumNarodeniaRule').required().withMessage('Dátum narodenia je povinný údaj.')
            .on(Zamestnanec)
            .rules;

        if (this.evidenciaZamestnancaZaznam.zamestnanec.zamestnanecID != null) {
            this.evidenciaZamestnancaZaznamValidationRules = ValidationRules
                .ensure('datumNastupu').required().withMessage('Dátum nástupu je povinný údaj.')
                .ensure('plat').required().withMessage('Plat je povinný údaj.')
                .on(EvidenciaZamestnancaZaznam)
                .rules;
        } else {
            this.evidenciaZamestnancaZaznamValidationRules = ValidationRules
                .ensure('datumNastupu').satisfiesRule('datumNastupuRule').required().withMessage('Dátum nástupu je povinný údaj.')
                .ensure('plat').required().withMessage('Plat je povinný údaj.')
                .on(EvidenciaZamestnancaZaznam)
                .rules;            
        }

        this.validationController.addObject(this.evidenciaZamestnancaZaznam, this.evidenciaZamestnancaZaznamValidationRules);
        this.validationController.addObject(this.zamestnanec, this.zamestnanecValidationRules);
    }

    private roundInput() {
        this.evidenciaZamestnancaZaznam.plat = parseFloat(this.evidenciaZamestnancaZaznam.plat).toFixed(2);
    }
 }