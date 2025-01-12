using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC_UI : MonoBehaviour
{
    public GameObject PanelforNpc;
    public bool isOpenPanelforNpc;
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
        if (!isOpenPanelforNpc)
        {
            PanelforNpc.SetActive(true);
            NpcDetailsPanelAnimator.SetTrigger("Open");
            isOpenPanelforNpc = true;
        }
        else if (isOpenPanelforNpc)
        {
            isOpenPanelforNpc = false;
            NpcDetailsPanelAnimator.SetTrigger("Close");
            PanelforNpc.SetActive(false);


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
            for (int i = 0; i < npc.OnGoingQuests.Count; i++)
            {
                Quest OnGoingQuest = npc.OnGoingQuests[i];
                GameObject item = Instantiate(QuestPrefab, QuestList.transform);
                item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = OnGoingQuest.name;
                item.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = OnGoingQuest.description;

                Button buyButton = item.transform.Find("Buy").GetComponent<Button>();
                buyButton.interactable = false;
                buyButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = "Accepted";
            }

            for (int i = 0; i < npc.Quests.Count; i++)
            {
                Quest quest = npc.Quests[i];
                GameObject item = Instantiate(QuestPrefab, QuestList.transform);
                item.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = quest.name;
                item.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = quest.description;

                Button buyButton = item.transform.Find("Buy").GetComponent<Button>();
                buyButton.onClick.AddListener(() =>
                {
                    quest.isCompleted = false;
                    questChecker.AddQuest(quest);
                    item.transform.Find("Buy").GetComponentInChildren<TextMeshProUGUI>().text = "Accepted";
                    buyButton.interactable = false;
                    npc.OnGoingQuests.Add(quest);
                    npc.Quests.Remove(quest);
                });
            }
            NpcDetailsPanel.SetActive(true);
            isNpcDetailsPanel = true;


        }
        else if (isNpcDetailsPanel)
        {
            NpcDetailsPanel.SetActive(false);
            isNpcDetailsPanel = false;
        }
    }
}
