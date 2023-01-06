using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_selection : MonoBehaviour
{
    selected_dictionary selected_table;
    RaycastHit hit;
    bool dragSelect;
    BoxCollider2D boxColl;

    MeshCollider selectionBox;
    Mesh selectionMesh;

    Vector3 p1;
    Vector3 p2;
    Vector3 init;
    Vector3 current;

    Vector2[] corners;
    Vector3[] verts;
    Vector3[] vecs;


    // Start is called before the first frame update
    void Start()
    {
        selected_table = GetComponent<selected_dictionary>();
        dragSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            p1 = Input.mousePosition;
            init = Camera.main.ScreenToWorldPoint(p1);

        }

        if (Input.GetMouseButton(0))
        {
            if ((p1 - Input.mousePosition).magnitude > 20 && !dragSelect)
            {
                boxColl = gameObject.AddComponent<BoxCollider2D>();
                boxColl.isTrigger = true;
                boxColl.offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                dragSelect = true;
            }
        }

        if (dragSelect)
        {
            current = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (current + init) / 2;
            boxColl.size = new Vector2(
                Mathf.Abs(init.x - current.x),
                Mathf.Abs(init.y - current.y));
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected_table.selectionSum();
            dragSelect = false;
            Destroy(boxColl);
            transform.position = Vector3.zero;
        }
    }

    void OnGUI()
    {
        if (dragSelect)
        {
            var rect = Utils.GetScreenRect(p1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        selected_table.addSelected(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        selected_table.deselect(other.gameObject);
    }
}
