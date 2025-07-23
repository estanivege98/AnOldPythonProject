using System;

[Serializable]
public class HighScoreElement
{
    public string playerName;
    public int score;

    public HighScoreElement(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }

    
}

