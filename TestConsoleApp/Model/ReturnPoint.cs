using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp.Model
{
    public class ReturnPoint : PipeNetworkElement
    {
        private static int idSeed = 1001;
        public List<int> ParentsIdList;
        public static event Action<ReturnPoint> ReturnPointCreated;

        public ReturnPoint()
        {
            Id = idSeed;
            ParentsList = new List<Pipe>();
            ParentsIdList = new List<int>();
            ReturnPointCreated?.Invoke(this);
            idSeed++;
        }


        public override double HeatLoss()
        {
            double TotalHeatLoss = 0;
            foreach (Pipe pipe in ParentsList)
            {
                TotalHeatLoss += 2 * pipe.Length * pipe.HeatLossPerMeter / pipe.ChildrenList.Count;
            }
            return Math.Floor(TotalHeatLoss*100)/100;
        }
               
    }
}
