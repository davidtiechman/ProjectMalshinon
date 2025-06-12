using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectMalshinon.PEOPLE
{
    internal class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string SecretCode { get; set; }
        public string Type { get; set; }

        public People(int id, string firstName, string lestName, string secret_Code, string type)
        {
            Id = id;
            FirstName = firstName;
            LestName = lestName;
            SecretCode = secret_Code;
            Type = type;
        }
    }
    
}
