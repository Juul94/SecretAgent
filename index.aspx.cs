using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecretAgentNew
{
    public partial class index : System.Web.UI.Page
    {
        static ArrayList agentArrayList;
        static ArrayList encryptList;
        private string[] encryptionNo = { "Select key", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25" };
        private string[] languages = { "Select Language", "Danish", "English", "Russian", "Japanese", "Spanish", "Russian", "Portuguese", "Italian", "Ukrainian", "Romanian", "Thai", "Czech" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ErrorMessage_realName.Visible = false;
                ErrorMessage_codeName.Visible = false;
                ErrorMessage_lang1.Visible = false;
                ErrorMessage_lang2.Visible = false;
                ErrorMessage_realName_h.Visible = false;
                ErrorMessage_lang1_h.Visible = false;
                ErrorMessage_lang2_h.Visible = false;
                ErrorMessage_Encrypton.Visible = false;
                ErrorMessage_Encrypton_Key.Visible = false;

                ShowAgentError.Visible = true;

                div_Update.Visible = false;
                div_Show.Visible = true;
                div_Create.Visible = false;
                div_encryption.Visible = false;

                ListBox_Encryption.Visible = false;
                Label_Success.Visible = false;

                agentArrayList = new ArrayList();
                encryptList = new ArrayList();

                DropDownList_Encryption.DataSource = encryptionNo;
                DropDownList_Encryption.DataBind();

                DropDownList_Language1.DataSource = languages;
                DropDownList_Language1.DataBind();

                DropDownList_Language2.DataSource = languages;
                DropDownList_Language2.DataBind();

                DropDownList_lang1.DataSource = languages;
                DropDownList_lang1.DataBind();

                DropDownList_lang2.DataSource = languages;
                DropDownList_lang2.DataBind();
            }
        }

        protected void Button_CreateAgent_Click(object sender, EventArgs e)
        {
            string realName = TextBox_realName.Text.ToLower();
            realName = new CultureInfo("en-US").TextInfo.ToTitleCase(realName);

            string codeName = TextBox_codeName.Text.ToLower();
            codeName = new CultureInfo("en-US").TextInfo.ToTitleCase(codeName);

            string lang1 = DropDownList_Language1.SelectedValue;
            lang1 = new CultureInfo("en-US").TextInfo.ToTitleCase(lang1);

            string lang2 = DropDownList_Language2.SelectedValue;
            lang2 = new CultureInfo("en-US").TextInfo.ToTitleCase(lang2);

            int check = 0;
            Regex regex = new Regex("^[A-Za-z]+$");

            for (int i = 0; i < agentArrayList.Count; i++)
            {
                if (((Agent)agentArrayList[i]).REALname == realName)
                {
                    check++;

                    ErrorMessage_realName.Text = "'" + ((Agent)agentArrayList[i]).REALname + "' already exist";
                    ErrorMessage_realName.Visible = true;
                }
            }

            if (check == 0)
            {
                if (realName == "" || realName == null)
                {
                    ErrorMessage_realName.Text = "Enter a real name";

                    ErrorMessage_realName.Visible = true;
                    ErrorMessage_codeName.Visible = false;
                    ErrorMessage_lang1.Visible = false;
                    ErrorMessage_lang2.Visible = false;
                }

                else if (!regex.IsMatch(realName))
                {
                    ErrorMessage_realName.Text = "1 word without spaces, numbers or special characters";

                    ErrorMessage_realName.Visible = true;
                    ErrorMessage_codeName.Visible = false;
                    ErrorMessage_lang1.Visible = false;
                    ErrorMessage_lang2.Visible = false;
                }

                else if (codeName == "" || codeName == null)
                {
                    ErrorMessage_realName.Visible = false;
                    ErrorMessage_codeName.Visible = true;
                    ErrorMessage_lang1.Visible = false;
                    ErrorMessage_lang2.Visible = false;
                }

                else if (lang1 == "Select Language")
                {
                    ErrorMessage_lang1.Text = "Choose 1. language";

                    ErrorMessage_realName.Visible = false;
                    ErrorMessage_codeName.Visible = false;
                    ErrorMessage_lang1.Visible = true;
                    ErrorMessage_lang2.Visible = false;
                }

                else if (lang2 == "Select Language")
                {
                    ErrorMessage_lang2.Text = "Choose 2. language";

                    ErrorMessage_realName.Visible = false;
                    ErrorMessage_codeName.Visible = false;
                    ErrorMessage_lang1.Visible = false;
                    ErrorMessage_lang2.Visible = true;
                }

                else if (lang1 == lang2)
                {
                    ErrorMessage_lang2.Text = "You can't choose the same language twice";

                    ErrorMessage_realName.Visible = false;
                    ErrorMessage_codeName.Visible = false;
                    ErrorMessage_lang1.Visible = false;
                    ErrorMessage_lang2.Visible = true;
                }

                else
                {
                    ErrorMessage_realName.Visible = false;
                    ErrorMessage_codeName.Visible = false;
                    ErrorMessage_lang1.Visible = false;
                    ErrorMessage_lang2.Visible = false;

                    Agent a = new Agent(realName, codeName, lang1, lang2);

                    agentArrayList.Add(a);

                    ListBox_Agents.Items.Clear();

                    for (int i = 0; i < agentArrayList.Count; i++)
                    {
                        ListBox_Agents.Items.Add(agentArrayList[i].ToString());
                    }

                    TextBox_realName.Text = "";
                    TextBox_codeName.Text = "";
                    DropDownList_Language1.SelectedValue = "Select Language";
                    DropDownList_Language2.SelectedValue = "Select Language";

                    Button_Show_Agents.Attributes.Add("class", "changeColor");
                    Button_Show_Create.Attributes.Add("class", "ColorDefault");

                    ShowAgentError.Visible = false;
                    div_Create.Visible = false;
                    div_Update.Visible = false;
                    div_encryption.Visible = false;
                    div_Show.Visible = true;

                    Label_Success.Text = "Success! '" + realName + "' has now been created";
                    Label_Success.Visible = true;
                }
            }
        }

        protected void Button_UpdateAgent_Click(object sender, EventArgs e)
        {
            string realName = TextBox_realName_h.Text.ToLower();
            realName = new CultureInfo("en-US").TextInfo.ToTitleCase(realName);

            string lang1 = DropDownList_lang1.SelectedValue;
            lang1 = new CultureInfo("en-US").TextInfo.ToTitleCase(lang1);

            string lang2 = DropDownList_lang2.SelectedValue;
            lang2 = new CultureInfo("en-US").TextInfo.ToTitleCase(lang2);

            Regex regex = new Regex("^[A-Za-z]+$");

            if (agentArrayList.Count == 0)
            {
                ErrorMessage_realName_h.Text = "'" + realName + "' doesn't exist";

                ErrorMessage_realName_h.Visible = true;
            }

            else
            {
                ErrorMessage_realName_h.Visible = false;
            }

            for (int i = 0; i < agentArrayList.Count; i++)
            {
                if (((Agent)agentArrayList[i]).REALname == realName)
                {
                   
                    ErrorMessage_realName_h.Visible = false;

                    if (lang1 == "Select Language")
                    {
                        ErrorMessage_lang1_h.Text = "Choose 1. language";

                        ErrorMessage_realName_h.Visible = false;
                        ErrorMessage_lang1_h.Visible = true;
                        ErrorMessage_lang2_h.Visible = false;
                    }

                    else if (((Agent)agentArrayList[i]).Lang1 == lang1)
                    {
                        ErrorMessage_lang1_h.Text = "1. Language is already '" + lang1 + "'";

                        ErrorMessage_realName_h.Visible = false;
                        ErrorMessage_lang1_h.Visible = true;
                        ErrorMessage_lang2_h.Visible = false;
                    }

                    else if (lang2 == "Select Language")
                    {
                        ErrorMessage_lang2_h.Text = "Choose 2. language";

                        ErrorMessage_realName_h.Visible = false;
                        ErrorMessage_lang1_h.Visible = false;
                        ErrorMessage_lang2_h.Visible = true;
                    }

                    else if (((Agent)agentArrayList[i]).Lang2  == lang2)
                    {
                        ErrorMessage_lang2_h.Text = "2. Language is already '" + lang2 + "'";

                        ErrorMessage_realName_h.Visible = false;
                        ErrorMessage_lang1_h.Visible = false;
                        ErrorMessage_lang2_h.Visible = true;
                    }

                    else if(lang1 == lang2)
                    {
                        ErrorMessage_lang2_h.Text = "You can't choose the same language twice";

                        ErrorMessage_realName_h.Visible = false;
                        ErrorMessage_lang1_h.Visible = false;
                        ErrorMessage_lang2_h.Visible = true;
                    }

                    else
                    {
                        ErrorMessage_realName_h.Visible = false;
                        ErrorMessage_lang1_h.Visible = false;
                        ErrorMessage_lang2_h.Visible = false;

                        ((Agent)agentArrayList[i]).Lang1 = lang1;
                        ((Agent)agentArrayList[i]).Lang2 = lang2;

                        ListBox_Agents.DataSource = agentArrayList;
                        ListBox_Agents.DataBind();

                        TextBox_realName_h.Text = "";
                        DropDownList_lang1.SelectedValue = "Select Language";
                        DropDownList_lang2.SelectedValue = "Select Language";

                        Button_Show_Agents.Attributes.Add("class", "changeColor");
                        Button_Show_Update.Attributes.Add("class", "ColorDefault");

                        ShowAgentError.Visible = false;
                        div_Create.Visible = false;
                        div_Update.Visible = false;
                        div_encryption.Visible = false;
                        div_Show.Visible = true;

                        Label_Success.Text = "Success! '" + ((Agent)agentArrayList[i]).REALname + "' has updated their languages";
                        Label_Success.Visible = true;
                    }

                    break;
                }

                else
                {
                    ErrorMessage_realName_h.Text = "Agent doesn't exist";

                    ErrorMessage_realName_h.Visible = true;
                    ErrorMessage_lang1_h.Visible = false;
                    ErrorMessage_lang2_h.Visible = false;
                }
            }
        }

        protected void Button_Show_Agents_Click(object sender, EventArgs e)
        {
            if (div_Show.Visible == false)
            {

                Button_Show_Agents.Attributes.Add("class", "changeColor");
                Button_Show_Create.Attributes.Add("class", "ColorDefault");
                Button_Show_Update.Attributes.Add("class", "ColorDefault");
                Button_EncrypCode.Attributes.Add("class", "ColorDefault");

                Label_Success.Visible = false;
                div_Show.Visible = true;
                div_Create.Visible = false;
                div_Update.Visible = false;
                div_encryption.Visible = false;

                ErrorMessage_realName.Visible = false;
                ErrorMessage_codeName.Visible = false;
                ErrorMessage_lang1.Visible = false;
                ErrorMessage_lang2.Visible = false;
                ErrorMessage_realName_h.Visible = false;
                ErrorMessage_lang1_h.Visible = false;
                ErrorMessage_lang2_h.Visible = false;
                ErrorMessage_Encrypton.Visible = false;
                ErrorMessage_Encrypton_Key.Visible = false;
            }

            if (agentArrayList.Count == 0)
            {
                ShowAgentError.Visible = true;
            }

            else
            {
                ShowAgentError.Visible = false;
            }
        }

        protected void Button_Show_Create_Click(object sender, EventArgs e)
        {
            if (div_Create.Visible == false)
            {
                Button_Show_Agents.Attributes.Add("class", "ColorDefault");
                Button_Show_Create.Attributes.Add("class", "changeColor");
                Button_Show_Update.Attributes.Add("class", "ColorDefault");
                Button_EncrypCode.Attributes.Add("class", "ColorDefault");

                Label_Success.Visible = false;
                div_Show.Visible = false;
                div_Create.Visible = true;
                div_Update.Visible = false;
                div_encryption.Visible = false;

                ErrorMessage_realName.Visible = false;
                ErrorMessage_codeName.Visible = false;
                ErrorMessage_lang1.Visible = false;
                ErrorMessage_lang2.Visible = false;
                ErrorMessage_realName_h.Visible = false;
                ErrorMessage_lang1_h.Visible = false;
                ErrorMessage_lang2_h.Visible = false;
                ErrorMessage_Encrypton.Visible = false;
                ErrorMessage_Encrypton_Key.Visible = false;
            }
        }

        protected void Button_Show_Update_Click(object sender, EventArgs e)
        {
            if (div_Update.Visible == false)
            {
                Button_Show_Agents.Attributes.Add("class", "ColorDefault");
                Button_Show_Create.Attributes.Add("class", "ColorDefault");
                Button_Show_Update.Attributes.Add("class", "changeColor");
                Button_EncrypCode.Attributes.Add("class", "ColorDefault");

                Label_Success.Visible = false;
                div_Show.Visible = false;
                div_Create.Visible = false;
                div_Update.Visible = true;
                div_encryption.Visible = false;

                ErrorMessage_realName.Visible = false;
                ErrorMessage_codeName.Visible = false;
                ErrorMessage_lang1.Visible = false;
                ErrorMessage_lang2.Visible = false;
                ErrorMessage_realName_h.Visible = false;
                ErrorMessage_lang1_h.Visible = false;
                ErrorMessage_lang2_h.Visible = false;
                ErrorMessage_Encrypton.Visible = false;
                ErrorMessage_Encrypton_Key.Visible = false;
            }
        }

        protected void Button_EncrypCode_Click(object sender, EventArgs e)
        {
            if (div_encryption.Visible == false)
            {
                Button_Show_Agents.Attributes.Add("class", "ColorDefault");
                Button_Show_Create.Attributes.Add("class", "ColorDefault");
                Button_Show_Update.Attributes.Add("class", "ColorDefault");
                Button_EncrypCode.Attributes.Add("class", "changeColor");

                Label_Success.Visible = false;
                div_Show.Visible = false;
                div_Create.Visible = false;
                div_Update.Visible = false;
                div_encryption.Visible = true;

                ErrorMessage_realName.Visible = false;
                ErrorMessage_codeName.Visible = false;
                ErrorMessage_lang1.Visible = false;
                ErrorMessage_lang2.Visible = false;
                ErrorMessage_realName_h.Visible = false;
                ErrorMessage_lang1_h.Visible = false;
                ErrorMessage_lang2_h.Visible = false;
                ErrorMessage_Encrypton.Visible = false;
                ErrorMessage_Encrypton_Key.Visible = false;
            }
        }

        protected void Button_Encrypion_Click(object sender, EventArgs e)
        {
            Encryption enc;

            string encryptionText = Text_encruptedText.Text.ToLower();
            encryptionText = new CultureInfo("en-US").TextInfo.ToTitleCase(encryptionText);

            string convertItems = DropDownList_Encryption.SelectedValue;

            if(encryptionText == "" || encryptionText == null)
            {
                ErrorMessage_Encrypton.Text = "Type some text";

                Label_Success.Visible = false;
                ErrorMessage_Encrypton.Visible = true;
                ErrorMessage_Encrypton_Key.Visible = false;
            }

            else if (convertItems == "Select key")
            {
                ErrorMessage_Encrypton_Key.Text = "Choose a key";

                Label_Success.Visible = false;
                ErrorMessage_Encrypton.Visible = false;
                ErrorMessage_Encrypton_Key.Visible = true;
            }

            else
            {
                enc = new Encryption(encryptionText, Convert.ToInt32(convertItems));

                if (encryptionText == "Select key")
                {
                    ErrorMessage_Encrypton.Text = "Enter some text to encrypt";

                    Label_Success.Visible = false;
                    ErrorMessage_Encrypton_Key.Visible = false;
                    ErrorMessage_Encrypton.Visible = true;
                }

                else
                {
                    ListBox_Encryption.Visible = true;
                    ErrorMessage_Encrypton.Visible = false;
                    ErrorMessage_Encrypton_Key.Visible = false;

                    encryptList.Add(enc.ToString());

                    ListBox_Encryption.Items.Clear();

                    for (int i = 0; i < encryptList.Count; i++)
                    {
                        ListBox_Encryption.Items.Add("Encryption : " + encryptList[i].ToString() + " Decryption: " + encryptionText);

                        Text_encruptedText.Text = "";
                        DropDownList_Encryption.SelectedValue = "Select key";
                    }

                    Label_Success.Text = "Success! The text has been encrypted";
                    Label_Success.Visible = true;
                }
            }
        }
    }
}