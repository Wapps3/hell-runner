using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoginUI : MonoBehaviour
{
    public GameObject usernameInput;
    public GameObject passwordInput;

    private string usernameString;
    private string passwordString;

    public Button validButton;

    Login listLogin = new Login();

    // Start is called before the first frame update
    void Start()
    {
        validButton.GetComponent<Button>().onClick.AddListener(LoginAction);

        //Open the stream and read login
        using (StreamReader sr = File.OpenText(Application.streamingAssetsPath + "/login.json"))
        {
            string file = "";
            string tmp = "";
            while ((tmp = sr.ReadLine()) != null)
            {
                file += tmp + "\n";
            }
            if (file != "")
            {
                Debug.Log(file);
                listLogin = JsonUtility.FromJson<Login>(file);
            }
            else
                listLogin = new Login();
        }
    }


    public void LoginAction()
    {
        if(usernameString != "")
        {
            if(listLogin.username.Contains(usernameString) )
            {
                if(passwordString == listLogin.password[listLogin.username.IndexOf(usernameString)] )
                {
                    SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        usernameString = usernameInput.GetComponent<InputField>().text;
        passwordString = passwordInput.GetComponent<InputField>().text;


        try
        {
            //Open the stream and read login
            using (StreamReader sr = File.OpenText(Application.streamingAssetsPath + "/login.json"))
            {
                string file = "";
                string tmp = "";
                while ((tmp = sr.ReadLine()) != null)
                {
                    file += tmp + "\n";
                }
                if (file != "")
                {
                    Debug.Log(file);
                    listLogin = JsonUtility.FromJson<Login>(file);
                }
                else
                    listLogin = new Login();
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }

    }
}
