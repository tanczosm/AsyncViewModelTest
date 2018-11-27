using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncViewModelTest
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected Dictionary<string, string> vmparams = new Dictionary<string, string>();

        public Task Initialization { get; protected set; }

        protected abstract Task InitializeAsync();

        // Set a single parameter
        public void SetParam(string key, string value)
        {
            vmparams[key] = value;

            OnParamsSet(new EventArgs());
        }

        public virtual void SetParams(Dictionary<string, string> vmparams)
        {
            this.vmparams.Clear();

            if (vmparams != null)
            {
                foreach (string key in vmparams.Keys)
                    this.vmparams.Add(key, vmparams[key]);
            }

            OnParamsSet(new EventArgs());
        }

        /// <summary>
        /// When a property is changed notify the UI (WP/WinStore)
        /// </summary>
        /// <param name="propName"></param>
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string ErrorMessage { get; set; } = "";

        private bool isError = false;

        /// <summary>
        /// Gets or sets if the View Model request returned an error
        /// </summary>
        public bool IsError
        {
            get { return isError; }
            set { isError = value; OnPropertyChanged("IsError"); OnPropertyChanged("ErrorMessage"); }
        }

        private bool isBusy;

        /// <summary>
        /// Gets or sets if the View Model is busy
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged("IsBusy"); OnPropertyChanged("IsNotBusy"); }
        }

        public bool IsNotBusy
        {
            get { return !isBusy; }
        }

        protected ICommand loadItemsCommand;
        protected virtual ICommand LoadItemsCommand
        {
            get { return null; }
        }

        public virtual event EventHandler Loaded;
        public virtual event EventHandler ParamsSet;

        protected virtual void OnLoaded(EventArgs e)
        {
            Loaded?.Invoke(this, e);
        }

        protected virtual void OnParamsSet(EventArgs e)
        {
            ParamsSet?.Invoke(this, e);
        }

    }

}