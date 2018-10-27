using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMvvmToolkit.Express;

namespace WpfApp2.BookSection
{
    public class BookSectionModel : ModelBase<BookSectionModel>
    {
        private string _fullPathFileName;
        private string _title;
        private string _content;
        private int _position;

        public BookSectionModel(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string FullPathFileName
        {
            get
            {
                return _fullPathFileName;
            }

            set
            {
                _fullPathFileName = value;
                NotifyPropertyChanged(m=>m.FullPathFileName);
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged(m=>m.Title);
            }
        }
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                NotifyPropertyChanged(m=>m.Content);
            }
        }
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                NotifyPropertyChanged(m=>m.Position);
            }
        }
    }
}
