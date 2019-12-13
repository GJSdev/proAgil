import { Component, OnInit, TemplateRef } from '@angular/core';
import { Pipe, PipeTransform } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Pipe({name: 'filter'})
@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})
export class EventoComponent implements OnInit {
  
  length: boolean;
  eventos: Evento[] = [];
  eventosFiltrados: Evento[] = [];  
  imagemAltura = 50;
  margem = 2;
  mostrarImagem = false;
  modalRef: BsModalRef; //nome que eu dei no template
  
  _filtrolista: string = '';

  get filtrolista() : string{
    return this._filtrolista;
  }
  set filtrolista(value: string){
    this._filtrolista = value;
    this.eventosFiltrados = this.filtrolista ? this.filtrarEventos(this.filtrolista) : this.eventos; 
  }
  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }  
  
  constructor(
    private eventoService: EventoService
   , private modalService: BsModalService
    ) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarpor: string): Evento[]{
    filtrarpor = filtrarpor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarpor) !== -1
    );
  }
   getEventos(){
    this.eventoService.getAllEvento().subscribe(
      (_eventos: Evento[]) => {
      this.eventos = _eventos;
    }, error => {
        console.log(error);
    });
    if(this.eventos.length){
      this.length = true;
    }
  }
  alternaImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }
  
}
