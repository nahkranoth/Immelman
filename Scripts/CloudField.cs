using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.WSA;

public class Cloud
{
    public Vector3 pos;
    public Vector3 scale;
    public Quaternion rot;
    public int x;
    public int y;

    public Matrix4x4 matrix
    {
        get
        {
            return Matrix4x4.TRS(pos, rot, scale);
        }
    }

    public Cloud(Vector3 pos, Vector3 scale, Quaternion rot)
    {
        this.pos = pos;
        this.scale = scale;
        this.rot = rot;
    }
}
[ExecuteInEditMode]
public class CloudField : MonoBehaviour
{
    public Mesh cloudMesh;
    public Material cloudMat;
    public float distance;
    public float amount;
    public float cloudScale;
    public bool active;
    public float timeScale;
    private List<Cloud> clouds;
    private List<List<Cloud>> cloudBatches;

    public NoiseGenerator noise;


private void Update()
    {
        int batches = Mathf.CeilToInt(amount / 31f);
        cloudBatches = new List<List<Cloud>>();
        for (var b = 0; b < batches; b++) {
            clouds = new List<Cloud>();
            for (var i = 0; i < 31; i++)
            {
                for(var j = 0; j < 31; j++)
                {
                    var pos = new Vector3( transform.position.x + ( i * distance), transform.position.y, transform.position.z + ( j * distance) );
                    var tempCloudScale = cloudScale * Mathf.Max(0f, noise.Noise(i/amount, j / amount, Time.time * timeScale)); //TODO: to keep it fair Time.time should be server time
                    if (tempCloudScale == 0f) continue;
                    var size = new Vector3(tempCloudScale, tempCloudScale, tempCloudScale);
                    clouds.Add(new Cloud(pos, size, Quaternion.identity));
                }
            }
            cloudBatches.Add(clouds);
        }
        for(var cb = 0; cb < cloudBatches.Count; cb++)
        {
            var currClouds = cloudBatches[cb];
            Graphics.DrawMeshInstanced(cloudMesh, 0, cloudMat, currClouds.Select((a) => a.matrix).ToList());
        }
        active = true;
    }
}
