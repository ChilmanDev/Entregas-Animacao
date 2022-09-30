using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowFlakeGenerator : MonoBehaviour
{
    [SerializeField]
    AudioPeer _audioPeer;

    int mainBranches, secondaryBranches;
    float mainBranchesSize, secondaryBranchesSize, scale;
    bool hollow, secondaryBranchesVariation;

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
    0.26

    Bass
    0.157

    Lower MidRange
    0.1

    MidRange
    0.03

    Upper MidRange
    0.012

    Presence
    0.008

    Blilliance
    0.0016
    */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        AnalizeAudio();
        UpdateSnowflake();

    }

    void AnalizeAudio()
    {
        // Num de branches = 4-6-8 -> Bass 0.157

        int percentage = (int)((100f * (float)System.Math.Round(_audioPeer._freqBand[(int)FrequencyRange.Bass], 5)) / 0.157f);

        mainBranches = 4 + (((int)(percentage / 33) * 2) < 3 ? (int)(percentage / 33) * 2 : 4);


    }

    void UpdateSnowflake()
    {
        //Create main branches

    }
}
