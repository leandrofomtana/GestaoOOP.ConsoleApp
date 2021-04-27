using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOOP
{
    class Gerenciamento
    {
        private Equipamento[] equipamentos = new Equipamento[100];
        private int numeroEquipamentos = 1;
        private Chamado[] chamados = new Chamado[100];
        private int numeroChamados = 1;

        public Equipamento[] Equipamentos { get => equipamentos; set => equipamentos = value; }
        public int NumeroEquipamentos { get => numeroEquipamentos; set => numeroEquipamentos = value; }
        public Chamado[] Chamados { get => chamados; set => chamados = value; }
        public int NumeroChamados { get => numeroChamados; set => numeroChamados = value; }

        private double PrecoValido()
        {
            double preco;
            while (true)
            {
                Console.WriteLine("Digite o preço do equipamento: ");
                string precoTxt = Console.ReadLine();
                if (precoTxt.Contains(".")) { precoTxt.Replace(".", ","); }
                if (double.TryParse(precoTxt, out preco)) { break; }
                else
                {
                    Console.WriteLine("Preço inválido. Digite um número com vírgula.");
                    continue;
                }
            }
            return preco;
        }

        private string NomeValido()
        {
            string nome;
            while (true)
            {
                Console.WriteLine("Digite o nome do equipamento: ");
                nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                    continue;
                }
                else { break; }
            }
            return nome;
        }

        private int NumeroValido(string tipo)
        {
            int numero;
            while (true)
            {
                Console.WriteLine($"Digite o número do {tipo}: ");
                string precoTxt = Console.ReadLine();
                if (Int32.TryParse(precoTxt, out numero)) { break; }
                else
                {
                    Console.WriteLine("Não é um número. Digite um número.");
                    continue;
                }
            }
            return numero;
        }

        private DateTime DataValida()
        {
            while (true)
            {
                Console.WriteLine("Digite a data de fabricação(formato DD/MM/YYYY): ");
                string data = Console.ReadLine();
                DateTime temp;
                if (DateTime.TryParse(data, out temp))
                {
                    if (DateTime.Now > temp) { return temp; }
                    else { Console.WriteLine("A data de fabricação não pode ser no futuro"); continue; }
                }
                else { Console.WriteLine("Digite uma data válida."); continue; }
            }
        }

        private Equipamento EquipamentoValido()
        {
            if (NumeroEquipamentos == 0) { return null; }
            else
            {
                Equipamento equipamento;
                while (true)
                {
                    int n = NumeroValido("equipamento");
                    if (equipamentos[n] == null)
                    {
                        Console.WriteLine("Não existe equipamento com esse número");
                        continue;
                    }
                    else { equipamento = equipamentos[n]; break; }
                }
                return equipamento;
            }
        }

        public void CriarEquipamento(int edit = -1)
        {
            string nome;
            nome = NomeValido();
            double preco;
            preco = PrecoValido();
            Console.WriteLine("Digite o número de série: ");
            string nSerie = Console.ReadLine();
            DateTime dataFabricacao = DataValida();
            Console.WriteLine("Digite o fabricante do equipamento: ");
            string fabricante = Console.ReadLine();
            Equipamento equipamento = new Equipamento(nome, preco, nSerie, dataFabricacao, fabricante);
            if (edit == -1)
            {
                Equipamentos[NumeroEquipamentos] = equipamento;
                NumeroEquipamentos++;
            }
            else { Equipamentos[edit] = equipamento; }
            Console.WriteLine("Equipamento criado com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarEquipamentos()
        {
            int i = 0;
            foreach (Equipamento equip in equipamentos)
            {
                if (!(equip == null))
                {
                    Console.WriteLine($"Número do equipamento: {i}");
                    Console.WriteLine(equip);
                    Console.WriteLine();
                }
                i++;
            }
            Console.ReadLine();
        }

        public void EditarEquipamento()
        {
            int n = NumeroValido("equipamento");
            if (n > numeroEquipamentos || n < 1 || equipamentos[n] == null)
            {
                Console.WriteLine("Digite um número de equipamento existente.");
            }
            else { CriarEquipamento(n); }
        }

        public void RemoverEquipamento()
        {
            int n = NumeroValido("equipamento que deseja remover");
            if (n > numeroEquipamentos || n < 1 || equipamentos[n] == null)
            {
                Console.WriteLine("Digite um número de equipamento existente.");
            }
            else { equipamentos[n] = null; Console.WriteLine("Equipamento removido."); Console.ReadLine(); }
        }
        public void CriarChamado(int edit = -1)
        {
            Console.WriteLine("Digite o título do chamado: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();
            Equipamento equipamento = EquipamentoValido();
            if (equipamento == null) { Console.WriteLine("Não existem equipamentos ainda."); Console.ReadLine(); }
            else
            {
                DateTime dataAbertura = DateTime.Now;
                Chamado chamado = new Chamado(titulo, descricao, equipamento, dataAbertura);
                if (edit == -1)
                {
                    Chamados[NumeroChamados] = chamado;
                    NumeroChamados++;
                }
                else { Chamados[edit] = chamado; }
                Console.WriteLine("Chamado criado com sucesso!");
                Console.ReadLine();
            }
        }
        public void VisualizarChamados()
        {
            int i = 0;
            foreach (Chamado cham in Chamados)
            {
                if (!(cham == null))
                {
                    Console.WriteLine($"Número do chamado: {i}");
                    Console.WriteLine(cham);
                    Console.WriteLine();
                }
                i++;
            }
            Console.ReadLine();
        }

        public void EditarChamado()
        {
            int n = NumeroValido("chamado");
            if (n > numeroChamados || n < 1 || Chamados[n] == null)
            {
                Console.WriteLine("Digite um número de chamado existente.");
            }
            else { CriarChamado(n); }
        }

        public void RemoverChamado()
        {
            int n = NumeroValido("chamado que deseja remover");
            if (n > numeroChamados || n < 1 || Chamados[n] == null)
            {
                Console.WriteLine("Digite um número de chamado existente.");
            }
            else { Chamados[n] = null; Console.WriteLine("Chamado removido."); Console.ReadLine(); }
        }

    }
}
