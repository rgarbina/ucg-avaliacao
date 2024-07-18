import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})

export class AppComponent {

    constructor(
        private titleService: Title) {
        this.titleService.setTitle('UCG Avaliação');
        this.insereSrc();
    }

    insereSrc() {
        const imgLogo = window.document.querySelector('img.index-logo') as HTMLImageElement;
        if (imgLogo) {
            imgLogo.setAttribute('src', `https://core-web.unimedcg.com.br/svg/logoUnimed.svg`);
        }
    }
}
