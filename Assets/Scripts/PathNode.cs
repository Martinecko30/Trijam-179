using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] public List<PathNode> nextNodes;

    private void OnDrawGizmos()
    {
        foreach (var pathNode in nextNodes)
        {

            Gizmos.DrawLine(transform.position, pathNode.transform.position);
        }
    }
}