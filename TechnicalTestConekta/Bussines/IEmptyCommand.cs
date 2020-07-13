using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public interface IEmptyCommand
    {
        string Name { get; set; }

        object ExecuteCommand(Image img);

    }
}
