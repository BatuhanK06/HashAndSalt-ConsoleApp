using System;
using HashAndSaltConsoleApp.src.BatuHash;
using HashAndSaltConsoleApp.src.IsValid;

namespace HashAndSaltConsoleApp
{
    class Program
    {
        static void Main()
        {
            bool kontrol = true;
            while (kontrol)
            {
                Console.WriteLine("Konuşmaya Başlayın:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Girdi boş olamaz. Lütfen tekrar deneyin.");
                    continue;
                }

                Console.WriteLine("İşlem Seçin (1: Batu Encrypt, 2: Batu Decrypt):");
                string choice = Console.ReadLine();

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 2 girin.");
                    continue;
                }

                if (choice == "1")
                {
                    if (IsValid.IsValidForEncryption(input))
                    {
                        string result = BatuEncrypt.Encrypt(input);
                        Console.WriteLine($"Orijinal metin: {input}\nŞifrelenmiş metin: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Şifreleme için geçersiz karakterler var.");
                    }
                }
                else if (choice == "2")
                {
                    if (IsValid.IsValidForDecryption(input))
                    {
                        string result = BatuDecrypt.Decrypt(input);
                        Console.WriteLine($"Orijinal metin: {input}\nÇözümlenmiş metin: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Şifre çözme için geçersiz hex dizileri var.");
                    }
                }
            }
        }
    }
}
