import * as numeral from 'numeral';

export class CurrencyFormatValueConverter {

    toView(value: any) {
        return numeral(value).format('(0,0.00)');
    }

    fromView(value: any) {
        return numeral(value).format('(0,0.00)');
    }
}