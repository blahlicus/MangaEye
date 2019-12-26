using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ReactiveUI;
namespace MangaEye.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private IEnumerable<string> imagePaths;
        private double width;
        private string title;
        public IEnumerable<string> ImagePaths
        {
            get => imagePaths;
            set => this.RaiseAndSetIfChanged(ref imagePaths, value);
        }
        public double Width
        {
            get => width;
            set => this.RaiseAndSetIfChanged(ref width, value);
        }
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        public MainWindowViewModel() : base()
        {
            Width = 300;
            if (!string.IsNullOrEmpty(MdCore.Instance.CurrentFolderPath))
            {
                Title = MdCore.PROGRAM_NAME + " (" + MdCore.PROGRAM_VERSION + ") - " + Path.GetFileName(MdCore.Instance.CurrentFolderPath);
                ImagePaths = Directory.GetFiles(MdCore.Instance.CurrentFolderPath);
                this.RaisePropertyChanged(nameof(ImagePaths));
            }
        }
    }
}
