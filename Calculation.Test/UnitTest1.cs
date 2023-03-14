using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program;

namespace Calculation.Test
{
    public class UnitTest1
    {
        Program.Program program = null;

        public UnitTest1()
        {
            program = new Program.Program();
        }


        //[Fact]
        public void Add_Test()
        {
            Program.Program program = new Program.Program();
            Assert.Equal(2, program.Add(1, 1)); // Fail case, logic is wrong in Add method
        }

        //[Fact]
        public void SendGetRequest_Test()
        {
            Program.Program program = new Program.Program();

            Assert.NotNull(program.SendGetRequest("https://jsonplaceholder.typicode.com/todos/18").Value);
            Assert.True(program.SendGetRequest("https://jsonplaceholder.typicode.com/todos/1").Status);
            Assert.Null(program.SendGetRequest("https://jsonplaceholder.typicode.com/todos/18878789").Value);
            Assert.NotEmpty(program.SendGetRequest("https://jsonplaceholder.typicode.com/todos/188888888888").Message);
            Assert.False(program.SendGetRequest("").Status);
        }

        [Fact]
        public void MakeFullNameTest()
        {
            Assert.Equal("james jones", program.MakeFullName("James", "Jones"), ignoreCase: true);
        }

        [Fact]
        public void FibonacciTest()
        {
            Assert.All(program.FibonacciNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        public void FiboInclude13()
        {

        }
    }
}