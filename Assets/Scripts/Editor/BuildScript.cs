using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

public class BuildScript
{
    [MenuItem("Build/Build WebGL")]
    static void PerformBuild()
    {
        var sceneSettings = EditorBuildSettings.scenes;
        Console.WriteLine(sceneSettings);
        string[] scenePaths = new string[sceneSettings.Length];

        Console.WriteLine(sceneSettings.Length);
        for (int i = 0; i < scenePaths.Length; ++i)
        {
            Console.WriteLine(sceneSettings[i].guid);
            Console.WriteLine(sceneSettings[i].path);
            scenePaths[i] = sceneSettings[i].path;
        }
        BuildPipeline.BuildPlayer(scenePaths, "build/web-gl", BuildTarget.WebGL, BuildOptions.None);
    }
}
