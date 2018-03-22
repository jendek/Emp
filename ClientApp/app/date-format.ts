import * as moment from 'moment';

export class DateFormatValueConverter {

    toView(value: any) {
        if (value == null) { return null };
        return moment(value).format('DD.MM.YYYY');
    }

    //fromView(value: any) {
    //    return moment(value).format('YYYY-MM-DD');
    //}
}