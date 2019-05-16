using System;

namespace Projeto_Medicamento
{
    class Program
    {
        static Medicamento medicamento;
        static Medicamentos medicamentos;

        static void Main(string[] args)
        {
            medicamentos = new Medicamentos();
            int opcao = 1;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(15, 5); Console.Write("---------------------- MENU ----------------------");
                Console.SetCursorPosition(15, 6); Console.Write("0. Finalizar processo");
                Console.SetCursorPosition(15, 7); Console.Write("1. Cadastrar medicamento");
                Console.SetCursorPosition(15, 8); Console.Write("2. Consultar medicamento (sintético)");
                Console.SetCursorPosition(15, 9); Console.Write("3. Consultar medicamento (analítico)");
                Console.SetCursorPosition(15, 10); Console.Write("4. Comprar medicamento (cadastrar lote)");
                Console.SetCursorPosition(15, 11); Console.Write("5. Vender medicamento (abater do lote mais antigo)");
                Console.SetCursorPosition(15, 12); Console.Write("6. Listar medicamentos (informar dados sintéticos)");
                Console.SetCursorPosition(15, 13); Console.Write("--------------------------------------------------");
                Console.SetCursorPosition(15, 15); Console.Write("--------------------------------------------------");
                Console.SetCursorPosition(15, 14); Console.Write("Opção: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao > 6) {
                        Console.Clear();
                        Console.SetCursorPosition(17, 9); Console.Write("---------------------------------------------");
                        Console.SetCursorPosition(17, 11); Console.Write("---------------------------------------------");
                        Console.SetCursorPosition(17, 10); Console.Write("Opção inválida, escolha um número entre 0 e 6");
                        Console.ReadKey();
                    }
                }
                catch {
                    Console.Clear();
                    Console.SetCursorPosition(17, 9); Console.Write("---------------------------------------------");
                    Console.SetCursorPosition(17, 11); Console.Write("---------------------------------------------");
                    Console.SetCursorPosition(17, 10); Console.Write("Opção inválida, escolha um número entre 0 e 6");
                    Console.ReadKey();
                    continue;
                }
                switch (opcao)
                {
                    case 1: cadastrarMedicamento(); break;
                    case 2: consultaSintetico(); break;
                    case 3: consultaAnalitico(); break;
                    case 4: comprarMedicamento(); break;
                    case 5: venderMedicamento(); break;
                    case 6: listarMedicamentos(); break;
                }
            } while (opcao != 0);
        }

        #region Métodos Funcionais

        static public void cadastrarMedicamento() {
            int idMed, idLote, qtde;
            string nome, laboratorio;
            DateTime venc;
            // Cadastro dos dados do medicamento
            Console.Clear();
            Console.SetCursorPosition(17, 3); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 4); Console.Write("          Cadastro do Medicamento            ");
            Console.SetCursorPosition(17, 5); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 9); Console.Write("---------------------------------------------");
            
Console.SetCursorPosition(17, 6); Console.Write("Id: ");idMed = entraInt();
            Console.SetCursorPosition(17, 7); Console.Write("Nome: ");nome = Console.ReadLine();
            Console.SetCursorPosition(17, 8); Console.Write("Laboratório: ");laboratorio = Console.ReadLine();

            // Cadastrando o lote ao qual o medicamento pertence
            Console.SetCursorPosition(17, 12); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 10); Console.Write("Id do Lote: ");idLote = entraInt();
            Console.SetCursorPosition(17, 11); Console.Write("Quantidade: ");qtde = entraInt();
            Console.SetCursorPosition(17, 14); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 7); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 13); Console.Write("              Data de Vencimento:            ");
            venc = entraData();
            if (venc != DateTime.MinValue)
            {
                // Adicionando na lista de medicamentos
                medicamento = new Medicamento(idMed, nome, laboratorio);
                medicamentos.adicionar(medicamento);
                medicamento.comprar(new Lote(idLote, qtde, venc));
                Console.Clear();
                Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 9); Console.Write("     Medicamento adicionado com sucesso!     ");
                Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
            }
            }

        static public void consultaSintetico(){
            Console.Clear();
            Console.SetCursorPosition(17, 6); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 7); Console.Write("              Consulta Sintética             ");
            Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 9); Console.Write("Digite o ID do medicamento. ");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.Clear();
                Console.SetCursorPosition(10, 6); Console.Write("------------------------------------------------------------");
                Console.SetCursorPosition(10, 7); Console.Write("Resultado da Consulta Analitica             ");
                Console.SetCursorPosition(10, 8); Console.Write("------------------------------------------------------------");
                Console.SetCursorPosition(10, 9); Console.Write(medicamento.toString());
                Console.SetCursorPosition(10, 10); Console.Write("------------------------------------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 9); Console.Write("         Medicamento não encontrado!");
                Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                Console.ReadKey();
            }
        }

        static public void consultaAnalitico(){
            Console.Clear();
            Console.SetCursorPosition(17, 6); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 7); Console.Write("              Consulta Analitica             ");
            Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 9); Console.Write("Digite o ID do medicamento.");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.Clear();
                Console.SetCursorPosition(1, 6); Console.Write("------------------------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(1, 7); Console.Write("Resultado da Consulta Analitica             ");
                Console.SetCursorPosition(1, 8); Console.Write("------------------------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(1, 9); Console.Write(medicamento.toString());
                int cont = 10;
                foreach (Lote lote in medicamento.Lotes)
                {
                    Console.SetCursorPosition(1, cont); Console.Write(lote.toString());
                    cont = cont+1;
                }
                Console.SetCursorPosition(1, cont); Console.Write("------------------------------------------------------------------------------------------------------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 9); Console.Write("         Medicamento não encontrado!");
                Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                Console.ReadKey();
            }
        }

        static public void comprarMedicamento() {
            int idLote, qtde;
            DateTime venc;
            Console.Clear();
            Console.SetCursorPosition(17, 6); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 7); Console.Write("             Compra de Medicamento           ");
            Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 9); Console.Write("Digite o ID do medicamento.");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.SetCursorPosition(17, 11); Console.Write("Id do Lote: "); idLote = entraInt();
                Console.SetCursorPosition(17, 12); Console.Write("Quantidade: "); qtde = entraInt();
                //data de vencimento
                Console.SetCursorPosition(17, 13); Console.Write("Data de Vencimento: ");
                venc = entraData();
                if (venc != DateTime.MinValue)
                {
                    medicamento.comprar(new Lote(idLote, qtde, venc));
                    Console.Clear();
                    Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                    Console.SetCursorPosition(17, 9); Console.Write("     Medicamento adicionado com sucesso!");
                    Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 9); Console.Write("        Medicamento não encontrado!");
                Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                Console.ReadKey();
            }
        }

        static public void venderMedicamento() {
            int qtde;
            Console.Clear();
            Console.SetCursorPosition(17, 6); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 7); Console.Write("             Venda de Medicamento           ");
            Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
            Console.SetCursorPosition(17, 9); Console.Write("Digite o ID do medicamento.");
            medicamento = new Medicamento(entraInt());
            medicamento = medicamentos.pesquisar(medicamento);
            if (medicamento != null)
            {
                Console.SetCursorPosition(17, 11); Console.Write("Quantidade: ");
                qtde = entraInt();
                if (medicamento.vender(qtde))
                {
                    {
                        Console.Clear();
                        Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                        Console.SetCursorPosition(17, 9); Console.Write("           Medicamento vendido!");
                        Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                        Console.ReadKey();
                    }
                    if (medicamentos.deletar(medicamento))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                        Console.SetCursorPosition(17, 9); Console.Write("Lote de medicamento zerado...");
                        Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                        Console.SetCursorPosition(17, 9); Console.Write("Quantidade insuficiente");
                        Console.SetCursorPosition(17, 9); Console.Write("Resta: " + medicamento.qtdeDisponivel() + " no estoque..."); 
                        Console.SetCursorPosition(17, 11); Console.Write("---------------------------------------------");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                    Console.SetCursorPosition(17, 9); Console.Write("           Quantidade insuficiente");
                    Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 9); Console.Write("        Medicamento não encontrado!");
                Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                Console.ReadKey();
            }
        }

        static public void listarMedicamentos() {
            Console.Clear();
            Console.SetCursorPosition(1, 6); Console.Write("------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(1, 7); Console.Write("Lista de todos os medicamentos");
            Console.SetCursorPosition(1, 8); Console.Write("------------------------------------------------------------------------------------------------------------------------------");
            Console.Write("");
            if (medicamentos.ListaMedicamentos.Count != 0)
            {
                int cont = 10;
                foreach (Medicamento medicamento in medicamentos.ListaMedicamentos)
                {
                    Console.SetCursorPosition(1, cont); Console.Write(medicamento.toString());
                    cont = cont + 1;
                }
                Console.SetCursorPosition(1, cont); Console.Write("------------------------------------------------------------------------------------------------------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(17, 8); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 9); Console.Write("               Estoque vazio");
                Console.SetCursorPosition(17, 10); Console.Write("---------------------------------------------");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Esta função previne a inserção de caracteres não numéricos
        /// </summary>
        /// <returns>Se o valor fornecido for um número ela retorna o número válido</returns>
        static public int entraInt() {
            int num=0;
            while (num == 0) {
                try { num = int.Parse(Console.ReadLine()); }
                catch { Console.SetCursorPosition(17, 1); Console.Write("Digite um número válido: "); num = 0; }
            }
            Console.SetCursorPosition(17, 1); Console.Write("                              ");
            return num;
        }

        static public DateTime entraData()
        {
            Console.SetCursorPosition(17, 18); Console.Write("---------------------------------------------");
            DateTime data;
            int dia, mes, ano;
            Console.SetCursorPosition(17, 15); Console.Write("Dia: ");
            dia = entraInt();
            Console.SetCursorPosition(17, 16); Console.Write("Mês: ");
            mes = entraInt();
            Console.SetCursorPosition(17, 17); Console.Write("Ano: ");
            ano = entraInt();
            try
            {
                data = new DateTime(ano, mes, dia);
                if (data.Ticks - DateTime.Now.Ticks > 0)
                    return data;
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(17, 9); Console.Write("---------------------------------------------");
                    Console.SetCursorPosition(17, 11); Console.Write("---------------------------------------------");
                    Console.SetCursorPosition(17, 10); Console.Write("    Medicamento vencido! Cadastre outro."     );
                    Console.ReadKey();
                    return DateTime.MinValue;
                }
            }
            catch
            {
                Console.Clear();
                Console.SetCursorPosition(17, 9); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 11); Console.Write("---------------------------------------------");
                Console.SetCursorPosition(17, 10); Console.Write("               Data inválida!");
                Console.ReadKey();
                return entraData();
            }
        }
        #endregion
    }
}
