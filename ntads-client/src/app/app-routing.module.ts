import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AdEditorComponent } from './ad-editor/ad-editor.component';
import { AdComponent } from './ad/ad.component';
import { AdalGuard } from 'adal-angular4';

const routes: Routes = [
  { path: '', redirectTo: 'ads', pathMatch: 'full'},
  { path: 'ads', component: AdComponent, canActivate: [AdalGuard] },
  { path: 'ads/create', component: AdEditorComponent, canActivate: [AdalGuard] },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
