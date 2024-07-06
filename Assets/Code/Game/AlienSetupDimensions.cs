using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dimensions", menuName = "ScriptableObjects/Setup/AlienSetupDimensions")]
public class AlienSetupDimensions : ScriptableObject
{
    public IntVariable leftX;
    public IntVariable rightX;
    public IntVariable topY;
    public IntVariable bottomY;
    public IntVariable aliensInCol;
    public IntVariable aliensInRow;
}
