using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Automation.VisualStudioTest.TestData
{
    public class LoginData
    {
        public LoginData(DataRow data)
        {
            UserNameOrEmailAddress = data["UserNameOrMailAddress"]?.ToString();
            Password = data["Password"]?.ToString();
            ExpectedResult = data["Expected Result"]?.ToString();
            ExpectedError = data["ErrorMessages"]?.ToString();
        }

        public string UserNameOrEmailAddress { get; set; }
        public string Password { get; set; }
        public string ExpectedResult { get; set; }
        public string ExpectedError { get; set; }

    }
}
