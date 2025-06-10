using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMalshinon;

namespace projectMalshinon
{
    internal class Reporter : ConnectSQL
    {
        public string Text;
        public string Id_Reporter;
        public Reporter(string id, string text)
        {
            this.Text = text;
           this.Id_Reporter = id;
        }
    }
    public void FindTarget(string text)
        {
            string[] arrayText = text.Split(" ") ;
            string[] names = new string[2];
            string fullname = "";
            foreach (string worde in arrayText)
            {
                if (char.IsUpper(worde[0]))
                {
                    fullname += worde;
                }
            }
        }
}
