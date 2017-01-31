﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectSubTilesModule
// Assembly: TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null
// MVID: C7ED7F12-DBD9-42C5-B3E5-7642F0F95B55
// Assembly location: E:\Steam\SteamApps\common\Terraria\TerrariaServer.exe

using System.Collections.Generic;
using Terraria.ObjectData;

namespace Terraria.Modules
{
  public class TileObjectSubTilesModule
  {
    public List<TileObjectData> data;

    public TileObjectSubTilesModule(TileObjectSubTilesModule copyFrom = null, List<TileObjectData> newData = null)
    {
      if (copyFrom == null)
        this.data = (List<TileObjectData>) null;
      else if (copyFrom.data == null)
      {
        this.data = (List<TileObjectData>) null;
      }
      else
      {
        this.data = new List<TileObjectData>(copyFrom.data.Count);
        for (int index = 0; index < this.data.Count; ++index)
          this.data.Add(new TileObjectData(copyFrom.data[index]));
      }
    }
  }
}