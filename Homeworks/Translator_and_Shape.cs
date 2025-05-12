using System;
/* Առաջադրանք:
Ստեղծել աբստրակտ Translator կլասը, որից ժառանգվում են Russian, Spanish, French կլասները:
Translator-ն ունի translate աբստրակտ մեթոդը, որն իբրև պարամետր ստանում է string 
տիպի բառ և վերադարձնում դրա թարգմանությունը համապատասխան լեզվով:
Ընդունենք, որ անհրաժեշտ է թարգմանել հետևյալ անգլերեն բառերը.
Apple, Banana, Orange, Mango, Pineapple, Grape, Strawberry, Cherry, Watermelon, Peach
Թարգմանությունները կարող եք ներկայացնել struct-ով, որն ունի original անգլերեն բառը և
 դրան համապատասխանող թարգմանությունը:
Նշված բառերի թարգմանություններն անհրաժեշտ է պահել համապատասխան կլասնսերում, 
սակայն հիշողության օպտիմալ օգտագործմամբ: */

public struct Translation
{
    public string Original {get;}
    public string Translated {get;}

    public Translation (string original, string translated)
    {
        Original = original;
        Translated = translated;
    }
}

public abstract class Translator
{
    protected Translation[]? translations;

    public Translator()
    {
        InitializeTranslations();
    }
    protected abstract void  InitializeTranslations();
    

    public void Translate (string wordToTranslate)
    {
        foreach(var item in translations)
        {
            if (item.Original == wordToTranslate)
            {
                System.Console.WriteLine($"{wordToTranslate} in {GetType()} is {item.Translated}"); 
                return;
            }
        }
        System.Console.WriteLine($"Word {wordToTranslate} is not founded"); 
    }
}

class Russian : Translator 
{
    protected override void InitializeTranslations()
    {
        translations = new Translation[]
        {
            new Translation("Apple", "Яблоко"),
            new Translation("Banana", "Банан"),
            new Translation("Orange", "Апельсин"),
            new Translation("Mango", "Манго"),
            new Translation("Pineapple", "Ананас"),
            new Translation("Grape", "Виноград"),
            new Translation("Strawberry", "Клубника"),
            new Translation("Cherry", "Вишня"),
            new Translation("Watermelon", "Арбуз"),
            new Translation("Peach", "Персик")
        };
    }

}
class Spanish : Translator 
{
    protected override void InitializeTranslations()
    {
          translations = new Translation[]
          {
              new Translation("Apple", "Manzana"),
              new Translation("Banana", "Plátano"),
              new Translation("Orange", "Naranja"),
              new Translation("Mango", "Mango"),
              new Translation("Pineapple", "Piña"),
              new Translation("Grape", "Uva"),
              new Translation("Strawberry", "Fresa"),
              new Translation("Cherry", "Cereza"),
              new Translation("Watermelon", "Sandía"),
              new Translation("Peach", "Melocotón")
          };
    }
}
class French : Translator 
{
    protected override void InitializeTranslations()
    {
        translations = new Translation[]
        {
            new Translation("Apple", "Pomme"),
            new Translation("Banana", "Banane"),
            new Translation("Orange", "Orange"),
            new Translation("Mango", "Mangue"),
            new Translation("Pineapple", "Ananas"),
            new Translation("Grape", "Raisin"),
            new Translation("Strawberry", "Fraise"),
            new Translation("Cherry", "Cerise"),
            new Translation("Watermelon", "Pastèque"),
            new Translation("Peach", "Pêche")
        };
    }
}
/*------------------------------------------------------------------------------*/
/* Ստեղծել Shape աբստրակտ կլասը, որի աբստրակտ մեթոդներն են՝  surface և  draw, 
առաջինը՝ մակերեը հաշվելու համար, երկրորդը նկարելու
Կլասն ունի նաև ոչ աբստրակտ print մեթոդը, որը կանչելիս ելքագրվում է 
տվյալ Shape-ի անունը, մակերեսը, ինչպես նաև պատկերը.
Կլասից ժառանգվում են՝
Square, Rectangle, կլասները */

public abstract class Shape
{
    public int Width {get; private set;}
    public int Length {get; private set;}

    public Shape (int width, int length)
    {
        Width = width;
        Length = length;
        CheckValidation();
    }
    protected abstract int Surface();
    protected abstract void Draw();

    protected abstract void CheckValidation();
    

    public void Print ()
    {
        Console.WriteLine($"Shape type: {GetType()} -- Surface {Surface()}");
        Draw();
    }
}

class Square : Shape
{
    public Square(int width, int length) : base (width, length ){}
    protected override void CheckValidation()
    {
        if (this.Length != this.Width)
            throw new Exception($"This shape is not a {GetType()}");
    }

    protected override int Surface() => Length * Width;

    protected override void Draw()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                Console.Write("= ");
            }
            System.Console.WriteLine();
        }     
    }

}

class Rectangle : Shape
{
     public Rectangle(int width, int length) : base (width, length ){}
    protected override int Surface() => Length * Width;
    protected override void CheckValidation()
    {
        if (this.Length == this.Width)
            throw new Exception($"This shape is not a {GetType()}");
    }
    protected override void Draw()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                Console.Write("= ");
            }
            System.Console.WriteLine();
        }     
    }

}
