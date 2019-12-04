namespace proAgil.api.Models
{
    public class Evento
    {
        public int EventoId {get;set;}
        public string Local {get;set;}
        public string DataEvento{get;set;}
        public string Tema{get;set;}
        public string QtdPessoas{get;set;}
        public int Lote{get;set;}

        public string ImagemURL{get;set;}
    }
}