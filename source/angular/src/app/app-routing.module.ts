import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizedComponent } from './authorized/authorized.component';
import { GuestComponent } from './guest/guest.component';

const routes: Routes = [{ path: 'auth', component: AuthorizedComponent },
{ path: '', component: GuestComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
