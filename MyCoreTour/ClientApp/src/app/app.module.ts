import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
// import { HomeComponent } from './home/home.component';
// import { CounterComponent } from './counter/counter.component';
// import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeroesComponent } from './heroes/heroes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MastersComponent } from './masters/masters.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { MasterDetailComponent } from './master-detail/master-detail.component';
import { HeroSearchComponent } from './hero-search/hero-search.component';
import { MasterSearchComponent } from './master-search/master-search.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    // HomeComponent,
    // CounterComponent,
    // FetchDataComponent,
    HeroesComponent,
    DashboardComponent,
    MastersComponent,
    HeroDetailComponent,
    MasterDetailComponent,
    HeroSearchComponent,
    MasterSearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DashboardComponent, pathMatch: 'full' },
      { path: 'heroes', component: HeroesComponent },
      { path: 'masters', component: MastersComponent },
      { path: 'hero/detail/:id', component: HeroDetailComponent },
      { path: 'master/detail/:id', component: MasterDetailComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
