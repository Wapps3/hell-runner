using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUI : MonoBehaviour
{
    public GameObject usernameInput;
    public GameObject passwordInput;
    public GameObject pseudoInput;

    private string usernameString;
    private string passwordString;
    private string pseudoString;

    public Button validButton;

    Login newinfo = new Login();

    // Start is called before the first frame update
    void Start()
    {
        validButton.GetComponent<Button>().onClick.AddListener(RegisterAction);

        //Open the stream and read login
        using (StreamReader sr = File.OpenText(Application.streamingAssetsPath + "/login.json"))
        {
            string s = "";
            string tmp = "";
            while ((tmp = sr.ReadLine()) != null)
            {
                s += tmp + "\n";
            }
            Debug.Log(s);

            if (s != "")
                newinfo = JsonUtility.FromJson<Login>(s);
            else
                newinfo = new Login();
        }
    }

    public void RegisterAction()
    {
        if(usernameString == "")
        {

        }
        else if( passwordString == "")
        {

        }
        else if(pseudoString == "")
        {

        }
        else
        {
            newinfo.Add(usernameString, passwordString, pseudoString);

            // Create the file, or overwrite if the file exists
            FileStream file = File.Create(Application.streamingAssetsPath + "/login.json");
            byte[] info = new UTF8Encoding(true).GetBytes(JsonUtility.ToJson(newinfo));
            file.Write(info, 0, info.Length );
        }
       
    }

    public void LoginAction()
    {

    }

    // Update is called once per frame
    void Update()
    {
        usernameString = usernameInput.GetComponent<InputField>().text;
        passwordString = passwordInput.GetComponent<InputField>().text;
        pseudoString = pseudoInput.GetComponent<InputField>().text;

    }
}
