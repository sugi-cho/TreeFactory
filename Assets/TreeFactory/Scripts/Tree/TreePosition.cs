using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TreePosition : MonoBehaviour
{
    [SerializeField] TreeManager manager;
    [SerializeField] int idx;

    private void Reset()
    {
        if (manager == null)
            manager = GetComponentInParent<TreeManager>();
        idx = System.Array.IndexOf(manager.GetComponentsInChildren<TreePosition>(), this);
    }

    [ContextMenu("spawn tree")]
    public void SpawnTree()
        => manager.SpawnTree(idx, transform.position, transform.localScale.x);

    [ContextMenu("clear tree")]
    public void ClearTree()
        => manager.ClearTree(idx);
}
