using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    //Base Stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] int expYield;
    [SerializeField] GrowthRate growthRate;

    [SerializeField] int catchRate = 255;

    [SerializeField] List<LearnableMove> learnableMoves;

    public static int MaxNumOffMoves { get; set; } = 4;

    public int GetExpForLevel(int level)
    {
        if (growthRate == GrowthRate.Fast)
        {
            return 4 * (level * level * level) / 5;
        }
        else if (growthRate == GrowthRate.MediumFast)
        {
            return level * level * level;
        }

        return -1;
    }
    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public Sprite BackSprite { get { return frontSprite; } }
    public Sprite FrontSprite { get {return backSprite; } }
    public PokemonType Type1 { get { return type1; } }
    public PokemonType Type2 { get { return type2; } }
    public int MaxHp { get { return maxHp; } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }
    public int SpAttack { get { return spAttack; } }
    public int SpDefense { get {return spDefense; } }
    public int Speed { get { return speed; } }
    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
    public int CatchRate => catchRate;
    public int ExpYield => expYield;
    public GrowthRate GrowthRate => growthRate;
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    { get { return moveBase; } }
    public int Level
    { get { return level; } }
}
public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy
}

public enum GrowthRate
{
    Fast, MediumFast
}

public enum Stat
{
    Attack,
    Defense,
    SpAttack,
    SpDefense,
    Speed,

    //There  2 are not actual stats, they're used to boost the moveAccuracy
    Accurcy,
    Evasion
}

public class TypeChart
{
     static float[][] chart =
    {
        //                       Nor   Fir    Wat    Ele    Gra    Ice    Fig    Poi    Gro    Fly    Psy    Bug    Roc    Gho    Dra    Dar    Ste    Fai    
        /*Normal*/  new float[]{ 1f,   1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,   0.5f,   0f,    1f,    1f,   0.5f,   1f  },
        /*Fire*/    new float[]{ 1f,  0.5f,  0.5f,   1f,    2f,    2f,    1f,    1f,    1f,    1f,    1f,    2f,   0.5f,   1f,   0.5f,   1f,    2f,    1f  },
        /*Water*/   new float[]{ 1f,   2f,   0.5f,   1f,   0.5f,   1f,    1f,    1f,    2f,    1f,    1f,    1f,    2f,    1f,   0.5f,   1f,    1f,    1f  },
        /*Electric*/new float[]{ 1f,   1f,    2f,   0.5f,  0.5f,   1f,    1f,    1f,    0f,    2f,    1f,    1f,    1f,    1f,   0.5f,   1f,    1f,    1f  },
        /*Grass*/   new float[]{ 1f,  0.5f,   2f,    1f,   0.5f,   1f,    1f,   0.5f,   2f,   0.5f,   1f,   0.5f,   2f,    1f,   0.5f,   1f,   0.5f,   1f  },
        /*Ice*/     new float[]{ 1f,  0.5f,  0.5f,   1f,    2f,   0.5f,   1f,    1f,    2f,    2f,    1f,    1f,    1f,    1f,    2f,    1f,   0.5f,   1f  },
        /*Fighting*/new float[]{ 2f,   1f,    1f,    1f,    1f,    2f,    1f,   0.5f,   1f,   0.5f,  0.5f,  0.5f,   2f,    0f,    1f,    2f,    2f,   0.5f },
        /*Poison*/  new float[]{ 1f,   1f,    1f,    1f,    2f,    1f,    1f,   0.5f,  0.5f,   1f,    1f,    1f,   0.5f,  0.5f,   1f,    1f,    0f,    2f  },
        /*Ground*/  new float[]{ 1f,   2f,    1f,    2f,   0.5f,   1f,    1f,    2f,    1f,    0f,    1f,   0.5f,   2f,    1f,    1f,    1f,    2f,    1f  },
        /*Flying*/  new float[]{ 1f,   1f,    1f,   0.5f,   2f,    1f,    2f,    1f,    1f,    1f,    1f,    2f,   0.5f,   1f,    1f,    1f,   0.5f,   1f  },
        /*Psychic*/ new float[]{ 1f,   1f,    1f,    1f,    1f,    1f,    2f,    2f,    1f,    1f,   0.5f,   1f,    1f,    1f,    1f,    0f,   0.5f,   1f  },
        /*Bug*/     new float[]{ 1f,  0.5f,   1f,    1f,    2f,    1f,   0.5f,  0.5f,   1f,   0.5f,   2f,    1f,    1f,   0.5f,   1f,    2f,   0.5f,  0.5f },
        /*Rock*/    new float[]{ 1f,   2f,    1f,    1f,    1f,    2f,   0.5f,   1f,   0.5f,   2f,    1f,    2f,    1f,    1f,    1f,    1f,   0.5f,   1f  },
        /*Ghost*/   new float[]{ 0f,   1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    2f,    1f,    1f,    2f,    1f,   0.5f,   1f,    1f  },
        /*Daragon*/ new float[]{ 1f,   1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    1f,    2f,    1f,   0.5f,   0f  },
        /*Dark*/    new float[]{ 1f,   1f,    1f,    1f,    1f,    1f,   0.5f,   1f,    1f,    1f,    2f,    1f,    1f,    2f,    1f,   0.5f,   1f,   0.5f },
        /*Steel*/   new float[]{ 1f,  0.5f,  0.5f,  0.5f,   1f,    2f,    1f,    1f,    1f,    1f,    1f,    1f,    2f,    1f,    1f,    1f,   0.5f,   2f  },
        /*Fairy*/   new float[]{ 1f,  0.5f,   1f,    1f,    1f,    1f,    2f,   0.5f,   1f,    1f,    1f,    1f,    1f,    1f,    2f,    2f,   0.5f,   1f  }
    };

    public static float GetEffecttiveness(PokemonType attackType, PokemonType defenseType)
    {
        if(attackType == PokemonType.None || defenseType == PokemonType.None)
            return 1;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}