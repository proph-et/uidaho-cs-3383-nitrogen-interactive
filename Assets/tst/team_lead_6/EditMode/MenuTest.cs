// using NUnit.Framework;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class MenuTest_EditMode
// {
//     private MainMenu menu;

//     [SetUp]
//     public void Setup()
//     {
//         GameObject obj = new GameObject("MainMenu");
//         menu = obj.AddComponent<MainMenu>();
//     }

//     [Test]
//     public void PlayGame_BoundarySceneIndex_IsValidInBuildSettings()
//     {
//         // Arrange
//         int targetSceneIndex = 1;
//         int totalScenes = SceneManager.sceneCountInBuildSettings;

//         // Act + Assert: make sure build settings are set up properly
//         Assert.Greater(totalScenes, 1,
//             "Build Settings must include at least 2 scenes: the Main Menu and the Game Scene.");
//         Assert.Less(targetSceneIndex, totalScenes,
//             $"Scene index {targetSceneIndex} is invalid. Valid range: 0 - {totalScenes - 1}.");
//         Assert.GreaterOrEqual(targetSceneIndex, 0, "Scene index must be non-negative.");

//         // Optional: check that scene at index 1 exists on disk
//         string scenePath = SceneUtility.GetScenePathByBuildIndex(targetSceneIndex);
//         Assert.IsFalse(string.IsNullOrEmpty(scenePath),
//             $"No scene found at index {targetSceneIndex} in Build Settings.");
//         Assert.IsTrue(System.IO.File.Exists(scenePath),
//             $"Scene file not found at path: {scenePath}");

//         Debug.Log($"Scene at index {targetSceneIndex} is valid and exists at: {scenePath}");
//     }

//     [Test]
//     public void PlayGame_DoesNotThrow_WhenCalledInEditMode()
//     {
//         // Act + Assert: Ensure it doesn’t crash Unity when called
//         Assert.DoesNotThrow(() =>
//         {
//             try
//             {
//                 menu.PlayGame();
//             }
//             catch (System.InvalidOperationException)
//             {
//                 // Expected in Edit Mode, so swallow this specific error
//             }
//         }, "PlayGame() should not throw unexpected exceptions in Edit Mode.");

//         Debug.Log(" PlayGame() safely handled Edit Mode call.");
//     }
// }
