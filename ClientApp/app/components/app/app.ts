import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Emp';
        config.map([{
            route: [ '', 'home' ],
            name: 'zadanie',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Zadanie'
        }, {
            route: 'aktualniZamestnanci',
            name: 'aktualniZamestnanci',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../counter/counter'),
            nav: true,
            title: 'Aktualni zamestnanci'
        }, {
            route: 'predosliZamestnanci',
            name: 'predosliZamestnanci',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../fetchdata/fetchdata'),
            nav: true,
            title: 'Predosli zamestnanci'
        }, {
                route: 'pozicie',
            name: 'pozicie',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../counter/counter'),
            nav: true,
            title: 'Pozicie vo firme'
        }]);

        this.router = router;
    }
}
