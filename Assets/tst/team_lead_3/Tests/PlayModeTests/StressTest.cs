using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.IO;

public class Log
{
    string file_path = "log.txt";
    public void Write_to_file(int num_nodes)
    {
        using (StreamWriter writer = new StreamWriter(file_path, true))
        {
            writer.WriteLine(num_nodes);
        } 
    }
}


public class StressTest
{
    GameObject newNode;
    private Log log;

    private int num_nodes = 0;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return new WaitForFixedUpdate();
        yield return SceneManager.LoadSceneAsync("SkillTreeScene"); // change to the correct name

        newNode = new GameObject("Node");
        newNode.AddComponent<Node>();

        log = new Log();

        yield return null;
    }

    public void AddNode()
    {
        GameObject node = new GameObject($"Node_{num_nodes}");
        node.AddComponent<Node>();

        log.Write_to_file(num_nodes);

        this.num_nodes++;
    }

    [UnityTest]
    public IEnumerator NodeSpawn()
    {
        int total = 1000000; // amount of nodes we spawn in
        for (int i = 0; i < total; i++)
        {
            AddNode();
            //Debug.Log($"Node: {num_nodes}");
        }
        if (num_nodes == total)
        {
            Assert.Fail(); // the stress test didn't work basically
        }
        else if (num_nodes > total)
        {
            Assert.Pass();
        }

        yield return null;
    }
}

