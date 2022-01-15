using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.VFX;

[ExecuteInEditMode]
public class TreeManager : MonoBehaviour
{
    [SerializeField] VisualEffect treeVfx;
    [SerializeField] int maxTrees = 8192;
    [SerializeField] Texture2D treePositionMap;

    private void OnEnable()
    {
        treePositionMap = new Texture2D(maxTrees, 1, TextureFormat.RGBAFloat, false);
        treePositionMap.filterMode = FilterMode.Point;
        treePositionMap.wrapMode = TextureWrapMode.Repeat;

        treeVfx.SetTexture("TreePositionMap", treePositionMap);
    }
    private void OnDestroy()
    {
        if (treePositionMap != null)
            DestroyImmediate(treePositionMap);
    }

    public void SpawnTree(int idx, Vector3 position, float size)
    {
        var color = new Color(position.x, position.y, position.z, size);
        treePositionMap.SetPixel(idx, 0, color);
        treePositionMap.Apply();

        treeVfx.SetInt("TreeIdx", idx);
        treeVfx.SendEvent("Spawn");
    }

    public void ClearTree(int idx)
    {
        treePositionMap.SetPixel(idx, 0, Color.clear);
        treePositionMap.Apply();
    }
}
