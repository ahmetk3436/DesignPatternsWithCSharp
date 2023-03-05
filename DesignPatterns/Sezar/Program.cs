using System;

class Sezar
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Şifrelenecek metni girin:");
        string metin = Console.ReadLine();

        Console.WriteLine("Anahtar değerini girin:");
        int anahtar = 3;

        string sifreliMetin = Sifrele(metin, anahtar);
        Console.WriteLine("Şifreli metin: " + sifreliMetin);

        string cozulmusMetin = Coz(sifreliMetin, anahtar);
        Console.WriteLine("Çözülmüş metin: " + cozulmusMetin);

        Console.ReadLine();
    }

    static string Sifrele(string metin, int anahtar)
    {
        string sifreliMetin = "";
        foreach (char karakter in metin)
        {
            if (Char.IsLetter(karakter))
            {
                char sifreliKarakter = (char)((((karakter + anahtar) - 'A') % 26) + 'A');
                if (karakter >= 'a' && karakter <= 'z')
                {
                    sifreliKarakter += (char)('a' - 'A');
                }
                else if (karakter >= 'ç' && karakter <= 'ü')
                {
                    sifreliKarakter += (char)('Ç' - 'A');
                }
                else if (karakter == 'ı')
                {
                    sifreliKarakter = 'İ';
                }
                else if (karakter == 'ğ')
                {
                    sifreliKarakter = 'Ğ';
                }
                else if (karakter == 'ö')
                {
                    sifreliKarakter = 'Ö';
                }
                else if (karakter == 'ş')
                {
                    sifreliKarakter = 'Ş';
                }
                sifreliMetin += sifreliKarakter;
            }
            else
            {
                sifreliMetin += karakter;
            }
        }
        return sifreliMetin;
    }

    public static string Coz(string sifreliMetin, int anahtar)
    {
        string cozulmusMetin = "";

        foreach (char karakter in sifreliMetin)
        {
            if (char.IsLetter(karakter))
            {
                int karakterKod = (int)karakter;

                int cozulmusKarakterKod = karakterKod - anahtar;

                if (char.IsUpper(karakter))
                {
                    if (cozulmusKarakterKod < 'A')
                    {
                        cozulmusKarakterKod = cozulmusKarakterKod + 26;
                    }
                }
                else if (char.IsLower(karakter))
                {
                    if (cozulmusKarakterKod < 'a')
                    {
                        cozulmusKarakterKod = cozulmusKarakterKod + 26;
                    }
                }

                if (cozulmusKarakterKod >= 199 && cozulmusKarakterKod <= 305)
                {
                    cozulmusKarakterKod = cozulmusKarakterKod + ('a' - 199);
                }
                else if (cozulmusKarakterKod >= 305 && cozulmusKarakterKod <= 252)
                {
                    cozulmusKarakterKod = cozulmusKarakterKod + ('A' - 305);
                }
                else if (cozulmusKarakterKod == 287)
                {
                    cozulmusKarakterKod = 286;
                }
                else if (cozulmusKarakterKod == 246)
                {
                    cozulmusKarakterKod = 214;
                }
                else if (cozulmusKarakterKod == 351)
                {
                    cozulmusKarakterKod = 350;
                }

                char cozulmusKarakter = (char)cozulmusKarakterKod;

                cozulmusMetin += cozulmusKarakter;
            }
            else
            {
                cozulmusMetin += karakter;
            }
        }

        return cozulmusMetin;
    }


}


