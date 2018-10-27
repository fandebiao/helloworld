namespace WpfApp2.BookSection
{
    public interface IBookSectionService
    {        
        void Play(BookSectionModel section);
        void Pause();
        void Resume();
        void Stop();
    }
}