import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { EditComponent } from './edit/edit.component';
import { CalendarComponent } from './calendar/calendar.component';
import { AddComponent } from './add/add.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'edit', component: EditComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: 'add', component: AddComponent },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
