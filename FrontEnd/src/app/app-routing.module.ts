import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameComponent } from './game/game.component';
import { SignComponent } from './sign/sign.component';

export const routes: Routes = [
  { path: '', redirectTo: 'sign', pathMatch: 'full' },
  { path: 'game', component: GameComponent },
  { path: 'sign', component: SignComponent },
  { path: '**', redirectTo: 'sign' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: []
})


export class AppRoutingModule { }
