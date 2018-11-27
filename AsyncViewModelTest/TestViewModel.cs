using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncViewModelTest
{
    public class TestViewModel : ViewModelBase
    {
        public TestViewModel()
        {
            // Required to initialize this viewmodel
            Initialization = InitializeAsync();
        }

        protected override async Task InitializeAsync()
        {
            Console.WriteLine("Fetching data async...");

            await Task.Delay(3000);

            //LoadItemsCommand?.Execute(null);

            Console.WriteLine("VM Loaded!");
        }

    }
}
