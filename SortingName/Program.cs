// FILENAME    : Program.cs
// ==========================================================
//  
// AUTHOR      : FADHLY PERMATA
// CREATED AT  : 2018-10-18
// 
// ==========================================================

#region REFFERENCES

using System;
using System.Linq;
using System.Collections.Generic;
using Data.Context;
using Data.Models;
using Utilities.Extensions;

#endregion

namespace SortingName
{
    internal class Program
    {
        #region VARS

        private const string STARTUP_TEXT = @"
================================================================================================
|| SortingName (Coding Assessment)                                                            ||
||                                                                                            ||
|| By Fadhly Permata                                                                          ||
================================================================================================
|| Usage:                                                                                     ||
||      SortingName.exe [inputPath] [outputPath]                                              ||
||                                                                                            ||
|| Available parameters:                                                                      ||
||      -help [or] -info [or] -?     => To show available parameters.                         ||
||      inputPath                    => Add an input file-path as data source                 ||
||      outputPath                   => Add an output file-path to write the result           ||
||                                                                                            ||
|| Example:                                                                                   ||
||      SortingName.exe -help                                                                 ||
||      or                                                                                    ||
||      SortingName.exe ""C:\temp\unsorted-name.txt"" ""C:\temp\sorted-name.txt""                 ||
||                                                                                            ||
|| Note:                                                                                      ||
||       The parameters must be ordered as listed above, or the application will not work     ||
||       well.                                                                                ||
================================================================================================
";

        private const int TABLE_WIDTH = 115;
        private const string TABLE_LINE_CHAR = "=";
        private const string TABLE_CELL_SEPARATOR = "||";

        private const int PADDING_WIDTH = 53;
        private const char PADDING_CHAR = ' ';

        #endregion VARS

        private static void Main(string[] args)
        {
            // check for supplied arguments
            if (args.Length == 0 || new []{"-help", "-info", "-?", "?"}.Any(args[0].Contains))
                Console.Write(STARTUP_TEXT);

            else
                DoProcess(args);

            // Assuming user running this apps by double clicking the exe file
            // or running it directly from VS. So, I need to add below lines
            // to wait for user respond
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #region UTILITIES

        /// <summary>
        ///     Start core engine
        /// </summary>
        /// <param name="args">The arguments passed on Main()</param>
        private static void DoProcess(IReadOnlyList<string> args)
        {
            var inputPath = args[0];
            var outputPath = args[1];

            Console.Write($"Start to sorting people names from:\n\"{inputPath}\"\n");

            var unsortedNames = Peoples.Get(inputPath);
            var sortedNames = Business.Peoples.SortByLastNameThenFirstName(unsortedNames);

            Peoples.Set(sortedNames, outputPath);
            DisplayResult(unsortedNames, sortedNames);

            Console.WriteLine($"Sorting people names is finished and stored at:\n\"{outputPath}\"\n");
        }

        /// <summary>
        ///     Display sorted & unsorted people data
        /// </summary>
        /// <param name="unsorted">List of people data.</param>
        /// <param name="sorted">Sort direction</param>
        private static void DisplayResult(IReadOnlyList<PeopleModel> unsorted, IReadOnlyList<PeopleModel> sorted)
        {
            var unsortedHeaderText = "UNSORTED".PadRight(PADDING_WIDTH, PADDING_CHAR);
            var sortedHeaderText = "SORTED".PadRight(PADDING_WIDTH, PADDING_CHAR);

            Console.WriteLine("");

            // DRAW TABLE HEADER
            Console.WriteLine(TABLE_LINE_CHAR.Repeat(TABLE_WIDTH));
            Console.WriteLine($"{TABLE_CELL_SEPARATOR} {unsortedHeaderText} {TABLE_CELL_SEPARATOR} {sortedHeaderText} {TABLE_CELL_SEPARATOR}");
            Console.WriteLine(TABLE_LINE_CHAR.Repeat(TABLE_WIDTH));

            // DRAW ROWS
            for (var i = 0; i < unsorted.Count; i++)
            {
                var unsortedRow = unsorted[i].FullName.PadRight(PADDING_WIDTH, PADDING_CHAR);
                var sortedRow = sorted[i].FullName.PadRight(PADDING_WIDTH, PADDING_CHAR);

                Console.WriteLine($"{TABLE_CELL_SEPARATOR} {unsortedRow} {TABLE_CELL_SEPARATOR} {sortedRow} {TABLE_CELL_SEPARATOR}");
            }

            // DRAW TABLE BOTTOM LINE
            Console.WriteLine(TABLE_LINE_CHAR.Repeat(TABLE_WIDTH));
            Console.WriteLine("");
        }

        #endregion UTILITIES
    }
}