using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ReactiveUI;
namespace MangaEye.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private HashSet<string> imageExtensions;
        public HashSet<string> ImageExtensions
        {
            get
            {
                if (imageExtensions == null)
                {
                    imageExtensions = new HashSet<string>
                    {
                        ".jpg",
                        ".gif",
                        ".webp",
                        ".tiff",
                        ".bmp",
                        ".jpeg",
                        ".svg",
                        ".svgz",
                        ".png",
                    };
                }
                return imageExtensions;
            }
        }

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
                ImagePaths = Directory.GetFiles(MdCore.Instance.CurrentFolderPath).Where(o => ImageExtensions.Contains(Path.GetExtension(o).ToLower())).OrderByAlphaNumeric(o => o);
                this.RaisePropertyChanged(nameof(ImagePaths));
            }
        }
    }
}
