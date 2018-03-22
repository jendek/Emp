import * as moment from 'moment';

export class DatePickerFormatValueConverter {

    toView(value: any) {
        if (value == null) { return null };
        return moment(value).format('YYYY-MM-DD');
    }

    //fromView(value: any) {
    //    return moment(value).format('YYYY-MM-DD');
    //}
}