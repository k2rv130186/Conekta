using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines;

namespace TechnicalTestConekta
{
    class Program
    {
        static Image img; 

        static void Main(string[] args)
        {
            while(true)
            {
                ExecuteCommand();
            }            
        }

        static void ExecuteCommand()
        {
            string strCommand = Console.ReadLine().Trim();
            if (strCommand.Length == 0)
                strCommand = " ";
            char command = strCommand[0];
            IEmptyCommand icommand=null;
            object obj = null;
            try
            {
                switch (command)
                {
                    case 'I':
                        icommand = new CreateCommand(strCommand);
                        break;
                    case 'C':
                        icommand = new ClearCommand(strCommand, img);
                        break;
                    case 'L':
                        icommand = new PixelColorCommand(strCommand, img);
                        break;
                    case 'V':
                        icommand = new DrawVerticalCommand(strCommand, img);
                        break;
                    case 'H':
                        icommand = new DrawHorizontalCommand(strCommand, img);
                        break;
                    case 'F':
                        icommand = new RegionCommand(strCommand, img);
                        break;
                    case 'S':
                        icommand = new ShowCommand(strCommand, img);
                        break;
                    case 'X':
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception("No valid Command");
                        

                }
                if(icommand!=null)
                {
                   obj=icommand.ExecuteCommand(img);
                    if(obj is String)
                    {
                        Console.Write(Convert.ToString(obj));
                        Console.Write(Environment.NewLine);
                    }
                    else if(obj is Image)
                    {
                        img = (Image)obj;
                    }
                }

            }catch(Exception ex)
            {
                Console.Write(ex.Message);
                Console.Write(Environment.NewLine);
            }           
        }
    }
}
