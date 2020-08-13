using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyricFinderPWA.Web.Services
{
    public interface ILyricSearch
    {
        Task<string> RetrieveLyric(string songTitle, string bandName);
    }
}
