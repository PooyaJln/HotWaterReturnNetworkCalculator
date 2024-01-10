using TestConsoleApp.Model;
using System.Collections.Generic;
using System;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PipeNetworkElement> PipeNetworkElements = new List<PipeNetworkElement>();

            void OnPipeCreated(Pipe pipe)
            {
                PipeNetworkElements.Add(pipe);
            }

            // Subscribe to the PipeCreated event
            Pipe.PipeCreated += OnPipeCreated;

            void OnReturnPointCreated(ReturnPoint returnPoint)
            {
                PipeNetworkElements.Add(returnPoint);
            }
            ReturnPoint.ReturnPointCreated += OnReturnPointCreated;

            Pipe pipe1 = new Pipe();
            pipe1.Id = 1;
            pipe1.Length = 1;
            //PipeNetworkElements.Add(pipe1);

            Pipe pipe2 = new Pipe();
            pipe2.Length = 2;
            pipe2.ParentId = pipe1.Id;
            //PipeNetworkElements.Add(pipe2);

            Pipe pipe4 = new Pipe();
            pipe4.Length = 4;
            pipe4.ParentId = pipe2.Id;
            //PipeNetworkElements.Add(pipe4);

            ReturnPoint returnPoint1001 = new ReturnPoint();
            returnPoint1001.ParentId = pipe4.Id;
            //PipeNetworkElements.Add(returnPoint1001);

            Pipe pipe5 = new Pipe();
            pipe5.Length = 5;
            pipe5.ParentId = pipe2.Id;
            //PipeNetworkElements.Add(pipe5);
            
            Pipe pipe10 = new Pipe();
            pipe10.Length = 10;
            pipe10.ParentId = pipe5.Id;
            //PipeNetworkElements.Add(pipe10);

            ReturnPoint returnPoint1002 = new ReturnPoint();
            returnPoint1002.ParentId = pipe10.Id;
            //PipeNetworkElements.Add(returnPoint1002);

            Pipe pipe11 = new Pipe();
            pipe11.Length = 11;
            pipe11.ParentId = pipe5.Id;
            //PipeNetworkElements.Add(pipe11);

            ReturnPoint returnPoint1003 = new ReturnPoint();
            returnPoint1003.ParentId = pipe11.Id;
            //PipeNetworkElements.Add(returnPoint1003)
                ;

            Pipe pipe3 = new Pipe();
            pipe3.Length = 3;
            pipe3.ParentId = pipe1.Id;
            //PipeNetworkElements.Add(pipe3);

            Pipe pipe6 = new Pipe()
            {
                Length = 6,
                ParentId = pipe3.Id,
            };
            //PipeNetworkElements.Add(pipe6);

            ReturnPoint returnPoint1004 = new ReturnPoint();
            returnPoint1004.ParentId = pipe6.Id;
            //PipeNetworkElements.Add(returnPoint1004);

            Pipe pipe7 = new Pipe()
            {
                Length = 7,
                ParentId = pipe3.Id,
            };
            //PipeNetworkElements.Add(pipe7);

            Pipe pipe8 = new Pipe()
            {
                Length = 8,
                ParentId = pipe7.Id,
            };
            //PipeNetworkElements.Add(pipe8);

            ReturnPoint returnPoint1005 = new ReturnPoint();
            returnPoint1005.ParentId = pipe8.Id;
            //PipeNetworkElements.Add(returnPoint1005);

            Pipe pipe9 = new Pipe() 
            {
                Length = 9,
                ParentId = pipe7.Id,
            };
            //PipeNetworkElements.Add(pipe9);

            ReturnPoint returnPoint1006 = new ReturnPoint();
            returnPoint1006.ParentId = pipe9.Id;
            //PipeNetworkElements.Add(returnPoint1006);





            List<Pipe> FilterPipes(List<PipeNetworkElement> list)
            {
                List<Pipe> result = new List<Pipe>();
                foreach(PipeNetworkElement element in list)
                {
                    if( element is Pipe )
                    {
                        Pipe Pipe = (Pipe)element;
                        result.Add(Pipe);
                    }
                }
                return result;
            }

            List<ReturnPoint> FilterReturnPoints(List<PipeNetworkElement> list)
            {
                List<ReturnPoint> result = new List<ReturnPoint>();
                foreach (PipeNetworkElement element in list)
                {
                    if (element is ReturnPoint)
                    {
                        ReturnPoint ReturnPoint = (ReturnPoint)element;
                        result.Add(ReturnPoint);
                    }
                }
                return result;
            }
            
            List <ReturnPoint> returnPoints = FilterReturnPoints(PipeNetworkElements);
            List<Pipe> Pipes= FilterPipes(PipeNetworkElements);

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

            foreach (PipeNetworkElement element in PipeNetworkElements)
            {
                Console.WriteLine($"the Element {element.Id} type is '{element.GetType().Name}' and its parent id is {element.ParentId}");
            }

        }
    }
}
