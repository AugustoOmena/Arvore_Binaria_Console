using System;

namespace Arvore_Binaria
{
    class No
    {
        public int Valor;
        public No Esquerda, Direita;

        public No(int valor)
        {
            Valor = valor;
            Esquerda = Direita = null;
        }
    }

    class ArvoreBinaria
    {
        private No raiz;

        public ArvoreBinaria()
        {
            raiz = null;
        }

        // Método público para inserir um valor na árvore
        public void Inserir(int valor)
        {
            raiz = InserirRecursivo(raiz, valor);
        }

        // Método privado para inserir um valor recursivamente
        private No InserirRecursivo(No no, int valor)
        {
            if (no == null)
            {
                no = new No(valor);
                return no;
            }

            if (valor < no.Valor)
                no.Esquerda = InserirRecursivo(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = InserirRecursivo(no.Direita, valor);

            return no;
        }

        // Método público para buscar um valor na árvore
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        // Método privado para buscar um valor recursivamente
        private bool BuscarRecursivo(No no, int valor)
        {
            if (no == null)
                return false;

            if (valor == no.Valor)
                return true;

            if (valor < no.Valor)
                return BuscarRecursivo(no.Esquerda, valor);
            else
                return BuscarRecursivo(no.Direita, valor);
        }

        // Métodos públicos para realizar travessias na árvore
        public void InOrder()
        {
            InOrderRecursivo(raiz);
        }

        public void PreOrder()
        {
            PreOrderRecursivo(raiz);
        }

        public void PostOrder()
        {
            PostOrderRecursivo(raiz);
        }

        // Métodos privados para realizar travessias recursivamente
        private void InOrderRecursivo(No no)
        {
            if (no != null)
            {
                InOrderRecursivo(no.Esquerda);
                Console.Write(no.Valor + " ");
                InOrderRecursivo(no.Direita);
            }
        }

        private void PreOrderRecursivo(No no)
        {
            if (no != null)
            {
                Console.Write(no.Valor + " ");
                PreOrderRecursivo(no.Esquerda);
                PreOrderRecursivo(no.Direita);
            }
        }

        private void PostOrderRecursivo(No no)
        {
            if (no != null)
            {
                PostOrderRecursivo(no.Esquerda);
                PostOrderRecursivo(no.Direita);
                Console.Write(no.Valor + " ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArvoreBinaria arvore = new ArvoreBinaria();

            arvore.Inserir(50);
            arvore.Inserir(30);
            arvore.Inserir(70);
            arvore.Inserir(20);
            arvore.Inserir(40);
            arvore.Inserir(60);
            arvore.Inserir(80);

            Console.WriteLine("In-Order:");
            arvore.InOrder();
            Console.WriteLine();

            Console.WriteLine("Pre-Order:");
            arvore.PreOrder();
            Console.WriteLine();

            Console.WriteLine("Post-Order:");
            arvore.PostOrder();
            Console.WriteLine();

            int valorBusca = 40;
            if (arvore.Buscar(valorBusca))
                Console.WriteLine($"{valorBusca} encontrado na árvore.");
            else
                Console.WriteLine($"{valorBusca} não encontrado na árvore.");
        }
    }
}
