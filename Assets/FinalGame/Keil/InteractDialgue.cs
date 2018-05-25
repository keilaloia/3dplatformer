using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialgue : MonoBehaviour
{
    public Dial dialz;

    public void TriggerDial()
    {
        FindObjectOfType<Dialogue>().StartDialogue(dialz);
    }
}
