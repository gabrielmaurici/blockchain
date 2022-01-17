using GeradorBlockchain.Dto;
using System.Collections.Generic;

namespace GeradorBlockchain.Repository
{
    public class GeraBlocos
    {
        private readonly GeraTransacoes serviceTransacoes;

        public GeraBlocos()
        {
            serviceTransacoes = new GeraTransacoes();
        }
        
        public List<GravarBlocoDto> GerarListaBlocos()
        {
            List<GravarBlocoDto> blocos = new List<GravarBlocoDto>();

            GravarBlocoDto bloco1 = new GravarBlocoDto
            {
                Transacoes = serviceTransacoes.GerarTransacoesBloco1(),
                Dificuldade = 2
            };

            GravarBlocoDto bloco2 = new GravarBlocoDto
            {
                Transacoes = serviceTransacoes.GerarTransacoesBloco2(),
                Dificuldade = 2
            };

            GravarBlocoDto bloco3 = new GravarBlocoDto
            {
                Transacoes = serviceTransacoes.GerarTransacoesBloco3(),
                Dificuldade = 2
            };

            blocos.Add(bloco1);
            blocos.Add(bloco2);
            blocos.Add(bloco3);

            return blocos;
        }
    }
}
