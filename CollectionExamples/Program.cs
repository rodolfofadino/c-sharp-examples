using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CollectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDictionaryExemplo();
            AllExemplo();
            RangeExemplo();
            FirstSingleExample();
            AnyAndCount();
            AllExample();
            ElementAtExample();
            LastExample();
        }
        private static void LastExample()
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < 10; i++)
            {
                produtos.Add(new Produto() { Id = i, Nome = $"{i} livro asp.net", Preco = i + 8.99M });
            }

            var ultimoProduto = produtos.Last();
            var ultimoProdutoComLivro = produtos.Last(a => a.Nome.Contains("livro"));
            var ultimoProdutoComLivroQueNaoExiste = produtos.Last(a => a.Nome.Contains("video"));
            var ultimoProdutoComLivroQueNaoExisteDefault = produtos.LastOrDefault(a => a.Nome.Contains("video"));
        }

        private static void ElementAtExample()
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < 10; i++)
            {
                produtos.Add(new Produto() { Id = i, Nome = $"{i} livro asp.net", Preco = i + 8.99M });
            }

            var segundoProduto = produtos.ElementAt(2);
            var vigesimoProduto = produtos.ElementAt(20);
            var vigesimoProdutoOrDefault = produtos.ElementAtOrDefault(20);
        }

        private static void AllExample()
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < 1000000; i++)
            {
                produtos.Add(new Produto() { Id = i, Nome = $"{i} livro asp.net", Preco = i + 8.99M });
            }
            var inicio = DateTime.Now;

            if (produtos.All(a => a.Nome.Length > 5))
            {

            }

            var fim = DateTime.Now;
            var total = (fim - inicio).TotalMilliseconds;
        }

        private static void AnyAndCount()
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < 1000000; i++)
            {
                produtos.Add(new Produto() { Id = i, Nome = $"{i} livro asp.net", Preco = i + 8.99M });
            }
            var inicio = DateTime.Now;
            for (int i = 0; i < 100; i++)
            {

                if (produtos.Count() > 0)
                {

                }

                if (produtos.Any())
                {

                }
                if (produtos.Count(a => a.Preco > new Random().Next(2, 30000)) > 0)
                {

                }

                if (produtos.Any(a => a.Preco > new Random().Next(2, 30000)))
                {

                }
            }
            var fim = DateTime.Now;
            var total = (fim - inicio).TotalMilliseconds;
        }

        private static void FirstSingleExample()
        {
            var produtos = new List<Produto>()
            {
                new Produto() { Id=1, Nome="livro asp.net", Preco=18.99M},
                new Produto() { Id=2, Nome="ebook asp.net", Preco=5.00M},
                new Produto() { Id=3, Nome="curso asp.net", Preco=108.99M},
            };

            var produto = produtos.First();
            var produtoComVideo = produtos.First(a => a.Nome.Contains("video"));
            var produtoComVideo2 = produtos.FirstOrDefault(a => a.Nome.Contains("video"));


            var produtoUnico = produtos.Single();
            var produtoUnicoComASPNET = produtos.Single(a => a.Nome.Contains("asp.net"));
            var produtoComVideoASPNET = produtos.SingleOrDefault(a => a.Nome.Contains("video"));
        }

        private static void ToDictionaryExemplo()
        {
            var produtos = CarregaProdutos(100000).ToList();

            //agrupar os produtos
            var dicionarioDeCategorias = produtos.GroupBy(p => p.Categoria)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        private static void AllExemplo()
        {
            var produtos = CarregaProdutos(100000).ToList();

            var inicio = DateTime.Now;

            ////15,5136 ms
            //if (produtos.All(a => a.Ativo))
            //{

            //}

            //17,9913 ms
            ////validar de todos os produtos estão ativos
            //if (produtos.Count() == produtos.Count(a => a.Ativo))
            //{
            //    //fazer algo
            //}

            var fim = DateTime.Now;

            var total = (fim - inicio).TotalMilliseconds;

            Console.WriteLine($"{total} ms");
            Console.ReadKey();
        }

        private static void RangeExemplo()
        {
            //3690,3322 ms
            //1855,6756 ms
            var inicio = DateTime.Now;
            var produtos = CarregaProdutos(1000000).ToList();
            var produtosParaAdicionar = CarregaProdutos(1000000);

            var fim = DateTime.Now;

            var total = (fim - inicio).TotalMilliseconds;

            Console.WriteLine($"{total} ms");
            Console.ReadKey();

            produtos.AddRange(produtosParaAdicionar);
        }

        private static IEnumerable<Produto> CarregaProdutos(int total)
        {
            for (int i = 0; i < total; i++)
            {
                var categoria = i % 2 == 0 ? "Livros" : "Cursos";
                yield return new Produto() { Id = i, Categoria = categoria, Ativo = true, Nome = $"{i} livro asp.net", Preco = 18.99M };
            }
        }
    }
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public string Categoria { get; set; }
    }
}
