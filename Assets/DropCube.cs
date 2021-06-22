//Unity Engineと言うライブラリを使います。
using UnityEngine;

public class DropCube : MonoBehaviour
{
    //MonoBehaviourを継承したDropCubeというクラスを定義します。

    public GameObject MyCube;
    //インスペクタでプレハブを指定出来る項目を作る。MyCubeは自分で決めてもいい名前。
    //void DropOne で書く名前は同じにしてください。

    private int CubeCount = 0;
    //このスクリプトの中だけでも参照出来る整数のCubeCountと言う変数の定義。
    //CubeCountの部分は変数名であり自分で決める事が出来ます。
    //void DropOneに書く名前は同じにしてください。



    // Start is called before the first frame update
    void Start()
    {

        //Start、始まったら以下を実行します。
        InvokeRepeating("DropOne", 2f, 1f);
        //始まって２秒経ったらDropOne関数を呼び出してそれ以降は１秒毎に呼び出します。

    }
    void DropOne()
    {

        //DoropOneが呼ばれたら以下を実行。これが関数になります。
        CubeCount++;
        //CubeCountの値を１つ追加

        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(MyCube, new Vector3(1.0f, 20.0f, 0.0f), Quaternion.identity);


        if (CubeCount == 100)
        {
            //100こ生成したら終わります。

            CancelInvoke();
        }
    }


}
