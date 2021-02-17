using System;
using System.IO;

namespace NaturKultur.Onlineboken
{
    public class NaturKulturDigitalbokReader : IDisposable
    {
        //First "page" is 1.

        public NaturKulturDigitalbokBookInfo GetBookInfoAsync()
        {
            // https://online.nok.se/bok/9789127436398/files/data/bookinfo.json?r=4851145482480
        }

        public NaturKulturDigitalbokInteractive GetInteractiveAsync(int page)
        {
            // https://online.nok.se/bok/9789127436398/files/pages/interactive/18.json?r=4851145482480
        }

        public Stream GetTabletImage(int page)
        {
            // https://online.nok.se/bok/9789127436398/files/pages/tablet/14.jpg
        }

        public Stream[] GetSvgImageSetAsync(int page)
        {
            // https://online.nok.se/bok/9789127436398/files/pages/svg/14.svg
            // https://online.nok.se/bok/9789127436398/files/pages/svg/14.jpg
        }

        public Stream GetAudioAsync(int page)
        {
            // https://online.nok.se/bok/9789127436398/files/media/audio/audio18.mp3
        }
    }
}