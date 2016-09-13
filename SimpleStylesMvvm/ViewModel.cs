using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace SimpleStylesMvvm
{
    public class ViewModel
    {
        // Note: Prism MVVM is installed only to provide the DelegateCommand implementation of ICommand
        public ViewModel()
        {
            SayHello = new DelegateCommand(Hello);
            SayHelloMe = new DelegateCommand<string>(HelloMe);
        }
        public ICommand SayHello { get; }
        public ICommand SayHelloMe { get; }
        public void HelloMe(string name)
        {
            MessageBox.Show("Hello " + name);
        }

        public void Hello()
        {
            // Test with no command params
            // If you're testing the press and release, notice that the message box blocks the thread
            MessageBox.Show("Hello !");
        }
    }
}
