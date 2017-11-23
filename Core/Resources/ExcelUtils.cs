using System;
using Excel = Microsoft.Office.Interop.Excel;
using FC_TestFramework.Core.Utils;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace FC_TestFramework.Core.Resources
{
    public class ExcelUtils
    {
        
        private Excel.Workbook Planilha = null;
        private Excel.Application Aplicacao = null;
        private Excel.Worksheet Folha = null;
        public int UltimaLinha { get; set; }

        public ExcelUtils() { }

        public ExcelUtils(String NomeArquivo, String NomePlanilha)
        {
            LerPlanilha(NomeArquivo, NomePlanilha);
        }

        /**Acessa uma planilha e ler os dados da primeira aba*/
        private void LerPlanilha(String NomeArquivo, String NomePlanilha) {
            String CaminhoArquivo = @"C:\DEV\"+NomeArquivo;

            try
            {
                Aplicacao = new Excel.Application();
                Aplicacao.Visible = false;
                Planilha = Aplicacao.Workbooks.Open(CaminhoArquivo);
                Folha = (Excel.Worksheet)Planilha.Sheets[NomePlanilha];
                UltimaLinha = Folha.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na leitura do arquivo! Motivo: " + e.Message);
            }

        }

        /**Captura o valor de uma célula com conteúdo textual*/
        public string LerCelulaTextual(int NumeroLinha, int NumeroColuna)
        {

            try
            {
                string Celula = Folha.Cells[NumeroLinha,NumeroColuna].Value;
                Console.WriteLine("O conteúdo da célula é: " + Celula);

                return Celula;

            }
            catch (Exception)
            {
                return "";
            }
        }

        /**Captura o valor de uma célula com conteúdo numérico*/
        public long LerCelulaNumerica(int NumeroLinha, int NumeroColuna)
        {

            try
            {
                long Celula = (long)Folha.Cells[NumeroLinha, NumeroColuna].Value.ToString();
                Console.WriteLine("O conteúdo da célula é: " + Celula);

                return Celula;

            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        /**Gravar Resultado Execucao*/
        public void GerarPlanilha(string NomePlanilha,
            string NomeAba, string Caminho,
            List<string> ListaColunas, List<string> ListaDados)
        {

            try
            {
                Excel.Application ApresentacaoResultado = new Excel.Application();
                ApresentacaoResultado.Visible = false;
                Excel.Workbook PlanilhaResultado = ApresentacaoResultado.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

                Excel.Worksheet FolhaResultado = (Excel.Worksheet)PlanilhaResultado.Worksheets[1];

                UltimaLinha = FolhaResultado.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

                //criacao do cabecalho
                int NumeroColuna = 1;
                if (UltimaLinha == 0)
                {
                    foreach (string NomeColuna in ListaColunas)
                    {
                        FolhaResultado.Cells[1, NumeroColuna] = NomeColuna;
                        NumeroColuna++;
                    }
                }

                //populando dados da planilha                
                int NumeroLinha = UltimaLinha;
                for (int i = 1; i < ListaColunas.Count; i++)
                {
                    FolhaResultado.Cells[NumeroLinha, i] = ListaDados[i - 1];
                }

                PlanilhaResultado.Sheets[1].Name = NomeAba;
                PlanilhaResultado.SaveAs(Caminho + "\\" + NomePlanilha + "_" +
                    new DateUtils().DataAtualSemEspeciais() + ".xlsx");

                PlanilhaResultado.Close();
                ApresentacaoResultado.Quit();

                Marshal.ReleaseComObject(FolhaResultado);
                Marshal.ReleaseComObject(PlanilhaResultado);
                Marshal.ReleaseComObject(ApresentacaoResultado);

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu erro ao gravar a planilha de resultado dos testes. Motivo: " + e.Message);
            }
        }

    }
}
