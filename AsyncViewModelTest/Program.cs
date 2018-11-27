using System;
using System.Threading.Tasks;

namespace AsyncViewModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestViewModel vm = new TestViewModel();
            TestViewModel vm2 = new TestViewModel();
            TestViewModel vm3 = new TestViewModel();

            //Task.WaitAll(vm.Initialization, vm2.Initialization, vm3.Initialization);

            Console.WriteLine("<Busy waiting...>");
            Console.ReadKey();
        }
    }
}
