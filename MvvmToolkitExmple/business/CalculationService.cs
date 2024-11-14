using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.business
{
    class CalculationService
    {
        public double CalculateCI(double poidsVif, double productionLait, double noteEtatCorps, string parite, int semaineLactation, int semaineGestation, int age)
        {
            double IL = CalculateIL(parite, semaineLactation);
            double IG = CalculateIG(semaineGestation);
            double IM = CalculateIM(age);

           
            double CI = (13.9 + (0.015 * (poidsVif - 600)) + (0.15 * productionLait) + (1.5 * (3 - noteEtatCorps))) * IL * IG * IM;
            return CI;
        }

        private double CalculateIL(string parite, int semaineLactation)
        {
            if (parite == "Primipare")
            {
                if (semaineLactation >= 1 && semaineLactation <= 9) return 0.775;
                if (semaineLactation >= 10 && semaineLactation <= 24) return 0.96;
                return 1;
            }
            if (parite == "Multipare")
            {
                if (semaineLactation >= 1 && semaineLactation <= 9) return 0.83;
                if (semaineLactation >= 10 && semaineLactation <= 24) return 0.97;
                return 1;
            }
            return 1;
        }

        private double CalculateIG(int semaineGestation)
        {
            if (semaineGestation < 30) return 1;
            if (semaineGestation >= 30 && semaineGestation <= 39) return 0.94;
            return 0.80;
        }

        private double CalculateIM(int age)
        {
            if (age >= 20 && age <= 32) return 0.8525;
            if (age > 32 && age <= 44) return 0.945;
            if (age > 44 && age <= 56) return 0.98;
            return 1;
        }
    }

}
