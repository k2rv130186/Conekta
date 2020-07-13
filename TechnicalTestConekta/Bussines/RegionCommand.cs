using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class RegionCommand : ICommand
    {
        public string Name { get; set; }

        public List<object> Parameters { get; set; }

        public RegionCommand(string strCommand, Image img)
        {
            Parameters = new List<object>();
            ValidateValues(strCommand, img);

        }

        private void ValidateValues(string strCommand, Image img)//F X Y C
        {

            string[] values = strCommand.Split();
            int outx, outy;

            if (img != null)
            {
                this.Name = "F";

                if (values.Count() == 4)
                {

                    if (int.TryParse(values[1], out outx))
                    {
                        if (outx >= 1 && outx <= img.M)
                            Parameters.Add(outx);
                        else
                            throw new Exception("The parameter X is not valid, please write a valid integer between 1 and M");

                        if (int.TryParse(values[2], out outy))
                        {
                            if (outy >= 1 && outy <= img.N)
                                Parameters.Add(outy);
                            else
                                throw new Exception("The parameter Y is not valid, please write a valid integer between 1 and N");


                            if (values[3].Length == 1 && Char.IsUpper(Convert.ToChar(values[3])))
                            {
                                Parameters.Add(Convert.ToChar(values[3]));
                            }
                            else
                            {
                                throw new Exception("The parameter Color is incorrect");
                            }
                        }
                        else
                        {
                            throw new Exception("The parameter Y is not valid, please write a valid integer");
                        }
                    }
                    else
                    {
                        throw new Exception("The parameter X is not valid, please write a valid integer");
                    }
                }
                else
                    throw new Exception("The numbers of parameters is not valid");
            }
            else
                throw new Exception("Please initialize an Imagen first");
        }

        public object ExecuteCommand(Image img)
        {
            img.Region((int)Parameters[0], (int)Parameters[1], (char)Parameters[2]);

            return null;
        }
    }
}

