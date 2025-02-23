using System.Diagnostics;
using AvaDic.ViewModels;
using Avalonia.Controls;
using Avalonia.Data;

namespace AvaDic.Views;

public partial class MainWindow : Window
{
  public MainWindow(MainWindowViewModel vm)
  {
    InitializeComponent();

    DataContext = vm;

    vm.DataMap.CollectionChanged += (_, _) =>
    {
      Debug.WriteLine("View::CollectionChanged");
      BindingOperations.GetBindingExpressionBase(DataBox, ComboBox.ItemsSourceProperty).UpdateSource();
      BindingOperations.GetBindingExpressionBase(DictBox, ComboBox.ItemsSourceProperty).UpdateSource();
    };
    vm.DataMap.PropertyChanged += (_, _) =>
    {
      Debug.WriteLine("View::PropertyChanged");
      BindingOperations.GetBindingExpressionBase(DataBox, ComboBox.ItemsSourceProperty).UpdateSource();
      BindingOperations.GetBindingExpressionBase(DictBox, ComboBox.ItemsSourceProperty).UpdateSource();
    };
  }
}
