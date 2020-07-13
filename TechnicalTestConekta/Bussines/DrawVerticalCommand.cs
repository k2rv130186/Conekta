using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class DrawVerticalCommand : ICommand
    {
        public string Name { get; set; }

        public List<object> Parameters { get; set; }

        public DrawVerticalCommand(string strCommand, Image img)
        {
            Parameters = new List<object>();
            ValidateValues(strCommand, img);

        }

        private void ValidateValues(string strCommand, Image img)//V X Y1 Y2 C
        {
            if (img != null)
            {

                string[] values = strCommand.Split();
                int outx, outy1, outy2;

                this.Name = "V";

                if (values.Count() == 5)
                {
                    if (int.TryParse(values[1], out outx))
                    {
                        if (outx >= 1 && outx <= img.M)
                            Parameters.Add(outx);

                        if (int.TryParse(values[2], out outy1))
                        {
                            if (outy1 >= 1 && outy1 <= img.N)
                                Parameters.Add(outy1);

                            if (int.TryParse(values[3], out outy2))
                            {
                                if (outy2 >= 1 && outy1 <= img.N)
                                    Parameters.Add(outy2);

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
            img.DrawVertical((int)Parameters[0], (int)Parameters[1], (int)Parameters[2], (char)Parameters[3]);

            return null;
        }
    }
}

