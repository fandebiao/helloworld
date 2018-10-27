using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WpfApp2.BookSection;

namespace WpfApp2
{
    public class ViewModelLocator
    {
        private readonly Container _container;

        public ViewModelLocator()
        {
            _container = new Container();
            Bootstrap();
        }

        private void Bootstrap()
        {
            //注册ViewModel
            _container.Register<BookSectionViewModel>(Lifestyle.Transient);
            _container.Register<IBookSectionService, BookSectionService>(Lifestyle.Transient);
        }

        public BookSectionViewModel BookSectionViewModel => _container.GetInstance<BookSectionViewModel>();

    }
}
