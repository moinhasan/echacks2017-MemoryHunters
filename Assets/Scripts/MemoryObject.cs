using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryObject : MonoBehaviour {
    
    public MemoryProperties Properties { get; set; }
    Renderer myRenderer;

    public bool isFocused;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        isFocused = Raycast();
        /*if (isFocused)
        {
            myRenderer.material.color = Color.red;
        }
        else
        {
            myRenderer.material.color = Color.white;
        }*/
    }

    private bool Raycast()
    {
        RaycastHit objectHit;
        Vector3 fromPosition = transform.position;
        Vector3 toPosition = Camera.main.transform.position;
        Vector3 direction = toPosition - fromPosition;
        Vector3 fwd = transform.TransformDirection(-Vector3.forward);
        //Vector3 direction = (Camera.main.transform.position - transform.position);
        Debug.DrawRay(transform.position, direction, Color.green);
        if (Physics.Raycast(transform.position, direction, out objectHit))
        {
            if (objectHit.collider.gameObject.CompareTag("View"))
            {
                return true;

            }
        }
        return false;
    }
    /* private GameObject MouseRaycast(List<Node> movementRange)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, int.MaxValue);

        if(hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
        {
            Tile tile = hit.collider.gameObject.GetComponent<Tile>();
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

            //For movement
            if (tile != null && !Attacking && movementRange.Contains(GetTargetNode(tile)))
                return hit.collider.gameObject;
            //For attacking
            else if (enemy != null && Pathfinding.GetRange(Nodes, friendlies[0].nodeParent, lastSelectedAttack.Range).Contains(enemy.nodeParent))
                return hit.collider.gameObject;
        }
        return null;
        
    }*/
}
