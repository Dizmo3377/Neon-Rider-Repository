using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject[] allProps;
    private GameObject[] stack = new GameObject[3];
    private Transform currentProp;

    private void Awake()
    {
        currentProp = this.transform;
        CreateProp(0f);
    }

    public void CreateProp(float offset)
    {
        int propId = Random.Range(0, allProps.Length);
        GameObject newProp = Instantiate(allProps[propId], new Vector3(currentProp.position.x + offset,0,0), Quaternion.identity);
        currentProp = newProp.transform;
        Add(newProp);
    }

    private void Add(GameObject prop)
    {
        int propsCount = 0;
        for (int i = 0; i < stack.Length; i++)
        {
            if (stack[i] == null)
            {
                stack[i] = prop;
                break;
            }
            propsCount++;
        }
        if (propsCount == stack.Length)
        {
            Sort(prop);
        }       
    }

    private void Sort(GameObject prop)
    {
        Destroy(stack[0]);
        stack[0] = null;
        for (int i = 0; i < stack.Length - 1; i++)
        {
            stack[i] = stack[i + 1];
        }
        stack[stack.Length - 1] = prop;
    }
}