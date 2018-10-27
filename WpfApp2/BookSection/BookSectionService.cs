using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BookSection
{
    public class BookSectionService : IBookSectionService
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public void Play(BookSectionModel section)
        {
            synthesizer.Volume = 100;
            synthesizer.Rate = 1;
            synthesizer.SelectVoice("Microsoft Huihui Desktop");
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SpeakAsync(section.Content);
            synthesizer.SpeakProgress += Synthesizer_SpeakProgress;
           
        }

        private void Synthesizer_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            Task.Factory.StartNew(
                () =>
                {
                    var p = synthesizer.ToString();                 
                    Console.WriteLine(p);
                }
            );
        }

        public void Pause()
        {
            synthesizer.Pause();
        }

        public void Resume()
        {
            synthesizer.Resume();
        }

        public void Stop()
        {
            synthesizer.SpeakAsyncCancelAll();
        }
    }
}
