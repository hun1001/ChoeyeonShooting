using System.Collections.Generic;

[System.Serializable]

public class User
{
    public long bestScore;
    public Material material = new Material();
    public Upgrade upgrade = new Upgrade();
}
