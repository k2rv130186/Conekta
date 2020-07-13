using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public interface ICommand
    {
        string Name { get; set; }

        List<Object> Parameters { get; set; }

        object ExecuteCommand(Image img);

    }
}
