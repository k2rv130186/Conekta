using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class CreateCommand : ICommand
    {
        public string Name { get; set; }

        public List<object> Parameters { get; set; }

        public CreateCommand(string strCommand)
        {
            Parameters = new List<object>();
            ValidateValues(strCommand);

        }

        private void ValidateValues(string strCommand)
        {
            string[] values = strCommand.Split();

            int outN, outM;

            this.Name = "I";

            if (values.Count() == 3)
            {

                if (int.TryParse(values[1], out outM))
                {
                    if (outM >= 1)
                        Parameters.Add(outM);

                    if (int.TryParse(values[2], out outN))
                    {
                        if (outN >= 1 && outN <= 250)
                            Parameters.Add(outN);
                        else
                            throw new Exception("The parameter N is not valid, please write a valid integer between 1 and 250");
                    }
                    else
                    {
                        throw new Exception("The parameter N is not valid, please write a valid integer between 1 and 250");
                    }
                }
                else
                {
                    throw new Exception("The parameter M is not valid, please write a valid integer bigger than 1");
                }
            }
            else
                throw new Exception("The numbers of parameters is not valid");
        }

        public object ExecuteCommand(Image img)
        {
            img = new Image((int)Parameters[0], (int)Parameters[1]);

            return img;
        }
    }
}

