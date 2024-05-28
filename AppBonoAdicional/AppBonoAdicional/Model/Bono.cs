using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBonoAdicional.Model
{
    public class Bono
    {
        private double sueldo;
        private int edad;
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public int Edad 
        {
            set
            {
                edad = value;
                if (Edad < 0) throw new Exception("Ingrese un numero de edad positiva");
                if (Edad == 0) throw new Exception("Edad no valida");
                if (Edad < 18) throw new Exception("No tienes edad para trabajar");
            }
            get { return edad; }
        }
        public bool ChckPHP { get; set; }
        public bool ChckASP { get; set; }
        public bool ChckJAVA { get; set; }
        public bool ChckORACLE { get; set; }
        public bool RB1a5 { get; set; }
        public bool RB6a10 { get; set; }


        public Bono()
        {
            Sexo = "";
            Nacionalidad = "";
        }
        public double Sueldo
        {
            set
            {
                sueldo = value;
                if (sueldo < 0) throw new Exception("Ingrese sueldo positivo");
                if (sueldo == 0) throw new Exception("Sueldo no valido");
            }
            get { return sueldo; }
        }

        public double CalcularBono()
        {
            double bono = 0;
            bono = (sueldo * .15);
            if (Sexo == "Femenino") bono += (sueldo * .03);
            //if (Sexo == "Masculino")
            if (Edad > 45) bono += (sueldo * .02);
            //if (Nacionalidad == "Nacional")
            if (Nacionalidad == "Extranjero") bono -= (sueldo * .05);

            if(RB1a5 ||  RB6a10 == true)
            {
                if (RB1a5) bono += (sueldo * .05);
                if (RB6a10) bono += (sueldo * .10);
            }
            else
            {
                throw new Exception("Selecione una opcion de antiguedad");
            }
            if (ChckPHP) bono += (3.00 * 20);
            if (ChckJAVA) bono += (3.00 * 35);
            if (ChckASP) bono += (3.00 * 40);
            if (ChckORACLE) bono += (3.00 * 60);

            return bono;
        }
    }
}
