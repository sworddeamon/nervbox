import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { NervboxComponent } from './nervbox.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SettingsComponent } from './settings/settings.component';
import { LogsComponent } from './logs/logs.component';
import { DebugComponent} from './debug/debug.component';
import { NotFoundComponent } from '../pages/miscellaneous/not-found/not-found.component';
import { AuthGuard } from '../auth-guard.service';


const routes: Routes = [{
  path: '',
  component: NervboxComponent,
  children: [
    {
      path: 'dashboard',
      component: DashboardComponent,
    },
    {
      path: 'logs',
      canActivate: [AuthGuard],            
      component: LogsComponent,
    },
    {
      path: 'settings',
      canActivate: [AuthGuard],            
      component: SettingsComponent,
    },
    {
      path: 'debug',
      canActivate: [AuthGuard],            
      component: DebugComponent,
    },    
    {
      path: '',
      redirectTo: 'dashboard',
      pathMatch: 'full',
    },
    {
      path: '**',
      component: NotFoundComponent,
    }
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NervboxRoutingModule {
}
