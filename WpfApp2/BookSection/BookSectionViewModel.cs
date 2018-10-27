using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleMvvmToolkit.Express;

namespace WpfApp2.BookSection
{
    public class BookSectionViewModel : ViewModelBase<BookSectionViewModel>
    {


        // "服务"
        private readonly IBookSectionService _service;
        private int _selectedIndex;

        // "数据"
        public List<BookSectionModel> BookSelectionList { get; set; }
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged(m=>m.SelectedIndex);
            }
        }

        // "命令"
        public ICommand PlayBookSectionCommand => new DelegateCommand(PlayBookSection);
        public ICommand PauseBookSectionCommand => new DelegateCommand(PauseBookSection);
        public ICommand ResumeBookSectionCommand => new DelegateCommand(ResumeBookSection);
        public ICommand StopBookSectionCommand => new DelegateCommand(StopBookSection);

        public void PlayBookSection()
        {
            var section = BookSelectionList[SelectedIndex];
            _service.Play(section);
        }

        public void PauseBookSection()
        {
            _service.Pause();
        }

        public void ResumeBookSection()
        {
            _service.Resume();            
        }

        public void StopBookSection()
        {
            _service.Stop();
        }

        // "构造器"
        public BookSectionViewModel(IBookSectionService service)
        {
            _service = service;
            init();
        }

        // "初始化数据"
        private void init()
        {
            BookSelectionList = new List<BookSectionModel>();
            int i = 0;
            var dir = new DirectoryInfo(Environment.CurrentDirectory + "\\小说\\永不瞑目\\");
            var files = dir.GetFiles();

            foreach (var item in files)
            {
                i++;
                var content = File.ReadAllText(item.FullName, Encoding.Default);

                var section = new BookSectionModel(i)
                {
                    FullPathFileName = item.FullName,
                    Title = item.Name.Replace(item.Extension, ""),
                    Content = content
                };
                BookSelectionList.Add(section);
            }
        }

    }
}
