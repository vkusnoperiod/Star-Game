using System;
using System.Threading;
namespace StarGame;
class Program
{
    static void Main()
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        static void DrawFrame()
        {
            Console.SetCursorPosition(Console.LargestWindowWidth / 4, Console.LargestWindowHeight / 4);
            for (int i = Console.LargestWindowWidth / 4; i < Console.LargestWindowWidth * 3 / 4; i++)
            {
                Console.Write("_");
            }
            for (int i = Console.LargestWindowHeight / 4 + 1; i < Console.LargestWindowHeight * 3 / 4 + 1; i++)
            {
                Console.SetCursorPosition(Console.LargestWindowWidth * 3 / 4, i);
                Console.Write("|");
            }
            for (int i = Console.LargestWindowWidth * 3 / 4 - 1; i > Console.LargestWindowWidth / 4 - 1; i--)
            {
                Console.SetCursorPosition(i, Console.LargestWindowHeight * 3 / 4);
                Console.Write("_");
            }
            for (int i = Console.LargestWindowHeight * 3 / 4; i > Console.LargestWindowHeight / 4; i--)
            {
                Console.SetCursorPosition(Console.LargestWindowWidth / 4, i);
                Console.Write("|");
            }
        }
        int wmin = Console.LargestWindowWidth / 4;
        int wmax = Console.LargestWindowWidth * 3 / 4;
        int hmin = Console.LargestWindowHeight / 4;
        int hmax = Console.LargestWindowHeight * 3 / 4;
        ConsoleKeyInfo next;
        Console.WriteLine("Вас приветствует игра-звездочка!\nПоймайте красную звуздочку как можно быстрее!\nХотите поиграть?");
        Console.WriteLine("Чтобы начать, введите \"Yes\"");
        if (Console.ReadLine() == "Yes")
        {
            int countermax = 10000;
            do
            {
                DrawFrame();//Функция рисования рамки
                bool check1 = true;
                Random rnd = new Random();
                int w1start = rnd.Next(wmin + 1, wmax - 1);
                int h1start = rnd.Next(hmin + 1, hmax - 1);
                int wstart = rnd.Next(wmin + 1, wmax - 1);
                int hstart = rnd.Next(hmin + 1, hmax - 1);
                bool check = true;
                Console.SetCursorPosition(wstart, hstart);
                Console.Write("*");
                Console.SetCursorPosition(w1start, h1start);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int counter=0;
                int turnv;
            turn:
                while (check)
                {
                    Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 5, Console.LargestWindowHeight / 5);
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.Write($"Текущий счет: {counter}");
                    Console.SetCursorPosition(Console.LargestWindowWidth / 2 - 4, Console.LargestWindowHeight / 5 - 2);
                    Console.Write($"Ваш рекорд: {countermax}");
                    Console.SetCursorPosition(0, Console.LargestWindowHeight / 5 - 1);
                    Console.ForegroundColor = ConsoleColor.Black;
                    ConsoleKeyInfo turn = Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (!check1)
                    {
                        Console.Clear();
                        DrawFrame();
                        check1 = true;
                    }
                    switch (turn.Key)
                    {
                        case ConsoleKey.W:
                            Console.SetCursorPosition(wstart, hstart); //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('0');
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(wstart, hstart - 1);
                            Console.Write("*");
                            hstart--;
                            break;
                        case ConsoleKey.S:
                            Console.SetCursorPosition(wstart, hstart); //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('0');
                            Console.ForegroundColor = ConsoleColor.Yellow; //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.SetCursorPosition(wstart, hstart + 1);
                            Console.Write("*");
                            hstart++;
                            break;
                        case ConsoleKey.A:
                            Console.SetCursorPosition(wstart, hstart); //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('0');
                            Console.ForegroundColor = ConsoleColor.Yellow; //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.SetCursorPosition(wstart - 1, hstart);
                            Console.Write("*");
                            wstart--;
                            break;
                        case ConsoleKey.D:
                            Console.SetCursorPosition(wstart, hstart); //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write('0');
                            Console.ForegroundColor = ConsoleColor.Yellow; //Начиная с первого хода. Замазывание предыдущей звездочки.
                            Console.SetCursorPosition(wstart + 1, hstart);
                            Console.Write("*");
                            wstart++;
                            break;
                        default:
                            Console.WriteLine("Неверный ход.\n Сходите заново.");
                            check1 = false;
                            goto turn;
                    }
                    if ((Math.Abs(wstart - w1start) <= 1 && Math.Abs(wstart - w1start) <= 1) || (Math.Abs(wstart - w1start) <= 1 && Math.Abs(wstart - w1start) <= 1)) goto endf;
                    boundsvillian:
                    Thread.Sleep(200);
                    Console.SetCursorPosition(w1start, h1start); //Начиная с первого хода. Замазывание предыдущей звездочки.
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write('0');
                    Console.ForegroundColor = ConsoleColor.Red; //Начиная с первого хода. Замазывание предыдущей звездочки.
                    turnv = rnd.Next(1, 5);
                    switch (turnv)
                    {
                        case 1:
                            if (h1start-1 <= hmin || h1start-1 >= hmax) goto boundsvillian;
                            h1start--;
                            break;
                        case 2:
                            if (w1start+1 <= wmin || w1start+1 >= wmax) goto boundsvillian;
                            w1start++;
                            break;
                        case 3:
                            if (h1start+1 <= hmin || h1start+1 >= hmax) goto boundsvillian;
                            h1start++;
                            break;
                        case 4:
                            if (w1start-1 <= wmin || w1start-1 >= wmax) goto boundsvillian;
                            w1start--;
                            break;
                    }
                    Console.SetCursorPosition(w1start, h1start);
                    Console.Write("*");
                    endf:
                    if (wstart >= wmax || wstart <= wmin || hstart <= hmin || hstart >= hmax||(Math.Abs(wstart-w1start)<=1 && Math.Abs(wstart-w1start)<=1)||(Math.Abs(wstart - w1start)<=1 && Math.Abs(wstart - w1start) <=1)) check = false;
                    counter++;
                }
                Console.WriteLine("Игра окончена");
                if (counter < countermax)
                {
                    countermax = counter;
                    Console.WriteLine("Поздравляю!\nВы достигли нового рекорда!");
                    Console.WriteLine($"Ваш текущий рекорд - {countermax}");
                }
            onemore:
                Console.WriteLine("Если хотите попробовать побить рекорд, то нажмите Enter\nЕсли не хотите, то нажмите Escape");
                Console.ForegroundColor = ConsoleColor.Black;
                next = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                if (next.Key != ConsoleKey.Enter && next.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("Так играем еще или как?");
                    goto onemore;
                }
            } while (next.Key != ConsoleKey.Escape);
        }
        Console.SetCursorPosition(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
        Console.Write("До встречи!");
        Console.SetCursorPosition(1, Console.LargestWindowHeight);
    }
}