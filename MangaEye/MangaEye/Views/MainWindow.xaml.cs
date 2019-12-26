using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using MangaEye.ViewModels;

namespace MangaEye.Views
{
    public class MainWindow : Window
    {
        public bool CtrlKeyIsDown { get; set; }
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.KeyDown += MainWindow_KeyDown;
        }


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            var vm = this.DataContext as MainWindowViewModel;
            if (e.Key == Key.OemMinus)
            {
                double newVal = vm.Width *0.9;
                if (newVal > 0)
                {
                    vm.Width = newVal;
                }
            } else if (e.Key == Key.OemPlus)
            {
                double newVal = vm.Width *1.1;
                if (newVal > 0)
                {
                    vm.Width = newVal;
                }
            }
            e.Handled = true;
        }
    }
}
