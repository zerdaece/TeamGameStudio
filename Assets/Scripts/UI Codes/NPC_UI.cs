using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_UI : MonoBehaviour
{
    public GameObject PanelforNpc;
    public bool isOpenPanelforNpc ;
    public GameObject NpcDetailsPanel;
    public bool isNpcDetailsPanel;
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
     if ( !isOpenPanelforNpc )
        {
            PanelforNpc.SetActive( true );
            isOpenPanelforNpc = true;
        }
        else if ( isOpenPanelforNpc )
        {
            PanelforNpc.SetActive( false );
           isOpenPanelforNpc = false;
        }
    }
     public void ToggleNpcDetails()
    {
        if (!isNpcDetailsPanel)
        {
            NpcDetailsPanel.SetActive(true);
            isNpcDetailsPanel = true;
            
            
        }
        else if (isNpcDetailsPanel)
        {
            NpcDetailsPanel.SetActive(false);
           isNpcDetailsPanel= false;
        }
    }
}
