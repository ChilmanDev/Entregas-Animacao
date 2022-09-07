using UnityEngine;
using System.Collections;
 
public class Shakev2 : MonoBehaviour
{
    public Material flaskMat;
    public Material flaskGlowMat;
    public GameObject particle;


    Color emissiveColor = Color.blue;  

    [HideInInspector]
    public bool isPlaying = false;

   [Header("Info")]
   private Vector3 _startPos;
   private float _timer;
   private Vector3 _randomPos;
 
   [Header("Settings")]
   [Range(0f, 2f)]
   public float _time = 0.2f;
   [Range(0f, 2f)]
   public float _distance = 0.1f;
   [Range(0f, 0.1f)]
   public float _delayBetweenShakes = 0f;
 
   private void Awake()
   {
       _startPos = transform.position;
   }
 
    void Update(){
        if (Input.GetKeyDown(KeyCode.F))
        {
           Begin();
        }
        GlowInGlowOut();
        
    }
   private void OnValidate()
   {
       if (_delayBetweenShakes > _time)
           _delayBetweenShakes = _time;
   }
 
   public void Begin()
   {
        StopAllCoroutines();
        StartCoroutine(Shake());
       
   }
 
   private IEnumerator Shake()
   {    

        var mats = gameObject.GetComponent<MeshRenderer> ().materials;
        mats[2] = flaskGlowMat;
        gameObject.GetComponent<MeshRenderer> ().materials = mats;
        particle.SetActive(true);
       _timer = 0f;

       isPlaying = true;
 
       
       while (_timer < _time)
       {
           _timer += Time.deltaTime;
 
           _randomPos = _startPos + (Random.insideUnitSphere * _distance);
 
           transform.position = _randomPos;
           
 
           if (_delayBetweenShakes > 0f)
           {
               yield return new WaitForSeconds(_delayBetweenShakes);
           }
           else
           {
               yield return null;
           }
       }
       mats[2] = flaskMat;
       gameObject.GetComponent<MeshRenderer> ().materials = mats;
       transform.position = _startPos;
       particle.SetActive(false);
       isPlaying = false;
   }
   

   private void GlowInGlowOut(){

    float phi = Time.time / _time *2 * Mathf.PI;
    float amplitude = Mathf.Cos(phi) * 1.0f +1.0f;
    float R = amplitude;
    float G = amplitude;
    float B = amplitude;

    flaskGlowMat.SetColor("_EmissionColor", new Color(0.0f,G+0.5f,B+0.8f));

   }
}