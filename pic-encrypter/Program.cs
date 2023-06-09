using System;

namespace pic_encrypter
{
    internal class Executable
    {
        static void Main(string[] args)
        {
            ChiefEncrypter Encrypter= new ChiefEncrypter();
            int ChosenOption;
            do
            {
                string Path;
                Console.WriteLine("Слова в Картинки\n1 - Преобразовать сообщение в картинку\n2 - Преобразовать " +
                    "документ в картинку\n3 - Преобразовать картинку в текст\n4 - Выйти");
                ChosenOption = 0;
                while (!(ChosenOption > 0 && ChosenOption < 5))
                {
                    try
                    {
                        ChosenOption = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Опция выбрана неверно");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Слишком большой ввод");
                    }
                }

                bool Success = false;
                switch (ChosenOption)
                {
                    case 1:
                        try
                        {
                            Encrypter.SetStrategy(new MessageEncrypter());
                            Console.WriteLine("Введите путь, по которому будет сохранена картинка");
                            Path = Console.ReadLine();
                            Console.WriteLine("Введите сообщение, которое вы хотите закодировать");
                            string Message = Console.ReadLine();
                            Encrypter.InitializeEncrypting(Path, Message);
                            Success = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            if (Success)
                            {
                                Console.WriteLine("Изображение сохранено успешно!");
                            }
                        }        
                        break;
                    case 2:
                        try
                        {
                            Encrypter.SetStrategy(new DocumentEncrypter());
                            Console.WriteLine("Введите путь, по которому будет сохранена картинка");
                            Path = Console.ReadLine();
                            Console.WriteLine("Введите путь к тексту, который вы хотите закодировать");
                            string MessagePath = Console.ReadLine();
                            Encrypter.InitializeEncrypting(Path, MessagePath);
                            Success = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            if (Success)
                            {
                                Console.WriteLine("Изображение сохранено успешно!");
                            }
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Введите путь, по которому сохранена нужная картинка");
                            Path = Console.ReadLine();
                            Decrypter.ConvertToText(Path);
                            Success = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            if (Success)
                            {
                                Console.WriteLine("Текст сохранён успешно!");
                            }
                        }
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (ChosenOption != 4);
        }
    }
}
