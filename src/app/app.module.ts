import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ViewContainerRef } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { CoursesComponent } from './components/courses/courses.component';
import { ContactComponent } from './components/contact/contact.component';
import { YogaRoomComponent } from './components/yoga-room/yoga-room.component';
import { BreakpointObserver, LayoutModule, MediaMatcher } from '@angular/cdk/layout';
import { Platform } from '@angular/cdk/platform';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { ImpressComponent } from './components/impress/impress.component';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CoursesComponent,
    ContactComponent,
    YogaRoomComponent,
    FooterComponent,
    ImpressComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    HttpClientModule,
    RouterModule,
  ],
  providers: [
    MediaMatcher,
    Platform,
    BreakpointObserver,
    {provide: LocationStrategy, useClass: HashLocationStrategy}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
