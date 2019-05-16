using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Medicamento
{
    class Medicamento
    {
        #region atributos

        int id;
        string nome;
        string laboratorio;
        DateTime dataValidade;
        Queue<Lote> lotes;

        #endregion

        #region propriedades

        public int Id { get{ return this.id; } set { this.id = value; } }
        public string Nome { get{ return this.nome; }set{ this.nome = value; } }
        public string Labotorio { get { return this.laboratorio; } set { this.laboratorio = value; } }
        public Queue<Lote> Lotes { get { return this.lotes; } set { this.lotes = value; } }

        #endregion

        #region construtores

        public Medicamento(int id) {
            this.id = id;
            lotes = new Queue<Lote>();
        }

        /// <summary>
        /// Este método faz chamada ao construtor novo medicamento com 3 parâmetros
        /// </summary>
        /// <param name="id">id do medicamento</param>
        /// <param name="nome">nome do medicamento</param>
        /// <param name="laboratorio">laboratório que produziu o medicamento</param>
        public Medicamento(int id, string nome, string laboratorio) {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }

        #endregion

        #region métodos

        public int qtdeDisponivel() {
            int qtde = 0;
            foreach(Lote lote in lotes)
            {
                qtde += lote.Qtde;
            }
            return qtde;
        }
        public void comprar(Lote lote) {
            if (pesquisar(lote)==null)
            {
                Lotes.Enqueue(lote);
            }
        }
        public bool vender(int qtde)
        {
            do
            {
                if (qtdeDisponivel() >= qtde && qtde>0)
                {
                    if (lotes.Peek().Qtde > qtde)
                    {
                        lotes.Peek().Qtde -= qtde;
                        return true;
                    }
                    else if (lotes.Peek().Qtde <= qtde)
                    {
                        qtde -= lotes.Peek().Qtde;
                        lotes.Dequeue();
                    }
                }
                else return false;
            } while (qtde != 0);
            return true;
        }

        public string toString() {
            //retornar id + “-“ +nome + “-“ +laboratorio + “-“ + qtdeDisponivel()
            string str ="Medicamento Id: " + id + " - Nome: " +  nome + " - Laboratório: " + laboratorio + " - Disponível: " + qtdeDisponivel();
            return str;
        }
        public bool adicionarLote(Lote lote)
        {
            if (pesquisar(lote) == null)
            {
                lotes.Enqueue(lote);
                return true;
            }
            return false;
        }
        public Lote pesquisar(Lote lote)
        {
            foreach (Lote l in Lotes)
            {
                if (l.Equals(lote))
                    return l;
            }
            return null;
        }
        #endregion

        #region sobreescritas

        public override bool Equals(object obj)
        {
            Medicamento m = ((Medicamento)obj);
            return this.id.Equals(m.Id);
        }
        #endregion
    }
}
