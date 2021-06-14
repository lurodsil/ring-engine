[System.Serializable]
public class Settings
{
    //Audio
    public float effectsVolume;
    public float musicVolume;
    public float voiceVolume;
    public VoiceType voiceType;

    //Graphics
    public bool ambientOcclusion;
    public bool motionBlur;
    public bool bloom;
    public bool colorGrading;

    //UI
    public HudType hudType;
    public LanguageType languageType;

    //Input
    public bool vibration;
    public bool invertFlightControl;

    public Settings()
    {

    }

    public static Settings DefaultSettings()
    {
        Settings settings = new Settings();

        settings.effectsVolume = 80;
        settings.musicVolume = 80;
        settings.voiceVolume = 80;
        settings.voiceType = VoiceType.Generations;

        settings.ambientOcclusion = false;
        settings.motionBlur = false;
        settings.bloom = false;
        settings.colorGrading = false;

        settings.hudType = HudType.Generations;
        settings.languageType = LanguageType.English;

        settings.vibration = true;
        settings.invertFlightControl = true;

        return settings;
    }
}