using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string TheRabbitsFoot(string s, bool encode)
        {
            string S = "h"; // строка должна быть не пустая
            string not = "initial conditions is not correct";
            if (s==null)
            {
                return not;
            }

            if (encode)
            {
              //  Console.WriteLine(s);
                foreach (var t in s)
                {
                    if (t == ' ')
                    {
                        s = s.Remove(s.IndexOf(t), 1);
                    }
                }
                double sl = s.Length;
               // Console.WriteLine(sl);
               // Console.WriteLine(s);
                sl = Math.Sqrt(sl);
                int LineNumber;
                int ColumNumber;
              //  Console.WriteLine(Math.Truncate(sl));
                int stl = (int)Math.Truncate(sl); //находим целую часть

                string sls = sl.ToString();//переводим значение корня в стринг
                int str = int.Parse(sls[sls.IndexOf(',') + 1].ToString());// переводим элемент строки из char в string, а потом этот же элемент 
               // Console.WriteLine(sl);
                //Console.WriteLine(str);
                //Console.WriteLine(stl);

                if (str > stl) { ColumNumber = str; LineNumber = stl; } // находим верхние и нижие пределы корня и определяем количество строк и столбцов
                else { ColumNumber = stl; LineNumber = str; }

                while (ColumNumber * LineNumber < s.Length) { LineNumber++; }//добавляем количество строк матрицы, чтобы элементы строки влезли в нее

                while (ColumNumber * LineNumber != s.Length) { s = s.Insert(s.Length, " "); }//добавляем количество пробелов, чтобы элементы строки равнялись по количеству элементам матрицы
                //Console.WriteLine(s);
                //Console.WriteLine(LineNumber + "=строка");
                //Console.WriteLine(ColumNumber + "=столбец");

                char[,] Encrypt = new char[LineNumber, ColumNumber];

                int TempS = 0;
                //for (int t = 0; t < s.Length; t++)
                //{
                for (int i = 0; i < LineNumber; i++)
                {
                    for (int j = 0; j < ColumNumber; j++)
                    {

                        Encrypt[i, j] = s[TempS]; // элементы из строки переводим в матрицу
                        TempS++;
                    }

                }
                //}

                //for (int i = 0; i < LineNumber; i++)
                //{
                //    for (int j = 0; j < ColumNumber; j++)
                //    {
                //        Console.Write(Encrypt[i, j] + "\t");
                //    }
                //    Console.WriteLine();
                //}

               // string S = "h"; // строка должна быть не пустая
                char temp;
                TempS = 0;
                for (int j = 0; j < ColumNumber; j++)
                {
                    for (int i = 0; i < LineNumber; i++)
                    {
                        if (Encrypt[i, j] != ' ')
                        {
                            temp = Encrypt[i, j];
                            S = S.Insert(TempS, temp.ToString());// char to string и добавляем подстроку в строку, для этого нужен был string
                            TempS++;
                        }
                    }

                    S = S.Insert(TempS, " "); // разделяем пробелами
                    TempS++;
                }
                S = S.Remove(S.Length - 1, 1);//удаляем "h"б который добавили
                S = S.Remove(S.Length - 1, 1);
                //Console.WriteLine(S);

            }
            if (!encode)
            {
                //Console.WriteLine(s);
                s = s.Insert(s.Length, " ");
                int check = s.IndexOf(' ');
                int count = 2;
                while ((count * check < s.Length) && (s[count * check] != ' '))
                {
                    //int test = count * check;
                    //char test2 = s[count * check];
                    s = s.Remove(count * check + 1, 1); //находим максимальную ширину 
                    count++;                            // подгоняем всю строку под нее
                    //Console.WriteLine(test + "=счет \t значение=" + test2);
                }
                s = s.Remove(check, 1);
                //Console.WriteLine(s);
                int dLength = s.Length;
                //Console.WriteLine(check);
                //Console.WriteLine(dLength);
                //Console.WriteLine(s[check * 2]);

                int LineNumber = dLength / check;///29/5
                int ColumNumber = check;
                char[,] Encrypt = new char[LineNumber, ColumNumber];

                int TempS = 0;
                //for (int t = 0; t < s.Length; t++)
                //{
                for (int i = 0; i < LineNumber; i++)
                {
                    for (int j = 0; j < ColumNumber; j++)
                    {

                        Encrypt[i, j] = s[TempS]; // элементы из строки переводим в матрицу
                        TempS++;
                    }

                }
                //}

                //for (int i = 0; i < LineNumber; i++)
                //{
                //    for (int j = 0; j < ColumNumber; j++)
                //    {
                //        Console.Write(Encrypt[i, j] + "\t");
                //    }
                //    Console.WriteLine();
                //}

                
                char temp;
                TempS = 0;
                for (int j = 0; j < ColumNumber; j++)
                {
                    for (int i = 0; i < LineNumber; i++)
                    {
                        if (Encrypt[i, j] != ' ')
                        {
                            temp = Encrypt[i, j];
                            S = S.Insert(TempS, temp.ToString());// char to string и добавляем подстроку в строку, для этого нужен был string
                            TempS++;
                        }
                    }

                    //    S = S.Insert(TempS, " "); // разделяем пробелами
                    //    TempS++;
                }


                //Console.WriteLine(S);
                S = S.Remove(S.Length - 1, 1);//удаляем "h"б который добавили
               
                //Console.WriteLine(S);
            }

            return S; 
        }
        //static void Main(string[] args)
        //{
        //    bool encode = false;
        //    //string s = "отдай мою кроличью лапку";
        //    string s = "омоюу толл1 дюиа акчп йрьк";
        //    //string s = "null";
        //    string S = TheRabbitsFoot(s, encode);
        //    Console.WriteLine(s);
        //    Console.WriteLine(S[S.Length-1]);
        //    Console.WriteLine(S[0]);
        //    Console.WriteLine(S);

        //}
    }
}
