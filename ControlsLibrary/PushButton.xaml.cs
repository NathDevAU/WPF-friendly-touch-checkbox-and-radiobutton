using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace TouchFriendlyControls
{
    public delegate void PressedChangedEventHandler(object sender, bool isPressed);

    public partial class PushButton : Button
    {
        public event PressedChangedEventHandler PressedChanged;

        public static readonly DependencyProperty PressChangedCommandProperty = DependencyProperty.Register(
        "PressChangedCommand", typeof(ICommand), typeof(PushButton), new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty PressChangedCommandParameterProperty = DependencyProperty.Register(
            "PressChangedCommandParameter", typeof(object), typeof(PushButton), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty ExecuteOnPressAndReleaseProperty = DependencyProperty.Register(
            "ExecuteOnPressAndRelease", typeof(bool), typeof(PushButton), new PropertyMetadata(default(bool)));

        /// <summary>
        /// Command that gets executed on press (default). You can configure <see cref="ExecuteOnPressAndRelease"/>
        /// to make the command fire on press and release
        /// </summary>
        public ICommand PressChangedCommand
        {
            get { return (ICommand)GetValue(PressChangedCommandProperty); }
            set { SetValue(PressChangedCommandProperty, value); }
        }

        /// <summary>
        /// Parameter for <see cref="PressChangedCommand"/>
        /// </summary>
        public object PressChangedCommandParameter
        {
            get { return (object)GetValue(PressChangedCommandParameterProperty); }
            set { SetValue(PressChangedCommandParameterProperty, value); }
        }

        /// <summary>
        /// Defines whether the button will execute the command on press only or press and release -theoretically-.
        /// in case you want release only, just use the normal Button Command
        /// test this by trying to do: click -> keep mouse down for a while -> release
        /// </summary>
        public bool ExecuteOnPressAndRelease
        {
            get { return (bool)GetValue(ExecuteOnPressAndReleaseProperty); }
            set { SetValue(ExecuteOnPressAndReleaseProperty, value); }
        }

        public PushButton()
        {
            InitializeComponent();
        }

        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            OnPressedChanged();
            base.OnIsPressedChanged(e);
        }

        private void OnPressedChanged()
        {
            PressedChanged?.Invoke(this, this.IsPressed);

            // Don't execute the command on release

            if (IsPressed)
            {
                FireCommand();
            }
            else
            {
                // TODO I'm not sure if it executes on the "Release" correctly
                // try to do: click -> keep mouse down for a while -> release
                if (ExecuteOnPressAndRelease)
                    FireCommand();
            }

        }

        void FireCommand()
        {
            if (PressChangedCommand != null && PressChangedCommand.CanExecute(PressChangedCommandParameter))
            {
                PressChangedCommand.Execute(PressChangedCommandParameter);
            }
        }
    }
}
