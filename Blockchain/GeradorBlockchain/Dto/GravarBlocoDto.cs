using GeradorBlockchain.Models;
using System;
using System.Collections.Generic;

namespace GeradorBlockchain.Dto
{
    public class GravarBlocoDto
    {
        public int Nonce { get; set; }
        public int Dificuldade { get; set; }
        public List<Transacao> Transacoes { get; set; }
        public DateTime Data { get; set; }
        public string HashBlocoAnterior { get; set; }
    }
}
