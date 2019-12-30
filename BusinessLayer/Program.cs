using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MergeSort
{
    partial class Program
    {
        static void Main(string[] args)
        {

            var sortService = new SortService();
            var miscService = new MiscService();
            var titleService = new TitleService();
            var wordScoreService = new WordScoreService();
            var piMatchService = new PiMatchService();
            var binaryGapService = new BinaryGapService();
            var oddOccurrencesService = new OddOccurrencesService();
            var cyclicRotation = new CyclicRotationService();
            var frogJumpService = new FrogJumpService();
            var maxCounterService = new MaxCountersService();   
            var adjacencyMatrixService = new AdjacencyMatrixService();
            var stringShuffleService = new StringShuffleService();

            //sortService.ConsoleRun();
            //miscService.ConsoleRun();
            //titleService.ConsoleRun();
            //wordScoreService.ConsoleRun();
            //piMatchService.ConsoleRun();
            //binaryGapService.ConsoleRun();
            //oddOccurrencesService.ConsoleRun();
            //cyclicRotation.ConsoleRun();
            //frogJumpService.ConsoleRun();
            //maxCounterService.ConsoleRun();
            //adjacencyMatrixService.ConsoleRun();
            stringShuffleService.ConsoleRun();
        }
    }    
}
