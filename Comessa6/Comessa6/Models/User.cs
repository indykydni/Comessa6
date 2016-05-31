using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comessa6.Models
{
  public class User
  {
    private int id;
    private string name;
    private string login;
    private string password;
    private string ip;
    private bool isMasterServer;
    private bool isServer;

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string Login
    {
      get { return login; }
      set { login = value; }
    }

    public string Password
    {
      get { return password; }
      set { password = value; }
    }

    public string IP
    {
      get { return ip; }
      set { ip = value; }
    }

    public bool IsMasterServer
    {
      get { return isMasterServer; }
      set { isMasterServer = value; }
    }

    public bool IsServer
    {
      get { return isServer; }
      set { isServer = value; }
    }

    public User(int id, string name, string login, string password, string ip, bool isMasterServer, bool isServer)
    {
      this.id = id;
      this.name = name;
      this.login = login;
      this.password = password;
      this.ip = ip;
      this.isMasterServer = isMasterServer;
      this.isServer = isServer;
    }
  }
}