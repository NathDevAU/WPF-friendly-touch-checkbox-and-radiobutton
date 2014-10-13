using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleStyles
{
public delegate void PressedChangedEventHandler(object sender, bool IsPressed);
    
public partial class PushButton : Button
{
    public event PressedChangedEventHandler PressedChanged;

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
        if (PressedChanged != null)
            PressedChanged(this, this.IsPressed);
    }
}
}
