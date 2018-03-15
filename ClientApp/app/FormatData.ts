import * as moment from 'moment';
import * as numeral from 'numeral';

export class FormatData {

    toCasualDate(value: Date): any {
        if (value === null) {
            return null;
        }
        return moment(value).format('DD.MM.YYYY');
    }

    toMoney(value: any): any {
        return numeral(value).format('(0,0.00)') + " €";
    }
}