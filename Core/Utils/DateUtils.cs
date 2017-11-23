using System;

namespace FC_TestFramework.Core.Utils
{
    public class DateUtils
    {
        public DateUtils() { }

        /**Data e Hora atual formatada*/
        public virtual String DataHoraAtual()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /**Data atual formatada*/
        public virtual String DataAtualFormatada() {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        /**Data atual sem formatação*/
        public virtual String DataAtualSemEspeciais()
        {
            return DateTime.Now.ToString("ddMMyyyy");
        }

        /**Data Atual Somando ou Subtraindo Dias*/
        /**Exemplos de chamada:          
           CalculaData(D0): Retornara Data Atual
           CalculaData(D+5): Retornara Data Atual + 5 Dias
           CalculaData(D-5): Retornara Data Atual - 5 Dias
        */
        public virtual String CalculaData(string Data)
        {            
            if (Data.Equals("D-0") || Data.Equals("D0"))
            {
                return this.DataAtualSemEspeciais();
            }
            else
            {
                DateTime Hoje = DateTime.Now;
                Char[] QtdDias = Data.ToCharArray();
                string DataAlterada;

                if (QtdDias.GetUpperBound(0) == 2)
                {
                    string Dia = QtdDias[1].ToString() + QtdDias[2].ToString();
                    DataAlterada = Hoje.AddDays(Convert.ToInt16(Dia)).ToString("ddMMyyyy");
                }
                else
                {
                    string Dia = QtdDias[1].ToString() + QtdDias[2].ToString() + QtdDias[3].ToString();
                    DataAlterada = Hoje.AddDays(Convert.ToInt16(Dia)).ToString("ddMMyyyy");
                }
                
                return DataAlterada;                
            }            
        }

        /**Data parametrizada sem formatação*/
        public virtual String DataSemEspeciais(DateTime Data)
        {
            return Data.ToString("ddMMyyyy");
        }

        /**Hora atual formatada*/
        public virtual String HoraAtualFormatada()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /**Hora atual sem formatação*/
        public virtual String HoraAtualSemEspeciais()
        {
            return DateTime.Now.TimeOfDay.ToString("HHmm");
        }

        /**Hora atual sem formatação com segundos*/
        public virtual String HoraAtualComSegundos()
        {
            return DateTime.Now.TimeOfDay.ToString("HHmmss");
        }

        /**Hora parametrizada no formato 24Hmm*/
        public virtual String HoraSemEspeciais(DateTime Data)
        {
            return Data.TimeOfDay.Hours.ToString()+"H"
                + Data.TimeOfDay.Minutes.ToString();
        }

        /**Hora atual no formato AMPM*/
        public virtual String HoraAtualAMPM()
        {
            TimeSpan Data = DateTime.Now.TimeOfDay;
            return Data.Hours + "H" + Data.Minutes;
        }

        /**Transforma a porção Data do DateTime em String no formato dd/MM/yyyy*/
        public virtual String FormatarData(DateTime Data)
        {
            return Data == null ? "Data não informada." : Data.ToString("dd/MM/yyyy");
        }

        /**Transforma a porção Hora do DateTime em String no formato HH:mm:ss*/
        public virtual String FormatarHora(DateTime Hora)
        {
            return Hora == null ? "Hora não informada." : Hora.ToString("HH:mm:ss");
        }

        /**Transforma Data e Hora do DateTime em String no formato dd/MM/yyyy HH:mm:ss*/
        public virtual String FormatarDataHora(DateTime Data)
        {
            return Data == null ? "Data não informada." : Data.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /**Devolve DateTime de Data Inferior àquela informada*/
        public virtual DateTime DataMenor(DateTime Data, int QtdDias)
        {
            return Data.AddDays(-QtdDias);
        }

        /**Devolve String de Data Inferior àquela informada*/
        public virtual string DataMenorFormatada(DateTime Data, int QtdDias)
        {
            return FormatarData(Data.AddDays(-QtdDias));
        }

        /**Devolve DateTime de Data Superior àquela informada*/
        public virtual DateTime DataMaior(DateTime Data, int QtdDias)
        {
            return Data.AddDays(-QtdDias);
        }

        /**Devolve String de Data Superior àquela informada*/
        public virtual string DataMaiorFormatada(DateTime Data, int QtdDias)
        {
            return FormatarData(Data.AddDays(Data.Day+QtdDias));
        }

        /**Devolve String de Hora Superior àquela informada*/
        public virtual string PegarHoraMaior(DateTime Data, double QtdHorasSuperior)
        {
            if (Data.Hour < 24)
                return Data.AddHours((Data.Hour) + QtdHorasSuperior).ToString("HH:mm");
            else if (Data.Hour == 0)
                return "23:59";

            return "Hora Informada Incorreta!";
        }

    }
}
