import { NgModule } from '@angular/core';

import { NbListModule, NbBadgeModule } from '@nebular/theme';
import { NgxEchartsModule } from 'ngx-echarts';
import { ThemeModule } from '../../@theme/theme.module';
import { DashboardComponent } from './dashboard.component';
import { TemperatureChartComponent } from './components/temperature-component/temperature-chart.component';
import { TemperatureComponent } from './components/temperature-component/temperature.component';
import { SensorComponent } from './components/sensor-component/sensor.component';
import { SensorCardFrontComponent } from './components/sensor-component/front-side/sensor-card-front.component';
import { SensorCardBackComponent } from './components/sensor-component/back-side/sensor-card-back.component';
import { StatusWidgetComponent } from './components/status-widget-component/statusWidget.component';
import { PlaySoundComponent} from './components/play-sound-component/playSound.component';

import { SearchFilterPipe } from './components/search-filter/searchFilter.pipe';
import { StatisticsComponent} from './components/statistics-component/statistics.component';

import { OrderModule } from 'ngx-order-pipe';

@NgModule({
  imports: [
    ThemeModule,
    NgxEchartsModule,
    NbListModule,
    NbBadgeModule,
    OrderModule
  ],
  declarations: [
    DashboardComponent,
    TemperatureChartComponent,
    TemperatureComponent,
    SensorComponent,
    SensorCardFrontComponent,
    SensorCardBackComponent,
    StatusWidgetComponent,
    PlaySoundComponent,
    SearchFilterPipe,
    StatisticsComponent,
  ],
})
export class DashboardModule { }
