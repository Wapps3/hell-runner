using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Login 
{
    public List<string> username;
    public List<string> password;
    public List<string> playerName;

    public Login()
    {
        username = new List<string>();
        password = new List<string>();
        playerName = new List<string>();
    }

    public void Add(string u,string p, string pl)
    {
        username.Add(u);
        password.Add(p);
        playerName.Add(pl);
    }
}
