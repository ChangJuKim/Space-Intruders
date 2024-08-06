using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dimensions", menuName = "ScriptableObjects/Setup/AlienSetupDimensions")]
public class AlienSetupDimensions : ScriptableObject
{
    [SerializeField] private IntVariable leftX;
    [SerializeField] private IntVariable rightX;
    [SerializeField] private IntVariable topY;
    [SerializeField] private IntVariable bottomY;
    [SerializeField] private IntVariable aliensInCol;
    [SerializeField] private IntVariable aliensInRow;

    public IntVariable LeftX { get => leftX; set => leftX = value; }
    public IntVariable RightX { get => rightX; set => rightX = value; }
    public IntVariable TopY { get => topY; set => topY = value; }
    public IntVariable BottomY { get => bottomY; set => bottomY = value; }
}
