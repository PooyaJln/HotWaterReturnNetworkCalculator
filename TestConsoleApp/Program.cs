using TestConsoleApp.Model;
using System.Collections.Generic;
using System;
using System.Xml.Linq;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PipeNetworkElement> PipeNetworkElements = new List<PipeNetworkElement>();
            List<Pipe> Pipes = new List<Pipe>();
            
            List<ReturnPoint> ReturnPoints = new List<ReturnPoint>();

            void OnPipeCreated(Pipe pipe)
            {   
                PipeNetworkElements.Add(pipe);
                Pipes.Add(pipe);
            }

            // Subscribe to the PipeCreated event
            Pipe.PipeCreated += OnPipeCreated;

            void OnReturnPointCreated(ReturnPoint returnPoint)
            {
                PipeNetworkElements.Add(returnPoint);
                ReturnPoints.Add(returnPoint);
            }
            ReturnPoint.ReturnPointCreated += OnReturnPointCreated;

            Pipe pipe1 = new Pipe();
            pipe1.Id = 1;
            pipe1.Length = 1;
            pipe1.HeatLossPerMeter = 1;
            

            Pipe pipe2 = new Pipe();
            pipe2.Id = 2;
            pipe2.Length = 2;
            pipe2.ParentId = pipe1.Id;
            pipe2.HeatLossPerMeter = 2;
            
            Pipe pipe4 = new Pipe();
            pipe4.Id = 4;
            pipe4.Length = 4;
            pipe4.ParentId = pipe2.Id;
            
            ReturnPoint returnPoint1001 = new ReturnPoint();
            returnPoint1001.Id = 1001;
            returnPoint1001.ParentId = pipe4.Id;
            

            Pipe pipe5 = new Pipe();
            pipe5.Id = 5;
            pipe5.Length = 5;
            pipe5.ParentId = pipe2.Id;
                        
            Pipe pipe10 = new Pipe();
            pipe10.Id = 10;
            pipe10.Length = 10;
            pipe10.ParentId = pipe5.Id;
            

            ReturnPoint returnPoint1002 = new ReturnPoint();
            returnPoint1002.Id = 1002;
            returnPoint1002.ParentId = pipe10.Id;
            

            Pipe pipe11 = new Pipe();
            pipe11.Id = 11;
            pipe11.Length = 11;
            pipe11.ParentId = pipe5.Id;
            

            ReturnPoint returnPoint1003 = new ReturnPoint();
            returnPoint1003.Id = 1003;
            returnPoint1003.ParentId = pipe11.Id;

            Pipe pipe3 = new Pipe();
            pipe3.Id = 3;
            pipe3.Length = 3;
            pipe3.ParentId = pipe1.Id;
            



            Pipe pipe6 = new Pipe()
            {
                Id = 6,
                Length = 6,
                ParentId = pipe3.Id,
            };
            

            ReturnPoint returnPoint1004 = new ReturnPoint();
            returnPoint1004.Id = 1004;
            returnPoint1004.ParentId = pipe6.Id;
            
            Pipe pipe7 = new Pipe()
            {
                Id = 7,
                Length = 7,
                ParentId = pipe3.Id,
            };
            
            Pipe pipe8 = new Pipe()
            {
                Id = 8,
                Length = 8,
                ParentId = pipe7.Id,
            };
            
            ReturnPoint returnPoint1005 = new ReturnPoint();
            returnPoint1005.Id = 1005;
            returnPoint1005.ParentId = pipe8.Id;
            
            Pipe pipe9 = new Pipe() 
            {
                Id = 9,
                Length = 9,
                ParentId = pipe7.Id,
            };
            
            ReturnPoint returnPoint1006 = new ReturnPoint();
            returnPoint1006.Id = 1006;
            returnPoint1006.ParentId = pipe9.Id;
           


            List<Pipe> PopulateParentList (PipeNetworkElement pipeNetworkElement, List<Pipe> pipeList) 
            {
                if (pipeNetworkElement.Id != 1)
                {   
                    Pipe parentPipe = Pipes.Find(pipe => pipe.Id == pipeNetworkElement.ParentId);
                    if (parentPipe != null) 
                    {
                        pipeList.Add(parentPipe);                        
                    }
                    
                    PopulateParentList(parentPipe, pipeList);
                }
                return pipeList;
                
            }

            void PopulatePipeChildrenList(ReturnPoint returnPoint)
            {
                foreach (Pipe pipe in returnPoint.ParentsList)
                {
                    pipe.ChildrenList.Add(returnPoint);
                    pipe.ChildrenIdList.Add(returnPoint.Id);
                }
            }

            void PopulateParentsIdList(ReturnPoint returnPoint)
            {
                foreach (Pipe pipe in returnPoint.ParentsList)
                {
                    returnPoint.ParentsIdList.Add(pipe.Id);
                }
            }

            static void printList(List<int> someList)
            {
                Console.Write("{");
                foreach (int item in someList)
                {
                    Console.Write(item);
                    if (!item.Equals(someList.Last()))
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("}");
                Console.WriteLine();
            }

            //foreach (PipeNetworkElement element in PipeNetworkElements)
            //{
            //    Console.WriteLine($"the Element {element.Id} type is '{element.GetType().Name}' and its parent id is {element.ParentId}");
            //}

            foreach (ReturnPoint returnPoint in ReturnPoints)
            {
                PopulateParentList(returnPoint, returnPoint.ParentsList);
                PopulateParentsIdList(returnPoint);
                PopulatePipeChildrenList(returnPoint);
            }

            foreach (Pipe pipe in Pipes)
            {
                Console.WriteLine($"the Pipe {pipe.Id}'s heatLossPerMeter is {pipe.HeatLossPerMeter} and it supplies {pipe.ChildrenList.Count} return points and those are:");
                printList(pipe.ChildrenIdList);
                Console.WriteLine();
            }

            foreach (ReturnPoint returnPoint in ReturnPoints)
            {
                Console.WriteLine($"returnPoint {returnPoint.Id}'s parents list has {returnPoint.ParentsList.Count} members");
                printList(returnPoint.ParentsIdList);
                Console.WriteLine($"the Element {returnPoint.Id}'s heatLoss is {returnPoint.HeatLoss()}");
                Console.WriteLine();
            }

            //Pipe GetParentPipe(PipeNetworkElement element, List<Pipe> list)
            //{
            //    Pipe ParentPipe = list.Find(pipe => pipe.Id == element.ParentId);
            //    if ( ParentPipe != null ) { return ParentPipe; }
            //}

            //void PopulateParentsList(List<PipeNetworkElement> list)
            //{
            //    foreach(PipeNetworkElement element in list)
            //    {
            //        Pipe Parent = GetParentPipe(element, Pipes);
            //        element.ParentsList.Add(Parent);
            //        List<Pipe> reducedPipes = Pipes.Where(pipe => pipe != Parent).ToList();

            //    }
            //};



        }
    }
}
