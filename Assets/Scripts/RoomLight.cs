using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomLight : MonoBehaviour
{
    public Slider redChannel, greenChannel, blueChannel;
    public List<Light> listOfLights;

    // Update is called once per frame
    void Update()
    {
        Color newColor = new Color(redChannel.value, greenChannel.value, blueChannel.value);

        foreach (Light lightbulb in listOfLights)
        {
            lightbulb.color = newColor;
        }
    }
}
