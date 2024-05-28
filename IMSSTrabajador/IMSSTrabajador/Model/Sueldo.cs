using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSSTrabajador.Model
{
    public class Sueldo
    {
        private double SueldoT;
        public int Categoria { get; set; }
        public bool RdbAntiguedad_5 { get; set; }
        public bool RdbAntiguedad_10 { get; set; }
        public bool ChkCertificacion2001 { get; set; }
        public bool ChkCertificacion9001 { get; set; }

        public double P_Sueldo
        {
            set
            {
                SueldoT = value;
                if (SueldoT < 0) throw new Exception("Capture valores positivos");
                if (SueldoT == 0) throw new Exception("Sueldo no valido");
            }
            get { return SueldoT; }
        }

        public double Calcula_NuevoSueldo()
        {
            double Aumento = 0;
            if (Categoria == 2) Aumento = SueldoT * 0.02;
            if (Categoria == 4) Aumento = SueldoT * 0.03;
            if (Categoria == 5) Aumento = SueldoT * 0.04;
            if (Categoria == 7) Aumento = SueldoT * 0.05;

            if(((RdbAntiguedad_5) || (RdbAntiguedad_10)) == true)
            {
                if (RdbAntiguedad_5) Aumento += SueldoT * 0.02;

                if (RdbAntiguedad_10) Aumento += + SueldoT * 0.03;
            }
            else
            {
                throw new Exception("Seleccione una antiguedad");
            }
            if(ChkCertificacion2001) Aumento += SueldoT * 0.02;

            if(ChkCertificacion9001) Aumento += SueldoT * 0.03;
            
            return SueldoT + Aumento;
        }
    }
}
