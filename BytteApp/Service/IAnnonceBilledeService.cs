using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BytteApp.Service;

public interface IAnnonceBilledeService
{
    // Upload et billede – returnerer (success, info)
    // info = key / filnavn hvis success, ellers fejlbesked
    Task<(bool success, string info)> SendFile(string filename, Stream stream);

    // Hent alle nøgle-navne (filnavne) for billeder
    Task<List<string>> GetAllKeys();

    // Lav URL til et billede ud fra key
    string ConvertToUrl(string key);

    // Slet en fil på serveren
    Task<(bool success, string info)> DeleteFile(string filename);
}