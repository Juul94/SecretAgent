using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretAgentNew
{
    public class Agent
    {
        // Class Variable
        private static int myCounter = 0;

        // Instance Variable
        private int agentID;
        public string realName;
        private string codeName;
        private string lang1;
        private string lang2;

        // Constructor
        public Agent(string realName, string codeName, string lang1, string lang2)
        {
            this.realName = realName;
            this.codeName = codeName;
            agentID = myCounter;
            this.lang1 = lang1;
            this.lang2 = lang2;

            myCounter++;
        }

        // Auto-generated Properties
        public string REALname { get => realName; }
        public string CODEname { get => codeName; }
        public string Lang1 { get => lang1; set => lang1 = value; }
        public string Lang2 { get => lang2; set => lang2 = value; }
        public int agentId { get => agentID; }

        // ToString
        public override string ToString()
        {
            return "(" + agentID + ") Name: " + realName + " - Code name: " + codeName + " - Speaks: " + lang1 + " & " + lang2;
        }
    }
}