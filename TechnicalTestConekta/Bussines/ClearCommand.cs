using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class ClearCommand : IEmptyCommand
    {
        public string Name { get; set; }        

        public ClearCommand(string strCommand, Image img)
        {
            ValidateCommand(strCommand, img);
        }

        public void ValidateCommand(string strCommand, Image img)
        {
            if (img != null)
            {
                if (strCommand == "C")
                    this.Name = "C";
                else
                    throw new Exception("The command no is correct");
            }
            else
                throw new Exception("Please initialize an Imagen first");
        }

        public object ExecuteCommand(Image img)
        {
            img.Clear();
            return null;
        }
    }
}
