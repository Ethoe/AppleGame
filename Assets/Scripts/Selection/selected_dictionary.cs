using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_dictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();
    private bool freeze = false;
    start_game game_controller;
    void Start()
    {
        game_controller = GetComponent<start_game>();
    }

    public void addSelected(GameObject go)
    {
        if (!freeze)
        {
            int id = go.GetInstanceID();

            if (!(selectedTable.ContainsKey(id)))
            {
                selectedTable.Add(id, go);
                go.AddComponent<selection_component>();
                Debug.Log("Added " + go.GetComponent<apple_value>().applevalue + " to dict");
            }
        }
    }

    public void selectionSum()
    {
        int sum = 0;
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                sum += selectedTable[pair.Key].GetComponent<apple_value>().applevalue;
            }
        }
        if (sum == game_controller.winCon)
        {
            destroyAll();
        }
        else
        {
            deselectAll();
        }
    }

    public void deselect(GameObject go)
    {
        if (!freeze)
        {
            int id = go.GetInstanceID();
            if (selectedTable.ContainsKey(id))
            {
                Destroy(selectedTable[id].GetComponent<selection_component>());
                selectedTable.Remove(id);

            }
        }
    }

    public void deselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                Destroy(selectedTable[pair.Key].GetComponent<selection_component>());
            }
        }
        selectedTable.Clear();
    }

    public void destroyAll()
    {
        freeze = true;
        int count = 0;
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                count++;
                selectedTable[pair.Key].GetComponent<apple_value>().Scored();
            }
        }
        game_controller.Score(count);
        selectedTable.Clear();
        freeze = false;
    }
}
