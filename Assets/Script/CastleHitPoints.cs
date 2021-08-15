using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CastleHitPoints : MonoBehaviour
{
    Text CastleHitPointsText;

    // Start is called before the first frame update
    void Start()
    {
        CastleHitPointsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCastleHitPoint();
    }

    void ShowCastleHitPoint()
    {
        CastleHitPointsText.text = Castle.currentCastleHitPoints.ToString();
    }
}
