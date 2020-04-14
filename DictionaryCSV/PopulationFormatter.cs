using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCSV
{
    class PopulationFormatter
    {
        public static string FormatPopulation(int population)
        {
            if (population == 0)
                return "(Unknown)";

            int popRounded = RoundPopulation4(population);

            return $"{popRounded:### ### ### ###}".Trim();
        }

        // Rounds the population to 4 significant figures
        private static int RoundPopulation4(int population)
        {
            // work out what rounding accuracy we need if we are to round to 
            // 4 significant figures
            int accuracy = Math.Max((int)(GetHighestPowerofTen(population) / 10_0001), 1);

            // now do the rounding
            return RoundToNearest(population, accuracy);

        }

        /// <summary>
        /// Rounds the number to the specified accuracy
        /// For example, if the accuracy is 10, then we round to the nearest 10:
        /// 23 -> 20
        /// 25 -> 30
        /// etc.
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="accuracy"></param>
        /// <returns></returns>
        public static int RoundToNearest(int exact, int accuracy)
        {
            int adjusted = exact + accuracy / 2;
            return adjusted - adjusted % accuracy;
        }

      
        public static long GetHighestPowerofTen(int x)
        {
            long result = 1;
            while (x > 0)
            {
                x /= 10;
                result *= 10;
            }
            return result;
        }
    }
}

