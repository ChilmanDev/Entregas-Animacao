using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
struct FrequencyData{
    public FrequencyRange frequencyRange;
    public float avarageAmplitude;
}

[System.Serializable]
struct FrequencyConfig{
    public FrequencyData MainBranchesAmmount;
    public FrequencyData MainBranchesThickness;
    public FrequencyData SecondaryBranchesAmmount;
    public FrequencyData SecondaryBranchesThickness;
    public FrequencyData SecondaryBranchesGap;
    public FrequencyData CenterFill;
    public FrequencyData Scale;
}

public class SnowFlakeModifier : MonoBehaviour
{
    [SerializeField]
    AudioPeer _audioPeer;
    float mainBranches = 6f, mainBranchesThicc = 0.6f;
    float secondaryBranches = 6f, secondaryBranchesThicc = 0.5f, secondaryBranchesGap = 0.1f;
    float centerFill = 1f, scale = 1f, startScale;

    [SerializeField]
    GameObject snowFlake;

    [SerializeField]
    FrequencyConfig _frequencyConfig;

    [SerializeField]
    bool useBuffer;
    //FrequencyRange[] frequencyControl = new FrequencyRange[7];

    /*
    Num de branches = 4-6-8
    Tamanho branches principais = 1x-3x

    Num de branches secundarios = 1-3
    Tamanho branches secundarios = 0.2 x principal - 0.5 x princial 

    Scale geral = 0.5x - 2.5x

    Bool
    Centro vazio
    Branches secundarios de tamnhos diferentes


    Max values:
    Sub-bass
    0.26072
    0.01516

    Bass
    0.15749
    0.02218

    Lower MidRange
    0.10785
    0.02498

    MidRange
    0.03142
    0.00666

    Upper MidRange
    0.01251
    0.00212

    Presence
    0.00815
    0.0011

    Blilliance
    0.00162
    0.00017
    */

    // Start is called before the first frame update
    void Start()
    {
        startScale = snowFlake.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {   
        AnalizeAudio();
    }

    void AnalizeAudio()
    {
        // Num de branches = 6-8-10 -> Bass 0.157

        // //int percentage = (int)((100f * (float)System.Math.Round(_audioPeer._freqBand[(int)FrequencyRange.Bass], 5)) / (0.02218f * 2));
        // float percentage = ((float)System.Math.Round(_audioPeer._freqBand[(int)FrequencyRange.Bass], 5)) / (0.02218f * 2);

        // //mainBranches = 6 + (((int)(percentage / 33) * 2) < 3 ? (int)(percentage / 33) * 2 : 4);

        // mainBranches = 6f + (percentage * 4f);
        UpdateMainBranchesAmount(_frequencyConfig.MainBranchesAmmount.frequencyRange, _frequencyConfig.MainBranchesAmmount.avarageAmplitude);

        UpdateMainBranchesThickness(_frequencyConfig.MainBranchesThickness.frequencyRange, _frequencyConfig.MainBranchesThickness.avarageAmplitude);

        UpdateSecondaryBranchesAmount(_frequencyConfig.SecondaryBranchesAmmount.frequencyRange, _frequencyConfig.SecondaryBranchesAmmount.avarageAmplitude);

        UpdateSecondaryBranchesThickness(_frequencyConfig.SecondaryBranchesThickness.frequencyRange, _frequencyConfig.SecondaryBranchesThickness.avarageAmplitude);

        UpdateSecondaryBranchesGap(_frequencyConfig.SecondaryBranchesGap.frequencyRange, _frequencyConfig.SecondaryBranchesGap.avarageAmplitude);

        UpdateCenterFill(_frequencyConfig.CenterFill.frequencyRange, _frequencyConfig.CenterFill.avarageAmplitude);

        UpdateScale(_frequencyConfig.Scale.frequencyRange, _frequencyConfig.Scale.avarageAmplitude);

    }

    void UpdateMainBranchesAmount(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 6f      Max = 10f
        mainBranches = 6f + (percentage * 4f);

        //Set ammount of main branches
        snowFlake.GetComponent<Renderer>().sharedMaterial.SetFloat("_Main_Branches" , mainBranches); 
    }

    void UpdateMainBranchesThickness(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 0.55f   Max = 0.6f
        mainBranchesThicc = (percentage * 0.05f) + 0.55f;

        //Set thickness of main branches
        snowFlake.GetComponent<Renderer>().sharedMaterial.SetFloat("_Main_Branches_Thickness" , mainBranchesThicc);
    }

    void UpdateSecondaryBranchesAmount(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 2f      Max = 10f
        secondaryBranches = (percentage * 8f) + 2f;

        //Set ammount of secondary branches
        snowFlake.GetComponent<Renderer>().sharedMaterial.SetFloat("_Secondary_Branches", secondaryBranches);
    }

    void UpdateSecondaryBranchesThickness(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 0.2f    Max = 0.8f
        secondaryBranchesThicc = (percentage * 0.6f) + 0.2f;

        //Set thickness of secondary branches
        snowFlake.GetComponent<Renderer>().sharedMaterial.SetFloat("_Secondary_Branches_Thickness", secondaryBranchesThicc);
    }

    void UpdateSecondaryBranchesGap(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 0f      Max = 0.3f
        secondaryBranchesGap = (percentage * 0.3f);

        //Set secondary branches gap
        snowFlake.GetComponent<Renderer>().sharedMaterial.SetFloat("_Secondary_Branches_Gap", secondaryBranchesGap);
    }

    void UpdateCenterFill(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 0.95f      Max = 1f
        centerFill = (percentage * 0.05f) + 0.95f;

        //Set center fill
        snowFlake.GetComponent<Renderer>().sharedMaterial.SetFloat("_Center_Fill", centerFill);
    }

    void UpdateScale(FrequencyRange range, float average_amp)
    {
        if (range == FrequencyRange.None) return;

        float percentage = Mathf.Clamp(((float)System.Math.Round(_audioPeer.getBand((int)range, useBuffer), 5)) / (average_amp * 2), 0f, 1f);

        //Min = 0.7f    Max = 1.3f
        scale = (percentage * 0.6f) + 0.7f;

        //Set scale
        snowFlake.transform.localScale = new Vector3(scale * startScale, scale * startScale, scale * startScale);
    }
}
