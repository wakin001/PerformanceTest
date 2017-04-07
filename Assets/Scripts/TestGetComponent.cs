using UnityEngine;
using System.Collections;

/// <summary>
/// Result:
/// GetComponent(string) finished : 1886.00 ms total 0.001886 ms per test for 1000000 tests
/// GetComponent<ComponentName>() finished : 79.00 ms total 0.000079 ms per test for 1000000 tests   (Fastest!! Unity 5.4)
/// GetComponent(typof(ComponentName)) finished : 82.00 ms total 0.000082 ms per test for 1000000 tests
/// </summary>
public class TestGetComponent : MonoBehaviour 
{
    int numTests = 1000000;
    TestComponent test;

	// Use this for initialization
	void Start () 
    {
        using (new CustomTimer("GetComponent(string)", numTests))
        {
            for (var i = 0; i < numTests; ++i)
            {
                test = (TestComponent)GetComponent("TestComponent");
            }
        }

        using (new CustomTimer("GetComponent<ComponentName>()", numTests))
        {
            for (var i = 0; i < numTests; ++i)
            {
                test = GetComponent<TestComponent>();
            }
        }

        using (new CustomTimer("GetComponent(typof(ComponentName))", numTests))
        {
            for (var i = 0; i < numTests; ++i)
            {
                test = (TestComponent)GetComponent(typeof(TestComponent));
            }
        }

	}
	
}
