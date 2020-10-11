import { BreakpointObserver, LayoutModule, MediaMatcher } from '@angular/cdk/layout';
import { Platform } from '@angular/cdk/platform';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactComponent } from './components/contact/contact.component';
import { CoursesComponent } from './components/courses/courses.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { ImpressComponent } from './components/impress/impress.component';
import { YogaRoomComponent } from './components/yoga-room/yoga-room.component';


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
