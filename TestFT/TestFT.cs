using System;
using System.Collections.Generic;
using FingerTree;

namespace TestFT
{
    class TestFT
    {
        static void Main(string[] args)
        {
            //FTree<char> myFT = FTree<char>.FromSequence("Hello, nodes".ToCharArray());
            FTree<char> myFT = FTree<char>.FromSequence("Hello, these are the leaf nodes".ToCharArray());

            myFT = myFT.Push_Front(' ').Push_Front('w').Push_Front('o').Push_Front('W');

            myFT = myFT.Push_Back('.').Push_Back('r').Push_Back('e').Push_Back('p').Push_Back('u').Push_Back('S');

            IEnumerator<char> IcharIter = myFT.ToSequence().GetEnumerator();

            char cX='\0';
            
            if(IcharIter.MoveNext())
                cX = IcharIter.Current;


            FTree<char> FT1 = FTree<char>.FromSequence("Hello, Darling! ".ToCharArray());
            FTree<char> FT2 = FTree<char>.FromSequence("How are you today, dearest?".ToCharArray());

            FTree<char> FT3 = FT1.Merge(FT2);

            foreach (char c in FT3.ToSequence())
                Console.Write(c);

            string theStr = "xxxxx";
            
            foreach (char c in FT3.ToSequenceR())
                Console.Write(c);

            string theEnd = theStr.Substring(0);

            int nCapacity = 100;
            List<int> intArray = new List<int>(nCapacity);

            for(int i = 0; i < nCapacity; i++)
               intArray.Add(i);
            
            Seq<int> myIntSeq = new Seq<int>(intArray);

            //myIntSeq.

            List<int> lstResults = new List<int>(nCapacity);

            for (uint i = 0; i < nCapacity; i++)
                lstResults.Add(myIntSeq[i]);


            uint ind = 1;

            int elemAtInd = myIntSeq[ind];

            int k = elemAtInd + 3;

            Seq<int> myIntSeq2 = new Seq<int>(myIntSeq.Reverse());

            List<int> lstResults2 = new List<int>(nCapacity);

            for (uint i = 0; i < nCapacity; i++)
                lstResults2.Add(myIntSeq2[i]);



            List<int> intList = new List<int>(new int[] { 5, 3, 6, 2, 9, 4 });

            int nCnt = intList.Count;

            List<int> intOrdered = new List<int>();
            
            PriorityQueue<int> myPriQ =
                new PriorityQueue<int>(new int[] { 5, 3, 6, 2, 9, 4 });

             PriorityQueue<int> myPriQ2 = myPriQ;

            while (nCnt > 0)
            {
                nCnt--;
                Pair<int, PriorityQueue<int>> pair1 = myPriQ2.extractMax();

                intOrdered.Add(pair1.first);

                myPriQ2 = pair1.second;
            }

            Console.WriteLine();

            foreach (int nMax in intOrdered)
                Console.Write("{0}, ", nMax);

            Console.WriteLine();

            myPriQ2 = (PriorityQueue<int>)(myPriQ.Push_Front(new CompElem<int>(15)));

            Console.WriteLine(myPriQ2.extractMax().first);

            Console.WriteLine(myPriQ.Push_Front(new CompElem<int>(22)).LeftView().head.Element);
            Console.WriteLine(myPriQ.Push_Back(new CompElem<int>(0)).RightView().last.Element);

            myPriQ2 = (PriorityQueue<int>)(myPriQ.Push_Back(new CompElem<int>(20)));

            Console.WriteLine(myPriQ2.extractMax().first);

            myPriQ2 = (PriorityQueue<int>)(myPriQ.LeftView().ftTail);
            Console.WriteLine(myPriQ.LeftView().head.Element);

            myPriQ2 = (PriorityQueue<int>)(myPriQ.RightView().ftInit);
            Console.WriteLine(myPriQ.RightView().last.Element);

            Console.WriteLine(myPriQ.Push_Front(new CompElem<int>(22)).LeftView().head.Element);
            Console.WriteLine(myPriQ.Push_Back(new CompElem<int>(0)).RightView().last.Element);

            int nXXX = intOrdered[0];

            Console.WriteLine();

            Key<int, int> myKeyObj = new Key<int, int>(-999999, new Key<int, int>.getKey(myId));

            OrderedSequence<int, int> myOrdSeq1 =
                new OrderedSequence<int, int>
                     (myKeyObj,
                      new int[] {1,2,3,4,5,7,8,9}
                     );

            Pair<OrderedSequence<int, int>, OrderedSequence<int, int>> 
                partPair = myOrdSeq1.Partition(5);

            OrderedSequence<int, int> ordSeqPart1 = partPair.first;
            OrderedSequence<int, int> ordSeqPart2 = partPair.second;

            foreach (int iii in ordSeqPart1.ToSequence())
                Console.Write("{0}, ", iii);
            Console.WriteLine();
            foreach (int iii in ordSeqPart2.ToSequence())
                Console.Write("{0}, ", iii);
            Console.WriteLine();

            OrderedSequence<int, int> myOrdSeq2 = myOrdSeq1.Insert(6);
            OrderedSequence<int, int> myOrdSeq3 = myOrdSeq2.Insert(6);
            OrderedSequence<int, int> myOrdSeq4 = myOrdSeq3.Insert(6);

            foreach (int iii in myOrdSeq4.ToSequence())
                Console.Write("{0}, ", iii);
            Console.WriteLine();

            OrderedSequence<int, int> myOrdSeq5 = myOrdSeq4.DeleteAll(6);
            foreach (int iii in myOrdSeq5.ToSequence())
                Console.Write("{0}, ", iii);
            Console.WriteLine();

            OrderedSequence<int, int> myOrdSeq6 =
                new OrderedSequence<int, int>
                     (myKeyObj,
                      new int[] { 1, 3, 5, 7, 9, 11 }
                     );

            OrderedSequence<int, int> myOrdSeq7 =
                new OrderedSequence<int, int>
                     (myKeyObj,
                      new int[] { 0, 2, 4, 6, 8, 10, 12 }
                     );

            OrderedSequence<int, int> myOrdSeq8 =
               myOrdSeq6.Merge(myOrdSeq7);
            foreach (int iii in myOrdSeq8.ToSequence())
                Console.Write("{0}, ", iii);
            Console.WriteLine();


            OrderedSequence<int, int> myOrdSeq9 =
                new OrderedSequence<int, int>(myKeyObj);

            foreach (int i in new int[] { 9, 3, -2, 5, 11, 4, 2 })
                myOrdSeq9 = myOrdSeq9.Insert(i);

            foreach(int i in myOrdSeq9.ToSequence())
                Console.Write("{0}, ", i);
            Console.WriteLine();


        }

        public static int myId(int i)
        {
            return i;
        }
    }
}
