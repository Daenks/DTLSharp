/*#######################################################################################
    Copyright (c) 2017-2019 Kasugaccho
    Copyright (c) 2018-2019 As Project
    https://github.com/Kasugaccho/DungeonTemplateLibrary
    wanotaitei@gmail.com

    DungeonTemplateLibraryUnity
    https://github.com/sitRyo/DungeonTemplateLibraryUnity
    seriru.rcvmailer@gmail.com

    Distributed under the Boost Software License, Version 1.0. (See accompanying
    file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
#######################################################################################*/

using System;
using DTL.Shape;

namespace DTL.Console {
    public class OutputConsole : IDrawer<int> {

        public string lhs { get; set; } = string.Empty;
        public string rhs { get; set; } = string.Empty;
        private Func<int, bool> func;

        private static class StateNumber {
            public static bool Draw(int[,] matrix) {
                var h = matrix.GetLength(0);
                var w = matrix.GetLength(1);

                string relt = "\n";
                for (int i = 0; i < h; ++i) {
                    string str = "";
                    for (int j = 0; j < w; ++j) str += matrix[i, j].ToString() + " ";
                    relt += str + "\n";
                }

                System.Console.WriteLine(relt);
                return true;
            }
        }

        private static class StateString {
            public static bool Draw(int[,] matrix, string lhs, string rhs, Func<int, bool> func) {
                var h = matrix.GetLength(0);
                var w = matrix.GetLength(1);

                string relt = "\n";
                for (int i = 0; i < h; ++i) {
                    string str = "";
                    for (int j = 0; j < w; ++j) 
                        str += func(matrix[i, j]) ? lhs : rhs;
                    relt += str + "\n";
                }

                System.Console.WriteLine(relt);
                return true;
            }
        }

        // Draw
        public bool Draw(int[,] matrix) {
            if (!string.IsNullOrEmpty(lhs) && !string.IsNullOrEmpty(rhs) && func != null) {
                StateString.Draw(matrix, lhs, rhs, func);
            }
            else {
                StateNumber.Draw(matrix);
            }
            return true;
        }

        // constructors
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OutputConsole() { } // default
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public OutputConsole(Func<int, bool> func, string lhs, string rhs) {
            this.lhs = lhs;
            this.rhs = rhs;
            this.func = func;
        }
    }
}