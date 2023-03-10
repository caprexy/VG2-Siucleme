using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS { 
public class InteractButton : MonoBehaviour
{
    public GameObject interactionTarget; 

    public void Interact()
    {
        if(interactionTarget != null)
        {
            Door targetDoor = interactionTarget.GetComponent<Door>();
            if(targetDoor != null)
            {
                targetDoor.Interact(gameObject);
            }

            InteractLight targetLight = interactionTarget.GetComponent<InteractLight>();
            if (targetLight != null)
            {
                    targetLight.Interact();
            }
            }
    }
}
}
