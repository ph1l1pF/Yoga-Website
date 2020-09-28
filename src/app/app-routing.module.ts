import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactComponent } from './components/contact/contact.component';
import { CoursesComponent } from './components/courses/courses.component';
import { HomeComponent } from './components/home/home.component';
import { ImpressComponent } from './components/impress/impress.component';
import { YogaRoomComponent } from './components/yoga-room/yoga-room.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'yoga_raum', component: YogaRoomComponent },
  { path: 'kurse', component: CoursesComponent },
  { path: 'kontakt', component: ContactComponent },
  { path: 'impressum', component: ImpressComponent },
  { path: '**', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
