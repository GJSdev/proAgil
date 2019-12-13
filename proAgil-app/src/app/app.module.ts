import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BsDropdownModule, TooltipModule, ModalModule } from 'ngx-bootstrap';

import { EventoService } from './_services/evento.service';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { EventoComponent } from './evento/evento.component';

import { FilterPipe } from './filter.pipe';
import { DateTimeFormatPipePipe } from './_helps/dateTimeFormatPipe.pipe';



@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      FilterPipe,
      EventoComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),   //forRoot significa que pode ser usado na app toda
      ModalModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
