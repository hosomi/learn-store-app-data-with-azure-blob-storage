using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public interface IStorage
    {
        Task Save(Stream fileStream, string name);
        Task<IEnumerable<string>> GetNames();
        Task<Stream> Load(string name);
    }
}
