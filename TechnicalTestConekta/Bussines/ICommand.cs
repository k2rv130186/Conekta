using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public interface ICommand:IEmptyCommand
    {
       List<Object> Parameters { get; set; }       
    }
}
