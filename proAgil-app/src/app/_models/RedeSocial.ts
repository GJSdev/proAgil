import { Evento } from './Evento';
import { Palestrante } from './Palestrante';

export interface RedeSocial {
    Id: number;  
    Nome: string;
    URL: string; 
    eventoId?: number;
    evento: Evento;
 
    palestranteId?: number;
    palestrante: Palestrante;
}
