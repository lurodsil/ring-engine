public static class Achievements
{

    public static Achievement[] achievements = new Achievement[]
    {
        new Achievement("Welcome to Ring Engine!", "Bem vindo a Ring Engine!", "Started the game", "Iniciou o jogo"),
        new Achievement("Ah! One extra life!", "Ah! Uma vida extra!", "Collected 100 Rings", "Coletou 100 Rings"),
        new Achievement("Die Without Fear!", "Die Without Fear!", "Get the first Checkpoint", "Get the first Checkpoint")
    };

    public static int startedTheGameId = 0;
    public static int collected100Rings = 1;
    public static int getCheckpoint = 2;
}

public class Achievement
{
    public string achievmentEn;
    public string achievmentPt;
    public string reasonEn;
    public string reasonPt;

    public Achievement()
    {

    }

    public Achievement(string achievmentEn, string achievmentPt, string reasonEn, string reasonPt)
    {
        this.achievmentEn = achievmentEn;
        this.achievmentPt = achievmentPt;
        this.reasonEn = reasonEn;
        this.reasonPt = reasonPt;
    }
}
