using UnityEngine;

public class SetParticleVolume : GenerationsObject
{

    public float Collision_Height = 16f;
    public float Collision_Length = 15f;
    public float Collision_Width = 15f;
    public float DefaultStatus = 0f;
    public string EFFECTNAME1 = "ef_st_ghz_yh1_waterfall1";
    public string EFFECTNAME2 = "dummy_effect";
    public float EFFECT_SCALE1 = 1f;
    public float EFFECT_SCALE2 = 1f;
    public float EFFECT_SCALE_TYPE1 = 0f;
    public float EFFECT_SCALE_TYPE2 = 0f;
    public float EFFECT_SCALE_X1 = 1f;
    public float EFFECT_SCALE_X2 = 1f;
    public float EFFECT_SCALE_Y1 = 1f;
    public float EFFECT_SCALE_Y2 = 1f;
    public float EFFECT_SCALE_Z1 = 1f;
    public float EFFECT_SCALE_Z2 = 1f;
    public float EFF_COL_SCALE_A1 = 1f;
    public float EFF_COL_SCALE_A2 = 1f;
    public float EFF_COL_SCALE_B1 = 1f;
    public float EFF_COL_SCALE_B2 = 1f;
    public float EFF_COL_SCALE_G1 = 1f;
    public float EFF_COL_SCALE_G2 = 1f;
    public float EFF_COL_SCALE_R1 = 1f;
    public float EFF_COL_SCALE_R2 = 1f;
    public float EMITTER1 = 2f;
    public float EMITTER2 = 0f;
    public Vector3 EMITTER_POS1;
    public Vector3 EMITTER_POS2;


    public bool NO_STOP_EVENT1 = true;
    public bool NO_STOP_EVENT2 = true;
    public bool ONLY_ONCE1 = true;
    public bool ONLY_ONCE2 = false;

    public string SENAME1 = "4012_splash04";
    public string SENAME2 = "4002_ring";
    public float Shape_Type = 0f;
    public int Trigger;
    public float TriggerType = 0f;
    public bool USE1 = true;
    public bool USE2 = false;
    public bool USESE1 = true;
    public bool USESE2 = false;

    public override void OnValidate()
    {

    }
}