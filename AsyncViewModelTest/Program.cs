using System;
using System.Threading.Tasks;

namespace AsyncViewModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestViewModel vm, vm2, vm3;

            // Fire off 3 async methods
            Task.Run(async () => {
                vm = new TestViewModel();
                await vm.Initialization;
            });

            Task.Run(async () => {
                vm2 = new TestViewModel();
                await vm2.Initialization;
            });

            Task.Run(async () => {
                vm3 = new TestViewModel();
                await vm3.Initialization;
            });


            Console.WriteLine("<Busy waiting...>");
            Console.ReadKey();
        }
    }
}
