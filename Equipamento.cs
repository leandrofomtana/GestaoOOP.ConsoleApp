using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOOP
{
    class Equipamento
    {
        private string nome;
        private double preco;
        private string numeroSerie;
        private DateTime dataFabricacao;
        private string fabricante;

        public Equipamento(string nome, double preco, string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            this.nome = nome;
            this.preco = preco;
            this.numeroSerie = numeroSerie;
            this.dataFabricacao = dataFabricacao;
            this.fabricante = fabricante;
        }

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public string NumeroSerie { get => numeroSerie; set => numeroSerie = value; }
        public DateTime DataFabricacao { get => dataFabricacao; set => dataFabricacao = value; }
        public string Fabricante { get => fabricante; set => fabricante = value; }

        public override string ToString()
        {
            return $"Nome do equipamento: {Nome}\nPreço do equipamento: {Preco}\nNúmero de série: {NumeroSerie}" +
                $"\nData de Fabricação: {DataFabricacao}\nFabricante: {Fabricante}";
        }
    }
}
