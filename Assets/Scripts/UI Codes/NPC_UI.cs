using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_UI : MonoBehaviour
{
    public GameObject PanelforNpc;
    public bool isOpen ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleOpen_Npc_Panels()
    {
     if ( !isOpen )
        {
            PanelforNpc.SetActive( true );
            isOpen = true;
        }
        else if ( isOpen )
        {
            PanelforNpc.SetActive( false );
            isOpen = false;
        }
    }
}
