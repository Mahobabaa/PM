using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Sprite[] MySprites;
    public GameObject ThisMap;
    int[,] LevelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,8,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},             
    };

  public static  int[,] ToTalMap = new int[29, 28];
    // Start is called before the first frame update
    void Start()//地图初始化
    {
        int[,] LevelMap1=new int[15,14];
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                LevelMap1[i,j] = LevelMap[ i,13-j];
            }
        }
        int[,] LevelMap2 = new int[15, 28];
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                if (j < 14)
                    LevelMap2[i, j] = LevelMap[i, j];
                else
                {
                    LevelMap2[i, j] = LevelMap1[i, j-14];
                }
            }
        }
        int[,] LevelMap3 = new int[14, 28];
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                LevelMap3[i, j] = LevelMap2[13-i, j];
            }
        }
       

        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                if (i < 15)
                    ToTalMap[i, j] = LevelMap2[i, j];
                else
                {
                    ToTalMap[i, j] = LevelMap3[i-15 , j];
                }
            }
        }
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j <28; j++)
            {
                bool BTrue = false;
                GameObject gameObject1 = GameObject.Instantiate(ThisMap);
                gameObject1.transform.SetParent(this.transform);
                if (ToTalMap[i, j] == 0)
                {

                }
                else
                {
                    gameObject1.GetComponent<SpriteRenderer>().sprite = MySprites[ToTalMap[i, j] - 1];
                }
               
                gameObject1.transform.position = new Vector3(-14*0.45f*0.7f+j * 0.45f*0.7f, 14 * 0.45f*0.7f - i * 0.45f*0.7f, 0);
                if (ToTalMap[i, j] == 1)
                {
                    if(i-1>=0)
                    {
                        if (ToTalMap[i-1, j] == 2|| ToTalMap[i - 1, j] == 1)
                        {
                            if (j - 1 >= 0)
                            {
                                if (ToTalMap[i, j - 1] == 2 || ToTalMap[i , j-1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);

                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (ToTalMap[i, j + 1] == 2 || ToTalMap[i , j+1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                  
                                }
                            }
                            
                           
                        }
                    }
                    if (i + 1 <= 28)
                    {
                        if (ToTalMap[i + 1, j] == 2 || ToTalMap[i + 1, j] == 1)
                        {
                            if (j - 1 >= 0)
                            {
                                if (ToTalMap[i, j - 1] == 2 || ToTalMap[i, j-1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                  
                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (ToTalMap[i, j + 1] == 2 || ToTalMap[i , j+1] == 1)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                  
                                }
                            }

                        }
                    }
                }
                if (ToTalMap[i, j] == 2)
                {
                    if (i - 1 >= 0)
                    {
                        if (ToTalMap[i - 1, j] == 2|| ToTalMap[i - 1, j] == 1|| ToTalMap[i - 1, j] == 7)
                        {
                          
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                          
                           


                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (ToTalMap[i, j-1] == 2 || ToTalMap[i, j-1] == 1|| ToTalMap[i, j - 1] ==7)
                        {
                           
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                          



                        }
                    }
                }
                if (ToTalMap[i, j] == 3)
                {
                    if (i - 1 >= 0)
                    {
                        if (ToTalMap[i - 1, j] == 4|| ToTalMap[i - 1, j] ==3)
                        {
                            if (j - 1 >= 0)
                            {
                                if (ToTalMap[i, j - 1] == 4 || ToTalMap[i, j-1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                    if (ToTalMap[i - 1, j] == 4 && ToTalMap[i, j - 1] == 4)
                                    {
                                        BTrue = true;
                                    }
                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (ToTalMap[i, j + 1] == 4 || ToTalMap[i , j+1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                    if (ToTalMap[i - 1, j] == 4 && ToTalMap[i, j+ 1] == 4)
                                    {
                                        BTrue = true;
                                    }

                                }
                            }
                           


                        }
                    }
                    if (j + 1 <= 27 && j - 1 >= 0 && i - 1 >= 0 && i + 1 <= 28)
                    {
                        if (ToTalMap[i - 1, j] == 4 || ToTalMap[i - 1, j] == 3)
                        {
                            if (ToTalMap[i + 1, j] == 4 || ToTalMap[i + 1, j] == 3)
                            {
                                if (ToTalMap[i, j - 1] == 4 || ToTalMap[i, j - 1] == 3)
                                {
                                    if (ToTalMap[i, j + 1] == 4 || ToTalMap[i, j + 1] == 3)
                                    {
                                        if (ToTalMap[i - 1, j] == 4&& ToTalMap[i, j - 1] == 4)
                                        {
                                            if (ToTalMap[i - 2, j] == 4 && ToTalMap[i, j - 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                                BTrue = true;
                                            }
                                        }
                                         if (ToTalMap[i - 1, j] == 4 && ToTalMap[i, j + 1] == 4)
                                        {
                                            if (ToTalMap[i - 2, j] == 4 && ToTalMap[i, j + 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                                BTrue = true;
                                            }
                                        }
                                         if (ToTalMap[i + 1, j] == 4 && ToTalMap[i, j + 1] == 4)
                                        {
                                            if (ToTalMap[i + 2, j] == 4 && ToTalMap[i, j + 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                                BTrue = true;
                                            }
                                        }
                                         if (ToTalMap[i + 1, j] == 4 && ToTalMap[i, j - 1] == 4)
                                        {
                                            if (ToTalMap[i + 2, j] == 4 && ToTalMap[i, j - 2] == 4)
                                            {
                                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                                BTrue = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (i + 1 <= 28&& !BTrue)
                    {
                        if (ToTalMap[i + 1, j] == 4 || ToTalMap[i + 1, j] == 3)
                        {
                            if (j - 1 >= 0)
                            {
                                if (ToTalMap[i, j - 1] == 4 || ToTalMap[i , j-1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                   
                                }
                            }
                            if (j + 1 <= 27)
                            {
                                if (ToTalMap[i, j + 1] == 4 || ToTalMap[i, j+1] == 3)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                  
                                }
                            }

                        }
                    }
                    
                }
                if (ToTalMap[i, j] == 4)
                {
                   
                    if (j - 1 >= 0)
                    {
                        if (ToTalMap[i, j - 1] == 3 || ToTalMap[i, j - 1] == 4 || ToTalMap[i, j - 1] == 7)
                        {


                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);

                        }
                    }
                    if (j + 1 <= 27)
                    {
                        if (ToTalMap[i, j + 1] == 4 || ToTalMap[i, j + 1] == 3 || ToTalMap[i, j + 1] == 7)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                        }
                    }
                    if (i - 1 >= 0)
                    {
                        if (ToTalMap[i - 1, j] == 3 || ToTalMap[i - 1, j] == 4 || ToTalMap[i - 1, j] == 7)
                        {
                            if (i + 1 <= 28)
                            {
                                if (ToTalMap[i + 1, j] == 3 || ToTalMap[i + 1, j] == 4 || ToTalMap[i + 1, j] == 7)
                                {
                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                }
                            }



                        }
                    }
                }
                if (ToTalMap[i, j] == 7)
                {
                    if (i - 1 >= 0)
                    {
                        if (ToTalMap[i - 1, j] == 3 || ToTalMap[i - 1, j] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                        }
                    }
                    if (i + 1 <= 27)
                    {
                        if (ToTalMap[i + 1, j] == 3 || ToTalMap[i + 1, j] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, -90);
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (ToTalMap[i, j-1] == 3 || ToTalMap[i , j-1] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                        }
                    }
                    if (j + 1 <= 27)
                    {
                        if (ToTalMap[i , j+1] == 3 || ToTalMap[i , j+1] == 4)
                        {
                            gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                        }
                    }

                }
                if (ToTalMap[i, j] == 6)
                {
                    gameObject1.transform.localScale = new Vector3(1, 1, 1);
                    gameObject1.GetComponent<Animator>().enabled = true;
                }
                if (ToTalMap[i, j] == 5)
                {
                    gameObject1.transform.localScale = new Vector3(1, 1, 1);

                }
                if (ToTalMap[i, j] == 8)
                {

                    gameObject1.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
