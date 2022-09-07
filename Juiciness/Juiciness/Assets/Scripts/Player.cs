using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Interactable currentInteractable;
    Vector3 startPos;

    [SerializeField]
    float camMoveSpeed;

    //

    private Vector3 destiny;
 
    private Vector3 offset;
    bool isStaging = false;

    void Start()
    {  
        startPos = Camera.main.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(currentInteractable != null)
        {
            if(!currentInteractable.isPlaying)
            {
                currentInteractable = null;
                ZoomOut();
            }      
        }
        else
        {
            ZoomOut();

            if (Input.GetMouseButtonDown(0))
            {
                TryRaycast();
            }            
        }
        
        CameraControl();        
    }

    void ZoomIn(){
       switch (currentInteractable.gameObject.tag) {
        case "Crystal":
            offset = new Vector3(-8,6,10);
            break;
        
        case "Flask":
            offset = new Vector3(-8,0,10);
            break;

        case "Cage":
            offset = new Vector3(-18,8,22);
            break;

        default :
            offset = new Vector3(-8,6,10);
            break;
       }

        destiny = currentInteractable.transform.position;

        isStaging = true;
    }
    void ZoomOut(){
        offset = destiny = Vector3.zero;

        isStaging = false;
    }

    void CameraControl()
    {
        if(isStaging){
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, destiny+offset, camMoveSpeed * Time.deltaTime);
        }
        else{
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, startPos, camMoveSpeed * Time.deltaTime);
        }
    }
    

    //Raycast
    //Pega o Objeto, e salva o vetor da posição inicial, pq tem alguns que se mexem então vai tem q pegar a posição inicial
    //Quando atingir o objeto tem q verificar a tag dele, e modificar o offset de acordo, os valores que estão ali em cima já estão testados nos respectivos objetos
    //Passar a transform.position do Target pro Vector3 Destiny

    void TryRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.GetComponent<Interactable>())
            {
                currentInteractable = hit.collider.gameObject.GetComponent<Interactable>();
                currentInteractable.play();
                ZoomIn();
            }
            else if(hit.collider.transform.parent.GetComponent<Interactable>())
            {
                currentInteractable = hit.collider.transform.parent.GetComponent<Interactable>();
                currentInteractable.play();
                ZoomIn();
            }
        }
    }

}
