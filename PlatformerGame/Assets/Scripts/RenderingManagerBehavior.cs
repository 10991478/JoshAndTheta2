using UnityEngine;

public class RenderingManagerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] managingObjects;
    [SerializeField] private GameObject player;
    public float xRange = 30;
    public float yRange = 20;
    private bool active = true;
    private float xDistance, yDistance;
    void Update()
    {
        xDistance = Mathf.Abs(transform.position.x - player.transform.position.x);
        yDistance = Mathf.Abs(transform.position.y - player.transform.position.y);
        if (xDistance > xRange || yDistance > yRange && active)
        {
            Deactivate(managingObjects);
            active = false;
        }
        else if (xDistance <= xRange && yDistance <= yRange && !active)
        {
            Activate(managingObjects);
            active = true;
        }
    }

    public void Deactivate(GameObject[] objectList)
    {
        for (int i = 0; i < objectList.Length; i++)
        {
            objectList[i].SetActive(false);
        }
    }

    public void Activate(GameObject[] objectList)
    {
        InitialConditions initConds;
        for (int i = 0; i < objectList.Length; i++)
        {
            objectList[i].SetActive(true);
            initConds = objectList[i].GetComponent<InitialConditions>();
            if (initConds != null)
            {
                initConds.RestoreToInitialConditions();
            }
        }
    }
}
