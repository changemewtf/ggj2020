using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicMeterController : MonoBehaviour
{
    public List<Sprite> FillSteps;
    public int PercentStep = 0;
    private SpriteRenderer spren;

    // Start is called before the first frame update
    void Start()
    {
        spren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spren.sprite = FillSteps[PercentStep];
    }
}
