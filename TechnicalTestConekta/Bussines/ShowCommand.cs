using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class ShowCommand : IEmptyCommand
    {
        public string Name { get; set; }

        public ShowCommand(string strCommand, Image img)
        {
            ValidateValues(strCommand, img);
        }

        private void ValidateValues(string strCommand, Image img)
        {        
            if (img != null)
            {
                if (strCommand == "S")
                    this.Name = "S";
                else
                    throw new Exception("The command no is correct");
            }
            else
                throw new Exception("Please initialize an Imagen first");
        }

        public object ExecuteCommand(Image img)
        {
            return img.Show();
            

        }
    }
}

