using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class DrawHorizontalCommand : ICommand
    {
        public string Name { get; set; }

        public List<object> Parameters { get; set; }

        public DrawHorizontalCommand(string strCommand, Image img)
        {
            Parameters = new List<object>();
            ValidateValues(strCommand, img);

        }

        private void ValidateValues(string strCommand, Image img)//H X1 X2 Y C
        {
            if (img != null)
            {
                string[] values = strCommand.Split();
                int outx1, outx2, outy;

                this.Name = "H";

                if (values.Count() == 5)
                {

                    if (int.TryParse(values[1], out outx1))
                    {
                        if (outx1 >= 1 && outx1 <= img.M)
                            Parameters.Add(outx1);
                        else
                            throw new Exception("The parameter X is not valid, please write a valid integer between 1 and M");

                        if (int.TryParse(values[2], out outx2))
                        {
                            if (outx2 >= 1 && outx1 <= img.M)
                                Parameters.Add(outx2);
                            else
                                throw new Exception("The parameter X is not valid, please write a valid integer between 1 and M");

                            if((int)Parameters[0] > (int)Parameters[1])
                                throw new Exception("The range is incorrect, X1 cannot be greater than X2");

                            if (int.TryParse(values[3], out outy))
                            {
                                if (outy >= 1 && outy <= img.N)
                                    Parameters.Add(outy);
                                else
                                    throw new Exception("The parameter Y is not valid, please write a valid integer between 1 and N");


                                if (values[4].Length == 1 && Char.IsUpper(Convert.ToChar(values[4])))
                                {
                                    Parameters.Add(Convert.ToChar(values[4]));
                                }
                                else
                                {
                                    throw new Exception("The parameter C is incorrect");
                                }
                            }
                            else
                            {
                                throw new Exception("The parameter Y is not valid, please write a valid integer");
                            }
                        }
                        else
                        {
                            throw new Exception("The parameter X2 is not valid, please write a valid integer");
                        }
                    }
                    else
                    {
                        throw new Exception("The parameter X1 is not valid, please write a valid integer");
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
            img.DrawHorizontal((int)Parameters[0], (int)Parameters[1], (int)Parameters[2], (char)Parameters[3]);

            return null;
        }
    }
}


