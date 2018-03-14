import { HttpClient } from 'aurelia-fetch-client';
import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Sprava Zamestnancov';
        config.map([{
            route: [ '', 'home' ],
            name: 'zadanie',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Zadanie'
        },
        {
            route: 'aktualniZamestnanci',
            name: 'aktualniZamestnanci',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../evidenciaZamestnancov/aktualniZamestnanci'),
            nav: true,
            title: 'Aktualni zamestnanci'
        },
        {
            route: 'predosliZamestnanci',
            name: 'predosliZamestnanci',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../evidenciaZamestnancov/predosliZamestnanci'),
            nav: true,
            title: 'Predosli zamestnanci'
        },
        {
            route: 'pozicie',
            name: 'pozicie',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../evidenciaZamestnancov/pozicie'),
            nav: true,
            title: 'Pozicie vo firme'
        },
        {
            route: 'zamestnanecInfo/:zamestnanecID',
            name: 'zamestnanecInfo',
            moduleId: PLATFORM.moduleName('../evidenciaZamestnancov/zamestnanecInfo'),
            nav: false,
            title: 'Zamestnanec Info'
        }]);

        this.router = router;
    }
}
