using Newtonsoft.Json.Linq;

namespace GMS.Common
{
    public class SQLInjection
    {

        public SQLInjection()
        {

        }

        public List<String> isValidString(string strInputString)
        {
            List<String> list = new List<String>();
          
            if (strInputString.ToLower().Contains("delete"))
            {
                list.Add(strInputString + " is invalid");
            }
            if (strInputString.ToLower().Contains("drop"))
            {
                list.Add(strInputString + " is invalid");
            }
            if (strInputString.ToLower().Contains("truncate"))
            {
                list.Add(strInputString + " is invalid");
            }
            if (strInputString.ToLower().Contains("alter"))
            {
                list.Add(strInputString + " is invalid");
            }
            if (strInputString.ToLower().Contains("insert"))
            {
                list.Add(strInputString + " is invalid");
            }
            if (strInputString.ToLower().Contains("update"))
            {
                list.Add(strInputString + " is invalid");
            }
            return list;
        }
    }
}
