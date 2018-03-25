import { autoinject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@autoinject
export class Prompt {
    answer: any;
    message: string;

    constructor(private controller: DialogController) {
        this.answer = null;
        this.controller.settings.centerHorizontalOnly = true;
        this.controller.settings.lock = false;
    }

    activate(message: string) {
        this.message = message;
    }
}