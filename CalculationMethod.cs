using UnityEngine;

public class CalculationMethod : MonoBehaviour
{

    public int easy_Calculation(int A, int B)
    {
        int F;

        if (A != B)
        {
            if (A % B == 0)
            {
                Debug.Log("*A / B");
                F = A / B;
            }
            else if (A > B)
            {
                Debug.Log("*A - B");
                F = A - B;
            }
            else if (A + B <= 10)
            {
                Debug.Log("*A * B");
                F = A * B;
            }
            else
            {
                Debug.Log("*A + B");
                F = A + B;
            }
        }
        else
        {
            if (A + B >= 10)
            {
                // + * /
                // [5,5]、[6,6]、[7,7]、[8,8]、[9,9]
                int y = Random.Range(1, 3);
                if (y == 1)
                {
                    Debug.Log("*A + B");
                    F = A + B;
                }
                else if (y == 2)
                {
                    Debug.Log("*A * B");
                    F = A * B;
                }
                else
                {
                    Debug.Log("*A / B");
                    F = A / B;
                }
            }
            else
            {
                // * + /
                // [1,1]、[2,2]、[3,3]、[4,4]
                int y = Random.Range(1, 3);
                if (y == 1)
                {
                    Debug.Log("*A + B");
                    F = A + B;
                }
                else if (y == 2)
                {
                    Debug.Log("*A * B");
                    F = A * B;
                }
                else
                {
                    Debug.Log("*A / B");
                    F = A / B;
                }
            }
        }
        return F;
    }


    public int medium_Calculation(int A, int B)
    {
        int F;

        if (A != B)
        {
            if (A % B == 0)
            {
                Debug.Log("**A + B");
                F = A + B;
            }
            else if (A < A/5 - B )
            {
                Debug.Log("**A - B");
                F = A - B;
            }
            else if (A + B <= 10)
            {
                Debug.Log("**A * B");
                F = A * B;
            }
            else
            {
                Debug.Log("**A + B");
                F = A + B;
            }
        }
        else
        {
            if (A + B >= 10)
            {
                // + * /
                // [5,5]、[6,6]、[7,7]、[8,8]、[9,9]
                int y = Random.Range(1, 3);
                if (y == 1)
                {
                    Debug.Log("**A + B");
                    F = A + B;
                }
                else if (y == 2)
                {
                    Debug.Log("**A * B");
                    F = A * B;
                }
                else
                {
                    Debug.Log("**A / B");
                    F = A / B;
                }
            }
            else
            {
                // * + /
                // [1,1]、[2,2]、[3,3]、[4,4]
                int y = Random.Range(1, 3);
                if (y == 1)
                {
                    Debug.Log("**A + B");
                    F = A + B;
                }
                else if (y == 2)
                {
                    Debug.Log("**A * B");
                    F = A * B;
                }
                else
                {
                    Debug.Log("**A / B");
                    F = A / B;
                }
            }
        }
        return F;
    }

    public int Hard_Calculation(int A, int B)
    {
        int F;

        if (A != B)
        {
            if (A % B == 0 && B != 1)
            {
                Debug.Log("***A / B");
                F = A / B;
            }
            else if ( A == 1 || B == 1)
            {
                int y = Random.Range(1, 2);

                if (A > B)
                {
                    if(y == 1)
                    {
                        Debug.Log("***A + B");
                        F = A + B;
                    }
                    else
                    {
                        Debug.Log("***A - B");
                        F = A - B;
                    }
                }
                else
                {
                    if (y == 1)
                    {
                        Debug.Log("***A + B");
                        F = B + A;
                    }
                    else
                    {
                        Debug.Log("***A - B");
                        F = B - A;
                    }
                }
            }
            else if ( A < 5 || B < 20 && B > 10)
            {
                if( A * B > 500)
                {
                    Debug.Log("***A + B");
                    F = A + B;
                }
                else
                {
                    Debug.Log("***A * B");
                    F = A * B;
                }
            }
            else if (B < 5 || A < 20 && A > 10)
            {
                if (A * B > 500)
                {
                    Debug.Log("***A + B");
                    F = A + B;
                }
                else
                {
                    Debug.Log("***A * B");
                    F = A * B;
                }
            }
            else if (A + B <= 20)
            {
                if (A * B > 500)
                {
                    Debug.Log("***A + B");
                    F = A + B;
                }
                else
                {
                    Debug.Log("***A * B");
                    F = A * B;
                }
            }
            else if (A > (A+B)/2 || B < (A+B)/2)
            {
                Debug.Log("***A - B");
                F = A - B;
            }
            else
            {
                Debug.Log("***A + B");
                F = A + B;
            }
        }
        else
        {
            if (A + B >= 10)
            {
                // + * /
                // [5,5]、[6,6]、[7,7]、[8,8]、[9,9]
                int y = Random.Range(1, 3);
                if (y == 1)
                {
                    Debug.Log("***A + B");
                    F = A + B;
                }
                else if (y == 2)
                {
                    Debug.Log("***A * B");
                    F = A * B;
                }
                else
                {
                    Debug.Log("***A / B");
                    F = A / B;
                }
            }
            else
            {
                // * + /
                // [1,1]、[2,2]、[3,3]、[4,4]
                int y = Random.Range(1, 3);
                if (y == 1)
                {
                    Debug.Log("***A + B");
                    F = A + B;
                }
                else if (y == 2)
                {
                    Debug.Log("***A * B");
                    F = A * B;
                }
                else
                {
                    Debug.Log("***A / B");
                    F = A / B;
                }
            }
        }
        return F;
    }

    public int insane_Calculation(int A, int B)
    {
        return 5;
    }

}
