using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IBookModel
    {
        string Name { get; set; }
        string Author { get; set; }
        int BookID { get; set; }
        bool IsAvailable { get; set; }
    }
}
