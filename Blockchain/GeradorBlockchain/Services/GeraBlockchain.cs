using GeradorBlockchain.Dto;
using GeradorBlockchain.Models;
using GeradorBlockchain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GeradorBlockchain.Services
{
    public class GeraBlockchain
    {
        private readonly GeraBlocos serviceBlocos;
        static List<Bloco> blockchain; 

        public GeraBlockchain()
        {
            serviceBlocos = new GeraBlocos();
            blockchain = new List<Bloco>();
        }

        public void GerarBlockChain()
        {

            List<GravarBlocoDto> blocos = serviceBlocos.GerarListaBlocos();

            foreach(var bloco in blocos)
            {
                AddBloco(bloco);
            }

            foreach(var blocoValido in blockchain)
            {
                    Console.WriteLine($"Nonce: {blocoValido.Nonce}\n\nData: {blocoValido.Data}\n\nDificuldade: {blocoValido.Dificuldade}\n\nHash do bloco: {blocoValido.Hash}\n\nHash do Bloco Anterior: {blocoValido.HashBlocoAnterior}\n\n-------Transações-------");

                foreach(var transacao in blocoValido.Transacoes)
                {
                    Console.WriteLine($"Remetente: {transacao.Remetente}\nDestinatário: {transacao.Destinatario}\nValor: {transacao.Valor}\n-------");
                }

                Console.WriteLine("\n\n***************************************************************");
            }
        }

        private void AddBloco(GravarBlocoDto bloco)
        {
            try
            {

                if (blockchain.Count == 0)
                {
                    bloco.Data = DateTime.Now;
                  
                    RetornoHashNonce retorno = GeraHashBloco(bloco);
                    if (retorno.Nonce == 0 || retorno.Hash == null)
                        throw new InvalidOperationException("Occoreu algum erro na gravação do bloco");

                    Bloco blocoValido = new Bloco
                    {
                        Nonce = retorno.Nonce,
                        Hash = retorno.Hash,
                        Dificuldade = bloco.Dificuldade,
                        Transacoes = bloco.Transacoes,
                        Data = bloco.Data,
                        HashBlocoAnterior = "0000000000000000000000000000000000000000000000000000000000000000"
                    };

                    blockchain.Add(blocoValido);

                } else
                {
                    bloco.Data = DateTime.Now;
                    bloco.HashBlocoAnterior = blockchain.Last().Hash;

                    RetornoHashNonce retorno = GeraHashBloco(bloco);

                    Bloco blocoValido = new Bloco
                    {
                        Nonce = retorno.Nonce,
                        Hash = retorno.Hash,
                        Dificuldade = bloco.Dificuldade,
                        Transacoes = bloco.Transacoes,
                        Data = bloco.Data,
                        HashBlocoAnterior = bloco.HashBlocoAnterior
                    };

                    blockchain.Add(blocoValido); 
                }
            } catch
            {
                Console.WriteLine("Ocorrou algum erro na gravação do Bloco.");
            }
        }

        private RetornoHashNonce GeraHashBloco(GravarBlocoDto bloco)
        {
            try
            {
                bloco.Nonce = 0;

                using SHA256 criptografia = SHA256.Create();
                string hash = "11";

                while(!Convert.ToString(hash[0]).Equals("0") || !Convert.ToString(hash[1]).Equals("0"))
                {
                    hash = GetHash(criptografia, JsonConvert.SerializeObject(bloco));
                    bloco.Nonce += 1;

                    Console.WriteLine(hash);
                }
                Console.WriteLine("\n\n\n");

                return new RetornoHashNonce
                {
                    Nonce = bloco.Nonce,
                    Hash = hash
                };
            } catch
            {
                return new RetornoHashNonce();
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}
