using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase Base { get; set; }
    public int PP { get; set; }

    public Move(MoveBase pbase)
    {
        Base = pbase;
        PP = pbase.PP;
    }

    public Move(MoveSaveData savedata)
    {
        Base = MoveDB.GetMoveByName(savedata.name);
        PP = savedata.pp;
    }

    public MoveSaveData GetSaveData()
    {
        var saveData = new MoveSaveData()
        {
            name = Base.Name,
            pp = PP,
        };
        return saveData;
    }
}

[Serializable]
public class MoveSaveData
{
    public string name;
    public int pp;
}
