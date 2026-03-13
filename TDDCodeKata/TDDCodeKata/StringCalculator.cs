using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCodeKata
{
    public class StringCalculator
    {
        public StringCalculator() { }

        public int Calculate(string arg)
        {
            if(arg == "") {  return 0; }


      
            bool break1 = false;
            bool break2 = false;
            bool start1 = false;
            bool start2 = false;
            bool start3 = false;

            char delimiter = ',';
      

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            int k = 0;

            if (arg[0]!= ' ' && (arg[0]<'0' || arg[0]>'9'))
            {
                delimiter = arg[0];
                k++;
            }

            for(int i=k; i < arg.Length; i++)
            {

                if (arg[i]>='0' && arg[i]<='9')
                {
                    if (!break1)
                    {
                        if(!break2)
                        {
                            if (!start1)
                            {
                                if (i > 0 && arg[i - 1] == '-')
                                {
                                    throw new Exception("no negative numbers");
                                }
                                start1 = true;
                            }
                            num1 = 10 * num1 + (int)(arg[i] - '0');

                        }
                        else
                        {
                            if (!start3)
                            {
                                if (i > 0 && arg[i - 1] == '-')
                                {
                                    throw new Exception("no negative numbers");
                                }
                                start3 = true;
                            }
                            num3 = 10 * num3 + (int)(arg[i] - '0');

                        }

                    }
                    else
                    {
                        if(!start2)
                        {
                            if (i > 0 && arg[i - 1] == '-')
                            {
                                throw new Exception("no negative numbers");
                            }
                            start2 = true;
                        }
                      
                        num2 = 10 * num2 + (int)(arg[i] - '0');

                    }

                }
                if (arg[i]==',' || arg[i]=='\n' || arg[i]==delimiter)
                {
                    if(break1)
                    {
                        break2 = true;
                        break1 = false;
                  

                    }
                    else
                    {
                        break1 = true;
                    }
                 
                }


               
            }


            if(num1 > 1000)
            {
                num1 = 0;
            }
            if(num2 > 1000)
            {
                num2 = 0;
            }
            if(num3 > 1000)
            {
                num3 = 0;
            }


            

     
            return num1+num2+num3;
        }
    }
}
