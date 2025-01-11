using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC_UI : MonoBehaviour
{
    public GameObject PanelforNpc;
    public bool isOpenPanelforNpc ;
    public GameObject NpcDetailsPanel;
    public GridLayoutGroup NpcDetailsPanelGrid;
    public Animator NpcDetailsPanelAnimator;
    public GameObject QuestList;
    public GameObject QuestPrefab;
    public QuestChecker questChecker;
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
            NpcDetailsPanelAnimator.SetTrigger("Open");
            isOpenPanelforNpc = true;
        }
        else if ( isOpenPanelforNpc )
        {
           isOpenPanelforNpc = false;
            NpcDetailsPanelAnimator.SetTrigger("Close");
            PanelforNpc.SetActive( false );


        }
    }
     public void ToggleNpcDetails(NPC npc)
    {
        if (!isNpcDetailsPanel)
        {
            foreach (Transform child in QuestList.transform)
            {
                Destroy(child.gameObject);
            }
            foreach(var quest in npc.Quests)
            {
               GameObject item = Instantiate(QuestPrefab, QuestList.transform);
               item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = quest.name;
                item.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = quest.description;
                item.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(() => { questChecker.AddQuest(quest); item.transform.Find("Buy").GetComponentInChildren<TextMeshProUGUI>().text = "Accepted";item.transform.Find("Buy").GetComponent<Button>().interactable = false; });
            }
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
