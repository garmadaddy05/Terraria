﻿// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Gamepad.UILinkPoint
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 8A63A7A2-328D-424C-BC9D-BF23F93646F7
// Assembly location: H:\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.UI.Gamepad
{
  public class UILinkPoint
  {
    public int ID;
    public bool Enabled;
    public Vector2 Position;
    public int Left;
    public int Right;
    public int Up;
    public int Down;

    public int Page { get; private set; }

    public event Func<string> OnSpecialInteracts;

    public UILinkPoint(int id, bool enabled, int left, int right, int up, int down)
    {
      this.ID = id;
      this.Enabled = enabled;
      this.Left = left;
      this.Right = right;
      this.Up = up;
      this.Down = down;
    }

    public void SetPage(int page)
    {
      this.Page = page;
    }

    public void Unlink()
    {
      this.Left = -3;
      this.Right = -4;
      this.Up = -1;
      this.Down = -2;
    }

    public string SpecialInteractions()
    {
      // ISSUE: reference to a compiler-generated field
      if (this.OnSpecialInteracts != null)
      {
        // ISSUE: reference to a compiler-generated field
        return this.OnSpecialInteracts();
      }
      return string.Empty;
    }
  }
}
