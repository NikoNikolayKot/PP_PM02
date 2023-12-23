using PP_PM02_Koshenskiy.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PM02_Koshenskiy.classes
{
    internal class SumCompletedRequest
    {
        public int Sum()
        {
            int sumCompletedRequest = 0;
            List<Accounting> accountings = AppModel.dbModel.Accounting.ToList();

            foreach (Accounting accounting in accountings)
            {
                if (accounting.status_id == 6)
                {
                    sumCompletedRequest++;
                }
            }

            return sumCompletedRequest;
        }
    }
}
