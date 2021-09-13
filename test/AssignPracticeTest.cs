using Xunit;
using System.Text.RegularExpressions;
using System.IO;
using System;

namespace bis_305_assign_practice
{
    public class AssignPracticeTest
    {
        [Fact]
        public void ConsoleOutputTest()
        {
            //set output
            var output = new StringWriter();
            Console.SetOut(output);

            Lyrics.Main();

            // //parse the output into a string array 
            // //then check each index in the array below
            var arrayFromMainMethod = output.ToString().Split("\n");

            //The array will be 5 lines in the split array as a WriteLine on the fourth line will 
            //create an empty 5 line 
            Assert.True(arrayFromMainMethod.Length >= 5, "There should be at least 4 lines of lyrics.");

            // subtract the Length of the array by 1 to omit the empty 5th line
            for (int i = 0; i < arrayFromMainMethod.Length - 1; i++)
            {
                Assert.True(arrayFromMainMethod[i].Trim().Length > 0, "You cannot have an emtpy lyric line.");
                Assert.Matches(new Regex(@"[A-Za-z0-9 _.,!/$]*"), arrayFromMainMethod[i]);
            }

            //clean up
            output.Dispose();
        }
    }
}
