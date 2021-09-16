namespace Lab5
{
    class GameEngine
    {

        public static int[] getOPosition(int x, int y, Form1.CellSelection[,] grid, int[,] drawn)
        {
            int[] result = new int[3] { -1, -1, 1 };

            bool draw = true;

            int a = (int)grid[0, 0],
                b = (int)grid[0, 1],
                c = (int)grid[0, 2],
                d = (int)grid[1, 0],
                e = (int)grid[1, 1],
                f = (int)grid[1, 2],
                g = (int)grid[2, 0],
                h = (int)grid[2, 1],
                i = (int)grid[2, 2];

            //0. leftcol
            //1. midcol
            //2. rightcol
            //3. upperrow
            //4. midrow
            //5. lowerrow  
            //6. downslope
            //7. upslope
            int[] values = {
                a + b + c, 
                e + f + d,
                g + h + i,
                a + d + g,
                b + e + h,
                c + f + i,
                a + e + i,
                c + e + g };


            for (int j = 0; j < 8; j++)
            {
                if (values[j] == -3)
                {
                    result[0] = -1;//-1 is win
                    result[1] = -1;
                    result[2] = 0; // 0 is over
                    return result;
                }
                else if (values[j] == 3)
                {
                    result[0] = -2;//-2 is lose
                    result[1] = -2;
                    result[2] = 0;
                    return result;
                }
            }

            for (int m = 0; m < 3; m++)
            {
                for (int n = 0; n < 3; n++)
                {
                    if (drawn[m, n] == 0)
                    {
                        draw = false;
                    }
                }
            }

            if (draw == true)
            {
                result[0] = 0;
                result[1] = 0;
                result[2] = -1;//-1 is draw
                return result;
            }

            for (int j = 0; j < 8; j++)
            {
                if (values[j] == 2)
                {
                    if (j == 0)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[0, k] == 0)
                            {
                                result[0] = 0;
                                result[1] = k;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 1)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[1, k] == 0)
                            {
                                result[0] = 1;
                                result[1] = k;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[2, k] == 0)
                            {
                                result[0] = 2;
                                result[1] = k;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 3)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, 0] == 0)
                            {
                                result[0] = k;
                                result[1] = 0;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 4)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, 1] == 0)
                            {
                                result[0] = k;
                                result[1] = 1;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 5)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, 2] == 0)
                            {
                                result[0] = k;
                                result[1] = 2;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 6)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, k] == 0)
                            {
                                result[0] = k;
                                result[1] = k;
                                result[2] = 0; // 0 is over
                                return result;
                            }
                        }
                    }
                    else if (j == 7)
                    {
                        if (drawn[0, 2] == 0)
                        {
                            result[0] = 0;
                            result[1] = 2;
                            result[2] = 0; // 0 is over
                            return result;
                        }
                        else if (drawn[1, 1] == 0)
                        {
                            result[0] = 1;
                            result[1] = 1;
                            result[2] = 0; // 0 is over
                            return result;
                        }
                        else if (drawn[2, 0] == 0)
                        {
                            result[0] = 2;
                            result[1] = 0;
                            result[2] = 0; // 0 is over
                            return result;
                        }
                    }

                }
            }

            for (int j = 0; j < 8; j++)
            {
                if (values[j] == -2)
                {
                    if (j == 0)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[0, k] == 0)
                            {
                                result[0] = 0;
                                result[1] = k;
                                return result;
                            }
                        }
                    }
                    else if (j == 1)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[1, k] == 0)
                            {
                                result[0] = 1;
                                result[1] = k;
                                return result;
                            }
                        }
                    }
                    else if (j == 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[2, k] == 0)
                            {
                                result[0] = 2;
                                result[1] = k;
                                return result;
                            }
                        }
                    }
                    else if (j == 3)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, 0] == 0)
                            {
                                result[0] = k;
                                result[1] = 0;
                                return result;
                            }
                        }
                    }
                    else if (j == 4)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, 1] == 0)
                            {
                                result[0] = k;
                                result[1] = 1;
                                return result;
                            }
                        }
                    }
                    else if (j == 5)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, 2] == 0)
                            {
                                result[0] = k;
                                result[1] = 2;
                                return result;
                            }
                        }
                    }
                    else if (j == 6)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (drawn[k, k] == 0)
                            {
                                result[0] = k;
                                result[1] = k;
                                return result;
                            }
                        }
                    }
                    else if (j == 7)
                    {
                        if (drawn[0, 2] == 0)
                        {
                            result[0] = 0;
                            result[1] = 2;
                            return result;
                        }
                        else if (drawn[1, 1] == 0)
                        {
                            result[0] = 1;
                            result[1] = 1;
                            return result;
                        }
                        else if (drawn[2, 0] == 0)
                        {
                            result[0] = 2;
                            result[1] = 0;
                            return result;
                        }
                    }

                }

            }


                if (x - 1 > 0 && drawn[x - 1, y] == 0)
            {
                result[0] = x - 1;
                result[1] = y;
                return result;
            }
            else if (x + 1 < 3 && drawn[x + 1, y] == 0)
            {
                result[0] = x + 1;
                result[1] = y;
                return result;
            }
            else if (y - 1 > 0 && drawn[x, y - 1] == 0)
            {
                result[0] = x;
                result[1] = y - 1;
                return result;
            }
            else if (y + 1 < 3 && drawn[x, y + 1] == 0)
            {
                result[0] = x;
                result[1] = y + 1;
                return result;
            }
            else
            {
                for (int m = 0; m < 3; m++)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        if (drawn[m, n] == 0)
                        {
                            result[0] = m;
                            result[1] = n;
                            return result;
                        }
                    }
                }
            }

            return result;
        }
    }
}
