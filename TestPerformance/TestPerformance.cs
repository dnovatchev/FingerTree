using System;
using System.Collections.Generic;
using System.Linq;
using FingerTree;


namespace TestPerformance
{
    class TestPerformance
    {
        static void Main(string[] args)
        {
            int nLength = 10000;
            uint nRepeat = 100000;

            List<short> intContent = new List<short>();

            for (short i = 0; i < nLength; i++)
                intContent.Add(i);

            PerfTest<short> shortPerfTest = new PerfTest<short>(nLength, nRepeat, intContent);

            double milliseconds = shortPerfTest.ReverseArray();
            double x = milliseconds + 333;

            milliseconds = shortPerfTest.ReverseTree();
            x = milliseconds + 333;

            milliseconds = shortPerfTest.ReverseList();
            x = milliseconds + 333;

            milliseconds = shortPerfTest.PopulateArray();
            x = milliseconds + 333;

            milliseconds = shortPerfTest.PopulateTree();
            x = milliseconds + 333;

            milliseconds = shortPerfTest.PopulateList();
            x = milliseconds + 333;

            milliseconds = shortPerfTest.PopFrontArray();
            x = milliseconds + 333;

            double msecs2 = shortPerfTest.PopFrontTree();
            double y = msecs2 + 333;

             msecs2 = shortPerfTest.PopFrontList();
             y = msecs2 + 333;

            double msecs3 = shortPerfTest.PeekFrontArray();
            y = msecs3 + 333;

            double msecs4 = shortPerfTest.PushFrontArray();
            y = msecs4 + 333;

            double msecs5 = shortPerfTest.PushFrontTree();
            y = msecs5 + 333;

            msecs5 = shortPerfTest.PushFrontList();
            y = msecs5 + 333;

            double msecs6 = shortPerfTest.PushBackArray();
            y = msecs6 + 333;

            double msecs7 = shortPerfTest.PushBackTree();
            y = msecs7 + 333;

            msecs7 = shortPerfTest.PushBackList();
            y = msecs7 + 333;

            double msecs8 = shortPerfTest.ConcatArray();
            y = msecs8 + 333;

            double msecs9 = shortPerfTest.ConcatTree();
            y = msecs9 + 333;

            msecs9 = shortPerfTest.ConcatList();
            y = msecs9 + 333;

            double msecs10 = shortPerfTest.PeekMiddleArray();
            y = msecs10 + 333;

            double msecs11 = shortPerfTest.PeekMiddleTree();
            y = msecs11 + 333;

            double msecs12 = shortPerfTest.InsertAtMidArray();
            y = msecs12 + 333;

            double msecs14 = shortPerfTest.InsertAtMidTree();
            y = msecs14 + 333;

            double msecs15 = shortPerfTest.RemoveAtMidArray();
            y = msecs15 + 333;

            double msecs16 = shortPerfTest.RemoveAtMidTree();
            y = msecs16 + 333;

        }

        public class PerfTest<T>
        {
            public UInt32 nOperations = 0;
            public int nContLength = 10000;
            public List<T> theContainer;

            public PerfTest(int contLength, UInt32 nOperations, IEnumerable<T> contents)
            {
                this.nContLength = contLength;

                this.nOperations = nOperations;

                theContainer = new List<T>(contents);
            }

            public double PopulateArray()
            {
                List<T> tempContainer;

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < 1000; i++)
                {
                    tempContainer = new List<T>(theContainer);
                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;

            }

            public double PopulateTree()
            {
                FTree<T> tempTree;

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < 1000; i++)
                {

                    //tempTree = popTree(theContainer);

                    tempTree = FTree<T>.FromSequence(theContainer);
                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;

            }

            public double ReverseList()
            {
                LinkedList<T> theList = new LinkedList<T>(theContainer);

                DateTime start = DateTime.Now;
                    for (UInt32 i = 0; i < 1000; i++)
                    {
                        LinkedList<T> tempList = new LinkedList<T>(theList.Reverse());
                    }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }


            public double PopulateList()
            {
                DateTime start = DateTime.Now;
                    for (UInt32 i = 0; i < 1000; i++)
                    {
                        LinkedList<T> theList = new LinkedList<T>();

                        foreach(T t in theContainer)
                            theList.AddLast(t);
                    }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }


            public double ReverseArray()
            {
                Double milliSeconds = 0D;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    List<T> tempContainer = new List<T>(theContainer);
                    DateTime start = DateTime.Now;
                    {
                        tempContainer.Reverse();
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }
            //FTree<T> popTree(List<T> aContainer)
            //{
            //    int nLength = aContainer.Count;
            //    if (nLength < 750)
            //        return FTree<T>.FromSequence(aContainer);
            //    //else
            //    int halfLength = nLength / 2;
            //    {
            //        FTree<T> tree1 = popTree(aContainer.GetRange(0, halfLength));
            //        FTree<T> tree2 = popTree(aContainer.GetRange(halfLength, nLength - halfLength));

            //        return tree1.Merge(tree2);
            //    }

            //}

            public Double PopFrontArray()
            {
                Double milliSeconds = 0D;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    List<T> tempContainer = new List<T>(theContainer);
                    DateTime start = DateTime.Now;
                    {
                        T head = tempContainer[0];
                        tempContainer.RemoveAt(0);
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public Double PopFrontList()
            {
                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    LinkedList<T> tempContainer = new LinkedList<T>(theContainer);
                    {
                        T head = tempContainer.First.Value;
                        tempContainer.RemoveFirst();
                    }

                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }

            public Double PushFrontList()
            {
                T t = default(T);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    LinkedList<T> tempContainer = new LinkedList<T>(theContainer);
                    {
                        tempContainer.AddFirst(t);
                    }

                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }

            public Double PushBackList()
            {
                T t = default(T);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    LinkedList<T> tempContainer = new LinkedList<T>(theContainer);
                    {
                        tempContainer.AddLast(t);
                    }

                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }

            public Double PushFrontArray()
            {
                T t = default(T);

                Double milliSeconds = 0D;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    List<T> tempContainer = new List<T>(theContainer);
                    DateTime start = DateTime.Now;
                    {
                        tempContainer.Insert(0, t); ;
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }
           
            public Double PushBackArray()
            {
                T t = default(T);

                Double milliSeconds = 0D;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    List<T> tempContainer = new List<T>(theContainer);
                    DateTime start = DateTime.Now;
                    {
                        tempContainer.Add(t);
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public double ConcatArray()
            {
                List<T> secndContainer = new List<T>(theContainer);
                Double milliSeconds = 0D;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    List<T> tempContainer = new List<T>(theContainer);
                    DateTime start = DateTime.Now;
                    {
                        tempContainer.AddRange(secndContainer);
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public Double ConcatList()
            {
                Double milliSeconds = 0D;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    LinkedList<T> tempContainer = new LinkedList<T>(theContainer);
                    
                    DateTime start = DateTime.Now;
                        {
                            foreach(T t in theContainer)
                                tempContainer.AddLast(t);
                        }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;
                }

                return milliSeconds;
            }


            public Double ReverseTree()
            {
                Seq<T> shortSeq = new Seq<T>(theContainer);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    {
                        Seq<T> newSeq = (Seq<T>)shortSeq.Reverse();
                    }

                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }
           
            public Double PushFrontTree()
            {
                T t = default(T);

                FTree<T> myFTree = FTree<T>.FromSequence(theContainer);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    FTree<T> myFTree2 = myFTree.Push_Front(t);
                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }
 
            public Double PushBackTree()
            {
                T t = default(T);


                FTree<T> myFTree = FTree<T>.FromSequence(theContainer);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    FTree<T> myFTree2 = myFTree.Push_Back(t);
                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }

            public Double PeekFrontArray()
            {
                Double milliSeconds = 0D;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    DateTime start = DateTime.Now;
                    {
                        T head = theContainer[0];
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public Double PeekMiddleArray()
            {
                Double milliSeconds = 0D;

                int indMid = nContLength / 2;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    DateTime start = DateTime.Now;
                    {
                        T elem = theContainer[indMid];
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public Double InsertAtMidArray()
            {
                Double milliSeconds = 0D;

                T t = default(T);

                int indMid = nContLength / 2;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    DateTime start = DateTime.Now;
                    {
                        List<T> newContainer = theContainer.GetRange(0, indMid - 1);
                        newContainer.Add(t);
                        newContainer.AddRange
                            (theContainer.GetRange(indMid, nContLength - indMid));
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public Double RemoveAtMidArray()
            {
                Double milliSeconds = 0D;

                int indMid = nContLength / 2;

                for (UInt32 i = 0; i < nOperations; i++)
                {
                    DateTime start = DateTime.Now;
                    {
                        List<T> newContainer = theContainer.GetRange(0, indMid - 1);
                        newContainer.AddRange
                            (theContainer.GetRange(indMid + 1, nContLength - indMid - 1));
                    }
                    DateTime end = DateTime.Now;

                    milliSeconds += (end - start).TotalMilliseconds;

                }
                return milliSeconds;
            }

            public Double InsertAtMidTree()
            {
                uint indMid = (uint)(nContLength / 2);

                T t = default(T);

                Seq<T> shortSeq = new Seq<T>(theContainer);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    {
                        Seq<T> newSeq = shortSeq.InsertAt(indMid, t);
                    }

                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }

            public Double RemoveAtMidTree()
            {
                uint indMid = (uint)(nContLength / 2);

                Seq<T> shortSeq = new Seq<T>(theContainer);

                DateTime start = DateTime.Now;
                for (UInt32 i = 0; i < nOperations; i++)
                {
                    {
                        Seq<T> newSeq = shortSeq.RemoveAt(indMid);
                    }

                }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }


            public Double PeekMiddleTree()
            {
                uint indMid = (uint) (nContLength / 2);

                Seq<T> shortSeq = new Seq<T>(theContainer);

                DateTime start = DateTime.Now;
                    for (UInt32 i = 0; i < nOperations; i++)
                    {
                        {
                            T elem = shortSeq[indMid];
                        }

                    }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }


            public Double PopFrontTree()
            {
                FTree<T> myFTree = FTree<T>.FromSequence(theContainer);

                DateTime start = DateTime.Now;
                    for (UInt32 i = 0; i < nOperations; i++)
                    {
                        FTree<T>.ViewL<T> lView = myFTree.LeftView();

                        T head = lView.head;
                        FTree<T> newFTree = lView.ftTail;
                    }
                DateTime end = DateTime.Now;

                return (end - start).TotalMilliseconds;
            }
            
            public Double ConcatTree()
            {
                FTree<T> myFTree = FTree<T>.FromSequence(theContainer);
                FTree<T> myFTree2 = FTree<T>.FromSequence(theContainer);

                DateTime start = DateTime.Now;
                    for (UInt32 i = 0; i < nOperations; i++)
                    {
                        {
                            FTree<T> newTree = myFTree.Merge(myFTree2); ;
                        }

                    }
                DateTime end = DateTime.Now;
                return (end - start).TotalMilliseconds;
            }
        }
    }
}
