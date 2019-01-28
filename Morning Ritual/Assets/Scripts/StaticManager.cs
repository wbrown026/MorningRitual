using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticManager
{
    // Global
    public static int day = 0;
    public static float chaosMeter = 100f;

    // Wake Up
    public static float time = 0f;

    // Breakfast
    public static GameObject cereal;
    public static float milkLevel = 0f;

    // Brush Teeth
    public static int numberOfBrushes = 0;

    // Shower
    public static float temperature = 0f;

    // Get Dressed
    public static Color shirtColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
}
