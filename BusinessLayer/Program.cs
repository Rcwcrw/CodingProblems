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
            var delegatePracticeService = new DelegatePracticeService();
            var anonLamdaFuncService = new AnonLamdaFuncService();
            var databaseService = new DatabaseService();
            var geneInterviewSerive = new GeneInterviewService();
            var adventOfCode1Service = new AdventOfCode1Service();
            var adventOfCode2Service = new AdventOfCode2Service();
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
            //stringShuffleService.ConsoleRun();
            //delegatePracticeService.ConsoleRun();
            //anonLamdaFuncService.ConsoleRun();
            //databaseService.ConsoleRun();
            adventOfCode2Service.ConsoleRun();
        }
    }    
}
