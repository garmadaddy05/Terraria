﻿// Decompiled with JetBrains decompiler
// Type: Terraria.RemoteServer
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 8A63A7A2-328D-424C-BC9D-BF23F93646F7
// Assembly location: H:\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System;
using System.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria
{
  public class RemoteServer
  {
    public ISocket Socket = (ISocket) new TcpSocket();
    public bool IsActive;
    public int State;
    public int TimeOutTimer;
    public bool IsReading;
    public byte[] ReadBuffer;
    public string StatusText;
    public int StatusCount;
    public int StatusMax;

    public void ClientWriteCallBack(object state)
    {
      --NetMessage.buffer[256].spamCount;
    }

    public void ClientReadCallBack(object state, int length)
    {
      try
      {
        if (!Netplay.disconnect)
        {
          int streamLength = length;
          if (streamLength == 0)
          {
            Netplay.disconnect = true;
            Main.statusText = Language.GetTextValue("Net.LostConnection");
          }
          else if (Main.ignoreErrors)
          {
            try
            {
              NetMessage.ReceiveBytes(this.ReadBuffer, streamLength, 256);
            }
            catch
            {
            }
          }
          else
            NetMessage.ReceiveBytes(this.ReadBuffer, streamLength, 256);
        }
        this.IsReading = false;
      }
      catch (Exception ex)
      {
        try
        {
          using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
          {
            streamWriter.WriteLine((object) DateTime.Now);
            streamWriter.WriteLine((object) ex);
            streamWriter.WriteLine("");
          }
        }
        catch
        {
        }
        Netplay.disconnect = true;
      }
    }
  }
}
