import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BetsViewComponent } from './views/bets-view/bets-view.component';

const routes: Routes = [
  {
    path: '',
    component: BetsViewComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BetsRoutingModule { }
