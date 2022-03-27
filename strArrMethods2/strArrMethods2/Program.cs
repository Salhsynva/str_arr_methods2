using System;

namespace strArrMethods2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qrupun nomresini daxil edin: "); // ilk 2 herf boyuk ve 3 reqem umumi 5
            string groupNo = Console.ReadLine();
            while (!TwoLetterThreeDigit(groupNo))
            {
                Console.WriteLine("No deyeri 2 boyuk herfle baslamali ve sonrasinda 3 reqem olmalidir");
                groupNo = Console.ReadLine();
            }

            Console.WriteLine("max telebe sayini daxil edin: ");
            int studentLimit = Convert.ToInt32(Console.ReadLine());
            while (studentLimit < 0 || studentLimit > 20)
            {
                Console.WriteLine("telebe limiti 0-dan kicik və 20-den boyuk ola bilmez");
                studentLimit = Convert.ToInt32(Console.ReadLine());
            }

            Group group1 = new Group();
            group1.No = groupNo;
            group1.Students = new Student[0];
            group1.StudentLimit = studentLimit;
            int answer;
            do
            {
                Console.WriteLine("=========MENU========");
                Console.WriteLine("1. Telebe daxil edin");
                Console.WriteLine("2. Butun telebelere bax");
                Console.WriteLine("3. Telebeler uzre axtaris et");
                Console.WriteLine("0. Programi bitir");

                string fullName = "";
                double avgPoint = 0;
                Console.WriteLine("seciminizi edin: ");
                string answerstr = Console.ReadLine();
                answer = Convert.ToInt32(answerstr);

                if(answer < 0 || answer > 3)
                {
                    Console.WriteLine("menuda bele secim yoxdur!");
                }
                if (answer == 1)
                {
                    if (group1.Students.Length == studentLimit)
                    {
                        Console.WriteLine("telebe limiti dolub!");
                    }
                    else
                    {
                        fullName = FullName();
                        Console.WriteLine("qiymetivizin ededi ortasini daxil edin: ");
                        avgPoint = Convert.ToDouble(Console.ReadLine());
                        while (avgPoint < 0 || avgPoint > 100)
                        {
                            Console.WriteLine("orta bal 0dan kicik 100den boyuk ola bilmez!");
                            avgPoint = Convert.ToDouble(Console.ReadLine());
                        }
                        Student student = new Student(fullName)
                        {
                            AvgPoint = avgPoint,
                            GroupNo = groupNo
                        };
                        Array.Resize(ref group1.Students, group1.Students.Length + 1);
                        group1.AddStudent(student);
                    }
                }
                else if (answer == 2)
                {
                    foreach (var item in group1.Students)
                    {
                        Console.WriteLine($"telebenin adi soyadi: {item.FullName} - qrup adi: {item.GroupNo} - orta bali: {item.AvgPoint}");
                    }
                }
                else if (answer == 3)
                {
                    Console.WriteLine("axtaris deyerini daxil edin: ");
                    string answer2 = Console.ReadLine();
                    bool check = false;
                    foreach (var item in group1.Students)
                    {
                        if (item.FullName == answer2)
                        {
                            Console.WriteLine($"telebenin adi soyadi: {item.FullName} - qrup adi: {item.GroupNo} - orta bali: {item.AvgPoint}");
                            check = true;
                        }
                        else if (answer2 == groupNo)
                        {
                            if(item.GroupNo == answer2)
                            {
                                Console.WriteLine($"telebenin adi soyadi: {item.FullName} - qrup adi: {item.GroupNo} - orta bali: {item.AvgPoint}");
                                check = true;
                            }
                        }
                        else if (IsNumber(answer2, item.AvgPoint))
                        {
                            if (IsNumber(answer2, item.AvgPoint))
                            {
                                Console.WriteLine($"telebenin adi soyadi: {item.FullName} - qrup adi: {item.GroupNo} - orta bali: {item.AvgPoint}");
                                check = true;
                            }
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("axtaris deyeri telebelerle uzlasmir!");
                    }
                }
                else if (answer == 0)
                {
                    Console.WriteLine("proqram dayandirildi");
                    break;
                }
            } while (answer != 0);
        }

        static bool TwoLetterThreeDigit(string str)
        {
            if (str.Length == 5)
            {
                if (char.IsUpper(str[0]) && char.IsUpper(str[1]))
                {
                    if (char.IsDigit(str[2]) && char.IsDigit(str[3]) && char.IsDigit(str[4]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static string FullName()
        {
            string fullname;
            string[] fullnameArray;
            do
            {
                Console.WriteLine("ad ve soyadinizi daxil edin: ");
                fullname = Console.ReadLine();
                fullname = fullname.Trim();
                fullnameArray = fullname.Split(' ');
            } while(!(fullnameArray.Length == 2 && char.IsUpper(fullnameArray[0][0]) && char.IsUpper(fullnameArray[1][0])));
           
            return fullname;
        }

        static bool IsNumber(string str, double number)
        {
            return (str.StartsWith($"{number}") && str.EndsWith($"{number}"));
        }

        


    }
}
