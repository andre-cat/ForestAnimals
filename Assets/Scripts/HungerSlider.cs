using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Canvas))]
public class HungerSlider : MonoBehaviour
{

    private AnimalController animal;

    private Canvas canvas;
    private Slider slider;

    private void Awake()
    {
        animal = gameObject.transform.parent.gameObject.GetComponent<AnimalController>();

        canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        slider = gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.maxValue = animal.FoodNeeded;
        slider.value = 0.1f;
    }

    private void FixedUpdate()
    {
        slider.value = animal.CurrentFood;

        if (animal.IsFed())
        {
            ColorBlock colors = slider.colors;
            colors.disabledColor = Color.green;
            slider.colors = colors;
        }

        slider.gameObject.transform.LookAt(Vector3.back);
    }
}
