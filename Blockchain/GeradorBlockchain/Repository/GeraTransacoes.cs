using GeradorBlockchain.Models;
using System.Collections.Generic;

namespace GeradorBlockchain.Repository
{
    public class GeraTransacoes
    {
        public List<Transacao> GerarTransacoesBloco1()
        {
            List<Transacao> lista = new List<Transacao>();

            Transacao transacao1 = new Transacao
            {
                Remetente = "Gabriel",
                Destinatario = "Ronaldo",
                Valor = "1 BTC"
            };

            Transacao transacao2 = new Transacao
            {
                Remetente = "Rodinaldo",
                Destinatario = "Salete",
                Valor = "0.439 BTC"
            };

            lista.Add(transacao1);
            lista.Add(transacao2);

            return lista;
        }

        public List<Transacao> GerarTransacoesBloco2()
        {
            List<Transacao> lista = new List<Transacao>();

            Transacao transacao1 = new Transacao
            {
                Remetente = "Josnei",
                Destinatario = "Arnaldo",
                Valor = "0.008 BTC"
            };

            Transacao transacao2 = new Transacao
            {
                Remetente = "Rodolfo",
                Destinatario = "Airton",
                Valor = "2.5 BTC"
            };

            lista.Add(transacao1);
            lista.Add(transacao2);

            return lista;
        }
        public List<Transacao> GerarTransacoesBloco3()
        {
            List<Transacao> lista = new List<Transacao>();

            Transacao transacao1 = new Transacao
            {
                Remetente = "Jeferson",
                Destinatario = "Rúbia",
                Valor = "8 BTC"
            };

            lista.Add(transacao1);

            return lista;
        }
    }
}
