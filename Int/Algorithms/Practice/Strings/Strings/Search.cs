using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class WildcardSearch
    {
        char[] item1=  "A?C?".ToCharArray();
        char[] item2 = "AECBD".ToCharArray();

        public bool Process()
        {
            int index1 = 0 , index2 = 0;
            bool result = true;

            while (index1 < item1.Count()-1 && index2 < item2.Count()-1)
            {
                if(item1[index1] == '*')
                {
                    if(! IsWildCardMatch(ref index1, ref index2, "*"))
                    {
                        result = false;
                        break;
                    }
                }
                else if(item1[index1] == '?')
                {
                    if (!IsWildCardMatch(ref index1, ref index2, "?"))
                    {
                        result = false;
                        break;
                    }
                }
                else if(item1[index1] != item2[index2])
                {
                    result = false;
                    break;
                }
                if (index1 < item1.Count() - 1)
                {
                    index1++;
                }
                if (index2 < item2.Count() - 1)
                {
                    index2++;
                }
            }
            return result;
        }

        private bool IsWildCardMatch(ref int index1, ref int index2, string wildCard)
        {
            bool result = false;

            switch(wildCard)
            {
                case "*":
                    {
                        if (item1.Count()-1 > index1)
                        {
                            index1++;
                        }
                        else
                        {
                            result = true;
                            break;
                        }

                        while(item2.Count() > index2)
                        {
                            if(item1[index1] != item2[index2])
                            {
                                index2++;
                                continue;
                            }
                            else
                            {
                                result = true;
                                break;
                            }
                        }
                        break;
                    };
                case "?":
                    {
                        index1++;
                        if (item2.Count() > index2)
                        {
                            index2++;
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                        break;
                    }                
            }

            return result;
        }
    }
}
