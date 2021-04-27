using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOOP.ConsoleApp
{
    class Menu
    {
        private string ops;
        private Gerenciamento gerenciamento = new Gerenciamento();

        public string Ops { get => ops; set => ops = value; }

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("Digite 1 para o Controle de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite alguma tecla além de 1 e 2 para sair do programa");
                Ops = Console.ReadLine();
                if (Ops == "1") { MenuEquipamento(); }
                else if (Ops == "2") { MenuChamadas(); }
                else { break; }
            }
        }

        private void MenuEquipamento()
        {
            while (true)
            {
                Console.WriteLine("Controle de Equipamentos");
                Console.WriteLine("Digite 1 para registrar um novo equipamento");
                Console.WriteLine("Digite 2 para visualizar todos os equipamentos registrados");
                Console.WriteLine("Digite 3 para editar um equipamento");
                Console.WriteLine("Digite 4 para excluir um equipamento do registro");
                Console.WriteLine("Digite qualquer outra tecla para voltar ao menu principal");
                Ops = Console.ReadLine();
                if (Ops == "1") { gerenciamento.CriarEquipamento(); continue; }
                else if (Ops == "2") { gerenciamento.VisualizarEquipamentos(); continue; }
                else if (Ops == "3") { gerenciamento.EditarEquipamento(); continue; }
                else if (Ops == "4") { gerenciamento.RemoverEquipamento(); continue; }
                else { break; }
            }
        }
        private void MenuChamadas()
        {
            while (true)
            {
                Console.WriteLine("Controle de Chamados de Manutenção");
                Console.WriteLine("Digite 1 para registrar um novo chamado");
                Console.WriteLine("Digite 2 para visualizar todos os chamados registrados");
                Console.WriteLine("Digite 3 para editar um chamado");
                Console.WriteLine("Digite 4 para excluir um chamado do registro");
                Console.WriteLine("Digite qualquer outra tecla para voltar ao menu principal");
                Ops = Console.ReadLine();
                if (Ops == "1") { gerenciamento.CriarChamado(); continue; }
                else if (Ops == "2") { gerenciamento.VisualizarChamados(); continue; }
                else if (Ops == "3") { gerenciamento.EditarChamado(); continue; }
                else if (Ops == "4") { gerenciamento.RemoverChamado(); continue; }
                else { break; }
            }
        }
    }
}
