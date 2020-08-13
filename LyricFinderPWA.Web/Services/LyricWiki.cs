using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyricFinderPWA.Web.Services
{
    public class LyricWiki : ILyricSearch
    {
        public async Task<string> RetrieveLyric(string songTitle, string bandName)
        {
            var band = bandName;
            var title = songTitle.Replace(" ", "_");

            var config = Configuration.Default.WithDefaultLoader();
            var address = $"https://lyrics.fandom.com/wiki/{band}:{title}";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);

            var lyricBox = document.QuerySelector(".lyricbox");
            var lyricText = lyricBox.InnerHtml;

            return lyricText;
        }
    }
}
