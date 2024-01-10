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
        public static event Action<ReturnPoint> ReturnPointCreated;

        public ReturnPoint()
        {
            Id = idSeed;
            ParentsList = new List<Pipe>();
            ReturnPointCreated?.Invoke(this);
            idSeed++;

        }
        public override double HeatLoss()
        {
            double TotalHeatLoss = 0.0;
            foreach (Pipe pipe in ParentsList)
            {
                TotalHeatLoss += pipe.HeatLossPerMeter / pipe.ChildrenList.Count;
            }
            return TotalHeatLoss;
        }


        
    }
}
